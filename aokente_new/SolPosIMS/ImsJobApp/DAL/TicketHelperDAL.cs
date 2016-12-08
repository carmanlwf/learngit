using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data;
using System.Data;

namespace Ims.Job.DAL
{
    public class TicketHelperDAL
    {
        /// <summary>
        /// 根据流水号作废票据领取记录
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static int AlterTicketState(string tid)
        {
            string strSql = "UPDATE ticket_sendlist SET state = 0 WHERE tid = '" + tid + "'";
            int ret = DataExecSqlHelper.ExecuteNonQuerySql(strSql);
            return ret;
        }
        /// <summary>
        /// 根据条件进行票据消耗统计
        /// </summary>
        /// <param name="person"></param>
        /// <param name="s_time"></param>
        /// <param name="e_time"></param>
        /// <returns></returns>
        public static DataTable GetTicketStaticsInfo(string person, string s_time, string e_time)
        {
            string strSql = "";
            if (!string.IsNullOrEmpty(s_time) && !string.IsNullOrEmpty(e_time))
            {
                strSql = @"SELECT a.operatorid,a.name,ISNULL(b.pson_amount,0.00) as pson_amount,ISNULL(c.pson_RealMoney,0) as pson_RealMoney FROM tb_Pos_Operator as a 
                            LEFT JOIN (SELECT receiver,ISNULL(SUM(amount),0) as pson_amount FROM ticket_sendlist WHERE state = 1 And addeddate >= '"+s_time+"' AND addeddate <='"+e_time +"' group by receiver) as b ON a.operatorid = b.receiver LEFT JOIN (SELECT USERID,ISNULL(SUM([RealMoney]),0) as pson_RealMoney FROM tb_POS_Transaction Group By UserID) as c ON b.receiver = c.UserID";
            }
            else
            {
                strSql = @"SELECT a.operatorid,a.name,ISNULL(b.pson_amount,0.00) as pson_amount,ISNULL(c.pson_RealMoney,0) as pson_RealMoney FROM tb_Pos_Operator as a 
                            LEFT JOIN (SELECT receiver,ISNULL(SUM(amount),0) as pson_amount FROM ticket_sendlist WHERE state = 1 group by receiver) as b ON a.operatorid = b.receiver
                            LEFT JOIN (SELECT USERID,ISNULL(SUM([RealMoney]),0) as pson_RealMoney FROM tb_POS_Transaction Group By UserID) as c ON b.receiver = c.UserID";
            }
                if (!string.IsNullOrEmpty(person))
                strSql += " Where a.operatorid = '"+person+"'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
    }
}
