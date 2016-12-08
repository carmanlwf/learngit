using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Log;
using Ims.Member.Model;
using Ims.Log.Model;

namespace Ims.Member.DAL
{
   public class card_integralexchangeDAL
    {
        /// <summary>
        /// 会员积分兑换操作（积分扣减）
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
       public static int IntegralExchangeByCard(string card, int amount)
       {
           string strSql = "update tb_member set points = points - " + amount + " where userid in (select userid from tb_card where card = '" + card + "' and status = 1)";
           return DataExecSqlHelper.ExecuteNonQuerySql(strSql);
       }
               /// <summary>
       /// 插入会员积分兑换记录
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
       public static bool IntegralExchange_insert(card_integralexchangelist ciel, tb_Log log)
       {
           Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
           objects.Add(ciel, DataExecCmdType.Insert);
           objects.Add(log, DataExecCmdType.Insert);
           TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
           try
           {
               //提交事务f
               DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
               return true;
           }
           catch (Exception exp)
           {

               DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
               LogHelper.Write(exp);
               return false;
           }
       }
    }
}

