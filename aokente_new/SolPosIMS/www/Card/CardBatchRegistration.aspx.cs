using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ims.Card.Model;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Card_CardBatchRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if(!IsPostBack )
        {
            cardstatus.Items.Insert(0, new ListItem("未激活", "未激活"));
            cardstatus.Items.Insert(1, new ListItem("已激活", "已激活"));
            cardstatus.Items.Insert(2, new ListItem("全部", ""));

            //InitListControlHelper.BindNormalTableToListControl(GroupID1, "GroupID", "GroupName", "tb_Group", "", "DeleStatus =0", "");
            //GroupID1.Items.Insert(0, new ListItem("全部", ""));
            InitListControlHelper.BindNormalTableToListControl(TypeID, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");
            TypeID.Items.Insert(0, new ListItem("全部", ""));
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_CardNoActive o = ParameterBindHelper.BindParameterToObject(typeof(v_CardNoActive), BindParameterUsage.OpQuery) as v_CardNoActive;

        if (addeddate1.Value != "" && addeddate2.Value != "")
        {
            o.addeddate1 = addeddate1.Value + " 00:00:00";
            o.addeddate2 = addeddate2.Value + " 23:59:60";
        }
        else if (addeddate1.Value != "" && addeddate2.Value == "")
        {
            o.addeddate1 = addeddate1.Value + " 00:00:00";
        }
        else if (addeddate1.Value == "" && addeddate2.Value != "")
        {
            o.addeddate2 = addeddate2.Value + " 23:59:60";
        }

        //if (Ims.Main.ImsInfo.UserIsInRoles("seller") != "")//销售人员
        //{
        //    o.GroupID = PmTtBLLHelper.GetManagerGroupID(Ims.Main.ImsInfo.CurrentUserId);//获取当用销售人员所在的组号
        //}
        
        o.TypeID = TypeID.Value;
        //o.GroupID = GroupID1.Value;
        o.SaleMemID = Request.Form.Get("Member1");


        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void btnBatch_ServerClick(object sender, EventArgs e)
    {

    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足的激活卡信息!");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        int n = 0;
        int count = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            //tb_ProductTypes aa = new tb_ProductTypes();
            tb_Card car = new tb_Card();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    car.card = id;
                    int m = Ims.Card.BLL.CardHelperBLL.DeleteObject(car);
                    if (m > 0)
                    {
                        count++;
                    }
                }
                else
                {
                    n++;
                }
            }
            if (n == this.GridView1.Rows.Count)
            {
                WebClientHelper.DoClientMsgBox("请先选择要删除的项!");
                return;
            }
            if (count > 0)
            {
                GridView1.DataSourceID = "ObjectDataSource1";
                GridView1.PageIndex = 0;
                GridView1.DataBind();

                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "删除操作";
                log.logmsg = log.operater + "对未激活会员卡进行删除操作,成功删除" + count + "条数据记录!";
                LogHelperBLL.InsertObject(log);

                WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                return;
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败!");
            }
        }
    }
}
