using System;
using System.Collections.Generic;
using System.Text;

using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;
using System.Web.Security;


namespace Ims.Site.Model
{
    /// <summary>
    /// 终端操作
    /// </summary>
    [DbObject("tb_Pos_Operator", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_pos_PosOperator", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_Pos_Operator
    {
        /// <summary>
        /// 操作员编号
        /// </summary>
        private string _operatorid;//操作员编号
        [DataField(IsKey = true)]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        private string _machineid;//站点编号
        /// <summary>
        /// 机器号
        /// </summary>
        public string machineid
        {
            get { return _machineid; }
            set { _machineid = value; }
        }


        /// <summary>
        /// POS机终端名字
        /// </summary>
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// 操作员登录员密码
        /// </summary>
        private string _pass;

        public string Pass
        {
            get { return _pass; }
            set { _pass = FormsAuthentication.HashPasswordForStoringInConfigFile(value, "MD5"); }
        }
      
        private string _cellphone;
        /// <summary>
        /// 操作员联系电话号码
        /// </summary>
        public string Cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        private string _memo;

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("flag")]
        private bool? _flag;
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 站点名称
        /// </summary>
        private string _sitename;
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        /// <summary>
        /// 登录日期
        /// </summary>
        string _adddate;

        public string adddate
        {
            get { return _adddate; }
            set { _adddate = value; }
        }

        string _adddate_begin;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "adddate")]
        [BindControlParameter("adddate_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string adddate_begin
        {
            get { return _adddate_begin; }
            set { _adddate_begin = value; }
        }

        string _operate_date_end;
        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "adddate")]
        [BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_end
        {
            get { return _operate_date_end; }
            set { _operate_date_end = value; }
        }
        /// <summary>
        ///   签到状态
        /// </summary>
        private string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 最后活跃时间
        /// </summary>
        private string _lastsigntime;
        public string lastsigntime
        {
            get { return _lastsigntime; }
            set { _lastsigntime = value; }
        }
        private string _last_siteid;
        /// <summary>
        /// 最后执勤路段的编号
        /// </summary>
        public string last_siteid
        {
            get { return _last_siteid; }
            set { _last_siteid = value; }
        }

        private string _last_sitename;
        /// <summary>
        /// 最后执勤路段的名称
        /// </summary>
        public string last_sitename
        {
            get { return _last_sitename; }
            set { _last_sitename = value; }
        }
        private string _last_possnr;
        /// <summary>
        /// 最后执勤所用的手持终端
        /// </summary>
        public string last_possnr
        {
            get { return _last_possnr; }
            set { _last_possnr = value; }
        }
        /// <summary>
        ///   是否登录
        /// </summary>
        private int? _islogin;
        public int? islogin
        {
            get { return _islogin; }
            set { _islogin = value; }
        }
        /// <summary>
        /// 是否脱岗
        /// </summary>
        private int? _isOutBounds;
        public int? isOutBounds
        {
            get { return _isOutBounds; }
            set { _isOutBounds = value; }
        }
        private bool? _IsCharge;
        /// <summary>
        /// 是否开通充值
        /// </summary>
        public bool? IsCharge
        {
            set { _IsCharge = value; }
            get { return _IsCharge; }
        }
        private bool? _cbIsCharge;
        /// <summary>
        /// 是否开通短信状态值
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("IsCharge")]
        public bool? cbIsCharge
        {
            set { _cbIsCharge = value; }
            get { return _cbIsCharge; }
        }
    }
}
