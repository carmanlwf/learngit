using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.PM.BLL;
using Ims.PM.DAL;

namespace Ims.PM
{
    class enableBLL
    {
        #region 添加、删除用
        public static List<pm_enable> GetObjects(pm_enable o)
        {
            List<pm_enable> objects = ObjectData.GetObjects<pm_enable>(o);
            return objects;
        }

        public static pm_enable GetObject(string id)
        {
            pm_enable o = new pm_enable();
            o.id = id;
            PmTtBLLHelper.checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o) as pm_enable;
        }

        public static pm_enable GetObject(pm_enable o)
        {
            PmTtBLLHelper.checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o) as pm_enable;
        }

        public static int InsertObject(pm_enable o)
        {
            o.id = PmTtBLLHelper.EnableId();
            return ObjectData.InsertObject(o);
        }

        public static int UpdateObject(pm_enable o)
        {
            PmTtBLLHelper.checkId(o, "更新的对象不存在！");
            return ObjectData.UpdateObject(o);
        }

        #endregion 添加、删除用

        #region 查询人员信息用

        private static bool processObject(pm_enable_search o)
        {
            o.beginworktime = PmTtBLLHelper.fromYearToDate(o.beginworktime);
            o.endworktime = PmTtBLLHelper.fromYearToDate(o.endworktime);
            if (!string.IsNullOrEmpty(o.beginworktime) || !string.IsNullOrEmpty(o.endworktime))
            {
                o.endworktime = string.IsNullOrEmpty(o.endworktime) ? "1" : o.endworktime;
            }
            o.beginchangetime = PmTtBLLHelper.fromYearToDate(o.beginchangetime);
            o.endchangetime = PmTtBLLHelper.fromYearToDate(o.endchangetime);
            if (!string.IsNullOrEmpty(o.beginchangetime) || !string.IsNullOrEmpty(o.endchangetime))
            {
                o.endchangetime = string.IsNullOrEmpty(o.endchangetime) ? "1" : o.endchangetime;
            }
            o.beginentertime = PmTtBLLHelper.fromYearToDate(o.beginentertime);
            o.endentertime = PmTtBLLHelper.fromYearToDate(o.endentertime);
            if (!string.IsNullOrEmpty(o.beginentertime) || !string.IsNullOrEmpty(o.endentertime))
            {
                o.endentertime = string.IsNullOrEmpty(o.endentertime) ? "1" : o.endentertime;
            }
            o.beginguardtime = PmTtBLLHelper.fromYearToDate(o.beginguardtime);
            o.endguardtime = PmTtBLLHelper.fromYearToDate(o.endguardtime);
            if (!string.IsNullOrEmpty(o.beginguardtime) || !string.IsNullOrEmpty(o.endguardtime))
            {
                o.endguardtime = string.IsNullOrEmpty(o.endguardtime) ? "1" : o.endguardtime;
            }
            return true;
        }

        private static bool processObject(v_pm_enable o)
        {
            o.beginworktime = PmTtBLLHelper.fromYearToDate(o.beginworktime);
            o.endworktime = PmTtBLLHelper.fromYearToDate(o.endworktime);
            if (!string.IsNullOrEmpty(o.beginworktime) || !string.IsNullOrEmpty(o.endworktime))
            {
                o.endworktime = string.IsNullOrEmpty(o.endworktime) ? "1" : o.endworktime;
            }
            o.beginchangetime = PmTtBLLHelper.fromYearToDate(o.beginchangetime);
            o.endchangetime = PmTtBLLHelper.fromYearToDate(o.endchangetime);
            if (!string.IsNullOrEmpty(o.beginchangetime) || !string.IsNullOrEmpty(o.endchangetime))
            {
                o.endchangetime = string.IsNullOrEmpty(o.endchangetime) ? "1" : o.endchangetime;
            }
            o.beginentertime = PmTtBLLHelper.fromYearToDate(o.beginentertime);
            o.endentertime = PmTtBLLHelper.fromYearToDate(o.endentertime);
            if (!string.IsNullOrEmpty(o.beginentertime) || !string.IsNullOrEmpty(o.endentertime))
            {
                o.endentertime = string.IsNullOrEmpty(o.endentertime) ? "1" : o.endentertime;
            }
            o.beginguardtime = PmTtBLLHelper.fromYearToDate(o.beginguardtime);
            o.endguardtime = PmTtBLLHelper.fromYearToDate(o.endguardtime);
            if (!string.IsNullOrEmpty(o.beginguardtime) || !string.IsNullOrEmpty(o.endguardtime))
            {
                o.endguardtime = string.IsNullOrEmpty(o.endguardtime) ? "1" : o.endguardtime;
            }
            return true;
        }

        public static List<pm_enable_search> GetPagedObjects(int startIndex, int pageSize, string sortedBy, pm_enable_search o)
        {
            if (!processObject(o)) return new List<pm_enable_search>();
            List<pm_enable_search> objects = ObjectData.GetPagedObjects<pm_enable_search>(startIndex, pageSize, sortedBy, o);
            foreach (pm_enable_search pmemployee in objects)
            {
                pmemployee.joblevel = PmEmployeeDAL.GetJobLevel(pmemployee.joblevel);
                pmemployee.skilllevel = PmEmployeeDAL.GetSkillLevel(pmemployee.skilllevel);
            }
            return objects;
        }

        public static int GetObjectsCount(pm_enable_search o)
        {
            if (!processObject(o)) return 0;
            return ObjectData.GetObjectsCount(o);
        }

        #endregion 查询人员信息用

        #region 查询能力资格认证相关

        public static List<v_pm_enable> GetObjects(v_pm_enable o)
        {
            if (!processObject(o)) return new List<v_pm_enable>();
            List<v_pm_enable> objects = ObjectData.GetObjects<v_pm_enable>(o);
            return objects;
        }

        public static List<v_pm_enable> GetPagedEnableObjects(int startIndex, int pageSize, string sortedBy, v_pm_enable o)
        {
            if (!processObject(o)) return new List<v_pm_enable>();
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = " id desc";
            List<v_pm_enable> objects = ObjectData.GetPagedObjects<v_pm_enable>(startIndex, pageSize, sortedBy, o);
            return objects;
        }

        public static int GetEnableObjectsCount(v_pm_enable o)
        {
            if (!processObject(o)) return 0;
            return ObjectData.GetObjectsCount(o);
        }

        #endregion 查询能力资格认证相关
    }
}
