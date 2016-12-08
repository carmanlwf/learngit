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

public partial class ST_RepeaterList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的记录信息!");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        JsongItems o = ParameterBindHelper.BindParameterToObject(typeof(JsongItems), BindParameterUsage.OpQuery) as JsongItems;
        o.deviceType = "ROUTE";
        e.InputParameters[0] = o;
    }
}
