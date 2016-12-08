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
using Ims.Job.Model;

public partial class Job_job_workturnlist : System.Web.UI.Page
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
            status.Items.Insert(0, new ListItem("全部记录", ""));
            status.Items.Insert(1, new ListItem("已结算未交班", "0"));
            status.Items.Insert(1, new ListItem("已结算已交班", "1"));

            //InitListControlHelper.BindNormalTableToListControl(tradetype, "areacode", "areaname", "tb_area");

            //InitListControlHelper.BindNormalTableToListControl(tradeway, "areacode", "areaname", "tb_area");
        }

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

        v_job_workturnlist o = ParameterBindHelper.BindParameterToObject(typeof(v_job_workturnlist), BindParameterUsage.OpQuery) as v_job_workturnlist;
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
            WebClientHelper.DoClientMsgBox("没有满足条件的交班信息!");
        }

    }
}

