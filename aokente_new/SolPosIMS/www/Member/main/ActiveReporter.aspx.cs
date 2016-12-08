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
using Ims.Main.BLL;
using ZsdDotNetLibrary.Project.User;

public partial class main_ActiveReporter : System.Web.UI.Page
{
    public string receiveMsgIds = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Expires = 0;
        string result = "ok;";
        try
        {
            string logoffReason = "";
            if (!UsersHelper.SessionIsActive(out logoffReason))
            {
                result += "false;" + logoffReason;
                Response.Write(result);
                return;
            }
            if (AgentInfo.UpdateUserActiveTime(out logoffReason) != "1")
            {
                result += "false;" + logoffReason;
            }
            else
            {
                result += "true;";
                result += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ";";
                result += AgentInfo.GetUserReceiveMsgIds("");
            }
            Response.Write(result);
        }
        catch (Exception ex)
        {
            result += "false;处理错误;" + ex;
            Response.Write(result);
        }
    }
}
