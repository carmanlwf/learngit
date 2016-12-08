using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class input_CheckIsArrearage:BaseMode_input
    {
        string _Uid;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string Uid
        {
            get { return _Uid; }
            set { _Uid = value; }
        }
        string _CardSnr;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CardSnr
        {
            get { return _CardSnr; }
            set { _CardSnr = value; }
        }
    }
}
