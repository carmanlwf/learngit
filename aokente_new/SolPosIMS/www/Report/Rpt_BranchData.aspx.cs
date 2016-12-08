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

public partial class Report_Rpt_BranchData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin,agent,seller,channel"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
    }
}
