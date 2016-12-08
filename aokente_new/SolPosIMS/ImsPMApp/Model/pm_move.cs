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
    /// 类pm_move。
    /// </summary>
    
    [BindControlParameter("","value",ParamUsage= BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    [DbObject("p_pm_move", ObjType = DbObjectAttribute.ObjectType.StoredProcedure, ParamFields = "id,employee_id,changetype,changetime,changebigsort,changereason,oldstation,station,flag")]
    [DbObject("pm_move", ObjType = DbObjectAttribute.ObjectType.Table)]
    public class pm_move
    {
        public pm_move()
        { }
        #region Model
        private string _id;
        private string _employee_id;
        private string _changetype;
        private string _changetime;
        private string _changebigsort;
        //private string _changesmallsort;
        private string _changereason;
        private string _station;
        private string _oldstation;
        private bool? _flag;
        /// <summary>
        /// 
        /// </summary>
        [DataField(IsKey = true , ParamDirection = ParameterDirection.Input)]
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
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string employee_id
        {
            set { _employee_id = value; }
            get { return _employee_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "SelectedValue", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string changetype
        {
            set { _changetype = value; }
            get { return _changetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string changetime
        {
            set { _changetime = value; }
            get { return _changetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "SelectedValue", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string changebigsort
        {
            set { _changebigsort = value; }
            get { return _changebigsort; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.InputOutput)]
        public string changereason
        {
            set { _changereason = value; }
            get { return _changereason; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("" , "checked" ,ParamUsage= BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField(ParamDirection = ParameterDirection.Input)]
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("","post","pm_codes","")]
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string station
        {
            set { _station = value; }
            get { return _station; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string oldstation
        {
            set { _oldstation = value; }
            get { return _oldstation; }
        }

        #endregion Model
    }
    #endregion 添加、修改对象


    #region 查询人员对象
   /// <summary>
	/// 类v_pm_move。
	/// </summary>
    
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
    [DbObject("v_pm_move_person", ObjType = DbObjectAttribute.ObjectType.View)]
    public class pm_move_search
    {
        public pm_move_search()
        { }
        private string _pname;
        private int? _sex;
        private string _birthday;
        private string _age;
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
        private string _histudy;
        private string _graduateschool;
        private string _hidegree;
        private string _hispeciality;
        private string _higraduatetime;
        private string _higraduateschool;
        private string _ptype;
        private string _transfertime;
        private string _station;
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
        private string _id;
        private string _movechangetime;
        private string _changereason;
        private string _oldstation;
        private string _movestation;
        private bool? _flag;
        private string _code;
        private string _typename;
        private string _codesname;

        private string _beginleveltime;
        private string _endleveltime;
        private string _beginchangestationtime;
        private string _endchangestationtime;
        private string _beginenterstationtime;
        private string _endenterstationtime;
        private string _ctype;
        private string _cchange;
        private string _changetype;


        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField(">=")]
        public string beginleveltime
        {
            set { _beginleveltime = value; }
            get { return _beginleveltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField("<=")]
        public string endleveltime
        {
            set { _endleveltime = value; }
            get { return _endleveltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField(">=")]
        public string beginchangestationtime
        {
            set { _beginchangestationtime = value; }
            get { return _beginchangestationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField("<=")]
        public string endchangestationtime
        {
            set { _endchangestationtime = value; }
            get { return _endchangestationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField(">=")]
        public string beginenterstationtime
        {
            set { _beginenterstationtime = value; }
            get { return _beginenterstationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField("<=")]
        public string endenterstationtime
        {
            set { _endenterstationtime = value; }
            get { return _endenterstationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "ctype", "pm_codes", "")]
        [DataField("changebigsort", OnlyQuery = true)]
        public string ctype
        {
            set { _ctype = value; }
            get { return _ctype; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "cchange", "pm_codes", "")]
        [DataField("changebigsort", OnlyQuery = true)]
        public string cchange
        {
            set { _cchange = value; }
            get { return _cchange; }
        }

        public string changetype
        {
            set { _changetype = value; }
            get { return _changetype; }
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
        public string birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
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
        [InitListControl("", "study", "pm_codes", "")]
        public string histudy
        {
            set { _histudy = value; }
            get { return _histudy; }
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
        public string transfertime
        {
            set { _transfertime = value; }
            get { return _transfertime; }
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
        //[InitListControl("", "jnzlx", "pub_codes", "")]
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
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string movechangetime
        {
            set { _movechangetime = value; }
            get { return _movechangetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string changereason
        {
            set { _changereason = value; }
            get { return _changereason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oldstation
        {
            set { _oldstation = value; }
            get { return _oldstation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string movestation
        {
            set { _movestation = value; }
            get { return _movestation; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("iflag", "value", ParamUsage = BindParameterUsage.OpQuery)]
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
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
        public string typename
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string codesname
        {
            set { _codesname = value; }
            get { return _codesname; }
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
    }
    #endregion 查询对象


    #region 查询异动信息对象

	/// <summary>
	/// 类v_pm_move。
	/// </summary>
    
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpQuery)]
    [DbObject("v_pm_move", ObjType = DbObjectAttribute.ObjectType.View)]
    public class pm_move_info
    {
        public pm_move_info()
        { }
        private string _pname;
        private int? _sex;
        private string _birthday;
        private string _age;
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
        private string _histudy;
        private string _graduateschool;
        private string _hidegree;
        private string _hispeciality;
        private string _higraduatetime;
        private string _higraduateschool;
        private string _ptype;
        private string _transfertime;
        private string _station;
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
        private string _id;
        private string _movechangetime;
        private string _changereason;
        private string _oldstation;
        private string _movestation;
        private bool? _flag;
        private string _code;
        private string _typename;
        private string _codesname;

        private string _beginleveltime;
        private string _endleveltime;
        private string _beginchangestationtime;
        private string _endchangestationtime;
        private string _beginenterstationtime;
        private string _endenterstationtime;
        private string _ctype;
        private string _cchange;
        private string _changetype;


        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField(">=")]
        public string beginleveltime
        {
            set { _beginleveltime = value; }
            get { return _beginleveltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField("<=")]
        public string endleveltime
        {
            set { _endleveltime = value; }
            get { return _endleveltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField(">=")]
        public string beginchangestationtime
        {
            set { _beginchangestationtime = value; }
            get { return _beginchangestationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField("<=")]
        public string endchangestationtime
        {
            set { _endchangestationtime = value; }
            get { return _endchangestationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField(">=")]
        public string beginenterstationtime
        {
            set { _beginenterstationtime = value; }
            get { return _beginenterstationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField("changetime", OnlyQuery = true)]
        [SqlField("<=")]
        public string endenterstationtime
        {
            set { _endenterstationtime = value; }
            get { return _endenterstationtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "ctype", "pm_codes", "")]
        [DataField("changebigsort", OnlyQuery = true)]
        public string ctype
        {
            set { _ctype = value; }
            get { return _ctype; }
        }
        /// <summary>
        /// 
        /// </summary>
        [InitListControl("", "cchange", "pm_codes", "")]
        [DataField("changebigsort", OnlyQuery = true)]
        public string cchange
        {
            set { _cchange = value; }
            get { return _cchange; }
        }

        public string changetype
        {
            set { _changetype = value; }
            get { return _changetype; }
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
        public string birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
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
        [InitListControl("", "study", "pm_codes", "")]
        public string histudy
        {
            set { _histudy = value; }
            get { return _histudy; }
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
        public string transfertime
        {
            set { _transfertime = value; }
            get { return _transfertime; }
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
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string movechangetime
        {
            set { _movechangetime = value; }
            get { return _movechangetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string changereason
        {
            set { _changereason = value; }
            get { return _changereason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string oldstation
        {
            set { _oldstation = value; }
            get { return _oldstation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string movestation
        {
            set { _movestation = value; }
            get { return _movestation; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("iflag", "value", ParamUsage = BindParameterUsage.OpQuery)]
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
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
        public string typename
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string codesname
        {
            set { _codesname = value; }
            get { return _codesname; }
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
    }
    #endregion 查询异动信息对象
}
