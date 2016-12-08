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
using System.Collections.Generic;
using ZsdDotNetLibrary.Project.DAL;
using Newtonsoft.Json;
using Jayrock.Json;
using System.Web.UI.MobileControls;
using Ims.Site.Model;
using Ims.Site.BLL;
using System.Text;
using Ims.Pos.Model;
using Ims.Pos.BLL;
using System.Data;
/// <summary>
///CommunicationHelperBLL 的摘要说明
/// </summary>
public class CommunicationHelperBLL
{
    public CommunicationHelperBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 生产设备列表
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortedBy"></param>
    /// <param name="o"></param>
    /// <returns></returns>
    public static List<JsongItems> GetPagedObjects_Repeater(int startIndex, int pageSize, string sortedBy, JsongItems o)
    {
        string parmsStr = "getDevices.do?page=1&start=0&limit=100&applicationId=f257031f4dec1168014dec12d00a000f&startTime=&devType=GATEWAY";
        JsonResponse jr_object = ComunicationHelperDAL.CallDCCloudService(parmsStr);
        DataTable dt = new DataTable();
        List<JsongItems> objects = new List<JsongItems>();
        jr_object.items.OrderBy(p => p.createTime).Distinct();
        objects = jr_object.items;
        return objects;
    }
    /// <summary>
    /// 记录行数
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static int GetObjectsCount_Repeater(JsongItems o)
    {
        string parmsStr = "getDevices.do?page=1&start=0&limit=100&applicationId=f257031f4dec1168014dec12d00a000f&startTime=&devType=GATEWAY";
        JsonResponse jr_object = ComunicationHelperDAL.CallDCCloudService(parmsStr);
        return jr_object.total;
    }
    /// <summary>
    /// 生产设备列表
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortedBy"></param>
    /// <param name="o"></param>
    /// <returns></returns>
    public static List<JsongItems> GetPagedObjects_Magic(int startIndex, int pageSize, string sortedBy, JsongItems o)
    {
        string parmsStr = "getChildDevices.do?applicationId=f257031f4dec1168014dec12d00a000f&mac=" + o.mac;
        JsonResponse jr_object = ComunicationHelperDAL.CallDCCloudService(parmsStr);
        //dt = ComunicationHelperDAL.JsonToDataTable(jr_object.items.ToString());
        List<JsongItems> objects = new List<JsongItems>();
        jr_object.items.OrderByDescending(p => p.updateTime).Distinct();
        objects = jr_object.items;
        return objects;
    }
    /// <summary>
    /// 记录行数
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static int GetObjectsCount_Magic(JsongItems o)
    {
        string parmsStr = "getChildDevices.do?applicationId=f257031f4dec1168014dec12d00a000f&mac=" + o.mac;
        JsonResponse jr_object = ComunicationHelperDAL.CallDCCloudService(parmsStr);
        return jr_object.total;
    }
    /// <summary>
    /// 根据设备号获取所在车场的所有车位状态
    /// </summary>
    /// <param name="posnum"></param>
    /// <returns></returns>
    public static string GetParkingSiteStatus(string posnum, int timespan)
    {

        output_Magic oOutput = new output_Magic();
        /***********************************************取消对云端的依赖开始*****************************************************
        ***********************************************2015-07-07经和地磁厂家郑工确认，由网关直接上传数据给后台************
        ***********************************************修改人:赵鹏 修改内容:取消对云端的依赖，解决数据超时问题**************
        if (timespan <= 1)
        {
            timespan = 10 ;
        }
        long start_time = (DateTimeToStamp(DateTime.Now)) * 1000 - timespan * 1000;
        long end_time = (DateTimeToStamp(DateTime.Now)) * 1000;
        //List<v_parkingsiteinfo> ov_parkingsiteinfo = new List<v_parkingsiteinfo>();
        //ov_parkingsiteinfo = parkingsiteinfoHelper.GetObjects(posnum);//P-20150618094651

        string macs = parkingsiteinfoHelper.GetMacsByPosNum(posnum);
        string mac_count = "0";
        if (!string.IsNullOrEmpty(macs))
        {
            string[] strArray = macs.Split(',');
            mac_count = (strArray.Length-1).ToString();
        }

        //string parmsStr = "getDeviceDatas.do?page=1&start=0&limit=100&applicationId=f257031f4dec1168014dec12d00a000f&macs=" + macs +"&startTime=" + start_time.ToString() + "&endTime=" + end_time.ToString();
        string parmsStr = "getDeviceDatas.do?page=1&start=0&limit=" + mac_count + "&applicationId=f257031f4dec1168014dec12d00a000f&macs=" + macs.TrimEnd(',');
        Status_Json_Response sjr_object = ComunicationHelperDAL.CallDCCloudService_GetMagicStatus(posnum,parmsStr);

        if (sjr_object.items == null || sjr_object.items.Count <= 0)
        {
            oOutput.FLAG = "0";//1表示没有数据，但访问成功
            //oOutput.MESSAGE = POS＿CommunicationHelper.GetErrMsgByErrCode(oOutput.FLAG);
            oOutput.sitestatuslist = new List<SiteStatusObject>();
            oOutput = GetMagicStatusHelperDAL.GetParkingSiteStatus(posnum);//获取最新的车位状态对照表

        }
        else// 结果集合不为空时批量更新车位状态，并将对应关系回传给APP
        {
            sjr_object.items.OrderByDescending(p => p.createTime).Distinct();
            List<MagicStatusList> objects_MagicStatus = sjr_object.items;
            List<SiteMacAndStatus> SiteMacAndStatus = new List<SiteMacAndStatus>();
            foreach (MagicStatusList oMagic in objects_MagicStatus)
            {
                string dataTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (!string.IsNullOrEmpty(oMagic.createTime) && oMagic.createTime.Length >= 3)
                {
                    dataTime = oMagic.createTime.Remove(oMagic.createTime.Length - 3, 3);
                    dataTime = StampToDateTime(dataTime).ToString("yyyy-MM-dd HH:mm:ss");//将createtime格式化
                }

                SiteMacAndStatus.Add(new SiteMacAndStatus(oMagic.mac, oMagic.infor, dataTime));
            }
            //更新车位状态
            int ret = GetMagicStatusHelperDAL.UpdateParkingSiteStatus(SiteMacAndStatus);
            //回传给终端app
            if (ret > 0)
            {
                oOutput.FLAG = "0";//0表示有数据，更新本地也成功了,远程访问成功
                oOutput.MESSAGE = "";
            }
            else
            {
                oOutput.FLAG = "8";//8表示有数据，但更新本地失败，提示终端要重新获取状态
                oOutput.MESSAGE = POS＿CommunicationHelper.GetErrMsgByErrCode(oOutput.FLAG);
            }

            ***********************************************取消对云端的依赖开始*****************************************************
            ***********************************************2015-07-07经和地磁厂家郑工确认，由网关直接上传数据给后台*************
            ***********************************************修改人:赵鹏 修改内容:取消对云端的依赖，解决数据超时问题**************/
            oOutput = GetMagicStatusHelperDAL.GetParkingSiteStatus(posnum);//获取最新的车位状态对照表
        //}
        string strRet = JavaScriptConvert.SerializeObject(oOutput);
        return strRet;
    }
    public static string getMagicMacs(List<v_parkingsiteinfo> list)
    {
        StringBuilder sb = new StringBuilder();
        foreach (v_parkingsiteinfo o in list)
        {
            sb.Append(o.magicid);
            sb.Append(",");
        }
        return sb.ToString().TrimEnd(',');
    }
    // 时间戳转为C#格式时间
    public static DateTime StampToDateTime(string timeStamp)

