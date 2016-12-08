using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Card.DAL
{
    public class tb_POS_TransactionDAL
    {
        /// <summary>
        /// 当有时间 对交易表进行统计 
        /// </summary>
        /// <param name="CredenceSnr"></param>
        /// <param name="BatchSnr"></param>
        /// <param name="Magcard"></param>
        /// <param name="Mode"></param>
        /// <param name="areacode"></param>
        /// <param name="Regionid"></param>
        /// <param name="PosSnr"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
        public static DataTable HavetimeCountPOS_Transaction(string CredenceSnr, string BatchSnr, string Magcard, string Mode, string areacode, string sitename, string PosSnr, string time1, string time2)
        {

            //StringBuilder sql = new StringBuilder("select SUM(Money) from v_pos_transaction  where 1=1");
            //if (CredenceSnr != "")
            //{
            //    sql.Append(" and CredenceSnr='" + CredenceSnr + "'");
            //}
            //if (BatchSnr != "")
            //{
            //    sql.Append(" and BatchSnr='" + BatchSnr + "'");
            //}
            //if (Magcard != "")
            //{
            //    sql.Append(" and Magcard='" + Magcard + "'");
            //}
            //if (Mode != "")
            //{
            //    sql.Append(" and Mode='" + Mode + "'");
            //}
            //if (areacode != "")
            //{
            //    sql.Append(" and areacode='" + areacode + "'");
            //}
            //if (sitename != "")
            //{
            //    sql.Append(" and Regionid='" + sitename + "'");
            //}
            //if (PosSnr != "")
            //{
            //    sql.Append(" and PosSnr='" + PosSnr + "'");
            //}

            //if (time1 != "")
            //{
            //    sql.Append(" and  Datetime>='" + time1 + " 00:00:00'");
            //}
            //if (time2 != "")
            //{ sql.Append(" and Datetime<='" + time2 + " 23:59:00'"); }

            //DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
            //return dt;


            string isWhere = "";
            if (CredenceSnr != "")
            {
                isWhere = "  CredenceSnr=" + "'" + CredenceSnr + "'";
            }
            if (BatchSnr != "")
            {
                if (isWhere != "")//前面已有条件
                {
                    isWhere += " and  BatchSnr=" + "'" + BatchSnr + "'";
                }
                else
                {
                    isWhere = " BatchSnr=" + "'" + BatchSnr + "'";//前面无条件
                }

            }
            if (Magcard != "")
            {

                if (isWhere != "")//前面已有条件
                {
                    isWhere += "  and  Magcard=" + "'" + Magcard + "'";
                }
                else
                {
                    isWhere = "  Magcard=" + "'" + Magcard + "'";
                }

            }
            if (Mode != "")
            {
                if (isWhere != "")
                {
                    isWhere += " and  Mode=" + "'" + Mode + "'";
                }
                else
                {
                    isWhere = " Mode=" + "'" + Mode + "'";
                }

            }
            if (areacode != "")
            {
                if (isWhere != "")
                {
                    isWhere += " and  areacode=" + "'" + areacode + "'";
                }
                else
                {
                    isWhere = " areacode=" + "'" + areacode + "'";
                }

            }
            if (sitename != "")
            {
                if (isWhere != "")
                {
                    isWhere += " and  Regionid=" + "'" + sitename + "'";
                }
                else
                {
                    isWhere = "  Regionid=" + "'" + sitename + "'";
                }

            }
            if (PosSnr != "")
            {
                if (isWhere != "")
                {
                    isWhere += " and  PosSnr=" + "'" + PosSnr + "'";
                }
                else
                {
                    isWhere = " PosSnr=" + "'" + PosSnr + "'";
                }

            }
            if (time1 != "")
            {
                if (isWhere != "")//前面已有条件
                {
                    isWhere += "  and  Datetime>='" + time1 + "'   ";
                }
                else
                {
                    isWhere = "  Datetime>='" + time1 + " 00:00:00'   ";
                }
            }
            if (time2 != "")
            {
                if (isWhere != "")//前面已有条件
                {
                    isWhere += "  and  Datetime<='" + time2 + " 23:59:60'   ";
                }
                else
                {
                    isWhere = "  Datetime<='" + time2 + " 23:59:60'   ";
                }
            }


            string sql1 = "select SUM(Money), SUM(DisMoney),SUM(Point) from v_pos_transaction    ";

            string sql3 = "  where  ";

            string sql4 = "";
            if (isWhere == "")
            {
                sql4 = sql1 + sql3 + "  OrStatus=0";
            }
            else
            {
                sql4 = sql1 + sql3 + isWhere + "  And   OrStatus=0";
            }
            return DataExecSqlHelper.ExecuteQuerySql(sql4);



        }

        /// <summary>
        /// 终端交易记录明细表
        /// </summary>
        /// <param name="CredenceSnr"></param>
        /// <param name="BatchSnr"></param>
        /// <param name="Magcard"></param>
        /// <param name="Mode"></param>
        /// <param name="areacode"></param>
        /// <param name="Regionid"></param>
        /// <param name="PosSnr"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
        public static DataTable PosHistory(string CredenceSnr, string BatchSnr, string Magcard, string Mode, string areacode, string sitename, string PosSnr, string time1, string time2, string siteid)
        {
            StringBuilder sql = new StringBuilder("select v.CredenceSnr '交易凭证号',v.PosSnr 'POS机号'," +
            "v.BatchSnr  '批次号' ,v.Magcard '卡号',v.UserID '操作员号',v.Money  '发生金额',v .DisMoney as '实际发生金额' ,v .DisCard as '折扣', v .Point as '产生积分' ," +
            " v.sitename '分店名称',v.ModeName '交易类型',v .TStatus as '状态' , " +
            "v.Datetime '操作时间'  from v_pos_transaction as v where 1=1");
            if (CredenceSnr != "")
            {
                sql.Append(" and v.CredenceSnr='" + CredenceSnr + "'");
            }
            if (BatchSnr != "")
            {
                sql.Append(" and v.BatchSnr='" + BatchSnr + "'");
            }
            if (Magcard != "")
            {
                sql.Append(" and v.Magcard='" + Magcard + "'");
            }
            if (Mode != "")
            {
                sql.Append(" and v.Mode='" + Mode + "'");
            }
            if (areacode != "")
            {
                sql.Append(" and v.areacode='" + areacode + "'");
            }
            if (sitename != "")
            {
                sql.Append(" and v.Regionid='" + sitename + "'");
            }
            if (PosSnr != "")
            {
                sql.Append(" and v.PosSnr='" + PosSnr + "'");
            }

            if (time1 != "")
            {
                sql.Append(" and  v.Datetime>='" + time1 + " 00:00:00'");
            }
            if (time2 != "")
            { sql.Append(" and v.Datetime<='" + time2 + " 23:59:00'"); }
            if (siteid != "")
            { sql.Append(" and v.Regionid='" + siteid + "'"); }


            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
            return dt;


        }


        /// <summary>
        ///  删除 tb_POS_Transaction里面的数据
        /// </summary>
        /// <returns></returns>
        public static int Deletecdtb_POS_Transaction()
        {
            string strSQL = "delete  FROM dbo.tb_POS_Transaction ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }


        /// <summary>
        ///  删除 tb_POS_Transaction里面的数据 有时间dd
        /// </summary>
        /// <returns></returns>
        public static int Deletecdtb_POS_TransactionByTime(string time1, string time2)
        {
            string strSQL = "delete from dbo.tb_POS_Transaction  where  Datetime>='" + time1 + " 00:00:00' and Datetime<='" + time2 + " 23:59:60' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        /// <summary>
        /// 检查tb_POS_Transaction里面 时间 有数据
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countPosTransactionBytime(string time1, string time2)
        {
            string strSQL = "select COUNT(1)  from dbo.tb_POS_Transaction  where  Datetime>='" + time1 + " 00:00:00' and Datetime<='" + time2 + " 23:59:60' ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 检查tb_POS_Transaction里面 时间 有数据
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countPosTransaction()
        {
            string strSQL = "select COUNT(1)  from dbo.tb_POS_Transaction";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// 批量删除终端交易记录
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public static int DeletePosTransDetails(string time1, string time2, bool IsAll)
        {
            string strSql = "Delete From tb_POS_Transaction Where 1=1";
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2) && !IsAll)
            {
                time1 = time1.Replace("-", "/");
                time2 = time2.Replace("-", "/");
                strSql += " And logtime>='" + time1 + "' And logtime <='" + time2 + "'";
            }
            return DataExecSqlHelper.ExecuteNonQuerySql(strSql);
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
            string strSql = "Delete From [tb_POS_Transaction_histroy] Where 1=1";
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2) && !IsAll)
            {
                time1 = time1.Replace("-", "/");
                time2 = time2.Replace("-", "/");
                strSql += " And logtime>='" + time1 + "' And logtime <='" + time2 + "'";
            }
            return DataExecSqlHelper.ExecuteNonQuerySql(strSql);
        }
    }
}
