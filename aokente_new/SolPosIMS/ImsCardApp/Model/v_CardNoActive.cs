using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Card.Model
{
    /// <summary>
    ///卡未激活信息
    /// </summary>
    [DbObject("v_CardNoActive", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
   public  class v_CardNoActive
    {

        #region Model
        private string _card;
        private decimal? _balance;
        private string _typename;
        private string _addeddate;
        private decimal? _condiscount;
        private int? _proportion;
        private string _groupname;
        private string _name;
        private string _salememid;
        private string _typeid;
        private string _groupid;
        private string _cardstatus;
        /// <summary>
        /// 
        /// </summary>
        public string card
        {
            set { _card = value; }
            get { return _card; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? balance
        {
            set { _balance = value; }
            get { return _balance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string addeddate
        {
            set { _addeddate = value; }
            get { return _addeddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ConDiscount
        {
            set { _condiscount = value; }
            get { return _condiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Proportion
        {
            set { _proportion = value; }
            get { return _proportion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SaleMemID
        {
            set { _salememid = value; }
            get { return _salememid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        private decimal? _initvalue;
        /// <summary>
        /// 初始金额
        /// </summary>
        public decimal? initvalue
        {
            get { return _initvalue; }
            set { _initvalue = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupID
        {
            set { _groupid = value; }
            get { return _groupid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cardstatus
        {
            set { _cardstatus = value; }
            get { return _cardstatus; }
        }
        //----------------------------------------------------------
        string _addeddate1;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "addeddate")]
        [BindControlParameter("addeddate1", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string addeddate1
        {
            get { return _addeddate1; }
            set { _addeddate1 = value; }
        }

        string _addeddate2;
        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "addeddate")]
        [BindControlParameter("addeddate2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string addeddate2
        {
            get { return _addeddate2; }
            set { _addeddate2 = value; }
        }
        private bool? _flag;
        /// <summary>
        /// 是否系统生成
        /// </summary>
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        //-----------------------------------------------------------
        #endregion Model

    }
}

