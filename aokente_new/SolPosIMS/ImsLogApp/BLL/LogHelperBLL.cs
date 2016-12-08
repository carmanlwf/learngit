using System;
using System.Collections.Generic;
using System.Text;
using Ims.Log.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Log.DAL;

namespace Ims.Log.BLL
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
        public static List<tb_Log> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_Log o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "operate_date desc";
            List<tb_Log> objects = ObjectData.GetPagedObjects<tb_Log>(startIndex, pageSize, sortedBy, o, "tb_Log");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_Log o)
        {
            return ObjectData.GetObjectsCount(o, "tb_Log");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Log GetObject(string logid)
        {
            tb_Log o = new tb_Log();
            o.logid = logid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_Log") as tb_Log;
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
        public static int InsertObject(tb_Log o)
        {
            checkId(o, "日志编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_Log");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_Log o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_Log");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_Log o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_Log");
        }





              
        /// <summary>
        ///  删除 tb_Log里面的数据
        /// </summary>
        /// <returns></returns>
        public static int Deletecdttb_Log()
        {
            return tb_LogDAL.Deletecdttb_Log();
        }


        
        /// <summary>
        ///  删除 tb_Log里面的数据 有时间
        /// </summary>
        /// <returns></returns>
        public static int Deletecdttb_LogBytime(string time1, string time2)
        {
            return tb_LogDAL.Deletecdttb_LogBytime(time1, time2);
        }


          
        /// <summary>
        ///  果看里面有没有数据
        /// </summary>
        /// <returns></returns>
        /// 

        public static int counlogbytime(string time1, string time2)
        {
            return tb_LogDAL.counlogbytime(time1, time2);
        }
        /// <summary>
        /// 记录pos机的请求日志
        /// </summary>
        /// <param name="logid"></param>
        /// <param name="cmdtype"></param>
        /// <param name="rawurl"></param>
        /// <param name="requrl"></param>
        /// <param name="rtnstr"></param>
        public static void PosReqLog(string logid, string posno, string cmdtype, string rawurl, string requrl, string rtnstr)
        {
            tb_LogDAL.PosReqLog(logid, posno, cmdtype, rawurl, requrl, rtnstr);
        }
    }
}
