using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Utility;
using Ims.Pub.DAL;
using System.Data;
using Ims.Pub.Model;

namespace Ims.Pub.BLL
{
    public class DataBackUpBLL
    {     /// <summary>
        /// 根据查询条件,获取信息总行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int GetObjectsCount_SaleData(DataBackUpModel o)
        {
            if (o != null)
            {
                return TypeHelper.StringToInt(o.TotalCount);
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetPagedObjects_SaleData(string sortedBy, DataBackUpModel o)
        {
            return DataBackUpDAL.CouputerSaleDataByOperID(o.name, o.StartDate, o.EndDate);
        }
    }
}
