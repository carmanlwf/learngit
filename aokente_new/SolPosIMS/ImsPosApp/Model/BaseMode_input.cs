using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class BaseMode_input
    {
        private string _POSSNR;
        /// <summary>
        /// POS终端设备号
        /// </summary>
        public string POSSNR
        {
            get { return _POSSNR; }
            set { _POSSNR = value; }
        }
        private string _VERSION;
        /// <summary>
        /// POS终端设备号
        /// </summary>
        public string VERSION
        {
            get { return _VERSION; }
            set { _VERSION = value; }
        }
    }
}
