using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using System.Web;
using System.Data;
using ZsdDotNetLibrary.Data;
using Ims.PM.BLL;

namespace Ims.PM
{
    public class checkBLL
    {
        #region 查询用

        private static bool processObject(pm_check_v o)
        {
            o.beginworktime = PmTtBLLHelper.fromYearToDate(o.beginworktime);
            o.endworktime = PmTtBLLHelper.fromYearToDate(o.endworktime);
            if (!string.IsNullOrEmpty(o.beginworktime) | !string.IsNullOrEmpty(o.endworktime))
            {
                o.endworktime = string.IsNullOrEmpty(o.endworktime) ? "1" : o.endworktime;
            }
            o.beginchangetime = PmTtBLLHelper.fromYearToDate(o.beginchangetime);
            o.endchangetime = PmTtBLLHelper.fromYearToDate(o.endchangetime);
            if (!string.IsNullOrEmpty(o.beginchangetime) | !string.IsNullOrEmpty(o.endchangetime))
            {
                o.endchangetime = string.IsNullOrEmpty(o.endchangetime) ? "1" : o.endchangetime;
            }
            o.beginentertime = PmTtBLLHelper.fromYearToDate(o.beginentertime);
            o.endentertime = PmTtBLLHelper.fromYearToDate(o.endentertime);
            if (!string.IsNullOrEmpty(o.beginentertime) | !string.IsNullOrEmpty(o.endentertime))
            {
                o.endentertime = string.IsNullOrEmpty(o.endentertime) ? "1" : o.endentertime;
            }
            o.beginguardtime = PmTtBLLHelper.fromYearToDate(o.beginguardtime);
            o.endguardtime = PmTtBLLHelper.fromYearToDate(o.endguardtime);
            if (!string.IsNullOrEmpty(o.beginguardtime) | !string.IsNullOrEmpty(o.endguardtime))
            {
                o.endguardtime = string.IsNullOrEmpty(o.endguardtime) ? "1" : o.endguardtime;
            }
            return true;
        }

        public static List<pm_check_v> GetPagedObjects(int startIndex, int pageSize, string sortedBy, pm_check_v o)
        {
            if (!processObject(o)) return new List<pm_check_v>();
            if ( string.IsNullOrEmpty(sortedBy))
                sortedBy = " id desc ";
            List<pm_check_v> objects = ObjectData.GetPagedObjects<pm_check_v>(startIndex, pageSize, sortedBy, o);
            return objects;
        }

        public static int GetObjectsCount(pm_check_v o)
        {
            if (!processObject(o)) return 0;
            return ObjectData.GetObjectsCount(o);
        }

        #endregion 查询用

        #region 添加、删除用
        public static List<pm_check> GetObjects(pm_check o)
        {
            List<pm_check> objects = ObjectData.GetObjects<pm_check>(o);
            return objects;
        }

        public static pm_check GetObject(string id)
        {
            pm_check o = new pm_check();
            o.id = id;
            PmTtBLLHelper.checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o) as pm_check;
        }

        public static pm_check GetObject(pm_check o)
        {
            PmTtBLLHelper.checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o) as pm_check;
        }

        public static int InsertObject(pm_check o)
        {
            o.id = PmTtBLLHelper.ChectkId();
            return ObjectData.InsertObject(o);
        }

        public static int UpdateObject(pm_check o)
        {
            PmTtBLLHelper.checkId(o, "更新的对象不存在！");
            return ObjectData.UpdateObject(o);
        }

        #endregion 添加、删除用
    }
}
