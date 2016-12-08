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
using System.Text;
using Ims.Pos.Model;
using Newtonsoft.Json;
using Ims.Pos.BLL;
using Ims.Log.BLL;

public partial class InterFace_FunPages_SignOut : System.Web.UI.Page
{
    StringBuilder sb_Log = new StringBuilder();
    string LogId = "SignOut_Log" + DateTime.Now.ToString("HHmmssfff");//Logid
    string PosId = "Defalut";
    string Pos370 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        WebHelper.SetNoCache();//设置不缓存
        sb_Log.Append("LogId： " + LogId + "\r\n");
        sb_Log.Append("RawURL：" + Request.RawUrl + "\r\n");// 
        sb_Log.Append("ServerURL：" + Request.Url.Host.ToString() + ":" + Request.Url.Port.ToString() + "\r\n");// 
        if (!string.IsNullOrEmpty(Request.QueryString["DATA"]))
        {
            string str = Request.QueryString["DATA"].ToString();//请求内容
            sb_Log.Append("[" + DateTime.Now.ToString() + "] ReqParmas：" + str + "\r\n");
            Pos370 = WebHelper.DES64_Algorithm(str, 0);//  pos370解密        

            sb_Log.Append("[" + DateTime.Now.ToString() + "] ReqDecrypt：" + Pos370 + "\r\n");//  
            Pos370 = ClearString.InputText(Pos370, 1024);//过滤敏感字符
            if (!string.IsNullOrEmpty(Pos370))
            {
                AnalyzingData(Pos370);//解析
            }
            else
            {
                Response.Write("请求串无法解密，解密后为空!");
            }
        }
        else
        {
            Response.Write("参数为空,无法解析.");
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

        input_SignOut oInput = new input_SignOut();
        try
        {
            oInput = JavaScriptConvert.DeserializeObject<input_SignOut>(data);
            RetStr = SP_POS_SignOutBLL.Pos_Out(oInput);
            PosId = string.IsNullOrEmpty(oInput.POSSNR) ? PosId : oInput.POSSNR;//终端机号
        }
        catch (Exception ex)
        {
            sb_Log.Append(ex.Message);
        }
        finally
        {

            sb_Log.Append("[" + DateTime.Now.ToString() + "] 返回的字符串：Rtn：" + RetStr + "\r\n");
            sb_Log.Append("[" + DateTime.Now.ToString() + "] Rtn加密：" + RetStr + "\r\n");
            sb_Log.Append("客户端名称：" + Request.UserHostName + "\r\n");
            sb_Log.Append("客户端IP：" + Request.UserHostAddress + "\r\n");
            sb_Log.Append("-----------------------------------------------------------------------------------------------------------" + "\r\n");

            WebHelper.WriteLog(sb_Log.ToString(), PosId, 1,"signout");
            
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
    public void PosReqLog(string logid, string posno, string cmdtype, string rawurl, string requrl, string rtnstr)
    {
        LogHelperBLL.PosReqLog(logid, posno, cmdtype, rawurl, requrl, rtnstr);
    }

}

