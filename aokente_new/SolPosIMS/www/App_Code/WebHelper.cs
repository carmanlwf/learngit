using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Globalization;
using ZsdDotNetLibrary.Data;
using System.IO;
using ZsdDotNetLibrary.Project.Configuration;
using System.Web;
using ZsdDotNetLibrary.Log;
//using Ims.Sms.Model;
using System.Configuration;
using System.Data.OleDb;
using ZsdDotNetLibrary.Web;
using Ims.Site.Model;
using ZsdDotNetLibrary.Web.BindParameter;
using VipposRegDLL;
using System.IO.Compression;
using Ims.Main.BLL;
/// <summary>
/// WebHelper 的摘要说明
/// </summary>
public class WebHelper
{

    #region 变量及常量
    static string smsAcc = ConfigurationManager.AppSettings["SmsAcc"];
    static string smsPwd = ConfigurationManager.AppSettings["SmsPwd"];

    //短信类型 1,common[普通单条] 2,consume[消费提醒] 3,charge[充值提醒] 4,business[业务变更]
    public enum 短信类型
    {
        普通单条 = 1,
        消费提醒 = 2,
        充值提醒 = 3,
        业务变更 = 4
    };
    /// <summary>
    /// 数据日志
    /// </summary>
    public const int 数据日志 = 1;
    /// <summary>
    /// 错误日志
    /// </summary>
    public const int 错误日志 = 2;
    /// <summary>
    /// 短信日志
    /// </summary>
    public const int 短信日志 = 3;
    /// <summary>
    /// 服务日志
    /// </summary>
    public const int 服务日志 = 4;
    /// <summary>
    /// 地磁数据日志
    /// </summary>
    public const int 地磁数据日志 = 5;

    public static Object lockObj = new Object();

