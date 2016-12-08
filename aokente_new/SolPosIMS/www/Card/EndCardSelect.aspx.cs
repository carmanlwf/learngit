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

public partial class Card_EndCardSelect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string PosCardType = ConfigurationManager.AppSettings["SysCardType"];
        if (PosCardType == "Magcard")
            Response.Redirect("EndCard2.aspx");//Magcard
        else if (PosCardType == "M1card")
            Response.Redirect("EndCard.aspx");//M1card
        else
            Response.Redirect("EndCard2.aspx");//Magcard
    }
}
