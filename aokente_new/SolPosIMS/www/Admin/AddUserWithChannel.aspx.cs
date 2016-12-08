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

public partial class Admin_AddUserWithChannel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("agent,seller,channel,manager,admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            ////sort.Items.Insert(0, new ListItem("全部", ""));
            //sort.Items.Insert(0, new ListItem("纽斯康", "纽斯康"));
            //sort.Items.Insert(1, new ListItem("养生之家", "养生之家"));
            //sort.Items.Insert(2, new ListItem("母婴", "母婴"));


            sort.Items.Insert(0, new ListItem("餐饮美食", "餐饮美食"));
            sort.Items.Insert(1, new ListItem("食品百货", "食品百货"));
            sort.Items.Insert(2, new ListItem("服饰百货", "服饰百货"));
            sort.Items.Insert(3, new ListItem("日用百货", "日用百货"));
            sort.Items.Insert(4, new ListItem("母婴用品", "母婴用品"));
            sort.Items.Insert(5, new ListItem("酒店宾馆", "酒店宾馆"));
            sort.Items.Insert(6, new ListItem("旅行票务", "旅行票务"));
            sort.Items.Insert(7, new ListItem("休闲娱乐", "休闲娱乐"));
            sort.Items.Insert(8, new ListItem("美容护理", "美容护理"));
            sort.Items.Insert(9, new ListItem("摄影婚庆", "摄影婚庆"));
            sort.Items.Insert(10, new ListItem("鲜花礼品", "鲜花礼品"));
            sort.Items.Insert(11, new ListItem("数码家电", "数码家电"));
            sort.Items.Insert(12, new ListItem("汽车行业", "汽车行业"));
            sort.Items.Insert(13, new ListItem("家居建材", "家居建材"));
            sort.Items.Insert(14, new ListItem("房地产业", "房地产业"));
            sort.Items.Insert(15, new ListItem("医疗器械", "医疗器械"));
            sort.Items.Insert(16, new ListItem("文体办公", "文体办公"));
            sort.Items.Insert(17, new ListItem("广告印刷", "广告印刷"));
            sort.Items.Insert(18, new ListItem("其它行业", "其它行业"));





        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        AgentData a = new AgentData();
        a.id = empid.Value.Trim();
        AgentData o1 = AgentInfoBLL.GetObject(a);
        pm_employee p = new pm_employee();
        p.code = code.Value.Trim();
        pm_employee o2 = PmTtBLLHelper.GetObject(p);
        if (o1 == null && o2 == null)
        {
        //设置雇员信息
        pm_employee employee = new pm_employee();
        employee = ParameterBindHelper.BindParameterToObject(typeof(pm_employee), BindParameterUsage.BindToObject) as pm_employee;
        //设置用户信息
        AgentData agent = new AgentData();
        agent = ParameterBindHelper.BindParameterToObject(typeof(AgentData), BindParameterUsage.BindToObject) as AgentData;
        agent.pm_employee_id = code.Value;//员工编号
        //agent.flag = true;
        agent.validflag = true;
        agent.sort = sort.Value;//渠道
        if (superflag.Checked) { agent.roles = "channel"; } else { agent.roles = "seller";}
        bool ret = AuthorityBLL.AddUserWithAuthority(employee, agent);
        if (ret)
        {
            WebClientHelper.DoClientMsgBox("添加用户成功!");
            SaveUserAuthority();//用户授权
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
        string authoritys = "";
        if (superflag.Checked) { authoritys = "'channel'"; } else { authoritys = "'seller'"; }
        string agents = "'" + empid.Value + "'";//获取被授权用户id
        //调用BLL

        returnvalue = AuthorityBLL.SaveUserInAuthority(agents, syscodes, authoritys);
        //记录操作日志
        FunctionLogBLL.WriteFunLog(FunctionLogBLL.S_Authority, "授权用户" + agents + "信息");
        if (returnvalue)
        {
            WebClientHelper.DoClientMsgBox("授权成功!");
        }
        else
        {
            WebClientHelper.DoClientMsgBox("授权失败!");
        }
    }
    private string GetSysCodes()
    {
        string syscode = "";
        if (User.IsInRole("admin"))
        {
            syscode += ",'admin','manager','pub','agent','member','channel','seller'";
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
}
