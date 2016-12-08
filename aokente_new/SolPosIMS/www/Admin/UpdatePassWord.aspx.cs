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
using Ims.Admin.BLL;
using ZsdDotNetLibrary.Web;
using Ims.Log.Model;
using Ims.Log.BLL;

public partial class Admin_UpdatePassWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("agent,seller,channel,manager,admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            /*authority.Items.Insert(0, new ListItem("系统管理员", "admin"));
            authority.Items.Insert(1, new ListItem("普通员","small"));*/
            InitListControlHelper.BindNormalTableToListControl(authority, "syscode", "name", "pub_rolesinfo");
            string roleName = Request.QueryString["rolesName"].ToString().Trim();
            if (!string.IsNullOrEmpty(roleName))
                authority.SelectedIndex = authority.Items.IndexOf(authority.Items.FindByText(roleName));
        }
    }
    protected void ButtOk_ServerClick(object sender, EventArgs e)
    {
        if (newPass.Value .Trim().Length<5)
        { 
            WebClientHelper.DoClientMsgBox("密长度不能小于5位，请重新输入!");
            return;
        }
        if (oKPass.Value.Trim().Length < 5)
        {
            WebClientHelper.DoClientMsgBox("密长度不能小于5位，请重新输入!");
            return;
        }
        if (string.IsNullOrEmpty(Request.QueryString["getcode"]))
        {
            WebClientHelper.DoClientMsgBox("用户状态不正常!");
            return;
        }
        string userid = Request.QueryString["getcode"].ToString();
        string roleType = authority.Items[authority.SelectedIndex].Value;
        if (newPass.Value != oKPass.Value)
        {
            WebClientHelper.DoClientMsgBox("两次密码不一致，请重新输入!");
            return;
        }
        else
        {
            if (AgentInfoBLL.ChangePWD(userid, roleType, oKPass.Value) == true)
            {

                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "密码重设";
                log.logmsg = log.operater + "对用户编号为" + userid + "进行了密码重新设定!";
                LogHelperBLL.InsertObject(log);

                //WebClientHelper.DoClientMsgBox("密码修改成功!");

                newPass.Value = "";
                oKPass.Value = "";

                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                string msg = "密码修改成功";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("密码修改失败!");
            }
        }

    }
}
