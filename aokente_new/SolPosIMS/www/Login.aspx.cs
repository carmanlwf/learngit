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
using System.Net;
using ZsdDotNetLibrary.Web.Server;
using System.Collections.Generic;
using ZsdDotNetLibrary.Project.Configuration;
using ZsdDotNetLibrary.Project.User;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Main;
using Ims.Main.Model;
using ZsdDotNetLibrary.Utility;
using Ims.Main.BLL;
using Ims.Admin;
using System.Xml;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Login2 : System.Web.UI.Page
{
    //private bool flag = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!WebHelper.CheckAuthority())
            Response.Redirect("Error.aspx");
        //this.Page.Form.Name = "ccappwin";
        this.form1.Name = "ccappwin";
        string s = Request.ServerVariables["SERVER_NAME"];
        //Request.ServerVariables["SERVER_PORT"]
        //if (Request.ServerVariables("SERVER_NAME") != "www.你的域名.com") Response.End();
        if (!WebHelper.CheckRequesInvalid())
        {
            Response.Redirect("InvalidRequest.htm");
        }

        string pix = !string.IsNullOrEmpty(Request["WH"]) ? Request["WH"].ToString() : "Unkonwn";
        if (pix != "Unkonwn")
        {
            int FrameHeight = int.Parse(pix.Remove(0, pix.IndexOf('x') + 1));
            int offset = FrameHeight - 215;
            ZsdDotNetLibrary.Utility.CookieHelper.WriteCookies("Fheight", offset.ToString());
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UserInfo userInfo = ParameterBindHelper.BindParameterToObject<UserInfo>(BindParameterUsage.UserToDo1);
            ParameterBindHelper.BindObjectToParameter(userInfo, BindParameterUsage.OpQuery);
        }
    }
    protected void UserLogin_LoggedIn(object sender, EventArgs e)
    {
        string u_name = ClearString.InputText(UserLogin.UserName, 10);
        UserInfo userInfo = UserHelper.LogIn<UserInfo>(u_name, AgentInfo.UserLogoffCallback, true);
        AgentInfo.LoadUserInfo(userInfo.Id, userInfo);
        userInfo.Ip = Request.UserHostAddress;
        userInfo.HostName = Request.UserHostName;
        userInfo.ServerIp = WebServerHelper.ServerNamePort;
        ParameterBindHelper.BindParameterToObject(userInfo, BindParameterUsage.OpQuery);
        ParameterBindHelper.BindObjectToParameter(userInfo, BindParameterUsage.UserToDo1);
        string ccappwin = CookieHelper.GetCookisValue("ccappwin");
        if (string.IsNullOrEmpty(ccappwin)) ccappwin = "0";
        int ccappwincount = TypeHelper.ChangeType<int>(ccappwin) + 1;
        CookieHelper.WriteCookies("ccappwin", ccappwincount.ToString());
        AgentInfo.UpdateUserStatus("0", "", null);
        Response.Redirect("~/Main.aspx");
    }

    protected void UserLogin_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        string code_input = "";
        string code_input_x = "";
        TextBox tb = (TextBox)UserLogin.FindControl("txtCode") as TextBox;
        if (tb != null)
        {
            code_input = ClearString.InputText(tb.Text, 4);
            code_input_x = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted, code_input, "!@#$%^&*");
        }
        //if (string.IsNullOrEmpty(code_input))
        //{
        //    string scriptMsg = "alert('请输入验证码!')";
        //    WebClientHelper.DoClientStartScript("alertMsg", scriptMsg);
        //    e.Cancel = true;
        //}
        string code_sys = "";
        if (Request.Cookies["checkcode"] != null)
        {
            code_sys = Request.Cookies["checkcode"].Value;
        }
        //if (code_input_x != code_sys)
        //{
        //    string scriptMsg = "alert('验证码错误,请重新输入!')";
        //    WebClientHelper.DoClientStartScript("alertMsg", scriptMsg);
        //    e.Cancel = true;
        //}
        if (string.IsNullOrEmpty(UserLogin.Password))
        {
            string scriptMsg = "alert('密码不能为空!')";
            WebClientHelper.DoClientStartScript("alertMsg", scriptMsg);
            e.Cancel = true;
        }
        if (NclSettings.GetSection().IsCheckLogin)
        {
            UserInfo curUser = new UserInfo();
            ParameterBindHelper.BindParameterToObject(curUser, BindParameterUsage.OpQuery);
            bool isLogin = AdminHelper.CheckUserLogin(curUser.Id);
            if (isLogin == true)
            {
                string scriptMsg = "alert('当前用户已经登录')";
                WebClientHelper.DoClientStartScript("alertMsg", scriptMsg);
                e.Cancel = true;
            }
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

    }
}
