using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using ZsdDotNetLibrary.Data;

/// <summary>
///ComunicationHelper 的摘要说明
/// </summary>
public class ComunicationHelperDAL
{
    public ComunicationHelperDAL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 根据业务需求传入不同的请求参数获取相应的数据
    /// </summary>
    /// <param name="urlParms"></param>
    /// <returns></returns>
    public static JsonResponse CallDCCloudService(string urlParms)
    {
        string DCCServiceURL = ConfigurationManager.AppSettings["DCCloundServiceURL"];
        string url_test = DCCServiceURL + urlParms;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_test);
        request.Timeout = 10000;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream ResStream = response.GetResponseStream();
        Encoding encoding = Encoding.GetEncoding("utf-8");
        StreamReader streamReader = new StreamReader(ResStream, encoding);
        string RetStr = streamReader.ReadToEnd();
        streamReader.Close();
        JsonResponse jr_object = JavaScriptConvert.DeserializeObject<JsonResponse>(RetStr);
        return jr_object;
    }
    /// <summary>
    /// 根据业务需求传入不同的请求参数获取相应的数据(单独查询地磁状态用)
    /// </summary>
    /// <param name="urlParms"></param>
    /// <returns></returns>
    public static Status_Json_Response CallDCCloudService_GetMagicStatus(string posnum,string urlParms)
    {
        Status_Json_Response jr_object = new Status_Json_Response();
        StringBuilder sb = new StringBuilder();
        try
        {
            string DCCServiceURL = ConfigurationManager.AppSettings["DCCloundServiceURL"];
            string url_test = DCCServiceURL + urlParms;
            sb.Append("[获取地磁状态服务开始] 客户端请求URL:" + url_test + "\r\n");
            DateTime dtStart = DateTime.Now;
            sb.Append("[" + dtStart.ToString() + "]" + "请求开始..." + "\r\n");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_test);
            request.Timeout = 30000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            DateTime dtEnd = DateTime.Now;
            int repSec = (dtEnd - dtStart).Seconds;
            sb.Append("[" + dtEnd.ToString() + "]" + "请求结束.累计耗时:" + repSec + "秒.\r\n");
            Stream ResStream = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(ResStream, encoding);
            string RetStr = streamReader.ReadToEnd();
            sb.Append("[获取地磁状态服务结束] 服务器返回URL:" + RetStr + "\r\n");
            streamReader.Close();
            jr_object = JavaScriptConvert.DeserializeObject<Status_Json_Response>(RetStr);
        }
        catch (Exception ex)
        {
            WebHelper.WriteLog(ex.Message.ToString() + "\r\n", "ServerErr", WebHelper.服务日志, "clound");
        }
        WebHelper.WriteLog(sb.ToString() + "\r\n", posnum, WebHelper.服务日志, "magic");
        return jr_object;
    }
    /// <summary>
    /// Json 字符串 转换为 DataTable数据集合
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static DataTable JsonToDataTable(string json)
    {
        DataTable dataTable = new DataTable();  //实例化
        DataTable result;
        try
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
            if (arrayList.Count > 0)
            {
                foreach (Dictionary<string, object> dictionary in arrayList)
                {
                    if (dictionary.Keys.Count<string>() == 0)
                    {
                        result = dataTable;
                        return result;
                    }
                    if (dataTable.Columns.Count == 0)
                    {
                        foreach (string current in dictionary.Keys)
                        {
                            dataTable.Columns.Add(current, dictionary[current].GetType());
                        }
                    }
                    DataRow dataRow = dataTable.NewRow();
                    foreach (string current in dictionary.Keys)
                    {
                        dataRow[current] = dictionary[current];
                    }

                    dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        result = dataTable;
        return result;
    }


    public static outputMagicStatus getMagicStatus(string urlParms)
    {
        outputMagicStatus jr_object = new outputMagicStatus();
        //StringBuilder sb = new StringBuilder();
        string DCCServiceURL = ConfigurationManager.AppSettings["DCCloundServiceURL"];
        StringBuilder sb = new StringBuilder();
        List<magicStatus> templist = null;
        try
        {
            string url_test = DCCServiceURL + urlParms;
            sb.Append("[获取地磁状态服务开始] 客户端请求URL:" + url_test + "\r\n");
            DateTime dtStart = DateTime.Now;
            sb.Append("[" + dtStart.ToString() + "]" + "请求开始..." + "\r\n");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_test);
            request.Headers.Add("token", "3916a474-dd08-4ffd-b4c3-cd4ca86c3d76-1461897117165");
            request.Timeout = 30000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            DateTime dtEnd = DateTime.Now;
            int repSec = (dtEnd - dtStart).Seconds;
            sb.Append("[" + dtEnd.ToString() + "]" + "请求结束.累计耗时:" + repSec + "秒.\r\n");
            Stream ResStream = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader streamReader = new StreamReader(ResStream, encoding);
            string RetStr = streamReader.ReadToEnd();

            streamReader.Close();
            RetStr = System.Web.HttpUtility.UrlDecode(RetStr);
            sb.Append("[获取地磁状态服务结束] 服务器返回数据:" + RetStr + "\r\n");
            jr_object = JavaScriptConvert.DeserializeObject<outputMagicStatus>(RetStr);
            if (null != jr_object.body && jr_object.body.Count() > 0)
            {
                updateParkSiteStatus(jr_object.body);
            }
            else
            {
                WebHelper.WriteLog("返回消息是" + jr_object.message + ", 结果码是" + jr_object.status + ", 描述" + jr_object.message + "\r\n", "ServerRee", WebHelper.错误日志, "magic");
            }
        }
        catch (Exception ex)
        {
            WebHelper.WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ex.Message.ToString() + "\r\n", "ServerErr", WebHelper.服务日志, "clound");
        }
        WebHelper.WriteLog(sb.ToString() + "\r\n", "magic", WebHelper.服务日志, "magic");
        return jr_object;
    }

    public static string getMagicStatusByName(string urlParms,string parmname)
    {
        outputMagicStatus jr_object = new outputMagicStatus();
        //StringBuilder sb = new StringBuilder();
        string DCCServiceURL = ConfigurationManager.AppSettings["DCCloundServiceURL"];
        StringBuilder sb = new StringBuilder();
        string RetStr = "";
        try
        {
            string url_test = DCCServiceURL + urlParms;
            sb.Append("[获取地磁ID开始] 客户端请求URL:" + url_test + ":"+parmname + "\r\n");
            DateTime dtStart = DateTime.Now;
            sb.Append("[" + dtStart.ToString() + "]" + "请求开始..." + "\r\n");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_test);
            request.Headers.Add("token", "3916a474-dd08-4ffd-b4c3-cd4ca86c3d76-1461897117165");
            request.Timeout = 30000;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //DateTime dtEnd = DateTime.Now;
            //int repSec = (dtEnd - dtStart).Seconds;
            //sb.Append("[" + dtEnd.ToString() + "]" + "请求结束.累计耗时:" + repSec + "秒.\r\n");
            //Stream ResStream = response.GetResponseStream();
            //Encoding encoding = Encoding.GetEncoding("utf-8");
            //StreamReader streamReader = new StreamReader(ResStream, encoding);
            //string RetStr = streamReader.ReadToEnd();

            //streamReader.Close();
            //RetStr = System.Web.HttpUtility.UrlDecode(RetStr);
            RetStr = HttpPostStr(url_test, "{\"name\":\"" + parmname + "\"}");
            //sb.Append("[获取ID服务结束] 服务器返回数据:" + RetStr + "\r\n");
            //jr_object = JavaScriptConvert.DeserializeObject<outputMagicStatus>(RetStr);
            //if (null != jr_object.body && jr_object.body.Count() > 0)
            //{
            //    updateParkSiteStatus(jr_object.body);
            //}
            //else
            //{
            //    WebHelper.WriteLog("返回消息是" + jr_object.message + ", 结果码是" + jr_object.status + ", 描述" + jr_object.message + "\r\n", "ServerRee", WebHelper.错误日志, "magic");
            //}
        }
        catch (Exception ex)
        {
            WebHelper.WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ex.Message.ToString() + "\r\n", "ServerErr", WebHelper.服务日志, "clound");
        }
        WebHelper.WriteLog(sb.ToString() + "\r\n", "magic", WebHelper.服务日志, "magic");
        return RetStr;
    }


    public static int updateParkSiteStatus(List<magicStatus> objects)
    {
        int success_count = 0;
        for (int i = 0; i < objects.Count; i++)
        {
            //string info = objects[i].info.Substring(objects[i].info.Length - 6, 2);//FE 0C C1 00 04 FF FF 03 03 22 22 02 01 00 55 (4号地磁有回应)
            //int state = int.Parse(info);
            int state = objects[i].status;
            //根据地磁mac更新车位状态（条件：mac相同，updatetime 要晚于传过来的记录时间 且地磁状态有变化的记录）
            string strSQL = "UPDATE park_parkingsite SET isbusy = " + state + ",updatetime = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',updateway='cloud' WHERE magicid = '" + objects[i].mac + "' And isbusy <> " + state + "";
            try
            {
                if (DataExecSqlHelper.ExecuteNonQuerySql(strSQL) > 0)
                    WebHelper.WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "地磁状态发生变化，车位号是：" + objects[i].carportNumber + "，状态是：" + state + "\r\n", "record", WebHelper.地磁数据日志, "record");
                success_count += 1;
            }
            catch (Exception ex)
            {
                WebHelper.WriteLog(ex.Message + "\r\n", "errorlog", 2, "magic");
                continue;
            }

        }
        return success_count;
    }


    /// <summary>
    /// Post请求
    /// </summary>
    /// <param name="Url">url地址</param>
    /// <param name="postDataStr">提交数据</param>
    /// <returns></returns>
    public static string HttpPostStr(string Url, string postDataStr)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        WebHeaderCollection headers = request.Headers;
        headers.Add("token:3916a474-dd08-4ffd-b4c3-cd4ca86c3d76-1461897117165");
        request.Method = "POST";
        request.ContentType = "application/json;charset=utf-8";
        //     request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
        Stream myRequestStream = request.GetRequestStream();
        StreamWriter myStreamWriter = new StreamWriter(myRequestStream);
        myStreamWriter.Write(postDataStr);
        myStreamWriter.Close();
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream myResponseStream = response.GetResponseStream();
        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        string retString = myStreamReader.ReadToEnd();
        myStreamReader.Close();
        myResponseStream.Close();
        return retString;
    }





}
