using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data;

namespace Ims.Pub.DAL
{
    public class BlackBookHelperDAL
    {
        /// <summary>
        /// 查询ip是否被拉黑
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsInBlack(string ip)
        {
            string sql = "Select count(1) FROM PUB_BlackBook Where IP ='" + ip + "'";
            int ret = (int)DataExecSqlHelper.ExecuteScalarSql(sql);
            if (ret > 0)
                return true;
            else
                return false;
        }
        
    }
}
