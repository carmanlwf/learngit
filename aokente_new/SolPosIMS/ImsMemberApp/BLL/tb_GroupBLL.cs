using System;
using System.Collections.Generic;
using System.Text;
using Ims.Member.Model;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Project.DAL;

namespace Ims.Member.BLL
{
   public  class tb_GroupBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_Group> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_Group o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "AddTime desc";
            List<tb_Group> objects = ObjectData.GetPagedObjects<tb_Group>(startIndex, pageSize, sortedBy, o, "tb_Group");
            return objects;
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_Group o)
        {
            return ObjectData.GetObjectsCount(o, "tb_Group");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Group GetObject(string id)
        {
            tb_Group o = new tb_Group();
            o.GroupID = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_Group") as tb_Group;
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
        public static int InsertObject(tb_Group o)
        {
            checkId(o, "站点编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_Group");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_Group o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_Group");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_Group o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_Group");
        }
    }
}
