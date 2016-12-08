using System;
using System.Collections.Generic;
using System.Text;
using Ims.Admin.Model;
using Ims.Admin.DAL;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using System.Data;
using Ims.Main;
namespace Ims.Admin.BLL
{
    /// <summary>
    /// �ֹ�˾����ҵ���߼���
    /// </summary>
    public class BranchManageBLL
    {
        /// <summary>
        /// ���ݲ�ѯ����,��ҳ��ѯ��֯�ṹ��д��Ϣ
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortedBy"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static List<ManageComInfo> GetPagedObjects(int startIndex, int pageSize, string sortedBy, ManageComInfo o)
        {
            List<ManageComInfo> objectBeans = ObjectData.GetPagedObjects<ManageComInfo>(startIndex, pageSize, sortedBy, o);
            return objectBeans;
        }
        /// <summary>
        /// ���ݲ�ѯ����,��ȡ��֯�ṹ��д��Ϣ������
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int GetObjectsCount(ManageComInfo o)
        {
            return ObjectData.GetObjectsCount(o);
        }

        /// <summary>
        /// ��ѯ���Ӧ�ֹ�˾
        /// </summary>
        /// <param name="strGroupCode"></param>
        /// <returns></returns>
        public static DataTable GetBranchInGroup(string strGroupCode)
        {
            return BranchManageDAL.GetBranchInGroup(strGroupCode);
        }
        /// <summary>
        /// ��ѯ���ѡ�ֹ�˾
        /// </summary>
        /// <param name="strGroupCode"></param>
        /// <returns></returns>
        public static DataTable GetBranchOutGroup(string strGroupCode)
        {
            return BranchManageDAL.GetBranchOutGroup(strGroupCode);
        }
        /// <summary>
        /// �޸Ļ�����д��Ϣ
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int UpdateObject(ManageComInfo o)
        {
            checkId(o);
            OrgshortInfo shortInfo = new OrgshortInfo();
            shortInfo.AreaCode = o.AreaCode;
            shortInfo.ShortName = o.ShortName;
            shortInfo.OrgCode = o.OrgCode;
            shortInfo.Agentinfo_id = ImsInfo.CurrentUserId;

            OrgshortInfo temp = new OrgshortInfo();
            temp.OrgCode = o.OrgCode;
            temp = ObjectData.GetObject(temp) as OrgshortInfo;
            if (temp == null)
            {
                return ObjectData.InsertObject(shortInfo);
            }
            else
            {
                return ObjectData.UpdateObject(shortInfo);
            }
        }
        /// <summary>
        /// ��������Ƿ�Ϊ��
        /// </summary>
        /// <param name="o"></param>
        public static void checkId(ManageComInfo o)
        {
            DbFieldInfo fieldInfo = DataBindHelper.GetKeyFieldInfo(o);

            if (fieldInfo == null || string.IsNullOrEmpty(fieldInfo.fieldValue))
            {
                throw new Exception("Id ����Ϊ�գ�");
            }

        }
        /// <summary>
        /// ���ķֹ�˾�뼼������չ�ϵ
        /// </summary>
        /// <param name="branchcodes"></param>
        /// <param name="groupid"></param>
        /// <param name="strOper">1��������2��ɾ��</param>
        /// <returns></returns>
        public static int UpdateBranchGroupId(string branchcodes, string groupid, string strOper)
        {
            return BranchManageDAL.UpdateBranchGroupId(branchcodes, groupid, strOper);
        }
    }
}