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
using NewSoftDotNetLibrary.Web;
using Ims.Card.Model;
using NewSoftDotNetLibrary.Web.BindParameter;

public partial class Card_CardChargeRulePicker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的充值优惠信息!");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        card_chargerule o = ParameterBindHelper.BindParameterToObject(typeof(card_chargerule), BindParameterUsage.OpQuery) as card_chargerule;
        o.flag = true;
        e.InputParameters[0] = o;
    }
}


