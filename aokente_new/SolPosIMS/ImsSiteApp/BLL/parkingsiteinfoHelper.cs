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
    public class parkingsiteinfoHelper
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        //public static DataTable GetPagedObjects(int startIndex, int pageSize, string sortedBy, parkingsiteinfo o)
        //{
        //    //if (string.IsNullOrEmpty(sortedBy))
        //    //    sortedBy = "regtime desc";
        //    string sqlselect = "select * from park_parkingsite";

        //    DataTable dt = DataExecSqlHelper.ExecutePagingSql(sqlselect, startIndex, pageSize, "", sortedBy, true);
        //    //List<parkingsiteinfo> objects = ObjectData.GetPagedObjects<parkingsiteinfo>(startIndex, pageSize, sortedBy, o, "v_parkingsiteinfo");
        //    return dt;
        //}
        public static List<v_parkingsiteinfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_parkingsiteinfo o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "";
            List<v_parkingsiteinfo> objects = ObjectData.GetPagedObjects<v_parkingsiteinfo>(startIndex, pageSize, sortedBy, o, "v_parkingsiteinfo");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_parkingsiteinfo o)
        {
            return ObjectData.GetObjectsCount(o, "v_parkingsiteinfo");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static park_parkingsite GetObject(string id)
        {
            park_parkingsite o = new park_parkingsite();
            o.parkingid = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "park_parkingsite") as park_parkingsite;
        }
        /// <summary>
        /// 多个个对象(集合)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static List<v_parkingsiteinfo> GetObjects(string posnum)
        {
            v_parkingsiteinfo o = new v_parkingsiteinfo();
            o.posnum = posnum;
            o.flag = true;
            List<v_parkingsiteinfo> list = new List<v_parkingsiteinfo>();
            try
            {
                list = ObjectData.GetObjects<v_parkingsiteinfo>(o);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        /// <summary>
        /// 根据pos机号获取地磁mac列表
        /// </summary>
        /// <param name="posNum"></param>
        /// <returns></returns>
        public static string GetMacsByPosNum(string posNum)
        {
            return ParkingsiteDAL.GetMacsByPosNum(posNum);
        }
        /// <summary>
        /// 获取所有地磁mac列表
        /// </summary>
        /// <param name="posNum"></param>
        /// <returns></returns>
        public static string GetAllMacsByPosNum()
        {
            return ParkingsiteDAL.GetAllMacsByPosNum();
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
        public static int InsertObject(park_parkingsite o)
        {
            checkId(o, "车位编号 不能为空！");
            int ret = ObjectData.InsertObject(o, "park_parkingsite");
            return ret;
        }
        /// <summary>
        /// 新增(批量)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool InsertObjects(string dtName,DataTable dt)
        {
            return InsertDataTable_SpotDAL.SqlBulkCopyInsert(dtName, dt);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(park_parkingsite o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "park_parkingsite");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(park_parkingsite o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "park_parkingsite");
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
        /// 是否已存在相同的地磁编号
        /// </summary>
        public static int IsExistsMagicID(string magicid)
        {
            string strSql = "select Count(1) from dbo.park_parkingsite where magicid ='" + magicid + "'";
            return ParkingsiteDAL.IsExistsMagicID(magicid);//test
        }
        /// <summary>
        /// 是否存在相同的自定义车位编号
        /// </summary>
        /// <param name="parkingname"></param>
        /// <returns></returns>
        public static int IsExistsParkingName(string parkingname)
        {
            return ParkingsiteDAL.IsExistsParkingName(parkingname);//test
        }
        /// <summary>
        /// 根据车位查询路段编号
        /// </summary>
        /// <param name="posnum"></param>
        /// <returns></returns>
        public static string GetParkingidSite_Codeid(string parkingid)
        {
            return ParkingsiteDAL.GetParkingidSite_Codeid(parkingid);

        }
        //public static string IssiteidValue(string siteid) {
            
        //}

    }
}
