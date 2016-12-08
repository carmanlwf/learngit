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
using Ims.Admin;
using ZsdDotNetLibrary.Utility;
using Ims.Admin.Model;
using ZsdDotNetLibrary.Web;
using System.Collections.Generic;
using ZsdDotNetLibrary.Log;
using Ims.Main;
using Ims.PM;
using Ims.PM.BLL;
//using Ims.PM.Model;
using Ims.PM.UI;
using Ims.Admin.BLL;
using Ims.Main.BLL;
public partial class Admin_AgentAuthority : System.Web.UI.Page
{
    private string currCheckSysStrs = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        string syscode = GetSysCodes();
        if (string.IsNullOrEmpty(syscode))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            //初始化用户基本信息
            if (Request.QueryString["pub_agentid"] != null)
            {
                string pub_agentid = HttpContext.Current.Request.QueryString["pub_agentid"];
                string[] agentids = pub_agentid.Split(',');
                ViewState["pub_agentid"] = agentids;

            }
            //初始化用户权限列表
            InitSysList();
        }        
    }


    /// <summary>
    /// 保存按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        SaveUserAuthority();
        InitSysList();
    }

    /// <summary>
    /// 保存用户权限信息
    /// </summary>
    private void SaveUserAuthority()
    {
        bool returnvalue = true;
        if (ViewState["pub_agentid"] == null) return ;
        //记录日志
        LogHelper.Write(ImsInfo.CurrentUserId+"于"+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"进行授权操作");
        //
        string[] agentids = (string[])(ViewState["pub_agentid"]);
        //1判断如果还未添加用户，则新增一个用户
        for (int k = 0; k < agentids.Length; k++)
        {
            MembershipUser user = Membership.GetUser(agentids[k]);
            if (user == null)
            {
                AgentData agent = new AgentData();
                agent.id = agentids[k];
                agent = AgentInfoBLL.GetObject(agent);
                Membership.CreateUser(agent.id, agent.pwd);
            }
        }
        string syscodes = GetSysCodes();//获取当前登录人员可授权模块
        string authoritys = GetCheckedcode();//获取已经勾选的权限、系统模块、角色
        string agents = GetAgentIds();//获取被授权用户id
        //调用BLL
        /*********2011-09-01纽斯康授权特征修改***********/
        /*********修改人：赵鹏***********/
        string[] authors = authoritys.Split(',');
        int flag = 0;
        for (int i = 0; i < authors.Length; i++)
        {
            if (authors[i].ToString().Trim()== "'manager'")
            {
                flag += 1;
            }
            else if (authors[i].ToString().Trim() == "'admin'")
            {
                flag += 1;
            }
            else if (authors[i].ToString().Trim() == "'agent'")
            {
                flag += 1;
            }
        }
        if (flag > 1)
        {
            WebClientHelper.DoClientMsgBox("不能同时分配两种以上权限:[系统管理员|区域代理商|店长].");
        }
        else
        {
            returnvalue = AuthorityBLL.SaveUserInAuthority(agents, syscodes, authoritys);
            //记录操作日志
            FunctionLogBLL.WriteFunLog(FunctionLogBLL.S_Authority, "授权用户" + agents + "信息");
            if (returnvalue)
            {
                WebClientHelper.DoClientMsgBox("保存成功!");
            }
            else
            {
                WebClientHelper.DoClientMsgBox("保存失败!");
            }
        }
    }
    private string GetCheckedcode()
    {
        string[] authorityitems = Request.Form.GetValues("cbauthorityitem");
        string[] sysitems = Request.Form.GetValues("cbsysitem");
        string[] roleitems = Request.Form.GetValues("cbroleitem");
        string returnvalue = "";
        if (sysitems != null)
        {
            for (int i = 0; i < sysitems.Length; i++)
            {
                returnvalue += ",'" + sysitems[i].Trim() + "'";
            }
        }
        if (roleitems != null)
        {
            for (int i = 0; i < roleitems.Length; i++)
            {
                int tmp = roleitems[i].Trim().IndexOf("|");
                returnvalue += ",'" + roleitems[i].Trim().Substring(0, tmp) + "'";
            }
        }
        if (authorityitems != null)
        {
            for (int i = 0; i < authorityitems.Length; i++)
            {
                int tmp = authorityitems[i].Trim().IndexOf("|");
                string temcode = "'" + authorityitems[i].Trim().Substring(0, tmp) + "'";
                if (returnvalue.IndexOf(temcode) < 0)
                {
                    returnvalue += "," + temcode;
                }
            }
        }
        if (!string.IsNullOrEmpty(returnvalue)) returnvalue = returnvalue.Remove(0, 1);
        return returnvalue;
    }
    private string GetAgentIds()
    {
        string[] agentids = (string[])(ViewState["pub_agentid"]);
        string returnvalue = "";
        for (int i = 0; i < agentids.Length; i++)
        {
            returnvalue += ",'" + agentids[i].Trim() + "'";
        }
        if (!string.IsNullOrEmpty(returnvalue)) returnvalue = returnvalue.Remove(0, 1);
        return returnvalue;
    }
    private string GetSysCodes()
    {
        string syscode = "";
        if (User.IsInRole("admin"))
        {
            syscode += ",'admin','tt','qc','manager','pub','spec','sn','agent','member'";
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
            if (User.IsInRole("sn_authority"))
            {
                syscode += ",'sn'";
            }
            if (User.IsInRole("agent"))
            {
                syscode += ",'agent'";
            }
        }
        if (syscode.Length > 0) syscode = syscode.Remove(0, 1);
        return syscode;
    }

    /// <summary>
    /// 根据当前用户的权限,初始化系统List
    /// </summary>
    private void InitSysList()
    {
        string agentid = "";
        if (ViewState["pub_agentid"] != null)
        {
            string[] agentids = (string[])(ViewState["pub_agentid"]);
            agentid = agentids[0];
        }
        string syscode = GetSysCodes();
        DataTable dataTable = AuthorityBLL.GetSysTable(syscode, agentid);
        tvsyslist.DataSource = dataTable;
        tvsyslist.DataBind();
        
        //2、刷新角色列表
        InitRoleList(syscode);

    }


    /// <summary>
    /// 根据系统code,初始化角色列表
    /// </summary>
    /// <param name="syscodes"></param>
    private void InitRoleList(string syscodes)
    {
        if (string.IsNullOrEmpty(syscodes))
        {
            tvRolelist.DataSource = null;
            tvRolelist.DataBind();
            return;
        }
        else
        {
            //1、刷新角色列表
            string agentid = "";
            if (ViewState["pub_agentid"] != null)
            {
                string[] agentids = (string[])(ViewState["pub_agentid"]);
                agentid = agentids[0];
            }
            DataTable dataTable = AuthorityBLL.GetRoleTableFromSyscode(syscodes, agentid);
            tvRolelist.DataSource = dataTable;
            tvRolelist.DataBind();

            //2、刷新当前用户的权限列表
            InitAuthorityList(syscodes);

        }
    }

    /// <summary>
    /// 根据系统code，初始化权限列表
    /// </summary>
    /// <param name="syscodes"></param>
    private void InitAuthorityList(string syscodes)
    {
        if (string.IsNullOrEmpty(syscodes))
        {
            tvAuthoritylist.DataSource = null;
            tvAuthoritylist.DataBind();
            return;
        }
        else
        {
            string agentid = "";
            if (ViewState["pub_agentid"] != null)
            {
                string[] agentids = (string[])(ViewState["pub_agentid"]);
                agentid = agentids[0];
            }
            DataTable dataTable = AuthorityBLL.GetAuthrityTableFromSyscode(syscodes, agentid);
            tvAuthoritylist.DataSource = dataTable;
            tvAuthoritylist.DataBind();
        }
    }

    protected void tvsyslist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
        bool isCheck = TypeHelper.ObjectToNullStr(((DataRowView)e.Item.DataItem)["checked"]) == "1";
        if (!isCheck) return;
        if (currCheckSysStrs != "") currCheckSysStrs += ",";
        currCheckSysStrs += "'" + ((DataRowView)e.Item.DataItem)["code"].ToString() +"'";
    }

}