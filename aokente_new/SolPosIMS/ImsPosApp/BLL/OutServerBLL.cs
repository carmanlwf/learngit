using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model;
using ZsdDotNetLibrary.Project.DAL;

namespace Ims.Pos.BLL
{
   public class OutServerBLL
    {
       public static List<OutServer> GetPagedObjects(int startIndex, int pageSize, string sortedBy, OutServer o)
        {
            o.Flag = true;
            List<OutServer> objects = ObjectData.GetPagedObjects<OutServer>(startIndex, pageSize, sortedBy, o, "OutServer");
            return objects;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int InsertObject(OutServer o)
        {
            o.Flag = true;
            return ObjectData.InsertObject(o, "OutServer");

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>`
       public static int UpdateObject(OutServer o)
        {
            o.Flag = true;
            return ObjectData.UpdateObject(o, "OutServer");
        }

    }
}
