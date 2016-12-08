using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Card.Model
{
    /// <summary>
    /// 会员流失信息
    /// </summary>
    [DbObject(" v_CardToExec", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]

    public class v_CardToExec
    {
        #region Model
        private string _card;
        private decimal? _balance;
        private string _addeddate;
        private string _activitystatus;
        private string _validdate;
        private string _cardstatus;
        private string _realname;
        private string _sitename;
        private string _activeaddate;
        private string _cellphone;
        private int? _points;
        private string _statusname;
        private string _Name;
        private string _siteid;
        private string _userRank;
        private string _isuseornouser;
        private string _TypeID;
        private string _TypeName;
        private string _initvalue;
        private int? _point1;
        private int? _point2;

        /// <summary>
        /// 
        /// </summary>
        public string isuseornouser
        {
            set { _isuseornouser = value; }
            get { return _isuseornouser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string siteid
        {
            set { _siteid = value; }
            get { return _siteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userRank
        {
            set { _userRank = value; }
            get { return _userRank; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string statusname
        {
            set { _statusname = value; }
            get { return _statusname; }
        }
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
        public string addeddate
        {
            set { _addeddate = value; }
            get { return _addeddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string activitystatus
        {
            set { _activitystatus = value; }
            get { return _activitystatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string validDate
        {
            set { _validdate = value; }
            get { return _validdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cardstatus
        {
            set { _cardstatus = value; }
            get { return _cardstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sitename
        {
            set { _sitename = value; }
            get { return _sitename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string activeaddate
        {
            set { _activeaddate = value; }
            get { return _activeaddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CellPhone
        {
            set { _cellphone = value; }
            get { return _cellphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Points
        {
            set { _points = value; }
            get { return _points; }
        }

        private bool? _flag;
        /// <summary>
        /// 有效状态
        /// </summary>
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }

        //-----------------------------发卡时间控制
        string _addeddate1;
        /// <summary>
        /// 发卡起始时间
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
        /// 发卡截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "addeddate")]
        [BindControlParameter("addeddate2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string addeddate2
        {
            get { return _addeddate2; }
            set { _addeddate2 = value; }
        }
        //-----------------------------------------------------------
        string _activetime1;
        /// <summary>
        /// 激活起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "activeaddate")]
        [BindControlParameter("activetime1", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string activetime1
        {
            get { return _activetime1; }
            set { _activetime1 = value; }
        }



        string _activetime2;
        /// <summary>
        /// 激活操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "activeaddate")]
        [BindControlParameter("activetime2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string activetime2
        {
            get { return _activetime2; }
            set { _activetime2 = value; }
        }

        public string areacode { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        /// <summary>
        /// 卡类型名称
        /// </summary>
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
        public string initvalue
        {
            get { return _initvalue; }
            set { _initvalue = value; }
        }

        /// <summary>
        /// 激活起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "Points")]
        [BindControlParameter("S_Point", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public int? S_Point
        {
            get { return _point1; }
            set { _point1 = value; }
        }

        /// <summary>
        /// 激活操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "Points")]
        [BindControlParameter("E_Point", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public int? E_Point
        {
            get { return _point2; }
            set { _point2 = value; }
        }
        #endregion Model

    }
}

