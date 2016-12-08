using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Site.Model;

namespace Ims.Site.BLL
{
   public class AlarmTracelistBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
       public static List<V_AlarmTracelist> GetPagedObjects(int startIndex, int pageSize, string sortedBy, V_AlarmTracelist o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "Name desc";
            V_AlarmTracelist t = getProperties(o);
            t.IsOutBounds = "1";
            List<V_AlarmTracelist> objects = ObjectData.GetPagedObjects<V_AlarmTracelist>(startIndex, pageSize, sortedBy, t, "V_AlarmTracelist");
            return objects;
        }

       public static V_AlarmTracelist getProperties<T>(T t)
       {
           Type Ts = t.GetType();
           V_AlarmTracelist o = new V_AlarmTracelist();
           System.Reflection.PropertyInfo[] properties = Ts.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

           foreach (System.Reflection.PropertyInfo item in properties)
           {
               string name = item.Name;
               object value = item.GetValue(t, null);
               if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
               {
                   if (value != null && !string.IsNullOrEmpty(value.ToString()))
                   {
                       Ts.GetProperty(name).SetValue(o, value, null);
                   }

               }
               else
               {
                   getProperties(value);
               }
           }
           return o;

       }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(V_AlarmTracelist o)
        {
            V_AlarmTracelist t = getProperties(o);
            t.IsOutBounds = "1";
            return ObjectData.GetObjectsCount(t, "V_AlarmTracelist");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static V_AlarmTracelist GetObject(string id)
        {
            V_AlarmTracelist o = new V_AlarmTracelist();
            o.Id = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "V_AlarmTracelist") as V_AlarmTracelist;
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
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(V_AlarmTracelist o)
        {
            checkId(o, "区域编号 不能为空！");
            return ObjectData.InsertObject(o, "V_AlarmTracelist");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(V_AlarmTracelist o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "V_AlarmTracelist");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(V_AlarmTracelist o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "V_AlarmTracelist");
        }
    }
}
