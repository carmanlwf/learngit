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
using NewSoftDotNetLibrary.Web;
using System.Collections.Generic;
using NewSoftDotNetLibrary.Data;
using Ims.PM.BLL;

public partial class ReportViewer_Business_Rpt_PosTransDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area", "", "areacode = '" + areacode + "'", "");

                InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode = '" + areacode + "'", "");
                Site_Code.Items.Insert(0, new ListItem("所有分店", ""));

            }
            else
            {
                InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
                Area_Code.Items.Insert(0, new ListItem("所有区域", ""));
                // InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site");
                Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
            }
        }
    }
    protected void Area_Code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Area_Code.SelectedValue == "")
        {
            Site_Code.Items.Clear();
            Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
        }
        else
        {
            InitListControlHelper.BindNormalTableToListControl(Site_Code, "id", "sitename", "tb_site", "", "areacode='" + Area_Code.SelectedValue + "'", "");
            Site_Code.Items.Insert(0, new ListItem("所有分店", ""));
        }
    }
     public void btnSubmit_ServerClick(object sender, EventArgs e)
    {

        DataTable dt = GetDataTable(begindate.Value.Trim(), enddate.Value.Trim(), BatchSnr.Value.Trim(), Magcard.Value.Trim(), PosSnr.Value.Trim(),Site_Code.SelectedValue);

        TableCell[] header = new TableCell[12];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 11;//设置跨越的列数
        header[0].Text = "终端交易记录</th></tr><tr>";

        //select possnr,batchsnr,credencesnr,magcard,userid,[money],[datetime],modename,recordtypename,sitename,Regionid from v_pos_transaction
        //第二行 
        header[1].Text = "序号";
        header[2].Text = "设备号";
        header[3].Text = "批次号";
        header[4].Text = "交易凭证号";
        header[5].Text = "交易卡号";//</th>
        header[6].Text = "用户编号";
        header[7].Text = "交易金额";
        header[8].Text = "交易时间";
        header[9].Text = "交易类型";
        header[10].Text = "记录类型";
        header[11].Text = "分店名称";

        ExcelOperator.SetCellFontSize(header[0], 50);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);



        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        //mergeCellNums.Add(0, 1);
        mergeCellNums.Add(1, 2);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "v_pos_transaction" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
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
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[5], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellWidth(e.Row.Cells[2], 100);
            ExcelOperator.SetCellFontSize(e.Row.Cells[2], 20);
            ExcelOperator.SetCellFontColor(e.Row.Cells[2], System.Drawing.Color.FromArgb(255, 255, 0, 0));
            ExcelOperator.SetCellWidth(e.Row.Cells[1], 100);
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
            //e.Row.Cells[
        }
    }
    public DataTable GetDataTable(string timeStart, string timeEnd,string batchNo,string card,string possnr,string sitecode)
    {
        

        string areacode = "", strSQL = ""; ;
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            areacode = Ims.PM.BLL.PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
            strSQL = "Select possnr,batchsnr,credencesnr,magcard,userid,[money],[datetime],modename,recordtypename,sitename from v_pos_transaction Where 1=1 and areacode ='" + areacode + "'";
        }
        else
            strSQL =  "Select possnr,batchsnr,credencesnr,magcard,userid,[money],[datetime],modename,recordtypename,sitename from v_pos_transaction Where 1=1 ";
    
        if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
            strSQL += " And datetime >='" + timeStart + "' And datetime <='" + timeEnd + "'";
        if (!string.IsNullOrEmpty(batchNo))
            strSQL += " And batchsnr='" + batchNo + "'";
        if (!string.IsNullOrEmpty(card))
            strSQL += " And magcard='" + card + "'";
        if (!string.IsNullOrEmpty(possnr))
            strSQL += " And possnr='" + possnr + "'";
        if (!string.IsNullOrEmpty(sitecode))
            strSQL += " And regionid='" + sitecode + "'";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSQL);
        return dt;
    }
}
