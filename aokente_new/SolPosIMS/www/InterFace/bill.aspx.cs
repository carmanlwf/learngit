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
using ZsdDotNetLibrary.Web;
using Ims.Pay;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Pay.Model;

public partial class InterFace_bill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

        v_pay_arrears o = ParameterBindHelper.BindParameterToObject(typeof(v_pay_arrears), BindParameterUsage.OpQuery) as v_pay_arrears;
        string myCarNum = "";
        if (!string.IsNullOrEmpty(Request.QueryString["CardSnr"]))
            myCarNum = Request.QueryString["CardSnr"].ToString();
        o.CardSnr = myCarNum;
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的账务信息!");
        }
    }
}
