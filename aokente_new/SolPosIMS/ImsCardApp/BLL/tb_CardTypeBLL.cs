using System;
using System.Collections.Generic;
using System.Text;
using Ims.Card.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.Card.Model.MonthlyCard;

namespace Ims.Card.BLL
{
   public  class tb_CardTypeBLL
    {
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<tb_CardType> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_CardType o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "Additme desc";
            List<tb_CardType> objects = ObjectData.GetPagedObjects<tb_CardType>(startIndex, pageSize, sortedBy, o, "tb_CardType");
            return objects;
        }

        /// <summary>
        /// ��¼����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(tb_CardType o)
        {
            return ObjectData.GetObjectsCount(o, "tb_CardType");
        }
        //�쿨
        public static DataTable GetObjectsCard()
        {
            string strSql = "select NumCost,TypeName,TypeID,NumMonths from tb_CardType group by NumCost,TypeName,TypeID,NumMonths having CAST(ISNULL(NumCost,0) AS MONEY)  > 0  or TypeName = '���ѿ�'";
            return DataExecSqlHelper.ExecuteQuerySql(strSql);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static tb_CardType GetObject(string id)
        {
            tb_CardType o = new tb_CardType();
            o.TypeID = id;
            checkId(o, "ѡ��Ķ��󲻴��ڣ�");
            return ObjectData.GetObject(o, "tb_CardType") as tb_CardType;
        }
        public static MonthlyCardTypeInfo GetMonthCardTypeInfo(string typeid)
        {
            MonthlyCardTypeInfo o = new MonthlyCardTypeInfo();
            string strSql = "select typeid,typename,months, price,IsDayCard from tb_CardType where TypeID='" + typeid + "'";
            DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                o.TypeID = dt.Rows[0]["typeid"].ToString();
                o.TypeNmae = dt.Rows[0]["typename"].ToString();
                o.months = int.Parse(dt.Rows[0]["months"].ToString());
                o.price = decimal.Parse(dt.Rows[0]["price"].ToString());
                if (string.IsNullOrEmpty(dt.Rows[0]["IsDayCard"].ToString()))
                    o.IsDayCard = false;
                else
                    o.IsDayCard = bool.Parse(dt.Rows[0]["IsDayCard"].ToString());
                return o;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool GetObjectName(string name)
        {
            string strSql = "select count(*) num from tb_CardType where TypeName='"+name+"'";
                  DataTable dt = DataExecSqlHelper.ExecuteQuerySql(strSql);
           if (dt != null && Convert.ToInt32(dt.Rows[0]["num"]) == 0)
                  return true;
              else
                  return false;
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
        public static int InsertObject(tb_CardType o)
        {
            checkId(o, "�������ͱ�� ����Ϊ�գ�");
            return ObjectData.InsertObject(o, "tb_CardType");
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(tb_CardType o)
        {
            checkId(o, "����ʧ�ܣ�");
            return ObjectData.UpdateObject(o, "tb_CardType");
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(tb_CardType o)
        {
            checkId(o, "ɾ��ʧ�ܣ�");
            return ObjectData.DeleteObject(o, "tb_CardType");
        }
    }
}
