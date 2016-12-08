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
        /// �������
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
        /// ��¼����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_CardActive_Histroy o)
        {
            return ObjectData.GetObjectsCount(o, "tb_CardActive_Histroy");
        }
        /// <summary>
        /// �������
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
        /// ��¼����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount_ChargeRules(cardchargerule o)
        {
            return ObjectData.GetObjectsCount(o, "cardchargerule");
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_CardActive_Histroy GetObject(string contno)
        {
            tb_CardActive_Histroy o = new tb_CardActive_Histroy();
            o.Contno = contno;
            checkId(o, "ѡ��Ķ��󲻴��ڣ�");
            return ObjectData.GetObject(o, "tb_CardActive_Histroy") as tb_CardActive_Histroy;
        }
        /// <summary>
        /// ��������Ƿ����
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
        /// ����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(tb_CardActive_Histroy o)
        {
            checkId(o, "���׺� ����Ϊ�գ�");
            return ObjectData.InsertObject(o, "tb_CardActive_Histroy");
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_CardActive_Histroy o)
        {
            checkId(o, "����ʧ�ܣ�");
            return ObjectData.UpdateObject(o, "tb_CardActive_Histroy");
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_CardActive_Histroy o)
        {
            checkId(o, "ɾ��ʧ�ܣ�");
            return ObjectData.DeleteObject(o, "tb_CardActive_Histroy");
        }

        /// <summary>
        /// ���ص�ǰ��ֵ�����������ֵ
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
        /// ���ص�ǰ��ֵ����������Сֵ
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
        /// ������ֵ����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject_ChargeRules(cardchargerule o)
        {
            return ObjectData.InsertObject(o, "cardchargerule");
        }
        /// <summary>
        /// �޸ĳ�ֵ����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject_ChargeRules(cardchargerule o)
        {
            return ObjectData.UpdateObject(o, "cardchargerule");
        }
        /// <summary>
        /// ɾ����ֵ����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObjects_ChargeRules(cardchargerule o)
        {
            return ObjectData.DeleteObject(o, "cardchargerule");
        }

        /// <summary>
        /// �鿴tb_CardActive_Histroy�������Ƿ�������(ûʱ��)
        /// </summary>
        /// <returns></returns>
        /// 
        public static int NocountCardActiveHistroy()
        {
            return tb_CardActive_HistroyDAL.NocountCardActiveHistroy();
        }


        /// 
        /// �鿴tb_CardActive_Histroy�������Ƿ�������(��ʱ��)
        /// </summary>
        /// <returns></returns>
        /// 
        public static int HavecountCardActiveHistroy(string time1, string time2)
        {
            return tb_CardActive_HistroyDAL.HavecountCardActiveHistroy(time1, time2);
        }

        /// <summary>
        ///ɾ��tb_CardActive_Histroy������������
        /// </summary>
        /// <returns></returns>
        /// 
        public static int deleteAlltb_CardActive_Histroy()
        {
            return tb_CardActive_HistroyDAL.deleteAlltb_CardActive_Histroy();
        }


        /// <summary>
        ///ɾ��tb_CardActive_Histroy������������
        /// </summary>
        /// <returns></returns>
        /// 
        public static int deleteAlltb_CardActive_HistroyByTime(string time1, string time2)
        {
            return tb_CardActive_HistroyDAL.deleteAlltb_CardActive_HistroyByTime(time1, time2);
        }
        /// <summary>
        /// ��������(��ֵ����)
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
