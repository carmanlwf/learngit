using System;
using System.Collections.Generic;
using System.Text;
using Ims.Log.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;

namespace Ims.Log.BLL
{
   public  class Card_LogBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
       public static List<tb_Card_Log> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_Card_Log o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "operate_date desc";
            List<tb_Card_Log> objects = ObjectData.GetPagedObjects<tb_Card_Log>(startIndex, pageSize, sortedBy, o, "tb_Log");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int GetObjectsCount(tb_Card_Log o)
        {
            return ObjectData.GetObjectsCount(o, "tb_Card_Log");
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
       public static int InsertObject(tb_Card_Log o)
        {
            //checkId(o, "日志编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_Card_Log");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int UpdateObject(tb_Card_Log o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_Card_Log");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int DeleteObject(tb_Card_Log o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_Card_Log");
        }
    }
}
