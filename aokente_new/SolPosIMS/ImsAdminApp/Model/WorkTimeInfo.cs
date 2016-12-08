using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// ����ʱ���趨
    /// </summary>
    [DbObject("pub_worktime", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pub_worktime", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    public class WorkTimeInfo
    {
        private string _WHATDAY;//���ں�

        /// <summary>
        /// ���ں�
        /// </summary>
        [DataField(FieldName = "WHATDAY", IsIdentity = false, IsKey = true, IsNullable = false)]
        public string WHATDAY
        {
            get { return _WHATDAY; }
            set { _WHATDAY = value; }
        }

        private string _WHATDAY_NANE;//��������

        /// <summary>
        /// ��������
        /// </summary>
        [DataField(FieldName = "WHATDAY_NAME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string WHATDAY_NAME
        {
            get { return _WHATDAY_NANE; }
            set { _WHATDAY_NANE = value; }
        }

        private string _AGENTSTART_TIME;//�ϰ�ʱ��

        /// <summary>
        /// �ϰ�ʱ��
        /// </summary>
        [DataField(FieldName = "AGENTSTART_TIME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string AGENTSTART_TIME
        {
            get { return _AGENTSTART_TIME; }
            set { _AGENTSTART_TIME = value; }
        }

        private string _AGENTEND_TIME;//�°�ʱ��

        /// <summary>
        /// �°�ʱ��
        /// </summary>
        [DataField(FieldName = "AGENTEND_TIME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string AGENTEND_TIME
        {
            get { return _AGENTEND_TIME; }
            set { _AGENTEND_TIME = value; }
        }

        private string _SERVICESTART_TIME;//����ʼʱ��

        /// <summary>
        /// ����ʼʱ��
        /// </summary>
        [DataField(FieldName = "SERVICESTART_TIME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string SERVICESTART_TIME
        {
            get { return _SERVICESTART_TIME; }
            set { _SERVICESTART_TIME = value; }
        }

        private string _SERVICEEND_TIME;//�������ʱ��

        /// <summary>
        /// �������ʱ��
        /// </summary>
        [DataField(FieldName = "SERVICEEND_TIME", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string SERVICEEND_TIME
        {
            get { return _SERVICEEND_TIME; }
            set { _SERVICEEND_TIME = value; }
        }
        private bool? _HAVE_AGENT;//�Ƿ�����ֵ��

        /// <summary>
        /// �Ƿ�����ֵ��
        /// </summary>
        [DataField(FieldName = "HAVE_AGENT", IsIdentity = false, IsKey = false, IsNullable = true)]
        public bool? HAVE_AGENT
        {
            get { return _HAVE_AGENT; }
            set { _HAVE_AGENT = value; }
        }
        private bool? _TRANSFER_FLAG;//�Ƿ�ת��

        /// <summary>
        /// �Ƿ�ת��
        /// </summary>
        [DataField(FieldName = "TRANSFER_FLAG", IsIdentity = false, IsKey = false, IsNullable = true)]
        public bool? TRANSFER_FLAG
        {
            get { return _TRANSFER_FLAG; }
            set { _TRANSFER_FLAG = value; }
        }
        private bool? _WORK_FLAG;//�Ƿ������ϰ�

        /// <summary>
        /// �Ƿ������ϰ�
        /// </summary>
        [DataField(FieldName = "WORK_FLAG", IsIdentity = false, IsKey = false, IsNullable = true)]
        public bool? WORK_FLAG
        {
            get { return _WORK_FLAG; }
            set { _WORK_FLAG = value; }
        }
        private string _agentinfo_id;//ά����

        /// <summary>
        /// ά����
        /// </summary>
        [DataField(FieldName = "agentinfo_id", IsIdentity = false, IsKey = false, IsNullable = true)]
        public string agentinfo_id
        {
            get { return _agentinfo_id; }
            set { _agentinfo_id = value; }
        }
    }
}
