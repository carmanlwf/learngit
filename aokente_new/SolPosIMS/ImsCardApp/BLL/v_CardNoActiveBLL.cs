using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Card.Model;

namespace Ims.Card.BLL
{
  public  class v_CardNoActiveBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_CardNoActive> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_CardNoActive o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "card asc"; }
            List<v_CardNoActive> objects = ObjectData.GetPagedObjects<v_CardNoActive>(startIndex, pageSize, sortedBy, o, "v_CardNoActive");
            return objects;
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_CardNoActive o)
        {
            return ObjectData.GetObjectsCount(o, "v_CardNoActive");
        }
 
    }
}
