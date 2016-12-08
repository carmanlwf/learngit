using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Card.Model
{
    /// <summary>
    /// 转账实体
    /// </summary>
    [DbObject("tb_TransferRecord", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_TransferRecord
    {
        private string _TransNo;
        /// <summary>
        ///交易编号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        //[InitListControl( "ProductId", "tb_Products", "tb_Products", "")]
        //[InitListControl("", "card", "card", "tb_member", "card")]
        //[BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string TransNo
        {
            get { return _TransNo; }
            set { _TransNo = value; }
        }
        private string _card1;
        /// <summary>
        /// 转出卡号
        /// </summary>
        public string card1
        {
            get { return _card1; }
            set { _card1 = value; }
        }
        private string _card2;
        /// <summary>
        /// 转入卡号
        /// </summary>
        public string card2
        {
            get { return _card2; }
            set { _card2 = value; }
        }
        private string _name1;
        /// <summary>
        /// 转出人姓名
        /// </summary>
        public string name1
        {
            get { return _name1; }
            set { _name1 = value; }
        }
        private string _name2;
        /// <summary>
        /// 转入人姓名
        /// </summary>
        public string name2
        {
            get { return _name2; }
            set { _name2 = value; }
        }
        private double? _card1_OldBalance;
        /// <summary>
        /// 转出卡原有金额card1_NewBalance
        /// </summary>
        public double? card1_OldBalance
        {
            get { return _card1_OldBalance; }
            set { _card1_OldBalance = value; }
        }
        private double? _card2_OldBalance;
        /// <summary>
        /// 转入卡原有金额
        /// </summary>
        public double? card2_OldBalance
        {
            get { return _card2_OldBalance; }
            set { _card2_OldBalance = value; }
        }




        private double? _card1_NewBalance;
        /// <summary>
        /// 转出卡后的金额card1_NewBalance
        /// </summary>
        public double? card1_NewBalance
        {
            get { return _card1_NewBalance; }
            set { _card1_NewBalance = value; }
        }
        private double? _card2_NewBalance;
        /// <summary>
        /// 转入卡后原的金额
        /// </summary>
        public double? card2_NewBalance
        {
            get { return _card2_NewBalance; }
            set { _card2_NewBalance = value; }
        }





        private double? _Amount;
        /// <summary>
        /// 转账金额
        /// </summary>
        public double? Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
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
        private string _memo;
        /// <summary>
        /// 转账备注
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
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
        string _Operator;
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        string _operate_date_begin;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "operatedate")]
        [BindControlParameter("operate_date_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_begin
        {
            get { return _operate_date_begin; }
            set { _operate_date_begin = value; }
        }

        string _operate_date_end;
        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "operatedate")]
        [BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_end
        {
            get { return _operate_date_end; }
            set { _operate_date_end = value; }
        }
    }
}
