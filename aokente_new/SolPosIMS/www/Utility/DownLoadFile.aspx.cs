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
using ZsdDotNetLibrary.Web;

public partial class Utility_DownLoadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string filepath = Request.QueryString["filepath"];
        if (!string.IsNullOrEmpty(filepath))
        {
            FileHelper.DownloadFile(filepath, true);
        }
        else
        {
            throw new Exception("你无此权限！");
        }
    }
}
