using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using System.Threading;
using System.Data;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Log;
using ZsdDotNetLibrary.Project.User;
using System.Net;
using ZsdDotNetLibrary.Web;
using System.Web;
using ZsdDotNetLibrary.Web.Server;
using ZsdDotNetLibrary.Utility;
using Ims.Main.Model;
using Ims.Main;
namespace Ims.Main.BLL
{
        public class AgentInfo
        {
            static private Timer timer = CreateCheckAgentsStatusTimer();

            static private Timer CreateCheckAgentsStatusTimer()
            {
                if (ImsInfo.CurrentConfig.CheckUserActiveTime < 60) ImsInfo.CurrentConfig.CheckUserActiveTime = 60;
                Timer timer = new Timer(new TimerCallback(timerCheckAgentsStatusCallback), null, (int)10 * 1000, (int)ImsInfo.CurrentConfig.CheckUserActiveTime * 1000);

                string hostName = WebServerHelper.ServerNamePort;

                try
                {
                    DataExecSqlHelper.ExecuteNonQuerySql("update pub_agentinfo set access_status=9 where access_serverip='" + hostName + "'");
                }
                catch (Exception ex) { LogHelper.Write(ex); }
                //try
                //{
                //    DataExecSqlHelper.ExecuteNonQuerySql("update pub_sheetrole set access_status=9 where access_serverip='" + hostName + "'");
                //}
                //catch (Exception ex) { LogHelper.Write(ex); }
                return timer;
            }

            static private void timerCheckAgentsStatusCallback(object state)
            {
                if (!ImsInfo.CurrentConfig.IsCheckUserActive) return;
                UsersHelper.CheckAllUsersActive();
                //return;
                //DateTime dt = DateTime.Now - new TimeSpan(0, 1, 0);
                //string access_activetime = dt.ToString("yyyy-MM-dd HH:mm:ss");
                //DataExecSqlHelper.ExecuteNonQuerySql("update pub_agentinfo set access_status=9 where access_activetime<'" + access_activetime + "'");
            }

            public AgentInfo() { }

            static public UserInfo GetUserInfo(string id)
            {
                UserInfo currUser = new UserInfo();
                if (string.IsNullOrEmpty(id)) return currUser;
                currUser.Id = id;
                if (LoadUserInfo(id, currUser)) return currUser;
                return null;
            }

            static public List<UserInfo> GetUserInfos(string ids)
            {
                if (string.IsNullOrEmpty(ids)) return new List<UserInfo>();
                ids = StrHelper.CollectionToStr(ids.Split(','), true);
                string sql = "select * from v_pub_agentinfo where id in (" + ids + ")";
                DataTable agenttable = DataExecSqlHelper.ExecuteQuerySql(sql);
                sql = "select * from v_pub_sheetrole where id in (" + ids + ")";
                DataTable sheettable = DataExecSqlHelper.ExecuteQuerySql(sql);
                List<UserInfo> userinfos = DataBindHelper.BindDataTableToObjArray<UserInfo>(agenttable);
                DataBindHelper.BindDataTableToObjArray(sheettable, typeof(UserInfo), userinfos);
                return userinfos;
            }

