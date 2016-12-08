using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Site.DAL;
using Ims.Site.Model;
using ZsdDotNetLibrary.Data;
using System.Data;

namespace Ims.Site.BLL
{
   public class PosposListinfoHelper
    {
       public static List<v_pos_poslistinfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_pos_poslistinfo o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "addedtime desc";
            List<v_pos_poslistinfo> objects = ObjectData.GetPagedObjects<v_pos_poslistinfo>(startIndex, pageSize, sortedBy, o, "v_pos_poslistInfo");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int GetObjectsCount(v_pos_poslistinfo o)
        {
            return ObjectData.GetObjectsCount(o, "v_pos_poslistInfo");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static pos_poslist GetObject(string id)
        {
            pos_poslist o = new pos_poslist();
            o.posnum = id;
            //checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "pos_poslist") as pos_poslist;
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
        public static int InsertObject(pos_poslist o)
        {
            //checkId(o, "车位编号 不能为空！");
            int ret = ObjectData.InsertObject(o, "pos_poslist");
            return ret;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(pos_poslist o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "pos_poslist");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(pos_poslist o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "pos_poslist");
        }
        /// <summary>
        /// --------------------------------------
        /// 判断区域号是否在门店中使用，如果在在使用状态，则不能删除
        /// Area_Times
        /// </summary>
        /// <returns></returns>
        /// 
        public static int Area_Times(string areacode)
        {
            return SiteandAreaHelperDAL.Area_Times(areacode);
        }
        /// <summary>
        /// 根据终端id获取路段名称
        /// </summary>
        /// <param name="parkingid"></param>
        /// <returns></returns>
        public static string GetSite_Codeid(string parkingid) {
            return ParkingsiteDAL.GetSite_Codeid(parkingid);

        }
        
       /// <summary>
       /// 根据路段id获取路段id
       /// </summary>
       /// <param name="areaid"></param>
       /// <returns></returns>
        public static string GetArea_Codeid(string areaid) {
            return ParkingsiteDAL.GetArea_Codeid(areaid);
        }
        /// <summary>
        /// 是否已存在相同的终端机号
        /// </summary>
        //public static int IsExistsMagicID(string magicid)
        //{
        //    string strSql = "select Count(1) from dbo.park_parkingsite where magicid='" + magicid + "'";
        //    return ParkingsiteDAL.IsExistsMagicID(magicid);//test
        //}

    }
}
