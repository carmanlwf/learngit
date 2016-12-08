using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Pub.Model
{
    /// <summary>
    /// 卡操作日志文件
    /// </summary>
    [DbObject("PUB_RequestClient", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class PUB_RequestClient
    {
        string _SerialNo;
        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }
        string _UserHostAddress;
        /// <summary>
        /// 客户端ip
        /// </summary>
        public string UserHostAddress
        {
            get { return _UserHostAddress; }
            set { _UserHostAddress = value; }
        }
        string _ClientName;
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string ClientName
        {
            get { return _ClientName; }
            set { _ClientName = value; }
        }
        //string _MachineName;
        ///// <summary>
        ///// 客户端机器名称
        ///// </summary>
        //public string MachineName
        //{
        //    get { return _MachineName; }
        //    set { _MachineName = value; }
        //}
        string _UserDomainName;
        /// <summary>
        /// 客户端机器域名服务器
        /// </summary>
        public string UserDomainName
        {
            get { return _UserDomainName; }
            set { _UserDomainName = value; }
        }
        string _Distinguishability;
        /// <summary>
        /// 分辨率
        /// </summary>
        public string Distinguishability 
        {
            get { return _Distinguishability; }
            set { _Distinguishability = value; }
        }
        string _Browser;
        /// <summary>
        /// 客户端浏览器名称
        /// </summary>
        public string Browser
        {
            get { return _Browser; }
            set { _Browser = value; }
        }
        string _Version;
        /// <summary>
        /// 客户端浏览器版本
        /// </summary>
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        string _Platform;
        /// <summary>
        /// 客户端操作系统平台
        /// </summary>
        public string Platform
        {
            get { return _Platform; }
            set { _Platform = value; }
        }
        string _Win16or32;
        /// <summary>
        /// 客户端操作系统位数
        /// </summary>
        public string Win16or32
        {
            get { return _Win16or32; }
            set { _Win16or32 = value; }
        }
        string _Url;
        /// <summary>
        /// 客户端请求的原始url
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        string _LogTime;
        /// <summary>
        /// 记录生成时间
        /// </summary>
        public string LogTime
        {
            get { return _LogTime; }
            set { _LogTime = value; }
        }
        //以下查询用-------------------------

        private string _LogTime1;

        private string _LogTime2;

        [DataField("LogTime", OnlyQuery = true)]
        [SqlField("<=")]
        /// <summary>
        /// 终止时间
        /// </summary>
        public string LogTime2
        {
            get { return _LogTime2; }
            set { _LogTime2 = value; }
        }

        [DataField("LogTime", OnlyQuery = true)]
        [SqlField(">=")]
        /// <summary>
        /// 起始时间
        /// </summary>
        public string LogTime1
        {
            get { return _LogTime1; }
            set { _LogTime1 = value; }
        }
        //---------------------------------


        string _STATUS;
        /// <summary>
        /// 拦截状态
        /// </summary>
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        bool? _FLAG;
        /// <summary>
        /// 是否中列表显示
        /// </summary>
        public bool? FLAG
        {
            get { return _FLAG; }
            set { _FLAG = value; }
        }
    }
}
