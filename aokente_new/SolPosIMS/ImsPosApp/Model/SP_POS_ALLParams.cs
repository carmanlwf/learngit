using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class SP_POS_ALLParams
    {
        #region-------------------------------包头--------------------------------------
        private string _CMD;
        private int _PACKCOUNT;
        private string _POSSNR;
        private string _FLAG;
        private string _VERSION;
        private string _BackByte;

        /// <summary>
        /// 命令字
        /// </summary>
        public string CMD
        {
            get { return _CMD; }
            set { _CMD = value; }
        }
        /// <summary>
        /// 参数个数
        /// </summary>
        public int PACKCOUNT
        {
            get { return _PACKCOUNT; }
            set { _PACKCOUNT = value; }
        }
        /// <summary>
        /// 终端机号
        /// </summary>
        public string POSSNR
        {
            get { return _POSSNR; }
            set { _POSSNR = value; }
        }
        /// <summary>
        /// 参数，POSSERVER 无意义
        /// </summary>
        public string FLAG
        {
            get { return _FLAG; }
            set { _FLAG = value; }
        }
        /// <summary>
        /// 版本号
        /// </summary>
        public string VERSION
        {
            get { return _VERSION; }
            set { _VERSION = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string BACKBYTE
        {
            get { return _BackByte; }
            set { _BackByte = value; }
        }
        #endregion
        #region-------------------签到-------------------------------------
        private int _USERID;
        private string _UserPIN;

        private string _PASSWORD;
        /// <summary>
        /// 操作密码
        /// </summary>
        public string PASSWORD
        {
            set { _PASSWORD = value; }
            get { return _PASSWORD; }
        }

        /// <summary>
        /// 操作员ID
        /// </summary>
        public int USERID
        {
            set { _USERID = value; }
            get { return _USERID; }
        }

        /// <summary>
        ///操作员签到密码
        /// </summary>
        public string USERPIN
        {
            set { _UserPIN = value; }
            get { return _UserPIN; }
        }
        private string _lon;
        /// <summary>
        /// 经度
        /// </summary>
        public string lon
        {
            set { _lon = value; }
            get { return _lon; }
        }
        private string _lat;
        /// <summary>
        /// 纬度
        /// </summary>
        public string lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        #region--------签到输出参数
        private string _CommPASSWORD;
        /// <summary>
        ///返回通信密码,目前无意义
        /// </summary>
        public string COMMPASSWORD
        {
            set { _CommPASSWORD = value; }
            get { return _CommPASSWORD; }
        }
        private string _Datetime;
        /// <summary>
        ///--返回当前服务器时间
        /// </summary>
        public string DATETIME
        {
            set { _Datetime = value; }
            get { return _Datetime; }
        }
        private string _PWDID;
        /// <summary>
        ///--返回密钥索引号,目前无意义
        /// </summary>
        public string PWDID
        {
            set { _PWDID = value; }
            get { return _PWDID; }
        }
        #endregion
        #endregion
        #region----------------------签退--------------------

        private string _STARTDATE;
        private string _ENDDATE;
        private decimal _BusinessAmount;
        private int _BusinessCount;

        private decimal _CancelAmount;
        private int _CancelCount;
        private decimal _IntegralAmount;
        private int _IntegralCount;
        private decimal _CANCELINTEGRALAMOUNT;
        private int _CANCELINTEGRALCOUNT;

        //private int _BATCHSNR;




        ///// <summary>
        ///// 交易批次号
        ///// </summary>
        //public string BATCHSNR
        //{
        //    set { _BATCHSNR = value; }
        //    get { return _BATCHSNR; }
        //}


        /// <summary>
        /// 起始时间
        /// </summary>
        public string STARTDATE
        {
            set { _STARTDATE = value; }
            get { return _STARTDATE == null ? "" : _STARTDATE; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string ENDDATE
        {
            set { _ENDDATE = value; }
            get { return _ENDDATE == null ? "" : _ENDDATE; }
        }
        /// <summary>
        /// 交易总额
        /// </summary>
        public decimal BUSINESSAMOUNT
        {
            set { _BusinessAmount = value; }
            get { return _BusinessAmount; }
        }

        /// <summary>
        ///交易次数
        /// </summary>
        public int BUSINESSCOUNT
        {
            set { _BusinessCount = value; }
            get { return _BusinessCount; }
        }
        /// <summary>
        /// 辙单总额
        /// </summary>
        public decimal CANCELAMOUNT
        {
            set { _CancelAmount = value; }
            get { return _CancelAmount; }
        }
        /// <summary>
        /// 辙单次数
        /// </summary>
        public int CANCELCOUNT
        {
            set { _CancelCount = value; }
            get { return _CancelCount; }
        }
        /// <summary>
        ///积分交易总额
        /// </summary>
        public decimal INTEGRALAMOUNT
        {
            set { _IntegralAmount = value; }
            get { return _IntegralAmount; }
        }
        /// <summary>
        ///积分交易次数
        /// </summary>
        public int INTEGRALCOUNT
        {
            set { _IntegralCount = value; }
            get { return _IntegralCount; }
        }
        /// <summary>
        ///积分辙单总额
        /// </summary>
        public decimal CANCELINTEGRALAMOUNT
        {
            set { _CANCELINTEGRALAMOUNT = value; }
            get { return _CANCELINTEGRALAMOUNT; }
        }
        /// <summary>
        /// 积分辙单次数
        /// </summary>
        public int CANCELINTEGRALCOUNT
        {
            set { _CANCELINTEGRALCOUNT = value; }
            get { return _CANCELINTEGRALCOUNT; }
        }


        #endregion
        #region---------------查询余额---------------
        private string _MAGCARD;

        private string _PIN;
        private decimal _TotalMoney;
        private decimal _TotalIntegral; 
        /// <summary>
        ///磁条卡号
        /// </summary>
        public string MAGCARD
        {
            set { _MAGCARD = value; }
            get { return _MAGCARD; }
        }

        /// <summary>
        /// 卡密
        /// </summary>
        public string PIN
        {
            set { _PIN = value; }
            get { return _PIN; }
        }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TOTALMONEY
        {
            set { _TotalMoney = value; }
            get { return _TotalMoney; }
        }
        /// <summary>
        /// 总积分
        /// </summary>
        public decimal TOTALINTEGRAL
        {
            set { _TotalIntegral = value; }
            get { return _TotalIntegral; }
        }
        #endregion
        #region-------------------交易------------------------------------------
        private Int64 _BatchSnr;
        private string _CredenceSnr;

        private string  _CARDSNR;
        private decimal _Money;

        private int _Mode;
        private int _RecordType;
        private int _CARDTYPE;

        private string _Itemid;
        private string _Account;
        private Int64 _ReBatchSnr;
        private string _ReCredenceSnr;
        private decimal _Balance;
        private decimal _Integral;
        private decimal _TotalInteger;
        private string _ShopCode;
        private string _ShopName;
        private string _ServerWasteSnr;
        private string _ExpDate;
        private string _Remark;
        #region------------------输入参数-----------------------------
        /// <summary>
        /// 交易批次号
        /// </summary>
        public Int64 BATCHSNR
        {
            set { _BatchSnr = value; }
            get { return _BatchSnr; }
        }

        /// <summary>
        ///交易凭证号（当为辙单交易时有用）
        /// </summary>
        public string CREDENCESNR
        {
            set { _CredenceSnr = value; }
            get { return _CredenceSnr; }
        }


        /// <summary>
        ///IC卡卡号
        /// </summary>
        public string CARDSNR
        {
            set { _CARDSNR = value; }
            get { return _CARDSNR; }
        }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal MONEY
        {
            set { _Money = value; }
            get { return _Money; }
        }

        ///// <summary>
        /////发生时间
        ///// </summary>
        //public string DATETIME
        //{
        //    set { _Datetime = value; }
        //    get { return _Datetime; }
        //}
        /// <summary>
        /// 交易类型
        /// </summary>
        public int MODE
        {
            set { _Mode = value; }
            get { return _Mode; }
        }
        /// <summary>
        /// 记录类型
        /// </summary>
        public int RECORDTYPE
        {
            set { _RecordType = value; }
            get { return _RecordType; }
        }
        /// <summary>
        ///卡类型
        /// </summary>
        public int CARDTYPE
        {
            set { _CARDTYPE = value; }
            get { return _CARDTYPE; }
        }
        /// <summary>
        ///项目号/订单号
        /// </summary>
        public string ITEMID
        {
            set { _Itemid = value; }
            get { return _Itemid; }
        }
        /// <summary>
        ///消费数量
        /// </summary>
        public string Account
        {
            set { _Account = value; }
            get { return _Account; }
        }
        #endregion



        /// <summary>
        ///返回交易批次号
        /// </summary>
        public Int64 REBATCHSNR
        {
            set { _ReBatchSnr = value; }
            get { return _ReBatchSnr; }
        }
        /// <summary>
        /// 返回交易凭证号
        /// </summary>
        public string RECREDENCESNR
        {
            set { _ReCredenceSnr = value; }
            get { return _ReCredenceSnr; }
        }

        /// <summary>
        ///卡上余额
        /// </summary>
        public decimal BALANCE
        {
            set { _Balance = value; }
            get { return _Balance; }
        }
        /// <summary>
        ///本次积分
        /// </summary>
        public decimal INTEGRAL
        {
            set { _Integral = value; }
            get { return _Integral; }
        }
        /// <summary>
        ///累计积分
        /// </summary>
        public decimal TOTALINTEGER
        {
            set { _TotalInteger = value; }
            get { return _TotalInteger; }
        }
        /// <summary>
        /// 商户编号
        /// </summary>
        public string SHOPCODE
        {
            set { _ShopCode = value; }
            get { return _ShopCode; }
        }
        /// <summary>
        /// 商户名称
        /// </summary>
        public string SHOPNAME
        {
            set { _ShopName = value; }
            get { return _ShopName; }
        }
        /// <summary>
        /// 服务器端流水号
        /// </summary>
        public string SERVERWASTESNR
        {
            set { _ServerWasteSnr = value; }
            get { return _ServerWasteSnr; }
        }
        /// <summary>
        /// 卡有效期
        /// </summary>
        public string EXPDATE
        {
            set { _ExpDate = value; }
            get { return _ExpDate; }
        }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string REMARK
        {
            set { _Remark = value; }
            get { return _Remark; }
        }
        #endregion
        #region  -----------------结算-------------------
        private string _BALANCEPASSWORD;

        /// <summary>
        /// 结算密码
        /// </summary>
        public string BALANCEPASSWORD
        {
            get { return _BALANCEPASSWORD; }
            set { _BALANCEPASSWORD = value; }
        }

        private string _NEXTBATCHSNR;

        /// <summary>
        /// 下一个结算的批次号
        /// </summary>
        public string NEXTBATCHSNR
        {
            get { return _NEXTBATCHSNR; }
            set { _NEXTBATCHSNR = value; }
        }
        string _ChargeAmount;
        /// <summary>
        /// 充值额度累计
        /// </summary>
        public string ChargeAmount
        {
            get { return _ChargeAmount; }
            set { _ChargeAmount = value; }
        }
        string _ChargeCount;
        /// <summary>
        /// 充值笔数累计
        /// </summary>
        public string ChargeCount
        {
            get { return _ChargeCount; }
            set { _ChargeCount = value; }
        }

        #endregion
        #region   --------------------------同步交易秘钥--------------
        private string _BUSINESSPWDID;

        /// <summary>
        /// 命令字
        /// </summary>
        public string BUSINESSPWDID
        {
            get { return _BUSINESSPWDID; }
            set { _BUSINESSPWDID = value; }
        }
        #endregion
        
        #region   --------------------------修改密码--------------
        private string _REMESSAGE;

        /// <summary>
        /// 回传信息
        /// </summary>
        public string REMESSAGE
        {
            get { return _REMESSAGE; }
            set { _REMESSAGE = value; }
        }

        private string _NEWPIN;

        /// <summary>
        /// 新密码
        /// </summary>
        public string NEWPIN
        {
            get { return _NEWPIN; }
            set { _NEWPIN = value; }
        }
        #endregion
        string _CELLPHONE;
        /// <summary>
        /// 手机号码
        /// </summary>
        public string CELLPHONE
        {
            set { _CELLPHONE = value; }
            get { return _CELLPHONE; }
        }
    }

}
