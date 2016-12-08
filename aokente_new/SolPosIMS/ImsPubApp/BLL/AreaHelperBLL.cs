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
    /// 区域管理
    /// </summary>
   public class AreaHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<PUB_Area> GetPagedObjects(int startIndex, int pageSize, string sortedBy, PUB_Area o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "regtime desc";
            List<PUB_Area> objects = ObjectData.GetPagedObjects<PUB_Area>(startIndex, pageSize, sortedBy, o, "PUB_Area");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(PUB_Area o)
        {
            return ObjectData.GetObjectsCount(o, "PUB_Area");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static PUB_Area GetObject(string id)
        {
            PUB_Area o = new PUB_Area();
            o.areacode = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "PUB_Area") as PUB_Area;
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
        public static int InsertObject(PUB_Area o)
        {
            checkId(o, "站点编号 不能为空！");
            return ObjectData.InsertObject(o, "PUB_Area");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(PUB_Area o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "PUB_Area");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(PUB_Area o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "PUB_Area");
        }
        /// <summary>
        /// --------------------------------------
        /// 判断区域号是否在门店中使用，如果在在使用状态，则不能删除
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Area_Times(string areacode)
        {
            return DAL.SiteAndAreaHelperDAL.Area_Times(areacode);
        }
    }
}
