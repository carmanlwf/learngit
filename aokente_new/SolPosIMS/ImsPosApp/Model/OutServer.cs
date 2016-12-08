using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class OutServer
    {
        private string _osIp;

        public string OsIp
        {
            get { return _osIp; }
            set { _osIp = value; }
        }
        private string _osID;
        public string OsID
        {
            get { return _osID; }
            set { _osID= value; }
        }
        private string _osName;
        public string OsName
        {
        get { return _osName; }
        set { _osName = value; }
        }
        private bool _flag;

        public bool Flag
        {
        get { return _flag; }
        set { _flag = value; }
        }
        
    }
}
