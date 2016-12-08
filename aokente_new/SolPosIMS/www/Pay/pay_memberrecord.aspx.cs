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
using Ims.Pay;

public partial class Pay_pay_memberrecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel,small,statistician") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            tradeway.Items.Insert(0, new ListItem("全部记录", ""));
            tradeway.Items.Insert(1, new ListItem("未知来源", "0"));
            tradeway.Items.Insert(2, new ListItem("系统平台", "1"));
            tradeway.Items.Insert(3, new ListItem("手持终端", "2"));
            tradeway.Items.Insert(4, new ListItem("手机客户端", "3"));
            //InitListControlHelper.BindNormalTableToListControl(tradeway, "areacode", "areaname", "tb_area");
        }
    }


    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_pay_paydetail o = ParameterBindHelper.BindParameterToObject(typeof(v_pay_paydetail), BindParameterUsage.OpQuery) as v_pay_paydetail;
        if (!string.IsNullOrEmpty(Request.QueryString["carnum"]))
        {
            o.carnum = Request.QueryString["carnum"].ToString();
        }
        o.tradetype = 8;
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
