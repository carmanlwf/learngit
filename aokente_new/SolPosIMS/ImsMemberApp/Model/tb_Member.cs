using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Member.Model
{
    /// <summary>
    /// 会员实体
    /// </summary>
    [DbObject("tb_member", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_member_MemberInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [DbObject("v_UserCenter_MemberInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_Member
    {
        private string _Userid;//会员号
        /// <summary>
        /// 会员号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        //[InitListControl( "ProductId", "tb_Products", "tb_Products", "")]
        [InitListControl("", "Userid", "Userid", "tb_Member", "Userid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Userid
        {
            get { return _Userid; }
            set { _Userid = value; }
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
        private string _TradePassword;
        /// <summary>
        /// 交易密码
        /// </summary>
        public string TradePassword
        {
            get { return _TradePassword; }
            set { _TradePassword = value; }
        }
        private string _TradePasswordSalt;
        /// <summary>
        /// 交易密钥
        /// </summary>
        public string TradePasswordSalt
        {
            get { return _TradePasswordSalt; }
            set { _TradePasswordSalt = value; }
        }
        private string _TradePasswordFormat;
        /// <summary>
        /// 加密方式
        /// </summary>
        public string TradePasswordFormat
        {
            get { return _TradePasswordFormat; }
            set { _TradePasswordFormat = value; }
        }
        private string _TypeName;
        /// <summary>
        /// 会员卡类型
        /// </summary>
        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
        private double? _Recharge;
        /// <summary>
        /// 充值比例
        /// </summary>
        public double? Recharge
        {
            get { return _Recharge; }
            set { _Recharge = value; }
        }

        private string _RealName;
        /// <summary>
        /// //真实姓名
        /// </summary>
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
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
        private int? _Age;
        /// <summary>
        /// 积分
        /// </summary>
        public int? Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        private string _Regionid;
        /// <summary>
        /// 分店编号  
        /// </summary>
        public string Regionid
        {
            get { return _Regionid; }
            set { _Regionid = value; }
        }

        

        private string _Regionids;
        /// <summary>
        /// 分店编号集合
        /// </summary>
        [SqlField("in")]
        [DataField("Regionid")]
        public string Regionids
        {
            get { return _Regionids; }
            set { _Regionids = value; }
        }

        //---------------2011-10-24-------------
        /// <summary>
        /// 分店编号
        /// </summary>
        private string _id;
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 区域编号集合
        /// </summary>

        private string _areacode;
        public string areacode
        {
            get { return _areacode; }
            set { _areacode = value; }
        }
        //---------------2011-10-24-------------

        /// <summary>
        /// 站点名称
        /// </summary>
        private string _sitename;
        /// <summary>
        /// //站点名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        private string _Address;
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Pass;
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }
        private string _Zipcode;
        /// <summary>
        /// 地址
        /// </summary>
        public string Zipcode
        {
            get { return _Zipcode; }
            set { _Zipcode = value; }
        }
        private string _ishavecard;
        /// <summary>
        /// 是否持卡
        /// </summary>
        public string ishavecard
        {
            get { return _ishavecard; }
            set { _ishavecard = value; }
        }
        private string _QQ;
        /// <summary>
        /// qq
        /// </summary>
        public string QQ
        {
            get { return _QQ; }
            set { _QQ = value; }
        }
        private string _MSN;
        /// <summary>
        /// MSN
        /// </summary>
        public string MSN
        {
            get { return _MSN; }
            set { _MSN = value; }
        }
        private string _email;
        /// <summary>
        /// email
        /// </summary>
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _TelPhone;
        /// <summary>
        /// TelPhone
        /// </summary>
        public string TelPhone
        {
            get { return _TelPhone; }
            set { _TelPhone = value; }
        }
        private string _CellPhone;
        /// <summary>
        /// CellPhone
        /// </summary>
        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
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
        /// 用户等级
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
        private string _ReferralUserid;
        /// <summary>
        /// 推荐人id
        /// </summary>
        public string ReferralUserid
        {
            get { return _ReferralUserid; }
            set { _ReferralUserid = value; }
        }
        private string _BirthDate;
        /// <summary>
        /// 会员生日
        /// </summary>
        public string BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }
        private int? _Gender;
        /// <summary>
        /// 性别
        /// </summary>
        public int? Gender
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
        private double? _Balance;
        /// <summary>
        /// 账户余额
        /// </summary>
        public double? Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        private double? _DeductMoney;
        /// <summary>
        /// 扣减金额
        /// </summary>
        public double? DeductMoney
        {
            get { return _DeductMoney; }
            set { _DeductMoney = value; }
        }
        private string _Memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get { return _Memo; }
            set { _Memo = value; }
        }
        //以下查询用
        private string _addeddate1;
        private string _addeddate2;

        [DataField("addeddate", OnlyQuery = true)]
        [SqlField("<=")]
        public string addeddate2
        {
            get { return _addeddate2; }
            set { _addeddate2 = value; }
        }

        [DataField("addeddate", OnlyQuery = true)]
        [SqlField(">=")]
        public string addeddate1
        {
            get { return _addeddate1; }
            set { _addeddate1 = value; }
        }
        private string _addeddate;//注册时间
        /// <summary>
        /// 注册时间
        /// </summary>
        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }

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
        private bool? _flag;
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        private bool? _IsSms;
        /// <summary>
        /// 是否开通短信
        /// </summary>
        public bool? IsSms
        {
            set { _IsSms = value; }
            get { return _IsSms; }
        }
        private bool? _cbIsSms;
        /// <summary>
        /// 是否开通短信状态值
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert| BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("IsSms")]
        public bool? cbIsSms
        {
            set { _cbIsSms = value; }
            get { return _cbIsSms; }
        }
        private string _State;
        /// <summary>
        /// 是否启用
        /// </summary>
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        private bool? _isSysAuto;
        /// <summary>
        /// 是否系统生成
        /// </summary>
        public bool? isSysAuto
        {
            set { _isSysAuto = value; }
            get { return _isSysAuto; }
        }
        //会员卡号
        private string _card;
        public string Card
        {
            get { return _card; }
            set { _card = value; }
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
        
                  //会员等级
        private string _rankid;
        public string rankid
        {
            get { return _rankid; }
            set { _rankid = value; }
        }
        //会员等级
        private string _rankname;
        public string rankname
        {
            get { return _rankname; }
            set { _rankname = value; }
        }
        //
        //会员等级
        private int? _status;
        public int? status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _GroupID;
        /// <summary>
        /// 组编号
        /// </summary>
        /// 

        public string GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        private string _GroupName;
        /// <summary>
        /// 组名字
        /// </summary>
        /// 

        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        private string _name;
        /// <summary>
        /// 销售人员名
        /// </summary>
        /// 

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
 
 
    }
}
