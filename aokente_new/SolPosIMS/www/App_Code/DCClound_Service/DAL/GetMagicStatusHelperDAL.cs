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
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using Ims.Pos.Model;

/// <summary>
///GetMagicStatusHelperDAL 的摘要说明
/// </summary>
public class GetMagicStatusHelperDAL
{
    public GetMagicStatusHelperDAL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
/// <summary>
/// 由云端系统返回数据根据状态和地址更新车位的信息
/// </summary>
/// <param name="status"></param>
/// <param name="mac"></param>
/// <returns></returns>
    public static int UpdateParkingSiteStatus(List<SiteMacAndStatus> objects)
    {
        int success_count = 0;
        for (int i = 0; i < objects.Count; i++)
        {
            string info = objects[i].info.Substring(objects[i].info.Length - 6 , 2);//FE 0C C1 00 04 FF FF 03 03 22 22 02 01 00 55 (4号地磁有回应)
            int state = int.Parse(info);
            //根据地磁mac更新车位状态（条件：mac相同，updatetime 要晚于传过来的记录时间 且地磁状态有变化的记录）
            string strSQL = "UPDATE park_parkingsite SET isbusy = " + state + ",updatetime = '"+objects[i].createTime+"',updateway='cloud' WHERE magicid = '" + objects[i].mac + "' And updatetime < '"+objects[i].createTime+"' And isbusy <> "+state+"";
            if (0 == state)
                strSQL = "UPDATE park_parkingsite SET isbusy = " + state + ",updatetime = '" + objects[i].createTime + "',updateway='cloud', currentcarnum = NULL WHERE magicid = '" + objects[i].mac + "' And updatetime < '" + objects[i].createTime + "' And isbusy <> " + state + "";
            try
            {
                DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
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
    /// 根据手持终端号查询所在车场的车位状态信息(返回车位自定义编号和占用状态)
    /// </summary>
    /// <param name="posnum"></param>
    /// <returns></returns>
    public static output_Magic GetParkingSiteStatus(string posnum)
    {
        string strSql = "SELECT isbusy,parkingname,updatetime FROM park_parkingsite WHERE siteid in (select siteid FROM pos_poslist WHERE posnum = '" + posnum + "') order by addtime asc,len(parkingname) asc , parkingname asc";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
        output_Magic oMagic = new output_Magic();
        if (dt != null && dt.Rows.Count > 0)
        {

            oMagic.sitestatuslist = new List<SiteStatusObject>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string pname = dt.Rows[i]["parkingname"].ToString();
                int busy = int.Parse(dt.Rows[i]["isbusy"].ToString());
                string updatetime = dt.Rows[i]["updatetime"].ToString();
                oMagic.sitestatuslist.Add(new SiteStatusObject(pname, busy,updatetime));
            }
            oMagic.FLAG = "0";
            oMagic.MESSAGE = "";
        }
        return oMagic;
    }
}
