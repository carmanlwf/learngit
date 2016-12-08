using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Ims.PM.BLL;
using ZsdDotNetLibrary.Web;
using Ims.Card.BLL;
using Ims.Card.Model;
using Ims.Main.BLL;

public partial class Report_Rpt_FreeParkList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,member,channel,manager,small,area_manager,statistician") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {

            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //  this.TABLE1.Rows[2].Style.Add("display ", "none ");
            }
            if (Ims.Main.ImsInfo.UserIsInRoles("channel") != "")
            {
                this.TABLE1.Rows[2].Style.Add("display ", "none ");
                //btnOut.Visible = false;
            }




            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area", "", "areacode = '" + areacode + "'", "");

                InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode = '" + areacode + "'", "");

            }
            else
            {

                InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
                Area_Code.Items.Insert(0, new ListItem("所有区域", ""));
            }


            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));

            BindStaticsData();

        }
    }

    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的交易信息!");
        }

       // BindStaticsData();

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        bool IsHasSpot = false;
        IsHasSpot = ConfigParmsInfo.IsHasSpot;
        if (!IsHasSpot)
        {
            GridView1.Columns[5].Visible = false;//动态隐藏车位号列
            GridView1.Columns[13].Visible = false;//动态隐藏地磁时间列
        }
        bool IsOpenPic = false;
        IsOpenPic = ConfigParmsInfo.IsOpenPic;
        if (!IsOpenPic)
        {
            GridView1.Columns[15].Visible = false;//动态隐藏图片查看列
        }
    }
    public void BindStaticsData()
    {
        string mode = !string.IsNullOrEmpty(Request.QueryString["type"]) ? Request.QueryString["type"].ToString() : "";//查询操作类型
        switch (mode)
        {
            case "xf":
                mode = "1";//一般消费
                break;
            case "cd_xf":
                mode = "2";//消费撤单
                break;
            case "jf":
                mode = "3";//积分交易
                break;
            case "cd_jf":
                mode = "4";//积分撤单
                break;
            case "cz":
                mode = "11";//充值交易
                break;
            case "cd_cz": //充值撤单
                mode = "12";//充值交易
                break;
            default:
                break;
        }

        if (start_date_begin.Value == "" && start_date_end.Value == "" )
        {
            start_date_begin.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            start_date_end.Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }

        DataTable dt = new DataTable();
        dt = POS_TransactionBLL.PostTransStatics("", "", CardSnr.Value.Trim(), mode, PosSnr.Value.Trim(), Site_Code.SelectedItem.Value, start_date_begin.Value.Trim(), start_date_end.Value.Trim(), Area_Code.SelectedItem.Value.Trim());
        if (dt != null && dt.Rows.Count > 0)
        {
            Label1.Text = dt.Rows[0]["XFTJ_Count"].ToString();
            //Label2.Text = dt.Rows[0]["CZTJ_Count"].ToString();
            //Label3.Text = dt.Rows[0]["CDTJ_Count"].ToString();
            Label4.Text = dt.Rows[0]["XFTJ_Amount"].ToString();
            //Label5.Text = dt.Rows[0]["CZTJ_Amount"].ToString();
            //Label6.Text = dt.Rows[0]["CDTJ_Amount"].ToString();
        }
        else
        {
            Label1.Text = "0";
            //Label2.Text = "0";
            //Label3.Text = "0";
            Label4.Text = "0.00";
            //Label5.Text = "0.00";
            //Label6.Text = "0.00";
        }

    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (start_date_begin.Value == "" && start_date_end.Value == "" )
        {
            start_date_begin.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            start_date_end.Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }
    
        //v_pos_transaction o = ParameterBindHelper.BindParameterToObject(typeof(v_pos_transaction), BindParameterUsage.OpQuery) as v_pos_transaction;
        v_pos_transaction o = new v_pos_transaction();
        if (!string.IsNullOrEmpty(CardSnr.Value.Trim()))
            o.CardSnr = CardSnr.Value.Trim();
        else
            o.CardSnr = "";
        if (!string.IsNullOrEmpty(PosSnr.Value.Trim()))
            o.PosSnr = PosSnr.Value.Trim();
        else
            o.PosSnr = "";
        if (!string.IsNullOrEmpty(this.CredenceSnr.Value.Trim()))
            o.CredenceSnr = CredenceSnr.Value.Trim();
        else
            o.CredenceSnr = "";
        if (!string.IsNullOrEmpty(start_date_begin.Value.Trim()) && !string.IsNullOrEmpty(start_date_end.Value.Trim()))
        {
            o.start_date_begin = start_date_begin.Value.Trim();
            o.end_date_begin = end_date_begin.Value.Trim();
        }
        if (!string.IsNullOrEmpty(end_date_begin.Value.Trim()) && !string.IsNullOrEmpty(end_date_end.Value.Trim()))
        {
            o.end_date_begin = end_date_begin.Value.Trim();
            o.end_date_end = end_date_end.Value.Trim();
        }
        o.Site_Code = Site_Code.SelectedItem.Value;
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }

        o.start_date_begin = start_date_begin.Value;
        o.start_date_end = start_date_end.Value;
        o.end_date_begin = end_date_begin.Value;
        o.end_date_end = end_date_end.Value;
        o.sumMins_min = 0;
        o.sumMins_max = 15;
        o.flag = true;
        e.InputParameters[0] = o;
    }

    /// <summary>
    /// 转换时分秒
    /// </summary>
    /// <param name="HowManySecond"></param>
    /// <returns></returns>
    public string RtnTimeStr(object Minutes)
    {

        string SumMins = "";
        if (Minutes != null)
            SumMins = Minutes.ToString();
        else
            SumMins = "0分钟";
        int Mins = 0;
        if (!string.IsNullOrEmpty(SumMins))
        {
            int.TryParse(SumMins, out Mins);
        }
        else
        { return "0分钟"; }

        int days = Mins / 1440;//天数
        int day_plus = Mins % 1440;//余数(分钟)
        int hour = day_plus / 60;//小时数
        int Min = day_plus % 60; //(余数)分钟数

        return days + "天" + hour + "小时" + Min + "分";
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //注释掉下面的代码，否则在asp.net2.0下会报错（注：GridView是asp.net2.0下的控件，1.1下一些控件也可以导出成Excel或者Word）
        //base.VerifyRenderingInServerForm(control);
    }

    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            Site_Code.Items.Clear();
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
        }
    }
}
