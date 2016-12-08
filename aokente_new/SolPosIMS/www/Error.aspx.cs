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

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VipposRegDLL.RegKey vrd = new VipposRegDLL.RegKey();
        string sid = vrd.CreateCode();

        errorMsg.Text = "未编译的动态库文件,错误代码:0x" + sid;
        errorPage.Text = "Default.aspx";
        if (!Page.IsPostBack)
        {
            try
            {
                ArrayList errors = Application["error"] as ArrayList;
                Application.Remove("error");
                if (errors == null) return;
                errorPage.Text = errors[0] as string;
                errorMsg.Text = errors[1] as string;
                errorAllMsgs.Text = errors[2] as string;
            }
            catch (Exception ex) { Response.Write(ex.Message); }
        }
    }
}
