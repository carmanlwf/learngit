using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Pay.DAL;
using System.Data;
using Ims.Pay.Model;

namespace Ims.Pay.BLL
{
    public class PayHelperBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<v_pay_paydetail> GetPagedObjects(int startIndex, int pageSize, string sortedBy, v_pay_paydetail o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "tradetime desc";
            List<v_pay_paydetail> objects = null;
            objects = ObjectData.GetPagedObjects<v_pay_paydetail>(startIndex, pageSize, sortedBy, o, "v_pay_paydetail");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(v_pay_paydetail o)
        {
            return ObjectData.GetObjectsCount(o, "v_pay_paydetail");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static v_pay_paydetail GetObject(string pid)
        {
            v_pay_paydetail o = new v_pay_paydetail();
            o.payid = pid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "v_pay_paydetail") as v_pay_paydetail;
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
        /// 根据流水号获取交易记录的详情
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static DataTable GetTradeInfoByPayId(string pid)
        {
            return PayHelperDAL.GetTradeInfoByPayId(pid);
        }


        public static List<v_pay_arrears> GetPagedArrearsObjects(int startIndex, int pageSize, string sortedBy, v_pay_arrears o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "tradetime desc";
            List<v_pay_arrears> objects = null;
            objects = ObjectData.GetPagedObjects<v_pay_arrears>(startIndex, pageSize, sortedBy, o, "v_pay_arrears");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetArrearsObjectsCount(v_pay_arrears o)
        {
            return ObjectData.GetObjectsCount(o, "v_pay_arrears");
        }

    }
}
