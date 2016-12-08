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
using System.IO;
using Ims.Pos.Model;
using Newtonsoft.Json;

public partial class InterFace_FunPages_errReport : System.Web.UI.Page
{
    StringBuilder sb_Log = new StringBuilder();
    string LogId = "Error_Log" + DateTime.Now.ToString("HHmmssfff");//Logid
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
        output_errReport oOutput = new output_errReport();
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
                //
                string jsonReq = streamReader.ReadToEnd();//
                sb_Log.Append("["+DateTime.Now.ToString()+"]\r\n");
                sb_Log.Append("[errRep]原始请求数据： " + jsonReq + "\r\n");

                //sb_Log.Append("[errRep]解码后的数据： " + jsonReq + "\r\n");
                //json_text = WebHelper.DES64_Algorithm(jsonReq, 0);//  pos370解密
                //sb_Log.Append("[errRep]请求数据明文： " + json_text + "\r\n");
                if (!string.IsNullOrEmpty(jsonReq))
                {
                    input_errReport oInput = JavaScriptConvert.DeserializeObject<input_errReport>(jsonReq);
                    oInput.repContent = Server.UrlDecode(oInput.repContent);//将错误详情decode
                    sb_Log.Append("错误发生时间:" + oInput.repTime + "\r\n");
                    sb_Log.Append("错误详情:\r\n");
                    sb_Log.Append("-------------------------------------------------------------------------\r\n" + oInput.repContent + "\r\n");
                    PosId = string.IsNullOrEmpty(oInput.POSSNR) ? PosId : oInput.POSSNR;//终端机号
                    oOutput.MESSAGE = "";
                    oOutput.FLAG = "0";

                }
                else
                {
                    oOutput.MESSAGE = "string length is 0";
                    oOutput.FLAG = "1";
                }
            }
        }
        catch (Exception ex)
        {
            sb_Log.Append(ex.Message);
            oOutput.MESSAGE = ex.Message;
            oOutput.FLAG = "1";
        }
        finally
        {
            RetStr = JavaScriptConvert.SerializeObject(oOutput);
            sb_Log.Append("[" + DateTime.Now.ToString() + "] 返回的明文字符串：Rtn：" + RetStr + "\r\n");
            sb_Log.Append("客户端名称：" + Request.UserHostName + "\r\n");
            sb_Log.Append("客户端IP：" + Request.UserHostAddress + "\r\n");
            sb_Log.Append("-----------------------------------------------------------------------------------------------------------" + "\r\n");
            WebHelper.WriteLog(sb_Log.ToString(), PosId, 2, "errReport");
            
            WebHelper.OutPutRetStr(RetStr);//输出到pos端
        }
    }
}
