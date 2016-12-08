using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using Ims.Main.BLL;


/**
 * 类名: CheckAutoSingOut
 * 
 * 
 **/
public class CheckAutoSingOut
{
    /**
     * 用于线程同步的问题。
     **/
    private static readonly Object asyncLock = new Object();

    /**
     * 用于存储上次自动签退的时间。
     **/
    private static DateTime lastAutoSignOutDateTime = new DateTime(1970, 01, 01, 01, 01, 01);


    /**
     * 功能:
     *   用于获取当前的日期。
     * 参数:
     *   无.
     * 返回值:
     *   当前日期时间。
     **/
    public static DateTime getNowDateTime()
    {
        return DateTime.Now;
    }

    ///**
    // * 功能:
    // *   是否在签退中...
    // * 参数:
    // *   无.
    // * 返回值:
    // *   true 签退中.
    // *   false 不在签退中.
    // **/ 
    //public static bool isNeedAutoSignOut()
    //{
    //    lock (asyncLock)
    //    {
    //        DateTime dtNow = DateTime.Now;

    //        TimeSpan timeSpan = dtNow - lastAutoSignOutDateTime;

    //        if (timeSpan.TotalMinutes > 3)
    //        {

    //            return true;
    //        }

    //    }

    //    return false;
    //}

    /**
     * 功能:
     *   用于检测是否需要自动签退，如果需要则执行自动签退。
     * 
     **/
    public static void checkAndAutoSingOut()
    {

        lock (asyncLock)
        {

            DateTime dtNow = DateTime.Now;

            TimeSpan timeSpan = dtNow - lastAutoSignOutDateTime;

            if (timeSpan.TotalMinutes <= 10)
            {
                return ;
            }

            lastAutoSignOutDateTime = DateTime.Now;

            bool isAuto = ConfigParmsInfo.IsAutoSignOut;//从内存中读取开启自动签退的配置信息

            if (isAuto)
            {
                try
                {
                    WriteAutoLog();//记录签退日志
                    Ims.Pos.BLL.SP_AutoSignOutBLL.Sys_AutoSignOut();
                }
                catch (Exception ex)
                {
                    WebHelper.WriteLog(ex.ToString(), "AutoLog", 2, "AutoLogError");
                }
            }

           
        }
    }

    /// <summary>
    /// 写签退日志 
    /// </summary>
    public static void WriteAutoLog()
    {
        StringBuilder sb_Log = new StringBuilder();
        string LogId = "Auto_Log" + DateTime.Now.ToString("HHmmssfff");//Logid
        sb_Log.Append("[" + DateTime.Now.ToString() + "] 自动签退方法被执行...\r\n");
        sb_Log.Append("客户端名称：" + HttpContext.Current.Request.UserHostName + "\r\n");
        sb_Log.Append("客户端IP：" + HttpContext.Current.Request.UserHostAddress + "\r\n");
        sb_Log.Append("-----------------------------------------------------------------------------------------------------------" + "\r\n");

        WebHelper.WriteLog(sb_Log.ToString(), "AutoLog", 1, "AutoLog");
    }


}
