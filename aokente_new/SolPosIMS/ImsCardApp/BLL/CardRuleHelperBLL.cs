using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Card.Model;
using ZsdDotNetLibrary.Data;
using Ims.Card.DAL;

namespace Ims.Card.BLL
{
    public class CardRuleHelperBLL
    {
        /// <summary>
        /// -------多个对象---------  
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<card_chargerule> GetPagedObjects(int startIndex, int pageSize, string sortedBy, card_chargerule o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "addeddate DESC"; }
            List<card_chargerule> objects = ObjectData.GetPagedObjects<card_chargerule>(startIndex, pageSize, sortedBy, o, "card_chargerule");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(card_chargerule o)
        {
            return ObjectData.GetObjectsCount(o, "card_chargerule");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static card_chargerule GetObject(string rid)
        {
            card_chargerule o = new card_chargerule();
            o.ruleid = rid;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "card_chargerule") as card_chargerule;
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
        public static int InsertObject(card_chargerule o)
        {
            checkId(o, "编号 不能为空！");
            return ObjectData.InsertObject(o, "card_chargerule");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(card_chargerule o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "card_chargerule");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(card_chargerule o)
        {
            checkId(o, "删除失败!");
            return ObjectData.DeleteObject(o, "card_chargerule");
        }
        /// <summary>
        /// 根据充值金额获取优惠条件
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        static public string getRule(decimal amount, string type)
        {
            return CardRuleHelperDAL.getRule(amount,type);
        }
    }
}
