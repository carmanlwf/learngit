using System;
using ZsdDotNetLibrary.Data;
using System.Data;
using System.Text;

namespace Ims.Card.DAL
{
    public class v_loss_Member_infoDAL
    {
        /// <summary>
        /// 会员流失统计信息表
        /// </summary>
        /// <param name="card"></param>
        /// <param name="realname"></param>
        /// <param name="monthquantry"></param>
        /// <returns>DataTable</returns>
        public static DataTable VlossMemberInfo(string card, string realname, string monthquantry,string siteid)
        {
            StringBuilder sql = new StringBuilder("select v.card '卡号',v.RealName '名字',v.Name '等级' ," +
                "v.sitename '分店名称', v.areaname '区域',v.Datetime1 '最后消费时间', v.monthquantry '多久没来消费（月）'" +
                "from  v_loss_member_info as v  where 1=1");
            if (card != "")
            {
                sql.Append(" and card='" + card + "'");
            }
            if (realname != "")
            {
                sql.Append(" and RealName='" + realname + "'");
            }
            if (monthquantry != "")
            {
                sql.Append(" and monthquantry='" + monthquantry + "'");
            }
            if (siteid != "")
            {
                sql.Append(" and regionid='" + siteid + "'");
            }
            return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
        }
    }
}