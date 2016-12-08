using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Job.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using System.Reflection;
using System.Data;

namespace Ims.Job.BLL
{
   public class RoadDateBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
       public static List<RoadDate> GetPagedObjects(int startIndex, int pageSize, string sortedBy, RoadDate o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "rdID desc";

            List<RoadDate> objects = ObjectData.GetPagedObjects<RoadDate>(startIndex, pageSize, sortedBy, o, "RoadDate");
            return objects;
        }


        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int GetObjectsCount(RoadDate o)
        {
            return ObjectData.GetObjectsCount(o, "RoadDate");
        }

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
        public static int InsertObject(RoadDate o)
        {
            //checkId(o, "日志编号 不能为空！");
            return ObjectData.InsertObject(o, "RoadDate");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(RoadDate o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "RoadDate");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(RoadDate o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "RoadDate");
        }
    }
}
