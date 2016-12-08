using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class input_Magic:BaseMode_input
    {
        private int _timespan;
        /// <summary>
        /// 默认30秒一个周期
        /// </summary>
        public int timespan
        {
            get { return _timespan; }
            set { _timespan = value; }
        }

    }
}