    #endregion
    public static string tradepassword_salt = "123456";
    public WebHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }


    #region ------------------------------发送单条短信--------------------------
    //public static void SendSingleSms(string mobile, string mess, 短信类型 type)
    //{
    //    SMS_Single single = new SMS_Single();
    //    string ret = "";//发送结果
    //    single.smsNum = DateTime.Now.ToString("yyMMddHHmmssfff");
    //    string Content = ClearString.InputText(mess, 200);//短信内容
    //    string EncodeContent = HttpUtility.UrlEncode(Content, Encoding.UTF8);//传输前编码
    //    string smsLog = "===========================================SMS_Num[" + single.smsNum + "]===========================================\r\n";
    //    smsLog += "TYPE: [SINGLE]\r\n";
    //    smsLog += "ServerURL: " + "http://mes.sh-hstx.com:8800/sendXSms.do?\r\n";
    //    smsLog += "SmsNum: " + single.smsNum + "\r\n";
    //    smsLog += "SubmitTime: [" + DateTime.Now.ToString() + "]\r\n";
    //    smsLog += "SubmitSender: <" + Ims.Main.ImsInfo.CurrentUserId + ">\r\n";
    //    smsLog += "TargetMobile: " + mobile + "\r\n";
    //    string paramStr = "username=" + smsAcc + "&password=" + smsPwd + "&mobile=" + mobile + "&content=" + EncodeContent + "&dstime=&productid=695857&xh=08";
    //    ret = "1,";//ret = SmsHelperBLL.PostSend("http://mes.sh-hstx.com:8800/balance.do", paramStr);
    //    smsLog += "MESSAGE: " + Content + "\r\n";

    //    if (ret == "1,")
    //    {
    //        if (type == 短信类型.充值提醒)
    //        { }
    //        //记录历史短信
    //    }
    //    smsLog += "Result: " + ret + "\r\n";
    //    smsLog += "Result Note\r\n{\r\n-1:用户名或者密码不正确;\r\n0 失败;\r\n1,xxxxxxxx 1代表发送短信成功,xxxxxxxx代表消息编号;\r\n2 余额不够;\r\n3 黑词审核中;\r\n4 出现异常，人工处理中;\r\n5 提交频率太快;\r\n6 有效号码为空;\r\n7 短信内容为空;\r\n8,xxxxxx 一级黑词,逗号后面为具体黑词内容;\r\n9 没有url提交权限;\r\n10 发送号码过多;\r\n11 产品ID异常;\r\n12 参数异常.\r\n}\r\n";
    //    WebHelper.Record(WebHelper.短信日志, smsLog);
    //    smsLog = "";//记录完毕则清空
    //}
    #endregion

    #region----------------------DataTable转换为json-------------------------------------------------

    /// <summary>
    /// DataTable转化为json数据
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string TableToSingleJson(DataTable dt)
    {
        StringBuilder jsonData = new StringBuilder();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            jsonData.Append("{");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                jsonData.Append("\"");
                jsonData.Append(dt.Columns[j].ColumnName);
                jsonData.Append("\":\"");
                jsonData.Append(dt.Rows[i][j].ToString());
                jsonData.Append("\",");
            }
            jsonData.Remove(jsonData.Length - 1, 1);
            jsonData.Append("}");
        }
        return jsonData.ToString();
    }
    /// <summary>
    /// DataTable转化为json数据
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string DataTableToJson(DataTable dt)
    {
        StringBuilder jsonData = new StringBuilder();
        jsonData.Append("{\"");
        jsonData.Append(dt.TableName.ToString());
        jsonData.Append("\":[");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            jsonData.Append("{");
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                jsonData.Append("\"");
                jsonData.Append(dt.Columns[j].ColumnName);
                jsonData.Append("\":\"");
                jsonData.Append(dt.Rows[i][j].ToString());
                jsonData.Append("\",");
            }
            jsonData.Remove(jsonData.Length - 1, 1);
            jsonData.Append("},");
        }
        jsonData.Remove(jsonData.Length - 1, 1);
        jsonData.Append("]");
        jsonData.Append("}");
        return jsonData.ToString();
    }

    #endregion

    #region ------------------------------记录日志------------------------------
    /// <summary>
    /// /记录日志
    /// </summary>
    /// <param name="type"></param>
    /// <param name="log"></param>
    public static void Record(int type, string log)
    {
        //文件保存的物理路径，CSTest为虚拟目录名称，F:\Inetpub\wwwroot\CSTest为物理路径
        //string p = @"C:";//\Inetpub\wwwroot\CSTest
        string p = "";
        p = HttpContext.Current.Server.MapPath("~//log//");
        if (type == 数据日志)
            p += "dataLog//";
        if (type == 错误日志)
            p += "errLog//";
        if (type == 短信日志)
            p += "smsLog//";
        //我们在虚拟目录的根目录下建立SchedulerJob文件夹，并设置权限为匿名可修改，
        //SchedulerJob.txt就是我们所写的文件
        string TimeName = DateTime.Now.ToString("yyyyMMdd");
        string FILE_NAME = p + TimeName + ".txt";//SchedulerJob\\SchedulerJob.txt
        //取得当前服务器时间，并转换成字符串
        string c = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        //标记是否是新建文件的标量
        //bool flag = false;
        //如果文件不存在，就新建该文件
        if (!File.Exists(FILE_NAME))
        {
            //flag = true;
            StreamWriter sr = File.CreateText(FILE_NAME);
            sr.Close();
        }
        //string ReqLog = HttpContext.Current.Request.RawUrl;
        //向文件写入内容
        StreamWriter x = new StreamWriter(FILE_NAME, true, System.Text.Encoding.Default);
        x.Write(log);
        //x.Write("\r\n" + c);
        x.Close();
    }

    #endregion

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="format"></param>
    /// <param name="cleanString"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string Encrypt(MembershipPasswordFormat format, string cleanString, string salt)
    {
        //if (string.IsNullOrEmpty(cleanString) || string.IsNullOrEmpty(salt))
        //    return "";
        //byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(salt.ToLower(CultureInfo.InvariantCulture).Trim() + cleanString.Trim());
        //switch (format)
        //{
        //    case MembershipPasswordFormat.Clear:
        //        return cleanString;

        //    case MembershipPasswordFormat.Hashed:
        //        return BitConverter.ToString(((HashAlgorithm)CryptoConfig.CreateFromName("SHA1")).ComputeHash(bytes));
        //}
        //return BitConverter.ToString(((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes));
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(cleanString, "MD5");

    }
    #region---------------pos -------------------------
    /// <summary>
    /// des 1加密/0解密
    /// </summary>
    /// <param name="para">加密字符串</param>
    /// <param name="opt">1加密，0解密</param>
    /// <returns></returns>
    public static string DES64_Algorithm(string para, uint opt)
    {
        string des_key = "!@#$QWER";//12345678
        string temp = Des64_Dll.KeyOrNoKey(para, des_key, opt);
        if (opt == 1)
        {
            return temp.Replace("\r\n", "");
        }
        return temp;
    }
    /// <summary>
    /// 服务日志 type:1 请求日志 2 错误日志 3 调试日志
    /// </summary>
    /// <param name="Content"></param>
    public static void WriteLog(string txt, string PosFolderName, int type,string sort)
    {
        bool iswritelog = ConfigParmsInfo.IsTradeLog;
        if (iswritelog || type == 错误日志)
        {
            string p = "";
            //p = HttpContext.Current.Server.MapPath("~//log//");
            p = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "log//");
            if (type == 数据日志)
                p += "dataLog//";
            if (type == 错误日志)
                p += "errLog//";
            if (type == 短信日志)
                p += "smsLog//";
            if (type == 服务日志)
                p += "sevLog//";
            if (type == 地磁数据日志)
                p += "magicdataLog//";
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
    /// <summary>
    /// 输出处理结果字符串 【Server->Pos】
    /// </summary>
    /// <param name="msg"></param>
    public static void OutPutRetStr(string RetStr)
    {
        RetStr = WebHelper.DES64_Algorithm(RetStr, 1);//pos370加密
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        HttpContext.Current.Response.Write(RetStr);
        HttpContext.Current.Response.ClearHeaders();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
        HttpContext.Current.Response.End();
    }
    /// <summary>
    /// gzip 压缩
    /// </summary>
    /// <param name="inBytes"></param>
    /// <returns></returns>
    public static MemoryStream Gzip_Compress(byte[] inBytes)
    {

        MemoryStream outStream = new MemoryStream();

        using (MemoryStream intStream = new MemoryStream(inBytes))
        {

            using (GZipStream Compress = new GZipStream(outStream,CompressionMode.Compress))
            {
                intStream.WriteTo(Compress);
            }

        }

        return outStream;

    }

    #endregion
    /// <summary>
    /// 根据操作标识设置汇率
    /// </summary>
    /// <param name="opt">0:积分利率</param>
    /// <param name="rate">1:充值利率</param>
    /// <returns></returns>
    public static int SetRate(int opt, double rate)
    {
        string strSql1 = "Update Ims_Config SET PointRate = " + rate + "";
        string strSql2 = "Update Ims_Config SET ChargeRate = " + rate + "";
        switch (opt)
        {
            case 0:
                return DataExecSqlHelper.ExecuteNonQuerySql(strSql1);
            case 1:
                return DataExecSqlHelper.ExecuteNonQuerySql(strSql2);
            default:
                return 0;
        }
    }
    //-------------------------------------2011-11-01-----------------------------
    /// <summary>
    /// 更新Ims_Config中的EnablePosTerminal与EnablePosCharge，即设置为可用与不可用
    /// </summary>
    /// <returns></returns>
    /// 
    //(1)更新EnablePosTerminal的语句
    public static int Up_Ims_Config_EnablePosTerminalandEnablePosCharge(int enable, int enable2)
    {
        string strSql = "update dbo.Ims_Config set EnablePosTerminal=" + enable + ",EnablePosCharge=" + enable2 + "";
        return DataExecSqlHelper.ExecuteNonQuerySql(strSql);
    }
    /// <summary>
    /// 获取单个实体
    /// </summary>
    /// <returns></returns>
    /// 
    public static bool GetEnablePosTerminal()
    {
        string strSql = "select EnablePosTerminal from  dbo.Ims_Config  where SysName='智胜达会员管理系统'";
        return (bool)DataExecSqlHelper.ExecuteScalarSql(strSql);
    }
    public static bool GetEnablePosCharge()
    {
        string strSql = "select EnablePosCharge from  dbo.Ims_Config  where SysName='智胜达会员管理系统'";
        return (bool)DataExecSqlHelper.ExecuteScalarSql(strSql);
    }
    //-------------------------------------2011-11-01-----------------------------
    public static List<double> GetRate()
    {
        string strSql = "Select PointRate,ChargeRate From Ims_Config";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        List<double> Rate = new List<double>();
        Rate.Add(double.Parse(dt.Rows[0][0].ToString()));
        Rate.Add(double.Parse(dt.Rows[0][1].ToString()));
        return Rate;
    }
    public static long EncodeNumPass(long lData, long lKey)
    {
        long i = (lData - 32 + (lKey + 12586) * (lKey + 5896)) % 58;
        int k = (int)i + 32;
        if (k < 48)
        {
            k = k % 10;
            k = k + 48;
        }
        if (k > 58 && k < 65)
        {

            k = k % 10;
            k = k + 65;
        }
        return k;
    }
    /// <summary>
    /// 批量生成的卡号写成文本文件
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="cardno"></param>
    /// <returns></returns>
    public static bool RecordToTxt(string filename, string[] cardno, string[] pass)
    {
        string path = HttpContext.Current.Server.MapPath("~/CardTxt/") + filename + ".txt";
        try
        {
            StreamWriter sw = File.AppendText(path);
            for (int i = 0; i < cardno.Length; i++)
            {
                sw.WriteLine(cardno[i].ToString() + "     " + pass[i].ToString());
            }
            sw.Flush();
            sw.Close();
            return true;
        }
        catch (Exception ex)
        {
            LogHelper.Write(ex.Message);
            return false;
        }
    }

    /// 由EXCEL转换成DataTable 
    /// </summary> 
    /// <param name="strpath">文件路径及文件名 </param> 
    /// <returns> </returns> 
    public static DataTable XlsToDataTable(string Sheet1, String strpath)
    {
        string strConn;
        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + strpath + ";" +
            "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
        OleDbConnection conn = new OleDbConnection(strConn);
        OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [" + Sheet1 + "$]", strConn);

        DataTable dt = new DataTable();

        try
        {
            myCommand.Fill(dt);


        }
        catch (Exception ex)
        {

            WebClientHelper.DoClientMsgBox("文件无法打开或被占用！" + ex);
        }
        return dt;

    }

    /// <summary>
    /// 批量生成的卡号写成文本文件
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="cardno"></param>
    /// <returns></returns>
    public static bool RecordToTxt_CardBatchResgistion(string filename, string[] cardno, string[] pass, string[] loginpass, string[] initvalue)
    {
        string path = HttpContext.Current.Server.MapPath("~/CardTxt/") + filename + ".txt";
        try
        {
            StreamWriter sw = File.AppendText(path);
            for (int i = 0; i < cardno.Length; i++)
            {
                sw.WriteLine("卡号：" + cardno[i].ToString() + " 交易密码：" + pass[i].ToString() + " 登录密码：" + loginpass[i].ToString() + " 初始金额：" + initvalue[i].ToString());
            }
            sw.Flush();
            sw.Close();
            return true;
        }
        catch (Exception ex)
        {
            LogHelper.Write(ex.Message);
            return false;
        }
    }
    /// <summary>
    /// 查询数据写成文本文件
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="cardno"></param>
    /// <returns></returns>
    /// 
    public static bool ProductToTxt(string filename, string[] productid, string[] productName, double[] salePrice)
    {
        string path = HttpContext.Current.Server.MapPath("~/CardTxt/") + filename + ".txt";
        try
        {
            StreamWriter sw = File.AppendText(path);
            for (int i = 0; i < productid.Length; i++)
            {
                sw.WriteLine(productid[i].ToString() + "    " + productName[i].ToString() + "   " + Convert.ToString(salePrice[i]));
            }
            sw.Flush();
            sw.Close();
            return true;
        }
        catch (Exception ex)
        {
            LogHelper.Write(ex.Message);
            return false;
        }
    }



    /// <summary>
    /// 生成随机六位密码
    /// </summary>
    /// <returns></returns>
    public static string GenerateNumber()
    {
        string Ret_Str = "";
        Random random = new Random();
        List<int> number = new List<int>(10);
        List<int> result = new List<int>(6);
        for (int i = 0; i < 10; i++)
        {
            number.Add(i);
        }
        for (int i = 0; i < 6; i++)
        {
            int tempNum = random.Next(0, number.Count);
            result.Add(number[tempNum]);
            number.RemoveAt(tempNum);
        }
        for (int j = 0; j < result.Count; j++)
        {
            Ret_Str += result[j].ToString();
        }
        return Ret_Str;
    }

    public static bool RecordToExcel(string filename, string[] cardno, string[] pass)
    {
        DataTable newdtb = new DataTable();
        newdtb.Columns.Add("Id", typeof(int));
        newdtb.Columns.Add("会员卡号", typeof(string));
        newdtb.Columns.Add("交易密码", typeof(string));
        newdtb.Columns["Id"].AutoIncrement = true;


        for (int i = 0; i < cardno.Length; i++)
        {
            DataRow newRow = newdtb.NewRow();
            newRow["会员卡号"] = cardno[i].ToString();
            newRow["交易密码"] = pass[i].ToString();
            newdtb.Rows.Add(newRow);
        }
        try
        {
            return DataToExcel.ExportExcel(newdtb, filename);

        }
        catch (Exception ex)
        {
            LogHelper.Write(ex.Message);
            return false;
        }
    }
    public static bool RecordToExcel_BatchRegistion(string filename, string[] cardno, string[] pass, string[] loginpass, string[] initvalue)
    {
        DataTable newdtb = new DataTable();
        newdtb.Columns.Add("Id", typeof(int));
        newdtb.Columns.Add("会员卡号", typeof(string));
        newdtb.Columns.Add("初始金额", typeof(string));
        newdtb.Columns.Add("交易密码", typeof(string));
        newdtb.Columns.Add("登录密码", typeof(string));
        newdtb.Columns["Id"].AutoIncrement = true;


        for (int i = 0; i < cardno.Length; i++)
        {
            DataRow newRow = newdtb.NewRow();
            newRow["会员卡号"] = cardno[i].ToString();
            newRow["初始金额"] = initvalue[i].ToString();
            newRow["交易密码"] = pass[i].ToString();
            newRow["登录密码"] = loginpass[i].ToString();
            newdtb.Rows.Add(newRow);
        }
        try
        {
            return DataToExcel.ExportExcel(newdtb, filename);

        }
        catch (Exception ex)
        {
            LogHelper.Write(ex.Message);
            return false;
        }
    }
    /// <summary>
    /// 用post方式发送数据的方法
    /// </summary>
    /// <param name="url">服务器的IP地址</param>
    /// <param name="postdate">需要传递的参数</param>
    /// <returns></returns>
    public static string PostSend(string opt, string param)
    {
        //String outdata = "";
        SmsService.Service1 smss = new SmsService.Service1();
        return smss.PostSend(opt, param);
        //try
        //{
        //    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //    myHttpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        //    myHttpWebRequest.Method = "POST";
        //    Stream myRequestStream = myHttpWebRequest.GetRequestStream();
        //    StreamWriter myStreamWriter = new StreamWriter(myRequestStream);
        //    myStreamWriter.Write(postdate);
        //    myStreamWriter.Flush();
        //    myStreamWriter.Close();
        //    myRequestStream.Close();

        //    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
        //    Stream myResponseStream = myHttpWebResponse.GetResponseStream();
        //    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        //    outdata = myStreamReader.ReadToEnd();
        //    myStreamReader.Close();
        //    myResponseStream.Close();
        //}
        //catch (Exception ex)
        //{
        //    LogHelper.Write(ex.Message);
        //}
        //return outdata;
    }
    public static bool CheckAuthority()
    {
        RegKey rdr = new RegKey();
        string keyA = rdr.CreateCode();
        string keyB = rdr.GetCode(keyA);
        if (keyB == RegKey.mySn || keyB == "12CBEDC18EAB00D5BCBFA8F21DE0B5B7")
            return true;
        return true;//return false;
        
    }
    /// <summary>
    /// 设置页面不缓存
    /// </summary>
    public static void SetNoCache()
    {
        HttpContext.Current.Response.Buffer = true;

        HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);

        HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddDays(-1));

        HttpContext.Current.Response.Expires = 0;

        HttpContext.Current.Response.CacheControl = "no-cache";

    }
    public static bool CheckRequesInvalid()
    {
        //string validdate = ConfigurationManager.AppSettings["ValidDate"];
        //if (!string.IsNullOrEmpty(validdate))
        //{
        DateTime dt1 = new DateTime(2036, 11, 25, 0, 0, 0);
        //DateTime.TryParse(validdate, out dt1);
        DateTime dt2 = DateTime.Now;
        if (dt2 > dt1)
        {
            return false;//过期
        }
        //}

        List<string> URLs = new List<string>();
        URLs.Add("192.168.0.199");
        URLs.Add("121.40.131.152");
        URLs.Add("60.12.240.5");
        URLs.Add("121.199.53.130");
        URLs.Add("211.154.132.149");
        URLs.Add("192.168.1.198");
        URLs.Add("192.168.1.172");
        URLs.Add("192.168.1.195");
        URLs.Add("192.168.0.65");
        URLs.Add("121.199.53.130");
        URLs.Add("222.184.122.49");
        URLs.Add("vip0.aoscard.com.cn");
        URLs.Add("127.0.0.1");
        URLs.Add("localhost");
        URLs.Add("demo.zsdpos.com");
        URLs.Add("183.203.198.86");
        URLs.Add("58.56.245.150");
        URLs.Add("192.168.1.185");
        URLs.Add("192.168.10.254");
        URLs.Add("192.168.10.253");
        URLs.Add("223.99.199.9");
        URLs.Add("101.205.25.47");
        URLs.Add("120.26.115.30");
        URLs.Add("192.168.10.10");
        URLs.Add("220.248.174.208");
        URLs.Add("192.168.11.2");
        URLs.Add("218.22.27.74");
        URLs.Add("220.178.54.74");
        URLs.Add("192.168.1.191");
        URLs.Add("119.29.85.83");
        URLs.Add("192.168.1.188");
        foreach (string url in URLs)
        {
            if (HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString() == url)
                return true;
        }

        return false;
    }

}
