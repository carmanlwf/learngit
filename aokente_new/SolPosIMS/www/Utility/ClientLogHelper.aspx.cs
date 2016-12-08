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
using ZsdDotNetLibrary.Log;

public partial class Utility_ClientLogHelper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Expires = 0;
            string msg = Request.QueryString["msg"];
            string category = Request.QueryString["category"];
            if (string.IsNullOrEmpty(category)) category = "Client";
            LogHelper.Write(msg, category, LogPriority.Lowest);
        }
        catch { }
    }
}
