using System;
using System.Collections.Generic;
using System.Text;
using Ims.Main.Model;
using System.Data;
using ZsdDotNetLibrary.Project.DAL;

namespace Ims.Main.BLL
{
    /// <summary>
    /// 用户状态业务逻辑层
    /// </summary>
    public class AgentsStatusInfo
    {

        public AgentsStatusInfo() { }

        public static DataTable GetObjects(v_agentinfo o)
        {
            DataTable objs = ObjectData.GetObjects(o);
            return objs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static List<v_agentinfo> GetIdleAgentInfosByGroupId(string groupid)
        {
            v_agentinfo queryObj = new v_agentinfo();
            queryObj.groupid = groupid;
            queryObj.access_status = "'3','2','5','6'";
            List<v_agentinfo> objs = ObjectData.GetObjects<v_agentinfo>(queryObj);
            return objs;
        }
        /// <summary>
        /// 获取处理赔组外用户信息
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public static List<v_agentinfo> GetNoClaimIdleAgentInfosByGroupId(string groupid)
        {
            v_agentinfo queryObj = new v_agentinfo();
            queryObj.groupid = groupid;
            queryObj.access_status = "'3','2','5','6'";
            List<v_agentinfo> objs = ObjectData.GetObjects<v_agentinfo>(queryObj);
            if (objs != null && objs.Count > 0)
            {
                for (int i = 0; i < objs.Count; i++)
                {
                    //移出理赔组用户（组名称中含有理赔字符）
                    if (!string.IsNullOrEmpty(objs[i].groupname) && objs[i].groupname.IndexOf("理赔") >= 0)
                    {
                        objs.Remove(objs[i]);
                        i--;
                    }
                }
            }
            return objs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="agentinfo"></param>
        /// <returns></returns>
        public static List<v_agentinfo> GetIdleAgentInfos(v_agentinfo agentinfo)
        {
            agentinfo.access_status = "'3','2','5','6'";
            List<v_agentinfo> objs = ObjectData.GetObjects<v_agentinfo>(agentinfo);
            return objs;
        }
    }
}
