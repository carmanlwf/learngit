using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using Ims.Card.Model;
using ZsdDotNetLibrary.Data;
 

namespace Ims.Card.BLL
{
  public   class tb_CardActive_HistroyBLL
    {
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_CardActive_Histroy> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_CardActive_Histroy o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "OperateDate DESC"; }
            List<tb_CardActive_Histroy> objects = ObjectData.GetPagedObjects<tb_CardActive_Histroy>(startIndex, pageSize, sortedBy, o, "tb_CardActive_Histroy");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_CardActive_Histroy o)
        {
            return ObjectData.GetObjectsCount(o, "tb_CardActive_Histroy");
        }
        /// <summary>
        /// 多个对象
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<cardchargerule> GetPagedObjects_ChargeRules(int startIndex, int pageSize, string sortedBy, cardchargerule o)
        {
            if (string.IsNullOrEmpty(sortedBy)) { sortedBy = "addeddate DESC"; }
            List<cardchargerule> objects = ObjectData.GetPagedObjects<cardchargerule>(startIndex, pageSize, sortedBy, o, "cardchargerule");
            return objects;
        }
        /// <summary>
        /// 记录行数
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_ChargeRules(cardchargerule o)
        {
            return ObjectData.GetObjectsCount(o, "cardchargerule");
        }
        /// <summary>
        /// 单个对象
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_CardActive_Histroy GetObject(string contno)
        {
            tb_CardActive_Histroy o = new tb_CardActive_Histroy();
            o.Contno = contno;
            checkId(o, "选择的对象不存在！");
            return ObjectData.GetObject(o, "tb_CardActive_Histroy") as tb_CardActive_Histroy;
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
        public static int InsertObject(tb_CardActive_Histroy o)
        {
            checkId(o, "交易号 不能为空！");
            return ObjectData.InsertObject(o, "tb_CardActive_Histroy");
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_CardActive_Histroy o)
        {
            checkId(o, "更新失败！");
            return ObjectData.UpdateObject(o, "tb_CardActive_Histroy");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_CardActive_Histroy o)
        {
            checkId(o, "删除失败！");
            return ObjectData.DeleteObject(o, "tb_CardActive_Histroy");
        }

        /// <summary>
        /// 返回当前充值赠送区间最大值
        /// </summary>
        /// <returns></returns>
        public static decimal GetMaxChargeRuleValue()
        {
            decimal ret = 0.0m;
            string strSql = "Select ISNULL(MAX(endAmount),0) From cardchargerule";
            object oRet = DataExecSqlHelper.ExecuteScalarSql(strSql);
            ret = (decimal)oRet;
            return ret;
        }
        /// <summary>
        /// 返回当前充值赠送区间最小值
        /// </summary>
        /// <returns></returns>
        public static decimal GetMinChargeRuleValue()
        {
            decimal ret = 0.0m;
            string strSql = "Select ISNULL(Min(beginAmount),0) From cardchargerule";
            object oRet = DataExecSqlHelper.ExecuteScalarSql(strSql);
            ret = (decimal)oRet;
            return ret;
        }
        /// <summary>
        /// 新增充值规则
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject_ChargeRules(cardchargerule o)
        {
            return ObjectData.InsertObject(o, "cardchargerule");
        }
        /// <summary>
        /// 修改充值规则
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject_ChargeRules(cardchargerule o)
        {
            return ObjectData.UpdateObject(o, "cardchargerule");
        }
        /// <summary>
        /// 删除充值规则
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObjects_ChargeRules(cardchargerule o)
        {
            return ObjectData.DeleteObject(o, "cardchargerule");
        }

        /// <summary>
        /// 查看tb_CardActive_Histroy表里面是否有数据(没时间)
        /// </summary>
        /// <returns></returns>
        /// 
        public static int NocountCardActiveHistroy()
        {
            return tb_CardActive_HistroyDAL.NocountCardActiveHistroy();
        }


        /// 
        /// 查看tb_CardActive_Histroy表里面是否有数据(有时间)
        /// </summary>
        /// <returns></returns>
        /// 
        public static int HavecountCardActiveHistroy(string time1, string time2)
        {
            return tb_CardActive_HistroyDAL.HavecountCardActiveHistroy(time1, time2);
        }

        /// <summary>
        ///删除tb_CardActive_Histroy里面所有数据
        /// </summary>
        /// <returns></returns>
        /// 
        public static int deleteAlltb_CardActive_Histroy()
        {
            return tb_CardActive_HistroyDAL.deleteAlltb_CardActive_Histroy();
        }


        /// <summary>
        ///删除tb_CardActive_Histroy里面所有数据
        /// </summary>
        /// <returns></returns>
        /// 
        public static int deleteAlltb_CardActive_HistroyByTime(string time1, string time2)
        {
            return tb_CardActive_HistroyDAL.deleteAlltb_CardActive_HistroyByTime(time1, time2);
        }
        /// <summary>
        /// 单个对象(充值规则)
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static cardchargerule GetObject_ChargeRules(string bid)
        {
            cardchargerule o = new cardchargerule();
            o.bounsid = bid;
            return ObjectData.GetObject(o, "cardchargerule") as cardchargerule;
        }

    }
}
