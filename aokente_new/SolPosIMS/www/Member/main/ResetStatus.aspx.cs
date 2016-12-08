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
using Ims;
using System.Collections.Generic;
using Ims.Main.Model;
using Ims.Main.BLL;

public partial class main_ResetStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(ImsInfo.CurrentUser.IsSupervisor)

        //ShowClientMsg("alert('"+ImsInfo.CurrentUser.IsSupervisor+"')");
    }

    /// <summary>
    /// 恢复登录状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackLogin_Click(object sender, EventArgs e)
    {
        string curId = curagentid.Text.Trim();
        int returnvalue = 0;
        if (curId.Length > 5)//处理岗
        {
            SheetRoleInfo roleInfo = new SheetRoleInfo();
            roleInfo.id = curId;
            returnvalue = SheetRoleBLL.BackUpLoginStatus(roleInfo);
        }
        else
        {
            AgentData agentInfo = new AgentData();
            agentInfo.id = curId;
            returnvalue = AgentInfoBLL.BackUpAgentLoginStatus(agentInfo);
        }
        if (returnvalue == 1)
        {

            ShowClientMsg("alert('恢复成功!');window.close();");
        }
        else
        {
            ShowClientMsg("alert('恢复失败!')");
        }
    }

    //消息
    protected void ShowClientMsg(string sptStr)
    {
        String csname = "showClientMsg";

        Type cstype = this.GetType();

        ClientScriptManager cs = Page.ClientScript;

        String script = sptStr;

        if (!cs.IsStartupScriptRegistered(cstype, csname))
        {
            cs.RegisterStartupScript(cstype, csname, script, true);
        }
    }
   
}
