using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.PM
{
    /// <summary>
    /// ¿‡pm_codes°£
    /// </summary>
    
    [DbObject("p_pub_code", ObjType = DbObjectAttribute.ObjectType.StoredProcedure , ParamFields="statu,sys,id,typecode,code,name,memo,showorder,validflag")]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.BindToObjectAndParameter | BindParameterUsage.OpQuery)]
    public class pub_codes
    {
        public pub_codes()
        { }

        private string _statu;
        [DataField(ParamDirection = ParameterDirection.InputOutput)]
        public string statu
        {
            get { return _statu; }
            set { _statu = value; }
        }
        private string _sys;
        [DataField(ParamDirection=ParameterDirection.Input)]
        public string sys
        {
            get { return _sys; }
            set { _sys = value; }
        }
        private int? _id;
        [DataField(ParamDirection = ParameterDirection.Input)]
        public int? id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _typecode;
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string typecode
        {
            get { return _typecode; }
            set { _typecode = value; }
        }
        private string _code;
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _name;
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _memo;
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private int? _showorder;
        [DataField(ParamDirection = ParameterDirection.Input)]
        public int? showorder
        {
            get { return _showorder; }
            set { _showorder = value; }
        }
        private bool? _validflag;
        [DataField(ParamDirection = ParameterDirection.Input)]
        public bool? validflag
        {
            get { return _validflag; }
            set { _validflag = value; }
        }
    }


	/// <summary>
	/// ¿‡pm_checkcode°£
	/// </summary>
    
    [DbObject("p_pm_checkcode", ObjType = DbObjectAttribute.ObjectType.StoredProcedure, ParamFields = "id,code,name,pcode,flag,statu,addflag")]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.BindToObjectAndParameter | BindParameterUsage.OpQuery)]
    public class pm_checkcode
    {
        public pm_checkcode()
        { }
        #region Model
        private int? _id;
        private string _code;
        private string _name;
        private string _pcode;
        private bool? _flag;
        private string _statu;
        private bool? _addflag;

        /// <summary>
        /// 
        /// </summary>
        [DataField(IsKey = true, ParamDirection = ParameterDirection.Input)]
        public int? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.Input)]
        public string pcode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.Input)]
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.InputOutput)]
        public string statu
        {
            get { return _statu; }
            set { _statu = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(ParamDirection = ParameterDirection.Input)]
        public bool? addflag
        {
            set { _addflag = value; }
            get { return _addflag; }
        }
        #endregion Model
    }



    
    public class pm_codes
    {
        public pm_codes()
        { }

        private int? _id;
        private string _typecode;
        private string _code;
        private string _name;
        private bool? _validflag;
        private int? _showorder;
        private bool? _vindicate;
        private string _orderby_showorder = "asc";

        [DataField("showorder", OnlyQuery = true)]
        [SqlField(IsOrderBy = true)]
        public string orderby_showorder
        {
            get { return _orderby_showorder; }
            set { _orderby_showorder = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [DataField(IsKey =true)]
        public int? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("typecode", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.BindToObjectAndParameter)]
        public string typecode
        {
            set { _typecode = value; }
            get { return _typecode; }
        }

        private string _selecttypecode;

        [DataField("typecode", OnlyQuery= true)]
        [BindControlParameter("GridView1", "SelectedValue", ParamUsage = BindParameterUsage.OpQuery)]
        public string selecttypecode
        {
            get { return _selecttypecode; }
            set { _selecttypecode = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("code", "value", ParamUsage = BindParameterUsage.OpUpdate | BindParameterUsage.OpInsert | BindParameterUsage.BindToObjectAndParameter)]
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpUpdate | BindParameterUsage.OpInsert | BindParameterUsage.BindToObjectAndParameter)]
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("", "checked", ParamUsage = BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        public bool? validflag
        {
            set { _validflag = value; }
            get { return _validflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        [BindControlParameter("showorder", "value", BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
        public int? showorder
        {
            set { _showorder = value; }
            get { return _showorder; }
        }

        public bool? vindicate
        {
            set { _vindicate = value; }
            get { return _vindicate; }
        }

 }
     
    
    [DbObject("v_pm_codeview", ObjType = DbObjectAttribute.ObjectType.View)]   
    public class pm_codetype  
    {    
        public pm_codetype()
            { }
            private string _code;
            private string _name;
            private string _pname;
            /// <summary>
            /// 
            /// </summary>
            public string code
            {
                set { _code = value; }
                get { return _code; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string name
            {
                set { _name = value; }
                get { return _name; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string pname
            {
                set { _pname = value; }
                get { return _pname; }
            }
        }
   
}	