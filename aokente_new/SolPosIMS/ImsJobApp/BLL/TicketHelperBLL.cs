using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Job.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Job.DAL;
using System.Data;

namespace Ims.Job.BLL
{
    public class TicketHelperBLL
    {
        public static int StatisticsCount = 0;
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_ticket_sendlist> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_ticket_sendlist o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "addeddate desc";
            List<v_ticket_sendlist> objects = null;
            objects = ObjectData.GetPagedObjects<v_ticket_sendlist>(startIndex, pageSize, sortedBy, o, "v_ticket_sendlist");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_ticket_sendlist o)
        {
            return ObjectData.GetObjectsCount(o, "v_ticket_sendlist");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static ticket_sendlist GetObject(string tid)
        {
            ticket_sendlist o = new ticket_sendlist();
            o.tid = tid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_ticket_sendlist") as ticket_sendlist;
        }
        /// <summary>
        /// 检查主键是否存在
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(object o, string errmessage)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception(errmessage);
            }

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(ticket_sendlist o)
        {
            //checkId(o, "日志编号 不能为空！");
            return ObjectData.InsertObject(o, "ticket_sendlist");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(ticket_sendlist o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "ticket_sendlist");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(ticket_sendlist o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "ticket_sendlist");
        }
        /// <summary>
        /// 根据流水号作废票据领取记录
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static int AlterTicketState(string tid)
        {
            return TicketHelperDAL.AlterTicketState(tid);
        }
        /// <summary>
        /// 根据条件进行票据消耗统计
        /// </summary>
        /// <param name="person"></param>
        /// <param name="s_time"></param>
        /// <param name="e_time"></param>
        /// <returns></returns>
        public static List<ticket_statistics> GetTicketStaticsInfo(int startIndex, int pageSize, string sortedBy, ticket_statistics o)
        {
            DataTable dt = TicketHelperDAL.GetTicketStaticsInfo(o.operatorid,o.addeddate_begin, o.addeddate_end);
            List<ticket_statistics> list = new List<ticket_statistics>();
            if (dt != null && dt.Rows.Count > 0)
            ZsdDotNetLibrary.Data.DataBindHelper.BindDataTableToObjArray(dt, typeof(ticket_statistics), list);
            StatisticsCount = list.Count;
            return list;
        }
        /// <summary>
        /// 记录行数(统计)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetTicketStaticsInfo_Count(ticket_statistics o)
        {
            return StatisticsCount;
        }
    }
}
