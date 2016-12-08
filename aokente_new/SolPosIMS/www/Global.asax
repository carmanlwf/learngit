<%@ Application Language="C#" %>
<%@ Import Namespace="ZsdDotNetLibrary.Log" %>
<%@ Import Namespace="System.Collections.Generic" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        //System.Timers.Timer t = new System.Timers.Timer(10000);
        //t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
        //t.AutoReset = false;   //设置是执行一次（false）还是一直执行(true)；   
        //t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
        //updateMagicStatus();
        System.Threading.Thread thread = new System.Threading.Thread(updateMagicStatus);
        thread.IsBackground = true;
        thread.Start();

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码
        WebHelper.WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "application关闭" + "\r\n", "magic", WebHelper.服务日志, "magic");
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
         //在出现未处理的错误时运行的代码
        string msg = string.Format("发生错误的页面：{0}\r\n错误信息：{1}\r\n",
            Request.Url.ToString(), Server.GetLastError());
        LogHelper.Write(msg, LogCategory.Error, LogPriority.Highest);
        //string requestUrl = Request.Url.ToString();
        //if (requestUrl.IndexOf("Error.aspx", StringComparison.OrdinalIgnoreCase) >= 0)
        //{
        //    Server.ClearError();
        //    return;
        //}
        //Exception objErr = Server.GetLastError().GetBaseException();
        //ArrayList errors = new ArrayList();
        //errors.Add(requestUrl);
        //errors.Add(objErr.Message);
        //errors.Add(Server.GetLastError().ToString());
        //Server.ClearError();
        //Application["error"] = errors;
        //Response.Redirect("~/Error.aspx");
    }

    void Session_Start(object sender, EventArgs e) 
    {
        /**
        // 在新会话启动时运行的代码
        bool isAuto = true;
        bool.TryParse(ConfigurationManager.AppSettings["IsAutoSignOut"], out isAuto);
        if (isAuto)
        {
            WriteAutoLog();
            try
            {
                Ims.Pos.BLL.SP_AutoSignOutBLL.Sys_AutoSignOut();
            }
            catch (Exception ex)
            {
                WebHelper.WriteLog(ex.ToString(), "AutoLog", 2, "AutoLogError");
            }
        }
         **/
    }
    public void WriteAutoLog()
    {
        StringBuilder sb_Log = new StringBuilder();
        string LogId = "Auto_Log" + DateTime.Now.ToString("HHmmssfff");//Logid
        sb_Log.Append("[" + DateTime.Now.ToString() + "] 自动签退方法被执行...\r\n");
        sb_Log.Append("客户端名称：" + Request.UserHostName + "\r\n");
        sb_Log.Append("客户端IP：" + Request.UserHostAddress + "\r\n");
        sb_Log.Append("-----------------------------------------------------------------------------------------------------------" + "\r\n");

        WebHelper.WriteLog(sb_Log.ToString(), "AutoLog", 1, "AutoLog"); 
    }
    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。

    }

    void t_Elapsed(object source, System.Timers.ElapsedEventArgs e)
    {
        //MessageBox.Show("OK!");
        //CommunicationHelperBLL.GetParkingSiteStatus();
        updateMagicStatus();
    }

    void updateMagicStatus()
    {
        CommunicationHelperBLL.GetParkingSiteStatus();
        System.Threading.Thread.Sleep(10000);
        updateMagicStatus();
    }
       
</script>
