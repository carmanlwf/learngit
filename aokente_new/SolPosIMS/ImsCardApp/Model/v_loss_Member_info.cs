using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Card.Model
{
    /// <summary>
    /// 会员流失信息
    /// </summary>
    [DbObject(" v_loss_Member_info", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]

  public   class v_loss_Member_info
    {
        #region Model
        private string _card;
        private string _realname;
        private string _sitename;
        private int? _status;
        private string _areaname;
        private string _name;
        private string _datetime1;
        private bool? _flag;
        private string _areacode;
        private string _regionid;
        /// <summary>
        /// 
        /// </summary>
        public string card
        {
            set { _card = value; }
            get { return _card; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sitename
        {
            set { _sitename = value; }
            get { return _sitename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areaname
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Datetime1
        {
            set { _datetime1 = value; }
            get { return _datetime1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areacode
        {
            set { _areacode = value; }
            get { return _areacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string regionid
        {
            set { _regionid = value; }
            get { return _regionid; }
        }

        int? _monthquantry;
        /// <summary>
        /// 操作截止时间
        /// </summary>
      [SqlField(QueryOperator = ">=", FieldFormatString = "monthquantry")]
      [BindControlParameter("monthquantry", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public int? monthquantry
        {
            get { return _monthquantry; }
            set { _monthquantry = value; }
        }
        #endregion Model

    }
}
