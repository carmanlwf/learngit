﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ims.Card.Model;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Card.BLL;
using Ims.Log.Model;
using Ims.Log.BLL;
using System.IO;
using Ims.PM.BLL;
public partial class Sysem_Cardchargelist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel,manager,small,statistician") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (Ims.Main.ImsInfo.UserIsInRole("channel"))
        {
            SumPan.Style.Value = "display:none";
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if(!IsPostBack){ 
            GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
            //Chargetype.Items.Insert(0, new ListItem("全部", ""));
            //Chargetype.Items.Insert(1, new ListItem("充值", "充值"));
            //Chargetype.Items.Insert(2, new ListItem("扣款", "扣款"));
            //Chargetype.Items.Insert(2, new ListItem("充值回滚", "充值回滚"));
            //Chargetype.Items.Insert(2, new ListItem("扣款回滚", "充值回滚"));

            //InitListControlHelper.BindNormalTableToListControl(cardtype, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");
             //chargeway.Items.Insert(0, new ListItem("全部", ""));
             //chargeway.Items.Insert(1, new ListItem("在线", "在线"));
             //chargeway.Items.Insert(1, new ListItem("终端", "终端"));
             BindStaticsData();
        }


    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        string time1 = !string.IsNullOrEmpty(OperateDate1.Value.Trim()) ? OperateDate1.Value.Trim() : DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
        string time2 = !string.IsNullOrEmpty(OperateDate2.Value.Trim()) ? OperateDate2.Value.Trim() : DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        v_card_chargelist_area o = ParameterBindHelper.BindParameterToObject(typeof(v_card_chargelist_area), BindParameterUsage.OpQuery) as v_card_chargelist_area;
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            o.areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        }
        o.OperateDate1 = time1; OperateDate1.Value = time1;
        o.OperateDate2 = time2; OperateDate2.Value = time2;
        o.flag = true; 
        e.InputParameters[0] = o;
    }
    protected void Button3_ServerClick(object sender, EventArgs e)
    {
        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            Label1.Text = "0";
            Label2.Text = "0";
            Label3.Text = "0";
            Label4.Text = "0";
            WebClientHelper.DoClientMsgBox("没有满足条件的充值信息!");
        }

        BindStaticsData();
    }
    public void BindStaticsData()
    {
        string opid = string.IsNullOrEmpty(operid.Value.ToString().Trim()) ? "" : operid.Value.ToString().Trim();
        //string ctype = string.IsNullOrEmpty(cardtype.Value.ToString().Trim()) ? "" : cardtype.Value.ToString().Trim();
        string card = string.IsNullOrEmpty(Card.Value.ToString().Trim()) ? "" : Card.Value.ToString().Trim();
        //string charge_type = string.IsNullOrEmpty(Chargetype.Value.ToString().Trim()) ? "" : Chargetype.Value.ToString().Trim();
        string time1 = !string.IsNullOrEmpty(OperateDate1.Value.Trim()) ? OperateDate1.Value.Trim() : DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
        string time2 = !string.IsNullOrEmpty(OperateDate1.Value.Trim()) ? OperateDate2.Value.Trim() : DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        DataTable dt = CardChargeListBLL.HavetimeCountCardChargeList(card, time1, time2, opid, "", "");
        if (dt != null && dt.Rows.Count > 0)
        {
            Label1.Text = dt.Rows[0]["am"].ToString();
            Label2.Text = dt.Rows[0]["charge_sum"].ToString();
            Label3.Text = dt.Rows[0]["cancel_sum"].ToString();
            Label4.Text = (decimal.Parse(dt.Rows[0]["charge_sum"].ToString()) - decimal.Parse(dt.Rows[0]["cancel_sum"].ToString())).ToString();
        }
        else
        {
            Label1.Text = "0";
            Label2.Text = "0";
            Label3.Text = "0";
            Label4.Text = "0";
        }



    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int n = 0;
        int count = 0;
        int sum = 0;
        if (this.GridView1.Rows.Count > 0)
        {
            card_chargelist o = new card_chargelist();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox ck = GridView1.Rows[i].Cells[0].FindControl("CheckBox1") as CheckBox;
                if (ck.Checked)
                {
                    string id = (this.GridView1.Rows[i].Cells[0].FindControl("Label1") as Label).Text;
                    o.transId = id;
                    int deletesum =
                        CardChargeListBLL.DeleteObject(o);

                    if (deletesum > 0)
                    {
                        count++;
                    }
                    else
                    {
                        sum++;
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

            }
            else
            {
                if (count > 0)
                {

                    //写入日志
                    tb_Log log = new tb_Log();
                    log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    log.operater = Ims.Main.ImsInfo.CurrentUserId;
                    //log.operater = "admin";
                    log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    log.type = "删除操作";
                    log.logmsg = log.operater + "  对充值记录进行删除操作,成功删除数据" + count + "条记录!";
                    LogHelperBLL.InsertObject(log);

                    GridView1.DataSourceID = "ObjectDataSource1";
                    GridView1.PageIndex = 0;
                    GridView1.DataBind();

                    WebClientHelper.DoClientMsgBox("成功删除" + count + "条记录!");
                }
                else
                {
                    WebClientHelper.DoClientMsgBox("删除失败,请重试!");
                }
            }
        }
    }

}

