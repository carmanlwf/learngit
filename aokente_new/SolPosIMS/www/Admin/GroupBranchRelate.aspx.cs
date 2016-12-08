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

public partial class Admin_GroupBranchRelate : System.Web.UI.Page
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
 
            //
            InitGroupInfo();
        }
    }
    /// <summary>
    /// 单击组List
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void groupinfo_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshGroupInfo();
    }
    /// <summary>
    /// 删除对照关系
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            string strBranchs = ControlHelper.SelectedListItemsToStr(branchIn.Items, true);
            if (String.IsNullOrEmpty(strBranchs))
            {
                WebClientHelper.DoClientMsgBox("请选择组内分公司!");
            }
            else
            {
                int count = BranchManageBLL.UpdateBranchGroupId(strBranchs, groupid, "2");
                if (count > 0)
                {
                    RefreshGroupInfo();
                }
            }
        }
    }
    /// <summary>
    /// 新增对照关系
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            string strBranchs = ControlHelper.SelectedListItemsToStr(branchOut.Items, true);
            if (String.IsNullOrEmpty(strBranchs))
            {
                WebClientHelper.DoClientMsgBox("请选择待选分公司!");
            }
            else
            {
                int count = BranchManageBLL.UpdateBranchGroupId(strBranchs, groupid, "1");
                if (count > 0)
                {
                    RefreshGroupInfo();
                }
            }

        }

    }


    #region 私有方法
    /// <summary>
    /// 初始化组信息列表
    /// </summary>
    private void InitGroupInfo()
    {
        //1、绑定组列表
        InitListControlHelper.BindNormalTableToListControl(groupinfo, "id", "groupname", "pub_groupinfo","id");
        //2、默认选择第一条
        if (groupinfo.Items.Count > 0)
        {
            groupinfo.SelectedIndex = 0;
            ViewState["admin_group_id"] = groupinfo.SelectedValue;
            //刷新
            RefreshGroupInfo();
        }
    }
    /// <summary>
    /// 绑定组信息列表
    /// </summary>
    private void RefreshGroupInfo()
    {
        if (groupinfo.SelectedItem == null) return;
        ViewState["admin_group_id"] = groupinfo.SelectedValue;
        //1、刷新组内分公司
        RefreshBranchInGroup();
        //2、刷新组待选分公司
        RefreshBranchNoGroup();
    }

    private void RefreshBranchInGroup()
    {
        if (groupinfo.SelectedItem == null) return;
        string groupidsel = groupinfo.SelectedValue.Trim();
        DataTable dtBranch = BranchManageBLL.GetBranchInGroup(groupidsel);
        if (dtBranch != null)
        {
            branchIn.Items.Clear();
            for (int i = 0; i < dtBranch.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Value = dtBranch.Rows[i]["code"].ToString();
                item.Text = dtBranch.Rows[i]["name"].ToString();
                branchIn.Items.Add(item);
            }
        }
    }
    private void RefreshBranchNoGroup()
    {
        if (groupinfo.SelectedItem == null) return;
        string groupidsel = groupinfo.SelectedValue.Trim();
        DataTable dtBranch = BranchManageBLL.GetBranchOutGroup(groupidsel);
        if (dtBranch != null)
        {
            branchOut.Items.Clear();
            for (int i = 0; i < dtBranch.Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Value = dtBranch.Rows[i]["code"].ToString();
                item.Text = dtBranch.Rows[i]["name"].ToString();
                branchOut.Items.Add(item);
            }
        }
    }
    #endregion
}
