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
using Microsoft.Office.Interop.Excel;

/// <summary>
///ExcelHelper 的摘要说明
/// </summary>
public class ExcelHelper
{
    public ExcelHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 获取此列的列名
    /// </summary>
    /// <param name="type"></param>
    /// <param name="ColName"></param>
    /// <returns></returns>
    //public static string GetRptColumnName(Type type,string ColName)
    //{
    //    FieldInfo fd = type.GetField(ColName);
    //  if (fd == null) 
    //    return string.Empty;
    //  object[] attrs = fd.GetCustomAttributes(typeof(RptColumnName), false);
    //  string name = string.Empty;
    //  foreach (RptColumnName attr in attrs)
    //  {
    //    name = attr.ColumnName;
    //  }
    //  return name;
    //}
    /// <summary>
    /// 获取生成的excel
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="type"></param>
    /// <param name="XslTitle"></param>
    /// <returns></returns>
    public static void ExportExcel(System.Data.DataTable dt, Type type, string XslTitle)
    {
        Application application = new Application();
        Workbook book = application.Workbooks.Add(true);
        //string TemPath = HttpContext.Current.Server.MapPath("~\\ReportViewer\\Templates\\" + type.Name + ".xlt");
        //string strExcelTemplateFile = System.IO.Path.GetFullPath(TemPath);
        //if (System.IO.File.Exists(strExcelTemplateFile) == false)
        //{
        //    throw new Exception("文件不存在");
        //}
        //Workbook book = application.Workbooks.Add(TemPath);
        Worksheet sheet = book.ActiveSheet as Worksheet;

        sheet.Name = XslTitle;
        //sheet.Tab.Color = System.Drawing.Color.FromArgb(65, 50, 225).ToArgb();
        //获取所有方法 
        //System.Reflection.MethodInfo[] methods = t.GetMethods();

        //foreach (System.Reflection.MethodInfo method in methods)
        //{

        //    //this.textBox1.Text += method.Name + System.Environment.NewLine;
        //}
        //获取所有成员 
        //System.Reflection.MemberInfo[] members = type.GetMembers();

        //string p = "";
        //string f = "";
        //System.Reflection.FieldInfo[] fieldInfos = type.GetFields();
        //foreach (System.Reflection.FieldInfo fieldInfo in fieldInfos)
        //{

        //    f += fieldInfo.Attributes.ToString();
        //    string s = GetRptColumnName(type, "userid");

        //    //this.lstColors.Items.Add(property.Name);
        //}

        //获取所有属性 
        int i = 1;
        List<string> columns = new List<string>();
        List<string> props = new List<string>();
        System.Reflection.PropertyInfo[] properties = type.GetProperties();
        foreach (System.Reflection.PropertyInfo property in properties)
        {
            object[] attrs = property.GetCustomAttributes(typeof(RptColumnName), false);
            string name = string.Empty;
            foreach (RptColumnName attr in attrs)
            {
                name = attr.ColumnName;

            }

            Range r = sheet.Cells[4, i] as Range;
            r.Font.Name = "黑体";
            r.Font.Size = 11;
            r.Font.Bold = 1;
            r.Borders.LineStyle = 1;
            r.Cells.Interior.Color = System.Drawing.Color.FromArgb(255, 204, 153).ToArgb();
            r.Merge(true);
            r.HorizontalAlignment = XlVAlign.xlVAlignCenter;
            r.Value2 = name;
            columns.Add(name);
            props.Add(property.Name);
            i++;
        }



        for (int j = 0; j < dt.Rows.Count; j++)
        {
            for (int k = 0; k < props.Count; k++)
            {
                Range range = sheet.Cells[j + 5, k + 1] as Range;
                //string zhi= dt.Rows[j][props[k].ToString()].ToString();
                //range.Value2 = dt.Rows[j][props[k].ToString()];
                range.Font.Size = 10;
                range.Borders.LineStyle = 1;
                range.EntireColumn.AutoFit();
                range.BorderAround(null, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, null);
            }
        }
        Range rangeTitle = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[1, props.Count]) as Range;
        rangeTitle.Merge(true);
        rangeTitle.HorizontalAlignment = XlVAlign.xlVAlignCenter;
        rangeTitle.Value2 = XslTitle;
        rangeTitle.Font.Size = 16;
        rangeTitle.Font.Bold = 1;
        rangeTitle.Borders.LineStyle = 1;
        rangeTitle.Cells.Interior.Color = System.Drawing.Color.FromArgb(255, 50, 39).ToArgb();
        ((Range)sheet.Rows["1:1", System.Type.Missing]).RowHeight = 30;


