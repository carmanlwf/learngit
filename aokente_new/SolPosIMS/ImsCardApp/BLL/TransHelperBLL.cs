using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.DAL;
using Ims.Card.Model;
using Ims.Member.Model;
using Ims.Log.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;

namespace Ims.Card.BLL
{
    public class TransHelperBLL
    {
        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool Card_ZhuanZhang(tb_TransCash o1, tb_TransCash o2,tb_Log log)
        {
            return TransHelperDAL.Card_ZhuanZhang(o1, o2,log);
        }
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool Card_ChongZhi(tb_TransLog t,  tb_Card c, tb_Log log)
        {
            return TransHelperDAL.Card_ChongZhi(t, c , log);
        }
        /// <summary>
        /// 转账
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_TransferRecord> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_TransferRecord o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "OperateDate DESC"; }
            List<tb_TransferRecord> objects = ObjectData.GetPagedObjects<tb_TransferRecord>(startIndex, pageSize, sortedBy, o, "tb_TransferRecord");
            return objects;
        }
                /// <summary>
        /// 会员补卡
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool MemberBuKa(tb_Card o1, tb_Card o2, Card_Record cardrecord, tb_CardActivityByShop c, tb_Log log)
        {
            return TransHelperDAL.MemberBuKa(o1, o2, cardrecord,c, log);
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_TransferRecord o)
        {
            return ObjectData.GetObjectsCount(o, "tb_TransferRecord");
        }
        /// <summary>
        /// 检查主键是否存在
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(object o, string errmessage)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception(errmessage);
            }

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(tb_TransferRecord o)
        {
            checkId(o, "交易编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_TransferRecord");
        }
         /// <summary>
        /// 会员发卡
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool SendCard(tb_Card c, tb_Log log, tb_CardActivityByShop aCtive)
        {
            return TransHelperDAL.SendCard(c, log,aCtive);
        }

        /// <summary>
        /// -----------------10-9-----------------------
        /// 会员卡转账
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool Online_transfer(tb_Card c1, tb_Card c2, tb_Member_Log log, tb_TransferRecord tranERe, tb_TransLog tranlog)
        {
            return TransHelperDAL.Online_transfer(c1, c2, log, tranERe, tranlog);
        }
        /// -----------------10-10----------------------
        /// 判断卡一天的转账次数
        /// Tran_Times
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        /// 
        public static int Tran_Times(string tradcard)
        {
            return TransHelperDAL.Tran_Times(tradcard);
        }
        /// -----------------2011-10-20----------------------
        ///  管理面在线帮会员转帐
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool Online_transferOfManger(tb_Card c1, tb_Card c2, tb_Log log, tb_TransferRecord tranERe, tb_TransLog tranlog)
        {
            return TransHelperDAL.Online_transferOfManger(c1, c2, log, tranERe, tranlog);
        }
        //-----------------2011-10-20----------------------
        /// <summary>
        /// 按卡号查询最后一次的消费记录
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public static string GetLastConsumeTime(string card)
        {
            return TransHelperDAL.GetLastConsumeTime(card);
        }
    }
}
