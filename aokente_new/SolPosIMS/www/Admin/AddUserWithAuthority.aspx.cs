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
using Ims.PM;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Admin.Model;
using Ims.Admin.BLL;
using ZsdDotNetLibrary.Log;
using Ims.Main;
using Ims.Main.BLL;
using Ims.PM.BLL;

public partial class Admin_AddUserWithAuthority : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("agent,seller,channel,manager,admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长  
        {
            this.TABLE1.Rows[5].Style.Add("display ", "none ");
            this.TABLE1.Rows[6].Style.Add("display ", "none ");
        }
        if (!Page.IsPostBack)
        {
            //InitListControlHelper.BindNormalTableToListControl(siteid1, "id", "sitename", "tb_Site");
            //InitListControlHelper.BindNormalTableToListControl(GroupID1, "GroupID", "GroupName", "tb_Group", "", "DeleStatus =0", "");
            InitListControlHelper.BindNormalTableToListControl(roleid, "syscode", "name", "pub_rolesinfo");
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        if(pwd.Value .Trim().Length<5)
        { 
            WebClientHelper.DoClientMsgBox("密码长度不能小于5位!");
            return;
        }

        AgentData a = new AgentData();
        a.id = empid.Value.Trim();
        AgentData o1 = AgentInfoBLL.GetObject(a);
        pm_employee p = new pm_employee();
        p.code = code.Value.Trim();
        p.sex = Convert.ToInt16(gender.Value);
     
        pm_employee o2 = PmTtBLLHelper.GetObject(p);
        if (o1 == null && o2 == null)
        {

            //设置雇员信息
            pm_employee employee = new pm_employee();
            employee = ParameterBindHelper.BindParameterToObject(typeof(pm_employee), BindParameterUsage.BindToObject) as pm_employee;
            employee.sex =Convert.ToInt16 ( gender.Value);
            
            //设置用户信息
            AgentData agent = new AgentData();
            agent = ParameterBindHelper.BindParameterToObject(typeof(AgentData), BindParameterUsage.BindToObject) as AgentData;
            agent.pm_employee_id = code.Value;//员工编号
            agent.areaid = Request.Form["areaid"].ToString();
            //agent.groupinfo_id = GroupID1.Value;//会员所在组
            //设置权限与所在分店 

            if (Ims.Main.ImsInfo.CurrentUserId == "super")
            {
                //agent.areaid = siteid1.Value;
                //agent.roles = RadioButtonList1.SelectedValue;
                agent.roles = roleid.Value;
            }
            else
            {
                if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
                {
                    agent.roles = "channel";
                    agent.areaid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                }
                else
                {
                    //agent.areaid = siteid1.Value;
                    //agent.roles = RadioButtonList1.SelectedValue;
                    agent.roles = roleid.Value;
                   
                }
            }

            //当添加的用户是销售人员时，才有分组，否则，其它的全都没有组
            //if (RadioButtonList1.SelectedValue == "seller")
            if (roleid.Value == "seller")
            {
                //agent.groupinfo_id = GroupID1.Value;//会员所在组
                agent.areaid = "";
            }
            else
            {
                agent.groupinfo_id ="";//会员所在组
            }

            bool ret = AuthorityBLL.AddUserWithAuthority(employee, agent);
            if (ret)
            {  
                SaveUserAuthority();//用户授权
                // WebClientHelper.DoClientMsgBox("添加用户成功!");
                //string msg = "";
                ClientScriptManager cs = Page.ClientScript;
                Type cstype = this.GetType();
                string msg = "添加用户成功";
                if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
                {
                    cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("添加用户失败,请重试!");
            }
        }
        else
        {
            WebClientHelper.DoClientMsgBox("员工编号或工号重复!");
        }


    }
    /// <summary>
    /// 保存用户权限信息
    /// </summary>
    private void SaveUserAuthority()
    {
        bool returnvalue = true;
        //记录日志
        LogHelper.Write(ImsInfo.CurrentUserId + "于" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "进行授权操作");
        
        //1判断如果还未添加用户，则新增一个用户
        MembershipUser user = Membership.GetUser(empid.Value);
        if (user == null)
        {
            AgentData agent = new AgentData();
            agent.id = empid.Value;
            agent = AgentInfoBLL.GetObject(agent);
            Membership.CreateUser(agent.id, agent.pwd);
        }
        string syscodes = GetSysCodes();//获取当前登录人员可授权模块
        //string authoritys = "'" + ViewState["agent_authoritys"].ToString() + "'";//获取待分配的角色

        ////获取待分配的角色
        string authoritys = "";
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            authoritys = "'channel'";//获取待分配的角色
        }
        else
        {
            //authoritys = "'" + RadioButtonList1.SelectedValue + "'";//获取待分配的角色
            authoritys = "'" + roleid.Value + "'";
        }
        //string authoritys = "'" + RadioButtonList1.SelectedValue + "'";//获取待分配的角色
        string agents = "'" + empid.Value + "'";//获取被授权用户id
        //调用BLL
       
        returnvalue = AuthorityBLL.SaveUserInAuthority(agents, syscodes, authoritys);
        //记录操作日志
        FunctionLogBLL.WriteFunLog(FunctionLogBLL.S_Authority, "授权用户" + agents + "信息");
        //if (returnvalue)
        //{
        //    WebClientHelper.DoClientMsgBox("授权成功!");
        //}
        //else
        //{
        //    WebClientHelper.DoClientMsgBox("授权失败!");
        //}
    }
    private string GetSysCodes()
    {
        string syscode = "";
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            syscode = "-" + "channel";
        }
        else
        {
              //syscode = "-" + RadioButtonList1.SelectedValue;
            syscode = "-" + roleid.Value;
        }
   
        if (syscode.Length > 0) syscode = syscode.Remove(0, 1);
        return syscode;
    }

    
}
