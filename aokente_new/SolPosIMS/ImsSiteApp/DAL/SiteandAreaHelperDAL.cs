using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.PM.BLL;

namespace Ims.Site.DAL
{
    public class SiteandAreaHelperDAL
    {
        /// <summary>
        /// ---------------------------------------
        /// �ж�������Ƿ����ŵ���ʹ�ã��������ʹ��״̬������ɾ��
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Area_Times(string areacode)
        {
            string strSQL = "select COUNT(1) from dbo.tb_Site where areacode='" + areacode + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// ---------------------------------------
        /// ͳ���ŵ���
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countSite()
        {
            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//�곤
            {
                //GetSiteByAgentID ��ȡ��ǰ�˵�areacode  עֻ�� agent ��ɫ����Ա����
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select COUNT(1) from dbo.tb_Site where flag='1' and areacode = '"+ areacode +"'";
            }
            else
             strSQL = "select COUNT(1) from dbo.tb_Site where flag='1'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// ---------------------------------------
        /// �����ֵ���ն�
        /// </summary>
        /// <returns></returns>
        /// 
        public static int KcountSite()
        {
            

            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//�곤
            {
                //GetSiteByAgentID ��ȡ��ǰ�˵�areacode  עֻ�� agent ��ɫ����Ա����
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select COUNT(1) from dbo.tb_Site where flag='1' and balance!=0 or isBalance!=1  and areacode = '" + areacode + "'";
            }
            else
                strSQL = "select COUNT(1) from dbo.tb_Site where flag='1' and balance!=0 or isBalance!=1 ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// ---------------------------------------
        /// ����ŵ�ͳ��
        /// </summary>
        /// <returns></returns>
        /// 
        public static int UpateCountSite()
        {
            string strSQL = "update  dbo.tb_Site set  NUMconsume='0',NUMrecharge='0',NUMRemove='0',Moneyconsume='0',Moneyrecharge='0',MoneyRemove='0'";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }

        /// <summary>
        /// ---------------------------------------
        /// �ж��ŵ��Ƿ��Ƿ��ڿ�Ƭ����ʹ�ã��������ʹ��״̬������ɾ��
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Site_Times(string siteid)
        {
            string strSQL = "select COUNT(1) from dbo.tb_Card where regionid='" + siteid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        //-----------------2011-10-25--------------------------------
        /// <summary>
        /// ---------------------------------------
        /// �����������õ����еķֵ��������
        /// GetAllSiteByAreacodeID
        /// </summary>
        /// <returns></returns>
        /// 
        public static string GetAreacodeIDSiteBysiteID(string siteid)
        {
            string strSQL = "select areacode from dbo.tb_Site where id ='" + siteid + "'";
            return DataExecSqlHelper.ExecuteScalarSql(strSQL).ToString();

        }
        /// <summary>
        /// ͳ���ܴ���
        /// </summary>
        /// <returns></returns>
        /// 
        public static int NumPosTransaction(int num, string str)
        {
            string strSQL = "select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where Mode=" + num + " " + str;
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// ͳ���ܽ��
        /// </summary>
        /// <returns></returns>
        /// 
        public static decimal CountMoneyPosTransaction(int num, string str)
        {
            string strSQL = "select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where   Mode=" + num + " " + str;
            return (decimal)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// �ж�tb_site���Ƿ��Ѵ�����ͬ�Ļ�����        
        /// </summary>
        /// <returns></returns>
        public static int Site_Machineid(string machineid)
        {
            string strSql = "select Count(1) from dbo.tb_Site where machineid='" + machineid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        }
        /// <summary>
        ///�ж�tb_Pos_Operator �Ƿ�����ͬ����
        /// </summary>
        /// <returns></returns>
        public static int tb_Pos_Operatorid(string operatorid)
        {
            string strSql = "select Count(1) from dbo.tb_Pos_Operator where operatorid='" + operatorid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        }

        /// <summary>
        /// �ֵ�ͳ�Ƶ���
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable SiteCountOut(string where,string str)
        {
            string sqlselect = "select s.id '�ֵ���',c.areaname '��������',s.sitename '�ֵ�����',s.Category '������ҵ', (select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ")  '���ѽ����ܶ�', (select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ") '���ѽ��ױ���',(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ")  '��ֵ�����ܶ�',(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ") '��ֵ���ױ���',(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ")  '���������ܶ�',(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ") '�������ױ���' from tb_Site as s ,tb_Area as c where s.areacode=c.areacode and 1=1 " + str + "";

            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sqlselect);
            return dt;
        }

        /// <summary>
        /// ��������ͳ�Ƶ���
        /// </summary>
        /// <param name="where"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable SiteCountOutMachine(string where, string str)
        {
            string sqlselect = "select s.Machineid '������', (select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ")  '���ѽ����ܶ�', (select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ") '���ѽ��ױ���',(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ")  '��ֵ�����ܶ�',(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ") '��ֵ���ױ���',(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ")  '���������ܶ�',(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ") '�������ױ���' from tb_Site as s ,tb_Area as c where s.areacode=c.areacode and 1=1 " + str + "";

            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sqlselect);
            return dt;
        }
        /// <summary>
        ///�ж�tb_site�Ƿ���������ĳ�λ,��ɾ��·�ε�ʱ��Ҫ�ж�
        /// </summary>
        /// <returns></returns>
        public static int IsHasSpotBySiteid(string siteid)
        {
            string strSql = "select Count(1) from park_parkingsite where siteid ='" + siteid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        }
    }
}
