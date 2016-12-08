using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.Model;
using Ims.Card.DAL;
using System.Data;
using ZsdDotNetLibrary.Project.DAL;

namespace Ims.Card.BLL
{
   public  class v_CardToExecBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_CardToExec> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_CardToExec o)
        {
            if (string.IsNullOrEmpty(sortedBy))
            {
                sortedBy = "activeaddate DESC";
            }
            List<v_CardToExec> objects = ObjectData.GetPagedObjects<v_CardToExec>(startIndex, pageSize, sortedBy, o, "v_CardToExec");
            return objects;
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_CardToExec o)
        {
            return ObjectData.GetObjectsCount(o, "v_CardToExec");
        }

        /// <summary>
        /// 卡内容全部导出
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="addeddate1"></param>
        /// <param name="addeddate2"></param>
        /// <returns>DataTable</returns>
        /// 
        public static DataTable CardConetEXEC(string typeid, string stiteID, string cardstatus, string addeddate1, string addeddate2, string activeaddeddate1, string activeaddeddate2, string initvalue, string point1, string point2)
        {
            return v_CardToExecDAL.CardConetEXEC(typeid, stiteID, cardstatus, addeddate1, addeddate2, activeaddeddate1, activeaddeddate2,initvalue,point1,point2);
        }
        /// <summary>
        /// 卡内容统计
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="addeddate1"></param>
        /// <param name="addeddate2"></param>
        /// <returns>DataTable</returns>
        /// 
        public static DataTable CardCount(string typeid, string stiteID, string cardstatus, string addeddate1, string addeddate2, string activeaddeddate1, string activeaddeddate2,string initvalue,string point1,string point2)
        {
            return v_CardToExecDAL.CardCount(typeid, stiteID, cardstatus, addeddate1, addeddate2, activeaddeddate1, activeaddeddate2,initvalue,point1,point2);
        }
    }
}
