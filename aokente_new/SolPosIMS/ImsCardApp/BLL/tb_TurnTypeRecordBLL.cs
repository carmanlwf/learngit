using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;

namespace Ims.Card.BLL
{
  public   class tb_TurnTypeRecordBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_TurnTypeRecord> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_TurnTypeRecord o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "AddDate desc";
            List<tb_TurnTypeRecord> objects = ObjectData.GetPagedObjects<tb_TurnTypeRecord>(startIndex, pageSize, sortedBy, o, "v_tb_TurnTypeRecord");
            return objects;
        }

        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_TurnTypeRecord o)
        {
            return ObjectData.GetObjectsCount(o, "v_tb_TurnTypeRecord");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_TurnTypeRecord GetObject(string id)
        {
            tb_TurnTypeRecord o = new tb_TurnTypeRecord();
            o.TID = id;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_tb_TurnTypeRecord") as tb_TurnTypeRecord;
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
        public static int InsertObject(tb_TurnTypeRecord o)
        {
            checkId(o, "站点编号 不能为空！");
            return ObjectData.InsertObject(o, "tb_TurnTypeRecord");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_TurnTypeRecord o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_TurnTypeRecord");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_TurnTypeRecord o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_TurnTypeRecord");
        }
    }
}
