using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    [DbObject("card_chargerule", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class card_chargerule
    {
        string _ruleid;
        string _rulename;
        int? _amount;
        int? _gift;
        string _opeid;
        string _addeddate;
        private bool? _flag;
        /// <summary>
        /// 
        /// </summary>
        /// 
        [DataField(IsKey = true)]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string ruleid
        {
            set { _ruleid = value; }
            get { return _ruleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [SqlField("like", AfterLike = "%", BeforeLike = "%")]
        public string rulename
        {
            set { _rulename = value; }
            get { return _rulename; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? gift
        {
            set { _gift = value; }
            get { return _gift; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string opeid
        {
            set { _opeid = value; }
            get { return _opeid; }
        }

        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }
        //以下查询用
        private string _addeddate1;
        private string _addeddate2;

        [DataField("addeddate", OnlyQuery = true)]
        [SqlField("<=")]
        public string addeddate2
        {
            get { return _addeddate2; }
            set { _addeddate2 = value; }
        }

        [DataField("addeddate", OnlyQuery = true)]
        [SqlField(">=")]
        public string addeddate1
        {
            get { return _addeddate1; }
            set { _addeddate1 = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
    }
}
