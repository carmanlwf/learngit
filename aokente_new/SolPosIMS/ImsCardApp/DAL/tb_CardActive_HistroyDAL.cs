using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;

namespace Ims.Card
{
   public  class tb_CardActive_HistroyDAL
    {
        /// 
        /// �鿴tb_CardActive_Histroy�������Ƿ�������(ûʱ��)
        /// </summary>
        /// <returns></returns>
        /// 
       public static int NocountCardActiveHistroy()
        {
            string strSQL = "select COUNT(1) from dbo.tb_CardActive_Histroy ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// 
        /// �鿴tb_CardActive_Histroy�������Ƿ�������(��ʱ��)
        /// </summary>
        /// <returns></returns>
        /// 
       public static int HavecountCardActiveHistroy(string time1, string time2)
        {
            string strSQL = "select COUNT(1) from dbo.tb_CardActive_Histroy  where activetime>='" + time1 + " 00:00:00' and activetime <='" + time2 + " 23:59:60'  ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        ///ɾ��tb_CardActive_Histroy������������
        /// </summary>
        /// <returns></returns>
        /// 
        public static int deleteAlltb_CardActive_Histroy()
        {
            string strSQL = " delete from dbo.tb_CardActive_Histroy  ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        /// <summary>
        ///ɾ��tb_CardActive_Histroy������������
        /// </summary>
        /// <returns></returns>
        /// 
       public static int deleteAlltb_CardActive_HistroyByTime(string time1,string time2)
       {
           string strSQL = "  delete from dbo.tb_CardActive_Histroy where activetime>='" + time1 +" 00:00:00' and activetime <='" + time2+ " 23:59:60'  ";
           return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
       }
    }
}
