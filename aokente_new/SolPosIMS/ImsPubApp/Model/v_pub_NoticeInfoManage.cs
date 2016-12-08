using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Pub.Model
{
    [DbObject("v_pub_noticeinfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "", ParamUsage = BindParameterUsage.OpQuery)]
    public class v_pub_NoticeInfoManage
    {
        public v_pub_NoticeInfoManage()
        { }
        #region Model
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
        private string _validdate;
        private string _name;
        /// <summary>
        /// 
        /// </summary>
        /// 
        [BindQueryStringParameter("", ParamUsage = BindParameterUsage.OpQueryKey)]
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
        //[InitListControl("", "subject", "pub_codes")]
        public string subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
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
        [BindFormParameter("")]
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
        [BindFormParameter("")]
        public bool? validflag
        {
            set { _validflag = value; }
            get { return _validflag; }
        }

        public string validdate
        {
            set { _validdate = value; }
            get { return _validdate; }
        }       /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }


        private string _beginstarttime;
        private string _endstarttime;

        /// <summary>
        /// 
        /// </summary>
        /// 
        [SqlField(QueryOperator = ">=")]
        [DataField("starttime", OnlyQuery = true)]
        public string beginstarttime
        {
            set { _beginstarttime = value; }
            get { return _beginstarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [SqlField(QueryOperator = "<=")]
        [DataField("starttime", OnlyQuery = true)]
        public string endstarttime
        {
            set { _endstarttime = value; }
            get { return _endstarttime; }
        }


        private string _startvaliddate;
        private string _endvaliddate;

        [SqlField(QueryOperator = ">=")]
        [DataField("validdate", OnlyQuery = true)]
        public string startvaliddate
        {
            set { _startvaliddate = value; }
            get { return _startvaliddate; }
        }

        [SqlField(QueryOperator = "<=")]
        [DataField("validdate", OnlyQuery = true)]
        public string endvaliddate
        {
            set { _endvaliddate = value; }
            get { return _endvaliddate; }
        }

        #endregion Model


        #region  成员方法
        #endregion  成员方法
    }
}
