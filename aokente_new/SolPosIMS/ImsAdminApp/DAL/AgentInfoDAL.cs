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
    /// 用户信息数据访问层
    /// </summary>
    public class AgentInfoDAL
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
            string strSQL = "";
            if (!string.IsNullOrEmpty(agentids))
            {
                strSQL = "update pub_agentinfo set groupinfo_id='" + groupid + "' where id in (" + agentids + ")";
            }
            else
            {
                strSQL = "update pub_agentinfo set groupinfo_id='" + groupid + "' where pm_employee_id in (" + employeeids + ")";
            }
            if (string.IsNullOrEmpty(strSQL))
            {
                return 0;
            }
            else
            {
                return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
            }
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
            string strSQL = "";
            if (!string.IsNullOrEmpty(agentids))
            {
                strSQL = "update pub_agentinfo set areaid='" + areaid + "' where id in (" + agentids + ")";
            }
            else
            {
                strSQL = "update pub_agentinfo set areaid='" + areaid + "' where pm_employee_id in (" + employeeids + ")";
            }
            if (string.IsNullOrEmpty(strSQL))
            {
                return 0;
            }
            else
            {
                return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
            }
        }
        /// <summary>
        /// 更改用户的代理区域id
        /// </summary>
        /// <param name="agentids"></param>
        /// <param name="employeeids"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static int UpdateAgentSiteId(string agentids, string employeeids, string siteid)
        {
            string strSQL = "";
            if (!string.IsNullOrEmpty(agentids))
            {
                strSQL = "update pub_agentinfo set siteid='" + siteid + "' where id in (" + agentids + ")";
            }
            else
            {
                strSQL = "update pub_agentinfo set siteid='" + siteid + "' where pm_employee_id in (" + employeeids + ")";
            }
            if (string.IsNullOrEmpty(strSQL))
            {
                return 0;
            }
            else
            {
                return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
            }
        }
        /// <summary>
        /// 根据员工编号查询返回用户信息
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public static AgentData GetAgentData(string employeeid)
        {
            string sql = "select * from v_pub_agentquery where pm_employee_id='" + employeeid + "'";
            DataTable table = DataExecSqlHelper.ExecuteQuerySql(sql);
            if (table.Rows.Count <= 0) return null;
            AgentData data = new AgentData();
            data = DataBindHelper.BindDataRowToObj(table.Rows[0], data);
            if (data != null && string.IsNullOrEmpty(data.id))
            {
                data.validflag = true;
            }
            return data;
        }

        /// <summary>
        /// 恢复登录状态
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int BackUpAgentLoginStatus(AgentData o)
        {
            string strSQL = "update pub_agentinfo set access_status='9' where id='" + o.id + "'";
            return DataExecSqlHelper.ExecuteNonQuerySql(strSQL);
        }
        /// <summary>
        /// 返回当前用户的所属品牌渠道类别
        /// </summary>
        /// <returns></returns>
        public static string GetChannelSort()
        {
            string sql = "select sort from pub_agentinfo where id='" + Ims.Main.ImsInfo.CurrentUserId + "'";
            DataTable dt = new DataTable();
            dt = DataExecSqlHelper.ExecuteQuerySql(sql);
            return dt.Rows[0][0].ToString();;
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
            if (o1 == null || o2 == null)
                return false;
            Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
            objects.Add(o1, DataExecCmdType.Delete );
            objects.Add(o2, DataExecCmdType.Delete  );
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



        ///
        /// <summary>
        ///连续删除 aspnet_UsersInRoles pub_agentinfo   pm_employee   aspnet_Users   aspnet_Membership;这些表的数据
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>

        public static bool DeleteMember(string MenberID, string MenberName)
        {
            if (string.IsNullOrEmpty(MenberID) || string.IsNullOrEmpty(MenberName))
            {
                return false;
            }
            List<string> strList = new List<string>();
            //删除aspnet_UsersInRoles
            string delsql11 = "delete aspnet_UsersInRoles where UserId=(select userid from  aspnet_Users  where LoweredUserName='" + MenberName + "')";
            strList.Add(delsql11);

            //删除pub_agentinfo
            string delsql1 = "delete aspnet_Membership where UserId=(select userid from  aspnet_Users  where LoweredUserName='" + MenberName + "')";
            strList.Add(delsql1);

            //删除pm_employee
            string delsql2 = "delete from pub_agentinfo  where pm_employee_id='" + MenberID + "'";
            strList.Add(delsql2);
            //删除aspnet_Users
            string delsql3 = "delete from  pm_employee where code='" + MenberID + "'";
            strList.Add(delsql3);
            //删除aspnet_Membership
            string delsql4 = "delete   from  aspnet_Users  where UserId=(select userid from  aspnet_Users  where LoweredUserName='" + MenberName + "')";
            strList.Add(delsql4);

            List<int> reault = DataExecSqlHelper.ExecuteNonQuerySqls(strList);
            if (reault == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获得当前用户密码11
        /// </summary>
        /// <returns></returns>
        public static string GetPassWord()
        {
            string sql = "select pwd  from dbo.pub_agentinfo where id ='" + Ims.Main.ImsInfo.CurrentUserId + "'";
            DataTable dt = new DataTable();
            dt = DataExecSqlHelper.ExecuteQuerySql(sql);
            return dt.Rows[0][0].ToString(); ;
        }
    }
}
