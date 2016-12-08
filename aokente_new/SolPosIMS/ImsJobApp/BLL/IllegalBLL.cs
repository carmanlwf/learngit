using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Job.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;

namespace Ims.Job.BLL
{
   public class IllegalBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
       public static List<Illegal> GetPagedObjects(int startIndex, int pageSize, string sortedBy, Illegal o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "igID desc";

            List<Illegal> objects = ObjectData.GetPagedObjects<Illegal>(startIndex, pageSize, sortedBy, o, "Illegal");
            return objects;
        }


        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int GetObjectsCount(Illegal o)
        {
            return ObjectData.GetObjectsCount(o, "Illegal");
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
        public static int InsertObject(Illegal o)
        {
            //checkId(o, "日志编号 不能为空！");
            return ObjectData.InsertObject(o, "Illegal");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(Illegal o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "Illegal");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(Illegal o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "CarSeatState");
        }

    }
}
