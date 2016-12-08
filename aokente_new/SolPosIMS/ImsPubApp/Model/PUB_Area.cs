using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Pub.Model
{
    /// <summary>
    /// 区域管理
    /// </summary>

    [DbObject("PUB_Area", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_product_ProductInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
   public  class PUB_Area
    {
        private string _areacode;//网站咨询序列号
        /// <summary>
        /// 区域代码(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [InitListControl("", "areacode", "areacode", "PUB_Area", "areacode")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string areacode
        {
            get { return _areacode; }
            set { _areacode = value; }
        }
        private string _areaname;
        /// <summary>
        /// 区域名
        /// </summary>
       [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string areaname
        {
            get { return _areaname; }
            set { _areaname = value; }
        }
        private string _linkman;
        /// <summary>
        /// 负责人
        /// </summary>
        public string linkman
        {
            get { return _linkman; }
            set { _linkman = value; }
        }
        private string _linkphone;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string linkphone
        {
            get { return _linkphone; }
            set { _linkphone = value; }
        }
        //以下查询用
        
        private string _regtime1;
       
        private string _regtime2;

        [DataField("regtime", OnlyQuery = true)]
        [SqlField("<=")]
        /// <summary>
        /// 终止时间
        /// </summary>
        public string regtime2
        {
            get { return _regtime2; }
            set { _regtime2 = value; }
        }

        [DataField("regtime", OnlyQuery = true)]
        [SqlField(">=")]
        /// <summary>
        /// 起始时间
        /// </summary>
        public string regtime1
        {
            get { return _regtime1; }
            set { _regtime1 = value; }
        }
        private string _regtime;//注册时间
        /// <summary>
        /// 注册时间
        /// </summary>
        public string regtime
        {
            get { return _regtime; }
            set { _regtime = value; }
        }
        private string _memo;//备注
        /// <summary>
        /// 备注
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private bool? _chflag;
        /// <summary>
        /// 是否启用
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("flag")]
        public bool? chflag
        {
            set { _chflag = value; }
            get { return _chflag; }
        }
        private bool? _flag;

        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
    }
}
