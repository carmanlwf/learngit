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
using System.Collections.Generic;
using Ims.Job.BLL;

public partial class ReportViewer_AchievementChartByOne : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel,small,statistician") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            type.Value = "1";
            searchDay.Value = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
            addeddate_begin.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            addeddate_end.Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        SP_CalcTollCollectorFeat o = ParameterBindHelper.BindParameterToObject(typeof(SP_CalcTollCollectorFeat), BindParameterUsage.OpQuery) as SP_CalcTollCollectorFeat;
        if (!string.IsNullOrEmpty(operatorid.Value.Trim()) && operatorid.Value != "请输入员工号")
        {
            o.persons = operatorid.Value.Trim();
            o.type = int.Parse(type.Value);
            o.startTime = addeddate_begin.Value.Trim();
            o.endTime = addeddate_end.Value.Trim();
            e.InputParameters[0] = o;
        }
    }

    protected void btnDay_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(searchDay.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("请选择要查看的日期!");
            return;
        }
        type.Value = "1";
        DateTime day_search = DateTime.Parse(searchDay.Value);
        addeddate_begin.Value = day_search.ToString("yyyy-MM-dd 00:00:00");
        addeddate_end.Value = day_search.ToString("yyyy-MM-dd 23:59:59");
    }

    protected void btnMonth_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(searchDay.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("请选择要查看的日期!");
            return;
        }
        type.Value = "2";
        DateTime day_search = DateTime.Parse(searchDay.Value);
        int day = DateTime.DaysInMonth(day_search.Year, day_search.Month);
        DateTime day_last = new DateTime(day_search.Year, day_search.Month, day);
        addeddate_begin.Value = day_search.ToString("yyyy-MM-01 00:00:00");
        addeddate_end.Value = day_last.ToString("yyyy-MM-dd 23:59:59");
    }

    protected void btnYear_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(searchDay.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("请选择要查看的日期!");
            return;
        }
        type.Value = "3";
        DateTime day_search = DateTime.Parse(searchDay.Value);
        addeddate_begin.Value = day_search.ToString("yyyy-01-01 00:00:00");
        addeddate_end.Value = day_search.ToString("yyyy-12-31 23:59:59");
    }

    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        type.Value = "2";
    }
}
