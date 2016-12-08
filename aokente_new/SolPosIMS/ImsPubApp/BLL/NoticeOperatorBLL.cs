using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Web;
using Ims.Pub.Model;
using System.Data;
using ZsdDotNetLibrary.Project.DAL;
using System.Web;
using Ims.Main;
using System.Web.UI.WebControls;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Pub.BLL
{
    public class NoticeOperatorBLL
    {
        ///// <summary>
        ///// 初始化岗位复选框集合
        ///// </summary>
        ///// <param name="cbl"></param>
        ///// <param name="list"></param>
        //static public void initStation(CheckBoxList cbl, List<pub_noticegroup> list)
        //{
        //    foreach (pub_noticegroup o in list)
        //    {
        //        for (int i = 0; i < cbl.Items.Count; i++)
        //        {
        //            if (cbl.Items[i].Value == o.groupcode)
        //            {
        //                cbl.Items[i].Selected = true;
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 更新或新增公告信息
        /// </summary>
        /// <param name="o"></param>
        /// <param name="cbl"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        //static public bool manageNoticeInfo(pub_noticeinfo o, CheckBoxList cbl, bool type)
        //{
        //    Dictionary<object, DataExecCmdType> objects = new Dictionary<object, DataExecCmdType>();
        //    if (!type)//更新
        //    {
        //        o.agentinfo_id = ImsInfo.CurrentUserId;
        //        objects.Add(o, DataExecCmdType.Update);
        //        pub_noticegroup ng = new pub_noticegroup();
        //        ng.notice_id = o.id;
        //        objects.Add(ng, DataExecCmdType.DeleteWhere);

        //        pub_noticeagent na = new pub_noticeagent();
        //        na.notice_id = o.id;
        //        objects.Add(na, DataExecCmdType.DeleteWhere);
        //    }
        //    else //新增
        //    {
        //        o.id = DateTime.Now.ToString("yyMMddHHmmss");
        //        o.starttime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //        o.agentinfo_id = ImsInfo.CurrentUserId;
        //        objects.Add(o, DataExecCmdType.Insert);
        //    }

        //    string[] stationlist = TmControlHelperBLL.transferListToArray(cbl);
        //    List<string> station = new List<string>(stationlist);
        //    if (station[0] == "") station.RemoveAt(0);
        //    pub_noticegroup[] ngs = new pub_noticegroup[station.Count];
        //    for (int i = 0; i < station.Count; i++)
        //    {
        //        ngs[i] = new pub_noticegroup();
        //        ngs[i].notice_id = o.id;
        //        ngs[i].groupcode = station[i];
        //        objects.Add(ngs[i], DataExecCmdType.Insert);
        //        /*
        //                        pub_noticeagent[] nas = getAgentInsertArray(o.id, station[i]);
        //                        for (int j = 0; j < nas.Length; j++) 
        //                        {
        //                            objects.Add(nas[j], DataExecCmdType.Insert);
        //                        }*/
        //    }
        //    ArrayList al = DataExecCmdHelper.ExecuteBatCommand(objects);
        //    return al == null ? false : true;
        //}
        /// <summary>
        /// 根据组号获得座席号集合
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupcode"></param>
        /// <returns></returns>
        //static public pub_noticeagent[] getAgentInsertArray(string id, string groupcode)
        //{
        //    Ncl.Notice.Model.pub_agentinfo ai = new Ims.Pub.Notice.Model.pub_agentinfo();
        //    ai.groupinfo_id = groupcode;
        //    ai.validflag = true;
        //    List<Ncl.Notice.Model.pub_agentinfo> list = ObjectData.GetObjects<Ims.Main.Model.pub_agentinfo>(ai);
        //    pub_noticeagent[] nas = new pub_noticeagent[list.Count];
        //    int i = 0;
        //    foreach (Ims.Pub.Notice.Model.pub_agentinfo agent in list)
        //    {
        //        nas[i] = new pub_noticeagent();
        //        nas[i].notice_id = id;
        //        nas[i].agent_id = agent.id;
        //        nas[i].displayflag = false;
        //        nas[i].readflag = false;
        //        i++;
        //    }
        //    return nas;
        //}
        /// <summary>
        /// 根据登录者ID获得公告查询对象
        /// </summary>
        /// <param name="agent_id"></param>
        /// <returns></returns>
        static public v_pub_noticeagentinfo getNoticeFromAgentId()
        {
            v_pub_noticeagentinfo info = new v_pub_noticeagentinfo();
            info.displayflag = true;
            info.validflag = true;
            info.validdate = info.beginvaliddate = DateTime.Now.ToString("yyyy-MM-dd");
            info.agentid = ImsInfo.CurrentUserId;
            return info;
        }
        /// <summary>
        /// 更新公告是否显示标志
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        static public int updateAgentDisplayFlag()
        {
            string notice_id = HttpContext.Current.Request.QueryString["id"];
            string agent_id = ImsInfo.CurrentUserId;
            string sql = "update pub_noticeagent set displayflag = 0 where notice_id = '" + notice_id + "' and agent_id = '" + agent_id + "'";
            int i = DataExecSqlHelper.ExecuteNonQuerySql(sql);
            return i;
        }
        /// <summary>
        /// 更新公告是否已读标志
        /// </summary>
        static public void updateAgentReadFlag()
        {
            string notice_id = HttpContext.Current.Request.QueryString["id"];
            string agent_id = ImsInfo.CurrentUserId;
            string sql = "insert pub_noticeagent(agent_id,notice_id,readflag,displayflag) values('" + agent_id + "','" + notice_id + "',1,1)";
            int i = DataExecSqlHelper.ExecuteNonQuerySql(sql);
        }
        /// <summary>
        /// 获取滚动公告信息集合
        /// </summary>
        /// <returns></returns>
        static public DataTable getNoticeRollInfo()
        {
            v_pub_noticeagentinfo o = getNoticeFromAgentId();
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(o);
            bool rollflag = false;
            string color;
            string title;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                rollflag = Convert.ToBoolean(dt.Rows[i]["rollflag"].ToString());
                if (!rollflag)
                {
                    dt.Rows.RemoveAt(i);
                    i--;
                }
                else
                {
                    color = dt.Rows[i]["color"].ToString();
                    title = "<font color='" + color + "'>" + dt.Rows[i]["title"].ToString() + "</font>";
                    if (Convert.ToBoolean(dt.Rows[i]["boldflag"].ToString()))
                        title = "<b>" + title + "</b>";
                    dt.Rows[i]["title"] = System.Web.HttpUtility.HtmlDecode(title);
                }
            }
            return dt;
        }
        /// <summary>
        /// 座席是否有查看公告详情权限
        /// </summary>
        /// <returns></returns>
        static public bool getAuthorityOfAgentNotice()
        {
            bool hasAu = false;
            pub_noticeagent o = ParameterBindHelper.BindParameterToObject<pub_noticeagent>(BindParameterUsage.OpQuery);

            List<pub_noticeagent> objs = ObjectData.GetObjects<pub_noticeagent>(o);
            foreach (pub_noticeagent na in objs)
            {
                if (na.agent_id == Ims.Main.ImsInfo.CurrentUserId && !((bool)na.displayflag))
                {
                    hasAu = true;
                    break;
                }
            }
            return hasAu;
        }
        /// <summary>
        /// 删除公告信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        static public bool DelNotice(pub_noticeinfo o)
        {
            if (o != null && !string.IsNullOrEmpty(o.id))
            {
                List<string> strList = new List<string>();
                //删除公告信息
                string sqldel = "delete from pub_noticeinfo where id='" + o.id + "'";
                strList.Add(sqldel);
                //删除pub_noticegroup
                string sqldelgroup = "delete from pub_noticegroup where notice_id='" + o.id + "'";
                strList.Add(sqldelgroup);
                //删除pub_noticeagent
                string sqldelagent = "delete from pub_noticeagent where notice_id='" + o.id + "'";
                strList.Add(sqldelagent);

                List<int> reault = DataExecSqlHelper.ExecuteNonQuerySqls(strList);
                if (reault == null) return false;
                else return true;
            }
            else
            {
                return false;
            }
        }
    }
}
