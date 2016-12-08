using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Job.Model
{
    public class sp_collector_persons
    {
        private string _operatorid;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        private string _name;
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _newtime;
        /// <summary>
        /// 时间
        /// </summary>
        public string newtime
        {
            get { return _newtime; }
            set { _newtime = value; }
        }
        private decimal? _receivable;
        /// <summary>
        /// 应收总额
        /// </summary>
        public decimal? receivable
        {
            get { return _receivable; }
            set { _receivable = value; }
        }
        private decimal? _pledge;
        /// <summary>
        /// 押金总额
        /// </summary>
        public decimal? pledge
        {
            get { return _pledge; }
            set { _pledge = value; }
        }
        private decimal? _unpaid;
        /// <summary>
        /// 欠缴总额
        /// </summary>
        public decimal? unpaid
        {
            get { return _unpaid; }
            set { _unpaid = value; }
        }
        private decimal? _rebates;
        /// <summary>
        /// 押金总额
        /// </summary>
        public decimal? rebates
        {
            get { return _rebates; }
            set { _rebates = value; }
        }
        private decimal? _afterPayment;
        /// <summary>
        /// 出场补交总额
        /// </summary>
        public decimal? afterPayment
        {
            get { return _afterPayment; }
            set { _afterPayment = value; }
        }
        private int? _carCount;
        /// <summary>
        /// 进场车辆总数
        /// </summary>
        public int? carCount
        {
            get { return _carCount; }
            set { _carCount = value; }
        }
        private decimal? _officialReceipts;
        /// <summary>
        /// 实收总额
        /// </summary>
        public decimal? officialReceipts
        {
            get { return _officialReceipts; }
            set { _officialReceipts = value; }
        }
        private decimal? _wirelessRecharge;
        /// <summary>
        /// 无线充值总额
        /// </summary>
        public decimal? wirelessRecharge
        {
            get { return _wirelessRecharge; }
            set { _wirelessRecharge = value; }
        }
        private int? _tradeCarCount;
        /// <summary>
        /// 月卡用户车辆总数
        /// </summary>
        public int? tradeCarCount
        {
            get { return _tradeCarCount; }
            set { _tradeCarCount = value; }
        }
    }
}
