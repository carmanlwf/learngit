using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class input_Business:BaseMode_input
    {
        private List<BusinessObjects> _BusinessItems;
        /// <summary>
        /// 消费记录
        /// </summary>
        public List<BusinessObjects> BusinessItems
        {
            get { return _BusinessItems; }
            set { _BusinessItems = value; }
        }
    }
}
