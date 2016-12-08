using System;
using System.Collections.Generic;
using System.Text;
using Ims.Admin.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.Main;
namespace Ims.Admin.BLL
{
    /// <summary>
    /// ���������ҵ���߼���
    /// </summary>
    public class AreaCodeBLL
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public AreaCodeBLL() { }

        /// <summary>
        /// ���ݲ�ѯ����,��ҳ��ѯ���������
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<AreaCodeInfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, AreaCodeInfo o)
        {
            List<AreaCodeInfo> objectBeans = ObjectData.GetPagedObjects<AreaCodeInfo>(startIndex, pageSize, sortedBy, o, "v_pub_areacode");
            return objectBeans;
        }

        /// <summary>
        /// ���ݲ�ѯ����,��ȡ���������������
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(AreaCodeInfo o)
        {
            return ObjectData.GetObjectsCount(o, "v_pub_areacode");
        }

        /// <summary>
        /// ���ݵ�������ʵ��,��ѯ����ʵ��
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static AreaCodeInfo GetObject(AreaCodeInfo o)
        {
            checkId(o);
            return ObjectData.GetObject(o, "v_pub_areacode") as AreaCodeInfo;
        }
        /// <summary>
        /// �޸ĵ���������Ϣ
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(AreaCodeInfo o)
        {
            checkId(o);
            o.agent_id = ImsInfo.CurrentUserId;
            o.update_time = System.DateTime.Now.ToString("yyyy-MM-dd");
            return ObjectData.UpdateObject(o, "pub_areacode");
        }
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int InsertObject(AreaCodeInfo o)
        {
            checkId(o);
            o.agent_id = ImsInfo.CurrentUserId;
            o.update_time = System.DateTime.Now.ToString("yyyy-MM-dd");
            return ObjectData.InsertObject(o, "pub_areacode");
        }
        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int DeleteObject(AreaCodeInfo o)
        {
            checkId(o);
            return ObjectData.DeleteObject(o, "pub_areacode");

        }
        /// <summary>
        /// ��������Ƿ�Ϊ��
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(AreaCodeInfo o)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception("Id ����Ϊ�գ�");
            }

        }
        /// <summary>
        /// ����Ƿ���ڵ���������ͬ����Ϣ
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool CheckAreaCodeData(AreaCodeInfo o)
        {
            AreaCodeInfo AreaCodeInfo = ObjectData.GetObject(o) as AreaCodeInfo;
            if (AreaCodeInfo == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
