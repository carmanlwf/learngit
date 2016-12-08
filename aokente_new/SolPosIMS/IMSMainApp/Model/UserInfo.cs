using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Project.User;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Project.Configuration;
using ZsdDotNetLibrary.Utility;
namespace Ims.Main.Model
{
        public enum agentState
        {
            eLogin = 0,//登录
            eLogout = 1,//注销
            eUnknown = 9//未知
        }

    [DbObject("v_pub_agentinfo", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    [DbObject("v_pub_sheetrole", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    [DbObject("pub_agentinfo", ObjType = DbObjectAttribute.ObjectType.Table, UpdateFields = "access_status,access_time,access_phone,access_callid,access_activetime,access_ip,access_hostname,access_serverip")]
    //[DbObject("pub_sheetrole", ObjType = DbObjectAttribute.ObjectType.Table, UpdateFields = "access_status,access_time,access_phone,access_callid,access_activetime,access_ip,access_hostname,access_serverip")]
    [Serializable]
        public class UserInfo : UserBase
        {
            bool isSupervisor = false;


            [DataField("superflag")]
            public bool IsSupervisor
            {
                get { return isSupervisor; }
                set { isSupervisor = value; }
            }

            public string supervisorId;
            public string supervisorName;

            
            public int areaId { get; set; }

            public string SupervisorId
            {
                get { return supervisorId; }
                set { supervisorId = value; }
            }

            public string SupervisorName
            {
                get { return supervisorName; }
                set { supervisorName = value; }
            }
            #region Model
            private string _pm_employee_id;
            private string pwd;
            private string _name;
            private bool? validflag;
            private string access_status;
            private string access_time;
            private string access_status_name;
            //private string activetime;
            private string access_activetime;
            //private Dictionary<string, string> branchs = new Dictionary<string, string>();

            //public Dictionary<string, string> Branchs
            //{
            //    get { return branchs; }
            //}

            //public bool isInBranch(string code)
            //{
            //    string value = "";
            //    if (branchs.TryGetValue(code, out value)) return true;
            //    return false;
            //}
            /// <summary>
            /// 
            /// </summary>
            /// <summary>
            /// 
            /// </summary>
            public string pm_employee_id
            {
                set { _pm_employee_id = value; }
                get { return _pm_employee_id; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Pwd
            {
                set { pwd = value; }
                get { return pwd; }
            }
            public string name
            {
                get { return _name; }
                set { _name = value; }
            }
            /// <summary>
            /// 
            /// </summary>
            public bool? Validflag
            {
                set { validflag = value; }
                get { return validflag; }
            }
            /// <summary>
            ///0:登录;1;退出;9:未知
            /// </summary>
            /// 
            [InitListControl("access_status", "agtState")]
            [BindControlParameter("", "value")]
            public string Access_status
            {
                set { access_status = value; }
                get { return access_status; }
            }
            /// <summary>
            /// 0:登录;1;退出;9:未知
            /// </summary>
            public string Access_status_name
            {
                set { access_status_name = value; }
                get { return access_status_name; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Access_time
            {
                set { access_time = value; }
                get { return access_time; }
            }

            public string Access_activetime
            {
                get { return access_activetime; }
                set { access_activetime = value; }
            }

            //分公司人员信息
            //private string _type;
            private string _station_code;
            private string _station_name;
            /// <summary>
            /// 
            /// </summary>
            public string stationcode
            {
                set { _station_code = value; }
                get { return _station_code; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string station_name
            {
                set { _station_name = value; }
                get { return _station_name; }
            }

            #endregion Model

            public override string ToString()
            {
                return PropHelper.ObjectToString(this);
            }

            public bool IsLogIn()
            {
                if (string.IsNullOrEmpty(access_status)) return false;
                switch ((agentState)TypeHelper.ChangeType<int>(access_status))
                {
                    case agentState.eLogout:
                        return false;
                    case agentState.eUnknown:
                        return false;
                }
                return true;
            }
        }
    }
