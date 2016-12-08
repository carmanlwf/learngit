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
using ZsdDotNetLibrary.Project.User;
using Ims.Main.BLL;
using ZsdDotNetLibrary.Utility;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ccappwin = CookieHelper.GetCookisValue("ccappwin");
        if (string.IsNullOrEmpty(ccappwin)) ccappwin = "0";
        int ccappwincount = TypeHelper.ChangeType<int>(ccappwin) - 1;
        CookieHelper.WriteCookies("ccappwin", ccappwincount.ToString());

        AgentInfo.UpdateUserStatus("1", "", null);
        UserHelper.LogOff();
    }
}
