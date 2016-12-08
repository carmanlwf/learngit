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
using Ims.Log.Model;
using Ims.Log.BLL;
using ZsdDotNetLibrary.Web;
using Ims.Admin.BLL;

public partial class Admin_UpdateAdminPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        //if (Ims.Main.ImsInfo.UserIsInRoles("admin,manger,agent") == "")
        if (Ims.Main.ImsInfo.UserIsInRoles("agent,seller,channel,manager,admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
    }
    protected void ButtOk_ServerClick(object sender, EventArgs e)
    {
        //密码
        string oldpass = AgentInfoBLL.GetPassWord();

        if (string.IsNullOrEmpty(oldPass.Value.Trim()) || string.IsNullOrEmpty(newPass.Value.Trim()) || string.IsNullOrEmpty(yesPass.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("任何密码都不能为空!");
            return;
        }
        if (this.newPass.Value.Length < 5 || this.yesPass.Value.Length < 5)
        {
            WebClientHelper.DoClientMsgBox("密码长度必须大于5位!");
            return;
        }
        if (oldPass.Value.Trim() != oldpass)
        {
            WebClientHelper.DoClientMsgBox("与原密码不一致!");
            return;
        }
        if (newPass.Value.Trim() != yesPass.Value.Trim())
        {
            WebClientHelper.DoClientMsgBox("新登录密码和确认密码不一致!");
            return;
        }
        else
        {
            if (AgentInfoBLL.ChangePWD(Ims.Main.ImsInfo.CurrentUserId, yesPass.Value.Trim()) == true)
            {
                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "密码重设";
                log.logmsg = "进行了密码重设,密码为:xxxxxxxxxxx";
                LogHelperBLL.InsertObject(log);
                WebClientHelper.DoClientMsgBox("密码修改成功!");

                oldPass.Value = "";
                newPass.Value = "";
                yesPass.Value = "";

            }
            else
            {
                WebClientHelper.DoClientMsgBox("密码修改失败!");
            }
        }
    }
    protected void ButtNo_ServerClick(object sender, EventArgs e)
    {
        oldPass.Value = "";
        newPass.Value = "";
        yesPass.Value = "";
    }
}
