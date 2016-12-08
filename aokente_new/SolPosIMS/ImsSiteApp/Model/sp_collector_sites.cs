using System;
using System.Collections.Generic;
using System.Text;

namespace Ims.Site.Model
{
    public class sp_collector_sites
    {
        private string _siteid;
        /// <summary>
        /// 路段编号
        /// </summary>
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        private string _sitename;
        /// <summary>
        /// 路段名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
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
    }
}

