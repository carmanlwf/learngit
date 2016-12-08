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
using NewSoftDotNetLibrary.Web;
using NewSoftDotNetLibrary.Web.BindParameter;
using Ims.Pub.Model;

public partial class ReportViewer_RptList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,small,maintenance") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(gvArea, ObjectDataSource1);
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        gvArea.DataSourceID = "ObjectDataSource1";
        gvArea.PageIndex = 0;
        gvArea.DataBind();
        if (gvArea.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的报表信息!");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        Rpt_List o = ParameterBindHelper.BindParameterToObject(typeof(Rpt_List), BindParameterUsage.OpQuery) as Rpt_List;
        o.name = name.Value.Trim();
        o.Rptid = Rptid.Value.Trim();
        o.flag = true;
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            o.authority = "'admin,agent'";
        }
        e.InputParameters[0] = o;
    }
}

