using System;
using System.Collections.Generic;
using System.Text;
using Ims.PM.BLL;
using ZsdDotNetLibrary.Data;
using System.Data;

namespace Ims.PM.DAL
{
    public class PmCheckDAL
    {
        /// <summary>
        /// 获取考核分值
        /// </summary>
        /// <param name="code"></param>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public static string GetGrade(string code, string typecode)
        {
            string wheresql = " where code = '" + code + "' and typecode = '" + typecode + "'";
            string grade = PmTtBLLHelper.GetSingleString(wheresql, "pm_codes", "memo");
            return grade;
        }

        /// <summary>
        /// 返回小类型
        /// </summary>
        /// <param name="bigcode"></param>
        /// <returns></returns>
        public static string GetSmallReason(string bigcode)
        {
            string sql = "select code , name from pm_codes where typecode ='" + bigcode + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
            string returnStr = "";
            foreach (DataRow dr in dt.Rows)
            {
                returnStr += dr["code"] + "|" + dr["name"] + ",";
            }
            returnStr = returnStr.EndsWith(",") ? returnStr.Remove((returnStr.Length - 1)) : returnStr;
            return returnStr;
        }
    }
}
