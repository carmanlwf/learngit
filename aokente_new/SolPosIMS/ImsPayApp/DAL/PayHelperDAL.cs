using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Pay.DAL
{
    public class PayHelperDAL
    {
        /// <summary>
        /// 根据流水号获取交易记录的详情
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static DataTable GetTradeInfoByPayId(string pid)
        {
            string strSql = "Select tradecomment,carnum From pay_paydetail Where payid = '" + pid + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        /// <summary>
        /// 获取欠费名单
        /// </summary>
        /// <param name="person"></param>
        /// <param name="s_time"></param>
        /// <param name="e_time"></param>
        /// <returns></returns>
        public static DataTable GetBillList(string carnum)
        {
            string strSql = "";
            if (!string.IsNullOrEmpty(carnum))
            {
                strSql = @"SELECT a.[card],a.balance,c.Expenditure,c.RealName, b.tradetime,b.tradecomment FROM tb_Card as a LEFT JOIN pay_paydetail as b on a.[card] = b.carnum LEFT JOIN tb_Member as c on a.userid = c.UserId
WHERE payid in (SELECT top 1 payid FROM pay_paydetail WHERE carnum = '" + carnum + "' order by tradetime desc)";
            }
            else
            {

            }
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
    }
}
