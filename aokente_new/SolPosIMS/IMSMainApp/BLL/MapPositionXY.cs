using System;
using System.Collections.Generic;
using System.Text;

namespace Ims.Main.BLL
{
    public class MapPositionXY
    {
        private string _longitude;
        /// <summary>
        /// 经度
        /// </summary>
        public string longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        private string _latitude;
        /// <summary>
        /// 纬度
        /// </summary>
        public string latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
    }
}
