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
    [DbObject("v_pos_transaction", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_pos_transaction
    {
        private string _id;//id

        /// <summary>
        /// id
        /// </summary>
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
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

        private string _CredenceSnr;
        /// <summary>
        /// 交易凭证号（当为辙单交易时有用）
        /// </summary>
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
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
        private string _CardSnr;
        /// <summary>
        /// ic卡号
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string CardSnr
        {
            get { return _CardSnr; }
            set { _CardSnr = value; }
        }
        private string _UserID;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserID
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
        /// 应缴金额
        /// </summary>
        public decimal? Money
        {
            get { return _Money; }
            set { _Money = value; }
        }
        private decimal? _RealMoney;
        /// <summary>
        /// 实缴金额
        /// </summary>
        public decimal? RealMoney
        {
            get { return _RealMoney; }
            set { _RealMoney = value; }
        }
        private decimal? _giving;
        /// <summary>
        /// 押金
        /// </summary>
        public decimal? giving
        {
            get { return _giving; }
            set { _giving = value; }
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
        private string _CarStatus;
        /// <summary>
        /// 停车状态(Mode的中文)
        /// </summary>
        public string CarStatus
        {
            get { return _CarStatus; }
            set { _CarStatus = value; }
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
        /// 交易类型
        /// </summary>
        public string TransType
        {
            get { return _TransType; }
            set { _TransType = value; }
        }
        private string _Site_Code;
        [DataField("Site_Code")]
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
        //private string _SiteCode;
        ///// <summary>
        ///// 路段编号
        ///// </summary>

        //public string SiteCode
        //{
        //    get { return _SiteCode; }
        //    set { _SiteCode = value; }
        //}
        private string _sitename;
        /// <summary>
        /// 路段名称
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

        bool _flag;
        /// <summary>
        /// 有效状态
        /// </summary>
        public bool flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        //string _operate_date_begin;
        ///// <summary>
        ///// 操作起始时间
        ///// </summary>
        //[SqlField(QueryOperator = ">=", FieldFormatString = "Datetime")]
        //[BindControlParameter("operate_date_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        //public string operate_date_begin
        //{
        //    get { return _operate_date_begin; }
        //    set { _operate_date_begin = value; }
        //}

        //string _operate_date_end;
        ///// <summary>
        ///// 操作截止时间
        ///// </summary>
        //[SqlField(QueryOperator = "<=", FieldFormatString = "Datetime")]
        //[BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        //public string operate_date_end
        //{
        //    get { return _operate_date_end; }
        //    set { _operate_date_end = value; }
        //}
 
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
        /// <summary>
        /// 起始时间
        /// </summary>
        private string _StartTime;
        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        string _start_date_begin;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "StartTime")]
        [BindControlParameter("start_date_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string start_date_begin
        {
            get { return _start_date_begin; }
            set { _start_date_begin = value; }
        }

        string _start_date_end;
        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "StartTime")]
        [BindControlParameter("start_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string start_date_end
        {
            get { return _start_date_end; }
            set { _start_date_end = value; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        private string _EndTime;
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        /// <summary>
        /// 车位号
        /// </summary>
        private string _BackByte;
        public string BackByte
        {
            get { return _BackByte; }
            set { _BackByte = value; }
        }
        string _end_date_begin;
        /// <summary>
        /// 操作起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "EndTime")]
        [BindControlParameter("end_date_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string end_date_begin
        {
            get { return _end_date_begin; }
            set { _end_date_begin = value; }
        }

        string _end_date_end;
        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "EndTime")]
        [BindControlParameter("end_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string end_date_end
        {
            get { return _end_date_end; }
            set { _end_date_end = value; }
        }

        /// <summary>
        /// 获取积分
        /// </summary>
        private int? _sumMins;
        public int? sumMins
        {
            get { return _sumMins; }
            set { _sumMins = value; }
        }
        int? _sumMins_min;
        /// <summary>
        /// 起始停车分钟数
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "sumMins")]
        [BindControlParameter("sumMins_min", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public int? sumMins_min
        {
            get { return _sumMins_min; }
            set { _sumMins_min = value; }
        }

        int? _sumMins_max;
        /// <summary>
        /// 截至停车分钟数
        /// </summary>
        [SqlField(QueryOperator = "<", FieldFormatString = "sumMins")]
        [BindControlParameter("sumMins_max", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public int? sumMins_max
        {
            get { return _sumMins_max; }
            set { _sumMins_max = value; }
        }
        /// <summary>
        /// 车位号
        /// </summary>
        private string _carpicture;
        /// <summary>
        /// 车辆照片
        /// </summary>
        public string carpicture
        {
            get { return _carpicture; }
            set { _carpicture = value; }
        }

        //APP版本号
        private string _version;

        public string version
        {
            get { return _version; }
            set { _version = value; }
        }
    }
}

