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
using Ims.Log.BLL;
using Newtonsoft.Json;
using System.Text;
using Ims.Pos.Model;
using Ims.Pos.BLL;
using System.IO;

public partial class InterFace_FunPages_Business : System.Web.UI.Page
{
    StringBuilder sb_Log = new StringBuilder();
    string LogId = "Business_Log" + DateTime.Now.ToString("HHmmssfff");//Logid
    string RetStr = "";
    string PosId = "Unkonwn";
    string json_text = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        WebHelper.SetNoCache();//设置不缓存
        string ClientAgentInfo = Request.UserAgent;
        string ip = Request.UserHostAddress;
        sb_Log.Append("LogId： " + LogId + "\r\n");
        sb_Log.Append("AgentInfo： " + ClientAgentInfo + "\r\n");
        sb_Log.Append("IpAddress： " + ip + "\r\n");
        try
        {
            HttpContext context = this.Context;
            HttpRequest request = context.Request;
            request.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Stream stream = request.InputStream;
            string responseJson = string.Empty;
            if (stream.Length != 0)
            {
                StreamReader streamReader = new StreamReader(stream);
                string jsonReq = streamReader.ReadToEnd();//解码
                //sb_Log.Append("[Business]原始请求数据： " + jsonReq + "\r\n");
                //sb_Log.Append("--------------------------------------------------------\r\n");
                string jsonDecode = Server.UrlDecode(jsonReq);//解码
                //sb_Log.Append("[Business]请求数据解码： " + jsonDecode + "\r\n");
               // sb_Log.Append("--------------------------------------------------------\r\n");
            

                if (!string.IsNullOrEmpty(jsonDecode))
                {
                    json_text = WebHelper.DES64_Algorithm(jsonDecode, 0);//  pos370解密
                    sb_Log.Append("[Business]请求数据明文： " + json_text + "\r\n");
                    sb_Log.Append("--------------------------------------------------------\r\n");
                    input_Business oInput = JavaScriptConvert.DeserializeObject<input_Business>(json_text);
                    PosId = string.IsNullOrEmpty(oInput.POSSNR) ? PosId : oInput.POSSNR;//终端机号
                    RetStr = SP_POS_BusinessBLL.Pos_Trans(oInput);
                }
            }
        }
        catch (Exception ex)
        {
            sb_Log.Append(ex.Message);
        }
        finally
        {
            //PosReqLog(LogId, PosId, "CMD", Request.RawUrl, Pos370, RetStr);

            sb_Log.Append("[" + DateTime.Now.ToString() + "] 返回的明文字符串：Rtn：" + RetStr + "\r\n");
            sb_Log.Append("[" + DateTime.Now.ToString() + "] Rtn加密：" + RetStr + "\r\n");
            sb_Log.Append("客户端名称：" + Request.UserHostName + "\r\n");
            sb_Log.Append("客户端IP：" + Request.UserHostAddress + "\r\n");
            sb_Log.Append("-----------------------------------------------------------------------------------------------------------" + "\r\n");

            WebHelper.WriteLog(sb_Log.ToString(), PosId, 1, "Business");
            WebHelper.OutPutRetStr(RetStr);//输出到pos端
        }
    }
}
