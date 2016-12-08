using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
using System.Web.Security;

namespace Ims.Site.Model
{
    /// <summary>
    /// 终端操作
    /// </summary>
    [DbObject("v_tb_Pos_Operator", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_tb_Pos_Operator
    {
        /// <summary>
        /// 操作员编号
        /// </summary>
        private string operatorid;//操作员编号
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey | BindParameterUsage.OpUpdate | BindParameterUsage.OpInsert| BindParameterUsage.BindToObjectAndParameter)]
        public string Operatorid
        {
            get { return operatorid; }
            set { operatorid = value; }
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
    }
}

