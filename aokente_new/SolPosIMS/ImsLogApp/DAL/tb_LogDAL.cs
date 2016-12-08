using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;

namespace Ims.Log.DAL
{
   public  class tb_LogDAL
    {
        /// <summary>
        ///  删除 tb_Log里面的数据
        /// </summary>
        /// <returns></returns>
        public static int Deletecdttb_Log()
        {
            string strSQL = "delete  FROM dbo.tb_Log ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }


        /// <summary>
        ///  删除 tb_Log里面的数据 有时间
        /// </summary>
        /// <returns></returns>
       public static int Deletecdttb_LogBytime(string time1, string time2)
        {
            string strSQL = "delete from dbo.tb_Log  where  operate_date>='" + time1 + " 00:00:00' and operate_date<='" + time2 + " 23:59:60' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        /// <summary>
        ///  果看里面有没有数据
        /// </summary>
        /// <returns></returns>
        /// 

       public static int counlogbytime(string time1, string time2)
       {
           string strSQL = "select COUNT(1)  from dbo.tb_Log  where  operate_date>='"+ time1 +" 00:00:00' and operate_date<='"+ time2+ " 23:59:60' ";
           return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
       }
       /// <summary>
       /// 记录pos机的请求日志
       /// </summary>
       /// <param name="logid"></param>
       /// <param name="cmdtype"></param>
       /// <param name="rawurl"></param>
       /// <param name="requrl"></param>
       /// <param name="rtnstr"></param>
       public static void PosReqLog(string logid,string posno, string cmdtype, string rawurl, string requrl, string rtnstr)
       {
           string strSql = "insert into tb_Pos_Log(logid,posno,cmdtype,rawUrl,reqUrl,rtnStr) values('" + logid + "','" + posno + "','" + cmdtype + "','" + rawurl + "','" + requrl + "','" + rtnstr + "')";
           DataExecSqlHelper.ExecuteNonQuerySql(strSql);
       }
    }
}
