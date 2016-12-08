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
using Ims.Main;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Admin.Model;
using Ims.Log.Model;
using Ims.Admin.BLL;
using Ims.PM;
using Ims.Log.BLL;
using Ims.Admin;

public partial class Admin_UserListByChannel : System.Web.UI.Page
{
    private bool IsCanChgPwd = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("agent,seller,channel,manager,admin") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        IsCanChgPwd = ImsInfo.UserIsInRole("admin");
        //初始化风格
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            //ViewState["type"] = Request.QueryString["type"].ToString();
            //ViewState["code"] = Request.QueryString["code"].ToString();
            //sort.Items.Insert(0, new ListItem("全部", ""));
            //sort.Items.Insert(1, new ListItem("纽斯康", "纽斯康"));
            //sort.Items.Insert(2, new ListItem("养生之家", "养生之家"));
            //sort.Items.Insert(3, new ListItem("母婴", "母婴"));

            sort.Items.Insert(0, new ListItem("全部", ""));
            sort.Items.Insert(1, new ListItem("餐饮美食", "餐饮美食"));
            sort.Items.Insert(2, new ListItem("食品百货", "食品百货"));
            sort.Items.Insert(3, new ListItem("服饰百货", "服饰百货"));
            sort.Items.Insert(4, new ListItem("日用百货", "日用百货"));
            sort.Items.Insert(5, new ListItem("母婴用品", "母婴用品"));
            sort.Items.Insert(6, new ListItem("酒店宾馆", "酒店宾馆"));
            sort.Items.Insert(7, new ListItem("旅行票务", "旅行票务"));
            sort.Items.Insert(8, new ListItem("休闲娱乐", "休闲娱乐"));
            sort.Items.Insert(9, new ListItem("美容护理", "美容护理"));
            sort.Items.Insert(10, new ListItem("摄影婚庆", "摄影婚庆"));
            sort.Items.Insert(11, new ListItem("鲜花礼品", "鲜花礼品"));
            sort.Items.Insert(12, new ListItem("数码家电", "数码家电"));
            sort.Items.Insert(13, new ListItem("汽车行业", "汽车行业"));
            sort.Items.Insert(14, new ListItem("家居建材", "家居建材"));
            sort.Items.Insert(15, new ListItem("房地产业", "房地产业"));
            sort.Items.Insert(16, new ListItem("医疗器械", "医疗器械"));
            sort.Items.Insert(17, new ListItem("文体办公", "文体办公"));
            sort.Items.Insert(18, new ListItem("广告印刷", "广告印刷"));
            sort.Items.Insert(19, new ListItem("其它行业", "其它行业"));
        }
    }
    protected void btnQuery_ServerClick(object sender, EventArgs e)
    {
        GridView1.PageIndex = 0;
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的人员信息!");
        }
    }
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
        o.roles = "'channel','seller'";
        e.InputParameters[0] = o;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    //string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;  //员工编号
                    //string id2 = this.GridView1.Rows[i].Cells[1].Text; //员工工号

                    //if (AgentInfoBLL.DelectEmpAgeMemberUser(o1, o2) == true && Membership.DeleteUser(id, true) == false)

                    string suerid = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    string userName = this.GridView1.Rows[i].Cells[2].Text;

                    //删除
                    bool b = AdminHelper.DeleteMember(suerid, userName);
     
                    if (b == true)  
                    {
                        count++;
                    }

                }
                else
                {
                    n++;
                }
            }
            if (n == this.GridView1.Rows.Count)
            {
                WebClientHelper.DoClientMsgBox("请先选择要删除的项!");
                return;
            }
            //删除成功才写入操作日志
            if (count > 0)
            {
                GridView1.DataSourceID = "ObjectDataSource1";
                GridView1.PageIndex = 0;
                GridView1.DataBind();

                //写入日志
                tb_Log log = new tb_Log();
                log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                log.operater = Ims.Main.ImsInfo.CurrentUserId;
                log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                log.type = "删除操作";
                log.logmsg = log.operater + "进行删除管理用户操作，共成功删除" + count + "条记录!";
                LogHelperBLL.InsertObject(log);
                WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
            }
            else
            {
                WebClientHelper.DoClientMsgBox("删除失败!");
            }
        }
    }
}
