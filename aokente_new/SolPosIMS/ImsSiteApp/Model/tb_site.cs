using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;


namespace Ims.Site.Model
{

    /// <summary>
    /// 分店（配送站）实体
    /// </summary>
    [DbObject("tb_Site", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_site_SiteInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_site
    {
        private string _id;//网站咨询序列号
        /// <summary>
        /// 网站咨询序列号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [InitListControl("", "id", "id", "tb_Site", "id")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _machineid;//机器号
        /// <summary>
        /// 机器号
        /// </summary>
        public string machineid
        {
            get { return _machineid; }
            set { _machineid = value; }
        }
        private string _longitude;
        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        private string _limitsFar;
        public string LimitsFar
        {
            get { return _limitsFar; }
            set { _limitsFar = value; }
        }
        private string _latitude;
        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        private string _isOpenFence;
        public string IsOpenFence
        {
            get { return _isOpenFence; }
            set { _isOpenFence = value; }
        }
        /// <summary>
        /// 站点名称
        /// </summary>
        private string _sitename;//站点名称
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        private string _beginTime;//站点名称
        public string BeginTime
        {
            get { return _beginTime; }
            set { _beginTime = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        private string _endTime;//站点名称

        public string EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private string _operatorid;//操作员id
        /// <summary>
        /// 操作员id
        /// </summary>
        //[BindControlParameter("querycustomername", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        private string _areacode;//区域代码
        /// <summary>
        /// 区域代码
        /// </summary>
        public string areacode
        {
            get { return _areacode; }
            set { _areacode = value; }
        }
        private string _areaname;//区域代码
        /// <summary>
        /// 区域名称
        /// </summary>
        public string areaname
        {
            get { return _areaname; }
            set { _areaname = value; }
        }
        private string _pass;//密码
        /// <summary>
        /// 密码
        /// </summary>
        public string pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        private string _linkman;//联系人
        /// <summary>
        /// 联系人
        /// </summary>
        public string linkman
        {
            get { return _linkman; }
            set { _linkman = value; }
        }

        private string _linkphone;//联系电话
        /// <summary>
        /// 联系电话
        /// </summary>
        public string linkphone
        {
            get { return _linkphone; }
            set { _linkphone = value; }
        }

        private decimal? _balance;//金额
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

      
        private int? _NUMconsume;
        /// <summary>
        ///消费交易笔数
        /// </summary>
        public int? NUMconsume
        {
            get { return _NUMconsume; }
            set { _NUMconsume = value; }
        }

        private decimal? _Moneyconsume;//售价
        /// <summary>
        /// 消费交易总额
        /// </summary>
        public decimal? Moneyconsume
        {
            get { return _Moneyconsume; }
            set { _Moneyconsume = value; }
        }


        private int? _NUMRemove;
        /// <summary>
        /// 撤单交易笔数
        /// </summary>
        public int? NUMRemove
        {
            get { return _NUMRemove; }
            set { _NUMRemove = value; }
        }


        private decimal? _MoneyRemove;//售价
        /// <summary>
        /// 撤单交易总额
        /// </summary>
        public decimal? MoneyRemove
        {
            get { return _MoneyRemove; }
            set { _MoneyRemove = value; }
        }

        private int? _NUMrecharge;
        /// <summary>
        /// 充值交易笔数
        /// </summary>
        public int? NUMrecharge
        {
            get { return _NUMrecharge; }
            set { _NUMrecharge = value; }
        }

        private decimal? _Moneyrecharge;//售价
        /// <summary>
        /// 充值交易总额
        /// </summary>
        public decimal? Moneyrecharge
        {
            get { return _Moneyrecharge; }
            set { _Moneyrecharge = value; }
        }

        //以下统计用
        private string _regtime3;
        private string _regtime4;

        public string regtime4
        {
            get { return _regtime4; }
            set { _regtime4 = value; }
        }

        public string regtime3
        {
            get { return _regtime3; }
            set { _regtime3 = value; }
        }

        //以下查询用
        private string _regtime1;
        private string _regtime2;

        [DataField("regtime", OnlyQuery = true)]
        [SqlField("<=")]
        public string regtime2
        {
            get { return _regtime2; }
            set { _regtime2 = value; }
        }

        [DataField("regtime", OnlyQuery = true)]
        [SqlField(">=")]
        public string regtime1
        {
            get { return _regtime1; }
            set { _regtime1 = value; }
        }
        private string _regtime;//注册时间
        /// <summary>
        /// 注册时间
        /// </summary>
        public string regtime
        {
            get { return _regtime; }
            set { _regtime = value; }
        }
        private string _note;//备注
        /// <summary>
        /// 备注
        /// </summary>
        public string note
        {
            get { return _note; }
            set { _note = value; }
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


        private bool? _isBalance;
        /// <summary>
        /// 是否限额
        /// </summary>
        [BindControlParameter("", "Checked", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("isBalance")]
        public bool? isBalance
        {
            set { _isBalance = value; }
            get { return _isBalance; }
        }

        private bool? _flag;
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        private string _Category;//品牌
        /// <summary>
        /// 品牌 
        /// </summary>
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        private string _status;//品牌
        /// <summary>
        /// 限额状态
        /// </summary>
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// 最后活跃时间
        /// </summary>
        private string _lastActiveTime;
        public string lastActiveTime
        {
            get { return _lastActiveTime; }
            set { _lastActiveTime = value; }
        }


    }
}
