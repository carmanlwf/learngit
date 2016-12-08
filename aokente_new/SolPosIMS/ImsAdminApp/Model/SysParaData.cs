using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Admin.Model
{
    /// <summary>
    /// 系统参数信息
    /// </summary>
    [DbObject("pub_syspara", ObjType = DbObjectAttribute.ObjectType.Table, IsCanQueryAll = true)]
    [Serializable()]
    public class SysParaData
    {
        private string _id;//参数类别代码

        /// <summary>
        /// 参数类别代码
        /// </summary>
        [DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _PARA_CATCODE;//参数类别代码

        /// <summary>
        /// 参数类别代码
        /// </summary>
        [DataField(FieldName = "PARA_CATCODE")]
        public string PARA_CATCODE
        {
            get { return _PARA_CATCODE; }
            set { _PARA_CATCODE = value; }
        }
        private string _PARA_CATNAME;//参数类别名称

        /// <summary>
        /// 参数类别名称
        /// </summary>
        [DataField(FieldName = "PARA_CATNAME")]
        public string PARA_CATNAME
        {
            get { return _PARA_CATNAME; }
            set { _PARA_CATNAME = value; }
        }
        private string _PARA_ID;//参数小类代码

        /// <summary>
        /// 参数小类代码
        /// </summary>
        [DataField(FieldName = "PARA_ID")]
        public string PARA_ID
        {
            get { return _PARA_ID; }
            set { _PARA_ID = value; }
        }
        private string _PARA_IDNAME;//参数小类名称

        /// <summary>
        /// 参数小类名称
        /// </summary>
        [DataField(FieldName = "PARA_IDNAME")]
        public string PARA_IDNAME
        {
            get { return _PARA_IDNAME; }
            set { _PARA_IDNAME = value; }
        }
        private string _AGENT_ID;//最近维护人

        /// <summary>
        /// 最近维护人
        /// </summary>
        [DataField(FieldName = "AGENT_ID")]
        public string AGENT_ID
        {
            get { return _AGENT_ID; }
            set { _AGENT_ID = value; }
        }
        private string _REFRESH_DATE;//最近维护时间

        /// <summary>
        /// 最近维护时间
        /// </summary>
        [DataField(FieldName = "REFRESH_DATE")]
        public string REFRESH_DATE
        {
            get { return _REFRESH_DATE; }
            set { _REFRESH_DATE = value; }
        }
        private bool? _VALID_FLAG;//是否有效

        /// <summary>
        /// 是否有效
        /// </summary>
        [DataField(FieldName = "VALID_FLAG")]
        public bool? VALID_FLAG
        {
            get { return _VALID_FLAG; }
            set { _VALID_FLAG = value; }
        }
    }
}
