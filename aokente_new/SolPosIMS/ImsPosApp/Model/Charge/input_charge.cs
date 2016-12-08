using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.Charge
{
    public class input_charge:BaseMode_input
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
        private string _UserID;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private decimal? _Amount;
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal? Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private string _AndroidID;
        public string AndroidID
        {
            get { return _AndroidID; }
            set { _AndroidID = value; }
        }
    }
}

