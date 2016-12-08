using System;
using System.Collections.Generic;
using System.Text;

namespace Ims.Card.Model.MonthlyCard
{
    public class MonthlyCardTypeInfo
    {
        private string _TypeID;
        /// <summary>
        /// 类型编号
        /// </summary>
        public string TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; ; }
        }
        private string _TypeName;
        /// <summary>
        /// 类型编号
        /// </summary>
        public string TypeNmae
        {
            get { return _TypeName; }
            set { _TypeName = value; ; }
        }
        private decimal? _price;
        /// <summary>
        /// 价格
        /// </summary>
        public decimal? price
        {
            get { return _price; }
            set { _price = value; }
        }
        private int? _months;
        /// <summary>
        /// 月份
        /// </summary>
        public int? months
        {
            get { return _months; }
            set { _months = value; }
        }

        private bool? _IsDayCard;

        public bool? IsDayCard
        {
            get { return _IsDayCard; }
            set { _IsDayCard = value; }
        }
    }
}
