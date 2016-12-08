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
    public class LogHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<Pub_Log> GetPagedObjects(int startIndex, int pageSize, string sortedBy, Pub_Log o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "operate_date desc";
            List<Pub_Log> objects = ObjectData.GetPagedObjects<Pub_Log>(startIndex, pageSize, sortedBy, o, "v_pub_Log");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(Pub_Log o)
        {
            return ObjectData.GetObjectsCount(o, "v_pub_Log");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Pub_Log GetObject(string logid)
        {
            Pub_Log o = new Pub_Log();
            o.logid = logid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_pub_Log") as Pub_Log;
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
        public static int InsertObject(Pub_Log o)
        {
            checkId(o, "日志编号 不能为空！");
            return ObjectData.InsertObject(o, "Pub_Log");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(Pub_Log o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "Pub_Log");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(Pub_Log o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "Pub_Log");
        }






        /// <summary>
        ///  删除 Pub_Log里面的数据
        /// </summary>
        /// <returns></returns>
        public static int DeletePub_Log()
        {
            return LogHelperDAL.DeletePub_Log();
        }



        /// <summary>
        ///  删除 Pub_Log里面的数据 根据时间
        /// </summary>
        /// <returns></returns>
        public static int DeletePub_LogBytime(string time3, string time4)
        {
            return LogHelperDAL.DeletePub_LogBytime(time3, time4);
        }



        /// <summary>
        ///  果看里面有没有数据
        /// </summary>
        /// <returns></returns>
        /// 

        public static int counlogbytime(string time1, string time2)
        {
            return LogHelperDAL.counlogbytime(time1, time2);
        }
    }
}
