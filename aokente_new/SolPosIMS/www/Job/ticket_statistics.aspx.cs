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

public partial class Job_ticket_statics : System.Web.UI.Page
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
        string operatorid = "";
        string timepoint = "";
        operatorid = !string.IsNullOrEmpty(Request.QueryString["operatorid"]) ? Request.QueryString["operatorid"].ToString() : "";
        timepoint = !string.IsNullOrEmpty(Request.QueryString["timepoint"]) ? Request.QueryString["timepoint"].ToString() : "";

        ticket_statistics o = ParameterBindHelper.BindParameterToObject(typeof(ticket_statistics), BindParameterUsage.OpQuery) as ticket_statistics;
        if (!string.IsNullOrEmpty(Request.QueryString["operatorid"]))
            o.operatorid = Request.QueryString["operatorid"].ToString();
        if (!string.IsNullOrEmpty(Request.QueryString["timepoint"]))
            o.addeddate_begin = Request.QueryString["timepoint"].ToString();
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {

        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的统计信息!");
        }

    }
    /// <summary>
    /// 获取剩余差额
    /// </summary>
    /// <param name="totalMoney"></param>
    /// <param name="RealMoney"></param>
    /// <returns></returns>
    public string GetStillMoney(string totalMoney, string RealMoney)
    {
        string ret_result = "";
        decimal t_money = 0;
        decimal r_money = 0;
        decimal lastmoney = 0;
        decimal.TryParse(totalMoney, out t_money);
        decimal.TryParse(RealMoney, out r_money);
        lastmoney = t_money - r_money;
        if (lastmoney < 0)
            ret_result = "<font color = 'red'>数据异常</font>";
        else if (lastmoney < 500 && lastmoney >100)
            ret_result = "<font color = 'orange'>" + lastmoney.ToString() + "</font>";
        else if (lastmoney < 100 && lastmoney >= 0)
            ret_result = "<font color = 'orangered'>"+lastmoney.ToString()+"</font>";
        else
            ret_result = "<font color = 'green'>" + lastmoney.ToString() + "</font>";
        return ret_result;
    }
}
