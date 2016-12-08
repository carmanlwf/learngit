using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Card.DAL
{
    public class tb_TransLogDAL
    {
        /// <summary>
        /// 充值表记录信息
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
        public static DataTable DTTransLog(string cardID, string typename, string time1, string time2, string siteid)
        {
            StringBuilder sql = new StringBuilder("select v.transNo '流水号',v.typename '操作类型',v.Card '卡号'," +
                "v.remainMoney '充值前余额',v.chargeRate '充值时比率',v.ActualCost '实际发生金额'," +
                "v.ChargeAmount '交易金额',v.finallyCost '充值后金额',v.transTypeName '付款方式'," +
                "v.OperateDate '充值时间' from v_card_translog as v where 1=1");
            if (cardID != "")
            {
                sql.Append(" and v.card='" + cardID + "'");
            }
            if (time1 != "" && time2 != "")
            {
                sql.Append(" and '" + time1 + "'<= v.OperateDate and v.OperateDate<='" + time2 + "'");
            }
            if (time1 != "" && time2 == "")
            {
                sql.Append(" and v.OperateDate>='" + time1 + "'");
            }
            if (time1 == "" && time2 != "")
            {
                sql.Append(" and v.OperateDate<='" + time2 + "'");
            }
            if (siteid != "")
            {
                sql.Append(" and v.regionid='" + siteid + "'");
            }
            if (typename != "")
            {
                sql.Append(" and v.typename='" + typename + "'");
            }

            return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
        }

        /// <summary>
        /// 对充值表进行统计 
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static DataTable HavetimeCountTransLog(string cardID, string time1, string time2, string transname)
        {
            StringBuilder sql = new StringBuilder("select SUM(ActualCost) as ActualCost1,SUM(ChargeAmount) as ChargeAmount1 from dbo.tb_TransLog where 1=1 ");
            if (cardID != "")
            {
                sql.Append(" and Card='" + cardID + "'");
            }
            if (time1 != "" && time2 != "")
            {
                sql.Append(" and  '" + time1 + "'<= OperateDate    and  OperateDate<='" + time2 + "'  ");
            }
            if (time1 != "" && time2 == "")
            {
                sql.Append(" and v.OperateDate>='" + time1 + "'");
            }
            if (time1 == "" && time2 != "")
            {
                sql.Append(" and v.OperateDate<='" + time2 + "'");
            }
            if (transname != "")
            {
                if (transname == "充值")
                {
                    sql.Append(" and transtype = '1'");
                }
                if (transname == "撤销充值")
                {
                    sql.Append(" and transtype = '4'");
                }
            }
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
            return dt;
        }

        #region

        /// <summary>
        /// 当没时间 对充值表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int NotimeCountTransLog()
        {
            string strSQL = "select COUNT(1) from dbo.tb_TransLog ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        /// 当有时间 对充值表查看有没有数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HavetimeCountTransLog1(string time1, string time2)
        {
            string strSQL = "select COUNT(1) from dbo.tb_TransLog  where OperateDate>='" + time1 + " 00:00:00' and  OperateDate<='" + time2 + " 23:59:60' ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }


        /// <summary>
        /// 当没时间 对充值表进行删除
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int NotimeDeleteTransLog()
        {
            string strSQL = " delete from dbo.tb_TransLog  ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        /// <summary>
        /// 当有时间 对充值表进行删除
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <summary>
        /// </summary>
        /// <returns></returns>

        public static int HavetimeDeleteTransLog(string time1, string time2)
        {
            string strSQL = " delete from dbo.tb_TransLog   where  OperateDate>='" + time1 + " 00:00:00' and  OperateDate<='" + time2 + " 23:59:60' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        #endregion
    }
}
