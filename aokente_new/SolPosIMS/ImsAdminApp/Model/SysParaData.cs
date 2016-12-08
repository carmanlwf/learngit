using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Admin.Model
{
    /// <summary>
    /// ϵͳ������Ϣ
    /// </summary>
    [DbObject("pub_syspara", ObjType = DbObjectAttribute.ObjectType.Table, IsCanQueryAll = true)]
    [Serializable()]
    public class SysParaData
    {
        private string _id;//����������

        /// <summary>
        /// ����������
        /// </summary>
        [DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _PARA_CATCODE;//����������

        /// <summary>
        /// ����������
        /// </summary>
        [DataField(FieldName = "PARA_CATCODE")]
        public string PARA_CATCODE
        {
            get { return _PARA_CATCODE; }
            set { _PARA_CATCODE = value; }
        }
        private string _PARA_CATNAME;//�����������

        /// <summary>
        /// �����������
        /// </summary>
        [DataField(FieldName = "PARA_CATNAME")]
        public string PARA_CATNAME
        {
            get { return _PARA_CATNAME; }
            set { _PARA_CATNAME = value; }
        }
        private string _PARA_ID;//����С�����

        /// <summary>
        /// ����С�����
        /// </summary>
        [DataField(FieldName = "PARA_ID")]
        public string PARA_ID
        {
            get { return _PARA_ID; }
            set { _PARA_ID = value; }
        }
        private string _PARA_IDNAME;//����С������

        /// <summary>
        /// ����С������
        /// </summary>
        [DataField(FieldName = "PARA_IDNAME")]
        public string PARA_IDNAME
        {
            get { return _PARA_IDNAME; }
            set { _PARA_IDNAME = value; }
        }
        private string _AGENT_ID;//���ά����

        /// <summary>
        /// ���ά����
        /// </summary>
        [DataField(FieldName = "AGENT_ID")]
        public string AGENT_ID
        {
            get { return _AGENT_ID; }
            set { _AGENT_ID = value; }
        }
        private string _REFRESH_DATE;//���ά��ʱ��

        /// <summary>
        /// ���ά��ʱ��
        /// </summary>
        [DataField(FieldName = "REFRESH_DATE")]
        public string REFRESH_DATE
        {
            get { return _REFRESH_DATE; }
            set { _REFRESH_DATE = value; }
        }
        private bool? _VALID_FLAG;//�Ƿ���Ч

        /// <summary>
        /// �Ƿ���Ч
        /// </summary>
        [DataField(FieldName = "VALID_FLAG")]
        public bool? VALID_FLAG
        {
            get { return _VALID_FLAG; }
            set { _VALID_FLAG = value; }
        }
    }
}
