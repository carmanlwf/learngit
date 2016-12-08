using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Log;
using Ims.Card.Model;
using Ims.Log.Model;
using System.Data.SqlClient;
using Ims.Main;

namespace Ims.Card.DAL
{
    public class CardChargeListDAL
    {
        /// <summary>
        /// 对充值表进行统计 
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static DataTable HavetimeCountCardChargeList(string card,string starttime,string endtime,string operid,string cardtype,string chargetype)
        {
            //StringBuilder sql = new StringBuilder("select SUM(amount)as am，SUM from dbo.card_chargelist where flag=1 ");
            string strSql = "";
            strSql = @"SELECT IsNull(SUM(amount),0) AS am,count(*) as count_sum,IsNull(SUM(CASE chargetype WHEN '充值' THEN amount ELSE 0 END),0) AS charge_sum, 
                      IsNull(SUM(CASE chargetype WHEN '扣款' THEN amount ELSE 0 END),0) AS cancel_sum, IsNull(SUM(CASE chargetype WHEN '充值回滚' THEN amount ELSE 0 END),0) 
                      AS charge_rollback_sum, IsNull(SUM(CASE chargetype WHEN '扣款回滚' THEN amount ELSE 0 END),0) AS cancel_rollback_sum
                      FROM dbo.card_chargelist Where 1=1";
            if (!string.IsNullOrEmpty(card) && !string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime) && !string.IsNullOrEmpty(operid) && !string.IsNullOrEmpty(cardtype) && !string.IsNullOrEmpty(chargetype))
            {
                strSql += " And card='" + card + "' And logtime>='" + starttime + "' And logtime<='" + endtime + "' And operid = '" + operid + "' And cardtype = '" + cardtype + "' And chargetype='" + chargetype + "'";
            }
            else
            {
                if (!string.IsNullOrEmpty(card))
                {
                    strSql += " And  card='" + card + "'";
                }
                if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
                {
                    strSql += " And  logtime>='" + starttime + "' And logtime<='" + endtime + "'";
                }
                if (!string.IsNullOrEmpty(operid))
                {
                    strSql += " And  operid='" + operid + "'";
                }
                if (!string.IsNullOrEmpty(cardtype))
                {
                    strSql += " And  cardtype='" + cardtype + "'";
                }
                if (!string.IsNullOrEmpty(chargetype))
                {
                    strSql += " And  chargetype='" + chargetype + "'";
                }
            }
            //strSql += " GROUP BY card";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        
        /// <summary>
        /// 充值表记录信息（导出）
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
        public static DataTable DTTransLog(string transId, string chargetype, string time1, string time2)
        {
            StringBuilder sql = new StringBuilder("  select v.transId '交易编号',v.card '卡号',v.cardtype '卡类型'," +
                "v.chargetype '类型',v.amount '充值金额',v.gift '赠送金额'," +
                "v.rulename '交易规则',v.logtime '交易时间',v.chargeway '付款方式'," +
                "v.operid '添加人' from v_card_chargelist as v where 1=1");
            if (transId != "")
            {
                sql.Append(" and v.transId='" + transId + "'");
            }
            if (time1 != "" && time2 != "")
            {
                sql.Append(" and '" + time1 + "'<= v.logtime and v.logtime<='" + time2 + "'");
            }
            if (time1 != "" && time2 == "")
            {
                sql.Append(" and v.logtime>='" + time1 + "'");
            }
            if (time1 == "" && time2 != "")
            {
                sql.Append(" and v.logtime<='" + time2 + "'");
            }
            if (chargetype != "")
            {
                sql.Append(" and v.chargetype='" + chargetype + "'");
            }

            return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
        }

        public static DataTable DTTransLogExit(string transId, string time1, string time2)
        {
            StringBuilder sql = new StringBuilder("  select v.transId '交易编号',v.card '卡号',v.cardtype '卡类型'," +
                "v.chargetype '类型',v.amount '扣款金额',v.gift '扣款金额'," +
                "v.rulename '交易规则',v.logtime '交易时间',v.chargeway '扣款方式'," +
                "v.operid '扣款人' from v_card_chargelistInfo as v where 1=1");
            if (transId != "")
            {
                sql.Append(" and v.transId='" + transId + "'");
            }
            if (time1 != "" && time2 != "")
            {
                sql.Append(" and '" + time1 + "'<= v.logtime and v.logtime<='" + time2 + "'");
            }
            if (time1 != "" && time2 == "")
            {
                sql.Append(" and v.logtime>='" + time1 + "'");
            }
            if (time1 == "" && time2 != "")
            {
                sql.Append(" and v.logtime<='" + time2 + "'");
            }
         
            return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
        }

