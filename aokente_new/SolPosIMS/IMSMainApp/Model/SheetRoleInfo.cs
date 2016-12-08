using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Main.Model
{
    /// <summary>
    /// 处理岗信息,品质协调员信息
    /// </summary>
    [DbObject("pub_sheetrole", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pub_sheetrole", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    //[DbObject("v_pub_qualitymanage", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    public class SheetRoleInfo
    {
        private string _id;//处理岗Id

        /// <summary>
        /// 处理岗Id
        /// </summary>
        [BindControlParameter("roleid", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        [DataField(FieldName = "id", IsIdentity = false, IsKey = true, IsNullable = false)]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _stationcode;

        /// <summary>
        /// 岗位类型
        /// </summary>
        [DataField(FieldName = "stationcode", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("stationcode", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string stationcode
        {
            get { return _stationcode; }
            set { _stationcode = value; }
        }
        private string _pwd;

        /// <summary>
        /// 密码
        /// </summary>
        [DataField(FieldName = "pwd", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("pwd", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        private string _email;

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataField(FieldName = "email", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("email", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _name;

        /// <summary>
        /// 岗位名称
        /// </summary>
        [DataField(FieldName = "name", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("name", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _tel;

        /// <summary>
        /// 电话
        /// </summary>
        [DataField(FieldName = "tel", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("tel", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        private string _type;

        /// <summary>
        /// 处理岗类型
        /// </summary>
        [DataField(FieldName = "type", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("type", "Value", ParamUsage = BindParameterUsage.OpInsert)]
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _new_managecom;

        /// <summary>
        /// 所属管理机构代码
        /// </summary>
        [DataField(FieldName = "new_managecom", IsIdentity = false, IsKey = false, IsNullable = true)]
        [SqlField(AfterLike = "%", QueryOperator = "like")]
        public string new_managecom
        {
            get { return _new_managecom; }
            set { _new_managecom = value; }
        }
        private string _role_type;
        /// <summary>
        /// 转办tm 回访转办ob
        /// </summary>
        /// 
        [DataField(FieldName = "role_type", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string role_type
        {
            set { _role_type = value; }
            get { return _role_type; }
        }
        private bool? _validflag;

        /// <summary>
        /// 是否有效
        /// </summary>
        [DataField(FieldName = "validflag", IsIdentity = false, IsKey = false, IsNullable = true)]
        [BindControlParameter("validflag", "Checked", ParamUsage = BindParameterUsage.OpInsert)]
        public bool? validflag
        {
            get { return _validflag; }
            set { _validflag = value; }
        }
        private string _type_name;
        /// <summary>
        /// 处理岗类型名称
        /// </summary>
        [DataField(FieldName = "type_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string type_name
        {
            get { return _type_name; }
            set { _type_name = value; }
        }

        private string _station_name;
        /// <summary>
        /// 岗位类型名称
        /// </summary>
        [DataField(FieldName = "station_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string station_name
        {
            get { return _station_name; }
            set { _station_name = value; }
        }
        private string _branch_name;
        /// <summary>
        /// 分公司
        /// </summary>
        [DataField(FieldName = "branch_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string branch_name
        {
            get { return _branch_name; }
            set { _branch_name = value; }
        }
        private string _dept_name;
        /// <summary>
        /// 中支
        /// </summary>
        [DataField(FieldName = "dept_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string dept_name
        {
            get { return _dept_name; }
            set { _dept_name = value; }
        }

        private string _channel_name;
        /// <summary>
        /// 岗位渠道类型(品质协调员)
        /// </summary>
        [DataField(FieldName = "channel_name")]
        public string channel_name
        {
            get { return _channel_name; }
            set { _channel_name = value; }
        }

        private string _wheresql;
        /// <summary>
        /// 是否是Where条件的SQL
        /// </summary>
        [SqlField(IsWhereSql = true)]
        public string wheresql
        {
            get { return _wheresql; }
            set { _wheresql = value; }
        }
    }
}
