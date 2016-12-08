using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ZsdDotNetLibrary.Utility;
using ZsdDotNetLibrary.Web.Server;
using Ims.Main;
public partial class _Default : System.Web.UI.Page 
{
    public bool ccappwinIsOpen = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("Login.aspx");
        //if (ImsInfo.CurrentConfig.IsUseSubAppSites && WebServerHelper.ServerPort == ImsInfo.CurrentConfig.DefaultAppSite && !string.IsNullOrEmpty(ImsInfo.CurrentConfig.SubAppSites))
        //{
        //    string url = WebServerHelper.GetAppSiteUrl(ImsInfo.CurrentConfig.SubAppSites, Request.RawUrl);
        //    Response.Redirect(url);
        //}
        //else
        //{
        //    string ccappwin = CookieHelper.GetCookisValue("ccappwin");
        //    if (string.IsNullOrEmpty(ccappwin)) ccappwin = "0";
        //}
        Common.AutoSignOutForParkingRecordYesterday();
    }
}
