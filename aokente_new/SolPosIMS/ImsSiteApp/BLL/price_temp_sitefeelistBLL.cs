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
   public class price_temp_sitefeelistBLL
    {

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
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable GetPagedObjects(string pid,string siteid)
        {
            string srt = @"select pid from dbo.price_temp_sitefeelist";
            if (!string.IsNullOrEmpty(siteid))
                srt += " where siteid='" + siteid + "' and pid='" + pid + "'";
            DataTable table = DataExecSqlHelper.ExecuteQuerySql(srt);

            return table;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(price_temp_sitefeelist o)
        {
            checkId(o, "区域编号 不能为空！");
            o.Addeddate = DateTime.Now.ToString("yyyy-M-d H:m:s");
         
            return ObjectData.InsertObject(o, "price_temp_sitefeelist");

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>`
        public static int UpdateObject(price_temp_sitefeelist o)
        {
            checkId(o, "更新失败！");

            return ObjectData.UpdateObject(o, "price_temp_sitefeelist");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(price_temp_sitefeelist o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "price_temp_sitefeelist");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject_siteid(price_temp_sitefeelist o)
        {
            string str = @"delete price_temp_sitefeelist where siteid='" + o.Siteid+"'";
            return DataExecSqlHelper.ExecuteNonQuerySql(str);
        }
       
    }
}
