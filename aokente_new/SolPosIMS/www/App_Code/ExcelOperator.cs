using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Drawing;

/// 
/// <summary>
///   <para>类名:ExcelOperator</para>
///   <para>功能:用于将Datatable数据导出Excel表格.</para>
/// </summary>
/// 

public class ExcelOperator
{
    /// <summary>
    /// <para>文本格式显示数字，这样就可以显示出0001。</para>
    /// </summary>
    public const String TEXT_NUMBER = "@";

    /// <summary>
    /// <para>日期模式显示数字。</para>
    /// </summary>
    public const String DATE_NUMBER = "yyyy/mm/dd"; //直接将数字显示为年月日。

    /// <summary>
    /// 数字模式显示数字。
    /// </summary>
    public const String NUMBER_NUMBER = "#,##0.00";

    /// <summary>
    /// 货币形式显示数字。
    /// </summary>
    public const String CURRENCY_NUMBER = "￥#,##0.00"; //货币模式现实数字。

    /// <summary>
    /// 百分比形式显示数字。
    /// </summary>
    public const String PERCENT_NUMBER = "#0.00%";


    public enum HorizAlignMode { Left, Center, Right };

    public enum VertAlignMode { Top, Middle, Bottom };



    /// <summary>
    ///   设置单元格的数字现实模式，比如用文本模式现实数字还是用数字模式，数字格式等。
    /// </summary>
    /// 
    /// <param name="tbCell">需要设置数字现实格式的单元格。</param>
    /// 
    /// <param name="strFormatStyle">
    ///   单元格的数字显示样式，可选参数如下:
    ///   <para>TEXT_NUMBER (文本格式显示数字，这样就可以显示出0001)</para>
    ///   <para>DATE_NUMBER (日期模式显示数字)</para>
    ///   <para>NUMBER_NUMBER (数字格式，可以自己拼凑数字格式)</para>
    ///   <para>CURRENCY_NUMBER (以货币形式显示，以人民币为单位)</para>
    ///   <para>PERCENT_NUMBER (以百分比形式显示。)</para>
    /// </param>
    public static void SetCellDisplayNumberStyle(TableCell tbCell, String strFormatStyle)
    {
        if (tbCell == null || strFormatStyle == null)
        {
            return;
        }

        tbCell.Style.Add("vnd.ms-excel.numberformat", strFormatStyle);
    }


    /// <summary>
    /// 设置单元格的宽度.
    /// </summary>
    /// <param name="tbCell">需要设置宽度的单元格.</param>
    /// <param name="iWidth">需要设置的宽度.</param>
    public static void SetCellWidth(TableCell tbCell, int iWidth)
    {
        if (tbCell == null)
        {
            return;
        }

        tbCell.Style.Add("word-break", "break-all");
        tbCell.Style.Add("word-wrap", "break-word");
        tbCell.Style.Add("width", iWidth.ToString());
    }


    /// <summary>
    ///   用于设置单元格的横向对齐模式。
    /// </summary>
    /// <param name="tbCell">需要设置对齐模式的单元格。</param>
    /// <param name="horizAlignMode">横向的对齐模式取值。</param>
    public static void SetCellHorizontalAlignMode(TableCell tbCell, HorizAlignMode horizAlignMode)
    {
        if (tbCell == null)
        {
            return;
        }

        switch (horizAlignMode)
        {
            case HorizAlignMode.Center:
                tbCell.HorizontalAlign = HorizontalAlign.Center;
                break;
            case HorizAlignMode.Left:
                tbCell.Style.Add("text-align", "left");
                break;

            case HorizAlignMode.Right:
                tbCell.Style.Add("text-align", "right");
                break;

        }
    }


    /// <summary>
    ///   设置单元格里的文本垂直对齐模式.
    /// </summary>
    /// 
    /// <param name="tbCell">需要设置的单元格。</param>
    /// 
    /// <param name="vertAlignMode">对齐模式的取值</param>
    /// 
    public static void SetCellVertAlignMode(TableCell tbCell, VertAlignMode vertAlignMode)
    {
        if (tbCell == null)
        {
            return;
        }

        switch (vertAlignMode)
        {
            case VertAlignMode.Top:
                tbCell.Style.Add("vertical-align", "top");
                break;
            case VertAlignMode.Middle:
                tbCell.Style.Add("vertical-align", "middle");
                break;
            case VertAlignMode.Bottom:
                tbCell.Style.Add("vertical-align", "bottom");
                break;
        }
    }


    /// <summary>
    ///   设置单元格字体大小。
    /// </summary>
    /// <param name="tbCell">需要设置字体大小的单元格。</param>
    /// <param name="iFontSize">字体大小。</param>
    public static void SetCellFontSize(TableCell tbCell, int iFontSize)
    {
        if (tbCell == null)
        {
            return;
        }

        tbCell.Style.Add("font-size", "" + iFontSize);
    }


