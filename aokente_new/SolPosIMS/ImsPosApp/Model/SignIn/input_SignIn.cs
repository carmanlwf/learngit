using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class input_SignIn:BaseMode_input
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
        private string _BackByte;
        /// <summary>
        /// 备用字节
        /// </summary>
        public string BackByte
        {
            set { _BackByte = value; }
            get { return _BackByte; }
        }
        private string _lon;
        /// <summary>
        /// 经度
        /// </summary>
        public string lon
        {
            set { _lon = value; }
            get { return _lon; }
        }
        private string _lat;
        /// <summary>
        /// 纬度
        /// </summary>
        public string lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
       
    }
}
