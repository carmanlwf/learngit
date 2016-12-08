using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Pub.Model
{
    /// <summary>
    /// 报表
    /// </summary>

    [DbObject("Rpt_List", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
     public class Rpt_List
    {
        private string _Rptid;
        /// <summary>
        /// 编号
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [InitListControl("", "Rptid", "Rptid", "Rpt_List", "Rptid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Rptid
        {
            get { return _Rptid; }
            set { _Rptid = value; }
        }
        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _PageName;
        /// <summary>
        /// 页面名称
        /// </summary>
        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
        }
        private string _type;
        /// <summary>
        /// 模板类别
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _template;
        /// <summary>
        /// 模板名称
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string template
        {
            get { return _template; }
            set { _template = value; }
        }
      

        private bool? _IsUseTemplate;
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsUseTemplate
        {
            set { _IsUseTemplate = value; }
            get { return _IsUseTemplate; }
        }

        private string _description;
        /// <summary>
        /// 描述
        /// </summary>
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _authority;
        /// <summary>
        /// 权限
        /// </summary>
        [SqlField("in")]
        public string authority
        {
            get { return _authority; }
            set { _authority = value; }
        }
        //以下查询用

        private string _addeddate1;

        private string _addeddate2;

        [DataField("addeddate", OnlyQuery = true)]
        [SqlField("<=")]
        /// <summary>
        /// 终止时间
        /// </summary>
        public string addeddate2
        {
            get { return _addeddate2; }
            set { _addeddate2 = value; }
        }

        [DataField("addeddate", OnlyQuery = true)]
        [SqlField(">=")]
        /// <summary>
        /// 起始时间
        /// </summary>
        public string addeddate1
        {
            get { return _addeddate1; }
            set { _addeddate1 = value; }
        }
        private string _addeddate;//注册时间
        /// <summary>
        /// 注册时间
        /// </summary>
        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }
        private int? _sortid;
        /// <summary>
        /// 排序id
        /// </summary>
        public int? sortid
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        private bool? _flag;

        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
    }
}
