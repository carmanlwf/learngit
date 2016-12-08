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

public partial class Wait : System.Web.UI.Page
{
    public bool issend = true;
    public string url = "";
    public string msg = "正在加载页面，请稍等......";
    public string param = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            issend = true;
            url = Request.QueryString[0];
            if (Request.QueryString.Count > 1)
                msg = Request.QueryString[1];
        }
        else if(Request.Form.Count >0)
        {
            issend = false;
            url = Request.Form["url"];
            if (!string.IsNullOrEmpty(Request.Form["msg"]))
                msg = Request.Form["msg"];
            if (!string.IsNullOrEmpty(Request.Form["param"]))
                param = Request.Form["param"];
        }
    }
}