    /// <summary>
    /// 用于将C#里的RGB颜色转换为WEB用的颜色。
    /// </summary>
    /// <param name="clColor">需要转换的C#的RGB</param>
    /// <returns>WEB用的颜色字符串</returns>
    public static String GetWebColor(Color clColor)
    {
        if (clColor == null)
        {
            return "#000000";
        }

        String strWebRed = (Convert.ToString(clColor.R, 16)).PadLeft(2, '0');
        String strWebGreen = (Convert.ToString(clColor.G, 16)).PadLeft(2, '0');
        String strWebBlue = (Convert.ToString(clColor.B, 16)).PadLeft(2, '0');
        String strWebColor = "#" + strWebRed + strWebGreen + strWebBlue;

        return strWebColor;
    }


    /// <summary>
    /// 设置单元格的字体颜色。
    /// </summary>
    /// <param name="tbCell">需要设置的单元格。</param>
    /// <param name="clFont">需要设置的字体颜色。</param>
    public static void SetCellFontColor(TableCell tbCell, Color clFont)
    {
        if (tbCell == null || clFont == null)
        {
            return;
        }

        String strWebFontColor = GetWebColor(clFont);
        tbCell.Style.Add("color", strWebFontColor);
    }


    /// <summary>
    /// 用于按需要合并的列排序。
    /// </summary>
    /// <param name="dtData"></param>
    /// <param name="mergeCellNums"></param>
    private static void SortByMergeCell(DataTable dtData, Dictionary<int, int> mergeCellNums)
    {
        ///////////////////////
        //
        // 以下代码是检查变量是不是空的
        if (dtData == null || mergeCellNums == null)
        {
            return;
        }

        ///////////////////////
        //
        // 对需要合并的列的键值进行排序
        SortedDictionary<int, int> sortMergeCellNums = new SortedDictionary<int, int>();

        foreach (KeyValuePair<int, int> item in mergeCellNums)
        {
            sortMergeCellNums.Add(item.Key, item.Value);
        }


        String strSortName = "";

        //////////////////////
        //
        // 循环设置排序的参数
        foreach (KeyValuePair<int, int> item in sortMergeCellNums)
        {
            //////////////////////
            //
            // 如果需要排序的列超出了表格的列的范围，则忽略。
            int iIndex = item.Key;

            if (iIndex >= dtData.Columns.Count)
            {
                continue;
            }

            if (strSortName == "")
            {
                strSortName = strSortName + dtData.Columns[iIndex].ColumnName;
            }
            else
            {
                strSortName = strSortName + ", " + dtData.Columns[iIndex].ColumnName;
            }

        } //foreach 


        dtData.DefaultView.Sort = strSortName + " asc";
        dtData = dtData.DefaultView.ToTable();

    }


    /// <summary>
    ///  <para>用于将DataTable 导出成 Excel表格.</para>
    ///  <param name="dtData">数据表DataTable</param>
    ///  <param name="header">Excel的表头</param>
    ///  <param name="fileName">下载时候默认的文件名</param>  
    ///  <param name="mergeCellNums">要合并的列索引字典 格式：列索引-合并模式(合并模式 1 合并相同项、2 合并空项、3 合并相同项及空项)</param>  
    ///  <param name="mergeKey">作为合并项的标记列索引</param>  
    ///  <param name="isNeedSerialNum">是否需要行标</param>
    /// </summary>
    public static void DataTable2Excel(DataTable dtData, TableCell[] header,
           GridViewRowEventHandler RowBoundHandler, string fileName,
           Dictionary<int, int> mergeCellNums, int? mergeKey, bool isNeedSerialNum)
    {
        System.Web.UI.WebControls.GridView gvExport = null;

        // 当前对话   
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;
        // IO用于导出并返回excel文件   
        System.IO.StringWriter strWriter = null;
        System.Web.UI.HtmlTextWriter htmlWriter = null;

        if (dtData != null)
        {
            // 设置编码和附件格式   
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            curContext.Response.Charset = "utf-8";

            if (!string.IsNullOrEmpty(fileName))
            {
                //处理中文名乱码问题  
                fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
                curContext.Response.AppendHeader("Content-Disposition", ("attachment;filename=" + (fileName.ToLower().EndsWith(".xls") ? fileName : fileName + ".xls")));
            }

            // 导出excel文件   
            strWriter = new System.IO.StringWriter();
            htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

            // 重新定义一个无分页的GridView   
            gvExport = new System.Web.UI.WebControls.GridView();


            //开始设置排序。
            SortByMergeCell(dtData, mergeCellNums);

            DataTable dtTmpTable = dtData.DefaultView.ToTable();

            //添加序号。
            if (isNeedSerialNum == true)
            {
                DataTable dtTable = AddSeriNumToDataTable(dtTmpTable);

                ///////////////////////////////
                //
                // 重置所有合并列的序号.
                if (dtTable != null)
                {
                    Dictionary<int, int> newMergeCellNums = new Dictionary<int, int>();

                    foreach (KeyValuePair<int, int> item in mergeCellNums)
                    {
                        newMergeCellNums.Add(item.Key + 1, item.Value);
                    }

                    mergeCellNums = newMergeCellNums;

                    mergeKey = mergeKey + 1;
                }


            }


            gvExport.DataSource = dtTmpTable.DefaultView;

            gvExport.AllowPaging = false;
            gvExport.EnableViewState = false;

            //gvExport.DataBinding = new System.EventHandler(


            //优化导出数据显示，如身份证、12-1等显示异常问题  
            gvExport.RowDataBound += new System.Web.UI.WebControls.GridViewRowEventHandler(GridView_DataBound);
            gvExport.RowDataBound += RowBoundHandler;

            gvExport.DataBind();

            //处理表头  
            if (header != null && header.Length > 0)
            {
                gvExport.HeaderRow.Cells.Clear();
                gvExport.HeaderRow.Cells.AddRange(header);
            }


            //合并单元格  
            if (mergeCellNums != null && mergeCellNums.Count > 0)
            {
                foreach (int cellNum in mergeCellNums.Keys)
                {
                    MergeRows(gvExport, cellNum, mergeCellNums[cellNum], mergeKey);
                }
            }



            // 返回客户端   
            gvExport.RenderControl(htmlWriter);



            curContext.Response.Clear();
            curContext.Response.Write("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=utf-8\"/>");
            curContext.Response.Write(strWriter.ToString());
            curContext.Response.End();
        }
    }

