using System;
using System.Collections.Generic;
using System.Text;
using Ims.Site.Model;
using System.Data;
using Ims.Site.DAL;
using System.Reflection;
using ZsdDotNetLibrary.Data;

namespace Ims.Site.BLL
{
    public class AchievementChartBySiteBLL
    {
        public static int StatisticsCount = 0;
        /// <summary>
        /// 根据条件进行票据消耗统计
        /// </summary>
        /// <param name="person"></param>
        /// <param name="s_time"></param>
        /// <param name="e_time"></param>
        /// <returns></returns>
        public static List<site_statistics> GetSiteStaticsInfo(int startIndex, int pageSize, string sortedBy, site_statistics o)
        {
            DataTable dt = AchievementChartBySiteDAL.GetSiteStaticsInfows(o.siteids, o.addeddate_begin, o.addeddate_end);
            List<site_statistics> list = new List<site_statistics>();
            if (dt != null && dt.Rows.Count > 0)
                list = TableToEntity<site_statistics>(dt);

            StatisticsCount = list.Count;
            return list;
        }


        private static List<T> TableToEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();

            try
            {
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
                            if (p.Name == c.ColumnName)
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
            }
            catch (Exception ex)
            { 
            }
         
            return list;
        }
        
        /// <summary>
        /// 记录行数(统计)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetSiteStaticsInfo_Count(site_statistics o)
        {
            return StatisticsCount;
        }
        public static List<sp_collector_sites> GetPagedObjects_site_statistics(int startIndex, int pageSize, string sortedBy, SP_CalcRoadSectionsFeat o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "siteid desc";
            List<sp_collector_sites> objects = new List<sp_collector_sites>();
            pageSize = o.siteids.Split(',').Length;
            if (pageSize != 0)
            {
                DataTable dt = AchievementChartBySiteDAL.GetDataTable_Collector_Sites(o);
                List<sp_collector_sites> list = new List<sp_collector_sites>();
                DataBindHelper.BindDataTableToObjArray(dt, typeof(sp_collector_sites), objects);
            }
            //objects = ObjectData.GetPagedObjects<job_statistics>(startIndex, pageSize, sortedBy, o, "SP_CalcTollCollectorFeat", true);
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_site_statistics(SP_CalcRoadSectionsFeat o)
        {
            return o.siteids.Split(',').Length;
        }
        /// <summary>
        /// 获取路段列表
        /// </summary>
        /// <returns></returns>
        public static string GetSites()
        {
            string strSites = "";
            DataTable dt = AchievementChartBySiteDAL.GetSites();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    strSites += dr["id"].ToString();
                    strSites += ",";
                }
                strSites = strSites.TrimEnd(',');
            }
            return strSites;
        }
    }
}
