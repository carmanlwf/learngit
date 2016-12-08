using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model;
using ZsdDotNetLibrary.Project.DAL;

namespace Ims.Pos.BLL
{
   public class Ims_ConfigBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
       public static List<Ims_Config> GetPagedObjects(int startIndex, int pageSize, string sortedBy, Ims_Config o)
        {
            o.IsHasSpot = true;
            List<Ims_Config> objects = ObjectData.GetPagedObjects<Ims_Config>(startIndex, pageSize, sortedBy, o, "Ims_Config");
            return objects;
        }
       /// <summary>
       /// 新增
       /// </summary>
       /// <param name="o"></param>
       /// <returns></returns>
       public static int InsertObject(Ims_Config o)
       {
           o.IsHasSpot = true;
           return ObjectData.InsertObject(o, "Ims_Config");

       }
       /// <summary>
       /// 更新
       /// </summary>
       /// <param name="o"></param>
       /// <returns></returns>`
       public static int UpdateObject(Ims_Config o)
       {
           o.IsHasSpot = true;
           return ObjectData.UpdateObject(o, "Ims_Config");
       }


    }
}
