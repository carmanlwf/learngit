using System;
using System.Collections.Generic;
using System.Text;
using Ims.PM.BLL;

namespace Ims.PM.DAL
{
    public class PmEmployeeDAL
    {
        /// <summary>
        /// ��ü���������
        /// </summary>
        /// <param name="Groupinfo"></param>
        /// <returns></returns>
        public static string GetGroupInfo(string Groupinfo)
        {
            Groupinfo = (string.IsNullOrEmpty(Groupinfo)) ? Groupinfo : Groupinfo.Trim();
            string wheresql = " where id = '" + Groupinfo + "'";
            string grade = PmTtBLLHelper.GetSingleString(wheresql, "pub_groupinfo", "groupname");
            return grade;
        }

        /// <summary>
        /// ���ְ������
        /// </summary>
        /// <param name="JobLevel"></param>
        /// <returns></returns>
        public static string GetJobLevel(string JobLevel)
        {
            JobLevel = (string.IsNullOrEmpty(JobLevel)) ? JobLevel : JobLevel.Trim();
            return PmTtBLLHelper.fromCodeToName(JobLevel, "joblevel");
        }

        /// <summary>
        /// ��ü��ܵȼ�
        /// </summary>
        /// <param name="SkillLevel"></param>
        /// <returns></returns>
        public static string GetSkillLevel(string SkillLevel)
        {
            SkillLevel = (string.IsNullOrEmpty(SkillLevel)) ? SkillLevel : SkillLevel.Trim();
            return PmTtBLLHelper.fromCodeToName(SkillLevel, "sklevel", "pm_codes");
        }

        /// <summary>
        /// �����ѵ�ȼ�
        /// </summary>
        /// <param name="TrainLevel"></param>
        /// <returns></returns>
        public static string GetTrainLevel(string TrainLevel)
        {
            TrainLevel = (string.IsNullOrEmpty(TrainLevel)) ? TrainLevel : TrainLevel.Trim();
            return PmTtBLLHelper.fromCodeToName(TrainLevel, "tlevel", "tt_codes");
        }

        /// <summary>
        /// ��Ȼ��
        /// </summary>
        /// <param name="EmployeeGroup"></param>
        /// <returns></returns>
        public static string GetEmployeeGroup(string EmployeeGroup)
        {
            EmployeeGroup = (string.IsNullOrEmpty(EmployeeGroup)) ? EmployeeGroup : EmployeeGroup.Trim();
            return PmTtBLLHelper.fromCodeToName(EmployeeGroup, "group", "pm_codes");
        }

        /// <summary>
        /// ��ѵ;��
        /// </summary>
        /// <param name="TrainMethod"></param>
        /// <returns></returns>
        public static string GetTrainMethod(string TrainMethod)
        {
            return PmTtBLLHelper.fromCodeToName(TrainMethod, "emethod");
        }
    }
}
