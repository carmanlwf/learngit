using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Card.DAL;
using System.Data;
using Ims.Log.Model;

namespace Ims.Card.BLL
{
    public class CardChargeListBLL
    {
        public static List<v_card_chargelist_area> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_card_chargelist_area o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "transid DESC"; }
            List<v_card_chargelist_area> objects = ObjectData.GetPagedObjects<v_card_chargelist_area>(startIndex, pageSize, sortedBy, o, "v_card_chargelist_area");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_card_chargelist_area o)
        {
            return ObjectData.GetObjectsCount(o, "v_card_chargelist_area");
        }
        /// <summary>
        /// 获取交班信息
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<card_chargestatics> GetPagedObjects_statics(int startIndex, int pageSize, string sortedBy, card_chargestatics o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "logtime DESC"; }
            List<card_chargestatics> objects = ObjectData.GetPagedObjects<card_chargestatics>(startIndex, pageSize, sortedBy, o, "card_chargestatics");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_statics(card_chargestatics o)
        {
            return ObjectData.GetObjectsCount(o, "card_chargestatics");
        }
        /// <summary>
        /// 当日充值
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetPageObject(int startIndex, int pageSize, string sortedBy, v_card_chargelist_area o)
        {

            string sqlselect = @"
                                select operid,SUM(amount)as Money, count(transid) as NumCZ, 
                SUM( case when chargetype='充值' then 1 else 0 end) as ZCCount ,
                SUM( case when chargetype='扣款' then 1 else 0 end )  as KCount,
                 SUM(case when chargetype='充值' then amount else 0 end ) as ZCMoney,
                 SUM(case when  chargetype='扣款' then amount else 0 end )as KMoney
                from v_card_chargelist_area where logtime<='" + DateTime.Now.ToString("yyyy-MM-dd ") + "23:59:60" + "' and logtime>='" + DateTime.Now.ToString("yyyy-MM-dd ") + "00:00:00" + "' group by operid ";
            DataTable dt = DataExecSqlHelper.ExecutePagingSql(sqlselect, startIndex, pageSize, "operid", sortedBy, true);
            return dt;
        }

        /// <summary>
        /// 操作员
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetPagedObject(int startIndex, int pageSize, string sortedBy, v_card_chargelist_area o)
        {

            string sqlselect = @"
                                select operid,IsNull(SUM(amount),0) as Money, IsNull(count(transid),0) as NumCZ, 
                IsNull(SUM( case when chargetype='充值' then 1 else 0 end),0) as ZCCount ,
                IsNull(SUM( case when chargetype='扣款' then 1 else 0 end ),0)  as KCount,
                 IsNull(SUM(case when chargetype='充值' then amount else 0 end ),0) as ZCMoney,
                 IsNull(SUM(case when  chargetype='扣款' then amount else 0 end ),0) as KMoney
                from v_card_chargelist_area  group by operid  ";
            DataTable dt = DataExecSqlHelper.ExecutePagingSql(sqlselect, startIndex, pageSize, "operid", sortedBy, true);
            return dt;
        }
        /// <summary>
        /// 操作员充值统计记录行数
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetPagedObject_count(v_card_chargelist_area o)
        {

            string sqlselect = @"
                                select operid,IsNull(SUM(amount),0) as Money, IsNull(count(transid),0) as NumCZ, 
                IsNull(SUM( case when chargetype='充值' then 1 else 0 end),0) as ZCCount ,
                IsNull(SUM( case when chargetype='扣款' then 1 else 0 end ),0)  as KCount,
                 IsNull(SUM(case when chargetype='充值' then amount else 0 end ),0) as ZCMoney,
                 IsNull(SUM(case when  chargetype='扣款' then amount else 0 end ),0) as KMoney
                from v_card_chargelist_area  group by operid  ";
            DataTable dt = DataExecSqlHelper.ExecutePagingSql(sqlselect, 0, 1000, "", "operid", true);
            return dt.Rows.Count;
        }

        public static DataTable ChargeListStaticsByOperator(card_chargelist o)
        {
            string StrSql = @" select operid,IsNull(SUM(amount),0) as Money, IsNull(count(transid),0) as NumCZ, 
                IsNull(SUM( case when chargetype='充值' then 1 else 0 end),0) as ZCCount ,
                IsNull(SUM( case when chargetype='扣款' then 1 else 0 end ),0)  as KCount,
                 IsNull(SUM(case when chargetype='充值' then amount else 0 end ),0) as ZCMoney,
                 IsNull(SUM(case when  chargetype='扣款' then amount else 0 end ),0) as KMoney,
                 ISNULL(SUM(case when cardtype<>'临时卡' And chargetype='充值' then 1 else 0 end),0) as vipCount,
                 ISNULL(SUM(case when cardtype<>'临时卡' And chargetype='充值' then amount else 0 end),0) as vipAmount
                from v_card_chargelist_area where operid='" + o.operid + "' And logtime>='" + o.OperateDate1 + "' And logtime<='" + o.OperateDate2 + "' group by operid  ";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(StrSql);
            return dt;
        }


        public static void checkId(object o, string errmessage)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception(errmessage);
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(card_chargelist o)
        {
            checkId(o, "删除失败!");
            return ObjectData.DeleteObject(o, "card_chargelist");
        }

        /// <summary>
        /// 对充值表进行统计 
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable HavetimeCountCardChargeList(string state, string starttime, string endtime,string operid,string cardtype,string chargetype)
        {
            return CardChargeListDAL.HavetimeCountCardChargeList(state, starttime, endtime, operid, cardtype, chargetype);
        }

        /// <summary>
        /// 充值表记录信息
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
        public static DataTable DTTransLog(string cardID, string chargetype, string time1, string time2)
        {
            return CardChargeListDAL.DTTransLog(cardID, chargetype, time1, time2);
        }

        public static DataTable DTTransLogExit(string cardID, string time1, string time2)
        {
            return CardChargeListDAL.DTTransLogExit(cardID,time1, time2);
        }

        public static DataTable DTTransLogTaday(string cardID)
        {
            return CardChargeListDAL.DTTransLogTaday(cardID);
        }
         /// <summary>
        /// 充值
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool UpdateBalanceAndInsert1(string oldbalance, string newbalance, string newgift, string cardID, card_chargelist clist, tb_Log log, int op)
        {
            return CardChargeListDAL.UpdateBalanceAndInsert1(oldbalance, newbalance, newgift, cardID, clist, log, op);
        }

        public static card_chargelist GetObject_objec(string Card)
        {
            card_chargelist o = new card_chargelist();
            o.Card = Card;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "card_chargelist") as card_chargelist;
        }
              /// <summary>
        /// 按操作员和时间对充值表进行统计 
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static DataTable HavetimeCountCardChargeListByOperatorId(string operatorid, string starttime, string endtime)
        {
            return CardChargeListDAL.HavetimeCountCardChargeListByOperatorId(operatorid,starttime,endtime);
        }
        /// <summary>
        ///  按操作员和时间对充值表进行统计（会员）
        /// </summary>
        /// <param name="operatorid"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public static DataTable HavetimeCountCardChargeStaticsByOperatorIdAndTime(string operatorid, string starttime, string endtime)
        {
            return CardChargeListDAL.HavetimeCountCardChargeStaticsByOperatorIdAndTime(operatorid, starttime, endtime);
        }
        /// <summary>
        /// 批量删除充值记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public static int DeleteChargeList(string time1, string time2, bool IsAll)
        {
            return CardChargeListDAL.DeleteChargeList(time1, time2, IsAll);
        }
        /// <summary>
        /// 批量删除充值结算记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public static int DeleteChargeStatic(string time1, string time2, bool IsAll)
        {
            return CardChargeListDAL.DeleteChargeStatic(time1,time2,IsAll);
        }

        public static bool UpdateBalanceAndInsert(string oldbalance, string newbalance, string cardID, card_chargelist clist, tb_Log log)
        {
            return CardChargeListDAL.UpdateBalanceAndInsert(oldbalance, newbalance, cardID, clist, log);
        }

    }
}
