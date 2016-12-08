using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model.ModifyPass
{
    public class input_ModifyPass : BaseMode_input
    {
        private string _userid;
        public string userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        private string _newpass;
        public string newpass
        {
            get { return _newpass; }
            set { _newpass = value; }
        }

        private string _oldpass;
        public string oldpass
        {
            get { return _oldpass; }
            set { _oldpass = value; }
        }


    }
}
