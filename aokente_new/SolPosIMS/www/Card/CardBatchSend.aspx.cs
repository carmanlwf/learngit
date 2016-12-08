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
using Ims.Member.Model;
using ZsdDotNetLibrary.Web;
using Ims.Member.BLL;
using System.Threading;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Card_CardBatchSend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent")=="")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Card o = ParameterBindHelper.BindParameterToObject(typeof(tb_Card), BindParameterUsage.OpQuery) as tb_Card;
        o.isSysAuto = true;
        o.Status = 0;//未激活是0不是4
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的激活卡信息!");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        int n = 0;
        int count = 0;
        if (this.GridView1.Rows.Count > 0)
        {
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
                log.logmsg = log.operater + "对商品进行删除操作,成功删除" + count + "条数据记录!";
                LogHelperBLL.InsertObject(log);

                WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败!");
            }
        }
    }
}
