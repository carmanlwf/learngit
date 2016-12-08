using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Main.Model
{
    [DbObject("v_pub_agentinfo", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    [DbObject("pub_agentinfo", ObjType = DbObjectAttribute.ObjectType.Table)]
    public class v_agentinfo
    {
        public v_agentinfo()
		{}
        #region Model
        private string _id;
        private string _pm_employee_id;
        private string _pwd;
        private string _icmid;
        private string _icmpwd;
        private string _obid;
        private string _obpwd;
        private bool? _superflag;
        private string _groupid;
        private bool? _validflag;
        private string _access_status;
        private string _access_time;
        private string _access_phone;
        private string _access_activetime;
        private string _access_callid;
        private string _name;
        private string _access_status_name;
        private string _groupname;
        private string _access_ip;
        private string _access_hostname;
        private string _access_serverip;
        private string _grouptype;
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "value")]
        [SqlField(QueryOperator = "like", AfterLike = "%", BeforeLike = "")]
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
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
        public string pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icmid
        {
            set { _icmid = value; }
            get { return _icmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icmpwd
        {
            set { _icmpwd = value; }
            get { return _icmpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string obid
        {
            set { _obid = value; }
            get { return _obid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string obpwd
        {
            set { _obpwd = value; }
            get { return _obpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? superflag
        {
            set { _superflag = value; }
            get { return _superflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("groupid", "id", "id+groupname", "pub_groupinfo", "id", "validflag=1", "")]
        [BindControlParameter("","value")]
        public string groupid
        {
            set { _groupid = value; }
            get { return _groupid; }
        }
        private string _groupid_in;
        [InitListControl("groupid_in", "id", "id+groupname", "pub_groupinfo", "id", "validflag=1", "")]
        [DataField("groupid")]
        [SqlField(QueryOperator="in")]
        public string groupid_in
        {
            set { _groupid_in = value; }
            get { return _groupid_in; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? validflag
        {
            set { _validflag = value; }
            get { return _validflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [InitListControl("access_status", "agtState")]
        [BindControlParameter("", "value")]
        [SqlField(QueryOperator = "in")]
        public string access_status
        {
            set { _access_status = value; }
            get { return _access_status; }
        }
        private string _access_status_in;
        [InitListControl("access_status_in", "agtState")]
        [SqlField(QueryOperator = "in")]
        [DataField("access_status")]
        public string access_status_in
        {
            set { _access_status_in = value; }
            get { return _access_status_in; }
        }
        [SqlField(IsWhereSql = true)]
        public string access_status_9
        {
            get { return " access_status <> '9'"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string access_time
        {
            set { _access_time = value; }
            get { return _access_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string access_phone
        {
            set { _access_phone = value; }
            get { return _access_phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string access_activetime
        {
            set { _access_activetime = value; }
            get { return _access_activetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string access_callid
        {
            set { _access_callid = value; }
            get { return _access_callid; }
        }
  
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "value")]
        [SqlField(QueryOperator = "like",AfterLike="%",BeforeLike="%")]
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string access_status_name
        {
            set { _access_status_name = value; }
            get { return _access_status_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        [SqlField(QueryOperator = "like", AfterLike = "%", BeforeLike = "")]
        public string groupname
        {
            set { _groupname = value; }
            get { return _groupname; }
        }

        public string access_ip
        {
            set { _access_ip = value; }
            get { return _access_ip; }
        }

        public string access_hostname
        {
            set { _access_hostname = value; }
            get { return _access_hostname; }
        }

        public string access_serverip
        {
            set { _access_serverip = value; }
            get { return _access_serverip; }
        }
        public string grouptype
        {
            set { _grouptype = value; }
            get { return _grouptype; }
        }
        
        #endregion Model


        #region  成员方法
        #endregion  成员方法

    }
}
