using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace ZsdDotNetLibrary.Data
{
    /// <summary>
    /// DataToExcel 的摘要说明
    /// </summary>
    public class DataToExcel
    {
        public DataToExcel()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static bool ExportExcel(System.Data.DataTable dtData, string filename)
        {
            HttpContext.Current.Items.Add("dt", dtData);
            HttpContext.Current.Items.Add("str", filename);
            //HttpContext.Current.Server.Transfer("down.aspx");
            HttpContext.Current.Server.Execute("down.aspx");
            return true;
        }

        public static  void CreateExcel(DataTable dt, string FileName) //dt为一个DataTable 类型的数据集   FileName  是导出来的文件名
        {
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName + ".xls");
            string colHeaders = "", ls_item = "";
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
            int i = 0;
            int cl = dt.Columns.Count;

            //取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))//最后一列，加\n
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\n";
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\t";
                }

            }
            HttpContext.Current.Response.Write(colHeaders);
            //向HTTP输出流中写入取得的数据信息

            //逐行处理数据  
            foreach (DataRow row in myRow)
            {
                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据    
                for (i = 0; i < cl; i++)
                {
                    if (i == (cl - 1))//最后一列，加\n
                    {
                        ls_item += row[i].ToString() + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString() + "\t";
                    }

                }
                HttpContext.Current.Response.Write(ls_item);
                ls_item = "";
            }
            HttpContext.Current.Response.End();
        }
    }
}