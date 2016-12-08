using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Ims.PM.DAL
{
    public class CodesDAL
    {
        /// <summary>
        /// �������е�codestype
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public static DataTable GetCodesTypeDataTable(string sys)
        {
            StringBuilder sql = new StringBuilder("select code , name , pcode from ");
            //�˹ܺ�������ѵ
            if (sys == "tt" || sys == "pm")
            {
                sql.Append(sys + "_codestype");
            }
            else
                sql.Append(sys + "_codetype");
            return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
        }

        /// <summary>
        /// �������е�codes
        /// </summary>
        /// <param name="sys"></param>
        /// <param name="codetype"></param>
        /// <returns></returns>
        public static DataTable GetCodesDataTable(string sys, string codetype)
        {
            StringBuilder sql = new StringBuilder("select id , code , name , showorder , validflag , memo from ");
            sql.Append(sys + "_codes");
            sql.Append(" where typecode = '" + codetype + "' and vindicate = 1");
            return DataExecSqlHelper.ExecuteQuerySql(sql.ToString());
        }

        /// <summary>
        /// ����code��ȡ��Ϣ
        /// </summary>
        /// <param name="sys"></param>
        /// <param name="codetype"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int GetDataFromCode(string sys, string codetype, string code)
        {
            StringBuilder sb = new StringBuilder("select id , code , name , showorder , validflag , memo from ");
            sb.Append(sys + "_codes");
            sb.Append(" where typecode = '" + codetype + "' and code = '" + code + "' and vindicate = 1");
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sb.ToString());
            return dt.Rows.Count;
        }

        /// <summary>
        /// ��ȡCheckCode����Ϣ
        /// </summary>
        /// <param name="codetype"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int GetDataFromCheckCode(string codetype, string code)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from pm_checkcode where pcode = '" + codetype + "' and code = '" + code + "'");
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sb.ToString());
            return dt.Rows.Count;
        }

        /// <summary>
        /// ɾ�����ݿ��е�codeΪ�յ�����
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public static string DeleteNullDataSql(string sys)
        {
            string tablename = sys + "_codes";
            return "delete from " + tablename + " where code is null or code = ''";
        }

        /// <summary>
        /// ɾ�����ݿ��pm_checkcode
        /// </summary>
        /// <returns></returns>
        public static string DeleteNullCheckCode()
        {
            return "delete from pm_checkcode where code is null or code = ''";
        }
    }
}
