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
using Ims.Admin.BLL;
using Ims.Admin.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Site.Model;

public partial class Admin_SiteAgentRelate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!Ims.Main.ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        //设置gridview风格样式
        GridViewHelper.InitDefaultGridViewEvent(gvGroup, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(areacode, "areacode", "areaname", "tb_area");
            areacode.Items.Insert(0, new ListItem("全部", ""));
        }
    }
    protected void imsbtnRight_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["admin_group_id"] == null)
        {
            WebClientHelper.DoClientMsgBox("请选择代理区域!");
            return;
        }
        else
        {
            string groupid = ViewState["admin_group_id"].ToString().Trim();
            string strAgents = ControlHelper.SelectedListItemsToStr(agentIn.Items, true);
            if (String.IsNullOrEmpty(strAgents))
            {
                WebClientHelper.DoClientMsgBox("请选择组内用户!");
            }
            else
            {
                int count = AgentInfoBLL.UpdateAgentSiteId(strAgents, null, "");
                if (count > 0)
                {

                    //刷新组内用户列表
                    agentIn.Items.Clear();
                    InitListControlHelper.BindNormalTableToListControl(agentIn, "id", "id+' '+ name", "v_pub_agentsiteinfo", "id", "siteid='" + groupid + "'", null);
                    //刷新待选用户列表
                    agentOut.Items.Clear();
                    InitListControlHelper.BindNormalTableToListControl(agentOut, "pm_employee_id", "case when id is null then  '*****'+' '+ name else id+' '+name end", "v_pub_agentnosite", "pm_employee_id", null, null);

                }
            }
        }
    }
    protected void imsbtnLeft_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["admin_group_id"] == null)
        {
            WebClientHelper.DoClientMsgBox("请选择分店!");
            return;
        }
        else
        {
            string groupid = ViewState["admin_group_id"].ToString().Trim();
            string employeeids = ControlHelper.SelectedListItemsToStr(agentOut.Items, true);
            if (String.IsNullOrEmpty(employeeids))
            {
                WebClientHelper.DoClientMsgBox("请选择待选用户!");
            }
            else
            {
                int temp = 0;
                for (int i = 0; i < agentOut.Items.Count; i++)
                {
                    if (agentOut.Items[i].Selected)
                    {
                        temp += 1;
                    }
                }
                int count = AgentInfoBLL.UpdateAgentSiteId(null, employeeids, groupid);
                if (temp != count)
                {
                    WebClientHelper.DoClientMsgBox("未授员工号用户不能选为店长!");
                }
                if (count > 0)
                {

                    //刷新组内用户列表
                    agentIn.Items.Clear();
                    InitListControlHelper.BindNormalTableToListControl(agentIn, "id", "id+' '+ name", "v_pub_agentsiteinfo", "id", "siteid='" + groupid + "'", null);
                    //刷新待选用户列表
                    agentOut.Items.Clear();
                    InitListControlHelper.BindNormalTableToListControl(agentOut, "pm_employee_id", "case when id is null then  '*****'+' '+ name else id+' '+name end", "v_pub_agentnosite", "pm_employee_id", null, null);

                }
            }

        }
    }
    protected void btnQuery_ServerClick(object sender, EventArgs e)
    {
        this.gvGroup.DataSourceID = "ObjectDataSource1";
        gvGroup.PageIndex = 0;
        gvGroup.DataBind();
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        object o = ParameterBindHelper.BindParameterToObject(typeof(tb_site), BindParameterUsage.OpQuery);
        e.InputParameters[0] = o;
    }
    protected void radBtnSel_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton radioCur = (RadioButton)sender;

        GridViewRow row = (GridViewRow)(radioCur.Parent.Parent);
        for (int i = 0; i < gvGroup.Rows.Count; i++)
        {
            RadioButton radio = (RadioButton)(gvGroup.Rows[i].FindControl("radBtnSel"));
            if (radio != null)
            {
                if (row.RowIndex != i)
                {
                    radio.Checked = false;
                }
            }
        }
        gvGroup.SelectedIndex = row.RowIndex;
        InitGroupInfo();
    }
    /// <summary>
    /// 刷新技能组信息和用户列表
    /// </summary>
    private void InitGroupInfo()
    {
        if (gvGroup.SelectedRow != null)
        {
            string groupidsel = gvGroup.SelectedDataKey.Value.ToString();
            GroupData groupData = new GroupData();
            groupData.id = groupidsel;
            groupData = GroupBLL.GetObject(groupData);
            //ParameterBindHelper.BindObjectToParameter(panelGroupInfo, groupData, BindParameterUsage.OpInsert);

            //改变状态为update
            ViewState["admin_group_status"] = "update";
            ViewState["admin_group_id"] = groupidsel;
            //btnAdd.Enabled = true;
            //只读控制
            //ControlHelper.SetControlReadonly(id, true);
            agentIn.Items.Clear();
            //刷新组内用户列表
            InitListControlHelper.BindNormalTableToListControl(agentIn, "id", "id+' '+ name", "v_pub_agentsiteinfo", "id", "siteid='" + groupidsel + "'", null);
            agentOut.Items.Clear();
            //刷新待选用户列表
            InitListControlHelper.BindNormalTableToListControl(agentOut, "pm_employee_id", "case when id is null then  '*****'+' '+ name else id+' '+name end", "v_pub_agentnosite", "pm_employee_id", null, null);

        }
    }
}
