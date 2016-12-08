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
using NewSoftDotNetLibrary.Data;

public partial class ReportViewer_Business_Rpt_SysLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            type.Items.Insert(0, new ListItem("全部", ""));
            type.Items.Insert(1, new ListItem("平台充值", "平台充值"));
            type.Items.Insert(2, new ListItem("充值规则", "充值规则"));
            type.Items.Insert(3, new ListItem("积分规则", "积分规则"));
            type.Items.Insert(4, new ListItem("批量发卡", "批量发卡"));
            type.Items.Insert(5, new ListItem("密码重设", "密码重设"));
            type.Items.Insert(6, new ListItem("在线转账", "在线转账"));
            type.Items.Insert(7, new ListItem("卡片挂失", "卡片挂失"));
            type.Items.Insert(8, new ListItem("卡片解挂", "卡片解挂"));
            type.Items.Insert(9, new ListItem("购物扣款", "购物扣款"));
            type.Items.Insert(10, new ListItem("会员销卡", "会员销卡"));
            type.Items.Insert(11, new ListItem("卡片激活", "卡片激活"));
            type.Items.Insert(12, new ListItem("删除操作", "删除操作"));
        }
    }

    public void btnSubmit_ServerClick(object sender, EventArgs e)
    {

        DataTable dt = GetDataTable(begindate.Value.Trim(), enddate.Value.Trim(), operater.Value.Trim(), type.Value.Trim());

        TableCell[] header = new TableCell[7];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 6;//设置跨越的列数
        header[0].Text = "系统日志记录</th></tr><tr>";

        //select logid,operater,operate_date,[type],logmsg from tb_Log
        //第二行 
        header[1].Text = "序号";
        header[2].Text = "事件编号";
        header[3].Text = "操作员";
        header[4].Text = "操作时间";
        header[5].Text = "操作类型";//</th>
        header[6].Text = "记录详情";

        ExcelOperator.SetCellFontSize(header[0], 50);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);



        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        //mergeCellNums.Add(0, 1);
        mergeCellNums.Add(1, 2);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "tb_Log" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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
            ExcelOperator.SetCellWidth(e.Row.Cells[5], 500);
            ExcelOperator.SetCellFontSize(e.Row.Cells[2], 20);
            ExcelOperator.SetCellFontColor(e.Row.Cells[2], System.Drawing.Color.FromArgb(255, 255, 0, 0));
            ExcelOperator.SetCellWidth(e.Row.Cells[1], 180);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
            //e.Row.Cells[
        }
    }
    public DataTable GetDataTable(string timeStart, string timeEnd, string operid, string logtype)
    {
        string strSQL = "Select logid,operater,operate_date,[type],logmsg from tb_Log Where 1=1";
        if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
            strSQL += " And operate_date >='" + timeStart + "' And operate_date <='" + timeEnd + "'";
        if (!string.IsNullOrEmpty(operid))
            strSQL += " And operater='" + operid + "'";
        if (!string.IsNullOrEmpty(logtype))
            strSQL += " And type='" + logtype + "'";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSQL);
        return dt;
    }
}

