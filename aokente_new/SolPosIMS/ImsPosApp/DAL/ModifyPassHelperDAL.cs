using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ZsdDotNetLibrary.Data;
using System.Data;

namespace Ims.Pos.DAL
{
    public class ModifyPassHelperDAL
    {
        public static bool checkUserExist(string userid)
        {
            string strSql = "select * from tb_Pos_Operator where operatorid = '" + userid + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (null != dt && dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static bool checkPassIsCorrect(string userid, string pass)
        {
            string strSql = "select * from tb_Pos_Operator where operatorid = '" + userid + "' and pass = '" + pass + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (null != dt && dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static int modifyPass(string userid, string pass)
        {
            string strSql = "update tb_Pos_Operator set pass = '" + pass + "' where operatorid = '" + userid + "'";
            int ret = DataExecSqlHelper.ExecuteNonQuerySql(strSql);
            return ret;
        }
    }
}
