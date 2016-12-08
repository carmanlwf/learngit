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
using Ims.Card.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.PM.BLL;

public partial class Card_CardActiveSelect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!IsPostBack)
        {
            activeway.Items.Insert(0, new ListItem("全部", ""));
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_card_CardActivityHistroy o = ParameterBindHelper.BindParameterToObject(typeof(v_card_CardActivityHistroy), BindParameterUsage.OpQuery) as v_card_CardActivityHistroy;
        o.flag = true;
        if (addeddate1.Value != "" && addeddate2.Value != "")
        {
            o.activetime1 = addeddate1.Value.Trim() + " 00:00:00";
            o.activetime2 = addeddate2.Value.Trim() + " 23:59:60";
        }
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            o.regionid = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        if (addeddate1.Value == "" && addeddate2.Value == "")
        {
            GridView1.DataSourceID = "ObjectDataSource1";
            GridView1.PageIndex = 0;
            GridView1.DataBind();
            if (GridView1.Rows.Count <= 0)
            {
                WebClientHelper.DoClientMsgBox("没有满足条件的激活卡记录信息!");
            }
        }
        else if (addeddate1.Value != "" && addeddate2.Value == "")
        { WebClientHelper.DoClientMsgBox("时间二不能为空!"); }
        else if (addeddate1.Value == "" && addeddate2.Value != "")
        { WebClientHelper.DoClientMsgBox("时间一不能为空!"); }
        else
        {
            GridView1.DataSourceID = "ObjectDataSource1";
            GridView1.PageIndex = 0;
            GridView1.DataBind();
            if (GridView1.Rows.Count <= 0)
            {
                WebClientHelper.DoClientMsgBox("没有满足条件的激活卡记录信息!");
            }
        }
    }
}
