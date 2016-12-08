using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.ParkingList
{
    public class output_ParkingList
    {
        private List<ParkingRecordObjects> _parkinglist;
        /// <summary>
        /// 停车记录
        /// </summary>
        public List<ParkingRecordObjects> parkinglist
        {
            get { return _parkinglist; }
            set { _parkinglist = value; }
        }
    }
}