        public static DataTable DTTransLogTaday(string transId)
        {
            StringBuilder sql = new StringBuilder("  select v.card '卡号',v.cardtype '卡类型'," +
                "v.chargetype '类型',v.amount '充值金额',v.gift '赠送金额'," +
                "v.rulename '交易规则',v.logtime '交易时间',v.chargeway '付款方式'," +
                "v.operid '添加人' from v_card_chargelist as v where 1=1");
            if (transId != "")
            {
                sql.Append(" and v.transId='" + transId + "'");
            }
           

            return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
        }
        /// <summary>
        /// 购物扣款
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        //public static bool ChargeOnLine(tb_Card t, card_chargelist c, tb_Log log)
        //{
        //    if (t == null || c == null || log == null)
        //        return false;
        //    Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
        //    objects.Add(t, DataExecCmdType.Update);
        //    objects.Add(c, DataExecCmdType.Insert);
        //    objects.Add(log, DataExecCmdType.Insert);
        //    TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
        //    try
        //    {
        //        //提交事务
        //        DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
        //        return true;
        //    }
        //    catch (Exception exp)
        //    {

        //        DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
        //        LogHelper.Write(exp);
        //        return false;
        //    }
        //}


        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool UpdateBalanceAndInsert1(string oldbalance,string newbalance, string newgift, string cardID,card_chargelist clist,tb_Log log, int op)
        {
            if (string.IsNullOrEmpty(cardID))
            {
                return false;
            }
            List<string> strList = new List<string>();
          
            double newbal = Convert.ToDouble(newbalance) + Convert.ToDouble(newgift);
            double oldbal = Convert.ToDouble(oldbalance);
            string operatbalance = "", strSql ="";
            if (op == 0)
            {
                operatbalance = (newbal - oldbal).ToString();
                strSql = @"INSERT INTO pay_paydetail(payid,businessid,carnum,amount,tradetime,tradetype,tradeway,tradecomment,beforemoney,aftermoney,operatorid)
	VALUES(NEWID(),'" + ImsInfo.CurrentUserId + DateTime.Now.ToString("HHmmssfff") + "','" + cardID + "'," + operatbalance + ",(CONVERT([varchar](20),getdate(),(120))),0,1,'平台在线充值'," + oldbalance + "," + newbalance + ",'" + ImsInfo.CurrentUserId + "')";
            }
            else
            {
                operatbalance = (oldbal - newbal).ToString();
                strSql = @"INSERT INTO pay_paydetail(payid,businessid,carnum,amount,tradetime,tradetype,tradeway,tradecomment,beforemoney,aftermoney,operatorid)
	VALUES(NEWID(),'" + ImsInfo.CurrentUserId + DateTime.Now.ToString("HHmmssfff") + "','" + cardID + "'," + operatbalance + ",(CONVERT([varchar](20),getdate(),(120))),9,1,'平台提现'," + oldbalance + "," + newbalance + ",'" + ImsInfo.CurrentUserId + "')";
            }

            //string strSql = @"INSERT INTO pay_paydetail(payid,businessid,carnum,amount,tradetime,tradetype,tradeway,tradecomment,beforemoney,aftermoney,operatorid)
	//VALUES(NEWID(),'" + ImsInfo.CurrentUserId + DateTime.Now.ToString("HHmmssfff") + "','" + cardID + "'," + operatbalance + ",(CONVERT([varchar](20),getdate(),(120))),0,1,'平台在线充值'," + oldbalance + "," + newbalance + ",'" + ImsInfo.CurrentUserId + "')";
            strList.Add(strSql);
            //删除tb_Member
            string delsql2 = string.Format("update tb_Card set balance='{0}', giftamount={1} where Card='{2}'", newbalance, newgift, cardID);
            strList.Add(delsql2);

            //删除tb_CardActivityByShop
            string delsql3 = string.Format("insert into card_chargelist(transid, card, cardtype, chargetype, amount, gift, rulename,chargeway, operid) values('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}')", clist.transId, clist.Card, clist.cardtype, clist.Chargetype, clist.amount, clist.gift, clist.Rulename,clist.chargeway, clist.operid);
        
            strList.Add(delsql3);

            //删除tb_CardActivityByShop
            string delsql4 = string.Format("insert into tb_log(logid, operater, operate_date, type, logmsg) values('{0}','{1}','{2}','{3}','{4}')",log.logid, log.operater, log.operate_date, log.type, log.logmsg);

            strList.Add(delsql4);
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

        //public static bool UpdateCard_chargelist(card_chargelist c)
        //{
        //    Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
        //    objects.Add(c, DataExecCmdType.Update);
        //    TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
        //    try
        //    {
        //        //提交事务
        //        DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
        //        return true;
        //    }
        //    catch (Exception exp)
        //    {
        //        DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
        //        LogHelper.Write(exp);
        //        return false;
        //    }
        //}
        /// <summary>
        /// 按操作员和时间对充值表进行统计 
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static DataTable HavetimeCountCardChargeListByOperatorId(string operatorid, string starttime, string endtime)
        {
            //StringBuilder sql = new StringBuilder("select SUM(amount)as am，SUM from dbo.card_chargelist where flag=1 ");
            string strSql = "";
            strSql = @"SELECT IsNull(SUM(amount),0) AS am, IsNull(SUM(CASE chargetype WHEN '充值' THEN amount ELSE 0 END),0) AS charge_sum, 
                      IsNull(SUM(CASE chargetype WHEN '扣款' THEN amount ELSE 0 END),0) AS cancel_sum, IsNull(SUM(CASE chargetype WHEN '充值回滚' THEN amount ELSE 0 END),0) 
                      AS charge_rollback_sum, IsNull(SUM(CASE chargetype WHEN '扣款回滚' THEN amount ELSE 0 END),0) AS cancel_rollback_sum
                      FROM dbo.card_chargelist Where 1 = 1";
            if (!string.IsNullOrEmpty(operatorid) && !string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
            {
                strSql += " And operid='" + operatorid + "' And logtime>='" + starttime + "' And logtime<='" + endtime + "'";
            }
            else
            {
                if (!string.IsNullOrEmpty(operatorid))
                {
                    strSql += " And operid='" + operatorid + "'";
                }
                if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
                {
                    strSql += " And logtime>='" + starttime + "' And logtime<='" + endtime + "'";
                }
            }
            //strSql += " GROUP BY card";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
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
            //StringBuilder sql = new StringBuilder("select SUM(amount)as am，SUM from dbo.card_chargelist where flag=1 ");
            string strSql = "";
            strSql = @"SELECT ISNULL(SUM(amount),0) as vipAmount,
		                ISNULL(SUM(CASE chargetype WHEN '充值' THEN 1 ELSE 0 END),0) as vipCount
		                FROM card_chargelist 
		                WHERE 1 = 1 And cardtype='普通会员' ";
            if (!string.IsNullOrEmpty(operatorid) && !string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
            {
                strSql += " And operid='" + operatorid + "' And logtime>='" + starttime + "' And logtime<='" + endtime + "'";
            }
            else
            {
                if (!string.IsNullOrEmpty(operatorid))
                {
                    strSql += " And operid='" + operatorid + "'";
                }
                if (!string.IsNullOrEmpty(starttime) && !string.IsNullOrEmpty(endtime))
                {
                    strSql += " And logtime>='" + starttime + "' And logtime<='" + endtime + "'";
                }
            }
            //strSql += " GROUP BY card";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        /// <summary>
        /// 批量删除充值记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public static int DeleteChargeList(string time1, string time2,bool IsAll)
        {
            string strSql = "Delete From card_chargelist Where 1=1";
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2)&&!IsAll)
                strSql += " And logtime>='" + time1 + "' And logtime <='"+time2+"'";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSql);
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
            string strSql = "Delete From card_chargestatics Where 1=1";
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2) && !IsAll)
                strSql += " And logtime>='" + time1 + "' And logtime <='" + time2 + "'";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }


        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool UpdateBalanceAndInsert(string oldbalance, string newbalance, string cardID, card_chargelist clist, tb_Log log)
        {
            if (string.IsNullOrEmpty(cardID))
            {
                return false;
            }
            List<string> strList = new List<string>();

            double newbal = Convert.ToDouble(newbalance);
            double oldbal = Convert.ToDouble(oldbalance);
            string operatbalance = (newbal - oldbal).ToString();
           

            string strSql = @"INSERT INTO pay_paydetail(payid,businessid,carnum,amount,tradetime,tradetype,tradeway,tradecomment,beforemoney,aftermoney,operatorid)
            VALUES(NEWID(),'" + ImsInfo.CurrentUserId + DateTime.Now.ToString("HHmmssfff") + "','" + cardID + "'," + operatbalance + ",(CONVERT([varchar](20),getdate(),(120))),0,1,'平台在线充值'," + oldbalance + "," + newbalance + ",'" + ImsInfo.CurrentUserId + "')";
            strList.Add(strSql);
            //删除tb_Member
            string delsql2 = string.Format("update tb_Card set balance='{0}' where Card='{1}'", newbalance, cardID);
            strList.Add(delsql2);

            //删除tb_CardActivityByShop
            string delsql3 = string.Format("insert into card_chargelist(transid, card, cardtype, chargetype, amount, gift, rulename,chargeway, operid) values('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}')", clist.transId, clist.Card, clist.cardtype, clist.Chargetype, clist.amount, clist.gift, clist.Rulename, clist.chargeway, clist.operid);

            strList.Add(delsql3);

            //删除tb_CardActivityByShop
            string delsql4 = string.Format("insert into tb_log(logid, operater, operate_date, type, logmsg) values('{0}','{1}','{2}','{3}','{4}')", log.logid, log.operater, log.operate_date, log.type, log.logmsg);

            strList.Add(delsql4);
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
