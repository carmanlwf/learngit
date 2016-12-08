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
using Ims.Admin.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Admin.Model;
using Ims.Main;
using Ims.Admin;
public partial class Admin_BranchManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!ImsInfo.UserIsInRole("admin_branch"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(gvBranch, ObjectDataSource1);
        if (!Page.IsPostBack)
        {

            //AdminHelper.BindTreeBranch(tvOrg,2);
        }
        
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        ManageComInfo manageComInfo = new ManageComInfo();
        if (!String.IsNullOrEmpty(tvOrg.SelectedValue))
        {
            manageComInfo.OrgCode = tvOrg.SelectedValue.Trim();
        }
        e.InputParameters[0] = manageComInfo;
    }
    protected void tvOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(tvOrg.SelectedValue))
        {
            gvBranch.PageIndex = 0;
            gvBranch.DataBind();
        }
    }
    protected void btnRefresh_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("BranchManage.aspx");

    }
}
