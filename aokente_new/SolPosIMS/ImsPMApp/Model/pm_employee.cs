using System;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Data;
namespace Ims.PM
{
	/// <summary>
	/// ʵ����pm_employee ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// Ա������
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// �Ա�
        /// </summary>
        public int? sex
        {
            set { _sex = value; }
            get { return _sex; }
        }

        /// <summary>
        /// ��������
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
        /// ���֤
        /// </summary>
        public string idcar
        {
            set { _idcar = value; }
            get { return _idcar; }
        }

        /// <summary>
        /// ��ְʱ��
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
        /// ��Ա����ע
        /// </summary>
        public string memo
        {
            set { _memo = value; }
            get { return _memo; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        [InitListControl("", "dept", "pm_codes", "")]
        public string dept
        {
            set { _dept = value; }
            get { return _dept; }
        }
        /// <summary>
        /// ���ڷ���
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

        //���²�ѯ��

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

