using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Site.Model
{
    [DbObject("v_pos_poslistInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_pos_poslistinfo
    {
        /// <summary>
        /// 终端管理(视图)
        /// </summary>
        private string _posnum;
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        /// <summary>
        /// 终端编号
        /// </summary>
        public string posnum
        {
            get { return _posnum; }
            set { _posnum = value; }
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        private string _postype;

        public string postype
        {
            get { return _postype; }
            set { _postype = value; }
        }
        /// <summary>
        /// 机器型号
        /// </summary>
        private string _productno;

        public string productno
        {
            get { return _productno; }
            set { _productno = value; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        private string _lat;

        public string lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        private string _lon;

        public string lon
        {
            get { return _lon; }
            set { _lon = value; }
        }
        /// <summary>
        /// 签退时间
        /// </summary>
        private string _lastactiontime;

        public string lastactiontime
        {
            get { return _lastactiontime; }
            set { _lastactiontime = value; }
        }
        /// <summary>
        /// 路段id
        /// </summary>
        private string _siteid;
        [BindControlParameter("Site_Code", "Text", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        [DataField("siteid")]
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        /// <summary>
        ///路段名称
        /// </summary>
        private string _sitename;//路段名称
        //[SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        /// <summary>
        /// 最后活动ip
        /// </summary>
        private string _lastip;

        public string lastip
        {
            get { return _lastip; }
            set { _lastip = value; }
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        private string _isaction;

        public string isaction
        {
            get { return _isaction; }
            set { _isaction = value; }
        }
        /// <summary>
        /// 签到时间
        /// </summary>
        private string _addedtime;

        public string addedtime
        {
            get { return _addedtime; }
            set { _addedtime = value; }
        }
        /// <summary>
        /// 操作管理员
        /// </summary>
        private string _opt_user;

        public string opt_user
        {
            get { return _opt_user; }
            set { _opt_user = value; }
        }
        private bool? _flag;

        public bool? flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}
