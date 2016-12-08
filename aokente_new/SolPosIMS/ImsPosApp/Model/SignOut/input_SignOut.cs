using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class input_SignOut:BaseMode_input
    {
        private string _UserID;
        /// <summary>
        /// 操作员ID
        /// </summary>
        public string UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
        }
        private string _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _Password = value; }
            get { return _Password; }
        }
        private string _BatchSnr;
        /// <summary>
        /// 结算批次号
        /// </summary>
        public string BatchSnr
        {
            set { _BatchSnr = value; }
            get { return _BatchSnr; }
        }
        private string _StartDate;
        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate
        {
            set { _StartDate = value; }
            get { return _StartDate; }
        }
        private string _EndDate;
        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate
        {
            set { _EndDate = value; }
            get { return _EndDate; }
        }
        private string _BusinessAmount;
        /// <summary>
        /// 累计交易金额
        /// </summary>
        public string BusinessAmount
        {
            set { _BusinessAmount = value; }
            get { return _BusinessAmount; }
        }
        private string _BunsinessCount;
        /// <summary>
        /// 累计交易笔数
        /// </summary>
        public string BunsinessCount
        {
            set { _BunsinessCount = value; }
            get { return _BunsinessCount; }
        }
    }
}
