using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Admin.Model
{
    /// <summary>
    /// 组织机构缩写信息
    /// </summary>
    [DbObject("v_pub_manageshort", ObjType = DbObjectAttribute.ObjectType.View, IsCanQueryAll = true)]
    public class ManageComInfo
    {
        private string orgcode;//机构代码

        /// <summary>
        /// 机构代码
        /// </summary>
        [DataField(FieldName = "orgcode", IsIdentity = false, IsKey = true, IsNullable = false)]
        [SqlField(QueryOperator = "like",AfterLike="%")]
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
        private string NAME;//全称

        /// <summary>
        /// 全称
        /// </summary>
        [DataField(FieldName = "NAME")]
        public string Name
        {
            get { return NAME; }
            set { NAME = value; }
        }
    }
}
