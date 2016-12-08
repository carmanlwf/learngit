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
using Ims.Log.Model;
using ZsdDotNetLibrary.Web.BindParameter;

public partial class Card_ChargingRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,seller,channel")=="")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (Ims.Main.ImsInfo.UserIsInRoles("channel,seller") != "")//设置功能限制
        {
            btnNew.Visible = false;
        }
         GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Log o = ParameterBindHelper.BindParameterToObject(typeof(tb_Log), BindParameterUsage.OpQuery) as tb_Log;
        o.type = "充值规则";
        e.InputParameters[0] = o;

    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的日志信息!");
        }
    }
}
