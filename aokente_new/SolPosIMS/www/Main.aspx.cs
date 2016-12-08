using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Ims.Main.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Project.User;
using ZsdDotNetLibrary.Utility;
using ZsdDotNetLibrary.Log;
using ZsdDotNetLibrary.Web.Server;
using ZsdDotNetLibrary.Net;
using Ims.Main;
using NewSoftDotNetLibrary.Data;
using Ims.Card.BLL;
using Ims.Member.Model;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Main : System.Web.UI.Page
{
    
    public string FrameHeight;
    public string currUserStr = "";
    public string currRolesStr = "";
    public string MsgAppSite = "";
    public string style = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("small") == "small")
        {
            style = "display:none;";
        }


        if (!WebHelper.CheckAuthority())
            Response.Redirect("Error.aspx");
        if (!WebHelper.CheckRequesInvalid())
        {
            Response.Redirect("InvalidRequest.htm");
        }
        FrameHeight = !string.IsNullOrEmpty(ZsdDotNetLibrary.Utility.CookieHelper.GetCookisValue("Fheight")) ? ZsdDotNetLibrary.Utility.CookieHelper.GetCookisValue("Fheight") + "px" : "500" + "px";

        Ims.Main.Model.UserInfo userInfo = UserHelper.GetUser<Ims.Main.Model.UserInfo>();
        if (userInfo.IsLogIn() == false)
        {
            Response.Redirect("Login.aspx");
        }


        if (!Page.IsPostBack)
        {
            if(Ims.Main.ImsInfo.CurrentUserId !="super")
                WriteLoginLog();
            string s = ImsInfo.CurrentUserId;
            //if (ImsInfo.CurrentUser.HavePhone)
            //{
            //    if (ImsInfo.CurrentUser.IsIPCCPhone)
            //    {
            //        ImsInfo.CurrentUser.HavePhone = ImsInfo.UserIsInRole("pub_telipccagent");
            //        ImsInfo.CurrentUser.IsSupervisor = ImsInfo.UserIsInRole("pub_telipccsupervisor");
            //    }
            //    else
            //    {
            //        ImsInfo.CurrentUser.HavePhone = ImsInfo.UserIsInRole("pub_telepagent");
            //        ImsInfo.CurrentUser.IsSupervisor = ImsInfo.UserIsInRole("pub_telepsupervisor");

            //    }
            //}
            //if (!ImsInfo.CurrentUser.HavePhone && !string.IsNullOrEmpty(ImsInfo.CurrentUser.PhoneNumber))
            //{
            //    ImsInfo.CurrentUser.PhoneNumber += "x";
            //}

            MsgAppSite = WebServerHelper.ApplicationPath;
            if (!string.IsNullOrEmpty(ImsInfo.CurrentConfig.MsgAppSites))
            {
                MsgAppSite = WebServerHelper.GetAppSiteUrl(ImsInfo.CurrentConfig.MsgAppSites, WebServerHelper.ApplicationPath);
                if (HttpClient.GetWebServerStatus(MsgAppSite + "/Utility/Pong.aspx", 30) != System.Net.HttpStatusCode.OK)
                    MsgAppSite = WebServerHelper.ApplicationPath;
            }
            
            LogHelper.Write("User Login.");



        }



    }
    public void WriteLoginLog()
    {
        tb_Log log = new tb_Log();
        log.logid = DateTime.Now.ToString("yyMMddhhmmssfff");
        log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        log.operater = Ims.Main.ImsInfo.CurrentUserId;
        log.type = "用户登录";
        log.logmsg = "用户:" + Ims.Main.ImsInfo.CurrentUserId + "于" + log.operate_date + "登录系统.客户端IP:" + Request.UserHostAddress + "客户端名称:" + Request.UserHostName + "代理信息:" + Request.UserAgent;
        log.flag = true;
        LogHelperBLL.InsertObject(log);
    }


}
