using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// ����������ʵ����
    /// </summary>
    [DbObject("pub_orgshortinfo", ObjType = DbObjectAttribute.ObjectType.Table, IsCanQueryAll = true)]
    public class OrgshortInfo
    {
        private string orgcode;//��������

        /// <summary>
        /// ��������
        /// </summary>
        [DataField(FieldName = "orgcode", IsIdentity = false, IsKey = true, IsNullable = false)]
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
        private string agentinfo_id;//ά����

        /// <summary>
        /// ά����
        /// </summary>
        [DataField(FieldName = "agentinfo_id")]
        public string Agentinfo_id
        {
            get { return agentinfo_id; }
            set { agentinfo_id = value; }
        }
    }
}
