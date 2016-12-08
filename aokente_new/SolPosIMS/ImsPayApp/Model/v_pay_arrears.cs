using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Pay.Model
{
    [DbObject("v_pay_arrears", ObjType = DbObjectAttribute.ObjectType.View)]
    public class v_pay_arrears
    {
        private string _CardSnr;
        public string CardSnr
        {
            get { return _CardSnr; }
            set { _CardSnr = value; }
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

        private string _tradecomment;
        /// <summary>
        /// 详情
        /// </summary>
        public string tradecomment
        {
            get { return _tradecomment; }
            set { _tradecomment = value; }
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
    }
}
