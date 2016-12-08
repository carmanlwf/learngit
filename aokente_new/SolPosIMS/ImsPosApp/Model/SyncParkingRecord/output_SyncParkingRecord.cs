using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model.MonthlyCard;

namespace Ims.Pos.Model
{
    public class output_SyncParkingRecord:BaseModel_output
    {
        private List<ParkingRecordObjects> _ParkingRecordItems;
        /// <summary>
        /// 停车记录
        /// </summary>
        public List<ParkingRecordObjects> ParkingRecordItems
        {
            get { return _ParkingRecordItems; }
            set { _ParkingRecordItems = value; }
        }

        private List<CardInfo> _cardlist;
        //月卡记录
        public List<CardInfo> cardlist
        {
            get { return _cardlist; }
            set { _cardlist = value; }
        }

        private string _count;
        //车位数
        public string count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
}
