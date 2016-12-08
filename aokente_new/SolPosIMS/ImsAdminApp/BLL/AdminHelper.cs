using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ZsdDotNetLibrary.Data;
using Ims.Admin.DAL;
namespace Ims.Admin
{
    public class AdminHelper
    {

        /// <summary>
        /// 检查该用户是否已经登录
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool CheckUserLogin(string userid)
        {
            if (string.IsNullOrEmpty(userid)) return false;
            bool returnvalue = false;
            //bool isAgent = false;
            userid = userid.Trim();
            string sql = "select * from pub_agentinfo where id='" + userid + "'";
            DataTable table = DataExecSqlHelper.ExecuteQuerySql(sql);
            if (table != null && table.Rows.Count > 0)
            {
                //isAgent = true;
                string access_status = table.Rows[0]["access_status"].ToString();
                if (access_status != "9" && !string.IsNullOrEmpty(access_status))
                {
                    returnvalue = true;
                }
            }
            //if (!isAgent)//不是坐席的话,则从sheetrole中查询
            //{
            //    string sqlSheet = "select * from pub_sheetrole where id='" + userid + "'";
            //    DataTable tableSheet = DataExecSqlHelper.ExecuteQuerySql(sqlSheet);
            //    if (tableSheet != null && tableSheet.Rows.Count > 0)
            //    {
            //        string access_status = tableSheet.Rows[0]["access_status"].ToString();
            //        if (access_status != "9" && !string.IsNullOrEmpty(access_status))
            //        {
            //            returnvalue = true;
            //        }
            //    }
            //}
            return returnvalue;
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
            return AgentInfoDAL.DeleteMember(MenberID, MenberName); 
        }
    }
}
