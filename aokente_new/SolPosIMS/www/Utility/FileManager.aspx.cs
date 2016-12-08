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
using System.IO;
public partial class Utility_FileManager : System.Web.UI.Page
{
     public string currentPath = "";
     public string currentFile = "";
     public string rootPath = "";
    public string parentControlId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = 0;
        //获取当前路径
        currentPath = Request.Form["currentPath"];
        if (string.IsNullOrEmpty(currentPath))
            currentPath = Request.QueryString["currentPath"];
        else
            currentPath = currentPath.Replace("\\\\", "\\");

        if (string.IsNullOrEmpty(currentPath))
            throw new Exception("你无权限访问！");
        if (currentPath[currentPath.Length - 1] != '\\') currentPath += '\\';

        //获取根路径
        rootPath = Request.Form["rootPath"];
        if (string.IsNullOrEmpty(rootPath))
            rootPath = Request.QueryString["rootPath"];
        else
            rootPath = rootPath.Replace("\\\\", "\\");
        if (string.IsNullOrEmpty(rootPath))
        {
            rootPath = currentPath;
        }

        //当前文件
        currentFile = Request.Form["selectRadioButton1"];
        if (string.IsNullOrEmpty(currentFile))
            currentFile = Request.QueryString["currentFile"];
        if (!string.IsNullOrEmpty(currentFile))
            currentFile = currentFile.Replace("\\\\", "\\");

        //文件名要放到到的控件ID
        parentControlId = Request.QueryString["controlId"];

    }


    protected void btnUpload_ServerClick(object sender, EventArgs e)
    {
        if (!FileUpload1.HasFile) return;
        string filename = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('\\') + 1);
        FileUpload1.SaveAs(currentPath + filename);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        FillFileView();
    }

    public void FillFileView()
    {
        DataTable table = new DataTable();
        table.Columns.Add("isdir", typeof(int));
        table.Columns.Add("filename", typeof(string));
        table.Columns.Add("fileselect", typeof(string));
        table.Columns.Add("pathurl", typeof(string));
        table.Columns.Add("size", typeof(string));
        table.Columns.Add("modifieddate", typeof(string));
        table.Columns.Add("downloadfile", typeof(string));
        
        if (Directory.Exists(currentPath))
        {
            if (rootPath != currentPath)
            {
                string parentPath = currentPath.TrimEnd('\\');
                parentPath = parentPath.Substring(0, parentPath.LastIndexOf('\\')+1);
                if (parentPath != "")
                {
                    string sdir = parentPath.Replace("\\", "\\\\");
                    DataRow row = table.NewRow();
                    table.Rows.Add(row);
                    row["isdir"] = 1;
                    row["pathurl"] = "<a href='javascript:openPath(\"" + sdir + "\")'>上级目录</a>";
                    row["filename"] = sdir;
                    row["fileselect"] = "";
                }
            }
            string[] dirs = Directory.GetDirectories(currentPath);
            if (dirs != null && dirs.Length > 0)
            {
                foreach (string dir in dirs)
                {
                    string sdir = dir.Replace("\\", "\\\\");
                    DataRow row = table.NewRow();
                    table.Rows.Add(row);
                    row["isdir"] = 1;
                    row["pathurl"] = "<a href='javascript:openPath(\"" + sdir + "\")'>" + dir.Substring(dir.LastIndexOf('\\') + 1) + "</a>";
                    row["filename"] = sdir + "\\\\";
                    row["fileselect"] = "";
                }
            }

            string[] files = Directory.GetFiles(currentPath);
            if (files != null && files.Length > 0)
            {
                foreach (string file in files)
                {
                    string sfile = file.Replace("\\", "\\\\");
                    string filename = file.Substring(rootPath.Length);
                    FileInfo finfo = new FileInfo(file);
                    DataRow row = table.NewRow();
                    table.Rows.Add(row);
                    row["isdir"] = 0;
                    row["pathurl"] = file.Substring(file.LastIndexOf('\\') + 1);
                    row["filename"] = sfile;
                    string isChecked = currentFile == filename ? "checked='checked'" : "";
                    //filename = filename.Replace("\\", "\\\\");
                    row["fileselect"] = "<input type='radio'　id='selectRadioButton1' name='selectRadioButton1' value='" + filename + "' " + isChecked + "/>";
                    row["size"] = finfo.Length.ToString();
                    row["modifieddate"] = finfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                    row["downloadfile"] = "<a href='javascript:void(0)' onclick='downloadFile(\"" + sfile + "\")' ><img border=0 src='../images/save.gif'/></a>";
                }
            }
            

        }

        FileView.DataSource = table;
        FileView.DataBind();
        return;

    }
}
