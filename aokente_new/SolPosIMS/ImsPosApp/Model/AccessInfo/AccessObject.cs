using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.AccessInfo
{
    public class AccessObject
    {
        private string _UserID;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private string _Password;
        /// <summary>
        /// 操作员密码
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private string _CardSnr;
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
