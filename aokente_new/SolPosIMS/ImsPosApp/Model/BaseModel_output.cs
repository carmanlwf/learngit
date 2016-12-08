using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class BaseModel_output
    {
        private string _FLAG;
        /// <summary>
        ///标志
        /// </summary>
        public string FLAG
        {
            set { _FLAG = value; }
            get { return _FLAG; }
        }
        private string _MESSAGE;
        /// <summary>
        ///信息内容
        /// </summary>
        public string MESSAGE
        {
            set { _MESSAGE = value; }
            get { return _MESSAGE; }
        }
    }
}
