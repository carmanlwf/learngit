using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Site.Model
{
    /// <summary>
    /// 终端管理
    /// </summary>
    [DbObject("pos_poslist", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_pos_poslistinfo", ObjType = DbObjectAttribute.ObjectType.View)]

    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class pos_poslist
    {
       
        private string _posnum;
        [DataField(IsKey = true)]
        [InitListControl("", "posnum", "posnum", "posnum", "posnum")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string posnum
        {
            get { return _posnum; }
            set { _posnum = value; }
        }
        private string _postype;

        public string postype
        {
            get { return _postype; }
            set { _postype = value; }
        }
        private string _productno;

        public string productno
        {
            get { return _productno; }
            set { _productno = value; }
        }
        private string _lat;

        public string lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        private string _lon;

        public string lon
        {
            get { return _lon; }
            set { _lon = value; }
        }
        [DataField("lastactiontime", OnlyQuery = true)]
        [SqlField("<=")]
        private string _lastactiontime;

        public string lastactiontime
        {
            get { return _lastactiontime; }
            set { _lastactiontime = value; }
        }
        private string _lastip;

        public string lastip
        {
            get { return _lastip; }
            set { _lastip = value; }
        }
        private int? _isaction;

        public int? isaction
        {
            get { return _isaction; }
            set { _isaction = value; }
        }
        [DataField("addedtime", OnlyQuery = true)]
        [SqlField(">=")]
        private string _addedtime;

        public string addedtime
        {
            get { return _addedtime; }
            set { _addedtime = value; }
        }
        private string _opt_user;

        public string opt_user
        {
            get { return _opt_user; }
            set { _opt_user = value; }
        }
        private string _siteid;

        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        private bool? _flag;

        public bool? flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}
