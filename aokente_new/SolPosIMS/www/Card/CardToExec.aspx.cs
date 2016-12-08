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
using ZsdDotNetLibrary.Web;
using Ims.Card.BLL;
using Ims.Card.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data;

public partial class Card_CardToExec : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!IsPostBack)
        {
        
            cardstatus1.Items.Insert(0, new ListItem("全部", ""));
            cardstatus1.Items.Insert(1, new ListItem("已使用", "已使用"));
            cardstatus1.Items.Insert(2, new ListItem("已补卡", "已补卡"));
            cardstatus1.Items.Insert(2, new ListItem("未激活", "未激活"));

            InitListControlHelper.BindNormalTableToListControl(TypeID, "TypeID", "TypeName", "tb_CardType");
            TypeID.Items.Insert(0, new ListItem("全部", ""));

            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            Area_Code.Items.Insert(0, new ListItem("全部", ""));
        }
    }

    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {

            LabelCardSum.Text = "0";
            LabelCardActiveSum.Text = "0";
            LabelCardNoActiveSum.Text = "0";
            LabelCardNoActiveSumBan.Text = "0.00";
            LabelMemberSumBan.Text = "0.00";
            LabelCardInitValue_Normal.Text = "0.00";
            LabelCardInitValue_NoActived.Text = "0.00";
            WebClientHelper.DoClientMsgBox("没有满足条件的会员卡信息!");
        }
        else
        {

            //声明一个 DataTable 
            DataTable dt_static = new DataTable();
            //dt_static = v_CardToExecBLL.CardCount("", "", cardstatus1.Value, addeddate1.Value, addeddate2.Value, activetime1.Value, activetime2.Value);
            string siteid = "";
            if (!string.IsNullOrEmpty(Request.Form.Get("Site_Code")))
            {
                //siteid = Request.Form.Get("Site_Code");
                siteid = Site_Code.SelectedValue;
            }
            else
            {
                siteid = "";
            }
            siteid = Site_Code.SelectedValue;

            //if (Checkbox2.Checked == true)
            //{
                dt_static = v_CardToExecBLL.CardCount(TypeID.Value, siteid, cardstatus1.Value, addeddate1.Value, addeddate2.Value, activetime1.Value, activetime2.Value, initvalue.Value.Trim(), S_Point.Value.Trim(), E_Point.Value.Trim());
            //}
            //if (Checkbox3.Checked == true)
            //{
            //    dt_static = v_CardToExecBLL.CardCount(TypeID.Value, siteid, cardstatus1.Value, "", "", activetime1.Value, activetime2.Value, initvalue.Value.Trim(), S_Point.Value.Trim(), E_Point.Value.Trim());
            //}
            //if (Checkbox4.Checked == true)
            //{
            //    dt_static = v_CardToExecBLL.CardCount(TypeID.Value, "", "未激活", addeddate1.Value, addeddate2.Value, "", "",initvalue.Value.Trim(),S_Point.Value.Trim(),E_Point.Value.Trim());
            //}



            if (dt_static.Rows.Count > 0)
            {

                LabelCardSum.Text = !string.IsNullOrEmpty(dt_static.Rows[0]["发卡总数_所有"].ToString())?dt_static.Rows[0]["发卡总数_所有"].ToString():"0.00";//总卡数
                LabelCardNoActiveSum.Text = !string.IsNullOrEmpty(dt_static.Rows[0]["发卡总数_未激活"].ToString())?dt_static.Rows[0]["发卡总数_未激活"].ToString():"0";//未激活卡数
                LabelCardActiveSum.Text = !string.IsNullOrEmpty(dt_static.Rows[0]["发卡总数_已使用"].ToString())?dt_static.Rows[0]["发卡总数_已使用"].ToString():"0";
                LabelCardNoActiveSumBan.Text = !string.IsNullOrEmpty(dt_static.Rows[0]["发卡总额_未激活"].ToString())?dt_static.Rows[0]["发卡总额_未激活"].ToString():"0.00" ;//未激活卡金额
                LabelMemberSumBan.Text = !string.IsNullOrEmpty(dt_static.Rows[0]["发卡总额_已使用"].ToString())?dt_static.Rows[0]["发卡总额_已使用"].ToString():"0.00";//会员当前余额
                LabelCardInitValue_NoActived.Text = !string.IsNullOrEmpty(dt_static.Rows[0]["初始总额_未激活"].ToString())?dt_static.Rows[0]["初始总额_未激活"].ToString():"0.00";
                LabelCardInitValue_Normal.Text = !string.IsNullOrEmpty(dt_static.Rows[0]["初始总额_已使用"].ToString()) ? dt_static.Rows[0]["初始总额_已使用"].ToString() : "0.00";
            }
        }
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        v_CardToExec o = ParameterBindHelper.BindParameterToObject(typeof(v_CardToExec), BindParameterUsage.OpQuery) as v_CardToExec;
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = Ims.PM.BLL.PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        if (Checkbox2.Checked == true)
        {
            if (addeddate1.Value != "")
            {
                o.addeddate1 = addeddate1.Value + " 00:00:00";
                o.addeddate2 = addeddate2.Value + " 23:59:60";
            }
            else if (addeddate1.Value != "" && addeddate2.Value == "")
            {
                o.addeddate1 = addeddate1.Value + " 00:00:00";
            }
            else if (addeddate1.Value == "" && addeddate2.Value != "")
            {
                o.addeddate2 = addeddate2.Value + " 23:59:60";
            }

            if (activetime1.Value != "" && activetime2.Value != "")
            {
                o.activetime1 = activetime1.Value + " 00:00:00";
                o.activetime2 = activetime2.Value + " 23:59:60";
            }
            else if (activetime1.Value != "" && activetime2.Value == "")
            {
                o.activetime1 = activetime1.Value + " 00:00:00";
            }
            else if (activetime1.Value == "" && activetime2.Value != "")
            {
                o.activetime2 = activetime2.Value + " 23:59:60";
            }
            //o.isuseornouser = "2";
            o.userRank = "";
            //o.siteid = Request.Form.Get("Site_Code");
            o.siteid = Site_Code.SelectedValue;
            o.cardstatus = cardstatus1.Value;

        }
        if (Checkbox3.Checked == true)
        {
            o.addeddate1 = "";
            o.addeddate2 = "";
            if (activetime1.Value != "" && activetime2.Value != "")
            {
                o.activetime1 = activetime1.Value + " 00:00:00";
                o.activetime2 = activetime2.Value + " 23:59:60";
            }
            else if (activetime1.Value != "" && activetime2.Value == "")
            {
                o.activetime1 = activetime1.Value + " 00:00:00";
            }
            else if (activetime1.Value == "" && activetime2.Value != "")
            {
                o.activetime2 = activetime2.Value + " 23:59:60";
            }
            o.isuseornouser = "2";
            o.userRank = "";
            //o.siteid = Request.Form.Get("Site_Code");
            o.siteid = Site_Code.SelectedValue;
            o.cardstatus = cardstatus1.Value;
        }
        if (Checkbox4.Checked == true)
        {
            if (addeddate1.Value != "")
            {
                o.addeddate1 = addeddate1.Value + " 00:00:00";
                o.addeddate2 = addeddate2.Value + " 23:59:60";
            }
            else if (addeddate1.Value != "" && addeddate2.Value == "")
            {
                o.addeddate1 = addeddate1.Value + " 00:00:00";
            }
            else if (addeddate1.Value == "" && addeddate2.Value != "")
            {
                o.addeddate2 = addeddate2.Value + " 23:59:60";
            }

            o.activetime1 = "";
            o.activetime2 = "";
            o.isuseornouser = "1";
            o.userRank = "";
            o.siteid = "";
            o.cardstatus = "";
            o.cardstatus = "未激活";
        }
        o.flag = true;
        e.InputParameters[0] = o;
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {

        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("请先对数据进行预览，再执行导出！");
        }
        else
        {
            //声明一个 DataTable 
            DataTable dt = new DataTable();
            string siteid = "";
            if (!string.IsNullOrEmpty(Request.Form.Get("Site_Code")))
            {
                //siteid = Request.Form.Get("Site_Code");
                siteid = Site_Code.SelectedValue;
            }
            else
            {
                siteid = "";
            }
            siteid = Site_Code.SelectedValue;

            //if (Checkbox2.Checked == true)
            //{
                dt = v_CardToExecBLL.CardConetEXEC(TypeID.Value, siteid, cardstatus1.Value, addeddate1.Value, addeddate2.Value, activetime1.Value, activetime2.Value, initvalue.Value.Trim(), S_Point.Value.Trim(), E_Point.Value.Trim());
            //}
            //if (Checkbox3.Checked == true)
            //{
            //    dt = v_CardToExecBLL.CardConetEXEC(TypeID.Value, siteid, cardstatus1.Value, "", "", activetime1.Value, activetime2.Value, initvalue.Value.Trim(), S_Point.Value.Trim(), E_Point.Value.Trim());
            //}
            //if (Checkbox4.Checked == true)
            //{
            //    dt = v_CardToExecBLL.CardConetEXEC(TypeID.Value, "", "未激活", addeddate1.Value, addeddate2.Value, "", "", initvalue.Value.Trim(), S_Point.Value.Trim(), E_Point.Value.Trim());
            //}

            DataToExcel.CreateExcel(dt, DateTime.Now.ToString("yyyyMMddhhmmssfff"));
        }
    }

    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            Site_Code.Items.Clear();
            Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
            Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
        }
    }
}
