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
        /// 判断区域号是否在门店中使用，如果在在使用状态，则不能删除
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
        /// 统计门店数
        /// </summary>
        /// <returns></returns>
        /// 
        public static int countSite()
        {
            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select COUNT(1) from dbo.tb_Site where flag='1' and areacode = '"+ areacode +"'";
            }
            else
             strSQL = "select COUNT(1) from dbo.tb_Site where flag='1'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// ---------------------------------------
        /// 允许充值的终端
        /// </summary>
        /// <returns></returns>
        /// 
        public static int KcountSite()
        {
            

            string strSQL = "";
            if (Ims.Main.ImsInfo.UserIsInRoles("agent") != "")//店长
            {
                //GetSiteByAgentID 获取当前人的areacode  注只有 agent 角色的人员才有
                string areacode = PmTtBLLHelper.GetSiteByAgentID(Ims.Main.ImsInfo.CurrentUserId);
                strSQL = "select COUNT(1) from dbo.tb_Site where flag='1' and balance!=0 or isBalance!=1  and areacode = '" + areacode + "'";
            }
            else
                strSQL = "select COUNT(1) from dbo.tb_Site where flag='1' and balance!=0 or isBalance!=1 ";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// ---------------------------------------
        /// 清除门店统计
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
        /// 判断门店是否是否在卡片中在使用，如果在在使用状态，则不能删除
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
        /// 根据区域号码得到所有的分店号与名字
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
        /// 统计总次数
        /// </summary>
        /// <returns></returns>
        /// 
        public static int NumPosTransaction(int num, string str)
        {
            string strSQL = "select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where Mode=" + num + " " + str;
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }
        /// <summary>
        /// 统计总金额
        /// </summary>
        /// <returns></returns>
        /// 
        public static decimal CountMoneyPosTransaction(int num, string str)
        {
            string strSQL = "select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where   Mode=" + num + " " + str;
            return (decimal)DataExecSqlHelper.ExecuteScalarSql(strSQL);
        }

        /// <summary>
        /// 判断tb_site中是否已存在相同的机器码        
        /// </summary>
        /// <returns></returns>
        public static int Site_Machineid(string machineid)
        {
            string strSql = "select Count(1) from dbo.tb_Site where machineid='" + machineid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        }
        /// <summary>
        ///判断tb_Pos_Operator 是否有相同数据
        /// </summary>
        /// <returns></returns>
        public static int tb_Pos_Operatorid(string operatorid)
        {
            string strSql = "select Count(1) from dbo.tb_Pos_Operator where operatorid='" + operatorid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        }

        /// <summary>
        /// 分店统计导出
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable SiteCountOut(string where,string str)
        {
            string sqlselect = "select s.id '分店编号',c.areaname '区域名称',s.sitename '分店名称',s.Category '所属行业', (select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ")  '消费交易总额', (select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ") '消费交易笔数',(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ")  '充值交易总额',(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ") '充值交易笔数',(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ")  '撤单交易总额',(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ") '撤单交易笔数' from tb_Site as s ,tb_Area as c where s.areacode=c.areacode and 1=1 " + str + "";

            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sqlselect);
            return dt;
        }

        /// <summary>
        /// 机号消费统计导出
        /// </summary>
        /// <param name="where"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable SiteCountOutMachine(string where, string str)
        {
            string sqlselect = "select s.Machineid '机器号', (select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ")  '消费交易总额', (select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=1 " + where + ") '消费交易笔数',(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ")  '充值交易总额',(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=11 " + where + ") '充值交易笔数',(select case when  SUM(Money) is not null then SUM(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ")  '撤单交易总额',(select case when  count(Money) is not null then count(Money) else 0 end as a from v_pos_transaction where PosSnr=machineid and Mode=2 " + where + ") '撤单交易笔数' from tb_Site as s ,tb_Area as c where s.areacode=c.areacode and 1=1 " + str + "";

            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sqlselect);
            return dt;
        }
        /// <summary>
        ///判断tb_site是否存在下属的车位,在删除路段的时候要判断
        /// </summary>
        /// <returns></returns>
        public static int IsHasSpotBySiteid(string siteid)
        {
            string strSql = "select Count(1) from park_parkingsite where siteid ='" + siteid + "'";
            return (int)DataExecSqlHelper.ExecuteScalarSql(strSql);
        }
    }
}
