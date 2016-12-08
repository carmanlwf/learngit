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
using Ims.Card.Model;
using System.Collections.Generic;
using NewSoftDotNetLibrary.Data;
using Ims.Site.Model;
using Ims.Site.BLL;
using Ims.Card.BLL;
using Ims.PM.BLL;
using ZsdDotNetLibrary.Web;

public partial class ReportViewer_Business_Rpt_MemberCardList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                //string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                //InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area", "", "areacode = '" + areacode + "'", "");

                InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode = '" + Area_Code.SelectedValue + "'", "");
                Site_Code.Items.Insert(0, new ListItem("所有路段", ""));

            }
            else
            {
                InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
                Area_Code.Items.Insert(0, new ListItem("所有区域", ""));
                // InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site");
                Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
            }
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
    public void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        if (start_date_begin.Value == "" && start_date_end.Value == "" && cbToday_in.Checked)
        {
            start_date_begin.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            start_date_end.Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }
        if (end_date_begin.Value == "" && end_date_end.Value == "" && cbToday_out.Checked)
        {
            end_date_begin.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            end_date_end.Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }
        DataTable dt = GetDataTable(start_date_begin.Value.Trim(), start_date_end.Value.Trim(),end_date_begin.Value,end_date_end.Value,Area_Code.SelectedItem.Text, Site_Code.SelectedItem.Text, possnr.Value, Mode.Value, CardSnr.Value);
        string area=Area_Code.Text;
        string site = Site_Code.Text;
        if (Area_Code.SelectedItem.Text != "所有区域" && Site_Code.SelectedItem.Text == "所有路段")
        {
            WebClientHelper.DoClientMsgBox("请选择所属路段!");
            return;
        }
        //DataTable dt = RptHelper.ToDataTable(c_list, typeof(v_pos_transaction));
      

        //DataTable ds = GetDataTable(begindate.Value.Trim(), enddate.Value.Trim());

        TableCell[] header = new TableCell[15];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 14;//设置跨越的列数
        header[0].Text = "停车明细清单</th></tr><tr>";
        //第二行 
        header[1].Text = "序号";
        header[2].Text = "流水号";
        header[3].Text = "终端机号";
        header[4].Text = "车牌号";
        header[5].Text = "所在路段";
        header[6].Text = "操作员号";
        //header[6].Width = 50;
        header[7].Text = "消费金额"; 
        header[8].Text = "交易类型";
        header[9].Text = "进场时间"; 
        header[10].Text = "离场时间";
        header[11].Text = "累积停车时长";
        header[12].Text = "缴费时间";
        header[13].Text = "交易前";
        header[14].Text = "交易后";
        //ExcelOperator.SetCellWidth(header[0],50);
        ExcelOperator.SetCellFontSize(header[0], 50);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        mergeCellNums.Add(1, 2);
        //mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "ParkingRecords" + DateTime.Now.ToString("yyMMddHHmmss") + ".xls";
        ExcelOperator.DataTable2Excel(dt, header, RowBoundEvent, strDefaultFileName, mergeCellNums, 0, true);


        DivCover.Style.Add("display", "none");
        Waiting.Style.Add("display", "none");


    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected static void dgExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[2].Attributes.Add("style", "vnd.ms-excel.numberformat:@"); //第二列用文本的模式现实数字，这样可以现实00012

            //e.Row.Cells[2].Style.Add("color", "#ff0000");

            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[1], ExcelOperator.TEXT_NUMBER);
            //ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[5], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellWidth(e.Row.Cells[5], 70);
            ExcelOperator.SetCellFontSize(e.Row.Cells[2], 20);
            ExcelOperator.SetCellFontColor(e.Row.Cells[2], System.Drawing.Color.FromArgb(255, 255, 0, 0));
            ExcelOperator.SetCellWidth(e.Row.Cells[1], 160);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
            ExcelOperator.SetCellFontSize(e.Row.Cells[6], 70);
            //e.Row.Cells[
        }
    }
    public DataTable GetDataTable(string timeStart, string timeEnd,string jiestrart,string jieend,string area, string site, string possnr, string Mode, string CardSnr)
    {
        string areacode = "", strSQL = "";
        strSQL = "Select CredenceSnr as 流水号,PosSnr as 终端机号,Magcard as 车牌号,sitename as 所在路段,UserID as 操作员号,Money as 消费金额,CarStatus as 交易类型,StartTime as 进场时间,EndTime as 离场时间,sumMins 累积停车时长,[Datetime] as 缴费时间,BeforeBalance as 交易前,AfterBalance as 交易后 from v_pos_transaction where 1=1";
        //if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        //{
        //    //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
        //    areacode = Ims.PM.BLL.PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
        //    strSQL = "Select CredenceSnr as 流水号,PosSnr as 终端机号,Magcard as 车牌号,sitename as 所在路段,UserID as 操作员号,Money as 消费金额,CarStatus as 交易类型,StartTime as 进场时间,EndTime as 离场时间,sumMins 累积停车时长,[Datetime] as 缴费时间,BeforeBalance as 交易前,AfterBalance as 交易后 from v_pos_transaction";
        //}
        if (!string.IsNullOrEmpty(timeStart))
        {
            strSQL += "And StartTime>='" + timeStart + "'";
        }
        if (!string.IsNullOrEmpty(timeEnd)) {
            strSQL += "And StartTime<='" + timeEnd + "'";
        }
        if (!string.IsNullOrEmpty(jiestrart)) {
            strSQL += "And EndTime>='" + jiestrart + "'";
        }
        if (!string.IsNullOrEmpty(jieend))
        {
            strSQL += "And EndTime<='" + jieend + "'";
        }
        if(!string.IsNullOrEmpty(possnr)){
            strSQL += "And PosSnr='" + possnr + "'";
        }
        if (area != "所有区域" && site != "所有路段")
            strSQL += "And sitename='" + site + "'";
        //else
        //    strSQL = "Select transid,card,cardtype,chargetype,amount,gift,rulename,logtime,chargeway,operid from v_card_chargelist_area Where 1=1  and areacode ='" + areacode + "'";
        if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
            strSQL += " And StartTime >='" + timeStart + "' And EndTime <='" + timeEnd + "'";
        if (!string.IsNullOrEmpty(Mode)) {
            strSQL += "And Mode='" + Mode + "'";
        }
        if (!string.IsNullOrEmpty(CardSnr)) {
            strSQL += "And CardSnr='" + CardSnr + "'";
        }
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSQL);
        return dt;
    }
}


