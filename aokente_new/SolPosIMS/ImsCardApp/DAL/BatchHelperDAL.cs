using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;
using Ims.Main;
using System.Data;

namespace Ims.Card.DAL
{
    public class BatchHelperDAL
    {
        public static bool IsBatchAtLastTime()
        {
            string strSQL = "select count(1) from batch_operator where operatorid ='" + ImsInfo.CurrentUserId + "'";
            int count = (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
            if (count > 0) return false;
            else
                return true;
        }
        public static int RegeditLoginStatus()
        {
            string tid ="t"+DateTime.Now.ToString("yyMMddHHmmssfff");
            string itime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string myid = ImsInfo.CurrentUserId;
            string strSQL = "insert into batch_operator(transid,starttime,operatorid)values('" + tid + "','" + itime + "','" + myid + "')";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        public static int DeleteLastRecord()
        {
            string strSQL = "delete from batch_operator where operatorid ='" + ImsInfo.CurrentUserId + "'";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        public static DataTable GetBatchStatus()
        {
            string strSQL = "select starttime from batch_operator where operatorid ='" + ImsInfo.CurrentUserId + "'";
            return DataExecSqlHelper.ExecuteQuerySql(strSQL);
        }
        public static void ResetStatus()
        {
            string strSQL = "update batch_operator set starttime =(CONVERT([varchar](20),getdate(),(120)))  where operatorid ='" + ImsInfo.CurrentUserId + "'";
            DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        /// <summary>
        /// 插入结算记录
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="ZCCount"></param>
        /// <param name="ZCMoney"></param>
        /// <param name="KCount"></param>
        /// <param name="KMoney"></param>
        /// <param name="Money"></param>
        /// <returns></returns>
        public static int InsertBatchRecordByOperator(string serialid,string operid,string starttime, string endtime, int ZCCount, decimal ZCMoney, int KCount, decimal KMoney, decimal Money)
        {

            string strSQL = "INSERT INTO card_chargestatics (serialid,operatorid,starttime,endtime,ZCCount,ZCMoney,KCount,KMoney,Money)";
                strSQL +="VALUES('"+serialid+"','"+operid+"','"+starttime+"','"+endtime+"',"+ZCCount+","+ZCMoney+","+KCount+","+KMoney+","+Money+")";
            return DataExecSqlHelper.ExecuteInsertSql(strSQL);
        }
        /// <summary>
        /// 事务性结算
        /// </summary>
        /// <param name="serialid"></param>
        /// <param name="operid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="ZCCount"></param>
        /// <param name="ZCMoney"></param>
        /// <param name="KCount"></param>
        /// <param name="KMoney"></param>
        /// <param name="Money"></param>
        /// <returns></returns>
        public static bool BatchingByOperator(string serialid, string operid, string starttime, string endtime, int ZCCount, decimal ZCMoney, int KCount, decimal KMoney, decimal Money,int VipCount,decimal VipAmount)
        {
            List<string> strList = new List<string>();
            string sql1 = "delete from batch_operator where operatorid ='" + operid + "'";
            strList.Add(sql1);

            string sql2 = "INSERT INTO card_chargestatics (serialid,operatorid,starttime,endtime,ZCCount,ZCMoney,KCount,KMoney,SumMoney,VipCount,VipAmount)";
            sql2 += "VALUES('" + serialid + "','" + operid + "','" + starttime + "','" + endtime + "'," + ZCCount + "," + ZCMoney + "," + KCount + "," + KMoney + "," + Money + ","+VipCount+","+VipAmount+")";
            strList.Add(sql2);


            List<int> reault = DataExecSqlHelper.ExecuteNonQuerySqls(strList);
            if (reault == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
