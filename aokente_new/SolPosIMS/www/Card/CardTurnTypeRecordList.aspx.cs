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
using Ims.Card.Model;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;

public partial class Card_CardTurnTypeRecordList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ///权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        
       tb_TurnTypeRecord o = ParameterBindHelper.BindParameterToObject(typeof(tb_TurnTypeRecord), BindParameterUsage.OpQuery) as tb_TurnTypeRecord;
       o.Flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的卡类型转换信息!");
        }
    }
}
