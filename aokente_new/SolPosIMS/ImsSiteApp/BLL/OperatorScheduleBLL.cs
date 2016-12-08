using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Site.DAL;
using Ims.Site.Model;
using ZsdDotNetLibrary.Project.DAL;

namespace Ims.Site.BLL
{
    public class OperatorScheduleBLL
    {
        public static List<tb_operator_schedule> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_operator_schedule o)
        {

            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "operatorid, addtime";

            List<tb_operator_schedule> objects = ObjectData.GetPagedObjects<tb_operator_schedule>(startIndex, pageSize, sortedBy, o, "tb_operator_schedule");
            return objects;
        }

        public static int GetPagedObjects(tb_operator_schedule o)
        {
            return ObjectData.GetObjectsCount(o, "tb_operator_schedule");
        }

        public static int GetObjectsCount(tb_operator_schedule o)
        {

            return ObjectData.GetObjectsCount(o, "tb_operator_schedule");
        }
    }
}
