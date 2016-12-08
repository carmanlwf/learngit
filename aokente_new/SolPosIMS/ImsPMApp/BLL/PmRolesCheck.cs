using System;
using System.Collections.Generic;
using System.Text;
using Ims.Main.BLL;
using System.Web.Security;
using Ims.Main;

namespace Ims.PM.BLL
{
    public class PmRolesCheck
    {
        #region ���д���ά����Ȩ���ж�

        /// <summary>
        /// ��ȡ��ǰ�û�����Ȩ��
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllRightsByCurrentUser()
        {
            return ImsInfo.CurrentRoles;
        }

        /// <summary>
        /// �ж��ǲ���ϵͳ����Ա
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsSystemManager()
        {
            List<string> list = GetAllRightsByCurrentUser();
            bool isSys = false;
            foreach (string str in list)
            {
                if (str.Trim().EndsWith("systemmanage") || str.Trim() == "admin_code")
                {
                    isSys = true;
                }
            }
            return isSys;
        }

        #endregion

        #region Ȩ�޶���

        //��Ա����
        public static readonly string PmInfo_Admin = "admin";
        public static readonly string PmInfo_All = "pm_baseinfoall";
        public static readonly string PmInfo_Dept = "pm_baseinfodept";
        public static readonly string PmInfo_Group = "pm_baseinfogroup";
        public static readonly string PmInfo_Self = "pm_baseinfoself";
        public static readonly string PmInfoCode = PmInfo_Admin+","+PmInfo_All + "," + PmInfo_Dept + "," + PmInfo_Group + "," + PmInfo_Self;

        //��λ�춯
        public static readonly string PmStation_All = "pm_stationchangeall";
        public static readonly string PmStation_Dept = "pm_stationchangedept";
        public static readonly string PmStation_Group = "pm_stationchangegroup";
        public static readonly string PmStation_Self = "pm_stationchangeself";
        public static readonly string PmStationCode = PmStation_All + "," + PmStation_Dept + "," + PmStation_Group + "," + PmStation_Self;

        //ȫԱ������Ϣ
        public static readonly string PmAbility_All = "pm_abilityall";
        public static readonly string PmAbility_Dept = "pm_abilitydept";
        public static readonly string PmAbility_Group = "pm_abilitygroup";
        public static readonly string PmAbility_Self = "pm_abilityself";
        public static readonly string PmAbilityCode = PmAbility_All + "," + PmAbility_Dept + "," + PmAbility_Group + "," + PmAbility_Self;

        //��ѵ����
        public static readonly string PmTrain_All = "pm_trainall";
        public static readonly string PmTrain_Dept = "pm_traindept";
        public static readonly string PmTrain_Group = "pm_traingroup";
        public static readonly string PmTrain_Self = "pm_trainself";
        public static readonly string PmTrainCode = PmTrain_All + "," + PmTrain_Dept + "," + PmTrain_Group + "," + PmTrain_Self;

        //�����ʸ���֤��Ϣ
        public static readonly string PmEnable_All = "pm_skillall";
        public static readonly string PmEnable_Dept = "pm_skilldept";
        public static readonly string PmEnable_Group = "pm_skillgroup";
        public static readonly string PmEnable_Self = "pm_skillself";
        public static readonly string PmEnableCode = PmEnable_All + "," + PmEnable_Dept + "," + PmEnable_Group + "," + PmEnable_Self;

        //���ܵȼ�
        public static readonly string PmSkill_All = "pm_enableall";
        public static readonly string PmSkill_Dept = "pm_enabledept";
        public static readonly string PmSkill_Group = "pm_enablegroup";
        public static readonly string PmSkill_Self = "pm_enableself";
        public static readonly string PmSkillCode = PmSkill_All + "," + PmSkill_Dept + "," + PmSkill_Group + "," + PmSkill_Self;

        //���ͼ�¼
        public static readonly string PmPunish_All = "pm_punishmentall";
        public static readonly string PmPunish_Dept = "pm_punishmentdept";
        public static readonly string PmPunish_Group = "pm_punishmentgroup";
        public static readonly string PmPunish_Self = "pm_punishmentself";
        public static readonly string PmPunishCode = PmPunish_All + "," + PmPunish_Dept + "," + PmPunish_Group + "," + PmPunish_Self;

        //��Ϊ�淶����
        public static readonly string PmCheck_All = "pm_checkall";
        public static readonly string PmCheck_Dept = "pm_checkdept";
        public static readonly string PmCheck_Group = "pm_checkgroup";
        public static readonly string PmCheck_Self = "pm_checkself";
        public static readonly string PmCheckCode = PmCheck_All + "," + PmCheck_Dept + "," + PmCheck_Group + "," + PmCheck_Self;

