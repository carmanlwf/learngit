using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Ims.Card.Model;
using Ims.Card.DAL;
using ZsdDotNetLibrary.Project.DAL;


namespace Ims.Card.BLL
{
    public class v_loss_Member_infoBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_loss_Member_info> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_loss_Member_info o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "Datetime1 DESC"; }
            List<v_loss_Member_info> objects = ObjectData.GetPagedObjects<v_loss_Member_info>(startIndex, pageSize, sortedBy, o, "v_loss_Member_info");
            return objects;
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_loss_Member_info o)
        {
            return ObjectData.GetObjectsCount(o, "v_loss_Member_info");
        }

        /// <summary>
        /// 会员流失统计信息表
        /// </summary>
        /// <param name="card"></param>
        /// <param name="realname"></param>
        /// <param name="monthquantry"></param>
        /// <returns>DataTable</returns>
        public static DataTable VlossMemberInfo(string card, string realname, string monthquantry,string siteid)
        {
            return  v_loss_Member_infoDAL.VlossMemberInfo(card, realname, monthquantry,siteid);
        }
    }
}
