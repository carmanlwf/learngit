using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Pub.Model
{
    [BindControlParameter("", "", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate)]
    public class pub_noticeinfo
    {
        public pub_noticeinfo()
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
        private string _beginvaliddate;
        /// <summary>
        /// 
        /// </summary>
        /// 
        [BindQueryStringParameter("", ParamUsage = BindParameterUsage.OpQueryKey | BindParameterUsage.OpQuery)]
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
        //[InitListControl("","subject","pub_codes")]
        public string subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpUpdate | BindParameterUsage.OpQuery)]
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [InitListControl("", "color", "pub_codes")]
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
        public string validdate
        {
            set { _validdate = value; }
            get { return _validdate; }
        }

        public string beginvaliddate
        {
            set { _beginvaliddate = value; }
            get { return _beginvaliddate; }
        }
        #endregion Model


        #region  成员方法
        #endregion  成员方法
    }
}
