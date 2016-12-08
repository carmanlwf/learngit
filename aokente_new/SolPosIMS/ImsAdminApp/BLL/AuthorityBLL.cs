using System;
using System.Collections.Generic;
using System.Text;
using Ims.Admin.Model;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Admin.DAL;
using System.Data;
using System.Security.Principal;
using System.Web.UI;
using System.Web;
using System.Web.Security;
using Ims.PM;
namespace Ims.Admin.BLL
{
    /// <summary>
    /// Ȩ�޹���ҵ���߼���
    /// </summary>
    public class AuthorityBLL
    {

        #region ���з���

        /// <summary>
        /// ����ϵͳ��Ų�ѯϵͳģ���嵥������Table
        /// </summary>
        /// <param name="syscode">ϵͳ����</param>
        /// <param name="agentid">�û�����</param>
        /// <returns>ϵͳ�嵥Table</returns>
        public static DataTable GetSysTable(string syscode, string agentid)
        {
            DataTable dtAuthority = AuthorityDAL.GetSysTable(syscode, agentid);
            return dtAuthority;
        }

        /// <summary>
        /// ����ϵͳcode����ѯϵͳ��������ȫ����ɫ��Ϣ
        /// </summary>
        /// <param name="syscode">ϵͳ����</param>
        /// <param name="agentid">�û�����</param>
        /// <returns></returns>
        public static DataTable GetRoleTableFromSyscode(string syscode, string agentid)
        {
            DataTable dtRole = AuthorityDAL.GetRoleTableFromSyscode(syscode, agentid);
            return dtRole;
        }
        /// <summary>
        /// ����ϵͳcode����ѯϵͳ��������ȫ��Ȩ����Ϣ
        /// </summary>
        /// <param name="syscode">ϵͳ����</param>
        /// <param name="agentid">�û�����</param>
        /// <returns></returns>
        public static DataTable GetAuthrityTableFromSyscode(string syscode, string agentid)
        {
            DataTable dtAuthrity = AuthorityDAL.GetAuthrityTableFromSyscode(syscode, agentid);
            return dtAuthrity;
        }

        /// <summary>
        ///  �����û�Ȩ�޶�����Ϣ��ͬʱɾ��ԭ��ϵͳģ���ڵ�Ȩ��
        /// </summary>
        /// <param name="agentIds">Ա�����ţ�����ö��ŷָ�</param>
        /// <param name="syscodes"></param>
        /// <param name="authoritys"></param>
        /// <returns></returns>
        public static bool SaveUserInAuthority(string agentIds, string syscodes,string authoritys)
        {
            if (string.IsNullOrEmpty(agentIds) || string.IsNullOrEmpty(syscodes)) return false;
            //�������ݷ��ʲ�
            return AuthorityDAL.SaveUserInAuthority(agentIds, syscodes, authoritys);

        }
        /// <summary>
        /// ��Ӵ�Ȩ�޵��û�
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public static bool AddUserWithAuthority(pm_employee o1, AgentData o2)
        {
            return AuthorityDAL.AddUserWithAuthority(o1, o2);
        }
         #endregion
    }
}
