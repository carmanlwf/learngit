using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// ��֯������д��Ϣ
    /// </summary>
    [DbObject("v_pub_manageshort", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    public class ManageComInfo
    {
        private string orgcode;//��������

        /// <summary>
        /// ��������
        /// </summary>
        [DataField(FieldName = "orgcode", IsIdentity = false, IsKey = true, IsNullable = false)]
        [SqlField(QueryOperator = "like",AfterLike="%")]
        public string OrgCode
        {
            get { return orgcode; }
            set { orgcode = value; }
        }
        private string areacode;//����

        /// <summary>
        /// ����
        /// </summary>
        [DataField(FieldName = "areacode")]
        public string AreaCode
        {
            get { return areacode; }
            set { areacode = value; }
        }
        private string shortname;//���

        /// <summary>
        /// ���
        /// </summary>
        [DataField(FieldName = "shortname")]
        public string ShortName
        {
            get { return shortname; }
            set { shortname = value; }
        }
        private string NAME;//ȫ��

        /// <summary>
        /// ȫ��
        /// </summary>
        [DataField(FieldName = "NAME")]
        public string Name
        {
            get { return NAME; }
            set { NAME = value; }
        }
    }
}
