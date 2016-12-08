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
using Ims.Admin.Model;
using Ims.Admin.BLL;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Utility;
//using Ims.User;
using System.Collections.Generic;
using Ims.Main.BLL;
using Ims;
using Ims.Main;
public partial class Admin_AgentInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (!ImsInfo.UserIsInRole("admin") || !ImsInfo.UserIsInRole("admin"))
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {

            //初始化用户基本信息
            if (Request.QueryString["pub_agentid"] != null)
            {
                string pub_agentid = HttpContext.Current.Request.QueryString["pub_agentid"];
                AgentData agent = new AgentData();
                agent.id = pub_agentid;
                BindAgentInfo(agent);
            }
            else if (Request.QueryString["pub_employeeid"] != null)
            {
                string pub_employeeid = HttpContext.Current.Request.QueryString["pub_employeeid"];
                AgentData agent = new AgentData();
                agent.pm_employee_id = pub_employeeid;
                agent.validflag = true;
                BindAgentInfo(agent);
            }
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        //根据状态，初始化页面控件只读属性
        if (Request.QueryString["pub_agent_status"] != null)
        {
            string status = HttpContext.Current.Request.QueryString["pub_agent_status"];
            if (status == "view")
            {
                ControlHelper.SetControlsReadonly(true);
                btnSave.Visible = false;
            }
        }
    }


    /// <summary>
    /// 保存按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        //1、保存用户信息
        if (!string.IsNullOrEmpty(curagentid.Value))
        {
            //修改
            UpdateAgent();
        }
        else
        {
            //新增
            InsertAgent();
        }
    }

    #region 私有方法

    /// <summary>
    /// 新增用户信息
    /// </summary>
    private void InsertAgent()
    {
        AgentData agentInfo = new AgentData();
        ParameterBindHelper.BindParameterToObject(panelAgent, agentInfo, BindParameterUsage.OpInsert);
        bool ishave = AgentInfoBLL.CheckAgentData(agentInfo);
        if (ishave)
        {
            //提示当前员工工号已经存在
            WebClientHelper.DoClientMsgBox("当前员工工号已经存在!");
            return;
        }
        else
        {
            //新增
            AgentInfoBLL.InsertObject(agentInfo);
            curagentid.Value = agentInfo.id;
            UpdateBiaAgent(agentInfo);
            //记录操作日志
            FunctionLogBLL.WriteFunLog(FunctionLogBLL.S_EditAgent, "新增用户" + agentInfo.id + "信息");
            WebClientHelper.DoClientMsgBox("保存成功!");
            ControlHelper.SetControlReadonly(empid, true);

        }
    }

    /// <summary>
    /// 修改用户信息
    /// </summary>
    private void UpdateAgent()
    {
        AgentData agentInfo = new AgentData();
        agentInfo.id = curagentid.Value.Trim();
        ParameterBindHelper.BindParameterToObject(panelAgent, agentInfo, BindParameterUsage.OpInsert);

        //修改
        AgentInfoBLL.UpdateObject(agentInfo);
        UpdateBiaAgent(agentInfo);
        ////记录操作日志
        FunctionLogBLL.WriteFunLog(FunctionLogBLL.S_EditAgent, "修改用户" + agentInfo.id + "信息");
        WebClientHelper.DoClientMsgBox("保存成功!");
    }

    /// <summary>
    /// 绑定用户基本信息
    /// </summary>
    /// <param name="agentData"></param>
    private void BindAgentInfo(AgentData agentData)
    {
        agentData = AgentInfoBLL.GetObject(agentData);
        if (agentData != null)
        {
            ParameterBindHelper.BindObjectToParameter(panelAgent, agentData, BindParameterUsage.OpQuery);
            curagentid.Value = agentData.id;
            if (!string.IsNullOrEmpty(agentData.id))
            {
                ControlHelper.SetControlReadonly(empid, true);
            }
            //BizAgent objBizAgent = new BizAgent();
            //objBizAgent.agentid = agentData.id;
            //objBizAgent = AgentInfoBLL.GetBizAgent(objBizAgent);
            //if (objBizAgent != null)
            //{
            //    bizoperid.Value = objBizAgent.bizoperid;
            //}
            //else
            //{
            //    bizoperid.Value = agentData.id;
            //}
        }
        else
        {
            WebClientHelper.DoClientMsgBox("无此员工编号的员工!");
            btnSave.Visible = false;
            btnAuthority.Visible = false;
        }

    }
    /// <summary>
    /// 修改核心业务系统对照密码
    /// </summary>
    /// <param name="agentData"></param>
    private void UpdateBiaAgent(AgentData agentData)
    {
        //BizAgent objBizAgent = new BizAgent();
        //objBizAgent.agentid = agentData.id;
        //objBizAgent.bizoperid = bizoperid.Value;
        //objBizAgent.bizoperid = bizoperid.Value;
        //AgentInfoBLL.UpdateBizAgent(objBizAgent);
    }
    #endregion


    /// <summary>
    /// 恢复登录状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBackLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(curagentid.Value))
        {
            WebClientHelper.DoClientMsgBox("无效的员工工号不能恢复!");
            return;
        }
        AgentData agentInfo = new AgentData();
        agentInfo.id = curagentid.Value.Trim();
        int returnvalue= AgentInfoBLL.BackUpAgentLoginStatus(agentInfo);
        if (returnvalue == 1)
        {
            WebClientHelper.DoClientMsgBox("恢复成功!");
        }
        else
        {
            WebClientHelper.DoClientMsgBox("恢复失败!");
        }
    }
}

