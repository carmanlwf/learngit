using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class BusinessObjects
    {
        private string _BatchSnr;
        /// <summary>
        /// 交易批次号
        /// </summary>
        public string BatchSnr
        {
            get { return _BatchSnr; }
            set { _BatchSnr = value; }
        }
        private string _CredenceSnr;
        /// <summary>
        /// 交易凭证号
        /// </summary>
        public string CredenceSnr
        {
            get { return _CredenceSnr; }
            set { _CredenceSnr = value; }
        }
        private string _CardSnr;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CardSnr
        {
            get { return _CardSnr; }
            set { _CardSnr = value; }
        }
        private string _UserID;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private string _Pin;
        /// <summary>
        /// 用户交易密码
        /// </summary>
        public string Pin
        {
            get { return _Pin; }
            set { _Pin = value; }
        }
        private decimal? _Money;
        /// <summary>
        /// 应扣款金额
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
        private decimal? _ReturnMoney;
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal? ReturnMoney
        {
            get { return _ReturnMoney; }
            set { _ReturnMoney = value; }
        }
        private string _DateTime;
        /// <summary>
        /// 扣款时间
        /// </summary>
        public string DateTime
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }
        private string _Mode;
        /// <summary>
        /// 进场(0)/离场(1)
        /// </summary>
        public string Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }
        private string _RecordType;
        /// <summary>
        /// 记录类型
        /// </summary>
        public string RecordType
        {
            get { return _RecordType; }
            set { _RecordType = value; }
        }
        private string _CardType;
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }
        private string _BackByte;
        /// <summary>
        /// 备用字节(车位号)
        /// </summary>
        public string BackByte
        {
            get { return _BackByte; }
            set { _BackByte = value; }
        }
        private string _StartTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        private string _EndTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        private string _carpicture;
        /// <summary>
        /// 照片
        /// </summary>
        public string carpicture
        {
            get { return _carpicture; }
            set { _carpicture = value; }
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
        private string _memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
    }
}
