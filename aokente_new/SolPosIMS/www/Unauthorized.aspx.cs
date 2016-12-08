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
using ZsdDotNetLibrary.Web;
public partial class Unauthorized : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebClientHelper.DoResultClientProcess(false, "你无此操作的权限！", 0, WebClientHelper.ToDo.CloseSelfWindow);
    }
}
