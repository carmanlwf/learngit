using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Site.Model
{
    /// <summary>
    /// 分店（配送站）实体
    /// </summary>
    [DbObject("price_temp_sitefeelist", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_product_ProductInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class price_temp_sitefeelist
    {
        private string _spid;
        [DataField(IsKey = true)]
        [InitListControl("", "Spid", "Spid", "price_temp_sitefeelist", "Spid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Spid
        {
            get { return _spid; }
            set { _spid = value; }
        }
        private string _siteid;
        [SqlField(QueryOperator = "in")]
        public string Siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        private string _sitename;
        public string Sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
         private string _pid;
        public string Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }

        private decimal? _minPayment;
        public decimal? MinPayment
        {
            get { return _minPayment; }
            set { _minPayment = value; }
        }
        
         private string _pname;
        public string Pname
        {
            get { return _pname; }
            set { _pname = value; }
        }
 
        private string _startWorkTime;
        public string StartWorkTime
        {
            get { return _startWorkTime; }
            set { _startWorkTime = value; }
        }

        private string _endWorkTime;
        public string EndWorkTime
        {
            get { return _endWorkTime; }
            set { _endWorkTime = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _addeddate;
        public string Addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }
      
        private bool? _flag;
        /// <summary>
        /// 标志
        /// </summary>
        public bool? Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

    }
}
