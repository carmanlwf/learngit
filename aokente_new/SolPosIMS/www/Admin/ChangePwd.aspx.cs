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
using Ims.Admin.Model;
using Ims.Admin.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Utility;
//using Ims.User;
using System.Collections.Generic;
using Ims.Main.BLL;
using Ims;
using Ims.Main;

public partial class Admin_ChangePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("agent,seller,channel,manager,admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
    }
    protected void btnConfirm_ServerClick(object sender, EventArgs e)
    {
        string pwd1 = pwd.Value.Trim();
        string pwd2 = pwdconfirm.Value.Trim();
        if (string.IsNullOrEmpty(pwd1) || string.IsNullOrEmpty(pwd2))
        {
            WebClientHelper.DoClientMsgBox("新登录密码不能为空!");
            return;
        }
        else if (pwd1 != pwd2)
        {
            WebClientHelper.DoClientMsgBox("新登录密码和确认密码不一致!");
            return;
        }
        else
        {
            bool returnvalue = false;
            if (AgentInfo.CheckIsSheetRole(ImsInfo.CurrentUserId))
            {
                //处理岗修改密码
                returnvalue = SheetRoleBLL.ChangePWD(ImsInfo.CurrentUserId, pwd1);
            }
            else
            {
                //用户修改密码
                returnvalue = AgentInfoBLL.ChangePWD(ImsInfo.CurrentUserId, pwd1);
            }
            if (returnvalue)
            {
                WebClientHelper.DoClientMsgBox("修改成功,下次登录生效!");
            }
            else
            {
                WebClientHelper.DoClientMsgBox("修改失败!");
            }
        }
    }
}