            static public bool LoadUserInfo(string id, UserInfo currUser)
            {
                bool result = false;
                UserInfo userinfo = new UserInfo();
                userinfo.Id = id;
                //if (CheckIsSheetRole(id))
                //{
                //    result = ObjectData.LoadObject(userinfo, currUser, "v_pub_sheetrole");
                //}
                //else
                //{
                result = ObjectData.LoadObject(userinfo, currUser, "v_pub_agentinfo");
                    if (result && !currUser.IsSupervisor && !string.IsNullOrEmpty(currUser.GroupId))
                    {
                        string sql1 = "select id,name from v_pub_agentinfo where groupid='" + currUser.GroupId + "' and superflag=1";
                        DataTable table = DataExecSqlHelper.ExecuteQuerySql(sql1);
                        if (table.Rows.Count > 0)
                        {
                            currUser.supervisorId = table.Rows[0]["id"].ToString();
                            currUser.supervisorName = table.Rows[0]["name"].ToString();
                        }
                    }
                    if (result && id.Length == 7)
                    {
                        string orgCode = "86" + id.Substring(0, 2);
                        currUser.stationcode = orgCode;
                    }
                //}
                if (!result) return false;
                //currUser.Id = currUser.Id.TrimEnd();
                //if (!string.IsNullOrEmpty(currUser.Icmid))
                //    currUser.Icmid = currUser.Icmid.TrimEnd();
                //if (!string.IsNullOrEmpty(currUser.Obid))
                //    currUser.Obid = currUser.Obid.TrimEnd();
                //string sql = "select areaname from pub_area where areaid = '" + currUser.GroupId + "'";
                //DataTable dtBranch = DataExecSqlHelper.ExecuteQuerySql(sql);
                //Dictionary<string, string> branchs = currUser.stationcode;//??
                //for (int i = 0; i < dtBranch.Rows.Count; i++)
                //{
                //    branchs.Add(dtBranch.Rows[i]["code"].ToString(), dtBranch.Rows[i]["name"].ToString());
                //}
                //try
                //{
                //    currUser.Pwd = CryptHelper.Decrypt(currUser.Pwd);
                //    currUser.Obpwd = CryptHelper.Decrypt(currUser.Obpwd);
                //    currUser.Icmpwd = CryptHelper.Decrypt(currUser.Icmpwd);
                //}
                //catch (Exception ex) 
                //{
                //    LogHelper.Write(ex);
                //    return false;
                //}
                return true;
            }
            /// <summary>
            /// 验证是否为转办岗登录
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            static public bool CheckIsSheetRole(string id)
            {
                bool isSheetRole = false;
                if (id.Length == 7)
                {
                    //if (id[4] != '1') isSheetRole = true;
                    //else
                    //{
                    int param = 0;
                    if (int.TryParse(id.Substring(4), out param))
                    {
                        if (param < 110)
                        {
                            isSheetRole = true;
                        }
                    }
                    else
                    {
                        isSheetRole = true;
                    }
                }
                //}
                else if (id.Length == 6)
                {
                    isSheetRole = true;
                }
                return isSheetRole;
            }

            static public bool UserLogoffCallback(UserBase user, string reason)
            {
                if (user == null) return false;
                UpdateUserStatus("9", "", (UserInfo)user);
                user.LogoutReason = reason;
                string msg = string.Format("user logoff! user:{0}\r\nreason:{1}\r\n", user.ToString(), reason);
                LogWriter.Write(user.Id, msg);
                return true;
            }


            static public void UpdateUserStatus(string access_status, string access_callid, UserInfo userInfo)
            {
                string access_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (userInfo == null)
                    userInfo = UserHelper.GetUser<UserInfo>();
                if (userInfo == null) return;
                userInfo.Access_status = access_status;
                userInfo.Access_time = access_time;
                //userInfo.Access_callid = access_callid;
                userInfo.Access_activetime = access_time;
                QSession.Session.TrySet("UserInfo", userInfo);
                if (access_status == "9")
                {
                    UserInfo dbUserInfo = GetUserInfo(userInfo.Id);
                    if (dbUserInfo == null) return;
                    if (dbUserInfo.HostName != userInfo.HostName || dbUserInfo.ServerIp != userInfo.ServerIp) return;
                }
                //if (string.IsNullOrEmpty(userInfo.type))
                ObjectData.UpdateObject(userInfo, "pub_agentinfo");
                //else
                //    ObjectData.UpdateObject(userInfo, "pub_sheetrole");
            }
            /// <summary>
            /// 获取用户收到的消息id
            /// </summary>
            /// <param name="agentid"></param>
            /// <returns></returns>
            static public string GetUserReceiveMsgIds(string agentid)
            {
                if (string.IsNullOrEmpty(agentid)) agentid = ImsInfo.CurrentUserId;

                string ids = "";
                try
                {
                    DataTable table = DataExecSqlHelper.ExecuteQuerySql("select id,fromagentid,fromagentname from pub_agentmsg where toagentid='" + agentid + "' and readtime is null");
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        ids += table.Rows[i][0] + "," + table.Rows[i][1] + "," + table.Rows[i][2] + ",";
                    }
                    if (ids != "") ids = ids.Remove(ids.Length - 1);
                }
                catch { }
                return ids;
            }

            static public string UpdateUserActiveTime()
            {
                string logoffReason = "";
                return UpdateUserActiveTime(out logoffReason);
            }

