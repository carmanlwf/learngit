using System;
using System.Collections.Generic;
using System.Text;

namespace Ims.Main.Model
{
    /// <summary>
    /// 业务功能日志
    /// </summary>
    public class pub_funloginfo
    {
        private string _operdate;
        /// <summary>
        /// 操作日期
        /// </summary>
        public string operdate
        {
            get { return _operdate; }
            set { _operdate = value; }
        }
        private string _agentid;
        /// <summary>
        /// 用户工号
        /// </summary>
        public string agentid
        {
            get { return _agentid; }
            set { _agentid = value; }
        }
        private string _functionid;
        /// <summary>
        /// 功能编号
        /// </summary>
        public string functionid
        {
            get { return _functionid; }
            set { _functionid = value; }
        }
        private string _logmsg;
        /// <summary>
        /// 日志内容
        /// </summary>
        public string logmsg
        {
            get { return _logmsg; }
            set { _logmsg = value; }
        }
    }
}
