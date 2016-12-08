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
        /// ����ʱ�� �Խ��ױ����ͳ�� 
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
                if (isWhere != "")//ǰ����������
                {
                    isWhere += " and  BatchSnr=" + "'" + BatchSnr + "'";
                }
                else
                {
                    isWhere = " BatchSnr=" + "'" + BatchSnr + "'";//ǰ��������
                }

            }
            if (Magcard != "")
            {

                if (isWhere != "")//ǰ����������
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
                if (isWhere != "")//ǰ����������
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
                if (isWhere != "")//ǰ����������
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
        /// �ն˽��׼�¼��ϸ��
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
            StringBuilder sql = new StringBuilder("select v.CredenceSnr '����ƾ֤��',v.PosSnr 'POS����'," +
            "v.BatchSnr  '���κ�' ,v.Magcard '����',v.UserID '����Ա��',v.Money  '�������',v .DisMoney as 'ʵ�ʷ������' ,v .DisCard as '�ۿ�', v .Point as '��������' ," +
            " v.sitename '�ֵ�����',v.ModeName '��������',v .TStatus as '״̬' , " +
            "v.Datetime '����ʱ��'  from v_pos_transaction as v where 1=1");
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
        ///  ɾ�� tb_POS_Transaction���������
        /// </summary>
        /// <returns></returns>
        public static int Deletecdtb_POS_Transaction()
        {
            string strSQL = "delete  FROM dbo.tb_POS_Transaction ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }


        /// <summary>
        ///  ɾ�� tb_POS_Transaction��������� ��ʱ��dd
        /// </summary>
        /// <returns></returns>
        public static int Deletecdtb_POS_TransactionByTime(string time1, string time2)
        {
            string strSQL = "delete from dbo.tb_POS_Transaction  where  Datetime>='" + time1 + " 00:00:00' and Datetime<='" + time2 + " 23:59:60' ";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        /// <summary>
        /// ���tb_POS_Transaction���� ʱ�� ������
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countPosTransactionBytime(string time1, string time2)
        {
            string strSQL = "select COUNT(1)  from dbo.tb_POS_Transaction  where  Datetime>='" + time1 + " 00:00:00' and Datetime<='" + time2 + " 23:59:60' ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// ���tb_POS_Transaction���� ʱ�� ������
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countPosTransaction()
        {
            string strSQL = "select COUNT(1)  from dbo.tb_POS_Transaction";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// ����ɾ���ն˽��׼�¼
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
        /// ����ɾ���ն˽��׼�¼_��ʷɾ����¼����
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
