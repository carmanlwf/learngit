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
        #region 所有代码维护的权限判断

        /// <summary>
        /// 获取当前用户所有权限
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllRightsByCurrentUser()
        {
            return ImsInfo.CurrentRoles;
        }

        /// <summary>
        /// 判断是不是系统管理员
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

        #region 权限对照

        //人员管理
        public static readonly string PmInfo_Admin = "admin";
        public static readonly string PmInfo_All = "pm_baseinfoall";
        public static readonly string PmInfo_Dept = "pm_baseinfodept";
        public static readonly string PmInfo_Group = "pm_baseinfogroup";
        public static readonly string PmInfo_Self = "pm_baseinfoself";
        public static readonly string PmInfoCode = PmInfo_Admin+","+PmInfo_All + "," + PmInfo_Dept + "," + PmInfo_Group + "," + PmInfo_Self;

        //岗位异动
        public static readonly string PmStation_All = "pm_stationchangeall";
        public static readonly string PmStation_Dept = "pm_stationchangedept";
        public static readonly string PmStation_Group = "pm_stationchangegroup";
        public static readonly string PmStation_Self = "pm_stationchangeself";
        public static readonly string PmStationCode = PmStation_All + "," + PmStation_Dept + "," + PmStation_Group + "," + PmStation_Self;

        //全员能力信息
        public static readonly string PmAbility_All = "pm_abilityall";
        public static readonly string PmAbility_Dept = "pm_abilitydept";
        public static readonly string PmAbility_Group = "pm_abilitygroup";
        public static readonly string PmAbility_Self = "pm_abilityself";
        public static readonly string PmAbilityCode = PmAbility_All + "," + PmAbility_Dept + "," + PmAbility_Group + "," + PmAbility_Self;

        //培训经历
        public static readonly string PmTrain_All = "pm_trainall";
        public static readonly string PmTrain_Dept = "pm_traindept";
        public static readonly string PmTrain_Group = "pm_traingroup";
        public static readonly string PmTrain_Self = "pm_trainself";
        public static readonly string PmTrainCode = PmTrain_All + "," + PmTrain_Dept + "," + PmTrain_Group + "," + PmTrain_Self;

        //能力资格认证信息
        public static readonly string PmEnable_All = "pm_skillall";
        public static readonly string PmEnable_Dept = "pm_skilldept";
        public static readonly string PmEnable_Group = "pm_skillgroup";
        public static readonly string PmEnable_Self = "pm_skillself";
        public static readonly string PmEnableCode = PmEnable_All + "," + PmEnable_Dept + "," + PmEnable_Group + "," + PmEnable_Self;

        //技能等级
        public static readonly string PmSkill_All = "pm_enableall";
        public static readonly string PmSkill_Dept = "pm_enabledept";
        public static readonly string PmSkill_Group = "pm_enablegroup";
        public static readonly string PmSkill_Self = "pm_enableself";
        public static readonly string PmSkillCode = PmSkill_All + "," + PmSkill_Dept + "," + PmSkill_Group + "," + PmSkill_Self;

        //奖惩记录
        public static readonly string PmPunish_All = "pm_punishmentall";
        public static readonly string PmPunish_Dept = "pm_punishmentdept";
        public static readonly string PmPunish_Group = "pm_punishmentgroup";
        public static readonly string PmPunish_Self = "pm_punishmentself";
        public static readonly string PmPunishCode = PmPunish_All + "," + PmPunish_Dept + "," + PmPunish_Group + "," + PmPunish_Self;

        //行为规范考核
        public static readonly string PmCheck_All = "pm_checkall";
        public static readonly string PmCheck_Dept = "pm_checkdept";
        public static readonly string PmCheck_Group = "pm_checkgroup";
        public static readonly string PmCheck_Self = "pm_checkself";
        public static readonly string PmCheckCode = PmCheck_All + "," + PmCheck_Dept + "," + PmCheck_Group + "," + PmCheck_Self;

        //所有CODE
        public static readonly string PmAll = PmStation_All + "," + PmTrain_All + "," + PmAbility_All + "," + PmSkill_All + "," + PmPunish_All + "," + PmCheck_All + "," + PmEnable_All;
        public static readonly string PmDept = PmStation_Dept + "," + PmTrain_Dept + "," + PmAbility_Dept + "," + PmPunish_Dept + "," + PmCheck_Dept + "," + PmEnable_Dept + "," + PmSkill_Dept;
        public static readonly string PmGroup = PmStation_Group + "," + PmStation_Group + "," + PmStation_Group + "," + PmStation_Group + "," + PmStation_Group + "," + PmEnable_Group + "," + PmSkill_Group;
        public static readonly string PmSelf = PmStation_Self + "," + PmTrain_Self + "," + PmAbility_Self + "," + PmPunish_Self + "," + PmCheck_Self + "," + PmEnable_Self + "," + PmSkill_Self;
        public static readonly string PmCode = PmStationCode + "," + PmTrainCode + "," + PmAbilityCode + "," + PmPunishCode + "," + PmCheckCode + "," + PmEnableCode + "," + PmSkillCode;


        //系统管理
        public static readonly string PmSys = "pm_systemmanage";

        //全员综合绩效考核
        public static readonly string PmPerforms = "pm_performscheckall";

        #endregion

        /// <summary>
        /// 检查是不是人管角色
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
        /// 获取用户对应的人管角色
        /// </summary>
        /// <returns></returns>
        public static string CheckPMRoles()
        {
            return CheckPMRoles("pm_trainer,pm_deptmanager,pm_monitor,pm_agent");
        }

        /// <summary>
        /// 获取用户对应的人管权限
        /// </summary>
        /// <param name="rolecode"></param>
        /// <returns></returns>
        public static string CheckPMRoles(string rolecode)
        {
            return ImsInfo.CheckUserRoles(rolecode);
        }

        /// <summary>
        /// 检查人管角色
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
        /// 检查权限
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
        /// 检查坐席权限
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMAgentRight()
        {
            return CheckRight(PmCode, PmSelf);
        }

        /// <summary>
        /// 检查处经理权限
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMDeptRight()
        {
            return CheckRight(PmCode, PmDept);
        }

        /// <summary>
        /// 检查班长权限
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMGroupRight()
        {
            return CheckRight(PmCode, PmGroup);
        }

        /// <summary>
        /// 检查系统管理员权限
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMSystemRight()
        {
            return CheckRight(PmSys, PmSys);
        }

        /// <summary>
        /// 检查权限
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
        /// 是不是培训岗角色
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMTrainer()
        {
            return CheckPMRole("pm_trainer");
        }

        /// <summary>
        /// 是不是处经理角色
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMDeptmanager()
        {
            return CheckPMRole("pm_deptmanager");
        }

        /// <summary>
        /// 是不是班长角色
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMMonitor()
        {
            return CheckPMRole("pm_monitor");
        }

        /// <summary>
        /// 是不是坐席代表角色
        /// </summary>
        /// <returns></returns>
        public static bool CheckPMAgent()
        {
            return CheckPMRole("pm_agent");
        }

        /// <summary>
        /// 当前登陆用户的编号（非工号）
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
        /// 当前登陆用户的处编号
        /// </summary>
        /// <returns></returns>
        public static string CurrDeptCode()
        {
            return PmTtBLLHelper.GetEmployeeInfo(CurrCode(), "dept");
        }

        /// <summary>
        /// 当前登陆用户的技能组编号
        /// </summary>
        /// <returns></returns>
        public static string CurrSkGroupCode()
        {
            return ImsInfo.CurrentUser.GroupId.ToString().Trim();
        }

    }
}
