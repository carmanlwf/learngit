using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Utility;
using Ims.Admin.Model;
using Ims.PM;
using ZsdDotNetLibrary.Log;
namespace Ims.Admin.DAL
{
    /// <summary>
    /// 权限管理数据访问层
    /// </summary>
    public class AuthorityDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="syscode"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static DataTable GetSysTable(string syscode, string agentid)
        {
            string sql = "";
            string sqltmp = "select code,name, '0' as 'checked' from pub_projectinfo";
            if (!string.IsNullOrEmpty(syscode))
            {
                sqltmp += " where code in ( " + syscode + " )";

            }
            if (!string.IsNullOrEmpty(agentid))
            {
                string sqltmp2 = "select t1.code,t1.name,case when t1.code=t2.code then '1' else '0' end as 'checked' from ( " + sqltmp + " ) t1 left outer join (select rolename as code from v_aspnet_userinrole where agent_id='" + agentid + "') t2 on t1.code=t2.code";
                sql = sqltmp2 + " order by t1.code";
            }
            else
            {
                sql = sqltmp + " order by code";
            }

            DataTable dtSys = DataExecSqlHelper.ExecuteQuerySql(sql);

            return dtSys;
        }

        /// <summary>
        /// 根据系统code，查询系统所包括的全部角色信息
        /// </summary>
        /// <param name="syscode">系统编码</param>
        /// <param name="agentid">用户工号</param>
        /// <returns></returns>
        public static DataTable GetRoleTableFromSyscode(string syscode, string agentid)
        {
            string sql = "";
            string sqltmp = "select code,name,syscode,code+'|'+syscode as 'itemvalue','0' as 'checked' from pub_rolesinfo";
            if (!string.IsNullOrEmpty(syscode))
            {
                sqltmp += " where syscode in ( " + syscode + " )";

            }
            if (!string.IsNullOrEmpty(agentid))
            {
                string sqltmp2 = "select t1.code,t1.name,t1.syscode,t1.itemvalue,case when t1.code=t2.rolecode then '1' else '0' end as 'checked' from ( " + sqltmp + " ) t1 left outer join (select rolename as rolecode from v_aspnet_userinrole where agent_id='" + agentid + "') t2 on t1.code=t2.rolecode";
                sql = sqltmp2 + " order by t1.syscode,t1.code";
            }
            else
            {
                sql = sqltmp + " order by syscode,code";
            }
            DataTable dtRole = DataExecSqlHelper.ExecuteQuerySql(sql);
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
            string sql = "";
            string sqltmp = "select code, rolecode,role_name,syscode,sys_name,name,code+'|'+rolecode+'|'+syscode as 'itemvalue' ,'0' as 'checked' from v_pub_authority ";
            if (!string.IsNullOrEmpty(syscode))
            {
                sqltmp += " where syscode in ( " + syscode + " )";
            }

            if (!string.IsNullOrEmpty(agentid))
            {
                string sqltmp2 = "select t1.code,t1.name,t1.rolecode,t1.role_name,t1.syscode,t1.sys_name,t1.itemvalue,case when t1.code=t2.authoritycode then '1' else '0' end as 'checked' from ( " + sqltmp + " ) t1 left outer join (select rolename as authoritycode from v_aspnet_userinrole where agent_id='" + agentid + "') t2 on  t1.code=t2.authoritycode";
                sql = sqltmp2 + " order by t1.syscode,t1.rolecode,t1.code";
            }
            else
            {
                sql = sqltmp + " order by syscode,rolecode,code";
            }
            DataTable dtAuthrity = DataExecSqlHelper.ExecuteQuerySql(sql);
            return dtAuthrity;
        }

        /// <summary>
        ///  保存用户权限对照信息
        /// </summary>
        /// <param name="agentIds">员工工号，多个用逗号分割</param>
        /// <param name="syscodes"></param>
        /// <param name="authoritys"></param>
        /// <returns></returns>
        public static bool SaveUserInAuthority(string agentIds, string syscodes, string authoritys)
        {
            if (string.IsNullOrEmpty(agentIds) || string.IsNullOrEmpty(syscodes)) return false;
            List<string> strList = new List<string>();
            //删除指定系统模块，指定用户的权限
            string[] syscodelist = syscodes.Split(',');
            for (int i = 0; i < syscodelist.Length; i++)
            {
                string delsyscode = syscodelist[i].Replace("'", "").Trim();
                string delsql = "";
                if (delsyscode == "aa" || delsyscode == "ob")
                {
                    delsql = "delete from aspnet_UsersInRoles where UserId In (select UserId from aspnet_Users where UserName in (" + agentIds + ")) and RoleId IN (select RoleId from aspnet_Roles where RoleName='" + delsyscode + "'or RoleName='pub_bizquery' or RoleName='pub_pequery' or RoleName like '" + delsyscode + "_%')";
                }
                else
                {
                    delsql = "delete from aspnet_UsersInRoles where UserId In (select UserId from aspnet_Users where UserName in (" + agentIds + ")) and RoleId IN (select RoleId from aspnet_Roles where RoleName='" + delsyscode + "' or RoleName like '" + delsyscode + "_%')";
                }
                strList.Add(delsql);
            }
            //2新增已经勾选的权限
            if (!string.IsNullOrEmpty(authoritys))
            {
                string insertsql = "insert into aspnet_UsersInRoles select t1.UserId,t2.RoleId from (select UserId,ApplicationId from aspnet_Users where UserName in (" + agentIds + ")) t1 left join (select RoleId,ApplicationId from aspnet_Roles where RoleName in (" + authoritys + ")) t2 on t1.ApplicationId=t2.ApplicationId";
                strList.Add(insertsql);
            }
            List<int> reault = DataExecSqlHelper.ExecuteNonQuerySqls(strList);
            if (reault == null) return false;
            else return true;
        }

        /// <summary>
        /// 根据系统code，查询系统所包括的权限信息
        /// </summary>
        /// <param name="syscode">系统编码</param>
        /// <returns></returns>
        public static string[] GetAuthrotyCodesFromSyscode(string syscode)
        {
            string sql = "";
            string sqltmp = "select distinct code from pub_authorityinfo ";
            if (!string.IsNullOrEmpty(syscode))
            {
                sqltmp += " where syscode in ( " + syscode + " )";
            }

            sql = sqltmp + " order by code";
          
            DataTable dtAuthrity = DataExecSqlHelper.ExecuteQuerySql(sql);
            string[] codes=null;
            if (dtAuthrity != null && dtAuthrity.Rows.Count > 0)
            {
                codes = new string[dtAuthrity.Rows.Count];
                for (int i = 0; i < dtAuthrity.Rows.Count; i++)
                {
                    codes[i] = dtAuthrity.Rows[i]["code"].ToString();
                }
            }
            return codes;
        }
        /// <summary>
        /// 添加带权限的用户
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool AddUserWithAuthority(pm_employee o1, AgentData o2)
        {
            if (o1 == null || o2 == null)
                return false;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(o1, DataExecCmdType.Insert);
            objects.Add(o2, DataExecCmdType.Insert);
            TransactonResults resultTran = DataExecCmdHelper.BeginExecuteBatCommand(objects);
            try
            {
                //提交事务
                DataExecCmdHelper.EndExecuteBatCommand(resultTran, true);
                return true;
            }
            catch (Exception exp)
            {

                DataExecCmdHelper.EndExecuteBatCommand(resultTran, false);
                LogHelper.Write(exp);
                return false;
            }
        }
    }
}
