using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Pub.Model
{
    [DbObject("v_pub_noticeinfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "InnerText", ParamUsage = BindParameterUsage.OpQuery)]
    public class v_pub_noticeagentinfo
    {
        private string _id;
        private string _title;
        private string _subject;
        private string _content;
        private string _color;
        private bool? _boldflag;
        private bool? _rollflag;
        private string _starttime;
        private string _agentinfo_id;
        private bool? _validflag;
        private string _beginvaliddate;
        private string _validdate;
        private string _name;
        /// <summary>
        /// 
        /// </summary>
        /// 
        [BindQueryStringParameter("id", ParamUsage = BindParameterUsage.OpQuery)]
        [DataField(IsKey = true)]
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public string subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [BindControlParameter("", "", ParamUsage = BindParameterUsage.OpQuery)]
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? boldflag
        {
            set { _boldflag = value; }
            get { return _boldflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public bool? rollflag
        {
            set { _rollflag = value; }
            get { return _rollflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string starttime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agentinfo_id
        {
            set { _agentinfo_id = value; }
            get { return _agentinfo_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public bool? validflag
        {
            set { _validflag = value; }
            get { return _validflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        [SqlField(QueryOperator = ">=")]
        public string validdate
        {
            set { _validdate = value; }
            get { return _validdate; }
        }

        [SqlField(QueryOperator = "<=")]
        public string beginvaliddate
        {
            set { _beginvaliddate = value; }
            get { return _beginvaliddate; }
        }


        public string name
        {
            set { _name = value; }
            get { return _name; }
        }

        private string _agentid;
        private bool? _readflag;
        private bool? _displayflag;

        [BindSessionParameter("UserInfo", "Id", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.BindToObject)]
        [DataField(IsKey = true)]
        public string agentid
        {
            set { _agentid = value; }
            get { return _agentid; }
        }

        public bool? readflag
        {
            set { _readflag = value; }
            get { return _readflag; }
        }

        public bool? displayflag
        {
            set { _displayflag = value; }
            get { return _displayflag; }
        }
        private string orderby;

        [SqlField(IsOrderBy = true)]
        [DataField("starttime")]
        public string _orderby
        {
            set { orderby = value; }
            get { return "desc"; }
        }
    }
}
