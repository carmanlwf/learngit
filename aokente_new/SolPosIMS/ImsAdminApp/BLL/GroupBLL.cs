using System;
using System.Collections.Generic;
using System.Text;
using Ims.Admin.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;

namespace Ims.Admin.BLL
{
    public class GroupBLL
    {
        /// <summary>
        /// 根据查询条件,分页查询技能组信息
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<GroupInfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, GroupInfo o)
        {
            List<GroupInfo> objectBeans = ObjectData.GetPagedObjects<GroupInfo>(startIndex, pageSize, sortedBy, o);
            return objectBeans;
        }

        /// <summary>
        /// 根据查询条件,获取技能组信息总行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(GroupInfo o)
        {
            return ObjectData.GetObjectsCount(o);
        }
        /// <summary>
        /// 根据地区代码实体,查询技能组信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static GroupData GetObject(GroupData o)
        {
            checkId(o);
            return ObjectData.GetObject(o) as GroupData;
        }
        /// <summary>
        /// 修改技能组信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(GroupData o)
        {
            checkId(o);
            return ObjectData.UpdateObject(o);
        }
        /// <summary>
        /// 新增技能组信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(GroupData o)
        {
            checkId(o);
            return ObjectData.InsertObject(o);
        }
        /// <summary>
        /// 检查主健是否为空
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(GroupData o)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception("Id 不能为空！");
            }

        }
        /// <summary>
        /// 检查是否存在组号相同的技能组
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool CheckGroupData(GroupData o)
        {
            GroupData groupdata = ObjectData.GetObject(o) as GroupData;
            if (groupdata == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
