using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.PM.DAL;
using System.Collections.Specialized;
using ZsdDotNetLibrary.Web;

namespace Ims.PM
{
    public class codesBLL
    {
        public static List<pm_codes> GetObjects(pm_codes o)
        {
            List<pm_codes> objects = ObjectData.GetObjects<pm_codes>(o);
            return objects;
        }

        public static pm_codes GetObject(string code)
        {
            pm_codes o = new pm_codes();
            o.code = code;
            checkId(o);
            return ObjectData.GetObject(o) as pm_codes;
        }

        public static void checkId(pm_codes o)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception("Id 不能为空！");
            }

        }

        #region New Method

        /// <summary>
        /// 所有的typecode
        /// </summary>
        /// <param name="sys"></param>
        /// <returns></returns>
        public static DataTable GetTypeCodes(string sys)
        {
            DataTable dt = CodesDAL.GetCodesTypeDataTable(sys);
            ListDictionary dic = new ListDictionary();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[i]["pcode"].ToString()))
                {
                    dic.Add(dt.Rows[i]["code"].ToString(), dt.Rows[i]["name"].ToString());
                    dt.Rows.RemoveAt(i);
                    --i;
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["pcode"] = GetPcodeName(dt.Rows[i]["pcode"].ToString(), dic);
            }
            return dt;
        }

        /// <summary>
        /// 所有的code
        /// </summary>
        /// <param name="sys"></param>
        /// <param name="codetype"></param>
        /// <returns></returns>
        public static DataTable GetCodes(string sys, string codetype)
        {
            return CodesDAL.GetCodesDataTable(sys, codetype);
        }

        /// <summary>
        /// 是否存在相同的code
        /// </summary>
        /// <param name="sys"></param>
        /// <param name="codetype"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool GetInfoFromCode(string sys, string codetype, string code , bool isChange)
        {
            int i = isChange ? 1 : 2;
            if (CodesDAL.GetDataFromCode(sys, codetype, code) < i)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在相同的CheckCode
        /// </summary>
        /// <param name="codetype"></param>
        /// <param name="code"></param>
        /// <param name="isChange"></param>
        /// <returns></returns>
        public static bool GetInfoFromCheckCode(string codetype, string code, bool isChange)
        {
            int i = isChange ? 1 : 2;
            if (CodesDAL.GetDataFromCheckCode(codetype, code) < i)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获得系统名称
        /// </summary>
        /// <param name="codevalue"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string GetPcodeName(string codevalue, ListDictionary dic)
        {
            codevalue = (dic[codevalue] == null) ? codevalue : dic[codevalue].ToString();
            return codevalue;
        }

        /// <summary>
        /// 删除空数据
        /// </summary>
        /// <param name="sys"></param>
        public static void DeleteNullData(string sys)
        {
            string sql = CodesDAL.DeleteNullDataSql(sys);
            DataExecSqlHelper.ExecuteNonQuerySql(sql);
        }

        /// <summary>
        /// 删除CheckCode
        /// </summary>
        public static void DeleteNullCheckcode()
        {
            string sql = CodesDAL.DeleteNullCheckCode();
            DataExecSqlHelper.ExecuteNonQuerySql(sql);
        }

        #region 通用代码操作
        public static DataTable GetTypeCode(pub_codes o)
        {
            DataTable DT = new DataTable();
            if (!string.IsNullOrEmpty(o.sys) && !string.IsNullOrEmpty(o.typecode))
            {
                DT = DataExecCmdHelper.ExecuteQueryStoredProcCommand(o);
            }
            return DT;
        }

        public static int DeleteCode(pub_codes o)
        {
            int i = 0;
            o.statu = "delete";
            DataExecCmdHelper.ExecuteNonQueryStoredProcCommand(o);
            if (!string.IsNullOrEmpty(o.statu))
                i = Convert.ToInt32(o.statu.Trim());
            return i;
        }

        public static int UpdateCode(pub_codes o)
        {
            int i = 0;
            o.statu = "update";
            DataExecCmdHelper.ExecuteNonQueryStoredProcCommand(o);
            if (!string.IsNullOrEmpty(o.statu))
                i = Convert.ToInt32(o.statu.Trim());
            return i;
        }

        public static int InsertCode(pub_codes o)
        {
            int i = 0;
            o.statu = "insert";
            DataExecCmdHelper.ExecuteNonQueryStoredProcCommand(o);
            if (!string.IsNullOrEmpty(o.statu))
                i = Convert.ToInt32(o.statu.Trim());
            return i;
        }
        #endregion

        #region 人管代码操作

        public static DataTable GetPmCode(pm_checkcode o)
        {
            DataTable DT = new DataTable();
            if (!string.IsNullOrEmpty(o.pcode))
            {
                DT = DataExecCmdHelper.ExecuteQueryStoredProcCommand(o);
            }
            return DT;
        }

        public static int DeletePmCode(pm_checkcode o)
        {
            int i = 0;
            o.statu = "delete";
            DataExecCmdHelper.ExecuteNonQueryStoredProcCommand(o);
            if (!string.IsNullOrEmpty(o.statu))
                i = Convert.ToInt32(o.statu.Trim());
            return i;
        }

        public static int UpdatePmCode(pm_checkcode o)
        {
            int i = 0;
            o.statu = "update";
            DataExecCmdHelper.ExecuteNonQueryStoredProcCommand(o);
            if (!string.IsNullOrEmpty(o.statu))
                i = Convert.ToInt32(o.statu.Trim());
            return i;
        }

        public static int InsertPmCode(pm_checkcode o)
        {
            int i = 0;
            o.statu = "insert";
            DataExecCmdHelper.ExecuteNonQueryStoredProcCommand(o);
            if (!string.IsNullOrEmpty(o.statu))
                i = Convert.ToInt32(o.statu.Trim());
            return i;
        }
        #endregion

        #endregion
    }
}
