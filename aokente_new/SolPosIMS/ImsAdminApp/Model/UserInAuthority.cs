using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// 用户权限对照表
    /// </summary>
    [DbObject("pub_userinauthority", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pub_userinauthority", ObjType = DbObjectAttribute.ObjectType.Table)]
    public class UserInAuthority
    {
        private int? _id;//id

        /// <summary>
        /// Id
        /// </summary>
        [DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = true)]
        public int? id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _agent_id;//员工工号

        /// <summary>
        /// 员工工号
        /// </summary>
        [BindControlParameter("agent_id", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(FieldName = "agent_id", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string agent_id
        {
            get { return _agent_id; }
            set { _agent_id = value; }
        }
        private string _rolecode;//角色编码

        /// <summary>
        /// 角色编码
        /// </summary>
        [BindControlParameter("rolecode", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(FieldName = "rolecode", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string rolecode
        {
            get { return _rolecode; }
            set { _rolecode = value; }
        }
        private string _syscode;//系统编码

        /// <summary>
        /// 系统编码
        /// </summary>
        [BindControlParameter("syscode", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(FieldName = "syscode", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string syscode
        {
            get { return _syscode; }
            set { _syscode = value; }
        }
        private string _authoritycode;//权限编码

        /// <summary>
        /// 权限编码
        /// </summary>
        [BindControlParameter("authoritycode", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(FieldName = "authoritycode", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string authoritycode
        {
            get { return _authoritycode; }
            set { _authoritycode = value; }
        }
        private string _authority_name;//权限名称

        /// <summary>
        /// 权限名称
        /// </summary>
        [DataField(FieldName = "authority_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string authority_name
        {
            get { return _authority_name; }
            set { _authority_name = value; }
        }
        private string _role_name;//角色名称

        /// <summary>
        /// 角色名称
        /// </summary>
        [DataField(FieldName = "role_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string role_name
        {
            get { return _role_name; }
            set { _role_name = value; }
        }
        private string _sys_name;//系统名称

        /// <summary>
        /// 系统名称
        /// </summary>
        [DataField(FieldName = "sys_name", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string sys_name
        {
            get { return _sys_name; }
            set { _sys_name = value; }
        }
    }
}
