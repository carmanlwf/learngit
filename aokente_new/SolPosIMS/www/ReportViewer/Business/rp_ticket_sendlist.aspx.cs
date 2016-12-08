using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZsdDotNetLibrary.Web;
using System.Data;
using ZsdDotNetLibrary.Data;

public partial class ReportViewer_Business_rp_ticket_sendlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller,small") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }

    }

    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        if (addeddate1.Value == "" && addeddate2.Value == "")
        {
            addeddate1.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            addeddate2.Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
        }

        DataTable dt = GetTableData();
        if (dt == null || dt.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的记录,请重新选择!");
            return;
        }

        TableCell[] header = new TableCell[9];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 8;//设置跨越的列数
        header[0].Text = "领票明细清单</th></tr><tr>";
        //第二行 				
        header[1].Text = "序 号";
        header[2].Text = "流水号";
        header[3].Text = "领取人ID";
        header[4].Text = "领取人";
        header[5].Text = "操作人员";
        header[6].Text = "领取金额";
        header[7].Text = "领取日期";
        header[8].Text = "备注";


        ExcelOperator.SetCellFontSize(header[0], 30);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        mergeCellNums.Add(1, 2);
        //mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "BillSendList" + DateTime.Now.ToString("yyMMddHHmmss") + ".xls";
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
            ExcelOperator.SetCellFontColor(e.Row.Cells[1], System.Drawing.Color.Blue);
            //ExcelOperator.SetCellFontColor(e.Row.Cells[4], System.Drawing.Color.Purple);
            ExcelOperator.SetCellFontColor(e.Row.Cells[5], System.Drawing.Color.Red);
            //ExcelOperator.SetCellFontColor(e.Row.Cells[9], System.Drawing.Color.OrangeRed);
            ExcelOperator.SetCellWidth(e.Row.Cells[1], 160);
            ExcelOperator.SetCellWidth(e.Row.Cells[7], 500);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[1], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[2], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[3], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[4], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[5], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[6], ExcelOperator.HorizAlignMode.Center);
            ExcelOperator.SetCellHorizontalAlignMode(e.Row.Cells[7], ExcelOperator.HorizAlignMode.Center);
        }
    }

    /// <summary>
    /// 获取停车记录数据源
    /// </summary>
    /// <returns></returns>
    public DataTable GetTableData()
    {
        string strSql = @"select tid,receiverid,receivername,agentid,amount,addeddate,memo from v_ticket_sendlist WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(receiverid.Value))
            strSql += " And receiverid ='" + receiverid.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(receivername.Value))
            strSql += " And receivername ='" + receivername.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(agentid.Value))
            strSql += " And agentid ='" + agentid.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(addeddate1.Value) && !string.IsNullOrEmpty(addeddate2.Value))
            strSql += " And addeddate >= '" + addeddate1.Value.Trim() + "' and addeddate <= '" + addeddate2.Value.Trim() + "'";
       
        DataTable dt = new DataTable();
        dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        return dt;
    }

}
