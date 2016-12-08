using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Pub.Model;
using Ims.Pub.DAL;
using System.Data;

namespace Ims.Pub.BLL
{
    /// <summary>
    /// 黑名单
    /// </summary>
    public  class BlackBookHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<PUB_BlackBook> GetPagedObjects(int startIndex, int pageSize, string sortedBy, PUB_BlackBook o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "Adddate desc";
            List<PUB_BlackBook> objects = ObjectData.GetPagedObjects<PUB_BlackBook>(startIndex, pageSize, sortedBy, o, "PUB_BlackBook");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(PUB_BlackBook o)
        {
            return ObjectData.GetObjectsCount(o, "PUB_BlackBook");
        }
        /// <summary>
        /// 查询ip是否被拉黑
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsInBlack(string ip)
        {
            return BlackBookHelperDAL.IsInBlack(ip);
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static PUB_BlackBook GetObject(string id)
        {
            PUB_BlackBook o = new PUB_BlackBook();
            o.IPid = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "PUB_BlackBook") as PUB_BlackBook;
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
        public static int InsertObject(PUB_BlackBook o)
        {
            checkId(o, "站点编号 不能为空！");
            return ObjectData.InsertObject(o, "PUB_BlackBook");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(PUB_BlackBook o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "PUB_BlackBook");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(PUB_BlackBook o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "PUB_BlackBook");
        }

        /// <summary>
        /// 根据IP获取表信息
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static DataTable GetBlackBookByIP(string IP)
        {
            string sql = "select *from PUB_BlackBook where IP='" + IP + "'";
            return DataExecSqlHelper.ExecuteQuerySql(sql);
        }


    }
}
