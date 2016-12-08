using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data;

namespace Ims.Pub.DAL
{
    public class LogHelperDAL
    {

        /// <summary>
        ///  删除 Pub_Log里面的数据
        /// </summary>
        /// <returns></returns>
        public static int DeletePub_Log()
        {
            string strSQL = "delete  FROM dbo.PUB_Log ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }


        /// <summary>
        ///  删除 Pub_Log里面的数据 根据时间
        /// </summary>
        /// <returns></returns>
        public static int DeletePub_LogBytime(string time3, string time4)
        {
            string strSQL = "delete from dbo.PUB_Log  where  operate_date>='" + time3 + "' and operate_date<='" + time4 + "' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        /// <summary>
        ///  果看里面有没有数据
        /// </summary>
        /// <returns></returns>
        /// 

        public static int counlogbytime(string time1, string time2)
        {
            string strSQL = "select COUNT(1)  from dbo.Pub_Log  where  operate_date>='" + time1 + " 00:00:00' and operate_date<='" + time2 + " 23:59:60' ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
    }
}

