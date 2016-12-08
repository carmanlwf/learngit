using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.PM.BLL;
using Ims.PM.DAL;

namespace Ims.PM
{
    public class PmEmployeeInfo
    {
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<pm_employee> GetPagedObjects(int startIndex, int pageSize, string sortedBy, pm_employee o)
        {
            List<pm_employee> objects = ObjectData.GetPagedObjects<pm_employee>(startIndex, pageSize, sortedBy, o, "v_site_SiteInfo");
            return objects;
        }
        /// <summary>
        /// ��¼����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(pm_employee o)
        {
            return ObjectData.GetObjectsCount(o);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static pm_employee GetObject(string code)
        {
            pm_employee o = new pm_employee();
            o.code = code;
            checkId(o, "ѡ��Ķ��󲻴��ڣ�");
            return ObjectData.GetObject(o, "v_site_SiteInfo") as pm_employee;
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
        public static int InsertObject(pm_employee o)
        {
            checkId(o, "�û���� ����Ϊ�գ�");
            return ObjectData.InsertObject(o, "pm_employee");
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(pm_employee o)
        {
            checkId(o, "����ʧ�ܣ�");
            return ObjectData.UpdateObject(o, "pm_employee");
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(pm_employee o)
        {
            checkId(o, "ɾ��ʧ�ܣ�");
            return ObjectData.DeleteObject(o, "pm_employee");
        }

    }


}
