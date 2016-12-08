using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data;

namespace Ims.Pub.DAL
{
    /// <summary>
    /// 访问信息
    /// </summary>
    public  class PUB_RequestClientHelperDAL
    {

        /// <summary>
        ///  删除 Pub_Log里面的数据
        /// </summary>
        /// <returns></returns>
        public static int DeletePUB_RequestClient()
        {
            string strSQL = "delete  FROM dbo.PUB_RequestClient ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }


        /// <summary>
        ///  删除 Pub_Log里面的数据 根据时间
        /// </summary>
        /// <returns></returns>
        public static int DeletePUB_RequestClientBytime(string time13, string time14)
        {
            string strSQL = "delete from dbo.PUB_RequestClient  where  LogTime>='" + time13 + "' and LogTime<='" + time14 + "' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
    }
}
