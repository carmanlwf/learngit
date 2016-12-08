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

/// <summary>
///DataCenterHelperBLL 的摘要说明
/// </summary>
public class DataCenterHelperBLL
{
    public DataCenterHelperBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 由网关直接发送地磁数据来保存入库
    /// </summary>
    /// <param name="status"></param>
    /// <param name="mac"></param>
    /// <returns></returns>
    public static string ReceiveMagicData(List<magicdata> objects,string ip)
    {
        return DataCenterHelperDAL.ReceiveMagicData(objects, ip);
    }
}
