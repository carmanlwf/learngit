using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    [DbObject("pub_agentinfo", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pub_agentinfo", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    [DbObject("v_pub_agentquerynew", ObjType = DbObjectAttribute.ObjectType.View)]
    //[DbObject("v_pub_agentquery", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
    public class AgentData
    {
        private string _id;//员工工号

        /// <summary>
        /// 员工工号
        /// </summary>
        [DataField(FieldName = "id", IsIdentity = false, IsKey = true, IsNullable = false)]
        //[SqlField(AfterLike="%",BeforeLike="%",QueryOperator="like")]
        [BindControlParameter("empid", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _pm_employee_id;//员工编码

        /// <summary>
        /// 员工编码
        /// </summary>
        [BindControlParameter("pm_employee_id", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("pm_employee_id", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        //[DataField(FieldName = "pm_employee_id", IsIdentity = false, IsKey = false, IsNullable = false)]
        //[SqlField(AfterLike = "%", BeforeLike = "%", QueryOperator = "like")]
        public string pm_employee_id
        {
            get { return _pm_employee_id; }
            set { _pm_employee_id = value; }
        }

        private string _pwd;//登录密码

        /// <summary>
        /// 登录密码
        /// </summary>
        [BindControlParameter("pwd", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("pwd", "Value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
        [DataField(FieldName = "pass", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        private bool? _superflag;//是否渠道经理

        /// <summary>
        /// 是否渠道经理
        /// </summary>
        [BindControlParameter("superflag", "checked", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("superflag", "checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
        [DataField(FieldName = "superflag", IsIdentity = false, IsKey = false, IsNullable = true)]
        public bool? superflag
        {
            get { return _superflag; }
            set { _superflag = value; }
        }

        private string _groupinfo_id;//分组编号

        /// <summary>
        /// 分组编号
        /// </summary>
        [BindControlParameter("groupinfo_id", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("groupinfo_id", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        [DataField(FieldName = "groupinfo_id", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string groupinfo_id
        {
            get { return _groupinfo_id; }
            set { _groupinfo_id = value; }
        }

        private string _siteid;//分店编号
        /// <summary>
        /// 分店编号
        /// </summary>
        [BindControlParameter("siteid", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("siteid", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        [DataField(FieldName = "siteid", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        private string _areaid;//代理商编号
        /// <summary>
        /// 代理商编号
        /// </summary>
        [BindControlParameter("areaid", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("areaid", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        [DataField(FieldName = "areaid", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string areaid
        {
            get { return _areaid; }
            set { _areaid = value; }
        }
        private string _Site_Code;//代理商编号
        /// <summary>
        /// 分店编号
        /// </summary> 
        [BindControlParameter("", "Text", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]

        public string Site_Code
        {
            get { return _Site_Code; }
            set { _Site_Code = value; }
        }
        private string _sort;//所属大类
        /// <summary>
        /// 所属大类
        /// </summary>
        [BindControlParameter("sort", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("sort", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        [DataField(FieldName = "sort", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        private bool? _validflag;//是否有效

        /// <summary>
        /// 是否有效
        /// </summary>
        [BindControlParameter("validflag", "checked", ParamUsage = BindParameterUsage.OpQuery)]
        [BindControlParameter("validflag", "checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
        [DataField(FieldName = "validflag", IsIdentity = false, IsKey = false, IsNullable = true)]
        public bool? validflag
        {
            get { return _validflag; }
            set { _validflag = value; }
        }

        private string _name;//员工姓名

        /// <summary>
        /// 员工姓名
        /// </summary>
        [BindControlParameter("name", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(FieldName = "name", IsIdentity = false, IsKey = false, IsNullable = true)]
        [SqlField(AfterLike = "%", BeforeLike = "%", QueryOperator = "like")]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _sexname;//性别

        /// <summary>
        /// 性别
        /// </summary>
        [BindControlParameter("sexname", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(FieldName = "sexname", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string sexname
        {
            get { return _sexname; }
            set { _sexname = value; }
        }
        private string _groupname;//组名称

        /// <summary>
        /// 组名称
        /// </summary>
        [BindControlParameter("groupname", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(FieldName = "groupname", IsIdentity = false, IsKey = false, IsNullable = true)]
        [SqlField(AfterLike = "%", BeforeLike = "%", QueryOperator = "like")]
        public string groupname
        {
            get { return _groupname; }
            set { _groupname = value; }
        }
        private string _access_time;
        /// <summary>
        /// //访问时间
        /// </summary>
        public string access_time
        {
            get { return _access_time; }
            set { _access_time = value; }
        }
        private string _access_ip;
        /// <summary>
        /// //_access_ip
        /// </summary>
        public string access_ip
        {
            get { return _access_ip; }
            set { _access_ip = value; }
        }
        private string _access_serverip;
        /// <summary>
        /// //_access_ip
        /// </summary>
        public string access_serverip
        {
            get { return _access_serverip; }
            set { _access_serverip = value; }
        }
        private string _roles;
        /// <summary>
        /// 角色
        /// </summary>
        [SqlField("=")]
        public string roles
        {
            get { return _roles; }
            set { _roles = value; }
        }
        //private bool? _chflag;
        ///// <summary>
        ///// 是否启用
        ///// </summary>
        //[BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        //[DataField("flag")]
        //public bool? chflag
        //{
        //    set { _chflag = value; }
        //    get { return _chflag; }
        //}
        //private bool? _flag;
        //public bool? flag
        //{
        //    set { _flag = value; }
        //    get { return _flag; }
        //}

        private string _sitename;
        /// <summary>
        /// 所在分店
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        private string _rolesName;
        /// <summary>
        /// 权限属性
        /// </summary>
        public string rolesName
        {
            get { return _rolesName; }
            set { _rolesName = value; }
        }

        private string _GroupNameseller;
        /// <summary>
        /// 所在组(针对销售人员)
        /// </summary>
        public string GroupNameseller
        {
            get { return _GroupNameseller; }
            set { _GroupNameseller = value; }
        }

        
    }
}
