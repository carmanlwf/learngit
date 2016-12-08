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

public partial class Card_zhifubao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton2.Checked = !RadioButton1.Checked;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton1.Checked = !RadioButton2.Checked;
    }
}
