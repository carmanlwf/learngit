using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// 技能组信息视图实体
    /// </summary>
    [DbObject("v_pub_groupinfo", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    public class GroupInfo
    {
        private string _id;//组号

        /// <summary>
        /// 组号
        /// </summary>
        [DataField(FieldName = "id", IsIdentity = false, IsKey = true, IsNullable = false)]
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
        public string typecode
        {
            get { return _typecode; }
            set { _typecode = value; }
        }
        private string _typecodename;//技能组类型

        /// <summary>
        /// 技能组类型
        /// </summary>
        [DataField(FieldName = "typecodename", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string typecodename
        {
            get { return _typecodename; }
            set { _typecodename = value; }
        }

        private string _levelcode;//技能组类型

        /// <summary>
        /// 技能组类型
        /// </summary>
        [DataField(FieldName = "levelcode", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string levelcode
        {
            get { return _levelcode; }
            set { _levelcode = value; }
        }

        private string _levelcodename;//技能组资质

        /// <summary>
        /// 技能组资质
        /// </summary>
        [DataField(FieldName = "levelcodename", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string levelcodename
        {
            get { return _levelcodename; }
            set { _levelcodename = value; }
        }

        private bool? _validflag;//有效标志

        /// <summary>
        /// 有效标志
        /// </summary>
        [DataField(FieldName = "validflag", IsIdentity = false, IsKey = false, IsNullable = false)]
        public bool? validflag
        {
            get { return _validflag; }
            set { _validflag = value; }
        }
    }
}
