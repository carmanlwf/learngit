using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Pub.Model
{
    public class pub_noticeagent
    {
        public pub_noticeagent()
        { }
        #region Model
        private int? _id;
        private string _notice_id;
        private string _agent_id;
        private bool? _displayflag;
        private bool? _readflag;
        /// <summary>
        /// 
        /// </summary>
        /// 
        [DataField(IsKey = true)]
        public int? id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [BindQueryStringParameter("id", ParamUsage = BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate)]
        public string notice_id
        {
            set { _notice_id = value; }
            get { return _notice_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public string agent_id
        {
            set { _agent_id = value; }
            get { return _agent_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public bool? displayflag
        {
            set { _displayflag = value; }
            get { return _displayflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? readflag
        {
            set { _readflag = value; }
            get { return _readflag; }
        }
        #endregion Model


        #region  成员方法
        #endregion  成员方法
    }
}