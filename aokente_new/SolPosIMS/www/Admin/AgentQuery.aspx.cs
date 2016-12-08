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
//using Brs.Admin.Model;
//using Brs.Admin.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Main;
using Ims.Admin.Model;
using Ims.Admin.BLL;

public partial class Admin_AgentQuery : System.Web.UI.Page
{
    private bool IsCanChgPwd = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        //权限验证
        if (!ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        IsCanChgPwd = ImsInfo.UserIsInRole("admin");
        //初始化风格
        GridViewHelper.InitDefaultGridViewEvent(gvAgent, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            //绑定groupinfo_id下拉框
            //InitListControlHelper.BindNormalTableToListControl(groupinfo_id, "id", "groupname", "pub_groupinfo", "id", "validflag = '1'", null);
            //InitListControlHelper.ListControlItemsHtmlDecode(groupinfo_id);
            //groupinfo_id.Items.Insert(0, new ListItem("全部",""));
        }
    }
    protected void btnQuery_ServerClick(object sender, EventArgs e)
    {
        gvAgent.PageIndex = 0;
        gvAgent.DataSourceID = "ObjectDataSource1";
        gvAgent.DataBind();
        if (gvAgent.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的人员信息!");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        AgentData o = ParameterBindHelper.BindParameterToObject(typeof(AgentData), BindParameterUsage.OpQuery) as AgentData;
        o.validflag = true;
        e.InputParameters[0] = o;
    }

    private string GetSysCodes()
    {
        string syscode = "";
        if (User.IsInRole("admin_authority"))
        {
            syscode += ",'admin'";
        }
        else
        {
            if (User.IsInRole("tt_authority"))
            {
                syscode += ",'tt'";
            }
            if (User.IsInRole("qc_authority"))
            {
                syscode += ",'qc'";
            }
            if (User.IsInRole("aa_authority"))
            {
                syscode += ",'aa'";
            }
            if (User.IsInRole("km_authority"))
            {
                syscode += ",'km'";
            }
            if (User.IsInRole("ob_authority"))
            {
                syscode += ",'ob'";
            }
            if (User.IsInRole("pm_authority"))
            {
                syscode += ",'pm'";
            }
            if (User.IsInRole("tm_authority"))
            {
                syscode += ",'tm'";
            }
            if (User.IsInRole("vt_authority"))
            {
                syscode += ",'vt'";
            }
        }
        if (syscode.Length > 0) syscode = syscode.Remove(0, 1);
        return syscode;
    }
    protected void gvAgent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //onclick="EditAgent('<%# Eval("pm_employee_id")%>')"
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsCanChgPwd) 
            {
                DataRowView currRowView = e.Row.DataItem as DataRowView;
                DataRow currRow = currRowView.Row;
                HtmlAnchor anchor = e.Row.FindControl("editAgent") as HtmlAnchor;
                if (anchor != null && currRow["pm_employee_id"] != null) 
                {
                    anchor.Attributes.Add("onclick", "EditAgent('" + currRow["pm_employee_id"].ToString() + "');");
                    anchor.Attributes.Add("href", "javascript:void(0)");
                }
            }
        }
    }

}
