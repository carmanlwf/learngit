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

public partial class ReportViewer_rp_CardExport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////权限验证
        if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,seller,small") == "")
        {
            Response.Redirect("../Unauthorized.aspx");
        }
        if (!Page.IsPostBack)
        {
            InitListControlHelper.BindNormalTableToListControl(Area_Code, "areacode", "areaname", "tb_area");
            Area_Code.Items.Insert(0, new ListItem("全部", ""));
            Site_Code.Items.Insert(0, new ListItem("所有路段", ""));
            Status.Items.Insert(0, new ListItem("正常", "1"));
            Status.Items.Insert(1, new ListItem("挂失", "2"));
            Status.Items.Insert(2, new ListItem("注销", "3"));
            Status.Items.Insert(3, new ListItem("补卡", "4"));
            Status.Items.Insert(4, new ListItem("全部", ""));

            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                Area_Code.Visible = false;
                Site_Code.Visible = false;
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
 
        TableCell[] header = new TableCell[12];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 11;//设置跨越的列数
        header[0].Text = "账户明细清单</th></tr><tr>";
        //第二行 
        header[1].Text = "序 号";
        header[2].Text = "车牌号";
        header[3].Text = "姓名";
        header[4].Text = "性别";
        header[5].Text = "类型";
        header[6].Text = "账户余额";
        header[7].Text = "创建时间";
        header[8].Text = "上次消费";
        header[9].Text = "联系电话";
        header[10].Text = "账户状态";
        header[11].Text = "是否有效";
       

        ExcelOperator.SetCellFontSize(header[0], 30);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);

        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        mergeCellNums.Add(1, 2);
        //mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "AccountInformation" + DateTime.Now.ToString("yyMMddHHmmss") + ".xls";
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

            //e.Row.Cells[
        }
    }

    /// <summary>
    /// 获取停车记录数据源
    /// </summary>
    /// <returns></returns>
    public DataTable GetTableData()
    {
        string strSql = @"select [card],RealName,sex,TypeName,balance,activitytime,LastSaleTime1,CellPhone,statusname,validDatetuse from v_card_MemberCardInfo WHERE 1 = 1 ";
        if (!string.IsNullOrEmpty(card.Value))
            strSql += " And [card] ='" + card.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(RealName.Value))
            strSql += " And RealName ='" + RealName.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(Status.Value))
            strSql += " And Status =" + Status.Value.Trim();
        if (!string.IsNullOrEmpty(addeddate1.Value) && !string.IsNullOrEmpty(addeddate2.Value))
            strSql += " And addeddate >= '" + addeddate1.Value.Trim() + "' and addeddate <= '" + addeddate2.Value.Trim() + "'";
        if (!string.IsNullOrEmpty(Area_Code.SelectedValue))
            strSql += " And areaname ='" + Area_Code.Items[Area_Code.SelectedIndex].Text + "'";

        if (!string.IsNullOrEmpty(Site_Code.SelectedValue))
            strSql += " And sitename ='" + Site_Code.Items[Site_Code.SelectedIndex].Text + "'";

        DataTable dt = new DataTable();
        dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        return dt;
    }


}
