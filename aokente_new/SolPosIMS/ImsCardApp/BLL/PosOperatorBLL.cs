using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Card.Model;
using ZsdDotNetLibrary.Data;
using Ims.Product.Model;

namespace Ims.Card.BLL
{
    public class PosOperatorBLL
    {
        /// <summary>
        /// 查看POS端信息
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_PosOperator> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_PosOperator o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "adddate DESC"; }
            List<tb_PosOperator> objects = ObjectData.GetPagedObjects<tb_PosOperator>(startIndex, pageSize, sortedBy, o, "v-PosOperator");
            return objects;
        }


        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_PosOperator o)
        {
            return ObjectData.GetObjectsCount(o, "tb_PosOperator");
        }

        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_PosOperator GetObject(string userid)
        {
            tb_PosOperator o = new tb_PosOperator();
            o.Operatorid = userid;
            //checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_PosOperator") as tb_PosOperator;
        }

        /// <summary>
        ///插入操作记录
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// 
        public static int InsertObject(tb_PosOperator o)
        {
            return ObjectData.InsertObject(o, "tb_PosOperator");
        }

        ///删除操作POS端登录信息
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        /// 
        public static int DeleteObject(tb_PosOperator o)
        {
            return ObjectData.DeleteObject(o, "tb_PosOperator");
        }
    }
}
