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
using Ims.Log.Model;
using Ims.Log.BLL;
using ZsdDotNetLibrary.Web;
using System.Data.SqlClient;
using ZsdDotNetLibrary.Log;
using System.IO;

public partial class Sysem_ManagementData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["SortOrder"] = "date";
            ViewState["OrderDire"] = "Desc";
            Bind();

        }
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        //获取连接字符串
        string connectionString = ConfigurationManager.ConnectionStrings["NSKConnectString"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);

        //获取数据库名称
        string[] useridinfo = connectionString.Split(';');
        for (int i = 0; i < useridinfo.Length; i++)
        {
            Text1.Value = useridinfo[0].ToString().Trim().Substring(9);
        }

        SqlCommand cmdBK = new SqlCommand();
        cmdBK.CommandType = CommandType.Text;
        cmdBK.Connection = conn;
        //cmdBK.CommandText = @"backup database XWC_DB  to disk= 'd:\" + DateTime.Now.ToString("yymmddHHmmss") + "备份.bak ' with  init;";
        string path3 = Server.MapPath("../Data/");
        string data1 = @"backup database [" + Text1.Value + "]  to disk= '" + path3 + "";
        string data2 = bakName.Value.Trim() + DateTime.Now.ToString("ddHHmmss");
        cmdBK.CommandText = data1 + data2 + "备份.bak ' with  init;";
        try
        {
            conn.Open();
            cmdBK.ExecuteNonQuery();
            conn.Close();
            //写入日志
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.type = "数据备份";
            log.logmsg = log.operater + "对数据库进行了手动备份!备份的名字为:" + data2 + "备份.bak";
            LogHelperBLL.InsertObject(log);


            ViewState["SortOrder"] = "date";
            ViewState["OrderDire"] = "Desc";
            Bind();

            WebClientHelper.DoClientMsgBox("备份成功!");

        }
        catch (Exception ex)
        {
            WebClientHelper.DoClientMsgBox(ex.Message);
            LogHelper.Write("备份出错。指令：" + cmdBK.CommandText);
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

    //获取文件列表数据
    public static DataTable DirSize(DirectoryInfo d)
    {
        DataTable c = new DataTable();//创建临时表
        c.Columns.Add(new DataColumn("name", typeof(string)));
        c.Columns.Add(new DataColumn("size", typeof(string)));
        c.Columns.Add(new DataColumn("date", typeof(string)));

        FileInfo[] fis = d.GetFiles("*.bak");
        foreach (FileInfo fi in fis)
        {
            DataRow dr = c.NewRow();
            dr["name"] = fi.Name;
            dr["size"] = fi.Length.ToString();
            dr["date"] = fi.CreationTime.ToString();
            c.Rows.Add(dr);
        }
        return c;
    }

    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        string fimeName = e.CommandArgument.ToString();
        string path2 = Server.MapPath("../Data/");
        string delFile = path2 + fimeName;


        try
        {
            File.Delete(delFile);

            //写入日志
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.type = "备份删除";
            log.logmsg = log.operater + "删除了名字为：" + fimeName + "!";
            LogHelperBLL.InsertObject(log);

            DirectoryInfo d = new DirectoryInfo(path2);
            GridView1.DataSource = DirSize(d);
            GridView1.DataBind();
            ViewState["SortOrder"] = "date";
            ViewState["OrderDire"] = "Desc";
            Bind();

            WebClientHelper.DoClientMsgBox("删除成功!");
        }
        catch
        {
            WebClientHelper.DoClientMsgBox("删除失败!");
        }

    }

    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        WebClientHelper.DoClientMsgBox("还原操作已禁用,请登录服务器执行操作.");
        return;
        string fimeName = e.CommandArgument.ToString();

        string path2 = Server.MapPath("../Data/");
        string pathFile = path2 + fimeName;//得到文件名与路径

        string last = pathFile.Substring(fimeName.LastIndexOf(".") + 1);//获取文件的后缀名 　

        //连接字符串
        string connectionString = ConfigurationManager.ConnectionStrings["NSKConnectString"].ToString();
        SqlConnection conn = new SqlConnection(connectionString);
        //获取数据库名
        string[] useridinfo = connectionString.Split(';');
        for (int i = 0; i < useridinfo.Length; i++)
        {
            Text1.Value = useridinfo[0].ToString().Trim().Substring(9);
        }
        //string cmdtxt2 = "ALTER DATABASE " + Text1.Value + " SET OFFLINE WITH ROLLBACK IMMEDIATE  restore database kkookkoo from disk='" + pathFile + "' with replace  "; 　//重要语句
        string cmdtxt2 = "ALTER DATABASE " + Text1.Value + " SET OFFLINE WITH ROLLBACK IMMEDIATE  restore database " + Text1.Value + " from disk='" + pathFile + "' with replace  "; 　//重要语句

        try
        {
            conn.Open();
            SqlCommand command = new SqlCommand(cmdtxt2, conn);
            command.ExecuteNonQuery();
            conn.Close();

            //写入日志
            tb_Log log = new tb_Log();
            log.logid = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            log.operater = Ims.Main.ImsInfo.CurrentUserId;
            log.operate_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.type = "数据还原";
            log.logmsg = log.operater + "还原了数据库,还原的数据备份名字为：" + fimeName + "";
            LogHelperBLL.InsertObject(log);

            WebClientHelper.DoClientMsgBox("还原成功,数据将重新加载!");
        }
        catch (Exception ex)
        {
            WebClientHelper.DoClientMsgBox(ex.Message);
            LogHelper.Write("备份出错。指令：" + cmdtxt2);
        }
        finally
        {
            conn.Close();
        }

    }


    //-------------------------------------------------------------------------------------------
    private void Bind()
    {

        GridView1.AllowSorting = true;

        try
        {
            //--------------------------
            string path = Server.MapPath("~/Data/");
            DirectoryInfo d = new DirectoryInfo(path);
            //--------------------------   DirSize(d);
            //DataView dv = getDt().DefaultView;
            DataView dv = DirSize(d).DefaultView;
            dv.Sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];

            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
        catch
        {
            WebClientHelper.DoClientMsgBox("应用程序与数据库路径不统一,无法进行备份!");
            Button1.Disabled = true;
        }

    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {

        string sPage = e.SortExpression;
        if (ViewState["SortOrder"].ToString() == sPage)
        {

            if (ViewState["OrderDire"].ToString() == "Desc")
            {
                ViewState["OrderDire"] = "Asc";
            }
            else
            {
                ViewState["OrderDire"] = "Desc";
            }
        }
        else
        {
            ViewState["SortOrder"] = e.SortExpression;
        }

        Bind();

    }




    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind();
            TextBox tb = (TextBox)GridView1.BottomPagerRow.FindControl("inPageNum");
            tb.Text = (GridView1.PageIndex + 1).ToString();
        }
        catch { }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "go")
        {
            try
            {
                TextBox tb = (TextBox)GridView1.BottomPagerRow.FindControl("inPageNum");
                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                GridView1_PageIndexChanging(null, ea);
            }
            catch (Exception ex)
            {
                LogHelper.Write(ex.Message);
            }
        }
    }
}