        Range rangeTime = sheet.get_Range(sheet.Cells[2, 1], sheet.Cells[2, props.Count]) as Range;
        rangeTime.Merge(true);
        rangeTime.Font.Size = 10;
        rangeTime.Value2 = "导出时间：" + DateTime.Now.ToShortDateString();
        rangeTime.Borders.LineStyle = 1;

        Range range1 = sheet.get_Range(sheet.Cells[3, 1], sheet.Cells[3, props.Count / 2]) as Range;
        range1.Merge(true);
        range1.Font.Size = 10;
        range1.Value2 = "记录行数：" + dt.Rows.Count;
        range1.Borders.LineStyle = 1;

        Range range2 = sheet.get_Range(sheet.Cells[3, props.Count / 2 + 1], sheet.Cells[3, props.Count]) as Range;
        range2.Merge(true);
        range2.Font.Size = 10;
        //range2.Columns.ColumnWidth = 20;
        range2.Value2 = "操作人：" + Ims.Main.ImsInfo.CurrentUserId;
        range2.Borders.LineStyle = 1;

        //Range rangeBottom = sheet.get_Range(sheet.Cells[dt.Rows.Count + 4,1], sheet.Cells[dt.Rows.Count + 4, props.Count]) as Range;
        //rangeBottom.Merge(true);
        //rangeBottom.Font.Size = 11;
        //rangeBottom.Borders.LineStyle = 0;
        //rangeBottom.Font.Bold = 1;
        //rangeBottom.Cells.Interior.Color = System.Drawing.Color.FromArgb(115, 150, 39).ToArgb();
        //rangeBottom.Value2 = "统计信息：";

        string fileName = "~\\ReportViewer\\Business\\" + DateTime.Now.ToString("yyMMddHHmmss") + ".xls"; //Guid.NewGuid().ToString()
        string pathFileName = HttpContext.Current.Server.MapPath(fileName);
        book.SaveAs(pathFileName, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        book.Close(Type.Missing, Type.Missing, Type.Missing);
        application.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
        book = null;
        application = null;
        sheet = null;
        GC.Collect();



        ExcelHelper exHelper = new ExcelHelper();
        exHelper.ResponseFile(pathFileName);


        //FileStream fs = new FileStream(pathFileName, FileMode.Open);
        //byte[] buffer = new byte[fs.Length];
        //fs.Read(buffer, 0, buffer.Length);
        //fs.Close();
        //File.Delete(pathFileName);
        //string fileName1 = HttpContext.Current.Server.UrlEncode("硬件设备明细表.xls");
        //Response.Charset = "UTF-8";
        //Response.ContentEncoding = System.Text.Encoding.Default;
        //Response.ContentType = "application/ms-excel";
        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName1);
        //Response.OutputStream.Write(buffer, 0, buffer.Length);
        //Response.Flush();
        //Response.End();

        //HttpResponse response = HttpContext.Current.Response;
        //string fileName1 = HttpContext.Current.Server.UrlEncode("test.xls");
        //response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName1);
        //response.Charset = "UTF-8";
        //response.ContentEncoding = System.Text.Encoding.Default;
        //response.ContentType = "application/ms-excel";

        //response.Clear();
        //response.WriteFile(pathFileName);

    }
    public void ResponseFile(string filepath)
    {
        System.IO.Stream iStream = null;

        // Buffer to read 10K bytes in chunk:
        byte[] buffer = new Byte[10000];

        // Length of the file:
        int length;

        // Total bytes to read:
        long dataToRead;

        // Identify the file to download including its path.
        //string filepath = "DownloadFileName";

        // Identify the file name.
        string filename = System.IO.Path.GetFileName(filepath);

        try
        {
            // Open the file.
            iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open,
            System.IO.FileAccess.Read, System.IO.FileShare.Read);


            // Total bytes to read:
            dataToRead = iStream.Length;

            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

            // Read the bytes.
            while (dataToRead > 0)
            {
                // Verify that the client is connected.
                if (HttpContext.Current.Response.IsClientConnected)
                {
                    // Read the data in buffer.
                    length = iStream.Read(buffer, 0, 10000);

                    // Write the data to the current output stream.
                    HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);

                    // Flush the data to the HTML output.
                    HttpContext.Current.Response.Flush();

                    buffer = new Byte[10000];
                    dataToRead = dataToRead - length;
                }
                else
                {
                    //prevent infinite loop if user disconnects
                    dataToRead = -1;
                }
            }
        }
        catch (Exception ex)
        {
            WebHelper.Record(WebHelper.错误日志, "错误路径：[./App_Code./ExcelHelper.cs]->ResponseFile()" + ex.Message);
            // Trap the error, if any.
            //Response.Write("Error : " + ex.Message);
        }
        finally
        {
            if (iStream != null)
            {
                //Close the file.
                iStream.Close();
            }
        }
    }

}
