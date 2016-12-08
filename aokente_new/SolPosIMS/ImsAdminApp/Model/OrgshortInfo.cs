using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// 管理机构简称实体类
    /// </summary>
    [DbObject("pub_orgshortinfo", ObjType = DbObjectAttribute.ObjectType.Table, IsCanQueryAll = true)]
    public class OrgshortInfo
    {
        private string orgcode;//机构代码

        /// <summary>
        /// 机构代码
        /// </summary>
        [DataField(FieldName = "orgcode", IsIdentity = false, IsKey = true, IsNullable = false)]
        public string OrgCode
        {
            get { return orgcode; }
            set { orgcode = value; }
        }
        private string areacode;//区号

        /// <summary>
        /// 区号
        /// </summary>
        [DataField(FieldName = "areacode")]
        public string AreaCode
        {
            get { return areacode; }
            set { areacode = value; }
        }
        private string shortname;//简称

        /// <summary>
        /// 简称
        /// </summary>
        [DataField(FieldName = "shortname")]
        public string ShortName
        {
            get { return shortname; }
            set { shortname = value; }
        }
        private string agentinfo_id;//维护人

        /// <summary>
        /// 维护人
        /// </summary>
        [DataField(FieldName = "agentinfo_id")]
        public string Agentinfo_id
        {
            get { return agentinfo_id; }
            set { agentinfo_id = value; }
        }
    }
}
