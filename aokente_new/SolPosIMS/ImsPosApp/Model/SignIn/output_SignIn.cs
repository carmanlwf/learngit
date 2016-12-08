using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ims.Pos.Model.SignIn;

namespace Ims.Pos.Model
{
    public class output_SignIn : BaseModel_output
    {
        private string _CommPassword;
        /// <summary>
        ///返回通信密码,目前无意义
        /// </summary>
        public string CommPassword
        {
            set { _CommPassword = value; }
            get { return _CommPassword; }
        }
        private string _Datetime;
        /// <summary>
        ///--返回当前服务器时间
        /// </summary>
        public string Datetime
        {
            set { _Datetime = value; }
            get { return _Datetime; }
        }
        private string _PWDID;
        /// <summary>
        ///--返回密钥索引号,目前无意义
        /// </summary>
        public string PWDID
        {
            set { _PWDID = value; }
            get { return _PWDID; }
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
        private string _sitename;
        /// <summary>
        /// 路段名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        private string _note;
        /// <summary>
        /// 便签通知
        /// </summary>
        public string note
        {
            get { return _note; }
            set { _note = value; }
        }
        private List<p_sitefeelist> _sitefeelist;
        /// <summary>
        /// 路段名称对照表
        /// </summary>
        public List<p_sitefeelist> sitefeelist
        {
            get { return _sitefeelist; }
            set { _sitefeelist = value; }
        }
        private bool _IsOpenPic;
        /// <summary>
        /// 是否开启图片功能
        /// </summary>
        public bool IsOpenPic
        {
            get { return _IsOpenPic; }
            set { _IsOpenPic = value; }
        }
        private string _longitude;
        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        private string _limitsFar;
        public string LimitsFar
        {
            get { return _limitsFar; }
            set { _limitsFar = value; }
        }
        private string _latitude;
        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        private bool _IsHasSpot;
        /// <summary>
        /// 是否开启有车位模式
        /// </summary>
        public bool IsHasSpot
        {
            get { return _IsHasSpot; }
            set { _IsHasSpot = value; }
        }
        //private bool _IsOpenFence;
        ///// <summary>
        ///// 是否开启围栏报警功能
        ///// </summary>
        //public bool IsOpenFence
        //{
        //    get { return _IsOpenFence; }
        //    set { _IsOpenFence = value; }
        //}
    }
}
