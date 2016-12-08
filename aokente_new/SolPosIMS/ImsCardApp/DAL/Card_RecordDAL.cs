using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Card.DAL
{
   public class Card_RecordDAL
    {
        /// <summary>
        /// 补卡记录（导出）
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
       public static DataTable DTTransLog(string NewCardId, string time1, string time2)
       {
           StringBuilder sql = new StringBuilder("  select v.Oldcardid '旧卡号',v.NewCardId '新卡号',v.balance '卡余额'," +
               "v.username '用户名',v.CardTime '补卡时间'" +
               "from v_Card_Record as v where 1=1");
           if (NewCardId != "")
           {
               sql.Append(" and v.NewCardId='" + NewCardId + "'");
           }
           if (time1 != "" && time2 != "")
           {
               sql.Append(" and '" + time1 + "'<= v.CardTime and v.CardTime<='" + time2 + "'");
           }
           if (time1 != "" && time2 == "")
           {
               sql.Append(" and v.CardTime>='" + time1 + "'");
           }
           if (time1 == "" && time2 != "")
           {
               sql.Append(" and v.CardTime<='" + time2 + "'");
           }
           return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());

       }
       /// <summary>
       /// 删除补卡记录Card_Record
       /// </summary>
       /// <returns></returns>
       public static int del_ReplaceCardRecord(string time1,string time2,bool IsAll)
       {
           string strSql = "Delete From Card_Record Where 1=1";
           if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2) && !IsAll)
               strSql += " And logtime>='" + time1 + "' And logtime <='" + time2 + "'";
           return DataExecSqlHelper.ExecuteNonQuerySql(strSql);
       }

       public static DataTable GetCard(string Getcard)
       {
           string strSql = "select case when  TypeID='' or TypeID=null   then '0' else '1' end  as cunt from tb_Card where [card]='" + Getcard + "'";

           return DataExecSqlHelper.ExecuteQuerySql(strSql);
       }

    }
}
