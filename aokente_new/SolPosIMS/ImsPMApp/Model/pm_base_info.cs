using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.PM
{
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
    [DbObject("v_pm_employee", ObjType = DbObjectAttribute.ObjectType.View)]
    public class pm_base_info
    {
        #region Model
        private string _code;
        private string _pname;
        private int? _sex;
        private string _age;
        private string _birthday;
        private string _nation;
        private string _polity;
        private string _native;
        private string _localplace;
        private string _idcar;
        private string _technicalpost;
        private string _worktime;
        private string _entertime;
        private string _email;
        private string _fristudy;
        private string _degree;
        private string _speciality;
        private string _graduatetime;
        private string _graduateschool;
        private string _histudy;
        private string _hidegree;
        private string _hispeciality;
        private string _higraduatetime;
        private string _higraduateschool;
        private string _ptype;
        private string _station;
        private string _transfertime;
        private string _posttime;
        private string _dept;
        private string _skillgroup;
        private string _employeegroup;
        private string _skilllevel;
        private string _joblevel;
        private string _fristtry;
        private string _listen;
        private string _writetest;
        private string _typespeed;
        private string _fristoption;
        private string _retrial;
        private string _retrialresult;
        private string _traintime;
        private string _postfit;
        private string _guardtime;
        private string _changetime;
        private bool? _flag;
        
        /// <summary>
        /// 
        /// </summary>
        [DataField(IsKey = true)]
        [BindQueryStringParameter("getemployee", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
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
        public string birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "nation", "pm_codes", "")]
        public string nation
        {
            set { _nation = value; }
            get { return _nation; }
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
        public string native
        {
            set { _native = value; }
            get { return _native; }
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
        public string idcar
        {
            set { _idcar = value; }
            get { return _idcar; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "tecpost", "pm_codes", "")]
        public string technicalpost
        {
            set { _technicalpost = value; }
            get { return _technicalpost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string worktime
        {
            set { _worktime = value; }
            get { return _worktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string entertime
        {
            set { _entertime = value; }
            get { return _entertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "study", "pm_codes", "")]
        public string fristudy
        {
            set { _fristudy = value; }
            get { return _fristudy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string degree
        {
            set { _degree = value; }
            get { return _degree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string speciality
        {
            set { _speciality = value; }
            get { return _speciality; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string graduatetime
        {
            set { _graduatetime = value; }
            get { return _graduatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string graduateschool
        {
            set { _graduateschool = value; }
            get { return _graduateschool; }
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
        public string hidegree
        {
            set { _hidegree = value; }
            get { return _hidegree; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hispeciality
        {
            set { _hispeciality = value; }
            get { return _hispeciality; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string higraduatetime
        {
            set { _higraduatetime = value; }
            get { return _higraduatetime; }
        }
        /// <summary>
        /// 
        /// </summary>

        public string higraduateschool
        {
            set { _higraduateschool = value; }
            get { return _higraduateschool; }
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
        public string transfertime
        {
            set { _transfertime = value; }
            get { return _transfertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string posttime
        {
            set { _posttime = value; }
            get { return _posttime; }
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
        [InitListControl("", "joblevel", "pm_codes", "")]
        public string joblevel
        {
            set { _joblevel = value; }
            get { return _joblevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fristtry
        {
            set { _fristtry = value; }
            get { return _fristtry; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string listen
        {
            set { _listen = value; }
            get { return _listen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string writetest
        {
            set { _writetest = value; }
            get { return _writetest; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typespeed
        {
            set { _typespeed = value; }
            get { return _typespeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fristoption
        {
            set { _fristoption = value; }
            get { return _fristoption; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string retrial
        {
            set { _retrial = value; }
            get { return _retrial; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string retrialresult
        {
            set { _retrialresult = value; }
            get { return _retrialresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string traintime
        {
            set { _traintime = value; }
            get { return _traintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string postfit
        {
            set { _postfit = value; }
            get { return _postfit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string guardtime
        {
            set { _guardtime = value; }
            get { return _guardtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string changetime
        {
            set { _changetime = value; }
            get { return _changetime; }
        }

        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        #endregion Model
    }
}
