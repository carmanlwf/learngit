using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Pub.Model
{
    /// <summary>
    /// 分店信息
    /// </summary>
    [DbObject("PUB_Site", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pub_Site", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class PUB_Site
    {
        private string _siteid;//网站咨询序列号
        /// <summary>
        /// 网站咨询序列号(必填)
        /// </summary>
        //[DataField(FieldName = "siteid", Issiteidentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [InitListControl("", "siteid", "siteid", "PUB_Site", "siteid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        //private string _machinesiteid;//机器号
        ///// <summary>
        ///// 机器号
        ///// </summary>
        //public string machinesiteid
        //{
        //    get { return _machinesiteid; }
        //    set { _machinesiteid = value; }
        //}
        /// <summary>
        /// 站点名称
        /// </summary>
        private string _sitename;//站点名称
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        private string _operatorsiteid;//操作员siteid
        /// <summary>
        /// 操作员siteid
        /// </summary>
        //[BindControlParameter("querycustomername", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operatorsiteid
        {
            get { return _operatorsiteid; }
            set { _operatorsiteid = value; }
        }
        private string _areacode;//区域代码
        /// <summary>
        /// 区域代码
        /// </summary>
        public string areacode
        {
            get { return _areacode; }
            set { _areacode = value; }
        }
        private string _areaname;//区域代码
        /// <summary>
        /// 区域名称
        /// </summary>
        public string areaname
        {
            get { return _areaname; }
            set { _areaname = value; }
        }
        private string _pass;//密码
        /// <summary>
        /// 密码
        /// </summary>
        public string pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        private string _linkman;//联系人
        /// <summary>
        /// 联系人
        /// </summary>
        public string linkman
        {
            get { return _linkman; }
            set { _linkman = value; }
        }

        private string _linkphone;//联系电话
        /// <summary>
        /// 联系电话
        /// </summary>
        public string linkphone
        {
            get { return _linkphone; }
            set { _linkphone = value; }
        }

        //private double? _balance;//金额
        ///// <summary>
        ///// 金额
        ///// </summary>
        //public double? balance
        //{
        //    get { return _balance; }
        //    set { _balance = value; }
        //}
        //以下查询用
        private string _regtime1;
        private string _regtime2;

        [DataField("regtime", OnlyQuery = true)]
        [SqlField("<=")]
        public string regtime2
        {
            get { return _regtime2; }
            set { _regtime2 = value; }
        }

        [DataField("regtime", OnlyQuery = true)]
        [SqlField(">=")]
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
        private string _note;//备注
        /// <summary>
        /// 备注
        /// </summary>
        public string note
        {
            get { return _note; }
            set { _note = value; }
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
        private string _Category;//品牌
        /// <summary>
        /// 品牌 
        /// </summary>
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        ///// <summary>
        ///// 最后活跃时间
        ///// </summary>
        //private string _lastActiveTime;
        //public string lastActiveTime
        //{
        //    get { return _lastActiveTime; }
        //    set { _lastActiveTime = value; }
        //}
    }
}
