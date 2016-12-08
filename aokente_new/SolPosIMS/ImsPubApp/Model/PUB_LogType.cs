using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Pub.Model
{
    /// <summary>
    /// 日志类型
    /// </summary>
    [DbObject("PUB_LogType", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_product_ProductInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public  class PUB_LogType
    {
        private string _typeid;//网站咨询序列号
        /// <summary>
        /// 类型ID
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [InitListControl("", "typeid", "typeid", "PUB_LogType", "typeid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string typeid
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        private string _typeName;
        /// <summary>
        /// 类型名
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string typeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        private string _memo;
        /// <summary>
        /// 备注
        /// </summary>
     
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private string _Addtime;
        /// <summary>
        /// 负责人
        /// </summary>
        public string Addtime
        {
            get { return _Addtime; }
            set { _Addtime = value; }
        }
        private bool? _flag;
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
    }
}
