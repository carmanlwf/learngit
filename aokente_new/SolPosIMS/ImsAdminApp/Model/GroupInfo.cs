using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// ��������Ϣ��ͼʵ��
    /// </summary>
    [DbObject("v_pub_groupinfo", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    public class GroupInfo
    {
        private string _id;//���

        /// <summary>
        /// ���
        /// </summary>
        [DataField(FieldName = "id", IsIdentity = false, IsKey = true, IsNullable = false)]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _groupname;//����

        /// <summary>
        /// ����
        /// </summary>
        [DataField(FieldName = "groupname", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string groupname
        {
            get { return _groupname; }
            set { _groupname = value; }
        }
        
        private string _typecode;//���������ʹ���

        /// <summary>
        /// ���������ʹ���
        /// </summary>
        [DataField(FieldName = "typecode", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string typecode
        {
            get { return _typecode; }
            set { _typecode = value; }
        }
        private string _typecodename;//����������

        /// <summary>
        /// ����������
        /// </summary>
        [DataField(FieldName = "typecodename", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string typecodename
        {
            get { return _typecodename; }
            set { _typecodename = value; }
        }

        private string _levelcode;//����������

        /// <summary>
        /// ����������
        /// </summary>
        [DataField(FieldName = "levelcode", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string levelcode
        {
            get { return _levelcode; }
            set { _levelcode = value; }
        }

        private string _levelcodename;//����������

        /// <summary>
        /// ����������
        /// </summary>
        [DataField(FieldName = "levelcodename", IsIdentity = false, IsKey = false, IsNullable = false)]
        public string levelcodename
        {
            get { return _levelcodename; }
            set { _levelcodename = value; }
        }

        private bool? _validflag;//��Ч��־

        /// <summary>
        /// ��Ч��־
        /// </summary>
        [DataField(FieldName = "validflag", IsIdentity = false, IsKey = false, IsNullable = false)]
        public bool? validflag
        {
            get { return _validflag; }
            set { _validflag = value; }
        }
    }
}
