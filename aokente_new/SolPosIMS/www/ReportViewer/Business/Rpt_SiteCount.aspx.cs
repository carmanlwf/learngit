using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NewSoftDotNetLibrary.Data;

public partial class ReportViewer_Business_Rpt_SiteCount : System.Web.UI.Page
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
        //tb_Card o = new tb_Card();
        //o.addeddate1 = begindate.Value;
        //o.addeddate2 = begindate.Value;
        //o.Status = 1;//normal
        //List<tb_Card> c_list = RptMemberCardBLL.GetPagedObjects(0, "", o);

        //DataTable dt = RptHelper.ToDataTable(c_list, typeof(RptMemberCard));
        //ExcelHelper.ExportExcel(dt, typeof(RptMemberCard), "会员卡清单");

        DataTable dt = GetDataTable(begindate.Value.Trim(), enddate.Value.Trim(),possnr.Value.Trim(),sitename.Value.Trim());

        TableCell[] header = new TableCell[10];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 9;//设置跨越的列数
        header[0].Text = "商户消费统计表</th></tr><tr>";

        //Select card,typename,initvalue,balance,addeddate,sitename,areaname FROM v_CardNoActive
        //第二行 
        header[1].Text = "序号";
        header[2].Text = "商户名称";
        header[3].Text = "终端设备号";
        header[4].Text = "累计消费笔数";//</th>
        header[5].Text = "累计充值笔数";
        header[6].Text = "累计撤单笔数" ;
        header[7].Text = "累计消费金额";
        header[8].Text = "累计充值金额";
        header[9].Text = "累计撤单金额";
        ExcelOperator.SetCellFontSize(header[0], 50);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);



        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        //mergeCellNums.Add(0, 1);
        //mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "Rpt_SiteCount" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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

            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[2], ExcelOperator.TEXT_NUMBER);
            ExcelOperator.SetCellWidth(e.Row.Cells[2], 100);
            ExcelOperator.SetCellFontSize(e.Row.Cells[2], 20);
            ExcelOperator.SetCellFontColor(e.Row.Cells[2], System.Drawing.Color.FromArgb(255, 255, 0, 0));


            ExcelOperator.SetCellWidth(e.Row.Cells[1], 200);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
            //e.Row.Cells[
        }
    }
    public DataTable GetDataTable(string timeStart, string timeEnd,string machineid,string sitename)
    {
        string StrSql = @"
                                  SELECT y.sitename,x.PosSnr,x.XFTJ_Count,x.CZTJ_Count,x.CDTJ_Count,x.XFTJ_Amount,x.CZTJ_Amount,x.CDTJ_Amount FROM (SELECT Possnr, ISNULL(SUM(case Mode when 1 then 1 else 0 end),0) as XFTJ_Count,
		 ISNULL(SUM(case Mode when 11 then 1 else 0 end),0) as CZTJ_Count, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then 1 else 0 end),0) as CDTJ_Count, 
		 ISNULL(SUM(case Mode when 1 then [Money] else 0 end),0) as XFTJ_Amount,
		 ISNULL(SUM(case Mode when 11 then [Money] else 0 end),0) as CZTJ_Amount, 
		 ISNULL(SUM(case when Mode = 1 And RecordType = 2 then [Money] else 0 end),0) as CDTJ_Amount
  FROM tb_POS_Transaction Where 1=1 ";

        if (!string.IsNullOrEmpty(machineid))
            StrSql += "And Possnr ='" + machineid + "'";
        if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
            StrSql += "And Datetime >= Replace('" + timeStart + "','-','/') And Datetime <= Replace('" + timeEnd + "','-','/')";
        if (!string.IsNullOrEmpty(sitename))
            StrSql += "And sitename = '" + sitename + "'";
        StrSql += " Group By Possnr) as x ";
        StrSql += "LEFT JOIN tb_Site as y ON x.PosSnr = y.machineid";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
        return dt;
    }
}




