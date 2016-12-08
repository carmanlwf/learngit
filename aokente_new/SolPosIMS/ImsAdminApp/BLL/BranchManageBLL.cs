using System;
using System.Collections.Generic;
using System.Text;
using Ims.Admin.Model;
using Ims.Admin.DAL;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.Main;
namespace Ims.Admin.BLL
{
    /// <summary>
    /// 分公司管理业务逻辑层
    /// </summary>
    public class BranchManageBLL
    {
        /// <summary>
        /// 根据查询条件,分页查询组织结构缩写信息
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<ManageComInfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, ManageComInfo o)
        {
            List<ManageComInfo> objectBeans = ObjectData.GetPagedObjects<ManageComInfo>(startIndex, pageSize, sortedBy, o);
            return objectBeans;
        }
        /// <summary>
        /// 根据查询条件,获取组织结构缩写信息总行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(ManageComInfo o)
        {
            return ObjectData.GetObjectsCount(o);
        }

        /// <summary>
        /// 查询组对应分公司
        /// </summary>
        /// <param name="strGroupCode"></param>
        /// <returns></returns>
        public static DataTable GetBranchInGroup(string strGroupCode)
        {
            return BranchManageDAL.GetBranchInGroup(strGroupCode);
        }
        /// <summary>
        /// 查询组待选分公司
        /// </summary>
        /// <param name="strGroupCode"></param>
        /// <returns></returns>
        public static DataTable GetBranchOutGroup(string strGroupCode)
        {
            return BranchManageDAL.GetBranchOutGroup(strGroupCode);
        }
        /// <summary>
        /// 修改机构缩写信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(ManageComInfo o)
        {
            checkId(o);
            OrgshortInfo shortInfo = new OrgshortInfo();
            shortInfo.AreaCode = o.AreaCode;
            shortInfo.ShortName = o.ShortName;
            shortInfo.OrgCode = o.OrgCode;
            shortInfo.Agentinfo_id = ImsInfo.CurrentUserId;

            OrgshortInfo temp = new OrgshortInfo();
            temp.OrgCode = o.OrgCode;
            temp = ObjectData.GetObject(temp) as OrgshortInfo;
            if (temp == null)
            {
                return ObjectData.InsertObject(shortInfo);
            }
            else
            {
                return ObjectData.UpdateObject(shortInfo);
            }
        }
        /// <summary>
        /// 检查主健是否为空
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(ManageComInfo o)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception("Id 不能为空！");
            }

        }
        /// <summary>
        /// 更改分公司与技能组对照关系
        /// </summary>
        /// <param name="branchcodes"></param>
        /// <param name="groupid"></param>
        /// <param name="strOper">1、新增；2、删除</param>
        /// <returns></returns>
        public static int UpdateBranchGroupId(string branchcodes, string groupid, string strOper)
        {
            return BranchManageDAL.UpdateBranchGroupId(branchcodes, groupid, strOper);
        }
    }
}