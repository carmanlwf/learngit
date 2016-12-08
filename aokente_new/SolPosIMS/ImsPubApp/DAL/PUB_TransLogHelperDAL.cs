using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Pub.DAL
{
   public class PUB_TransLogHelperDAL
    {
        /// <summary>
        /// 当没时间 对充值表进行删除
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int NotimeDeleteTransLog()
        {
            string strSQL = " delete from dbo.PUB_TransLog  ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        /// <summary>
        /// 当有时间 对充值表进行删除
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HavetimeDeleteTransLog(string time7, string time8)
        {
            string strSQL = " delete from dbo.PUB_TransLog   where  OperateDate>='" + time7 + " ' and  OperateDate<='" + time8 + " ' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
    }
}
