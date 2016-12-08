using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class output_SignOut:BaseModel_output
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
        private string _BackByte;
        /// <summary>
        /// 备用字节
        /// </summary>
        public string BackByte
        {
            set { _BackByte = value; }
            get { return _BackByte; }
        }
    }
}