    protected static void GridView_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TableCellCollection cells = e.Row.Cells;

            foreach (TableCell cell in cells)
            {
                cell.Text = HttpContext.Current.Server.HtmlDecode(cell.Text);
            }

        }
    }



    /// <summary>     
    /// 描述：合并GridView列中相同的行  
    /// </summary>     
    /// <param   name="gvExport">GridView对象</param>     
    /// <param   name="cellNum">需要合并的列</param>     
    /// <param name="mergeMode">合并模式 1 合并相同项、2 合并空项、3 合并相同项及空项</param>  
    /// <param name="mergeKey">作为合并项的标记列索引</param>  
    private static void MergeRows(GridView gvExport, int cellNum, int mergeMode, int? mergeKey)
    {
        int i = 0, rowSpanNum = 1;
        System.Drawing.Color alterColor = System.Drawing.Color.White;

        //String strText1 = HttpContext.Current.Server.HtmlDecode(gvExport.Rows[1].Cells[0].Text);
        //String strText2 = HttpContext.Current.Server.HtmlDecode(gvExport.Rows[2].Cells[1].Text);
        ////gvExport.Rows[2].Cells[1].Text = strText2;
        //String strText3 = HttpContext.Current.Server.HtmlDecode(gvExport.Rows[1].Cells[2].Text);

        while (i < gvExport.Rows.Count - 1)
        {
            GridViewRow gvr = gvExport.Rows[i];
            for (++i; i < gvExport.Rows.Count; i++)
            {
                GridViewRow gvrNext = gvExport.Rows[i];
                if ((!mergeKey.HasValue || (mergeKey.HasValue && (gvr.Cells[mergeKey.Value].Text.Equals(gvrNext.Cells[mergeKey.Value].Text) || " ".Equals(gvrNext.Cells[mergeKey.Value].Text)))) && ((mergeMode == 1 && gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text) || (mergeMode == 2 && " ".Equals(gvrNext.Cells[cellNum].Text.Trim())) || (mergeMode == 3 && (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text || " ".Equals(gvrNext.Cells[cellNum].Text.Trim())))))
                {
                    gvrNext.Cells[cellNum].Visible = false;
                    rowSpanNum++;
                    gvrNext.BackColor = gvr.BackColor;
                }
                else
                {
                    gvr.Cells[cellNum].RowSpan = rowSpanNum;
                    rowSpanNum = 1;
                    //间隔行加底色，便于阅读  
                    if (mergeKey.HasValue && cellNum == mergeKey.Value)
                    {
                        alterColor = System.Drawing.Color.White;
                    }
                    break;
                }

                if (i == gvExport.Rows.Count - 1)
                {
                    gvr.Cells[cellNum].RowSpan = rowSpanNum;
                    //if (mergeKey.HasValue && cellNum == mergeKey.Value)
                    //{
                    //    if (alterColor == System.Drawing.Color.White)
                    gvr.BackColor = System.Drawing.Color.White;
                    //}
                }
            }
        }
    }

    /// <summary>
    /// 在DataTable中添加一序号列，编号从1依次递增
    /// </summary>
    /// <param >DataTable</param>
    /// <returns></returns>
    public static DataTable AddSeriNumToDataTable(DataTable dt)
    {
        if (dt.Columns.IndexOf("序号") >= 0)
        {
            return null;
        }

        dt.Columns.Add("序号", Type.GetType("System.UInt32"));
        dt.Columns["序号"].SetOrdinal(0);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Rows[i]["序号"] = i + 1;
        }

        return dt;

    }


}
