using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Site.Model
{
    [DbObject("v_parkingsiteinfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_parkingsiteinfo
    {
            /// <summary>
            /// 车位管理(视图)
            /// </summary>
            private string _parkingid;
            /// <summary>
            /// //车位编号
            /// </summary>
            [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
            [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
            public string parkingid
            {
                get { return _parkingid; }
                set { _parkingid = value; }
            }
            /// <summary>
            /// 车位编号(自定义)
            /// </summary>
            private string _parkingname;
            public string parkingname
            {
                get { return _parkingname; }
                set { _parkingname = value; }
            }
            /// <summary>
            ///pos终端号
            /// </summary>
            private string _posnum;//pos终端号
            //[SqlField("like", AfterLike = "%", BeforeLike = "%")]
            public string posnum
            {
                get { return _posnum; }
                set { _posnum = value; }
            }
            /// <summary>
            ///路段编号
            /// </summary>
            private string _siteid;//路段编号
            [DataField("siteid")]
            [BindControlParameter("Site_Code", "Text", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
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
            ///区域编号
            /// </summary>
            private string _aeraid;//车位名称
            //[SqlField("like", AfterLike = "%", BeforeLike = "%")]
            [DataField("areacode")]
            public string aeraid
            {
                get { return _aeraid; }
                set { _aeraid = value; }
            }
            /// <summary>
            ///区域名称
            /// </summary>
            private string _areaname;//区域名称
            //[SqlField("like", AfterLike = "%", BeforeLike = "%")]
            public string areaname
            {
                get { return _areaname; }
                set { _areaname = value; }
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
            private string _log;

            public string log
            {
                get { return _log; }
                set { _log = value; }
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
            /// <summary>
            /// 女性车位
            /// </summary>
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
            /// 车位状态
            /// </summary>
            private string _parkingstatus;

            public string parkingstatus
            {
                get { return _parkingstatus; }
                set { _parkingstatus = value; }
            }
            /// <summary>
            /// 车位状态
            /// </summary>
            private string _parkingtype;

            public string parkingtype
            {
                get { return _parkingtype; }
                set { _parkingtype = value; }
            }
            /// <summary>
            /// 当前车牌号
            /// </summary>
            private string _parkingcarnum;

            public string parkingcarnum
            {
                get { return _parkingcarnum; }
                set { _parkingcarnum = value; }
            }
            /// <summary>
            /// 入场时间
            /// </summary>
            private string _addtime;

            public string addtime
            {
                get { return _addtime; }
                set { _addtime = value; }
            }
            /// <summary>
            /// 出场时间
            /// </summary>
            private string _updatetime;

            public string updatetime
            {
                get { return _updatetime; }
                set { _updatetime = value; }
            }
            /// <summary>
            /// 车主姓名
            /// </summary>
            private string _opt_user;
            /// <summary>
            /// 操作管理员
            /// </summary>
            public string opt_user
            {
                get { return _opt_user; }
                set { _opt_user = value; }
            }
            private bool _flag;
            /// <summary>
            /// 标志
            /// </summary>
            public bool flag
            {
                get { return _flag; }
                set { _flag = value; }
            }
            /// <summary>
            /// 感应源
            /// </summary>
            private string _updateway;

            public string updateway
            {
                get { return _updateway; }
                set { _updateway = value; }
            }
        }
}
