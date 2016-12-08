using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Job.Model;
using Ims.Job.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Job_ticket_sendlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

        v_ticket_sendlist o = ParameterBindHelper.BindParameterToObject(typeof(v_ticket_sendlist), BindParameterUsage.OpQuery) as v_ticket_sendlist;
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
            WebClientHelper.DoClientMsgBox("没有满足条件的领取信息!");
        }

    }
    protected void btnNoUse_Click(object sender, EventArgs e)
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
                    if (TicketHelperBLL.AlterTicketState(id) > 0)
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
                WebClientHelper.DoClientMsgBox("请先选择要作废的领取记录!");
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
                    log.logmsg = log.operater + "对票据领取记录作废操作完成,成功作废" + count + "条数据记录!";
                    LogHelperBLL.InsertObject(log);
                    //WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "对票据领取记录作废操作完成,成功作废" + count + "条记录!" + "未能处理" + sum + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("对票据领取记录作废操作完成,成功作废" + count + "条记录!" + "未能处理" + sum + "条记录!");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("处理失败，系统无法处理!");
            }
        }
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
                    ticket_sendlist t = new ticket_sendlist();
                    t.tid = id;
                    if (TicketHelperBLL.DeleteObject(t)>0)
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
                WebClientHelper.DoClientMsgBox("请先选择要删除的领取记录!");
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
                    log.logmsg = log.operater + "对票据领取记录操作完成,成功删除" + count + "条数据记录!";
                    LogHelperBLL.InsertObject(log);
                    //WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "对票据领取记录操作完成,成功删除" + count + "条记录!" + "未能处理" + sum + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("对票据领取记录操作完成,成功删除" + count + "条记录!" + "未能处理" + sum + "条记录!");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败，系统无法处理!");
            }
        }
    }
}
