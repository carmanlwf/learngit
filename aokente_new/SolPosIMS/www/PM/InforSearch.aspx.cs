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
using Ims.PM;
using Ims.PM.BLL;
using Ims.PM.UI;

public partial class PM_InforSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            sex.Items.Add("");
            sex.SelectedIndex = 2;
            InitListControlHelper.InitListControls(typeof(pm_employee));
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        PmUI.SetGridViewDivVisible(GridView1, search_result);
        
        //权限设置
        //if (PmRolesCheck.InPMRoles(PmRolesCheck.PmInfoCode))
        //{
        //    if (PmRolesCheck.CheckPMRole(PmRolesCheck.PmInfoCode, PmRolesCheck.PmInfo_Self))
        //    {
        //        code.Value = PmRolesCheck.CurrCode();
        //        code.Disabled = true;
        //        btnNew.Visible = false;
        //    }
        //    if (PmRolesCheck.CheckPMRole(PmRolesCheck.PmInfoCode, PmRolesCheck.PmInfo_Dept))
        //    {
        //        dept.Value = PmRolesCheck.CurrDeptCode();
        //        dept.Disabled = true;
        //        btnNew.Visible = false;
        //    }
        //    if (PmRolesCheck.CheckPMRole(PmRolesCheck.PmInfoCode, PmRolesCheck.PmInfo_Group))
        //    {
        //        skillgroup.Value = PmRolesCheck.CurrSkGroupCode();
        //        skillgroup.Disabled = true;
        //        btnNew.Visible = false;
        //    }
        //}
        //else
        //{
        //    return;
        //}
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        object o = ParameterBindHelper.BindParameterToObject(typeof(pm_employee), BindParameterUsage.OpQuery);
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        PmUI.SetGridViewDivVisible(GridView1, search_result);
    }
}
