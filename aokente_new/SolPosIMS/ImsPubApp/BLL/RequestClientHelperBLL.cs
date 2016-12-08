using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pub.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Pub.DAL;

namespace Ims.Pub.BLL
{
    public class RequestClientHelperBLL
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(PUB_RequestClient o)
        {
            checkId(o, "请求日志编号 不能为空！");
            return ObjectData.InsertObject(o, "PUB_RequestClient");
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
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<PUB_RequestClient> GetPagedObjects(int startIndex, int pageSize, string sortedBy, PUB_RequestClient o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "LogTime desc";
            List<PUB_RequestClient> objects = ObjectData.GetPagedObjects<PUB_RequestClient>(startIndex, pageSize, sortedBy, o, "PUB_RequestClient");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(PUB_RequestClient o)
        {
            return ObjectData.GetObjectsCount(o, "PUB_RequestClient");
        }

        /// <summary>
        ///  删除 Pub_Log里面的数据
        /// </summary>
        /// <returns></returns>
        public static int DeletePUB_RequestClient()
        {
            return PUB_RequestClientHelperDAL.DeletePUB_RequestClient();
        }


        /// <summary>
        ///  删除 Pub_Log里面的数据 根据时间
        /// </summary>
        /// <returns></returns>
        public static int DeletePUB_RequestClientBytime(string time13, string time14)
        {
            return PUB_RequestClientHelperDAL.DeletePUB_RequestClientBytime(time13,time14);
        }
    }
}
