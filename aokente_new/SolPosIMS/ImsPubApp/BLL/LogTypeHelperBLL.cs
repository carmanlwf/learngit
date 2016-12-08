using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Pub.Model;
using Ims.Pub.DAL;

namespace Ims.Pub.BLL
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public class LogTypeHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<PUB_LogType> GetPagedObjects(int startIndex, int pageSize, string sortedBy, PUB_LogType o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "Addtime desc";
            List<PUB_LogType> objects = ObjectData.GetPagedObjects<PUB_LogType>(startIndex, pageSize, sortedBy, o, "PUB_LogType");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(PUB_LogType o)
        {
            return ObjectData.GetObjectsCount(o, "PUB_LogType");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static PUB_LogType GetObject(string logid)
        {
            PUB_LogType o = new PUB_LogType();
            o.typeid = logid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "PUB_LogType") as PUB_LogType;
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
        public static int InsertObject(PUB_LogType o)
        {
            checkId(o, "日志编号 不能为空！");
            return ObjectData.InsertObject(o, "PUB_LogType");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(PUB_LogType o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "PUB_LogType");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(PUB_LogType o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "PUB_LogType");
        }



    }
}
