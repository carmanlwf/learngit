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
using Ims.Main;
using ZsdDotNetLibrary.Web.Server;
using ZsdDotNetLibrary.Net;

public partial class main_Left : System.Web.UI.Page
{
    public string NetServiceUserSite = "..";
    public string NetWebSite = "";
    public string VoiceTestSite = "";
    public string NetWebBrowseSite = "";
    public string NewIndivServerUrl = "";
    public string NewNclUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(ImsInfo.CurrentConfig.NetServiceUserSites))
        {
            NetServiceUserSite = WebServerHelper.GetAppSiteUrl(ImsInfo.CurrentConfig.NetServiceUserSites, WebServerHelper.ApplicationPath);
            if (HttpClient.GetWebServerStatus(NetServiceUserSite + "/Utility/Pong.aspx", 30) != System.Net.HttpStatusCode.OK)
                NetServiceUserSite = "..";
        }

        NetWebSite = WebServerHelper.GetAppSiteUrl(ImsInfo.CurrentConfig.NetWebSites, "");
        VoiceTestSite = WebServerHelper.GetAppSiteUrl(ImsInfo.CurrentConfig.VoiceTestSites, "");

        if (ImsInfo.CurrentConfig.IsKmLocalFile)
            NetWebBrowseSite = "..";
        else
            NetWebBrowseSite = WebServerHelper.GetAppSiteUrl(ImsInfo.CurrentConfig.NetWebBrowseSites, "");

        NewIndivServerUrl = ImsInfo.CurrentConfig.NewIndivServerUrl;//核心接口地址
        NewNclUrl = ImsInfo.CurrentConfig.NewNclUrl;//核心界面地址
    }
}
