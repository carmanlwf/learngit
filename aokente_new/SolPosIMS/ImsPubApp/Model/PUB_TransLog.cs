using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Pub.Model
{
    /// <summary>
    /// 卡账户操作日志文件
    /// </summary>
    [DbObject("PUB_TransLog", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_card_translog", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
   public class PUB_TransLog
    {
        private string _TransNo;//交易编号
        /// <summary>
        /// 交易编号
        /// </summary>
        public string TransNo
        {
            get { return _TransNo; }
            set { _TransNo = value; }
        }
        private string _Userid;//会员号
        /// <summary>
        /// 会员号
        /// </summary>
        public string Userid
        {
            get { return _Userid; }
            set { _Userid = value; }
        }
        private string _typename;//转账类型
        /// <summary>
        /// 转账类型
        /// </summary>
        public string typename
        {
            get { return _typename; }
            set { _typename = value; }
        }
        private string _RealName;//转账类型
        /// <summary>
        /// 转账类型
        /// </summary>
        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }
        string _OperateDate;
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperateDate
        {
            get { return _OperateDate; }
            set { _OperateDate = value; }
        }
        int? _transType;
        /// <summary>
        /// 交易类型(1：充值；2：扣款;3:转账)
        /// </summary>
        public int? transType
        {
            get { return _transType; }
            set { _transType = value; }
        }
        private string _transTypeName;//转账类型名称
        /// <summary>
        /// 转账类型名称
        /// </summary>
        public string transTypeName
        {
            get { return _transTypeName; }
            set { _transTypeName = value; }
        }
        double? _transmemberReak;
        /// <summary>
        /// 操作金额
        /// </summary>
        public double? transmemberReak
        {
            get { return _transmemberReak; }
            set { _transmemberReak = value; }
        }
        string _Card;
        /// <summary>
        /// 操作卡号
        /// </summary>
        public string Card
        {
            get { return _Card; }
            set { _Card = value; }
        }
        decimal? _ActualCost;
        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal? ActualCost
        {
            get { return _ActualCost; }
            set { _ActualCost = value; }
        }
        decimal? _ChargememberReak;
        /// <summary>
        /// 发生金额
        /// </summary>
        public decimal? ChargememberReak
        {
            get { return _ChargememberReak; }
            set { _ChargememberReak = value; }
        }
        int? _TransWay;
        /// <summary>
        /// 操作方式（1：现金；2：刷卡3:预付款;4在线交易）
        /// </summary>
        public int? TransWay
        {
            get { return _TransWay; }
            set { _TransWay = value; }
        }
        string _operatorid;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        string _memo;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        bool _flag;
        /// <summary>
        /// 有效状态
        /// </summary>
        public bool flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        string _OperateDate1;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "OperateDate")]
        [BindControlParameter("OperateDate1", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string OperateDate1
        {
            get { return _OperateDate1; }
            set { _OperateDate1 = value; }
        }

        string _OperateDate2;
        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "OperateDate")]
        [BindControlParameter("OperateDate2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string OperateDate2
        {
            get { return _OperateDate2; }
            set { _OperateDate2 = value; }
        }



        private string _memberReak;
        /// <summary>
        /// 会员等级
        /// </summary>
        public string memberReak
        {
            get { return _memberReak; }
            set { _memberReak = value; }
        }

        private decimal? _remainMoney;
        /// <summary>
        /// 充值前余额
        /// </summary>
        public decimal? remainMoney
        {
            get { return _remainMoney; }
            set { _remainMoney = value; }
        }

        private decimal? _chargeRate;
        /// <summary>
        /// 当时充值比例
        /// </summary>
        public decimal? chargeRate
        {
            get { return _chargeRate; }
            set { _chargeRate = value; }
        }

        private decimal? _ChargeAmount;
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal? ChargeAmount
        {
            get { return _ChargeAmount; }
            set { _ChargeAmount = value; }
        }


        private decimal? _finallyCost;
        /// <summary>
        ///最后金额
        /// </summary>
        public decimal? finallyCost
        {
            get { return _finallyCost; }
            set { _finallyCost = value; }
        }


    }
}
