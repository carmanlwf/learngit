using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Card.Model
{
    [Serializable]
    [DbObject("tb_card", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_card_MemberCardInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [DbObject("v_member_MemberInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [DbObject("pro_card_MemberCardInfo",ObjType=DbObjectAttribute.ObjectType.StoredProcedure)]
    [DbObject("v_Card", ObjType = DbObjectAttribute.ObjectType.View)]
    [DbObject("v_card_MemberCardInfoNoActive", ObjType = DbObjectAttribute.ObjectType.View)]
    //[DbObject("v_card_CardActivitySelect", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_Card
    {
        private string _card;//卡号
        /// <summary>
        /// 会员号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        //[InitListControl( "ProductId", "tb_Products", "tb_Products", "")]
        [InitListControl("", "card", "card", "v_card_MemberCardInfo", "card")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string card
        {
            get { return _card; }
            set { _card = value; }
        }
        private string _Userid;
        /// <summary>
        /// //用户编号
        /// </summary>
        public string Userid
        {
            get { return _Userid; }
            set { _Userid = value; }
        }
        private string _physicalno;
        /// <summary>
        /// //物理卡号
        /// </summary>
        public string physicalno
        {
            get { return _physicalno; }
            set { _physicalno = value; }
        }
        private string _isByTime;

       public string IsByTime
        {
            get { return _isByTime; }
            set { _isByTime = value; }
        }
       private string _supportSites;
       [SqlField(QueryOperator = "like", AfterLike = "%", BeforeLike = "%")]
       public string SupportSites
       {
           get { return _supportSites; }
           set { _supportSites = value; }
       }
        
        private string _uptotime;
        /// <summary>
        /// 
        /// </summary>
        public string uptotime
        {
            get { return _uptotime; }
            set { _uptotime = value; }
        }
       
        private double? _Expenditure;
        /// <summary>
        /// //消费额
        /// </summary>
        public double? Expenditure
        {
            get { return _Expenditure; }
            set { _Expenditure = value; }
        }
        private string _RealName;
        /// <summary>
        /// //真实姓名
        /// </summary>
        public string RealName
        {
            get { return _RealName; }
            set { _RealName = value; }
        }
        private int? _Points;
        /// <summary>
        /// 积分
        /// </summary>
        public int? Points
        {
            get { return _Points; }
            set { _Points = value; }
        }
        private string _Address;
        /// <summary>
        /// 分店编号
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _regionid;
        /// <summary>
        /// 分店编号
        /// </summary>
        public string regionid
        {
            get { return _regionid; }
            set { _regionid = value; }
        }
        private string _Regionids;
        /// <summary>
        /// 分店编号集合
        /// </summary>
        [SqlField("in")]
        public string Regionids
        {
            get { return _Regionids; }
            set { _Regionids = value; }
        }
        /// <summary>
        /// 站点名称
        /// </summary>
        private string _sitename;
        /// <summary>
        /// //站点名称
        /// </summary>
        //[DataField("sitename", OnlyQuery = true)]
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

      
        private string _IdType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string IdType
        {
            get { return _IdType; }
            set { _IdType = value; }
        }
        private string _IdTypeName;
        /// <summary>
        /// 证件类型名称
        /// </summary>
        public string IdTypeName
        {
            get { return _IdTypeName; }
            set { _IdTypeName = value; }
        }
        private string _IdNo;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdNo
        {
            get { return _IdNo; }
            set { _IdNo = value; }
        }
        private string _UserRank;
        /// <summary>
        /// 用户等级id
        /// </summary>
        public string UserRank
        {
            get { return _UserRank; }
            set { _UserRank = value; }
        }
        private string _RankName;
        /// <summary>
        /// 会员等级
        /// </summary>
        public string RankName
        {
            get { return _RankName; }
            set { _RankName = value; }
        }
        private string _CellPhone;
        /// <summary>
        /// 手机号
        /// </summary>
        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        private string _Gender;
        /// <summary>
        /// 性别编号
        /// </summary>
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private string _Sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        private decimal?  _Balance;
        /// <summary>
        /// 账户余额
        /// </summary>
        public  decimal? Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        private decimal? _giftamount;
        public decimal? giftamount
        {
            get { return _giftamount; }
            set { _giftamount = value; }
        }

        //private double? _DeductMoney;
        ///// <summary>
        ///// 扣减金额
        ///// </summary>
        //public double? DeductMoney
        //{
        //    get { return _DeductMoney; }
        //    set { _DeductMoney = value; }
        //}
        private int? _Status;
        /// <summary>
        /// 卡状态（0：未激活 1：正常 2：挂失 3：销卡 4:补卡）
        /// </summary>
        public int? Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        private string _tradepassword;
        /// <summary>
        /// 交易密码
        /// </summary>
        public string tradepassword
        {
            get { return _tradepassword; }
            set { _tradepassword = value; }
        }
        private string _tradepasswordsalt;
        /// <summary>
        /// 交易密钥
        /// </summary>
        public string tradepasswordsalt
        {
            get { return _tradepasswordsalt; }
            set { _tradepasswordsalt = value; }
        }
        private string _pass;
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string pass
        {
            get { return _pass; }
            set { _pass = value; }
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
        private string _statusname;
        /// <summary>
        /// 卡状态名称
        /// </summary>
        //[DataField("statusname", OnlyQuery = true)]
        public string statusname
        {
            get { return _statusname; }
            set { _statusname = value; }
        }
        private int? _activitystatus;
        /// <summary>
        /// 卡激活状态:0待激活 1已永久激活 2临时激活
        /// </summary>
        public int? activitystatus
        {
            get { return _activitystatus; }
            set { _activitystatus = value; }
        }
        private string _activitytime;
        /// <summary>
        /// 卡激活时间
        /// </summary>
        public string activitytime
        {
            get { return _activitytime; }
            set { _activitytime = value; }
        }
        private string _CActivityTime;
        /// <summary>
        /// 卡激活时间
        /// </summary>
        public string CActivityTime
        {
            get { return _CActivityTime; }
            set { _CActivityTime = value; }
        }

        
        private string _activityway;
        /// <summary>
        /// 卡激活方式 终端/在线
        /// </summary>
        public string activityway
        {
            get { return _activityway; }
            set { _activityway = value; }
        }
        private string _logouttime;
        /// <summary>
        /// 卡注销时间
        /// </summary>
        public string logouttime
        {
            get { return _logouttime; }
            set { _logouttime = value; }
        }
        private string _validDate;
        /// <summary>
        /// 卡有效日期
        /// </summary>
        public string validDate
        {
            get { return _validDate; }
            set { _validDate = value; }
        }
        private string _memo;
        /// <summary>
        /// 卡操作备注
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        //-----------------------------------------------
        //以下查询用
        //private string _addeddate1;
        //private string _addeddate2;

        //[SqlField("<=")]
        //public string addeddate2
        //{
        //    get { return _addeddate2; }
        //    set { _addeddate2= value; }
        //}

        //[SqlField(">=")]
        //public string addeddate1
        //{
        //    get { return _addeddate1; }
        //    set { _addeddate1 = value; }
        //}
        private string _addeddate;//注册时间
        /// <summary>
        /// 注册时间
        /// </summary>
        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
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
        //-----------------------------------------------------------
        private bool? _chflag;
        /// <summary>
        /// 是否启用
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("flag")]
        public bool? chflag
        {
            set { _chflag = value; }
            get { return _chflag; }
        }
        //private bool? _flag;
        //public bool? flag
        //{
        //    set { _flag = value; }
        //    get { return _flag; }
        //}
        //private string _State;
        ///// <summary>
        ///// 是否启用
        ///// </summary>
        //public string State
        //{
        //    get { return _State; }
        //    set { _State = value; }
        //}
        private bool? _isSysAuto;
        /// <summary>
        /// 是否系统生成
        /// </summary>
        public bool? isSysAuto
        {
            set { _isSysAuto = value; }
            get { return _isSysAuto; }
        }
        /// <summary>
        /// 区域代码
        /// </summary>
        private string _areaname;
        public string areaname
        {
            get { return _areaname; }
            set { _areaname = value; }
        }

        /// <summary>
        /// 区域名称
        /// </summary>
        private string _areacode;
        public string areacode
        {
            get { return _areacode; }
            set { _areacode = value; }
        }

        /// <summary>
        /// 会员等级
        /// </summary>
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private decimal? _scale;
        /// <summary>
        /// 充值比例
        /// </summary>
        public decimal? scale
        {
            get { return _scale; }
            set { _scale = value; }
        }


        /// <summary>
        /// 卡号是否有效
        /// </summary>
        private string _validDatetuse;
        public string validDatetuse
        {
            get { return _validDatetuse; }
            set { _validDatetuse = value; }
        }
        /// <summary>
        /// 余额
        /// </summary>
        private decimal? _balance;
        public decimal? balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        int? _balance_max;
        /// <summary>
        /// 截至停车分钟数
        /// </summary>
        [SqlField(QueryOperator = "<", FieldFormatString = "balance")]
        [BindControlParameter("balance_max", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public int? balance_max
        {
            get { return _balance_max; }
            set { _balance_max = value; }
        }

        decimal? _balance2;
        /// <summary>
        /// 操作截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "balance")]
        [BindControlParameter("balance2", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public decimal? balance2
        {
            get { return _balance2; }
            set { _balance2 = value; }
        }
        /// <summary>
        ///    流水号
        /// </summary>            
        private string _contno;

        public string Contno
        {
            get { return _contno; }
            set { _contno = value; }
        }

        /// <summary>
        ///   在线/终端
        /// </summary>
        private string _activeway;
        public string activeway
        {
            get { return _activeway; }
            set { _activeway = value; }
        }

        ///  激活时间
        /// </summary>
        private string _activetime;
        public string activetime
        {
            get { return _activetime; }
            set { _activetime = value; }
        }                                                                            
        /// <summary>
        ///    操作员
        /// </summary>
        private string _activeoperator;
        public string activeoperator
        {
            get { return _activeoperator; }
            set { _activeoperator = value; }
        }

        /// <summary>
        ///   卡类型编号
        /// </summary>
        private string _TypeID;
        public string TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        /// <summary>
        ///   分组编号
        /// </summary>
        private string _GroupID;
        public string GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        /// <summary>
        ///  销售人员编号
        /// </summary>
        private string _SaleMemID;
        public string SaleMemID
        {
            get { return _SaleMemID; }
            set { _SaleMemID = value; }
        }
         /// <summary>
        ///   最后消费时间
        /// </summary>
        private string _LastSaleTime1;
        public string LastSaleTime1
        {
            get { return _LastSaleTime1; }
            set { _LastSaleTime1 = value; }
        }
        /// <summary>
        ///   最后消费时间
        /// </summary>
        private string _LastSaleTime;
        public string LastSaleTime
        {
            get { return _LastSaleTime; }
            set { _LastSaleTime = value; }
        }

        /// <summary>
        ///  销售人员名字
        /// </summary>
        private string _saleName;
        public string saleName
        {
            get { return _saleName; }
            set { _saleName = value; }
        }
        /// <summary>
        ///   卡类型
        /// </summary>
        private string _TypeName;
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
               
        /// <summary>
        ///   分组名
        /// </summary>
        private string _GroupName;
        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
         /// <summary>
        ///   Recharge
        /// </summary>
        private decimal? _Recharge;
        public decimal? Recharge
        {
            get { return _Recharge; }
            set { _Recharge = value; }
        }

             
        /// <summary>
        ///   ConDiscount
        /// </summary>
        private decimal? _ConDiscount;
        public decimal? ConDiscount
        {
            get { return _ConDiscount; }
            set { _ConDiscount = value; }
        }
        /// <summary>
        ///   int?
        /// </summary>
        private  int? _Proportion;
        public  int? Proportion
        {
            get { return _Proportion; }
            set { _Proportion = value; }
        }


        string _uptotime_begin;
        /// <summary>
        /// 有效期起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "uptotime")]
        [BindControlParameter("uptotime_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string uptotime_begin
        {
            get { return _uptotime_begin; }
            set { _uptotime_begin = value; }
        }

        string _uptotime_end;
        /// <summary>
        /// 有效期截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "uptotime")]
        [BindControlParameter("uptotime_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string uptotime_end
        {
            get { return _uptotime_end; }
            set { _uptotime_end = value; }
        }

        
    }
}
