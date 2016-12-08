using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Pub.Model;
using Ims.Pub.DAL;

namespace Ims.Pub.BLL
{
    /// <summary>
    /// 分店信息
    /// </summary>
   public class SiteHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<PUB_Site> GetPagedObjects(int startIndex, int pageSize, string sortedBy, PUB_Site o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "regtime desc";
            List<PUB_Site> objects = ObjectData.GetPagedObjects<PUB_Site>(startIndex, pageSize, sortedBy, o, "v_pub_Site");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(PUB_Site o)
        {
            return ObjectData.GetObjectsCount(o, "v_pub_Site");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static PUB_Site GetObject(string id)
        {
            PUB_Site o = new PUB_Site();
            o.siteid = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_pub_Site") as PUB_Site;
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
        public static int InsertObject(PUB_Site o)
        {
            checkId(o, "站点编号 不能为空！");
            return ObjectData.InsertObject(o, "PUB_Site");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(PUB_Site o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "PUB_Site");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(PUB_Site o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "PUB_Site");
        }
        /// <summary>
        /// ---------------------------------------
        /// 判断门店是否是否在卡片中在使用，如果在在使用状态，则不能删除
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Site_Times(string siteid)
        {
            return SiteAndAreaHelperDAL.Site_Times(siteid);
        }
        /// <summary>
        /// ---------------------------------------
        /// 根据区域号码得到所有的分店号与名字
        /// GetAllSiteByAreacodeID
        /// </summary>
        /// <returns></returns>
        /// 
        public static string GetAreacodeIDSiteBysiteID(string siteid)
        {
            return DAL.SiteAndAreaHelperDAL.GetAreacodeIDSiteBysiteID(siteid);
        }
        /// <summary>
        /// ---------------------------------------
        /// 判断PUB_Site中是否已存在相同的机器码  
        /// Site_Machineid
        /// </summary>
        /// <returns></returns>
        /// 
        //public static int Site_Machineid(string machineid)
        //{
        //    return SiteAndAreaHelperDAL.Site_Machineid(machineid);
        //}


        /// <summary>
        ///判断tb_Pos_Operator 是否有相同数据
        /// </summary>
        /// <returns></returns>
        public static int tb_Pos_Operatorid(string operatorid)
        {
            return SiteAndAreaHelperDAL.tb_Pos_Operatorid(operatorid);
        }
    }
}
