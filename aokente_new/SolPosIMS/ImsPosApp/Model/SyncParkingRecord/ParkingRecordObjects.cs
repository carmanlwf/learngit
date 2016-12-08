using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class ParkingRecordObjects
    {
        private string _CardSnr;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CardSnr
        {
            get { return _CardSnr; }
            set { _CardSnr = value; }
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
        private string _StartTime;
        /// <summary>
        /// 进场时间
        /// </summary>
        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        private string _EndTime;
        /// <summary>
        /// 离场时间
        /// </summary>
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
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
        private string _CredenceSnr;
        /// <summary>
        /// 交易凭证号
        /// </summary>
        public string CredenceSnr
        {
            get { return _CredenceSnr; }
            set { _CredenceSnr = value; }
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
        private string _Money;
        /// <summary>
        /// 扣款金额
        /// </summary>
        public string Money
        {
            get { return _Money; }
            set { _Money = value; }
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
        private int _Mode;
        /// <summary>
        /// 进场 0 出场 1
        /// </summary>
        public int Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }
        private decimal _RealMoney;
        /// <summary>
        /// 实际缴纳金额
        /// </summary>
        public decimal RealMoney
        {
            get { return _RealMoney; }
            set { _RealMoney = value; }
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
        private string _carpicture;
        /// <summary>
        /// 图片
        /// </summary>
        public string carpicture
        {
            get { return _carpicture; }
            set { _carpicture = value; }
        }
        private decimal _userMoney;
        /// <summary>
        /// 账户余额balance->userMoney
        /// </summary>
        public decimal userMoney
        {
            get { return _userMoney; }
            set { _userMoney = value; }
        }
    }
}
