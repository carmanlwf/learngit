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
using NewSoftDotNetLibrary.Data;
using System.Collections.Generic;
using Ims.Site.Model;
using Ims.Site.BLL;

public partial class ReportViewer_Business_Rpt_CardChargeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    Chargetype.Items.Insert(0, new ListItem("全部", ""));
        //    Chargetype.Items.Insert(1, new ListItem("充值", "充值"));
        //    Chargetype.Items.Insert(2, new ListItem("扣款", "扣款"));
        //    Chargetype.Items.Insert(2, new ListItem("充值回滚", "充值回滚"));
        //    Chargetype.Items.Insert(2, new ListItem("扣款回滚", "充值回滚"));

        //    //InitListControlHelper.BindNormalTableToListControl(cardtype, "TypeID", "TypeName", "tb_CardType", "", "DeleStatus =0", "");
        //    //cardtype.Items.Insert(0, new ListItem("全部", ""));
        //}
    }
    public void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        v_parkingsiteinfo o = new v_parkingsiteinfo();
        //o.addeddate1 = begindate.Value;
        //o.addeddate2 = begindate.Value;
        //o.Status = 1;//normal
        List<v_parkingsiteinfo> c_list = parkingsiteinfoHelper.GetPagedObjects(0,0,"",o);
        

        DataTable dt = RptHelper.ToDataTable(c_list, typeof(RptMemberCard));
        ExcelHelper.ExportExcel(dt, typeof(RptMemberCard), "会员卡清单");

        DataTable ds = GetDataTable(begindate.Value.Trim(), enddate.Value.Trim());

        TableCell[] header = new TableCell[12];

        for (int i = 0; i < header.Length; i++)
        {
            header[i] = new TableHeaderCell();
        }

        header[0].ColumnSpan = 11;//设置跨越的列数
        header[0].Text = "平台充值明细清单</th></tr><tr>";

        //select transid,card,cardtype,chargetype,amount,gift,rulename,logtime,chargeway,operid from card_chargelist
        //第二行 
        header[1].Text = "序号";
        header[2].Text = "停车区域";
        header[3].Text = "所在路段";
        header[4].Text = "车位编号";//</th>
        header[5].Text = "车牌号码";
        header[6].Text = "收费员"; ;
        header[7].Text = "停入时间";
        header[8].Text = "离场时间";
        header[9].Text = "记录时间";
        header[10].Text = "已停时间";
        header[11].Text = "收费";
        header[12].Text = "操作机号";
        ExcelOperator.SetCellFontSize(header[0], 50);
        ExcelOperator.SetCellFontColor(header[0], System.Drawing.Color.Green);



        Dictionary<int, int> mergeCellNums = new Dictionary<int, int>();

        mergeCellNums.Add(0, 2);
        //mergeCellNums.Add(1, 1);

        System.Web.UI.WebControls.GridViewRowEventHandler RowBoundEvent = new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);
        String strDefaultFileName = "v_CardNoActive" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
        ExcelOperator.DataTable2Excel(ds, header, RowBoundEvent, strDefaultFileName, mergeCellNums, 0, true);


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
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[2], ExcelOperator.TEXT_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[5], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellDisplayNumberStyle(e.Row.Cells[6], ExcelOperator.NUMBER_NUMBER);
            ExcelOperator.SetCellWidth(e.Row.Cells[1], 180);
            ExcelOperator.SetCellFontSize(e.Row.Cells[2], 20);
            ExcelOperator.SetCellFontColor(e.Row.Cells[2], System.Drawing.Color.FromArgb(255, 255, 0, 0));
            ExcelOperator.SetCellFontSize(e.Row.Cells[1], 20);
            //e.Row.Cells[
        }
    }
    public DataTable GetDataTable(string timeStart, string timeEnd)
    {
        

        string areacode = "", strSQL = "";
        strSQL = "Select parkingid, parkingname, siteid, sitename, areaname, addtime, updatetime, opt_user, minute from v_shimianfei";
        if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
        {
            //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
            areacode = Ims.PM.BLL.PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
            strSQL = "Select parkingid, parkingname, siteid, sitename, areaname, addtime, updatetime, opt_user, minute from v_shimianfei";
        }
        //else
        //    strSQL = "Select transid,card,cardtype,chargetype,amount,gift,rulename,logtime,chargeway,operid from v_card_chargelist_area Where 1=1  and areacode ='" + areacode + "'";
    


        if (!string.IsNullOrEmpty(timeStart) && !string.IsNullOrEmpty(timeEnd))
            strSQL += " And addtime >='" + timeStart + "' And updatetime <='" + timeEnd + "'";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSQL);
        return dt;
    }
}



