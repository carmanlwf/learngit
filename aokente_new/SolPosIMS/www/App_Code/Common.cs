using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;

/// <summary>
/// Common 的摘要说明
/// </summary>
public class Common
{
    public Common()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static string InputText(string inputString, int maxLength)
    {
        StringBuilder retVal = new StringBuilder();
        if ((inputString != null) && (inputString != String.Empty))
        {
            inputString = inputString.Trim();
            if (inputString.Length > maxLength)
                inputString = inputString.Substring(0, maxLength);
            for (int i = 0; i < inputString.Length; i++)
            {
                switch (inputString[i])
                {
                    case '"':
                        retVal.Append("&quot;");
                        break;
                    case '<':
                        retVal.Append("&lt;");
                        break;
                    case '>':
                        retVal.Append("&gt;");
                        break;
                    default:
                        retVal.Append(inputString[i]);
                        break;
                }
            }
            retVal.Replace("'", " ");
        }
        return retVal.ToString();
    }
    /// <summary>
    /// 自动签退方法(静态)
    /// </summary>
    public static void AutoSignOutForParkingRecordYesterday()
    {
        //TimeSpan lt_TS = new TimeSpan(20, 00, 00);//默认晚上20：00开始签退
        //try
        //{
        //    string leaveTime = ConfigurationManager.AppSettings["OutTime"];
        //    lt_TS = TimeSpan.Parse(leaveTime);
        //}
        //catch (Exception ex)
        //{
        //    WebHelper.WriteLog(ex.ToString(), "AutoLog", 2, "AutoLogError");
        //}
        CheckAutoSingOut.checkAndAutoSingOut();
    }
    public static void ShowDialogWin(Page page,object obj,string msg)
    {
        msg = "<font color = green  >" + msg + "</font>";
        ClientScriptManager cs = page.ClientScript;
        Type cstype = obj.GetType();
        if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
        {
            cs.RegisterStartupScript(cstype, "ReturnWin", "<script>showdialogWin('" + msg + "');</script>");
        }
    }
}
