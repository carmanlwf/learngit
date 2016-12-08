using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.PriceList
{
    public class output_PriceList:BaseModel_output
    {
        private string _segmentId;
        /// <summary>
        /// 段id
        /// </summary>
        public string segmentId
        {
            get { return _segmentId; }
            set { _segmentId = value; }
        }
        private string _ruleId;
        /// <summary>
        /// 规则id
        /// </summary>
        public string ruleId
        {
            get { return _ruleId; }
            set { _ruleId = value; }
        }
        private long _timeNode1;
        /// <summary>
        /// 时间点
        /// </summary>
        public long timeNode1
        {
            get { return _timeNode1; }
            set { _timeNode1 = value; }
        }
        private int _isautoout;
        /// <summary>
        /// 时间点
        /// </summary>
        public int isautoout
        {
            get { return _isautoout; }
            set { _isautoout = value; }
        }
        private string _detailId;
        /// <summary>
        /// 内容
        /// </summary>
        public string detailId
        {
            get { return _detailId; }
            set { _detailId = value; }
        }
        private decimal _price;
        /// <summary>
        /// 价格
        /// </summary>
        public decimal price
        {
            get { return _price; }
            set { _price = value; }
        }
        private int _timeNode2;
        /// <summary>
        /// 时间点
        /// </summary>
        public int timeNode2
        {
            get { return _timeNode2; }
            set { _timeNode2 = value; }
        }
        private int _timeSpan;
        /// <summary>
        /// 时间段
        /// </summary>
        public int timeSpan
        {
            get { return _timeSpan; }
            set { _timeSpan = value; }
        }

    }
}
