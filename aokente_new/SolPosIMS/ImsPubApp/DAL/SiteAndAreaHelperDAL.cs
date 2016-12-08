using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data;
using System.Data;

namespace Ims.Pub.DAL
{
   public class SiteAndAreaHelperDAL
    {
        /// <summary>
        /// ---------------------------------------
        /// 判断区域号是否在门店中使用，如果在在使用状态，则不能删除
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Area_Times(string areacode)
        {
            string strSQL = "select COUNT(1) from dbo.PUB_Site where areacode='" + areacode + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// ---------------------------------------
        /// 判断门店是否是否在卡片中在使用，如果在在使用状态，则不能删除
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Site_Times(string siteid)
        {
            string strSQL = "select COUNT(1) from dbo.MB_Card where siteid='" + siteid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        //-----------------2011-10-25--------------------------------
        /// <summary>
        /// ---------------------------------------
        /// 根据区域号码得到所有的分店号与名字
        /// GetAllSiteByAreacodeID
        /// </summary>
        /// <returns></returns>
        /// 
        public static string GetAreacodeIDSiteBysiteID(string siteid)
        {
            string strSQL = "select areacode from dbo.PUB_Site where siteid ='" + siteid + "'";
            return DataExecSqlHelper.ExecuteScalarSql(strSQL).ToString();

        }
        /// <summary>
        /// 判断tb_site中是否已存在相同的机器码        
        /// </summary>
        /// <returns></returns>
        //public static int Site_Machineid(string machineid)
        //{
        //    string strSql = "select Count(1) from dbo.tb_Site where machineid='" + machineid + "'";
        //    return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        //}
        /// <summary>
        ///判断tb_Pos_Operator 是否有相同数据
        /// </summary>
        /// <returns></returns>
        public static int tb_Pos_Operatorid(string operatorid)
        {
            string strSql = "select Count(1) from dbo.POS_Operator where operatorid='" + operatorid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        }
    }
}
