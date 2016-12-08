using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;
using System.Data.SqlClient;
using Ims.Pos.DAL;
using Ims.Site.Model;

namespace Ims.Site.DAL
{
    public class AchievementChartBySiteDAL
    {
        /// <summary>
        /// 根据条件进行收费路段的营收统计
        /// </summary>
        /// <param name="person"></param>
        /// <param name="s_time"></param>
        /// <param name="e_time"></param>
        /// <returns></returns>
        public static DataTable GetSiteStaticsInfo(string sites, string s_time, string e_time)
        {
            if (string.IsNullOrEmpty(sites)) return null;
            string strSql = "";
            if (!string.IsNullOrEmpty(s_time) && !string.IsNullOrEmpty(e_time))
            {
                strSql = @"SELECT ISNULL(x.amount_real,0.00) as amount_real,
                            ISNULL(x.amount_receivable,0.00) as amount_receivable,
                            ISNULL(x.giving_amount,0.00) as giving_amount,y.id as siteid,y.sitename  
                            FROM (SELECT siteid, SUM([Money]) as amount_receivable,SUM([RealMoney]) as amount_real,
                            SUM(giving) as giving_amount FROM tb_POS_Transaction WHERE EndTime >='" + s_time + "' AND EndTime <='" + e_time + "' GROUP BY siteid ) as x RIGHT JOIN (SELECT id,sitename FROM tb_site WHERE id in (" + sites + ") ) as y ON x.siteid = y.id";
            }
            else
            {
                strSql = @"SELECT ISNULL(x.amount_real,0.00) as amount_real,
                            ISNULL(x.amount_receivable,0.00) as amount_receivable,
                            ISNULL(x.giving_amount,0.00) as giving_amount,y.id as siteid,y.sitename  
                            FROM (SELECT siteid, SUM([Money]) as amount_receivable,SUM([RealMoney]) as amount_real,
                            SUM(giving) as giving_amount FROM tb_POS_Transaction GROUP BY siteid ) as x
                            RIGHT JOIN (SELECT id,sitename FROM tb_site WHERE id in (" + sites + ") ) as y ON x.siteid = y.id";
            }
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }

        public static DataTable GetSiteStaticsInfows(string sites, string s_time, string e_time)
        {
            if (string.IsNullOrEmpty(sites)) return null;
            string strSql = "";


            strSql = @"select 
id as siteid, sitename, ISNULL(sum(pledge), 0.00) as giving_amount, ISNULL(sum(wirelessCharge), 0) as amount1, 
ISNULL(sum(amount_receivable), 0) as amount_receivable, ISNULL(sum(amount_real), 0) as amount_real, 
ISNULL(sum(returnMoney), 0) as ReturnMoney, ISNULL(sum(ISNULL(wirelessCharge, 0.00) + ISNULL(pledge, 0.00) + ISNULL(amount_real, 0.00) - ISNULL(returnMoney, 0.00)), 0.00) as Totality, ISNULL(sum(arrears), 0) as beforemoney3, ISNULL(sum(totalCount), 0) as num
from (select id, sitename from tb_Site where id in (" + sites + ")) as m left join (select siteid, posnum from pos_poslist) as h on m.id = h.siteid left join (select substring(businessid, 1, (charindex('_', businessid) -1)) as posnum, sum(case when tradetype = 6 then amount else 0.00 end) as pledge, sum(case when tradetype = 2 then amount else 0.00 end) as wirelessCharge, SUM(case when tradetype = 6 then 1 else 0 end) as totalCount from pay_paydetail where tradetime >= '" + s_time + "' and tradetime <= '" + e_time + "' and charindex('_', businessid) > 0 GROUP BY  substring(businessid, 1, (charindex('_', businessid) -1))) as a on h.posnum = a.posnum  left join (SELECT PosSnr, ISNULL(SUM([Money]), 0) as amount_receivable, ISNULL(SUM([RealMoney]), 0) as amount_real, ISNULL(SUM(ReturnMoney), 0) as returnMoney FROM tb_POS_Transaction where EndTime >= '" + s_time + "' and EndTime <= '" + e_time + "' GROUP BY PosSnr ) as b on a.posnum = b.PosSnr left join (select posnum, SUM(arrears) as arrears from (select detail.carnum, substring(detail.businessid, 1, charindex('_', detail.businessid) - 1) as posnum, (SUM(detail.aftermoney) - SUM(detail.beforemoney)) as arrears from (SELECT * from pay_paydetail as p1 where  EXISTS (select * from (select t.carnum, substring(businessid, 1, (charindex('_', businessid) - 1)) as posnum from (select  Row_Number() OVER(partition by carnum, substring(businessid, 1, (charindex('_', businessid) - 1)) order by tradetime DESC) as rn, p.*  FROM pay_paydetail as p where p.tradetime >= '" + s_time + "' and p.tradetime <=  '" + e_time + "' and charindex('_', businessid) > 0) as t WHERE t.rn = 1 and t.aftermoney < 0) as tt where tt.carnum = p1.carnum )) as detail where detail.tradetime >= '" + s_time + "' and detail.tradetime <= '" + e_time + "' and charindex('_', detail.businessid) > 0 GROUP BY detail.carnum, substring(detail.businessid, 1, charindex('_', detail.businessid) - 1) HAVING SUM(detail.aftermoney) - SUM(detail.beforemoney) < 0) as d GROUP BY d.posnum) as c on a.posnum = c.posnum  group by m.id, m.sitename order by Totality desc";

            //}
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
        /// <summary>
        /// 获取路段列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSites()
        {
            string strSql = "SELECT id from tb_site";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }

        /// <summary>
        /// 统计业绩存储过程
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetDataTable_Collector_Sites(SP_CalcRoadSectionsFeat o)
        {
            SqlParameter[] Para = new SqlParameter[]{                
                   new SqlParameter("@startTime", SqlDbType.VarChar,20), 
                   new SqlParameter("@endTime", SqlDbType.VarChar,20),   
                   new SqlParameter("@siteids",SqlDbType.VarChar,8000)
            };
            Para[0].Value = o.startTime;//开始时间
            Para[1].Value = o.endTime;//结束时间
            Para[2].Value = o.siteids;//人员id

            DataSet ds = SQLHelper.QueryStored("SP_CalcRoadSectionsFeat", CommandType.StoredProcedure, Para);
            return ds.Tables[0];
        }
    }
}
