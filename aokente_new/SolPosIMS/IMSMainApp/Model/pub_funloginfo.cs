using System;
using System.Collections.Generic;
using System.Text;

namespace Ims.Main.Model
{
    /// <summary>
    /// ҵ������־
    /// </summary>
    public class pub_funloginfo
    {
        private string _operdate;
        /// <summary>
        /// ��������
        /// </summary>
        public string operdate
        {
            get { return _operdate; }
            set { _operdate = value; }
        }
        private string _agentid;
        /// <summary>
        /// �û�����
        /// </summary>
        public string agentid
        {
            get { return _agentid; }
            set { _agentid = value; }
        }
        private string _functionid;
        /// <summary>
        /// ���ܱ��
        /// </summary>
        public string functionid
        {
            get { return _functionid; }
            set { _functionid = value; }
        }
        private string _logmsg;
        /// <summary>
        /// ��־����
        /// </summary>
        public string logmsg
        {
            get { return _logmsg; }
            set { _logmsg = value; }
        }
    }
}