            static public string UpdateUserActiveTime(out string logoffReason)
            {
                logoffReason = "";
                try
                {
                    UserInfo userInfo = UserHelper.GetUser<UserInfo>();
                    if (userInfo == null)
                    {
                        logoffReason = "会话已过期";
                        return "0";
                    }
                    userInfo.Access_activetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    userInfo.ActiveTime = DateTime.Now;
                    QSession.Session.TrySet("UserInfo", userInfo);
                    string sql = "";
                    //if (string.IsNullOrEmpty(userInfo.type))
                    //{
                        sql = string.Format("update pub_agentinfo set access_activetime='{1}' where id='{0}'",
                            userInfo.Id, userInfo.Access_activetime);

                        return ObjectData.UpdateObject(userInfo, "pub_agentinfo").ToString();
                    //}
                    //else
                    //{
                    //    //return ObjectData.UpdateObject(userInfo, "pub_sheetrole").ToString();
                    //    sql = string.Format("update pub_sheetrole set access_activetime='{1}' where id='{0}'",
                    //        userInfo.Id, userInfo.Access_activetime);
                    //}
                    //return DataExecSqlHelper.ExecuteNonQuerySql(sql).ToString();
                }
                catch (Exception ex)
                {
                    logoffReason = "发生异常";
                    LogHelper.Write(ex);
                    return ex.ToString();
                }
            }

            /// <summary>
            /// 权限验证（特殊时段报表浏览）
            /// </summary>
            /// <returns></returns>
            /// <remarks>
            /// 1、拥有此权限的用户，在任何时段都可以浏览
            /// 2、没有此权限的用户，只能在8:30-17:30(周一至周五)外浏览</remarks>
            static public bool CheckReportView()
            {
                if (ImsInfo.UserIsInRole("spec_reportview")) return true;
                else
                {
                    //8:30-17:30(周一至周五)
                    if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                    {
                        DateTime curtime = System.DateTime.Now;
                        DateTime begintime = Convert.ToDateTime(curtime.ToString("yyyy-MM-dd ") + "08:29:59");
                        DateTime finishtime = Convert.ToDateTime(curtime.ToString("yyyy-MM-dd ") + "17:31:59");
                        if (curtime > begintime && curtime < finishtime)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            /// <summary>
            /// 权限验证（特殊时段回访结果查询）
            /// </summary>
            /// <returns></returns>
            /// <remarks>
            /// 1、拥有此权限的用户，在任何时段都可以查询
            /// 2、没有此权限的用户，只能在8：30-12：00、13：00-19：00(周一至周五)外查询</remarks>
            static public bool CheckCallOutResultQuery()
            {
                if (ImsInfo.UserIsInRole("spec_outresultquery")) return true;
                else
                {
                    //8:30-17:30(周一至周五)
                    if (DateTime.Now.DayOfWeek != DayOfWeek.Saturday && DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
                    {
                        DateTime curtime = System.DateTime.Now;
                        DateTime begintime = Convert.ToDateTime(curtime.ToString("yyyy-MM-dd ") + "08:30:00");
                        DateTime finishtime = Convert.ToDateTime(curtime.ToString("yyyy-MM-dd ") + "12:00:00");

                        DateTime begintime2 = Convert.ToDateTime(curtime.ToString("yyyy-MM-dd ") + "13:00:00");
                        DateTime finishtime2 = Convert.ToDateTime(curtime.ToString("yyyy-MM-dd ") + "19:00:00");

                        if (curtime > begintime && curtime < finishtime)
                        {
                            return false;
                        }
                        else if (curtime > begintime2 && curtime < finishtime2)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            /// <summary>
            /// 验证是否外拨用户登录
            /// </summary>
            /// <param name="userInfo"></param>
            /// <returns></returns>
            static public bool CheckIsObAgent(UserInfo userInfo)
            {
                bool isObAgent = false;
                if (userInfo == null) return isObAgent;
                if (string.IsNullOrEmpty(userInfo.Id)) return isObAgent;
                if (userInfo.Id.Length == 7)
                {
                    isObAgent = true;
                }
                else if (userInfo.Id.Length == 5 && userInfo.Id.StartsWith("54"))
                {
                    isObAgent = true;
                }
                return isObAgent;
            }

        }
    }
