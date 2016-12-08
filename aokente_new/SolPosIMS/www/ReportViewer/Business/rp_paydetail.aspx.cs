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
using System.Collections.Generic;
using ZsdDotNetLibrary.Web;
using ZsdDotNetLibrary.Data;

public partial class ReportViewer_Business_rp_paydetail : System.Web.UI.Page
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
            tradetype.Items.Insert(0, new ListItem("全部记录", ""));
            tradetype.Items.Insert(1, new ListItem("平台充值", "0"));
            tradetype.Items.Insert(1, new ListItem("停车消费", "1"));
            tradetype.Items.Insert(2, new ListItem("无线充值", "2"));
            tradetype.Items.Insert(3, new ListItem("停车欠费", "3"));
            tradetype.Items.Insert(4, new ListItem("积分兑换", "4"));
            tradetype.Items.Insert(4, new ListItem("活动赠送", "5"));

            //InitListControlHelper.BindNormalTableToListControl(tradetype, "areacode", "areaname", "tb_area");

            tradeway.Items.Insert(0, new ListItem("全部记录", ""));
            tradeway.Items.Insert(1, new ListItem("未知来源", "0"));
            tradeway.Items.Insert(2, new ListItem("系统平台", "1"));
            tradeway.Items.Insert(3, new ListItem("手持终端", "2"));
            tradeway.Items.Insert(4, new ListItem("手机客户端", "3"));
            //InitListControlHelper.BindNormalTableToListControl(tradeway, "areacode", "areaname", "tb_area");
        }
    }
    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        if (tradetime_begin.Value == "" && tradetime_end.Value == "" && cbToday_in.Checked)
        {
            tradetime_begin.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            tradetime_end.Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }
        DataTable dt = GetTableData();
        if (dt == null || dt.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的记录,请重新选择!");
            return;
        }
        TableCell[] header = new TableCell[13];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 12;//设置跨越的列数
        header[0].Text = "财务流水记录</th></tr><tr>";
        //第二行 
        header[1].Text = "序 号";
        header[2].Text = "记录流水号";
        header[3].Text = "业务流水号";
        header[4].Text = "车牌号";
        header[5].Text = "发生金额";
        header[6].Text = "交易时间";
        header[7].Text = "交易类型";
        header[8].Text = "交易来源";
        header[9].Text = "交易前金额";
        header[10].Text = "交易后金额";
        header[11].Text = "操作员";
        header[12].Text = "详情";
        ExcelOperator.SetCellFontSize(header[0], 30);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        mergeCellNums.Add(1, 2);
        //mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "pay_paydetail" + DateTime.Now.ToString("yyMMddHHmmss") + ".xls";
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
            ExcelOperator.SetCellFontSize(e.Row.Cells[3], 20);
            ExcelOperator.SetCellFontColor(e.Row.Cells[3], System.Drawing.Color.Blue);
            ExcelOperator.SetCellFontColor(e.Row.Cells[4], System.Drawing.Color.Purple);
            ExcelOperator.SetCellFontColor(e.Row.Cells[8], System.Drawing.Color.OrangeRed);
            ExcelOperator.SetCellFontColor(e.Row.Cells[9], System.Drawing.Color.OrangeRed);
            ExcelOperator.SetCellWidth(e.Row.Cells[1], 160);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 10);
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
            //e.Row.Cells[
        }
    }
    /// <summary>
    /// 获取停车记录数据源
    /// </summary>
    /// <returns></returns>
    public DataTable GetTableData()
    {
        string strSql = @"SELECT     payid, businessid, carnum, amount, tradetime, 
                      CASE tradetype WHEN 0 THEN '平台充值' WHEN 1 THEN '停车消费' WHEN 2 THEN '无线充值' WHEN 3 THEN '停车欠费' WHEN 4 THEN '积分兑换' WHEN
                       5 THEN '活动赠送' WHEN 6 THEN '押金充值' END AS tradetypename,  
                      CASE tradeway WHEN 0 THEN '未知来源' WHEN 1 THEN '系统平台' WHEN 2 THEN '手持终端' WHEN 3 THEN '手机客户端' END AS tradewayname, 
                       beforemoney, aftermoney, operatorid,tradecomment FROM dbo.pay_paydetail WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(operatorid.Value.Trim()))
            strSql += " And operatorid ='" + operatorid.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(businessid.Value.Trim()))
            strSql += " And businessid ='" + businessid.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(CardSnr.Value.Trim()))
            strSql += " And CardSnr ='" + CardSnr.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(tradeway.Value))
            strSql += " And Mode =" + tradeway.Value.Trim();
        if (!string.IsNullOrEmpty(tradetype.Value))
            strSql += " And Mode =" + tradetype.Value.Trim();
        if (!string.IsNullOrEmpty(tradetime_begin.Value) && !string.IsNullOrEmpty(tradetime_end.Value))
            strSql += " And tradetime >='" + tradetime_begin.Value + "' And tradetime<='" + tradetime_end.Value + "'";
        DataTable dt = new DataTable();
        dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        return dt;
    }
}
