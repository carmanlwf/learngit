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
using System.IO;
using System.Text;
using Newtonsoft.Json;

public partial class InterFace_FunPages_datacenter : System.Web.UI.Page
{
    StringBuilder sb_Log = new StringBuilder();
    string LogId = "magicdataLog" + DateTime.Now.ToString("HHmmssfff");//Logid
    string RetStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        WebHelper.SetNoCache();//设置不缓存
        string ClientAgentInfo = Request.UserAgent;
        string ip = Request.UserHostAddress;
        string jsonReq = "";
        sb_Log.Append("LogId： " + LogId + "\r\n");
        sb_Log.Append("AgentInfo： " + ClientAgentInfo + "\r\n");
        sb_Log.Append("IpAddress： " + ip + "\r\n");
        outputMagicData ouputData = new outputMagicData();
        string rets = "";
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
                //string jsontext = Server.UrlDecode(streamReader.ReadToEnd());//解码
                jsonReq = streamReader.ReadToEnd();//解码
                //json = jsontext.Replace("\\", "");
                sb_Log.Append("[magicdata]原始请求数据： " + jsonReq + "\r\n");
                if (!string.IsNullOrEmpty(jsonReq) && jsonReq.Length > 15)
                {
                    sb_Log.Append("[magicdata]处理前数据： " + jsonReq + "\r\n");
                    inputMagicData oInput = JavaScriptConvert.DeserializeObject<inputMagicData>(jsonReq);
                    rets = DataCenterHelperBLL.ReceiveMagicData(oInput.dataitems,ip);
                    if (rets == "")//成功
                    {
                        ouputData.success = "true";
                        ouputData.message = "";
                    }
                }
                else
                {
                    ouputData.success = "false";
                    ouputData.message = "wrong json string";
                }
            }
        }
        catch (Exception ex)
        {
            ouputData.success = "false";
            ouputData.message = rets ;//错误的mac
            sb_Log.Append(DateTime.Now.ToString() + " " + ex.Message + "\r\n 数据接收时出错,地磁mac集合:" + rets );
            //WebHelper.WriteLog(DateTime.Now.ToString() + " " + ex.Message + "\r\n 数据接收时出错,地磁mac集合:" + rets + "\r\n原始请求的json串:" + jsonReq + "\r\n", "receiveError", 2, "magic");
        }
        finally
        {
            RetStr = JavaScriptConvert.SerializeObject(ouputData);
            sb_Log.Append(DateTime.Now.ToString() + " " + "[magicdata]返回数据： " + RetStr + "\r\n");
            WebHelper.WriteLog(sb_Log.ToString() + "\r\n", "magicdata", WebHelper.数据日志, "mdata");
            WebHelper.OutPutRetStr(RetStr);//输出到pos端
        }
    }
}
