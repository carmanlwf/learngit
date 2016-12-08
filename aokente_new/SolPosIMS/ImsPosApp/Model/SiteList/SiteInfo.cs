using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.SiteList
{
    public class SiteInfo
    {
        private string _siteid;
        /// <summary>
        /// 路段编号
        /// </summary>
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        private string _sitename;
        /// <summary>
        /// 路段名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _num;
        public string num
        {
            get { return _num; }
            set { _num = value; }
        }
    }
}
