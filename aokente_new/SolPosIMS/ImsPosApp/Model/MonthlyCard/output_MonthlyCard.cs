using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.MonthlyCard
{
    public class output_MonthlyCard:BaseModel_output
    {
        private List<CardInfo> _cardlist;
        /// <summary>
        /// 有效月卡客户车牌对照表
        /// </summary>
        public List<CardInfo> cardlist
        {
            get { return _cardlist; }
            set { _cardlist = value; }
        }
    }
}
