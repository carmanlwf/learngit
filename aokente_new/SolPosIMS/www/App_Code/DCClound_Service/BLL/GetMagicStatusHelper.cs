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
using Ims.Site.Model;
using Ims.Site.BLL;

/// <summary>
///GetMagicStatusHelper 的摘要说明
/// </summary>
public class GetMagicStatusHelper
{
    public GetMagicStatusHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 获取设备状态
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortedBy"></param>
    /// <param name="o"></param>
    /// <returns></returns>
    public static List<MagicStatusList> GetPagedObjects_MagicStatus(int startIndex, int pageSize, string sortedBy, MagicStatusList o)
    {
        string macs = "";
        if(!string.IsNullOrEmpty(o.mac))
            macs = o.mac;
        else
            macs = parkingsiteinfoHelper.GetAllMacsByPosNum();
        string mac_count = "0";
        if (!string.IsNullOrEmpty(macs))
        {
            string[] strArray = macs.Split(',');
            mac_count = (strArray.Length - 1).ToString();
        }
        //old string parmsStr = "getDeviceDatas.do?page=1&start=0&limit=100&applicationId=f257031f4dec1168014dec12d00a000f&macs=" + macs +"&startTime=" + start_time.ToString() + "&endTime=" + end_time.ToString();
        string parmsStr = "getDeviceDatas.do?page=1&start=0&limit=50&applicationId=f257031f4dec1168014dec12d00a000f&macs=" + macs.TrimEnd(',');
        //string parmsStr = "getDeviceDatas.do?page=1&start=0&limit=100&applicationId=f257031f4dec1168014dec12d00a000f&macs=0002FFFFFF132015,0004FFFFFF132015,0001FFFFFF132015,0022FFFFFF442017,0005FFFFFF132015,0003FFFFFF132015";
        Status_Json_Response sjr_object = ComunicationHelperDAL.CallDCCloudService_GetMagicStatus("search",parmsStr);
        sjr_object.items.OrderByDescending(p => p.createTime).Distinct();
        List<MagicStatusList> objects = sjr_object.items;
        return objects;
    }
    /// <summary>
    /// 记录行数
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static int GetObjectsCount_MagicStatus(MagicStatusList o)
    {
        string macs = "";
        if (!string.IsNullOrEmpty(o.mac))
            macs = o.mac;
        else
            macs = parkingsiteinfoHelper.GetAllMacsByPosNum();
        string mac_count = "0";
        if (!string.IsNullOrEmpty(macs))
        {
            string[] strArray = macs.Split(',');
            mac_count = (strArray.Length - 1).ToString();
        }
        //old string parmsStr = "getDeviceDatas.do?page=1&start=0&limit=100&applicationId=f257031f4dec1168014dec12d00a000f&macs=" + macs +"&startTime=" + start_time.ToString() + "&endTime=" + end_time.ToString();
        string parmsStr = "getDeviceDatas.do?page=1&start=0&limit=50&applicationId=f257031f4dec1168014dec12d00a000f&macs=" + macs.TrimEnd(',');
        Status_Json_Response sjr_object = ComunicationHelperDAL.CallDCCloudService_GetMagicStatus("search", parmsStr);
        return sjr_object.total;
    }
}
