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
using ZsdDotNetLibrary.Data;
using System.Collections.Generic;
using System.Threading;

/// <summary>
///DataCenterHelperDAL 的摘要说明
/// </summary>
public class DataCenterHelperDAL
{
    public DataCenterHelperDAL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 由网关直接发送地磁数据来保存入库，并返回入库结果
    /// </summary>
    /// <param name="status"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    public static string ReceiveMagicData(List<magicdata> objects,string ip)
    {
        string failMacs = "";
        for (int i = 0; i < objects.Count; i++)
        {
            string serialno = System.Guid.NewGuid().ToString(); 
            magicdata mdata = objects[i];
            string state = "Unknown";
            string recordtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (!string.IsNullOrEmpty(mdata.createTime))
            {
                recordtime = CommunicationHelperBLL.StampToDateTime(mdata.createTime.Remove(mdata.createTime.Length - 3, 3)).ToString("yyyy-MM-dd HH:mm:ss");
            }
            if(mdata!= null&&!string.IsNullOrEmpty(mdata.infor))
                state = mdata.infor.Substring(mdata.infor.Length - 6, 2);//FE 0C C1 00 04 FF FF 03 03 22 22 02 01 00 55 (4号地磁有回应)
            string strSQL = "INSERT INTO magic_receivedata(transid,mac,infor,isalarm,descr,createTime,updatetime,ipAddress)VALUES('" + serialno + "','" + mdata.mac + "','" + mdata.infor + "','" + state + "','" + mdata.descr + "','" + mdata.createTime + "','" + recordtime + "','" + ip + "')";
            try
            {
                DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
            }
            catch (Exception ex)
            {
                failMacs += mdata.mac;
                failMacs += ",";
                WebHelper.WriteLog(DateTime.Now.ToString() + " " + ex.Message + "\r\n 入库操作时出错的地磁mac集合:" + failMacs + "\r\n 执行sql:" + strSQL+" 时失败.\r\n", "receiveError", 2, "magic");
                continue;
            }
            Thread.Sleep(20);

        }
        failMacs = failMacs.TrimEnd(',');//成功返回空，失败返回逗号隔开的mac 和地磁厂家郑工沟通因为地磁状态信息周期性上传，暂不设置重传机制。
        return failMacs;
    }
}
