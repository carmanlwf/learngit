using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Site.Model;

namespace Ims.Site.BLL
{
    public class PosOperatorHelperBLL
    {
        /// <summary>
        /// 查看POS端信息
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_Pos_Operator> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_Pos_Operator o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "adddate desc"; }
            List<tb_Pos_Operator> objects = ObjectData.GetPagedObjects<tb_Pos_Operator>(startIndex, pageSize, sortedBy, o, "v_tb_Pos_Operator");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_Pos_Operator o)
        {
            return ObjectData.GetObjectsCount(o, "v_tb_Pos_Operator");
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
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_Pos_Operator GetObject(string oid)
        {
            tb_Pos_Operator o = new tb_Pos_Operator();
            o.Operatorid = oid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_Pos_Operator") as tb_Pos_Operator;
        }


        /// <summary>
        ///插入操作记录
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// 
        public static int InsertObject(tb_Pos_Operator o)
        {
            return ObjectData.InsertObject(o, "tb_Pos_Operator");
        }
        /// <summary>
        ///更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// 
        public static int UpdateObject(tb_Pos_Operator o)
        {
            return ObjectData.UpdateObject(o, "tb_Pos_Operator");
        }

        ///删除操作POS端登录信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// 
        public static int DeleteObject(tb_Pos_Operator o)
        {
            return ObjectData.DeleteObject(o, "tb_Pos_Operator");
        }
    }
}
