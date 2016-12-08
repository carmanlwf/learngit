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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;
using Ims.Card.BLL;

public partial class Card_ExitCard : FormNormalEditPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
            GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Card o = ParameterBindHelper.BindParameterToObject(typeof(tb_Card), BindParameterUsage.OpQuery) as tb_Card;
        o.Status = 3;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的注销卡信息!");
        }
    }

}
