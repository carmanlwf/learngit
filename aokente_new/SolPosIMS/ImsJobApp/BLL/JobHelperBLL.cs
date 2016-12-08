using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Job.Model;
using System.Data;
using Ims.Job.DAL;
using System.Reflection;
using ZsdDotNetLibrary.Web;

namespace Ims.Job.BLL
{
    public class JobHelperBLL
    {
        public static int StatisticsCount = 0;
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_job_workturnlist> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_job_workturnlist o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "logtime desc";
            List<v_job_workturnlist> objects = null;
            objects = ObjectData.GetPagedObjects<v_job_workturnlist>(startIndex, pageSize, sortedBy, o, "v_job_workturnlist");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_job_workturnlist o)
        {
            return ObjectData.GetObjectsCount(o, "v_job_workturnlist");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static v_job_workturnlist GetObject(string tid)
        {
            v_job_workturnlist o = new v_job_workturnlist();
            o.turnid = tid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_job_workturnlist") as v_job_workturnlist;
        }
        /// <summary>
        /// 检查主键是否存在
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(object o, string errmessage)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception(errmessage);
            }

        }

        public static List<sp_collector_persons> GetPagedObjects_job_statistics(int startIndex, int pageSize, string sortedBy, SP_CalcTollCollectorFeat o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "operatorid desc";
            List<sp_collector_persons> objects = new List<sp_collector_persons>();
            pageSize = o.persons.Split(',').Length;
            if (pageSize != 0)
            {
                DataTable dt = JobHelperDAL.GetDataTable_Collector_Persons(o);
                List<sp_collector_persons> list = new List<sp_collector_persons>();
                DataBindHelper.BindDataTableToObjArray(dt, typeof(sp_collector_persons), objects);
            }
            //objects = ObjectData.GetPagedObjects<job_statistics>(startIndex, pageSize, sortedBy, o, "SP_CalcTollCollectorFeat", true);
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_job_statistics(SP_CalcTollCollectorFeat o)
        {
            return o.persons.Split(',').Length;
        }
        /// <summary>
        /// 根据条件进行票据消耗统计
        /// </summary>
        /// <param name="person"></param>
        /// <param name="s_time"></param>
        /// <param name="e_time"></param>
        /// <returns></returns>
        public static List<job_statistics_p> GetJobStaticsInfo(int startIndex, int pageSize, string sortedBy, job_statistics o)
        {
            DataTable dt = JobHelperDAL.GetJobStaticsInfows(o.operatorids,o.operatorid, o.addeddate_begin, o.addeddate_end, o.isSignleOrMutiply);
            List<job_statistics_p> list = new List<job_statistics_p>();
            if (dt != null && dt.Rows.Count > 0)
               list = TableToEntity<job_statistics_p>(dt);

            StatisticsCount = list.Count;

            return list;
        }

        private static List<T> TableToEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] pArray = type.GetProperties();
                T entity = new T();

                string val = string.Empty;
                object obj = null;
                foreach (PropertyInfo p in pArray)
                {
                    foreach (DataColumn c in dt.Columns)
                    {
                        if (p.Name==c.ColumnName)
                        {
                            //单个类型
                              //if (row[p.Name] is Int64)
                              //{
                              //    p.SetValue(entity, Convert.ToInt32(row[p.Name]), null); continue;
                              //}
                              //else if (row[p.Name] is Decimal)
                            //多个类型
                            val = row[p.Name].ToString();
                            //非泛型
                            if (!p.PropertyType.IsGenericType)
                                obj = string.IsNullOrEmpty(val) ? null : Convert.ChangeType(val, p.PropertyType);
                            else //泛型Nullable<>
                            {
                                Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                {
                                    obj = string.IsNullOrEmpty(val) ? null : Convert.ChangeType(val, Nullable.GetUnderlyingType(p.PropertyType));
                                }
                            }

                            p.SetValue(entity, obj, null);
                        }
                      
                    }
                   
                }
                list.Add(entity); 
            }
            return list;
        }
        
        
        
        /// <summary>
        /// 记录行数(统计)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetJobStaticsInfo_Count(job_statistics o)
        {
            return StatisticsCount;
        }
        /// <summary>
        /// 获取操作员列表 ","
        /// </summary>
        /// <returns></returns>
        public static string GetPosOperators()
        {
            string strOperators = "";
            DataTable dt = JobHelperDAL.GetPosOperators();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    strOperators += dr["operatorid"].ToString();
                    strOperators += ",";
                }
                strOperators = strOperators.TrimEnd(',');
            }
            return strOperators;
        }

        public static List<sp_collector_persons> GetPagedObjects_job_statistics_One(int startIndex, int pageSize, string sortedBy, SP_CalcTollCollectorFeat o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "newtime asc";
            List<sp_collector_persons> objects = new List<sp_collector_persons>();
            if (o != null)
            {
                pageSize = 1;
                DataTable dt = JobHelperDAL.GetDataTable_Collector_Persons_One(o);
                List<sp_collector_persons> list = new List<sp_collector_persons>();
                DataBindHelper.BindDataTableToObjArray(dt, typeof(sp_collector_persons), objects);
            }
            return objects;
        }
    }

}
