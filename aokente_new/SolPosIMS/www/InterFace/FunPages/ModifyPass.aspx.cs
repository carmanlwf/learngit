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
using Newtonsoft.Json;
using System.Text;
using Ims.Pos.Model.ModifyPass;
using Ims.Pos.BLL;

public partial class InterFace_FunPages_ModifyPass : System.Web.UI.Page
{

    StringBuilder sb_Log = new StringBuilder();
    string LogId = "ModifyPass_Log" + DateTime.Now.ToString("HHmmssfff");//Logid
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
            sb_Log.Append("[" + DateTime.Now.ToString() + "] ReqParmas：" + str + "\r\n ");
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

    public void AnalyzingData(string data)
    {
        string RetStr = "";//返回POS的字符串
        string RetStr_ecode = "";
        input_ModifyPass oInput = new input_ModifyPass();
        try
        {
            oInput = JavaScriptConvert.DeserializeObject<input_ModifyPass>(data);
            PosId = string.IsNullOrEmpty(oInput.POSSNR) ? PosId : oInput.POSSNR;//终端机号
            RetStr = ModifyPassHelperBLL.modifyPass(oInput);
        }
        catch (Exception ex)
        {
            sb_Log.Append(ex.Message);
        }
        finally
        {

            sb_Log.Append("[" + DateTime.Now.ToString() + "] 返回的字符串：Rtn：" + RetStr + "\r\n");
            sb_Log.Append("[" + DateTime.Now.ToString() + "] Rtn编码：" + RetStr_ecode + "\r\n");
            sb_Log.Append("[" + DateTime.Now.ToString() + "] Rtn加密：" + RetStr + "\r\n");
            sb_Log.Append("客户端名称：" + Request.UserHostName + "\r\n");
            sb_Log.Append("客户端IP：" + Request.UserHostAddress + "\r\n");
            sb_Log.Append("-----------------------------------------------------------------------------------------------------------" + "\r\n");

            WebHelper.WriteLog(sb_Log.ToString(), PosId, 1, "modifyPass");
            WebHelper.OutPutRetStr(RetStr);//输出到pos端
        }
    }
}
