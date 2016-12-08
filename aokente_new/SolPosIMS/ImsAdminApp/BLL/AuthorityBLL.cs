using System;
using System.Collections.Generic;
using System.Text;
using Ims.Admin.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Admin.DAL;
using System.Data;
using System.Security.Principal;
using System.Web.UI;
using System.Web;
using System.Web.Security;
using Ims.PM;
namespace Ims.Admin.BLL
{
    /// <summary>
    /// 权限管理业务逻辑层
    /// </summary>
    public class AuthorityBLL
    {

        #region 公有方法

        /// <summary>
        /// 根据系统编号查询系统模块清单，返回Table
        /// </summary>
        /// <param name="syscode">系统编码</param>
        /// <param name="agentid">用户工号</param>
        /// <returns>系统清单Table</returns>
        public static DataTable GetSysTable(string syscode, string agentid)
        {
            DataTable dtAuthority = AuthorityDAL.GetSysTable(syscode, agentid);
            return dtAuthority;
        }

        /// <summary>
        /// 根据系统code，查询系统所包括的全部角色信息
        /// </summary>
        /// <param name="syscode">系统编码</param>
        /// <param name="agentid">用户工号</param>
        /// <returns></returns>
        public static DataTable GetRoleTableFromSyscode(string syscode, string agentid)
        {
            DataTable dtRole = AuthorityDAL.GetRoleTableFromSyscode(syscode, agentid);
            return dtRole;
        }
        /// <summary>
        /// 根据系统code，查询系统所包括的全部权限信息
        /// </summary>
        /// <param name="syscode">系统编码</param>
        /// <param name="agentid">用户工号</param>
        /// <returns></returns>
        public static DataTable GetAuthrityTableFromSyscode(string syscode, string agentid)
        {
            DataTable dtAuthrity = AuthorityDAL.GetAuthrityTableFromSyscode(syscode, agentid);
            return dtAuthrity;
        }

        /// <summary>
        ///  保存用户权限对照信息，同时删除原有系统模块内的权限
        /// </summary>
        /// <param name="agentIds">员工工号，多个用逗号分割</param>
        /// <param name="syscodes"></param>
        /// <param name="authoritys"></param>
        /// <returns></returns>
        public static bool SaveUserInAuthority(string agentIds, string syscodes,string authoritys)
        {
            if (string.IsNullOrEmpty(agentIds) || string.IsNullOrEmpty(syscodes)) return false;
            //调用数据访问层
            return AuthorityDAL.SaveUserInAuthority(agentIds, syscodes, authoritys);

        }
        /// <summary>
        /// 添加带权限的用户
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool AddUserWithAuthority(pm_employee o1, AgentData o2)
        {
            return AuthorityDAL.AddUserWithAuthority(o1, o2);
        }
         #endregion
    }
}
