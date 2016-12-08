using System;
using System.Collections.Generic;
using System.Text;
using Ims.Member.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
namespace Ims.Member.BLL
{
    public class MemberRanksHelper
    {
        /// <summary>
        /// 多个对象   00
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_MemberRanks> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_MemberRanks o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "addeddate desc";
            List<tb_MemberRanks> objects = ObjectData.GetPagedObjects<tb_MemberRanks>(startIndex, pageSize, sortedBy, o, "v_MemberRanks");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_MemberRanks o)
        {
            return ObjectData.GetObjectsCount(o, "v_MemberRanks");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_MemberRanks GetObject(string rankid)
        {
            tb_MemberRanks o = new tb_MemberRanks();
            o.id = rankid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_MemberRanks") as tb_MemberRanks;
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
        public static int InsertObject(tb_MemberRanks o)
        {
            //checkId(o, "会员编号 不能为空！");
            checkId(o, "会员编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_MemberRanks");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_MemberRanks o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_MemberRanks");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_MemberRanks o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_MemberRanks");
        }
    }
}
