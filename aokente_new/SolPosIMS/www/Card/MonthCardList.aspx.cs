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
using Ims.Card.Model;
using Ims.PM.BLL;
using Ims.Card.BLL;


public partial class Card_MonthCardList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }


        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            Area_Code.Items.Insert(0, new ListItem("全部", ""));
            InitListControlHelper.BindNormalTableToListControl(TypeID, "TypeId", "TypeName", "tb_CardType", "", "IsMonthlyCard = 1", "");
            TypeID.Items.Insert(0, new ListItem("全部", ""));

            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                Label2.Visible = false;
                Area_Code.Visible = false;
                Site_Code.Visible = false;
            }

            uptotime_begin.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");

        }
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
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的会员卡信息!");
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        tb_Card o = ParameterBindHelper.BindParameterToObject(typeof(tb_Card), BindParameterUsage.OpQuery) as tb_Card;
        if (Ims.Main.ImsInfo.UserIsInRoles("admin") != "")//Admin
        {
            o.SupportSites = Request.Form.Get("Site_Code");
        }

        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }

        //if (uptotime_begin.Value != "" && uptotime_end.Value != "")
        //{
        //    o.uptotime_begin = uptotime_begin.Value + " 00:00:00";
        //    o.uptotime_end = uptotime_end.Value + " 23:59:60";
        //}
        //else if (uptotime_begin.Value != "" && uptotime_end.Value == "")
        //{
        //    o.uptotime_begin = uptotime_begin.Value + " 00:00:00";
        //}
        //else if (uptotime_begin.Value == "" && uptotime_end.Value != "")
        //{
        //    o.uptotime_end = uptotime_end.Value + " 23:59:60";
        //}


        o.chflag = true;
        e.InputParameters[0] = o;

    }
}
