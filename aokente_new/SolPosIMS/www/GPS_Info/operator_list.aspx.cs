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
using Ims.Site.Model;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;

public partial class GPS_Info_operator_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,maintenance,area_manager") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            islogin.Items.Insert(0, new ListItem("全部", ""));
            islogin.Items.Insert(1, new ListItem("下班", "0"));
            islogin.Items.Insert(2, new ListItem("值班", "1"));

            isOutBounds.Items.Insert(0, new ListItem("全部", ""));
            isOutBounds.Items.Insert(1, new ListItem("在岗", "0"));
            isOutBounds.Items.Insert(2, new ListItem("脱岗", "1"));
        }
    }

    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的人员执勤信息!");
        }
    }


    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Pos_Operator o = ParameterBindHelper.BindParameterToObject(typeof(tb_Pos_Operator), BindParameterUsage.OpQuery) as tb_Pos_Operator;
        o.flag = true;
        e.InputParameters[0] = o;
    }



}
