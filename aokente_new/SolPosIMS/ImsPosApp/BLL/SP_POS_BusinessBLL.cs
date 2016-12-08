using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using Ims.Pos.DAL;
using System.Data;
using Ims.Log.BLL;
using System.IO;
using System.Web;
using Ims.Pos.Model.Business;

namespace Ims.Pos.BLL
{
    public class SP_POS_BusinessBLL
    {
        public static Object lockObj = new Object();
        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Pos_Trans(input_Business oInput)
        {
            string RetStr = "";
            string ErrTransId = "";
            string OkTransId = "";
            string successid = "";
            int FailCount = 0;
            output_Business oOutput = new output_Business();
            for (int i = 0; i < oInput.BusinessItems.Count; i++)
            {
                BusinessObjects oBusObj = oInput.BusinessItems[i];
                try
                {
                    oOutput = SP_POS_BusinessDAL.Pos_Trans(oInput.POSSNR, oInput.VERSION, oBusObj);

                }
                catch
                {
                }
                finally
                {
                    if (oOutput.FLAG != "0" || string.IsNullOrEmpty(oOutput.FLAG)) //这里仅仅借用变量传地址，不代表最终结果
                    {
                        FailCount += 1;
                        ErrTransId += oBusObj.CredenceSnr;
                        ErrTransId += ",";
                    }
                    else
                    {
                        OkTransId += oBusObj.CredenceSnr;
                        OkTransId += ",";
                        successid += "'" + oBusObj.CredenceSnr + "',";
                    }
                }
            }
            if (FailCount > 0)
            {
                //oOutput.FLAG = "-1";//代表回传给app的最终结果
                oOutput.MESSAGE = ErrTransId.TrimEnd(',');//不为空，说明有没有成功执行的记录(主要从业务层面判断,如果整个函数异常,则有可能返回空)
            }
            else
            {
                oOutput.FLAG = "0";//代表回传给app的最终结果
                oOutput.MESSAGE = "";
            }

            oOutput.RecordIDs_OK = OkTransId.TrimEnd(',');//成功的id回传给app
            RetStr = JavaScriptConvert.SerializeObject(oOutput);
            successid = successid.TrimEnd(',');
            DataTable dt = SP_POS_BusinessDAL.uploadParkingRecord(successid);
            List<ParkingRecord> list = new List<ParkingRecord>();
            if (null != dt && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    ParkingRecord temp = new ParkingRecord();
                    temp.credencesnr = dt.Rows[i]["CredenceSnr"].ToString();
                    temp.cardsnr = dt.Rows[i]["CardSnr"].ToString();
                    temp.cardtype = dt.Rows[i]["CardType"].ToString();
                    temp.sitename = dt.Rows[i]["sitename"].ToString();
                    temp.backbyte = dt.Rows[i]["BackByte"].ToString();
                    temp.mode = Convert.ToInt32(dt.Rows[i]["Mode"].ToString());
                    temp.userid = dt.Rows[i]["UserID"].ToString();
                    temp.possnr = dt.Rows[i]["PosSnr"].ToString();
                    temp.money = Convert.ToDecimal(dt.Rows[i]["Money"].ToString());
                    temp.giving = Convert.ToDecimal(dt.Rows[i]["giving"].ToString());
                    temp.realmoney = Convert.ToDecimal(dt.Rows[i]["RealMoney"].ToString());
                    temp.returnmoney = Convert.ToDecimal(dt.Rows[i]["ReturnMoney"].ToString());
                    temp.starttime = dt.Rows[i]["StartTime"].ToString();
                    temp.endtime = dt.Rows[i]["EndTime"].ToString();
                    temp.sysid = dt.Rows[i]["SysID"].ToString();
                    temp.memo = dt.Rows[i]["SysID"].ToString();

                    list.Add(temp);
                }
            }

            if (list.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                try
                {                   
                    string str = JavaScriptConvert.SerializeObject(list);
                    string uploadUrl = ConfigurationManager.AppSettings["uploadUrl"];
                    if (string.IsNullOrEmpty(uploadUrl))
                        return RetStr;

                    //str = System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.UTF8);
                    byte[] bs = Encoding.UTF8.GetBytes(str);
                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "开始上传停车记录，请求URL:" + uploadUrl + "\r\n");
                    sb.Append("发送的数据是:" + str + "\r\n");
                    DateTime dtStart = DateTime.Now;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uploadUrl);
                    request.Timeout = 10000;
                    request.Method = "POST";
                    request.Headers.Add("token", "069f2789-d0fc-47b6-a863-19ea08ef5f84-1461293420057");
                    //request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentType = "application/json;charset=utf-8";
                    request.ContentLength = bs.Length;
                    request.GetRequestStream().Write(bs, 0, bs.Length);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    DateTime dtEnd = DateTime.Now;
                    int repSec = (dtEnd - dtStart).Seconds;
                    Stream ResStream = response.GetResponseStream();
                    Encoding encoding = Encoding.GetEncoding("utf-8");
                    StreamReader streamReader = new StreamReader(ResStream, encoding);
                    string RetStr1 = streamReader.ReadToEnd();
                    streamReader.Close();
                    RetStr1 = System.Web.HttpUtility.UrlDecode(RetStr1);
                    sb.Append("服务器返回数据:" + RetStr1 + "\r\n");
                    sb.Append("[" + dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "]" + "请求结束.累计耗时:" + repSec + "秒.\r\n");
                }
                catch (Exception ex)
                {
                    WriteLog(ex.Message.ToString() + "\r\n", "ServerErr", "uploadData");
                }
                WriteLog(sb.ToString() + "\r\n", "uploadData", "uploadData");
               
            }
            return RetStr;
        }

        public static void WriteLog(string txt, string PosFolderName, string sort)
        {
            
                string p = "";
                //p = HttpContext.Current.Server.MapPath("~//log//");
                p = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "log//");
                p += "uploadData//";
                string folderName = DateTime.Now.Date.ToString("yyyyMMdd");

                if (Directory.Exists(p + folderName + "/" + PosFolderName) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(p + folderName + "/" + PosFolderName);
                }
                string path = "";
                path = p + folderName + "/" + PosFolderName + "/";//Log//文件夹名//pos机号名称

                string FILE_NAME = path + "Log_" + sort + folderName + ".txt";//SchedulerJob\\SchedulerJob.txt

                try
                {

                    lock (lockObj)
                    {

                        //如果文件不存在，就新建该文件
                        if (!File.Exists(FILE_NAME))
                        {
                            //flag = true;
                            StreamWriter sr = File.CreateText(FILE_NAME);
                            sr.Close();
                        }
                        //向文件写入内容
                        StreamWriter x = new StreamWriter(FILE_NAME, true, System.Text.Encoding.Default);
                        x.Write(txt);
                        x.Close();
                    }
                }
                catch
                {
                }
           

        }

        
    }
}
