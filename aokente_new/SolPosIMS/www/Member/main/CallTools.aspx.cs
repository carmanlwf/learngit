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
public partial class main_CallTools : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string funName = Request.QueryString["funname"];
            string[] allParams = Request.QueryString.GetValues("param");
            string result = Ims.Main.BLL.CallTools.doProcess(funName, allParams);
            Response.Clear();
            Response.Expires = 0;
            Response.Write(result);
        }
        catch
        {
            Response.Clear();
            Response.Write("");
        }
    }
}
