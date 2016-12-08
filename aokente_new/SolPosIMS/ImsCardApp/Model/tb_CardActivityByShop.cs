using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    [DbObject("tb_CardActivityByShop", ObjType = DbObjectAttribute.ObjectType.Table)]
    [DbObject("v_card_CardActivityByShop", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class tb_CardActivityByShop
    {
        ///// <summary>
        ///// 卡操作日志文件
        ///// </summary>
        //private string _id;//序号
        ///// <summary>
        ///// 序号
        ///// </summary>
        //[DataField(FieldName = "id", IsIdentity = true, IsKey = true, IsNullable = false)]
        //public string id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}
        string _card;
        /// <summary>
        /// 卡号
        /// </summary>
        [DataField(IsKey = true)]
        public string card
        {
            get { return _card; }
            set { _card = value; }
        }
        string _siteid;
        /// <summary>
        /// 分店编号
        /// </summary>
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        int? _status;
        /// <summary>
        /// 过期状态 0:临时激活 1:已过期 2:使用中
        /// </summary>
        public int? status
        {
            get { return _status; }
            set { _status = value; }
        }
        string _activityway;
        /// <summary>
        /// 激活方式：终端和在线
        /// </summary>
        public string activityway
        {
            get { return _activityway; }
            set { _activityway = value; }
        }
        string _statuname;
        /// <summary>
        /// 有效状态名称
        /// </summary>
        public string statuname
        {
            get { return _statuname; }
            set { _statuname = value; }
        }
        string _operatorid;
        /// <summary>
        /// 操作员id  
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        string _sitename;
        /// <summary>
        /// 分店名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        string _rankname;
        /// <summary>
        /// 等级名称
        /// </summary>
        public string rankname
        {
            get { return _rankname; }
            set { _rankname = value; }
        }
        double? _balance;
        /// <summary>
        /// 账户金额
        /// </summary>
        public double? balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        double? _initvalue;
        /// <summary>
        /// 初始卡金额
        /// </summary>
        public double? initvalue
        {
            get { return _initvalue; }
            set { _initvalue = value; }
        }
        string _memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        string _activitydate;
        /// <summary>
        /// 激活时间
        /// </summary>
        public string activitydate
        {
            get { return _activitydate; }
            set { _activitydate = value; }
        }
        string _logtime;
        /// <summary>
        /// 记录时间
        /// </summary>
        public string logtime
        {
            get { return _logtime; }
            set { _logtime = value; }
        }
        string _addeddate;
        /// <summary>
        /// 发卡时间
        /// </summary>
        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }
        string _operate_date_begin;
        /// <summary>
        /// 起始时间
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "activitydate")]
        [BindControlParameter("operate_date_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_begin
        {
            get { return _operate_date_begin; }
            set { _operate_date_begin = value; }
        }

        string _operate_date_end;
        /// <summary>
        /// 截止时间
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "activitydate")]
        [BindControlParameter("operate_date_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string operate_date_end
        {
            get { return _operate_date_end; }
            set { _operate_date_end = value; }
        }
        private bool? _flag1;
        public bool? flag1
        {
            set { _flag1 = value; }
            get { return _flag1; }
        }
        //------------------------2011-9-20-----------------
        string _areacode;
        /// <summary>
        /// 区域代号
        /// </summary>
        public string areacode
        {
            get { return _areacode; }
            set { _areacode = value; }
        }

        string _areaname;
        /// <summary>
        /// 区域名称
        /// </summary>
        public string areaname
        {
            get { return _areaname; }
            set { _areaname = value; }
        }

        //------------------------2011-9-20-----------------
    }
}