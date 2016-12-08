using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Pay
{
    [DbObject("v_pay_paydetail", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_pay_paydetail
    {
        private string _payid;
        /// <summary>
        /// 支付流水号
        /// </summary>
        public string payid
        {
            get { return _payid; }
            set { _payid = value; }
        }
        private string _businessid;
        /// <summary>
        /// 支付流水号
        /// </summary>
        public string businessid
        {
            get { return _businessid; }
            set { _businessid = value; }
        }
        private string _carnum;
        /// <summary>
        /// 车牌号
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string carnum
        {
            get { return _carnum; }
            set { _carnum = value; }
        }
        private decimal? _amount;
        /// <summary>
        /// 交易发生金额
        /// </summary>
        public decimal? amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private string _tradetime;
        /// <summary>
        /// 交易时间
        /// </summary>
        public string tradetime
        {
            get { return _tradetime; }
            set { _tradetime = value; }
        }
        private int? _tradetype;
        /// <summary>
        /// 交易类型(0:未知类型 1:停车消费 2:在线充值 3:欠费补缴 4:积分兑换 5:活动赠送)
        /// </summary>
        public int? tradetype
        {
            get { return _tradetype; }
            set { _tradetype = value; }
        }
        private string _tradetypename;
        /// <summary>
        /// 交易类型(中文)
        /// </summary>
        public string tradetypename
        {
            get { return _tradetypename; }
            set { _tradetypename = value; }
        }
        private int? _tradeway;
        /// <summary>
        /// 交易来源(0:未知来源 1:系统平台 2:手持终端 3:手机客户端)
        /// </summary>
        public int? tradeway
        {
            get { return _tradeway; }
            set { _tradeway = value; }
        }
        private string _tradewayname;
        /// <summary>
        /// 交易来源(中文)
        /// </summary>
        public string tradewayname
        {
            get { return _tradewayname; }
            set { _tradewayname = value; }
        }
        private string _tradecomment;
        /// <summary>
        /// 详情
        /// </summary>
        public string tradecomment
        {
            get { return _tradecomment; }
            set { _tradecomment = value; }
        }
        private decimal? _beforemoney;
        /// <summary>
        /// 交易之前金额
        /// </summary>
        public decimal? beforemoney
        {
            get { return _beforemoney; }
            set { _beforemoney = value; }
        }
        private decimal? _aftermoney;
        /// <summary>
        /// 交易之后金额
        /// </summary>
        public decimal? aftermoney
        {
            get { return _aftermoney; }
            set { _aftermoney = value; }
        }
        int? _aftermoney_max;
        /// <summary>
        /// 截至停车分钟数
        /// </summary>
        [SqlField(QueryOperator = "<", FieldFormatString = "aftermoney")]
        [BindControlParameter("aftermoney_max", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public int? aftermoney_max
        {
            get { return _aftermoney_max; }
            set { _aftermoney_max = value; }
        }
        private string _operatorid;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        private bool? _flag;
        /// <summary>
        /// 标识
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
        [SqlField(QueryOperator = ">=", FieldFormatString = "tradetime")]
        [BindControlParameter("tradetime_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string tradetime_begin
        {
            get { return _tradetime_begin; }
            set { _tradetime_begin = value; }
        }
        private string _tradetime_end;
        /// <summary>
        /// 交易时间(结束)
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "tradetime")]
        [BindControlParameter("tradetime_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string tradetime_end
        {
            get { return _tradetime_end; }
            set { _tradetime_end = value; }
        }
    }
}
