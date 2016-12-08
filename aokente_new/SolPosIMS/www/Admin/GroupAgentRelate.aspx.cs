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
//using Ncl.Admin.Model;
//using Ncl.Admin.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Utility;
using Ims.Admin.Model;
using Ims.Admin.BLL;
using Ims.Site.Model;
public partial class Admin_GroupAgentRelate : System.Web.UI.Page
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


            //绑定下拉框
            //InitListControlHelper.BindCodesToListControl(typecode, "jnzlx");
            //绑定下拉框
            InitListControlHelper.BindNormalTableToListControl(areacode, "areacode", "areaname", "tb_area");
            areacode.Items.Insert(0, new ListItem("全部", ""));
            //绑定下拉框
            //InitListControlHelper.BindCodesToListControl(levelcode, "zzdj");
            //默认为新增状态
            //btnAdd_ServerClick(btnAdd, new EventArgs());

        }
    }
    
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //tb_site obj = new tb_site();
        //obj.id = id.Value;
        //obj.flag = true;
        ////obj.typecode = typecodequery.Value;
        ////if (validflagquery.Value == "1")
        ////{
        ////    obj.validflag = true;
        ////}
        ////else if (validflagquery.Value == "0")
        ////{
        ////    obj.validflag = false;
        ////}
        //e.InputParameters[0] = obj;
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
    #region 界面按钮
    /// <summary>
    /// 添加按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {
        ////清空界面
        //GroupData groupData = new GroupData();
        //groupData.validflag = true;
        //ParameterBindHelper.BindObjectToParameter(panelGroupInfo, groupData, BindParameterUsage.OpInsert);
        ////改变状态为add
        //ViewState["admin_group_status"] = "add";
        ////只读控制
        //ControlHelper.SetControlReadonly(id, false);
        //btnAdd.Enabled = false;
    }

    /// <summary>
    /// 保存按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        //if (ViewState["admin_group_status"] == null)
        //{
        //    return;
        //}
        //else if (ViewState["admin_group_status"].ToString() == "add")
        //{
        //    //新增
        //    InsertData();
        //}
        //else if (ViewState["admin_group_status"].ToString() == "update")
        //{
        //    //修改
        //    UpdateData();
        //}
    }
    /// <summary>
    /// 浏览组内用户按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnView_ServerClick(object sender, EventArgs e)
    {
        if (agentIn.SelectedIndex < 0)
        {
            //提示组号已经存在
            WebClientHelper.DoClientMsgBox("未选择组内用户，不能浏览!");
            return;
        }
        else
        {
            string agentid = agentIn.Value.Trim();
            string url = "AgentInfo.aspx?pub_agentid=" + agentid + "&pub_agent_status=view";
            Redirect(url);
        }
    }
    /// <summary>
    /// 编辑待选用户按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_ServerClick(object sender, EventArgs e)
    {
        if (agentOut.SelectedIndex < 0)
        {
            //提示组号已经存在
            WebClientHelper.DoClientMsgBox("未选择待选用户，不能浏览!");
            return;
        }
        else
        {
            string agentcode = agentOut.Value.Trim();
            string url = "AgentInfo.aspx?pub_employeeid=" + agentcode + "&pub_agent_status=edit";
            Redirect(url);
        }
    }
    /// <summary>
    /// 浏览待选用户按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnView2_ServerClick(object sender, EventArgs e)
    {

        if (agentOut.SelectedIndex < 0)
        {
            //提示组号已经存在
            WebClientHelper.DoClientMsgBox("未选择待选用户，不能浏览!");
            return;
        }
        else
        {
            string agentcode = agentOut.Value.Trim();
            string url = "AgentInfo.aspx?pub_employeeid=" + agentcode + "&pub_agent_status=view";
            Redirect(url);
        }
    }
    protected void imsbtnRight_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["admin_group_id"] == null)
        {
            WebClientHelper.DoClientMsgBox("请选择技能组!");
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
                int count = AgentInfoBLL.UpdateAgentGroupId(strAgents, null, "");
                if (count > 0)
                {

                    //刷新组内用户列表
                    agentIn.Items.Clear();
                    InitListControlHelper.BindNormalTableToListControl(agentIn, "id", "id+' '+ name", "v_pub_agentsiteinfo", "id", "groupid='" + groupid + "'", null);
                    //刷新待选用户列表
                    agentOut.Items.Clear();
                    InitListControlHelper.BindNormalTableToListControl(agentOut, "pm_employee_id", "case when id is null then  '*****'+' '+ name else id+' '+name end", "v_pub_agentnogroup", "pm_employee_id", null, null);

                }
            }
        }
    }
    protected void imsbtnLeft_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["admin_group_id"] == null)
        {
            WebClientHelper.DoClientMsgBox("请选择技能组!");
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
                int count = AgentInfoBLL.UpdateAgentGroupId(null, employeeids, groupid);
                if (temp != count)
                {
                    WebClientHelper.DoClientMsgBox("未授员工号用户不能选入技能组!");
                }
                if (count > 0)
                {

                    //刷新组内用户列表
                    agentIn.Items.Clear();
                    InitListControlHelper.BindNormalTableToListControl(agentIn, "id", "id+' '+ name", "v_pub_agentsiteinfo", "id", "groupid='" + groupid + "'", null);
                    //刷新待选用户列表
                    agentOut.Items.Clear();
                    InitListControlHelper.BindNormalTableToListControl(agentOut, "pm_employee_id", "case when id is null then  '*****'+' '+ name else id+' '+name end", "v_pub_agentnogroup", "pm_employee_id", null, null);

                }
            }

        }
    }
    /// <summary>
    /// 查询按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_ServerClick(object sender, EventArgs e)
    {
        gvGroup.PageIndex = 0;
        gvGroup.DataBind();
    }
    #endregion 

    #region 私有方法

    /// <summary>
    /// 新增技能组信息
    /// </summary>
    //private void InsertData()
    //{
    //    GroupData groupdata = new GroupData();
    //    ParameterBindHelper.BindParameterToObject(panelGroupInfo, groupdata, BindParameterUsage.OpInsert);
    //    bool ishave = GroupBLL.CheckGroupData(groupdata);
    //    if (ishave)
    //    {
    //        //提示组号已经存在
    //        WebClientHelper.DoClientMsgBox("当前组号已经存在!");
    //        return;
    //    }
    //    else
    //    {
    //        //新增
    //        GroupBLL.InsertObject(groupdata);
    //        //刷新界面
    //        gvGroup.PageIndex = 0;
    //        gvGroup.DataBind();
    //    }
    //}

    /// <summary>
    /// 修改技能组信息
    /// </summary>
    //private void UpdateData()
    //{
    //    GroupData groupdata = new GroupData();
    //    ParameterBindHelper.BindParameterToObject(panelGroupInfo, groupdata, BindParameterUsage.OpUpdate);

    //    //修改
    //    GroupBLL.UpdateObject(groupdata);
    //    //刷新界面
    //    gvGroup.PageIndex = 0;
    //    gvGroup.DataBind();

    //}

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
            InitListControlHelper.BindNormalTableToListControl(agentIn, "id", "id+' '+ name", "v_pub_agentsiteinfo", "id", "groupid='" + groupidsel + "'", null);
            agentOut.Items.Clear();
            //刷新待选用户列表
            InitListControlHelper.BindNormalTableToListControl(agentOut, "pm_employee_id", "case when id is null then  '*****'+' '+ name else id+' '+name end", "v_pub_agentnogroup", "pm_employee_id", null, null);

        }
    }

    private void Redirect(string url)
    {
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "Test"))
        {
            cs.RegisterClientScriptBlock(cstype, "Test", "<script>window.open('"+url+"',target='_blank')</script>");

        }
    }
    #endregion



}
