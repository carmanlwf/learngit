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
using Ims.Admin.Model;
using Ims.Main;
using Ims.Log.Model;
using Ims.Log.BLL;
using Ims.PM;
using Ims.Admin;
using Ims.PM.BLL;

public partial class Admin_UserListByAuthority : System.Web.UI.Page
{
    //private bool IsCanChgPwd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("agent,seller,channel,manager,admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(gvAgent, ObjectDataSource1);
        if (!Page .IsPostBack)
        {
            if (Ims.Main.ImsInfo.UserIsInRoles("admin") != "")//Admin  
        {
            //InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            //Area_Code.Items.Insert(0, new ListItem("全部", ""));
            //Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
            roles.Items.Insert(0, new ListItem("全部", ""));
            roles.Items.Insert(1, new ListItem("营业员", "channel"));
            roles.Items.Insert(2, new ListItem("系统管理员", "admin"));
            roles.Items.Insert(3, new ListItem("商户", "agent"));

        }

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
    //protected void gvAgent_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        if (IsCanChgPwd)
    //        {
    //            DataRowView currRowView = e.Row.DataItem as DataRowView;
    //            DataRow currRow = currRowView.Row;
    //            HtmlAnchor anchor = e.Row.FindControl("editAgent") as HtmlAnchor;
    //            if (anchor != null && currRow["pm_employee_id"] != null)
    //            {
    //                anchor.Attributes.Add("onclick", "EditAgent('" + currRow["pm_employee_id"].ToString() + "');");
    //                anchor.Attributes.Add("href", "javascript:void(0)");
    //            }
    //        }
    //    }
    //}
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        AgentData o = ParameterBindHelper.BindParameterToObject(typeof(AgentData), BindParameterUsage.OpQuery) as AgentData;
        o.validflag = true;
        e.InputParameters[0] = o;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
 
          //pm_employee o=new pm_employee();
          for (int i = 0; i < gvAgent.Rows.Count; i++)
            {
                CheckBox ck = gvAgent.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string userName = this.gvAgent.Rows[i].Cells[1].Text;
                    string suerid = this.gvAgent.Rows[i].Cells[2].Text;

                    //删除
                    bool b = AdminHelper.DeleteMember(suerid, userName);
                    if (b ==true )
                        {
                            count++;
                        
                        }
                }
                else
                {
                    n++;
                }
            }
            if (n == this.gvAgent.Rows.Count)
            {
                WebClientHelper.DoClientMsgBox("请先选择要删除的项!");
                return;
            }
            if (count > 0)
            {
                gvAgent.DataSourceID = "ObjectDataSource1";
                gvAgent.PageIndex = 0;
                gvAgent.DataBind();

                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "删除操作";
                if (sum == 0)
                {
                    log.logmsg = log.operater + "对人员进行删除操作,成功删除" + count + "条数据记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    log.logmsg = log.operater + "对人员进行删除操作,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);
                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败!");
            }
        }

    }
