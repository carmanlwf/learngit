using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Pub.Model;

namespace Ims.Pub.BLL
{
    public class NoticeListBLL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_pub_noticeagentinfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_pub_noticeagentinfo o)
        {
            if (string.IsNullOrEmpty(sortedBy)) sortedBy = "starttime desc";
            List<v_pub_noticeagentinfo> objects = ObjectData.GetPagedObjects<v_pub_noticeagentinfo>(startIndex, pageSize, sortedBy, o, "v_pub_noticeagentinfo");
            //DateTime dt = new DateTime();
            //foreach (v_pub_noticeagentinfo nInfo in v_pub_noticeinfos)
            //{
            //    if (!string.IsNullOrEmpty(nInfo.starttime))
            //    {
            //        //dt = Convert.ToDateTime(nInfo.starttime);
            //        if (DateTime.TryParse(nInfo.starttime, out dt))
            //        {
            //            nInfo.starttime = dt.ToString("MM-dd HH:mm");
            //        }
            //        else
            //        {
            //            nInfo.starttime = "";
            //        }
            //    }
            //}
            return objects;
        }
        public static int GetObjectsCount(v_pub_noticeagentinfo o)
        {
            return ObjectData.GetObjectsCount(o);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_pub_NoticeInfoManage> GetPagedObjectsNM(int startIndex, int pageSize, string sortedBy, v_pub_NoticeInfoManage o)
        {
            object[] objects = ObjectData.GetPagedObjects(startIndex, pageSize, sortedBy, o);
            List<v_pub_NoticeInfoManage> v_pub_NoticeInfoManages = new List<v_pub_NoticeInfoManage>();
            for (int i = 0; i < objects.Length; i++)
            {
                v_pub_NoticeInfoManages.Add(objects[i] as v_pub_NoticeInfoManage);
            }
            return v_pub_NoticeInfoManages;
        }
        public static int GetObjectsCountNM(v_pub_NoticeInfoManage o)
        {
            return ObjectData.GetObjectsCount(o);
        }
    }
}
