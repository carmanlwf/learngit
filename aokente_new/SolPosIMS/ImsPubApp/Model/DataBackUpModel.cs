using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pub.Model
{
  public  class DataBackUpModel
    {
        private string _TotalCount = "0";
        /// <summary>
        /// 总行数
        /// </summary>
        public string TotalCount
        {
            get { return _TotalCount; }
            set { _TotalCount = value; }
        }
        private string _name;
        /// <summary>
        /// 操作员号
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _StartDate;
        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        private string _EndDate;
        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
    }
}
