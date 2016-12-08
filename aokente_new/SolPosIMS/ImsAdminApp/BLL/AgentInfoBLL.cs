using System;
using System.Collections.Generic;
using System.Text;
using Ims.Admin.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Admin.DAL;
using System.Web;
using System.Web.Security;
using System.Data;
using Ims.PM;
namespace Ims.Admin.BLL
{
    /// <summary>
    /// 用户信息业务逻辑处理层
    /// </summary>
    public class AgentInfoBLL
    {
        /// <summary>
        /// 更改用户技能组编号
        /// </summary>
        /// <param name="agentids"></param>
        /// <param name="employeeids"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static int UpdateAgentGroupId(string agentids, string employeeids, string groupid)
        {
            return AgentInfoDAL.UpdateAgentGroupId(agentids, employeeids, groupid);
        }
        /// <summary>
        /// 更改用户的代理区域id
        /// </summary>
        /// <param name="agentids"></param>
        /// <param name="employeeids"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static int UpdateAgentAreaId(string agentids, string employeeids, string areaid)
        {
            return AgentInfoDAL.UpdateAgentAreaId(agentids, employeeids, areaid);
        }
        /// <summary>
        /// 更改用户的门店id
        /// </summary>
        /// <param name="agentids"></param>
        /// <param name="employeeids"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static int UpdateAgentSiteId(string agentids, string employeeids, string siteid)
        {
            return AgentInfoDAL.UpdateAgentSiteId(agentids, employeeids, siteid);
        }
        /// <summary>
        /// 根据地区代码实体,查询技能组信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static AgentData GetObject(AgentData o)
        {
            if (!string.IsNullOrEmpty(o.id))
            {
                return ObjectData.GetObject(o, "pub_agentinfo") as AgentData;
            }
            else if (!string.IsNullOrEmpty(o.pm_employee_id))
            {
                return AgentInfoDAL.GetAgentData(o.pm_employee_id);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(AgentData o)
        {
            MembershipUser user = Membership.GetUser(o.id);
            if (user == null)
            {
                Membership.CreateUser(o.id, o.pwd);
            }
            AgentData agentTmp = new AgentData();
            agentTmp.id = o.id;
            agentTmp = GetObject(agentTmp);

            user = Membership.GetUser(o.id);
            bool ismodify = user.ChangePassword(agentTmp.pwd, o.pwd);
            if (!ismodify)
            {
                string[] roles = Roles.GetRolesForUser(o.id);
                Membership.DeleteUser(o.id);
                Membership.CreateUser(o.id, o.pwd);
                if (roles != null && roles.Length > 0)
                {
                    Roles.AddUserToRoles(o.id, roles);
                }
            }

            return ObjectData.UpdateObject(o, "pub_agentinfo");
        }
        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(AgentData o)
        {
            checkId(o);
            MembershipUser user = Membership.GetUser(o.id);
            if (user != null)
            {
                Membership.DeleteUser(o.id, true);
            }

            Membership.CreateUser(o.id, o.pwd);
            return ObjectData.InsertObject(o, "pub_agentinfo");
        }
        //-----------------------------------------------------
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(AgentData o)
        {
            checkId(o);
            //MembershipUser user = Membership.GetUser(o.id);
            //if (user != null)
            //{
            //    Membership.DeleteUser(o.id, true);
            //}

            //Membership.CreateUser(o.id, o.pwd);
            //return ObjectData.InsertObject(o, "pub_agentinfo");
            return ObjectData.DeleteObject(o, "AgentData");
        }

        //public static int DeleteObject(tb_Order o)
        //{
        //    checkId(o, "删除失败！");
        //    return ObjectData.DeleteObject(o, "tb_Order");
        //}
        //----------------------------------------------------
        /// <summary>
        /// 检查主健是否为空
        /// </summary>
        /// <param name="o"></param>
        private static void checkId(AgentData o)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception("Id 不能为空！");
            }

        }
        /// <summary>
        /// 检查是否存在员工工号相同的用户
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool CheckAgentData(AgentData o)
        {
            AgentData agentInfo = ObjectData.GetObject(o, "pub_agentinfo") as AgentData;
            if (agentInfo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 根据查询条件,分页查询用户列表
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<AgentData> GetPagedObjects(int startIndex, int pageSize, string sortedBy, AgentData o)
        {
            List<AgentData> objectBeans = ObjectData.GetPagedObjects<AgentData>(startIndex, pageSize, sortedBy, o, "v_pub_agentquerynew");
            return objectBeans;
        }
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetObjects(AgentData o)
        {
            return ObjectData.GetObjects(o, "v_pub_agentquerynew");
        }
        /// <summary>
        /// 根据查询条件,获取用户列表总行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(AgentData o)
        {
            return ObjectData.GetObjectsCount(o, "v_pub_agentquerynew");
        }
        /// <summary>
        /// 更改用户登录密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool ChangePWD(string userid, string pwd)
        {
            MembershipUser user = Membership.GetUser(userid);
            if (user == null)
            {
                Membership.CreateUser(userid, pwd);
            }
            AgentData agentTmp = new AgentData();
            agentTmp.id = userid;
            agentTmp = GetObject(agentTmp);
            if (agentTmp == null) return false;
            bool ismodify = user.ChangePassword(agentTmp.pwd, pwd);
            if (ismodify)
            {
                AgentData o = new AgentData();
                o.id = userid;
                o.pwd = pwd;
                o.pm_employee_id = agentTmp.pm_employee_id;
                ObjectData.UpdateObject(o, "pub_agentinfo");
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool ChangePWD(string userid, string roleType, string pwd)
        {
            MembershipUser user = Membership.GetUser(userid);
            if (user == null)
            {
                Membership.CreateUser(userid, pwd);
            }
            AgentData agentTmp = new AgentData();
            agentTmp.id = userid;
            agentTmp = GetObject(agentTmp);
            if (agentTmp == null) return false;
            bool ismodify = user.ChangePassword(agentTmp.pwd, pwd);
            if (ismodify)
            {
                AgentData o = new AgentData();
                o.id = userid;
                o.pwd = pwd;
                o.roles = roleType;
                o.pm_employee_id = agentTmp.pm_employee_id;
                ObjectData.UpdateObject(o, "pub_agentinfo");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取回核心系统对应的用户ID
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        //public static BizAgent GetBizAgent(BizAgent o)
        //{
        //    return ObjectData.GetObject(o) as BizAgent;
        //}
        /// <summary>
        /// 取回核心系统对应的用户ID
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        //public static int UpdateBizAgent(BizAgent o)
        //{
        //    ObjectData.DeleteObject(o);
        //    return ObjectData.InsertObject(o);
        //}

        /// <summary>
        /// 恢复登录状态
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int BackUpAgentLoginStatus(AgentData o)
        {
            if (o != null && !string.IsNullOrEmpty(o.id))
            {
                return AgentInfoDAL.BackUpAgentLoginStatus(o);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 返回当前用户的所属品牌渠道类别
        /// </summary>
        /// <returns></returns>
        public static string GetChannelSort()
        {
            return AgentInfoDAL.GetChannelSort();
        }
                ///---------------------2011-10-25------------------------
        ///
        /// <summary>
        ///连续删除pm_employee，pub_agentinfo， Membership.DeleteUser(o.id);这些表的数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool DelectEmpAgeMemberUser(pm_employee o1, AgentData o2)
        {
            return AgentInfoDAL.DelectEmpAgeMemberUser(o1 ,o2 );
        }

        /// <summary>
        /// 获得当前用户密码
        /// </summary>
        /// <returns></returns>
        public static string GetPassWord()
        {
            return AgentInfoDAL.GetPassWord();
        }
    }
}
