using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Admin.Model
{
        /// <summary>
        /// 技能组信息实体
        /// </summary>
        [DbObject("pub_groupinfo", ObjType = DbObjectAttribute.ObjectType.Table, IsCanQueryAll = true)]
        public class GroupData
        {
            private string _id;//组号

            /// <summary>
            /// 组号
            /// </summary>
            [DataField(FieldName = "id", IsIdentity = false, IsKey = true, IsNullable = false)]
            [BindControlParameter("groupid", "Value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
            public string id
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _groupname;//组名

            /// <summary>
            /// 组名
            /// </summary>
            [DataField(FieldName = "groupname", IsIdentity = false, IsKey = false, IsNullable = false)]
            [BindControlParameter("groupname", "Value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
            public string groupname
            {
                get { return _groupname; }
                set { _groupname = value; }
            }
            private string _typecode;//技能组类型代码

            /// <summary>
            /// 技能组类型代码
            /// </summary>
            [DataField(FieldName = "typecode", IsIdentity = false, IsKey = false, IsNullable = false)]
            [BindControlParameter("typecode", "Value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
            public string typecode
            {
                get { return _typecode; }
                set { _typecode = value; }
            }
            private string _levelcode;//技能组资质代码

            /// <summary>
            /// 技能组资质代码
            /// </summary>
            [DataField(FieldName = "levelcode", IsIdentity = false, IsKey = false, IsNullable = false)]
            [BindControlParameter("levelcode", "Value", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
            public string levelcode
            {
                get { return _levelcode; }
                set { _levelcode = value; }
            }
            private bool? _validflag;//有效标志

            /// <summary>
            /// 有效标志
            /// </summary>
            [DataField(FieldName = "validflag", DefaultValue = true, IsIdentity = false, IsKey = false, IsNullable = false)]
            [BindControlParameter("validflag", "checked", DefaultValue = true, ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate)]
            public bool? validflag
            {
                get { return _validflag; }
                set { _validflag = value; }
            }
        }
    }
