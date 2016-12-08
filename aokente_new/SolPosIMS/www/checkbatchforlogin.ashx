<%@ WebHandler Language="C#" Class="checkbatchforlogin" %>

using System;
using System.Web;

public class checkbatchforlogin : IHttpHandler {
    readonly NiceFoodDataContext dc = new NiceFoodDataContext();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string ret = "";
        if (Ims.Main.ImsInfo.UserIsInRole("channel"))
        {
            if (Ims.Card.BLL.BatchHelperBLL.IsBatchAtLastTime())
                LoginBatchStart();
            else
            {
                ret = "系统检测到您的账户尚未结算,系统将继续累计您的当班营业信息!";
                //Ims.Card.BLL.BatchHelperBLL.ResetStatus();
                //WebClientHelper.DoClientMsgBox("系统检测到您的账户上次没有正常结算后退出,已重置当前的结算状态!");
            }
            context.Response.Write(ret);
            context.Response.End();
        }
        else
        {
            context.Response.Write(ret);
            context.Response.End(); 
        }
    }
    /// <summary>
    /// 记录当前操作员登录时间
    /// </summary>
    public void LoginBatchStart()
    {
        try
        {
            /*
            batch_operator gc = new batch_operator
            {
                transid = "t" + DateTime.Now.ToString("yyMMddHHmmssfff"),
                starttime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                operatorid = Ims.Main.ImsInfo.CurrentUserId
            };
            dc.batch_operator.InsertOnSubmit(gc);
            dc.SubmitChanges();
             * */
            
            int ret = Ims.Card.BLL.BatchHelperBLL.RegeditLoginStatus();
            
        }
        catch (Exception ex)
        {
            WebHelper.Record(WebHelper.错误日志, ex.Message.ToString());
        }
    }
    public bool IsReusable {
        get {
            return false;
        }
    }

}