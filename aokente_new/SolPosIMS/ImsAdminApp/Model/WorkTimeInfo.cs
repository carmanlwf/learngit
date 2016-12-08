using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// 工作时间设定
    /// </summary>
    [DbObject("pub_worktime", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pub_worktime", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    public class WorkTimeInfo
    {
        private string _WHATDAY;//星期号

        /// <summary>
        /// 星期号
        /// </summary>
        [DataField(FieldName = "WHATDAY", IsIdentity = false, IsKey = true, IsNullable = false)]
        public string WHATDAY
        {
            get { return _WHATDAY; }
            set { _WHATDAY = value; }
        }

        private string _WHATDAY_NANE;//星期名称

        /// <summary>
        /// 星期名称
        /// </summary>
        [DataField(FieldName = "WHATDAY_NAME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string WHATDAY_NAME
        {
            get { return _WHATDAY_NANE; }
            set { _WHATDAY_NANE = value; }
        }

        private string _AGENTSTART_TIME;//上班时间

        /// <summary>
        /// 上班时间
        /// </summary>
        [DataField(FieldName = "AGENTSTART_TIME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string AGENTSTART_TIME
        {
            get { return _AGENTSTART_TIME; }
            set { _AGENTSTART_TIME = value; }
        }

        private string _AGENTEND_TIME;//下班时间

        /// <summary>
        /// 下班时间
        /// </summary>
        [DataField(FieldName = "AGENTEND_TIME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string AGENTEND_TIME
        {
            get { return _AGENTEND_TIME; }
            set { _AGENTEND_TIME = value; }
        }

        private string _SERVICESTART_TIME;//服务开始时间

        /// <summary>
        /// 服务开始时间
        /// </summary>
        [DataField(FieldName = "SERVICESTART_TIME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string SERVICESTART_TIME
        {
            get { return _SERVICESTART_TIME; }
            set { _SERVICESTART_TIME = value; }
        }

        private string _SERVICEEND_TIME;//服务结束时间

        /// <summary>
        /// 服务结束时间
        /// </summary>
        [DataField(FieldName = "SERVICEEND_TIME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string SERVICEEND_TIME
        {
            get { return _SERVICEEND_TIME; }
            set { _SERVICEEND_TIME = value; }
        }
        private bool? _HAVE_AGENT;//是否有人值守

        /// <summary>
        /// 是否有人值守
        /// </summary>
        [DataField(FieldName = "HAVE_AGENT", IsIdentity = false, IsKey = false, IsNullable = true)]
        public bool? HAVE_AGENT
        {
            get { return _HAVE_AGENT; }
            set { _HAVE_AGENT = value; }
        }
        private bool? _TRANSFER_FLAG;//是否转接

        /// <summary>
        /// 是否转接
        /// </summary>
        [DataField(FieldName = "TRANSFER_FLAG", IsIdentity = false, IsKey = false, IsNullable = true)]
        public bool? TRANSFER_FLAG
        {
            get { return _TRANSFER_FLAG; }
            set { _TRANSFER_FLAG = value; }
        }
        private bool? _WORK_FLAG;//是否正常上班

        /// <summary>
        /// 是否正常上班
        /// </summary>
        [DataField(FieldName = "WORK_FLAG", IsIdentity = false, IsKey = false, IsNullable = true)]
        public bool? WORK_FLAG
        {
            get { return _WORK_FLAG; }
            set { _WORK_FLAG = value; }
        }
        private string _agentinfo_id;//维护人

        /// <summary>
        /// 维护人
        /// </summary>
        [DataField(FieldName = "agentinfo_id", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string agentinfo_id
        {
            get { return _agentinfo_id; }
            set { _agentinfo_id = value; }
        }
    }
}
