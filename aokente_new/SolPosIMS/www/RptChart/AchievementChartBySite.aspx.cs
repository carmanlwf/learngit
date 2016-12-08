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
using ZsdDotNetLibrary.Web.BindParameter;
using Ims.Site.Model;
using System.Collections.Generic;
using Ims.Site.BLL;

public partial class RptChart_AchievementChartBySite : System.Web.UI.Page
{
    public decimal amount_receivable = 0;
    public decimal giving_amount = 0;
    public decimal Balanceb = 0;
    public decimal amount = 0;
    public decimal ReturnMoney = 0;
    public decimal Totality = 0;
    public int num = 0;
    public decimal amount_real = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller,channel,small") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        GridViewHelper.InitDefaultGridViewEvent(GridView1, ObjectDataSource1);
        if (!Page.IsPostBack)
        {
            searchDay.Value = DateTime.Now.Date.ToString("yyyy-MM-dd");
            addeddate_begin.Value = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            addeddate_end.Value = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
            dateso();
        }
       
    }
    public void dateso()
    {
        if (GridView1 != null && GridView1.Rows.Count > 0)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                amount_receivable += decimal.Round(Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text), 2);
                giving_amount += decimal.Round(Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text), 2);
                Balanceb += decimal.Round(Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text), 2);
                amount += decimal.Round(Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text), 2);
                ReturnMoney += decimal.Round(Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text), 2);
                amount_real += decimal.Round(Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text), 2);
                Totality += decimal.Round(Convert.ToDecimal(GridView1.Rows[i].Cells[10].Text), 2);
                num += Convert.ToInt32(GridView1.Rows[i].Cells[9].Text);
            }
        }
    }


    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

        SP_CalcRoadSectionsFeat o = ParameterBindHelper.BindParameterToObject(typeof(SP_CalcRoadSectionsFeat), BindParameterUsage.OpQuery) as SP_CalcRoadSectionsFeat;
        if (!string.IsNullOrEmpty(operatorid.Value.Trim()) && operatorid.Value != "请输入路段编号")
            o.siteids = operatorid.Value.Trim();
        else
            o.siteids = AchievementChartBySiteBLL.GetSites();//获取所有路段
        o.startTime = addeddate_begin.Value.Trim();
        o.endTime = addeddate_end.Value.Trim();
        e.InputParameters[0] = o;
    }
    protected void btnDay_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(searchDay.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("请选择要查看的日期!");
            return;
        }
        DateTime day_search = DateTime.Parse(searchDay.Value);
        addeddate_begin.Value = day_search.ToString("yyyy-MM-dd 00:00:00");
        addeddate_end.Value = day_search.ToString("yyyy-MM-dd 23:59:59");
        btnSearch_ServerClick(this, null);
    }
    protected void btnMonth_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(searchDay.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("请选择要查看的日期!");
            return;
        }
        DateTime day_search = DateTime.Parse(searchDay.Value);
        int day = DateTime.DaysInMonth(day_search.Year, day_search.Month);
        DateTime day_last = new DateTime(day_search.Year, day_search.Month, day);
        addeddate_begin.Value = day_search.ToString("yyyy-MM-01 00:00:00");
        addeddate_end.Value = day_last.ToString("yyyy-MM-dd 23:59:59");
        btnSearch_ServerClick(this, null);
    }
    protected void btnYear_ServerClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(searchDay.Value.Trim()))
        {
            WebClientHelper.DoClientMsgBox("请选择要查看的日期!");
            return;
        }
        DateTime day_search = DateTime.Parse(searchDay.Value);
        addeddate_begin.Value = day_search.ToString("yyyy-01-01 00:00:00");
        addeddate_end.Value = day_search.ToString("yyyy-12-31 23:59:59");
        btnSearch_ServerClick(this, null);
    }
    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {

        GridView1.DataSourceID = "ObjectDataSource1";
        GridView1.PageIndex = 0;
        GridView1.DataBind();
        if (GridView1.Rows.Count <= 0)
        {
            WebClientHelper.DoClientMsgBox("没有满足条件的统计信息!");
        }
        dateso();
    }


    protected void btnExport_ServerClick(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count <= 0)
            WebClientHelper.DoClientMsgBox("没有数据可以导出!");

        DataTable dt = new DataTable();

        dt.Columns.Add("序号", Type.GetType("System.Int32"));
        for (int i = 1; i < GridView1.Columns.Count; ++i)
            dt.Columns.Add(GridView1.Columns[i].HeaderText);

        for (int i = 0; i < GridView1.Rows.Count; ++i)
        {
            DataRow dr = dt.NewRow();
            for (int j = 0; j < GridView1.Columns.Count; ++j)
                if (0 == j)
                    dr[j] = i + 1;
                else
                    dr[j] = GridView1.Rows[i].Cells[j].Text.Trim();

            dt.Rows.Add(dr);

        }

        dateso();
        DataRow dr1 = dt.NewRow();
        dr1[2] = "合计";
        dr1[3] = amount_receivable;
        dr1[4] = giving_amount;
        dr1[5] = Balanceb;
        dr1[6] = amount;
        dr1[7] = ReturnMoney;
        dr1[8] = amount_real;
        dr1[9] = num;
        dr1[10] = Totality;

        dt.Rows.Add(dr1);

        TableCell[] header = new TableCell[12];
        for (int i = 0; i < header.Length; ++i)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 11;//设置跨越的列数
        header[0].Text = "路段业绩明细清单</th></tr><tr>";
        //第二行 
        header[1].Text = "序 号";
        header[2].Text = "路段编号";
        header[3].Text = "路段名称";
        header[4].Text = "应收总额";
        header[5].Text = "押金总额";
        header[6].Text = "欠缴总额";
        header[7].Text = "无线充值总额";
        header[8].Text = "返还押金总额";
        header[9].Text = "出场补交总额";
        header[10].Text = "入场车辆";
        header[11].Text = "实收现金总额";

        ExcelOperator.SetCellFontSize(header[0], 30);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        mergeCellNums.Add(0, 2);
        //mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "roadfinance" + DateTime.Now.ToString("yyMMddHHmmss") + ".xls";
        ExcelOperator.DataTable2Excel(dt, header, RowBoundEvent, strDefaultFileName, mergeCellNums, 0, true);
    }


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
            ExcelOperator.SetCellWidth(e.Row.Cells[1], 200);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
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


            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[3], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[4], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[5], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[6], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[7], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[8], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[10], ExcelOperator.NUMBER_NUMBER);

            //e.Row.Cells[
        }
    }
}

