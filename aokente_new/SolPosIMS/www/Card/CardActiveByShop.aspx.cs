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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.Model;

public partial class Card_CardActiveByShop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            //InitListControlHelper.BindNormalTableToListControl(siteid, "id", "sitename", "tb_site");
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            Area_Code.Items.Insert(0, new ListItem("所有区域", ""));

            activityway.Items.Insert(0, new ListItem("全部", ""));
            activityway.Items.Insert(1, new ListItem("终端", "终端"));
            activityway.Items.Insert(2, new ListItem("在线", "在线"));


            Status.Items.Insert(0, new ListItem("全部", ""));
            Status.Items.Insert(1, new ListItem("临时激活", "0"));
            Status.Items.Insert(1, new ListItem("激活超时", "1"));
            Status.Items.Insert(2, new ListItem("正常使用", "2"));
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_CardActivityByShop o = ParameterBindHelper.BindParameterToObject(typeof(tb_CardActivityByShop), BindParameterUsage.OpQuery) as tb_CardActivityByShop;
        o.siteid = Request.Form.Get("siteid");
        o.flag1 = true;
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的卡激活信息!");
        }
    }
}
