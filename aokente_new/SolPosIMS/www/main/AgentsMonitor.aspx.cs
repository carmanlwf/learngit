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
using Ims.Main.Model;
using Ims;
using Ims.Main;

public partial class main_AgentsMonitor : System.Web.UI.Page
{
    public string action = "";
    public string currSelectAgentId = "";
    public string currSelectAllAgentId = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        action = (string)ViewState["action"];
        currSelectAllAgentId = Request.Form.Get("selectCheckboxButton1");
        if (currSelectAllAgentId == null) currSelectAllAgentId = "";
        string[] currSelectAgentIds = Request.Form.GetValues("selectCheckboxButton1");
        if (currSelectAgentIds != null && currSelectAgentIds.Length>0)
            currSelectAgentId = currSelectAgentIds[0];
        if (!Page.IsPostBack)
        {
            InitListControlHelper.InitListControls(typeof(v_agentinfo));
            //qc_qcall  qc_qcgroup
            ViewState["action"] = action = Request.QueryString["action"];//monitor qc
            //if (string.IsNullOrEmpty(action)) action = "monitor";
            if(action == "statusmonitor")
            {
                if (ImsInfo.CurrentUser == null)
                {
                    ImsInfo.CheckUserRoles("");
                    return;
                }
                refeshsecond.Value = "";
                agentsstatus.AllowPaging = false;
                agentsstatus.ShowFooter = true;
            }
            else if (action == "monitor")
            {
                if (ImsInfo.CurrentUser== null || !ImsInfo.CurrentUser.IsSupervisor)
                {
                    ImsInfo.CheckUserRoles("");
                    return;
                }
                refeshsecond.Value = "10";
                sbtnQC.Visible = false;
                if (!ImsInfo.UserIsInRole("aa_RealtimeAgent"))
                {
                    if (groupid_in.Items.FindByValue(ImsInfo.CurrentUser.GroupId) != null)
                    {
                        groupid_in.SelectedValue = ImsInfo.CurrentUser.GroupId;
                    }
                    groupid_in.Attributes["disabled"] = "disabled";
                }
                agentsstatus.AllowPaging = true;
                agentsstatus.ShowFooter = false;
            }
            else if (action == "qc")
            {
                string currRole = ImsInfo.CheckUserRoles("qc_qcall,qc_qcgroup");
                if (string.IsNullOrEmpty(currRole))
                {
                    return;
                }
                if (currRole == "qc_qcgroup")
                {
                    if (groupid_in.Items.FindByValue(ImsInfo.CurrentUser.GroupId) != null)
                    {
                        groupid_in.SelectedValue = ImsInfo.CurrentUser.GroupId;
                    }
                    groupid_in.Attributes["disabled"] = "disabled";
                }
                refeshsecond.Value = "";
                sbtnReady.Visible = sbtnLogout.Visible = sbtnInterceptCall.Visible = false;
                agentsstatus.AllowPaging = false;
                agentsstatus.ShowFooter = true;
            }
            else
            {
                WebClientHelper.DoResultClientProcess(false, "无效的操作请求！", 0, WebClientHelper.ToDo.CloseSelfWindow);
                return;
            }

        }

        GridViewHelper.InitDefaultGridViewEvent(agentsstatus, AgentsStatusInfoDataSource);
    }

    protected void AgentsStatusInfoDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_agentinfo o = ParameterBindHelper.BindParameterToObject<v_agentinfo>(BindParameterUsage.OpQuery);
        o.groupid_in = ControlHelper.SelectedListItemsToStr(groupid_in.Items, true);
        o.access_status_in = ControlHelper.SelectedListItemsToStr(access_status_in.Items, true);
        e.InputParameters[0] = o;
    }

    protected void btnRefesh_ServerClick(object sender, EventArgs e)
    {
        //agentsstatus.PageIndex = 0;
        agentsstatus.DataBind();
    }

    protected void agentsstatus_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            //e.Row.Cells[0].Attributes["colspan"] = "7";
        }
    }
}
/*
 新增了三个角色
pub_telin	电话呼入	
pub_telout	电话呼出	
pub_common	公共权限	
新增了以下权限
pub_telipccagen		IPCC软电话
pub_telipccsupervisor	IPCC班长
pub_telepagent   	EP软电话
pub_telepsupervisor	EP班长
pub_voicelisten	        留言调听
pub_faxsend	        传真发送
pub_noticepublish	公告发布
pub_audiolisten	        录音调听

pub_agentinfo数据表中superid改为superflag，标识是否行政班长，默认为0
 
 */
