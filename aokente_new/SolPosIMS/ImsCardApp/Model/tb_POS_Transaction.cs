using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    /// <summary>
    /// 充值实体
    /// </summary>
    [DbObject("tb_POS_Transaction", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pos_transaction", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_POS_Transaction
    {
        private string _id;//id

        /// <summary>
        /// id
        /// </summary>
        [DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [BindControlParameter("", "Text", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
       
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _PosSnr;
        /// <summary>
        /// Pos机号
        /// </summary>
        public string PosSnr
        {
            get { return _PosSnr; }
            set { _PosSnr = value; }
        }
        private long? _BatchSnr;
        /// <summary>
        /// 批次号
        /// </summary>
        public long? BatchSnr
        {
            get { return _BatchSnr; }
            set { _BatchSnr = value; }
        }
        /// <summary>
        /// 商店编号
        /// </summary>
        private string _regionid;
        public string Regionid
        {
            get { return _regionid; }
            set { _regionid = value; }
        }

        //--------------------2010-10-27-----------
        private string _Site_Code;
        [DataField("SiteCode")]
        [BindControlParameter("", "Text", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        public string Site_Code
        {
            get { return _Site_Code; }
            set { _Site_Code = value; }
        }

        private string _Area_Code;
        /// <summary>
        /// 区域代号
        /// </summary>
        [BindControlParameter("", "Text", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]

        public string Area_Code
        {
            get { return _Area_Code; }
            set { _Area_Code = value; }
        }


        private string _Area_Code1;
        /// <summary>
        /// 区域代号
        /// </summary>
        [BindControlParameter("Area_Code1", "SelectedValue", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("Area_Code")]
        public string Area_Code1
        {
            get { return _Area_Code1; }
            set { _Area_Code1 = value; }
        }

        //--------------------2010-10-27-----------
        private string _CredenceSnr;
        /// <summary>
        /// 交易凭证号（当为辙单交易时有用）
        /// </summary>
        public string CredenceSnr
        {
            get { return _CredenceSnr; }
            set { _CredenceSnr = value; }
        }
        private string _Magcard;
        /// <summary>
        /// 磁条卡号
        /// </summary>
        public string Magcard
        {
            get { return _Magcard; }
            set { _Magcard = value; }
        }
        private Int64? _CardSnr;
        /// <summary>
        /// ic卡号
        /// </summary>
        public Int64? CardSnr
        {
            get { return _CardSnr; }
            set { _CardSnr = value; }
        }
        private int? _UserID;
        /// <summary>
        /// ic卡号
        /// </summary>
        public int? UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private string _PIN;
        /// <summary>
        /// ic卡号
        /// </summary>
        public string PIN
        {
            get { return _PIN; }
            set { _PIN = value; }
        }
        private decimal? _Money;
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal? Money
        {
            get { return _Money; }
            set { _Money = value; }
        }
        private string _Datetime;
        /// <summary>
        /// 发生时间
        /// </summary>
        public string Datetime
        {
            get { return _Datetime; }
            set { _Datetime = value; }
        }
        private int? _Mode;
        /// <summary>
        /// 交易类型
        /// </summary>
        public int? Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }
        private int? _RecordType;
        /// <summary>
        /// 记录类型：1交易记录 2冲正记录
        /// </summary>
        public int? RecordType
        {
            get { return _RecordType; }
            set { _RecordType = value; }
        }
        private string _RecordTypeName;
        /// <summary>
        /// 记录类型名称
        /// </summary>
        public string RecordTypeName
        {
            get { return _RecordTypeName; }
            set { _RecordTypeName = value; }
        }
        private int? _CardType;
        /// <summary>
        /// 卡类型 00：磁条卡
        /// </summary>
        public int? CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }
        private string _TransType;
        /// <summary>
        /// 交易类型：1，一般交易；2，消费撤单；3，积分交易；4，积分撤单；11，冲正交易
        /// </summary>
        public string TransType
        {
            get { return _TransType; }
            set { _TransType = value; }
        }
        private string _sitename;
        /// <summary>
        /// 分店名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        //-------------------
        private string _areacode;
        /// <summary>
        /// 区域代号
        /// </summary>

        public string areacode
        {
            get { return _areacode; }
            set { _areacode = value; }
        }
        private string _areaname;
        /// <summary>
        /// 区域名称
        /// </summary>
        public string areaname
        {
            get { return _areaname; }
            set { _areaname = value; }
        }
        //-------------------
        private string _ModeName;
        /// <summary>
        /// 分店名称
        /// </summary>
        public string ModeName
        {
            get { return _ModeName; }
            set { _ModeName = value; }
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
        string _operate_date_begin;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "Datetime")]
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
        [SqlField(QueryOperator = "<=", FieldFormatString = "Datetime")]
        [BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_end
        {
            get { return _operate_date_end; }
            set { _operate_date_end = value; }
        }


        private string _recentPlayCard;
        /// <summary>
        /// 流失状态
        /// </summary>
        public string recentPlayCard
        {
            get { return _recentPlayCard; }
            set { _recentPlayCard = value; }
        }

        private string _intervalPlayCard;
        /// <summary>
        /// 距离上一次打卡月数
        /// </summary>
        public string intervalPlayCard
        {
            get { return _intervalPlayCard; }
            set { _intervalPlayCard = value; }
        }

        /// <summary>
        /// 赠送金额
        /// </summary>
        private string _giving;
        public string Giving
        {
            get { return _giving; }
            set { _giving = value; }
        }

        //折扣金额
        private decimal? _DisMoney;
        public decimal? DisMoney
        {
            get { return _DisMoney; }
            set
            { _DisMoney=value ;}
        }
        //卡折扣
        private decimal? _DisCard;
        public decimal? DisCard
        {
            get { return _DisCard; }
            set
            { _DisCard = value; }
        }
            
        /// <summary>
        /// 交易状态
        /// </summary>
        private string _TStatus;
        public string TStatus
        {
            get { return _TStatus; }
            set { _TStatus = value; }
        }
             
        /// <summary>
        /// 获取积分
        /// </summary>
        private int? _Point;
        public int? Point
        {
            get { return _Point; }
            set { _Point = value; }
        }
        /// <summary>
        /// 会员编号
        /// </summary>
        private string _Muserid;
        public string Muserid
        {
            get { return _Muserid; }
            set { _Muserid = value; }
        }
        private decimal? _BeforeBalance;
        /// <summary>
        /// 交易前金额
        /// </summary>
        public decimal? BeforeBalance
        {
            get { return _BeforeBalance; }
            set { _BeforeBalance = value; }
        }
        private decimal? _AfterBalance;
        /// <summary>
        /// 交易后金额
        /// </summary>
        public decimal? AfterBalance
        {
            get { return _AfterBalance; }
            set { _AfterBalance = value; }
        }
    }
}
