using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;

namespace Ims.Pos.DAL
{
    public class GetSiteListHelperDAL
    {
        public static DataTable GetSiteListInfo()
        {
            string strSql = "SELECT	a.id AS siteid, a.SiteName,	b.name, c.num FROM tb_Site as a LEFT JOIN (select siteid,userid,name from (select *,row_number() over(partition by siteid order by endtime desc) as rw from tb_POS_Transaction where left(starttime,10) = convert(varchar(10),getdate(),120)) as d, tb_Pos_Operator where userid = operatorid and rw = 1) as b ON a.id = b.siteid left join (select siteid, count(*) as num from tb_POS_Transaction where left(StartTime, 10) = convert(VARCHAR(10),getdate(),120) and mode = 0 group by siteid) as c on a.id = c.siteid ";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            return dt;
        }
    }
}
