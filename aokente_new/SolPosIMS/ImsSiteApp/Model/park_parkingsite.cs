using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Site.Model
{
     /// <summary>
        /// 车位管理
        /// </summary>
    [DbObject("park_parkingsite", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_parkingsiteinfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class park_parkingsite
    {
        private string _parkingid;//车位编号
        /// 车位编号(必填)
        /// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        [DataField(IsKey = true)]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string parkingid
        {
            get { return _parkingid; }
            set { _parkingid = value; }
        }
        /// <summary>
        ///路段编号
        /// </summary>
        private string _siteid;//车位名称
        //[SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }

        /// <summary>
        /// 车位编号(自定义)
        /// </summary>
        private string _parkingname;
        //[SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string parkingname
        {
            get { return _parkingname; }
            set { _parkingname = value; }
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
        private string _magicid;

        public string magicid
        {
            get { return _magicid; }
            set { _magicid = value; }
        }
        /// <summary>
        /// 车位是否正在使用
        /// </summary>
        private int? _isbusy;

        public int? isbusy
        {
            get { return _isbusy; }
            set { _isbusy = value; }
        }
        private bool? _femaleonly;

        public bool? femaleonly
        {
            get { return _femaleonly; }
            set { _femaleonly = value; }
        }
        private string _currentcarnum;

        public string currentcarnum
        {
            get { return _currentcarnum; }
            set { _currentcarnum = value; }
        }
        /// <summary>
        /// 是隐藏车位还是显示车位
        /// </summary>
        private bool? _ishidden;

        public bool? ishidden
        {
            get { return _ishidden; }
            set { _ishidden = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        private string _addtime;

        public string addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        private string _updatetime;

        public string updatetime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }
        /// <summary>
        /// 系统操作员编号
        /// </summary>
        private string _opt_user;

        public string opt_user
        {
            get { return _opt_user; }
            set { _opt_user = value; }
        }
        private bool _flag;

        public bool flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}
