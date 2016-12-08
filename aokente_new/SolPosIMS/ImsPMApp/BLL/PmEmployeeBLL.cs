using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.PM.BLL;
using Ims.PM.DAL;

namespace Ims.PM
{
    public class PmEmployeeInfo
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<pm_employee> GetPagedObjects(int startIndex, int pageSize, string sortedBy, pm_employee o)
        {
            List<pm_employee> objects = ObjectData.GetPagedObjects<pm_employee>(startIndex, pageSize, sortedBy, o, "v_site_SiteInfo");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(pm_employee o)
        {
            return ObjectData.GetObjectsCount(o);
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static pm_employee GetObject(string code)
        {
            pm_employee o = new pm_employee();
            o.code = code;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_site_SiteInfo") as pm_employee;
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
        public static int InsertObject(pm_employee o)
        {
            checkId(o, "用户编号 不能为空！");
            return ObjectData.InsertObject(o, "pm_employee");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(pm_employee o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "pm_employee");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(pm_employee o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "pm_employee");
        }

    }


}
