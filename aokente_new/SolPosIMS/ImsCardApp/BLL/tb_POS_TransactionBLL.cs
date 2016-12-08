using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.DAL;

namespace Ims.Card.BLL
{
    public class tb_POS_TransactionBLL
    {
        /// <summary>
        /// 批量删除终端交易记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public static int DeletePosTransDetails(string time1, string time2, bool IsAll)
        {
            return tb_POS_TransactionDAL.DeletePosTransDetails(time1, time2, IsAll);
        }
        /// <summary>
        /// 批量删除终端交易记录_历史删除记录备份
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public static int DeletePosTransDetailsHistroy(string time1, string time2, bool IsAll)
        {
            return tb_POS_TransactionDAL.DeletePosTransDetailsHistroy(time1, time2, IsAll);
        }
    }
}
