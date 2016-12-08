using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Ims.Card.BLL;

public partial class WebPrint_PreView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = CardChargeListBLL.DTTransLog("", "", "", "");
        string retStr = WebPrint.GridTablePrint(dt,"充值测试报表");
        Response.Write(retStr);
    }
}
