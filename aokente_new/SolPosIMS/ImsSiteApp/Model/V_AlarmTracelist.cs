using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Site.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DbObject("V_AlarmTracelist", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpQuery  | BindParameterUsage.BindToObjectAndParameter)]
    public class V_AlarmTracelist
    {
       
        private string _id;
        /// <summary>
        /// 终端编号
        /// </summary>
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage =  BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _isOutBounds;
        /// <summary>
        /// 终端编号
        /// </summary>
        public string IsOutBounds
        {
            get { return _isOutBounds; }
            set { _isOutBounds = value; }
        }
        private string _name;
        /// <summary>
        /// 终端编号
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _possnr;
        /// <summary>
        /// 终端编号
        /// </summary>
        public string Possnr
        {
            get { return _possnr; }
            set { _possnr = value; }
        }
        private string _last_sitename;
        /// <summary>
        /// 终端编号
        /// </summary>
        public string Last_sitename
        {
            get { return _last_sitename; }
            set { _last_sitename = value; }
        }

        private string _logtime;
        /// <summary>
        /// 终端编号
        /// </summary>
        public string Logtime
        {
            get { return _logtime; }
            set { _logtime = value; }
        }
        private string _operatorid;
        /// <summary>
        /// 终端编号
        /// </summary>
        public string Operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
    }
}
