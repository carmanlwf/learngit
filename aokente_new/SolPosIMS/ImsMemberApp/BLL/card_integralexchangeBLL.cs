using System;
using System.Collections.Generic;
using System.Text;
using Ims.Member.Model;
using ZsdDotNetLibrary.Data;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Member.DAL;
using ZsdDotNetLibrary.Log;
using Ims.Log.Model;

namespace Ims.Member.BLL
{
    public class card_integralexchangeBLL
    {
        /// <summary>
        /// 多个对象   00
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<card_integralexchangelist> GetPagedObjects(int startIndex, int pageSize, string sortedBy, card_integralexchangelist o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "operatetime desc";
            List<card_integralexchangelist> objects = ObjectData.GetPagedObjects<card_integralexchangelist>(startIndex, pageSize, sortedBy, o, "card_integralexchangelist");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(card_integralexchangelist o)
        {
            return ObjectData.GetObjectsCount(o, "card_integralexchangelist");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static card_integralexchangelist GetObject(string transid)
        {
            card_integralexchangelist o = new card_integralexchangelist();
            o.transid = transid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "card_integralexchangelist") as card_integralexchangelist;
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
        public static int InsertObject(card_integralexchangelist o)
        {
            checkId(o, "业务流水号不能为空！");
            return ObjectData.InsertObject(o, "card_integralexchangelist");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(card_integralexchangelist o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "card_integralexchangelist");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(card_integralexchangelist o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "card_integralexchangelist");
        }
        /// <summary>
        /// 会员积分兑换操作（积分扣减）
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static int IntegralExchangeByCard(string card, int amount)
        {
            return card_integralexchangeDAL.IntegralExchangeByCard(card, amount);
        }
        /// <summary>
        /// 插入会员积分兑换记录
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool IntegralExchange_insert(card_integralexchangelist ciel, tb_Log log)
        {
            return card_integralexchangeDAL.IntegralExchange_insert(ciel, log);
        }
    }
}
