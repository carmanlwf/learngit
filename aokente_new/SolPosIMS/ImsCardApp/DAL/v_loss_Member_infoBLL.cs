using System;
using ZsdDotNetLibrary.Data;
using System.Data;
using System.Text;

namespace Ims.Card.DAL
{
    public class v_loss_Member_infoDAL
    {
        /// <summary>
        /// ��Ա��ʧͳ����Ϣ��
        /// </summary>
        /// <param name="card"></param>
        /// <param name="realname"></param>
        /// <param name="monthquantry"></param>
        /// <returns>DataTable</returns>
        public static DataTable VlossMemberInfo(string card, string realname, string monthquantry,string siteid)
        {
            StringBuilder sql = new StringBuilder("select v.card '����',v.RealName '����',v.Name '�ȼ�' ," +
                "v.sitename '�ֵ�����', v.areaname '����',v.Datetime1 '�������ʱ��', v.monthquantry '���û�����ѣ��£�'" +
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