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
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;
using Ims.PM.BLL;
using Ims.Card.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Card_CardList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
 
    
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
           Area_Code.Items.Insert(0, new ListItem("全部", ""));
           /*Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
           Status.Items.Insert(0, new ListItem("正常", "1"));
           Status.Items.Insert(1, new ListItem("挂失", "2"));
           Status.Items.Insert(2, new ListItem("注销", "3"));
           Status.Items.Insert(3, new ListItem("补卡", "4"));
           Status.Items.Insert(4, new ListItem("全部", ""));*/
            InitListControlHelper.BindNormalTableToListControl(TypeID, "TypeId", "TypeName", "tb_CardType");
            TypeID.Items.Insert(0, new ListItem("全部", ""));

            btnNew.Visible = false;
 
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                Label2.Visible = false;
                Area_Code.Visible = false;
                Site_Code.Visible = false;
            }
            
        }
    }
    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            Site_Code.Items.Clear();
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的会员卡信息!");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Card o = ParameterBindHelper.BindParameterToObject(typeof(tb_Card), BindParameterUsage.OpQuery) as tb_Card;
        if (Ims.Main.ImsInfo.UserIsInRoles("admin") != "")//Admin
        {
            o.regionid = Request.Form.Get("Site_Code");
        }

        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId); 
        }

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
 
        
        o.chflag = true;
        e.InputParameters[0] = o;

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;//卡号
                    if (CardHelperBLL.DeleteCardAndMemBer(id))
                    {
                        count++;
                    }
                    else
                    {
                        sum++;
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
                //log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operater = "admin";
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "删除操作";
                if (sum == 0)
                {
                    log.logmsg = log.operater + "对会员卡进行删除操作,成功删除" + count + "条数据记录!";
                    LogHelperBLL.InsertObject(log);
                    //WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "对会员卡进行删除操作,成功删除数据" + count + "条记录!" + "未能删除" + sum + "条记录! 原因是这些卡正在处于使用状态,系统默认不能删除!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!" + "未能删除  " + sum + "条记录! 原因是这些卡正在处于使用状态,系统默认不能删除!");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败,原因是这些卡都处于正常使用中，系统默认不能删除!");
            }
        }
    }
}
