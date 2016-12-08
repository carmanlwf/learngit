using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.PM.DAL
{
    public class PmDAL
    {
        /// <summary>
        /// 返回当前用户的代理区域下所属的站点id
        /// </summary>
        /// <returns></returns>
        public static string GetAgentArea()
        {
            //string sql = "select id from tb_site where id in(select areaid from pub_agentinfo where id='" + Ims.Main.ImsInfo.CurrentUserId + "')";
            string sql = "select areaid from pub_agentinfo where id in('" + Ims.Main.ImsInfo.CurrentUserId + "')";
            DataTable dt = new DataTable();
            dt = DataExecSqlHelper.ExecuteQuerySql(sql);
            string regionids = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                regionids += dt.Rows[i][0].ToString();
                regionids += "'";
            }
            return regionids;
        }
        /// <summary>
        /// 返回当前用户的所属分店
        /// </summary>
        /// <returns></returns>
        public static string GetManagerSite()
        {
            string sql = "select siteid from pub_agentinfo where id='" + Ims.Main.ImsInfo.CurrentUserId + "'";
            DataTable dt = new DataTable();
            dt = DataExecSqlHelper.ExecuteQuerySql(sql);
            return dt.Rows[0][0].ToString();
        }
        /// <summary>
        /// 返回当前用户的所在的组编号
        /// </summary>
        /// <returns></returns>
        public static string GetManagerGroupID(string id)
        {
            string sql = "select  groupinfo_id  from pub_agentinfo where id='" + id + "'";
            DataTable dt = new DataTable();
            dt = DataExecSqlHelper.ExecuteQuerySql(sql);
            return dt.Rows[0][0].ToString();
        }
        /// <summary>--------------2011-10-24---------------
        /// 返回当前用户的所属分店
        /// </summary>
        /// <returns></returns>
        public static string GetAreacodeByAgentID(string agentID)
        {
            string strSQL = "SELECT areaid FROM dbo.pub_agentinfo WHERE id='" + agentID + "'";
            return  DataExecSqlHelper.ExecuteScalarSql(strSQL).ToString();
        }
        /// <summary>
        /// 返回当前用户的所属分店编号
        /// </summary>
        /// <returns></returns>
        public static string GetSiteByAgentID(string agentID)
        {
            string strSQL = "SELECT areaid   FROM   dbo.pub_agentinfo  WHERE id='" + agentID + "'";
            return DataExecSqlHelper.ExecuteScalarSql(strSQL).ToString();
        }
        /// <summary>--------------2011-10-24---------------
     
    }
}
