using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Site.Model;
using ZsdDotNetLibrary.Data;
using Ims.Site.DAL;
using System.Data;


namespace Ims.Site.BLL
{
    public class InPriceBLL
    {

        static int totalCount = 0;
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<price_temp_feetype> GetPagedObjects(int startIndex, int pageSize, string sortedBy, price_temp_feetype o)
        {

            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "pname desc";

            List<price_temp_feetype> objects = ObjectData.GetPagedObjects<price_temp_feetype>(startIndex, pageSize, sortedBy, o, "price_temp_feetype");
            return objects;
        }



        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetPagedObjects(string pid)
        {
            string srt = @"select pid,pname,memo from dbo.price_temp_feetype";
            if (!string.IsNullOrEmpty(pid))
                srt += " where pid = '" + pid + "'";
            DataTable table = DataExecSqlHelper.ExecuteQuerySql(srt);

            return table;
        }

        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetPagedObjects_pid(int startIndex, int pageSize, string sortedBy, price_temp_sitefeelist o)
        {
            string srt = @"select top " + pageSize + " case when a.ChargeByTimes = 1 then '是' else '否' end as ChargeByTimes,b.spid,a.pname,a.minPayment as MinPayment,a.firstChargingTimeSeg,b.addeddate,a.normalChargingPrice,a.maxPayment,a.memo,a.freeTimeSeg,b.sitename,b.startWorkTime,b.endWorkTime from price_temp_sitefeelist b left join  price_temp_feetype a on a.pid = b.pid where 1=1";
            if (!string.IsNullOrEmpty(o.Pname))
            {
                srt += " and a.pname='" + o.Pname + "'";
            }
            if (Convert.ToInt32(o.MinPayment) > 0)
            {
                srt += " and a.MinPayment='" + o.MinPayment + "'";
            }
            if (!string.IsNullOrEmpty(o.Spid))
            {
                srt += " and b.spid='" + o.Spid + "'";
            }
            if (!string.IsNullOrEmpty(o.Siteid))
            {
                srt += " and b.siteid in (" + o.Siteid.TrimEnd(',') + ")";
            }

            srt += " and b.spid not in(select top " + startIndex + " c.spid from price_temp_sitefeelist c left join price_temp_feetype d on c.pid = d.pid order by c.siteid,a.pname desc) order by b.siteid,a.pname desc";

            DataTable table = DataExecSqlHelper.ExecuteQuerySql(srt);
            if (table != null && table.Rows.Count > 0)
                totalCount = table.Rows.Count;
            return table;
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(price_temp_sitefeelist o)
        {
            return totalCount;
            //o.Flag = true;
            //return ObjectData.GetObjectsCount(o, "price_temp_sitefeelist");

            //int startIndex, int pageSize, string sortedBy,
            //if (string.IsNullOrEmpty(o.Spid))
            //    o.Spid = null;
            //if (string.IsNullOrEmpty(o.Pname))
            //    o.Pname = null;

            //string srt = @"select top " + pageSize + " count(1) num from price_temp_sitefeelist b left join  price_temp_feetype a on a.pid = b.pid  where b.spid not in (select top " + startIndex + "  c.spid from price_temp_sitefeelist c order by c.spid)";
            //if (!string.IsNullOrEmpty(o.Pname))
            //{
            //    srt += " and a.pname='" + o.Pname + "'";
            //}
            //if (Convert.ToInt32(o.MinPayment) > 0)
            //{
            //    srt += " and a.MinPayment='" + o.MinPayment + "'";
            //}
            //if (!string.IsNullOrEmpty(o.Spid))
            //{
            //    srt += " and a.spid='" + o.Spid + "'";
            //}
            //if (!string.IsNullOrEmpty(o.Pid))
            //{
            //    srt += " and a.pid='" + o.Pid + "'";
            //}

            //srt += "order by b.spid";
            //int count = 0;
            //DataTable table = DataExecSqlHelper.ExecuteQuerySql(srt);
            //if (table != null && table.Rows.Count > 0)
            //{
            //    count = Convert.ToInt32(table.Rows[0]["num"]);
            //}
            //return count;
        }

        public static int GetObjectsCount_pe(price_temp_feetype o)
        {

            return ObjectData.GetObjectsCount(o, "price_temp_feetype");
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
        public static int InsertObject(price_temp_feetype o)
        {
            checkId(o, "区域编号 不能为空！");
            o.Flag = true;
            o.Addeddate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return ObjectData.InsertObject(o, "price_temp_feetype");

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>`
        public static int UpdateObject(price_temp_feetype o)
        {
            checkId(o, "更新失败！");

            if (o.Pname == "")
                o.Pname = null;
            if (o.Memo == "")
                o.Memo = null;

            o.Flag = true;
            return ObjectData.UpdateObject(o, "price_temp_feetype");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(price_temp_feetype o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "price_temp_feetype");
        }
    }
}
