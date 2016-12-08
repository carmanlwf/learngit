using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewSoftDotNetLibrary.Web;
using NewSoftDotNetLibrary.Web.BindParameter;
using Ims.Log.Model;
using Ims.Member.Model;
using Ims.Member.BLL;
using Ims.Log.BLL;

public partial class Member_IntegralExchangeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Ims.Main.ImsInfo.UserIsInRoles("admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        string time1 = !string.IsNullOrEmpty(addeddate1.Value.Trim()) ? addeddate1.Value.Trim() : DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
        string time2 = !string.IsNullOrEmpty(addeddate2.Value.Trim()) ? addeddate2.Value.Trim() : DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        card_integralexchangelist o = ParameterBindHelper.BindParameterToObject(typeof(card_integralexchangelist), BindParameterUsage.OpQuery) as card_integralexchangelist;
        o.addeddate1 = time1; addeddate1.Value = time1;
        o.addeddate2 = time2; addeddate2.Value = time2;
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的积分兑换记录!");
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            card_integralexchangelist o = new card_integralexchangelist();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.transid = id;
                    int deletesum =
                        card_integralexchangeBLL.DeleteObject(o);

                    if (deletesum > 0)
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

            }
            else
            {
                if (count > 0)
                {

                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    //log.operater = "admin";
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.type = "删除操作";
                    log.logmsg = log.operater + "  对积分兑换记录进行删除操作,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);

                    GridView1.DataSourceID = "ObjectDataSource1";
                    GridView1.PageIndex = 0;
                    GridView1.DataBind();

                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    WebClientHelper.DoClientMsgBox("删除失败,请重试!");
                }
            }
        }
    }
}

