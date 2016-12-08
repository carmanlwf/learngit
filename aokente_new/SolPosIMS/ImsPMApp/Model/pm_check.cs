using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;
namespace Ims.PM
{
    #region 添加、修改对象
    /// <summary>
    /// 类pm_check。
    /// </summary>
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class pm_check
    {
        public pm_check()
        { }
        #region Model
        private string _id;
        private string _employee_id;
        private string _checktime;
        private string _bigreason;
        private string _smallreason;
        private string _checkdescribe;
        private bool? _flag;
        /// <summary>
        /// 
        /// </summary>
        [DataField(IsKey = true)]
        [BindQueryStringParameter("getid", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string employee_id
        {
            set { _employee_id = value; }
            get { return _employee_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checktime
        {
            set { _checktime = value; }
            get { return _checktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "code", "name", "pm_checkcode", "code")]
        [BindControlParameter("", "SelectedValue", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        public string bigreason
        {
            set { _bigreason = value; }
            get { return _bigreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "SelectedValue", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        public string smallreason
        {
            set { _smallreason = value; }
            get { return _smallreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checkdescribe
        {
            set { _checkdescribe = value; }
            get { return _checkdescribe; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [BindControlParameter("","Checked",ParamUsage= BindParameterUsage.BindToObjectAndParameter | BindParameterUsage.OpUpdate | BindParameterUsage.OpInsert)]
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        #endregion Model
    }
    #endregion 添加、修改对象

    #region 查询考核信息对象
    /// <summary>
    /// 类pm_check。
    /// </summary>
    [DbObject("v_pm_check", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpQuery)]
    public class pm_check_v
    {
        public pm_check_v()
        { }
        #region Model
        private string _id;
        //private string _employee_id;
        private string _checktime;
        private string _bigreason;
        private string _smallreason;
        private string _checkdescribe;
        private string _grade;
        private bool? _chflag;

        public string grade
        {
            get { return _grade; }
            set { _grade = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataField(IsKey = true)]
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checktime
        {
            set { _checktime = value; }
            get { return _checktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bigreason
        {
            set { _bigreason = value; }
            get { return _bigreason; }
        }

        private string _bigreasoncode;
        [InitListControl("", "code", "name", "pm_checkcode", "code")]
        public string bigreasoncode
        {
            set { _bigreasoncode = value; }
            get { return _bigreasoncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string smallreason
        {
            set { _smallreason = value; }
            get { return _smallreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checkdescribe
        {
            set { _checkdescribe = value; }
            get { return _checkdescribe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? chflag
        {
            set { _chflag = value; }
            get { return _chflag; }
        }

        private string _code;
        private string _pname;
        private int? _sex;
        private string _age;
        private string _polity;
        private string _localplace;
        private string _fristudy;
        private string _histudy;
        private string _ptype;
        private string _station;
        private string _dept;
        private string _skillgroup;
        private string _employeegroup;
        private string _skilllevel;
        private bool? _flag;
        private string _worktime;
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string worktime
        {
            get { return _worktime; }
            set { _worktime = value; }
        }
        private string _entertime;

        public string entertime
        {
            get { return _entertime; }
            set { _entertime = value; }
        }
        private string _guardtime;

        public string guardtime
        {
            get { return _guardtime; }
            set { _guardtime = value; }
        }
        private string _changetime;

        public string changetime
        {
            get { return _changetime; }
            set { _changetime = value; }
        }

        private string _joblevel;

        public string joblevel
        {
            get { return _joblevel; }
            set { _joblevel = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "code", "code", "pm_employee", "code")]
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "sex", "pm_codes", "")]
        public int? sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "polity", "pm_codes", "")]
        public string polity
        {
            set { _polity = value; }
            get { return _polity; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "PLACECODE", "PLACENAME", "v_pub_province", "")]
        public string localplace
        {
            set { _localplace = value; }
            get { return _localplace; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "PLACECODE", "PLACENAME", "v_pub_province", "")]
        public string fristudy
        {
            set { _fristudy = value; }
            get { return _fristudy; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "study", "pm_codes", "")]
        public string histudy
        {
            set { _histudy = value; }
            get { return _histudy; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "ptype", "pm_codes", "")]
        public string ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "station", "pm_codes", "")]
        public string station
        {
            set { _station = value; }
            get { return _station; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "dept", "pm_codes", "")]
        public string dept
        {
            set { _dept = value; }
            get { return _dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "id", "groupname", "pub_groupinfo", "")]
        public string skillgroup
        {
            set { _skillgroup = value; }
            get { return _skillgroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "group", "pm_codes", "")]
        public string employeegroup
        {
            set { _employeegroup = value; }
            get { return _employeegroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "sklevel", "pm_codes", "")]
        public string skilllevel
        {
            set { _skilllevel = value; }
            get { return _skilllevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }

        //以下查询用
        private string _beginworktime;
        private string _endworktime;

        [DataField("worktime", OnlyQuery = true)]
        [SqlField("<=")]
        public string beginworktime
        {
            get { return _beginworktime; }
            set { _beginworktime = value; }
        }

        [DataField("worktime", OnlyQuery = true)]
        [SqlField(">=")]
        public string endworktime
        {
            get { return _endworktime; }
            set { _endworktime = value; }
        }

        private string _beginentertime;
        private string _endentertime;

        [DataField("entertime", OnlyQuery = true)]
        [SqlField("<=")]
        public string beginentertime
        {
            get { return _beginentertime; }
            set { _beginentertime = value; }
        }

        [DataField("entertime", OnlyQuery = true)]
        [SqlField(">=")]
        public string endentertime
        {
            get { return _endentertime; }
            set { _endentertime = value; }
        }

        private string _beginguardtime;
        private string _endguardtime;

        [DataField("guardtime", OnlyQuery = true)]
        [SqlField("<=")]
        public string beginguardtime
        {
            get { return _beginguardtime; }
            set { _beginguardtime = value; }
        }

        [DataField("guardtime", OnlyQuery = true)]
        [SqlField(">=")]
        public string endguardtime
        {
            get { return _endguardtime; }
            set { _endguardtime = value; }
        }

        private string _beginchangetime;
        private string _endchangetime;

        [DataField("changetime", OnlyQuery = true)]
        [SqlField("<=")]
        public string beginchangetime
        {
            get { return _beginchangetime; }
            set { _beginchangetime = value; }
        }

        [DataField("changetime", OnlyQuery = true)]
        [SqlField(">=")]
        public string endchangetime
        {
            get { return _endchangetime; }
            set { _endchangetime = value; }
        }

        private string _beginjoblevel;
        private string _endjoblevel;

        [DataField("joblevel", OnlyQuery = true)]
        [SqlField(">=")]
        [InitListControl("", "joblevel", "pm_codes", "")]
        public string beginjoblevel
        {
            get { return _beginjoblevel; }
            set { _beginjoblevel = value; }
        }

        [DataField("joblevel", OnlyQuery = true)]
        [SqlField("<=")]
        [InitListControl("", "joblevel", "pm_codes", "")]
        public string endjoblevel
        {
            get { return _endjoblevel; }
            set { _endjoblevel = value; }
        }


        //add by xl 0816
        private string _beginchecktime;
        [DataField("checktime", OnlyQuery = true)]
        [SqlField(">=")]
        public string beginchecktime
        {
            get { return _beginchecktime; }
            set { _beginchecktime = value; }
        }
        private string _endchecktime;

        [DataField("checktime", OnlyQuery = true)]
        [SqlField("<=")]
        public string endchecktime
        {
            get { return _endchecktime; }
            set { _endchecktime = value; }
        }

        private bool? _iflag;
        [DataField("flag", OnlyQuery = true)]
        public bool? iflag
        {
            get
            { return _iflag; }
            set
            { _iflag = value; }
        }


        #endregion Model

    
    }
    #endregion 查询考核信息对象

}