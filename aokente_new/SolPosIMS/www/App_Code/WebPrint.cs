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
using System.Text;

/// <summary>
///WebPrint 的摘要说明
/// </summary>
public class WebPrint
{
    public WebPrint()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// //GridTablePrint执行的功能：根据DataTable转换成对应的HTML对应的字符串
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string GridTablePrint(DataTable dt,string rptTitle)
    {

        DataTable myDataTable = dt;

        int myRow = myDataTable.Rows.Count;

        int myCol = myDataTable.Columns.Count;

        StringBuilder sb = new StringBuilder();

        string colHeaders = "<html><meta name='viewport' content='width=device-width, initial-scale=1' /><body style='width:98%'><div style='width:100%;text-align:center;'><h3>" + rptTitle + "</h3></div>" + "<object ID='WebBrowser' WIDTH=0 HEIGHT=0 CLASSID='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2'VIEWASTEXT></object>" + "<table style='font-size:10pt;width:100%' border='1' bordercolor='#DFDFDF' style='border-collapse:collapse;'><tr>";

        for (int i = 0; i < myCol; i++)
        {

            colHeaders += "<td  style='border: solid 1px #DFDFDF; height: 20%;'>" + myDataTable.Columns[i].ColumnName.ToString() + "</td>";

        }

        colHeaders += "</tr>";

        sb.Append(colHeaders);



        for (int i = 0; i < myRow; i++)
        {

            sb.Append("<tr>");

            for (int j = 0; j < myCol; j++)
            {

                sb.Append("<td>");

                sb.Append(myDataTable.Rows[i][j].ToString().Trim());

                sb.Append("</td>");

            }

            sb.Append("</tr>");

        }



        sb.Append("</table></body></html>");

        colHeaders = sb.ToString();

        colHeaders += "<script languge='Javascript'>WebBrowser.ExecWB(6,1); window.opener=null;window.close();</script>";

        return (colHeaders);

    }
}