        //����CODE
        public static readonly string PmAll = PmStation_All + "," + PmTrain_All + "," + PmAbility_All + "," + PmSkill_All + "," + PmPunish_All + "," + PmCheck_All + "," + PmEnable_All;
        public static readonly string PmDept = PmStation_Dept + "," + PmTrain_Dept + "," + PmAbility_Dept + "," + PmPunish_Dept + "," + PmCheck_Dept + "," + PmEnable_Dept + "," + PmSkill_Dept;
        public static readonly string PmGroup = PmStation_Group + "," + PmStation_Group + "," + PmStation_Group + "," + PmStation_Group + "," + PmStation_Group + "," + PmEnable_Group + "," + PmSkill_Group;
        public static readonly string PmSelf = PmStation_Self + "," + PmTrain_Self + "," + PmAbility_Self + "," + PmPunish_Self + "," + PmCheck_Self + "," + PmEnable_Self + "," + PmSkill_Self;
        public static readonly string PmCode = PmStationCode + "," + PmTrainCode + "," + PmAbilityCode + "," + PmPunishCode + "," + PmCheckCode + "," + PmEnableCode + "," + PmSkillCode;


        //ϵͳ����
        public static readonly string PmSys = "pm_systemmanage";

        //ȫԱ�ۺϼ�Ч����
        public static readonly string PmPerforms = "pm_performscheckall";

        #endregion

        /// <summary>
        /// ����ǲ����˹ܽ�ɫ
        /// </summary>
        /// <returns></returns>
        public static bool InPMRoles(string rolecode)
        {
            if (string.IsNullOrEmpty(CheckPMRoles(rolecode)))
                return false;
            else
                return true;
        }

        /// <summary>
        /// ��ȡ�û���Ӧ���˹ܽ�ɫ
        /// </summary>
        /// <returns></returns>
        public static string CheckPMRoles()
        {
            return CheckPMRoles("pm_trainer,pm_deptmanager,pm_monitor,pm_agent");
        }

        /// <summary>
        /// ��ȡ�û���Ӧ���˹�Ȩ��
        /// </summary>
        /// <param name="rolecode"></param>
        /// <returns></returns>
        public static string CheckPMRoles(string rolecode)
        {
            return ImsInfo.CheckUserRoles(rolecode);
        }

        /// <summary>
        /// ����˹ܽ�ɫ
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static bool CheckPMRole(string roles)
        {
            if (CheckPMRoles().Contains(roles))
                return true;
            else
                return false;
        }

        /// <summary>
        /// ���Ȩ��
        /// </summary>
        /// <param name="rolecode"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static bool CheckPMRole(string rolecode, string roles)
        {
            if (CheckPMRoles(rolecode).Contains(roles))
                return true;
            else
                return false;
        }

        /// <summary>
        /// �����ϯȨ��
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMAgentRight()
        {
            return CheckRight(PmCode, PmSelf);
        }

        /// <summary>
        /// ��鴦����Ȩ��
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMDeptRight()
        {
            return CheckRight(PmCode, PmDept);
        }

        /// <summary>
        /// ���೤Ȩ��
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMGroupRight()
        {
            return CheckRight(PmCode, PmGroup);
        }

        /// <summary>
        /// ���ϵͳ����ԱȨ��
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMSystemRight()
        {
            return CheckRight(PmSys, PmSys);
        }

        /// <summary>
        /// ���Ȩ��
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public static bool CheckRight(string roles , string typecode)
        {
            bool result = false;
            string[] tcode = typecode.Split(new char[]{','} , StringSplitOptions.RemoveEmptyEntries);
            for ( int i = 0 ; i < tcode.Length ; i++)
            {
                if (CheckPMRoles(PmCode).Contains(tcode[i]))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// �ǲ�����ѵ�ڽ�ɫ
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMTrainer()
        {
            return CheckPMRole("pm_trainer");
        }

        /// <summary>
        /// �ǲ��Ǵ������ɫ
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMDeptmanager()
        {
            return CheckPMRole("pm_deptmanager");
        }

        /// <summary>
        /// �ǲ��ǰ೤��ɫ
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMMonitor()
        {
            return CheckPMRole("pm_monitor");
        }

        /// <summary>
        /// �ǲ�����ϯ�����ɫ
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMAgent()
        {
            return CheckPMRole("pm_agent");
        }

        /// <summary>
        /// ��ǰ��½�û��ı�ţ��ǹ��ţ�
        /// </summary>
        /// <returns></returns>
        public static string CurrCode()
        {
            return ImsInfo.CurrentUser.pm_employee_id.ToString().Trim();
        }

        public static string CurrName()
        {
            return ImsInfo.CurrentUser.Name.ToString().Trim();
        }

        /// <summary>
        /// ��ǰ��½�û��Ĵ����
        /// </summary>
        /// <returns></returns>
        public static string CurrDeptCode()
        {
            return PmTtBLLHelper.GetEmployeeInfo(CurrCode(), "dept");
        }

        /// <summary>
        /// ��ǰ��½�û��ļ�������
        /// </summary>
        /// <returns></returns>
        public static string CurrSkGroupCode()
        {
            return ImsInfo.CurrentUser.GroupId.ToString().Trim();
        }

    }
}
