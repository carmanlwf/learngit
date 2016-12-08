using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class SiteStatusObject
    {
        public SiteStatusObject()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public SiteStatusObject(string pname,int isbusy,string updatetime)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            this.parkingname = pname;
            this.isbusy = isbusy;
            this.updatetime = updatetime;
            //
        }
        private string _parkingname;
        /// <summary>
        /// 车位编号(自定义)
        /// </summary>
        public string parkingname
        {
            get { return _parkingname; }
            set { _parkingname = value; }
        }
        private int _isbusy;
        /// <summary>
        /// 是否繁忙(0 空闲 1 报警 2 占用 3维修)
        /// </summary>
        public int isbusy
        {
            get { return _isbusy; }
            set { _isbusy = value; }
        }
        private string _updatetime;
        /// <summary>
        /// 地磁状态变化更新时间(传递给手持终端作为进出场依据)
        /// </summary>
        public string updatetime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
    }
}
