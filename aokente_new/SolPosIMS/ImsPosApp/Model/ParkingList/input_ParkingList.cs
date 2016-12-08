using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.ParkingList
{
    public class input_ParkingList:BaseMode_input
    {
        private string _siteid;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
    }
}
