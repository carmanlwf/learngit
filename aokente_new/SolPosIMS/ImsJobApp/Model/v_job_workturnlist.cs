using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;
namespace Ims.Job.Model
{
    [DbObject("v_pay_paydetail", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_job_workturnlist
    {
        private string _turnid;
        /// <summary>
        /// 交班id
        /// </summary>
        public string turnid
        {
            get { return _turnid; }
            set { _turnid = value; }
        }
        private string _operatorid;
        /// <summary>
        /// 上一操作员
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        private decimal? _totalmoney;
        /// <summary>
        /// 累计营收金额
        /// </summary>
        public decimal? totalmoney
        {
            get { return _totalmoney; }
            set { _totalmoney = value; }
        }
        private decimal? _totalpledgecash;
        /// <summary>
        /// 累计预缴押金金额
        /// </summary>
        public decimal? totalpledgecash
        {
            get { return _totalpledgecash; }
            set { _totalpledgecash = value; }
        }
        private string _starttime;
        /// <summary>
        /// 上班时间
        /// </summary>
        public string starttime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }
        private string _endtime;
        /// <summary>
        /// 下班时间
        /// </summary>
        public string endtime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }
        private string _logtime;
        /// <summary>
        /// 记录时间
        /// </summary>
        public string logtime
        {
            get { return _logtime; }
            set { _logtime = value; }
        }
        private string _siteid;
        /// <summary>
        /// 路段编号
        /// </summary>
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        private string _sitename;
        /// <summary>
        /// 路段名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        private string _nextoperator;
        /// <summary>
        /// 下一操作员
        /// </summary>
        public string nextoperator
        {
            get { return _nextoperator; }
            set { _nextoperator = value; }
        }
        private int? _status;
        /// <summary>
        /// 下一操作员
        /// </summary>
        public int? status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _statusname;
        /// <summary>
        /// 状态名称
        /// </summary>
        public string statusname
        {
            get { return _statusname; }
            set { _statusname = value; }
        }
        private bool? _flag;
        /// <summary>
        /// 启用标识
        /// </summary>
        public bool? flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        private string _tradetime_begin;
        /// <summary>
        /// 交易时间(开始)
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "endtime")]
        [BindControlParameter("endtime_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string tradetime_begin
        {
            get { return _tradetime_begin; }
            set { _tradetime_begin = value; }
        }
        private string _tradetime_end;
        /// <summary>
        /// 交易时间(结束)
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "endtime")]
        [BindControlParameter("endtime_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string tradetime_end
        {
            get { return _tradetime_end; }
            set { _tradetime_end = value; }
        }
    }
}
