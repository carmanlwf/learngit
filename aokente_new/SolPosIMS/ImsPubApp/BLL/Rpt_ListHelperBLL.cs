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
    /// 报表
    /// </summary>
   public class Rpt_ListHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<Rpt_List> GetPagedObjects(int startIndex, int pageSize, string sortedBy, Rpt_List o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "sortid asc";
            List<Rpt_List> objects = ObjectData.GetPagedObjects<Rpt_List>(startIndex, pageSize, sortedBy, o, "Rpt_List");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(Rpt_List o)
        {
            return ObjectData.GetObjectsCount(o, "Rpt_List");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Rpt_List GetObject(string id)
        {
            Rpt_List o = new Rpt_List();
            o.Rptid = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "Rpt_List") as Rpt_List;
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
        public static int InsertObject(Rpt_List o)
        {
            checkId(o, "站点编号 不能为空！");
            return ObjectData.InsertObject(o, "Rpt_List");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(Rpt_List o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "Rpt_List");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(Rpt_List o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "Rpt_List");
        }
    }
}
