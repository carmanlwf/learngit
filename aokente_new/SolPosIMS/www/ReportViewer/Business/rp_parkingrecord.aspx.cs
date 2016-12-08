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
using ZsdDotNetLibrary.Data;
using System.Collections.Generic;

public partial class ReportViewer_Business_rp_parkingrecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,small") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            Mode.Items.Insert(0, new ListItem("全部", ""));
            Mode.Items.Insert(1, new ListItem("进场", "0"));
            Mode.Items.Insert(2, new ListItem("离场", "1"));

            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            Area_Code.Items.Insert(0, new ListItem("所有区域", ""));
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));

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
    protected void btnSubmit_ServerClick(object sender, EventArgs e)
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
        DataTable dt = GetTableData();
        if (dt == null || dt.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的记录,请重新选择!");
            return;
        }
        else
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["ts_parking"] = RtnTimeStr(dr["ts_parking"]);
            }
        }
        TableCell[] header = new TableCell[17];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 16;//设置跨越的列数
        header[0].Text = "停车明细清单</th></tr><tr>";
        //第二行 
        header[1].Text = "序 号";
        header[2].Text = "流水号";
        header[3].Text = "终端机号";
        header[4].Text = "车牌号";
        header[5].Text = "车辆类型";
        header[6].Text = "车位号";
        header[7].Text = "收费员编号";
        header[8].Text = "押金充值";
        header[9].Text = "应缴金额";
        header[10].Text = "实缴金额";
        header[11].Text = "进场/离场";
        header[12].Text = "进场时间";
        header[13].Text = "离场时间";
        header[14].Text = "所在路段";
        header[15].Text = "所在区域";
        header[16].Text = "累计停车时长";
        ExcelOperator.SetCellFontSize(header[0], 30);
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
            ExcelOperator.SetCellFontColor(e.Row.Cells[3], System.Drawing.Color.Blue);
            ExcelOperator.SetCellFontColor(e.Row.Cells[4], System.Drawing.Color.Purple);
            ExcelOperator.SetCellFontColor(e.Row.Cells[7], System.Drawing.Color.OrangeRed);
            ExcelOperator.SetCellFontColor(e.Row.Cells[8], System.Drawing.Color.OrangeRed);
            ExcelOperator.SetCellFontColor(e.Row.Cells[9], System.Drawing.Color.OrangeRed);
            ExcelOperator.SetCellWidth(e.Row.Cells[1], 160);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 10);
            ExcelOperator.SetCellFontSize(e.Row.Cells[6], 20);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[1], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[2], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[3], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[4], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[5], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[6], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[7], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[8], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[9], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[10], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[11], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[12], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[13], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[14], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[15], ExcelOperator.HorizAlignMode.Center);
            //e.Row.Cells[
        }
    }
    /// <summary>
    /// 获取停车记录数据源
    /// </summary>
    /// <returns></returns>
    public DataTable GetTableData()
    {
        string strSql = @"SELECT [CredenceSnr],[PosSnr],[CardSnr],Case [CardType] When 1 then '小车' When 2 then '大车' end as CardType,[BackByte],[UserID],[giving],[Money],[RealMoney],[CarStatus],[StartTime],[EndTime],[sitename],[areaname],CAST([sumMins] as varchar(10)) as ts_parking FROM [v_pos_transaction] WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(possnr.Value.Trim()))
            strSql += " And PosSnr ='" + possnr.Value.Trim()+"'";
        if (!string.IsNullOrEmpty(CardSnr.Value.Trim()))
            strSql += " And CardSnr ='" + CardSnr.Value.Trim()+"'";
        if (!string.IsNullOrEmpty(Mode.Value))
            strSql += " And Mode =" + Mode.Value.Trim();
        if (!string.IsNullOrEmpty(Mode.Value))
            strSql += " And Mode =" + Mode.Value.Trim();
        if (!string.IsNullOrEmpty(Area_Code.SelectedValue.Trim()))
            strSql += " And areacode ='" + Area_Code.SelectedValue.Trim() + "'";
        if (!string.IsNullOrEmpty(Site_Code.SelectedValue.Trim()))
            strSql += " And Site_Code ='" + Site_Code.SelectedValue.Trim() + "'";
        if (!string.IsNullOrEmpty(start_date_begin.Value) && !string.IsNullOrEmpty(start_date_end.Value))
            strSql +=" And StartTime >='"+start_date_begin.Value+"' And StartTime<='"+start_date_end.Value+"'";
        if (!string.IsNullOrEmpty(end_date_begin.Value) && !string.IsNullOrEmpty(start_date_end.Value))
            strSql +=" And EndTIme >='"+end_date_begin.Value+"' And EndTime <='"+end_date_end.Value+"'";
        DataTable dt = new DataTable();
        dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        return dt;
    }
}
