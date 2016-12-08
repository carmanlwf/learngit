using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class input_SyncParkingRecord:BaseMode_input
    {
        private long _LastUpdateTime;
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public long LastUpdateTime
        {
            get { return _LastUpdateTime; }
            set { _LastUpdateTime = value; }
        }
        #region 附带定时上传的GPS坐标
        private string _lng;
        /// <summary>
        /// 经度
        /// </summary>
        public string lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
        private string _lat;
        /// <summary>
        /// 纬度
        /// </summary>
        public string lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        private string _isOutBounds;
        /// <summary>
        /// 是否越界 0：无  1：有
        /// </summary>
        public string isOutBounds
        {
            get { return _isOutBounds; }
            set { _isOutBounds = value; }
        }
        private string _UID;
        /// <summary>
        /// 收费员编号
        /// </summary>
        public string UID
        {
            get { return _UID; }
            set { _UID = value; }
        }
        #endregion
    }
}
