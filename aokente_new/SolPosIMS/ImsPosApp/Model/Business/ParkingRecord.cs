using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.Business
{
    public class ParkingRecord
    {
        private string _credencesnr;
        /// <summary>
        /// 交易凭证号
        /// </summary>
        public string credencesnr
        {
            get { return _credencesnr; }
            set { _credencesnr = value; }
        }
        private string _cardsnr;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string cardsnr
        {
            get { return _cardsnr; }
            set { _cardsnr = value; }
        }

        private string _cardtype;
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string cardtype
        {
            get { return _cardtype; }
            set { _cardtype = value; }
        }

        private string _sitename;
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        private string _backbyte;
        /// <summary>
        /// 备用字节(车位号)
        /// </summary>
        public string backbyte
        {
            get { return _backbyte; }
            set { _backbyte = value; }
        }

        private string _userid;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _possnr;
        public string possnr
        {
            get { return _possnr; }
            set { _possnr = value; }
        }
        
        private decimal? _money;
        /// <summary>
        /// 应扣款金额
        /// </summary>
        public decimal? money
        {
            get { return _money; }
            set { _money = value; }
        }
        private decimal? _realmoney;
        /// <summary>
        /// 实缴金额
        /// </summary>
        public decimal? realmoney
        {
            get { return _realmoney; }
            set { _realmoney = value; }
        }
        private decimal? _returnmoney;
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal? returnmoney
        {
            get { return _returnmoney; }
            set { _returnmoney = value; }
        }
        
        private int _mode;
        /// <summary>
        /// 进场(0)/离场(1)
        /// </summary>
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        //private string _RecordType;
        ///// <summary>
        ///// 记录类型
        ///// </summary>
        //public string RecordType
        //{
        //    get { return _RecordType; }
        //    set { _RecordType = value; }
        //}
        
        
        private string _starttime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public string starttime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }
        private string _endtime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public string endtime
        {
            get { return _endtime; }
            set { _endtime = value; }
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

        private string _sysid;
        public string sysid
        {
            get { return _sysid; }
            set { _sysid = value; }
        }
    }
}
