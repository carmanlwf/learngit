using System;
using System.Collections.Generic;
using System.Text;
using Ims.Log.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;

namespace Ims.Log.BLL
{
   public  class Card_LogBLL
    {
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
       public static List<tb_Card_Log> GetPagedObjects(int startIndex, int pageSize, string sortedBy, tb_Card_Log o)
        {
            if (string.IsNullOrEmpty(sortedBy))
                sortedBy = "operate_date desc";
            List<tb_Card_Log> objects = ObjectData.GetPagedObjects<tb_Card_Log>(startIndex, pageSize, sortedBy, o, "tb_Log");
            return objects;
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int GetObjectsCount(tb_Card_Log o)
        {
            return ObjectData.GetObjectsCount(o, "tb_Card_Log");
        }

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
       public static int InsertObject(tb_Card_Log o)
        {
            //checkId(o, "��־��� ����Ϊ�գ�");
            return ObjectData.InsertObject(o, "tb_Card_Log");
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int UpdateObject(tb_Card_Log o)
        {
            checkId(o, "����ʧ�ܣ�");
            return ObjectData.UpdateObject(o, "tb_Card_Log");
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
       public static int DeleteObject(tb_Card_Log o)
        {
            checkId(o, "ɾ��ʧ�ܣ�");
            return ObjectData.DeleteObject(o, "tb_Card_Log");
        }
    }
}
