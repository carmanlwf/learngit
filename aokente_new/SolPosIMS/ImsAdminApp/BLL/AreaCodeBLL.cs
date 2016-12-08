using System;
using System.Collections.Generic;
using System.Text;
using Ims.Admin.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.Main;
namespace Ims.Admin.BLL
{
    /// <summary>
    /// 地区代码表业务逻辑层
    /// </summary>
    public class AreaCodeBLL
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AreaCodeBLL() { }

        /// <summary>
        /// 根据查询条件,分页查询地区代码表
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<AreaCodeInfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, AreaCodeInfo o)
        {
            List<AreaCodeInfo> objectBeans = ObjectData.GetPagedObjects<AreaCodeInfo>(startIndex, pageSize, sortedBy, o, "v_pub_areacode");
            return objectBeans;
        }

        /// <summary>
        /// 根据查询条件,获取地区代码表总行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(AreaCodeInfo o)
        {
            return ObjectData.GetObjectsCount(o, "v_pub_areacode");
        }

        /// <summary>
        /// 根据地区代码实体,查询返回实体
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static AreaCodeInfo GetObject(AreaCodeInfo o)
        {
            checkId(o);
            return ObjectData.GetObject(o, "v_pub_areacode") as AreaCodeInfo;
        }
        /// <summary>
        /// 修改地区代码信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(AreaCodeInfo o)
        {
            checkId(o);
            o.agent_id = ImsInfo.CurrentUserId;
            o.update_time = System.DateTime.Now.ToString("yyyy-MM-dd");
            return ObjectData.UpdateObject(o, "pub_areacode");
        }
        /// <summary>
        /// 新增地区代码
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(AreaCodeInfo o)
        {
            checkId(o);
            o.agent_id = ImsInfo.CurrentUserId;
            o.update_time = System.DateTime.Now.ToString("yyyy-MM-dd");
            return ObjectData.InsertObject(o, "pub_areacode");
        }
        /// <summary>
        /// 删除地区代码
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(AreaCodeInfo o)
        {
            checkId(o);
            return ObjectData.DeleteObject(o, "pub_areacode");

        }
        /// <summary>
        /// 检查主健是否为空
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(AreaCodeInfo o)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception("Id 不能为空！");
            }

        }
        /// <summary>
        /// 检查是否存在地区代码相同的信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool CheckAreaCodeData(AreaCodeInfo o)
        {
            AreaCodeInfo AreaCodeInfo = ObjectData.GetObject(o) as AreaCodeInfo;
            if (AreaCodeInfo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
