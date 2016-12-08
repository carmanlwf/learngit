using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.SignIn
{
    public class p_sitefeelist
    {
        private int? _carType;
        /// <summary>
        /// 车辆类型 1：小车  2：大车
        /// </summary>
        public int? carType
        {
            get { return _carType; }
            set { _carType = value; }
        }
        private string _startWorkTime;
        /// <summary>
        /// 开始工作时间
        /// </summary>
        public string startWorkTime
        {
            get { return _startWorkTime; }
            set { _startWorkTime = value; }
        }
        private string _endWorkTime;
        /// <summary>
        /// 结束工作时间
        /// </summary>
        public string endWorkTime
        {
            get { return _endWorkTime; }
            set { _endWorkTime = value; }
        }
        private decimal? _minPayment;
        /// <summary>
        /// 起步价
        /// </summary>
        public decimal? minPayment
        {
            get { return _minPayment; }
            set { _minPayment = value; }
        }
        private decimal? _maxPayment;
        /// <summary>
        /// 封顶价
        /// </summary>
        public decimal? maxPayment
        {
            get { return _maxPayment; }
            set { _maxPayment = value; }
        }
        private int? _firstChargingTimeSeg;
        /// <summary>
        /// 起步时段（分钟）
        /// </summary>
        public int? firstChargingTimeSeg
        {
            get { return _firstChargingTimeSeg; }
            set { _firstChargingTimeSeg = value; }
        }
        private int? _normalChargingTimeSeg;
        /// <summary>
        /// 起步时段以后多少时间间隔计费一次（分钟）
        /// </summary>
        public int? normalChargingTimeSeg
        {
            get { return _normalChargingTimeSeg; }
            set { _normalChargingTimeSeg = value; }
        }
        private decimal? _normalChargingPrice;
        /// <summary>
        /// 起步段后每次计费累加金额（元）
        /// </summary>
        public decimal? normalChargingPrice
        {
            get { return _normalChargingPrice; }
            set { _normalChargingPrice = value; }
        }
        private int? _freeTimeSeg;
        /// <summary>
        /// 免费时长（分钟）
        /// </summary>
        public int? freeTimeSeg
        {
            get { return _freeTimeSeg; }
            set { _freeTimeSeg = value; }
        }
        private bool? _isChargByTimes;
        /// <summary>
        /// 是否按次收费
        /// </summary>
        public bool? isChargByTimes
        {
            get { return _isChargByTimes; }
            set { _isChargByTimes = value; }
        }
        private string _memo;
        /// <summary>
        /// 描述
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private bool? _IsFullTiming;
        /// <summary>
        /// 是否足额计费 默认0
        /// </summary>
        public bool? IsFullTiming
        {
            get { return _IsFullTiming; }
            set { _IsFullTiming = value; }
        }
        private int? _FisrtChargingTimes;
        /// <summary>
        /// 首次计费倍数 默认1
        /// </summary>
        public int? FisrtChargingTimes
        {
            get { return _FisrtChargingTimes; }
            set { _FisrtChargingTimes = value; }
        }
    }
}