    {
        //timeStamp = timeStamp.Remove(timeStamp.Length - 3);
        DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new TimeSpan(lTime);

        return dateTimeStart.Add(toNow);
    }

    // DateTime时间格式转换为Unix时间戳格式
    public static long DateTimeToStamp(System.DateTime time)
    {
        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
        return (long)(time - startTime).TotalSeconds;
    }

    public static /*List<magicStatus>*/ string GetParkingSiteStatus()
    {
        //string parmsStr = "getAllPostionStatus.do?ver=v1.0.1&carrierId=c1b87c48-1d3d-4438-a807-2c2b2426e294&sign=254A6D6BF63518B302BEE75E0B98FF2A&parkCode=11758380-1ba9-4877-b65e-153a67ff8c80&reqDate=" + DateTime.Now.ToString("yyyyMMddHHmmss");
        //string parmsStr = "getAllPostionStatus.do?ver=v1.0.1&carrierId=c1b87c48-1d3d-4438-a807-2c2b2426e294&sign=254A6D6BF63518B302BEE75E0B98FF2A&parkCode=94a95fd2-5974-463c-a337-d0f9736bfb5b&reqDate=" + DateTime.Now.ToString("yyyyMMddHHmmss");

        outputMagicStatus jr_object = new outputMagicStatus();
        string strsql = "select distinct a.siteid,b.sitename from park_parkingsite as a join tb_Site as b on a.siteid=b.id";
        DataTable dt=ZsdDotNetLibrary.Data.DataExecSqlHelper.ExecuteQuerySql(strsql);
         
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string sitename = dt.Rows[i]["sitename"].ToString();
                string parmsname = "getParkByName";
                string returnID = ComunicationHelperDAL.getMagicStatusByName(parmsname, sitename);



                newmagicStatus strjr_object = new newmagicStatus();
                strjr_object = JavaScriptConvert.DeserializeObject<newmagicStatus>(returnID);
                if (strjr_object.message != "get park success")
                {
                    continue;
                }




                string parmsStr = "getBusinessCarportDetail?low=0&count=200&parkId=" + strjr_object.body[0].id;
                    jr_object = ComunicationHelperDAL.getMagicStatus(parmsStr);
            

                
                
                //JObject obj = JObject.Parse(returnID);

                //string serial_number = obj["entry"]["serial_number"].ToString();

                //string parmsStr = "getBusinessCarportDetail?low=0&count=200&parkId=" + ;
                //outputMagicStatus jr_object = ComunicationHelperDAL.getMagicStatus(parmsStr);
            }
        }



        //string parmsStr = "getBusinessCarportDetail?low=0&count=200&parkId=108";
        //outputMagicStatus jr_object = ComunicationHelperDAL.getMagicStatus(parmsStr);

        //parmsStr = "getBusinessCarportDetail?low=0&count=200&parkId=109";
        //jr_object = ComunicationHelperDAL.getMagicStatus(parmsStr);

        //parmsStr = "getBusinessCarportDetail?low=0&count=200&parkId=136";
        //jr_object = ComunicationHelperDAL.getMagicStatus(parmsStr);

        //parmsStr = "getBusinessCarportDetail?low=0&count=200&parkId=137";
        //jr_object = ComunicationHelperDAL.getMagicStatus(parmsStr);

       /* DataTable dt = new DataTable();
        List<JsongItems> objects = new List<JsongItems>();
        jr_object.items.OrderBy(p => p.createTime).Distinct();
        objects = jr_object.items;*/
        //List<magicStatus> objects = jr_object.data.parkList;
       string objects = jr_object.message;
       return objects;
        
    }
}
