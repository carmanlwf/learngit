using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.MonthlyCard
{
    public class CardInfo
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
        private string _uptotime;
        /// <summary>
        /// 截至日期(月卡)
        /// </summary>
        public string uptotime
        {
            get { return _uptotime; }
            set { _uptotime = value; }
        }
    }
}
