using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Admin.Model
{
    /// <summary>
    /// 用户角色对照表
    /// </summary>
    [DbObject("pub_userinrole", ObjType = DbObjectAttribute.ObjectType.Table)]
    public class UserInRole
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
    }
}
