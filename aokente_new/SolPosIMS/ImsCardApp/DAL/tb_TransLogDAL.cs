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
        /// ��ֵ���¼��Ϣ
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns>DataTable</returns>
        public static DataTable DTTransLog(string cardID, string typename, string time1, string time2, string siteid)
        {
            StringBuilder sql = new StringBuilder("select v.transNo '��ˮ��',v.typename '��������',v.Card '����'," +
                "v.remainMoney '��ֵǰ���',v.chargeRate '��ֵʱ����',v.ActualCost 'ʵ�ʷ������'," +
                "v.ChargeAmount '���׽��',v.finallyCost '��ֵ����',v.transTypeName '���ʽ'," +
                "v.OperateDate '��ֵʱ��' from v_card_translog as v where 1=1");
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
        /// �Գ�ֵ�����ͳ�� 
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
                if (transname == "��ֵ")
                {
                    sql.Append(" and transtype = '1'");
                }
                if (transname == "������ֵ")
                {
                    sql.Append(" and transtype = '4'");
                }
            }
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
            return dt;
        }

        #region

        /// <summary>
        /// ��ûʱ�� �Գ�ֵ��鿴��û������
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
        /// ����ʱ�� �Գ�ֵ��鿴��û������
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
        /// ��ûʱ�� �Գ�ֵ�����ɾ��
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
        /// ����ʱ�� �Գ�ֵ�����ɾ��
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
