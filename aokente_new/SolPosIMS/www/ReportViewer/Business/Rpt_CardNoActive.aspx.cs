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

public partial class ReportViewer_Business_CardNoActive : System.Web.UI.Page
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

        DataTable dt = GetDataTable(begindate.Value.Trim(), enddate.Value.Trim());

        TableCell[] header = new TableCell[9];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 8;//设置跨越的列数
        header[0].Text = "未激活卡清单</th></tr><tr>";

        //Select card,typename,initvalue,balance,addeddate,sitename,areaname FROM v_CardNoActive
        //第二行 
        header[1].Text = "序号";
        header[2].Text = "卡号";
        header[3].Text = "卡片类型";
        header[4].Text = "初始金额";//</th>
        header[5].Text = "卡内余额";
        header[6].Text = "注册时间";;
        header[7].Text = "所属分店";
        header[8].Text = "所属区域";

        ExcelOperator.SetCellFontSize(header[0], 50);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);



        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        mergeCellNums.Add(0, 1);
        mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "v_CardNoActive" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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

            //ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[2], ExcelOperator.TEXT_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[2], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellWidth(e.Row.Cells[2], 100);
            ExcelOperator.SetCellFontSize(e.Row.Cells[2], 20);
            ExcelOperator.SetCellFontColor(e.Row.Cells[2], System.Drawing.Color.FromArgb(255, 255, 0, 0));


            ExcelOperator.SetCellWidth(e.Row.Cells[1], 100);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
            //e.Row.Cells[
        }
    }
    public DataTable GetDataTable(string timeStart, string timeEnd)
    {
        

        string areacode = "", strSQL = "";
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            areacode = Ims.PM.BLL.PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
            strSQL = "Select card,typename,initvalue,balance,addeddate,sitename,areaname FROM v_CardNoActive Where 1=1 And Statusname = '未激活' ";
        }
        else
            strSQL = "Select card,typename,initvalue,balance,addeddate,sitename,areaname FROM v_CardNoActive Where 1=1 And Statusname = '未激活'  and areacode ='" + areacode + "'";
    


        if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
            strSQL += "And addeddate >='" + timeStart + "' And addeddate <='" + timeEnd + "'";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSQL);
        return dt;
    }
}



