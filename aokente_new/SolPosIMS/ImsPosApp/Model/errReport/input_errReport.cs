using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class input_errReport :BaseMode_input
    {
        private string _repContent;
        /// <summary>
        /// 错误内容
        /// </summary>
        public string repContent
        {
            get { return _repContent; }
            set { _repContent = value; }
        }
        private string _repTime;
        /// <summary>
        /// 错误时间
        /// </summary>
        public string repTime
        {
            get { return _repTime; }
            set { _repTime = value; }
        }
    }
}
