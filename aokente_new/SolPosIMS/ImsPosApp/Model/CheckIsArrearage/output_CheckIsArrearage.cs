using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class output_CheckIsArrearage:BaseModel_output
    {
        //string _CardSnr;
        ///// <summary>
        ///// 车牌号
        ///// </summary>
        //public string CardSnr
        //{
        //    get { return _CardSnr; }
        //    set { _CardSnr = value; }
        //}
        string _CardType;
        /// <summary>
        /// 账户类型
        /// </summary>
        public string CardType
        {
            get { return _CardType; }
            set { _CardType = value; }
        }
        decimal? _Balance;
        /// <summary>
        /// 账户金额
        /// </summary>
        public decimal? Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        decimal? _TotalExpenditure;
        /// <summary>
        /// 累计消费
        /// </summary>
        public decimal? TotalExpenditure
        {
            get { return _TotalExpenditure; }
            set { _TotalExpenditure = value; }
        }
        int? _Points;
        /// <summary>
        /// 累计消费
        /// </summary>
        public int? Points
        {
            get { return _Points; }
            set { _Points = value; }
        }
        string _validDate;
        /// <summary>
        /// 有效期
        /// </summary>
        public string validDate
        {
            get { return _validDate; }
            set { _validDate = value; }
        }
        string _CellPhone;
        /// <summary>
        /// 手机号码
        /// </summary>
        public string CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        string _LastSaleTime;
        /// <summary>
        /// 最后消费时间
        /// </summary>
        public string LastSaleTime
        {
            get { return _LastSaleTime; }
            set { _LastSaleTime = value; }
        }
        int _IsByTime;
        /// <summary>
        /// 是否为月卡  0：不是   1：是
        /// </summary>
        public int IsByTime
        {
            get { return _IsByTime; }
            set { _IsByTime = value; }
        }
        string _uptotime;
        /// <summary>
        /// 月卡截至日期
        /// </summary>
        public string uptotime
        {
            get { return _uptotime; }
            set { _uptotime = value; }
        }
        string _supportSites;
        /// <summary>
        /// 支持停车的路段
        /// </summary>
        public string supportSites
        {
            get { return _supportSites; }
            set { _supportSites = value; }
        }

        private string _chargeTime;
        public string chargeTime
        {
            get { return _chargeTime; }
            set { _chargeTime = value; }
        }
    }
}
