using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Site.Model;
using ZsdDotNetLibrary.Data;
using Ims.Site.DAL;

namespace Ims.Site.BLL
{
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
        public static List<tb_area> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_area o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "regtime desc";
            List<tb_area> objects = ObjectData.GetPagedObjects<tb_area>(startIndex, pageSize, sortedBy, o, "tb_area");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_area o)
        {
            return ObjectData.GetObjectsCount(o, "tb_area");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_area GetObject(string id)
        {
            tb_area o = new tb_area();
            o.areacode = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_area") as tb_area;
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
        public static int InsertObject(tb_area o)
        {
            checkId(o, "区域编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_area");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_area o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_area");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_area o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_area");
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
            return SiteandAreaHelperDAL.Area_Times(areacode);
        }
    }
}
