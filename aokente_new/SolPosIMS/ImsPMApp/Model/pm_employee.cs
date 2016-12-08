using System;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Data;
namespace Ims.PM
{
	/// <summary>
	/// 实体类pm_employee 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [DbObject("pm_employee", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pm_employee", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class pm_employee
    {
        public pm_employee()
        { }
        #region Model
        private string _code;
        private string _pname;
        private int? _sex;
        private string _birthday;
        private string _idcar;
        private string _entertime;
        private string _email;
        private string _dept;
        private string _employeegroup;
        private string _station;
        private string _memo;
        private bool? _flag;
        /// <summary>
        /// 
        /// </summary>
        [DataField(IsKey = true)]
        [InitListControl("", "code", "code", "pm_employee", "code")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 员工姓名
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int? sex
        {
            set { _sex = value; }
            get { return _sex; }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string station
        {
            set { _station = value; }
            get { return _station; }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        public string idcar
        {
            set { _idcar = value; }
            get { return _idcar; }
        }

        /// <summary>
        /// 入职时间
        /// </summary>
        public string entertime
        {
            set { _entertime = value; }
            get { return _entertime; }
        }
        /// <summary>
        /// email
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 入员工备注
        /// </summary>
        public string memo
        {
            set { _memo = value; }
            get { return _memo; }
        }

        /// <summary>
        /// 所属部门
        /// </summary>
        [InitListControl("", "dept", "pm_codes", "")]
        public string dept
        {
            set { _dept = value; }
            get { return _dept; }
        }
        /// <summary>
        /// 所在分组
        /// </summary>
        [InitListControl("", "group", "pm_codes", "")]
        public string employeegroup
        {
            set { _employeegroup = value; }
            get { return _employeegroup; }
        }

        private bool? _chflag;
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("flag")]
        public bool? chflag
        {
            set { _chflag = value; }
            get { return _chflag; }
        }

        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }

        //以下查询用

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
        #endregion Model
    }
}

