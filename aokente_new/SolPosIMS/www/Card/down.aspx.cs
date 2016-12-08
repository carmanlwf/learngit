using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Card_down : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { GetExcel(); }
    }
    public void GetExcel()
    {
        DataTable dtData = (DataTable)HttpContext.Current.Items["dt"];
        string filename = HttpContext.Current.Items["str"].ToString();
        System.Web.UI.WebControls.DataGrid dgExport = null;
        // 当前对话
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;
        // IO用于导出并返回excel文件
        System.IO.StringWriter strWriter = null;
        System.Web.UI.HtmlTextWriter htmlWriter = null;

        if (dtData != null)
        {
            // 设置编码和附件格式
            //curContext.Response.ContentType = "application/vnd.ms-excel";
            //curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //curContext.Response.Charset = "";

            curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
            //HttpContext.Current.Response.Charset = "UTF-8";
            curContext.Response.Charset = "GB2312";
            curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //HttpContext.Current.Response.ContentType=".xls/.txt/.doc";image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword 
            curContext.Response.ContentType = ".xls";
            // 导出excel文件
            strWriter = new System.IO.StringWriter();
            htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

            // 为了解决dgData中可能进行了分页的情况，需要重新定义一个无分页的DataGrid
            dgExport = new System.Web.UI.WebControls.DataGrid();
            dgExport.DataSource = dtData.DefaultView;
            dgExport.AllowPaging = false;
            dgExport.DataBind();

            // 返回客户端
            dgExport.RenderControl(htmlWriter);
            curContext.Response.Write(strWriter.ToString());
            curContext.Response.Flush();
            curContext.Response.Clear();
            curContext.Response.End();
        }
    }
}
