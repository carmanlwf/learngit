using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    /// <summary>
    /// tb_TurnTypeRecord 
    /// </summary>
    [DbObject("tb_TurnTypeRecord", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_tb_TurnTypeRecord", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
   public class tb_TurnTypeRecord
    {
        private string _TID;
        /// <summary>
        /// TID
        /// </summary>
        [DataField(IsKey = true)]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string TID
        {
            get { return _TID; }
            set { _TID = value; }
        }
        /// <summary>
        /// CardID
        /// </summary>
        private string _CardID;
        public string CardID
        {
            get { return _CardID; }
            set { _CardID = value; }
        }
        /// <summary>
        /// OTypeID
        /// </summary>
        private string _OTypeID;
        public string OTypeID
        {
            get { return _OTypeID; }
            set { _OTypeID = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        private string _NTypeID;
        public string NTypeID
        {
            get { return _NTypeID; }
            set { _NTypeID = value; }
        }
        private decimal? _ConDiscount1;
        /// <summary>
        ///ConDiscount1
        /// </summary>
        public decimal? ConDiscount1
        {
            get { return _ConDiscount1; }
            set { _ConDiscount1 = value; }
        }
        private int? _Proportion1;
        /// <summary>
        ///Proportion1
        /// </summary>
       public int? Proportion1
        {
            get { return _Proportion1; }
            set { _Proportion1 = value; }
        }
        private decimal? _Recharge1;
        /// <summary>
        ///充值金额范围1
        /// </summary>
        public decimal? Recharge1
        {
            get { return _Recharge1; }
            set { _Recharge1 = value; }
        }
        private decimal? _ConDiscount2;
        /// <summary>
        ///ConDiscount2
        /// </summary>
        public decimal? ConDiscount2
        {
            get { return _ConDiscount2; }
            set { _ConDiscount2 = value; }
        }
       private int? _Proportion2;
        /// <summary>
        ///Proportion21
        /// </summary>
       public int? Proportion2
        {
            get { return _Proportion2; }
            set { _Proportion2 = value; }
        }
        private decimal? _Recharge2;
        /// <summary>
        ///Recharge21
        /// </summary>
        public decimal? Recharge2
        {
            get { return _Recharge2; }
            set { _Recharge2 = value; }
        }
        /// <summary>
        /// AddDate
        /// </summary>
        private string _AddDate;
        public string AddDate
        {
            get { return _AddDate; }
            set { _AddDate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        private string _TMan;
        public string TMan
        {
            get { return _TMan; }
            set { _TMan = value; }
        }
        private bool? _Flag;
        public bool? Flag
        {
            set { _Flag = value; }
            get { return _Flag; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string _RealName;
        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }
        /// <summary>
        /// OTypeName
        /// </summary>
        private string _OTypeName;
        public string OTypeName
        {
            get { return _OTypeName; }
            set { _OTypeName = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string _NTypeName;
        public string NTypeName
        {
            get { return _NTypeName; }
            set { _NTypeName = value; }
        }


        string _AddDate1;
        /// <summary>
        ///  起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "AddDate")]
        [BindControlParameter("AddDate1", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string AddDate1
        {
            get { return _AddDate1; }
            set { _AddDate1 = value; }
        }

        string _AddDate2;
        /// <summary>
        ///  截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "AddDate")]
        [BindControlParameter("AddDate2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string AddDate2
        {
            get { return _AddDate2; }
            set { _AddDate2 = value; }
        }
    }
}
