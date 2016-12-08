using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Ims.Pos.BLL;
using Ims.Pos.Model;
using ZsdDotNetLibrary.Data;
using System.Text;
using Newtonsoft.Json;
using System.Xml;
using Ims.Log.BLL;
public partial class dc : System.Web.UI.Page
{     
    StringBuilder sb_Log = new StringBuilder();
    string LogId = "Log" + DateTime.Now.ToString("HHmmssfff");//Logid
    string PosId = "Defalut";
    string Pos370 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        sb_Log.Append("LogId： " + LogId + "\r\n");
        sb_Log.Append("RawURL：" + Request.RawUrl + "\r\n");// 
        sb_Log.Append("ServerURL：" + Request.Url.Host.ToString() + ":" + Request.Url.Port.ToString() + "\r\n");// 
        //string des = "CMD=02\r\nPACKCOUNT=11\r\nPOSSNR=00000001\r\nFLAG=0\r\nVERSION=\r\nUserID=1\r\nPassword=000000\r\nBatchSnr=14\r\nStartDate=\r\nEndDate=\r\nBusinessAmount=4\r\nBusinessCount=1\r\nCancelAmount=0\r\nCancelCount=0\r\nIntegralAmount=0\r\nIntegralCount=0\r\nCancelIntegralAmount=0\r\nCancelIntegralCount=0";
        //string ens = WebHelper.DES64_Algorithm(des, 1);
        if (Request.QueryString["DATA"] != null)
        {
            string str = Request.QueryString["DATA"].ToString();//请求内容
            sb_Log.Append("[" + DateTime.Now.ToString() + "] ReqDecrypt：" + str + "\r\n");
            Pos370 = WebHelper.DES64_Algorithm(str, 0);//  pos370解密 
//CMD=03
//PACKCOUNT=3
//POSSNR=00000001
//FLAG=0
//VERSION=
//Magcard=100000
//CardSnr=100000
//PIN=000000
//CardType=1
//BackByte=       

            sb_Log.Append("[" + DateTime.Now.ToString() + "] ReqDecrypt：" + Pos370 + "\r\n");//  
            Pos370 = ClearString.InputText(Pos370, 1024);//过滤字符
            if (!string.IsNullOrEmpty(Pos370))
            {
                string centerstr = Pos370.Replace("\r\n", "\",\"").Replace("=", "\":\"");
                Pos370 = "{\"" + centerstr;
                Pos370 = Pos370.ToUpper() + "\"}";
                //":\.Remove(Pos370.LastIndexOf(':'))

                AnalyzingData(Pos370);//解析
            }
            else
            {
                Response.Write("请求串无法解密，解密后为空");
            }
        }
        else
        {
            pagename.Text = "错误信息：错误的访问路径!";
            string message = "<font style='font-size:10pt;color=red'><strong>Error:非法的访问路径!</strong></font></br><hr />";
            message += "<font style='font-size:10pt;'><strong>请求URL：</strong>" + Request.RawUrl + "</br>";
            message += "<strong>客户名称：</strong>" + Request.UserHostName + "</br>";
            message += "<strong>客户端IP：</strong>" + Request.UserHostAddress + "</br>";
            message += "<strong>请求时间：</strong>" + DateTime.Now.ToString() + "</font>";
            Response.Write(message);
            return;
        }
    }
    /*    0：成功
          1：卡不存在
          2：卡已挂失
          3：用户卡密码错误
          4：卡上余额不足本次交易
          5：卡上积分不足本次交易
          6：卡已过期
          7：终端未注册*/
    ///// <summary>
    ///// 数据解析
    ///// </summary>
    ///// <param name="data"></param>
    public void AnalyzingData(string data)
    {
        string RetStr = "";//返回POS的字符串

        SP_POS_ALLParams OParams = new SP_POS_ALLParams();   //签到实例  
        try
        {
            OParams = JavaScriptConvert.DeserializeObject<SP_POS_ALLParams>(data);
            RetStr = SP_POS_TransactionBLL.PosReturnStr(OParams);
            PosId = string.IsNullOrEmpty(OParams.POSSNR) ? PosId : OParams.POSSNR;//终端机号
        }
        catch (Exception ex)
        {
            sb_Log.Append(ex.Message);
            WebHelper.WriteLog(sb_Log.ToString(), PosId, 2,"total");
        }
        finally
        {
            PosReqLog(LogId, PosId, OParams.CMD, Request.RawUrl, Pos370, RetStr);

            sb_Log.Append("[" + DateTime.Now.ToString() + "] 返回的字符串：Rtn：" + RetStr + "\r\n");
            
            RetStr = WebHelper.DES64_Algorithm(RetStr, 1);//pos370加密

            sb_Log.Append("[" + DateTime.Now.ToString() + "] Rtn加密：" + RetStr + "\r\n");
            sb_Log.Append("客户端名称：" + Request.UserHostName + "\r\n");
            sb_Log.Append("客户端IP：" + Request.UserHostAddress + "\r\n");
            sb_Log.Append("-----------------------------------------------------------------------------------------------------------" + "\r\n");
            
            WebHelper.WriteLog(sb_Log.ToString(), PosId, 1,"total");
            //RetStr = "Awkv9/O2LM9N6JkXPWMoJMxaK3jJuyJPKdRtcN0TBeax0XFKex1z8wx5hQttcQi2BMIvi9ge+mfn0CpsCq6l4rMlyNuvt7e/XNRgR10PivKJBOIFiD0e4gR42l9BAcjVoh2uVdfARsDDZ57YSuUzeGFaYMfS1zfxNtPfsgAsPTavKB+vL4gL8/BgMHTyDs0m";//测试
            WebHelper.OutPutRetStr(RetStr);//输出到pos端
        }
    }
    /// <summary>
    /// 记录pos机请求日志
    /// </summary>
    /// <param name="logid"></param>
    /// <param name="posno"></param>
    /// <param name="cmdtype"></param>
    /// <param name="rawurl"></param>
    /// <param name="requrl"></param>
    /// <param name="rtnstr"></param>
    public void PosReqLog(string logid,string posno, string cmdtype, string rawurl, string requrl, string rtnstr)
    {
        LogHelperBLL.PosReqLog(logid, posno, cmdtype, rawurl, requrl, rtnstr);
    }

}
