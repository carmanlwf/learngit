using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewSoftDotNetLibrary.Data;
using System.Data;

public partial class ReportViewer_Business_Rpt_CardChargeStatics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //InitListControlHelper.BindNormalTableToListControl(RankId, "RankName", "RankName", "MB_MemberRanks");
            //RankId.Items.Insert(0, new ListItem("全部", ""));
        }
    }
    public void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        string operid = operatorid.Value.Trim();
        string time1 = "";
        string time2 = "";
        switch (RadioButtonList1.SelectedValue)
        {
            case "查询本年":
                time1 = DateTime.Today.Year.ToString() + "-01-01" + " 00:00:00";
                time2 = DateTime.Today.Year.ToString() + "-12-31" + " 23:59:59";
                break;
            case "查询本月":
                //当前月份第一天   
                time1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd") + " 00:00:00";
                //当前月份最后一天   + " 23:59:59"
                time2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
                break;
            case "查询今天":
                time1 = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
                time2 = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
                break;
            case "自定义":
                time1 = !string.IsNullOrEmpty(begindate.Value.Trim()) ? begindate.Value.Trim() + " 00:00:00" : "";
                time2 = !string.IsNullOrEmpty(enddate.Value.Trim()) ? enddate.Value.Trim() + " 23:59:59" : "";
                break;

        }

        DataTable dt = GetDataTable(begindate.Value.Trim(), enddate.Value.Trim(), operatorid.Value.Trim());

        TableCell[] header = new TableCell[14];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 13;//设置跨越的列数
        header[0].Text = "操作员充值统计表</th></tr><tr>";

        //Select serialid,starttime,endtime, ZCCount,ZCMoney,KCount,KMoney,SumMoney,VipCount,VipAmount,operatorid,logtime from card_chargestatics
        //第二行 
        header[1].Text = "序号";
        header[2].Text = "记录编号";
        header[3].Text = "接班时间";
        header[4].Text = "交班时间";
        header[5].Text = "累计充值笔数";//</th>
        header[6].Text = "累计充值金额";
        header[7].Text = "累计退款笔数";
        header[8].Text = "累计退款金额";
        header[9].Text = "累计金额";
        header[10].Text = "充值笔数(会员)";
        header[11].Text = "充值金额(会员)";
        header[12].Text = "操作员编号";
        header[13].Text = "记录时间";
        ExcelOperator.SetCellFontSize(header[0], 50);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);



        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        //mergeCellNums.Add(0, 1);
        //mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "Rpt_CardChargeStatics" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[12], ExcelOperator.TEXT_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[2], ExcelOperator.TEXT_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[3], ExcelOperator.TEXT_NUMBER);
            ExcelOperator.SetCellWidth(e.Row.Cells[2], 150);
            ExcelOperator.SetCellWidth(e.Row.Cells[3], 150);
            //ExcelOperator.SetCellFontSize(e.Row.Cells[2], 20);
            //ExcelOperator.SetCellFontColor(e.Row.Cells[2], System.Drawing.Color.FromArgb(255, 255, 0, 0));


            ExcelOperator.SetCellWidth(e.Row.Cells[1], 200);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
            //e.Row.Cells[
        }
    }
    public DataTable GetDataTable(string starttime, string endtime, string operatorid)
    {
        string strSql = "";
        strSql = @"Select serialid,starttime,endtime, ZCCount,ZCMoney,KCount,KMoney,SumMoney,VipCount,VipAmount,operatorid,logtime from card_chargestatics Where 1 = 1";
        if (!string.IsNullOrEmpty(operatorid) && !string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
        {
            strSql += " And operid='" + operatorid + "' And logtime>='" + starttime + "' And logtime<='" + endtime + "'";
        }
        else
        {
            if (!string.IsNullOrEmpty(operatorid))
            {
                strSql += " And operatorid='" + operatorid + "'";
            }
            if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
            {
                strSql += " And logtime>='" + starttime + "' And logtime<='" + endtime + "'";
            }
        }
        //strSql += " GROUP BY card";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        return dt;
    }
}





