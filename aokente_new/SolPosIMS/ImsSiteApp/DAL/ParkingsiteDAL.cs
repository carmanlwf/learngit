using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.Site.Model;

namespace Ims.Site.DAL
{
    public class ParkingsiteDAL
    {
        /// <summary>
        /// 判断tb_site中是否已存在相同的地磁编号      
        /// </summary>
        /// <returns></returns>
        public static int IsExistsMagicID(string magicid)
        {
            string strSql = "select Count(1) from dbo.park_parkingsite where magicid='" + magicid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        }
        /// <summary>
        /// 根据终端id获取路段编号
        /// </summary>
        /// <param name="parkingid"></param>
        /// <returns></returns>
        public static string GetSite_Codeid(string posnum)
        {
            string sql = string.Format("select siteid from pos_poslist where posnum='{0}'", posnum);
            DataTable zhi = DataExecSqlHelper.ExecuteQuerySql(sql);
            return zhi.Rows[0][0].ToString();

        }
        /// <summary>
        /// 根据车位查询路段编号
        /// </summary>
        /// <param name="posnum"></param>
        /// <returns></returns>
        public static string GetParkingidSite_Codeid(string parkingid)
        {
            string sql = string.Format("select siteid from park_parkingsite where parkingid='{0}'", parkingid);
            DataTable zhi = DataExecSqlHelper.ExecuteQuerySql(sql);
            return zhi.Rows[0][0].ToString();

        }

        /// <summary>
        /// 根据路段id获取区域id
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
        public static string GetArea_Codeid(string areaid)
        {
            string sql = string.Format("select areacode from tb_Site where id='{0}'",areaid);
            return DataExecSqlHelper.ExecuteQuerySql(sql).Rows[0][0].ToString();
        }
        /// <summary>
        /// 是否存在相同的自定义车位编号
        /// </summary>
        /// <param name="parkingname"></param>
        /// <returns></returns>
        public static int IsExistsParkingName(string parkingname)
        {
            string strSql = "select COUNT(1) parkingname from park_parkingsite where parkingname='" + parkingname + "'";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSql);//test
        }
        /// <summary>
        /// 根据pos机号获取地磁mac列表
        /// </summary>
        /// <param name="posNum"></param>
        /// <returns></returns>
        public static string GetMacsByPosNum(string posNum)
        {
            string strRtn = "";
            string strSql = "SELECT magicid FROM park_parkingsite WHERE siteid in (Select siteid From pos_poslist Where posnum='" + posNum + "')";
            DataTable dt_Macs = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (dt_Macs != null && dt_Macs.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_Macs.Rows)
                {
                    strRtn += dr["magicid"].ToString();
                    strRtn += ",";
                }
            }
            else
            {
                return "";
            }
            return strRtn;
        }
        /// <summary>
        /// 获取所有已注册地磁mac列表
        /// </summary>
        /// <param name="posNum"></param>
        /// <returns></returns>
        public static string GetAllMacsByPosNum()
        {
            string strRtn = "";
            string strSql = "SELECT magicid FROM park_parkingsite";
            DataTable dt_Macs = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (dt_Macs != null && dt_Macs.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_Macs.Rows)
                {
                    strRtn += dr["magicid"].ToString();
                    strRtn += ",";
                }
            }
            else
            {
                return "";
            }
            return strRtn;
        }
    }
}
