using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.DAL;
using System.Data;

namespace Ims.Card.BLL
{
    public class BatchHelperBLL
    {
        public static bool IsBatchAtLastTime()
        {
            return BatchHelperDAL.IsBatchAtLastTime();
        }
        public static int DeleteLastRecord()
        {
            return BatchHelperDAL.DeleteLastRecord();
        }
        public static DataTable GetBatchStatus()
        {
            return BatchHelperDAL.GetBatchStatus();
        }
        public static void ResetStatus()
        {
            BatchHelperDAL.ResetStatus();
        }
        public static int RegeditLoginStatus()
        {
            return BatchHelperDAL.RegeditLoginStatus();
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
            return BatchHelperDAL.InsertBatchRecordByOperator(serialid,operid,starttime,endtime,ZCCount,ZCMoney,KCount,KMoney,Money);
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
            return BatchHelperDAL.BatchingByOperator(serialid,operid,starttime,endtime,ZCCount,ZCMoney,KCount,KMoney,Money,VipCount,VipAmount);
        }
    }
}
