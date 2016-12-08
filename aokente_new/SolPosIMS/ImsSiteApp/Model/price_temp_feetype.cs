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
    [DbObject("price_temp_feetype", ObjType = DbObjectAttribute.ObjectType.Table)]
    //[DbObject("v_product_ProductInfo", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class price_temp_feetype
    {
        private string _pid;
        [DataField(IsKey = true)]
        [InitListControl("", "Pid", "Pid", "price_temp_feetype", "Pid")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        private string _pname;
        public string Pname
        {
            get { return _pname; }
            set { _pname = value; }
        }
        private string _spid;
        public string Spid
        {
            get { return _spid; }
            set { _spid = value; }
        }
        private int? _cartype;
        public int? Cartype
        {
            get { return _cartype; }
            set { _cartype = value; }
        }
        private decimal? _minPayment;
        public decimal? MinPayment
        {
            get { return _minPayment; }
            set { _minPayment = value; }
        }
        private decimal? _normalChargingPrice;
        public decimal? NormalChargingPrice
        {
            get { return _normalChargingPrice; }
            set { _normalChargingPrice = value; }
        }
        private int? _normalChargingTimeSeg;
        public int? NormalChargingTimeSeg
        {
            get { return _normalChargingTimeSeg; }
            set { _normalChargingTimeSeg = value; }
        }
        private decimal? _maxPayment;
        public decimal? MaxPayment
        {
            get { return _maxPayment; }
            set { _maxPayment = value; }
        }

        private int? _firstChargingTimeSeg;
        public int? FirstChargingTimeSeg
        {
            get { return _firstChargingTimeSeg; }
            set { _firstChargingTimeSeg = value; }
        }

        private int? _freeTimeSeg;
        /// <summary>
        /// 休息时间
        /// </summary>
        public int? FreeTimeSeg
        {
            get { return _freeTimeSeg; }
            set { _freeTimeSeg = value; }
        }
        private bool? _chargeByTimes;
        /// <summary>
        /// 是否休息时间
        /// </summary>
        public bool? ChargeByTimes
        {
            get { return _chargeByTimes; }
            set { _chargeByTimes = value; }
        }

        private string _memo;
        /// <summary>
        /// 标准
        /// </summary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
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
        private string _siteName;
        /// <summary>
        /// 停车区域
        /// </summary>
        public string SiteName
        {
            get { return _siteName; }
            set { _siteName = value; }
        }

    }
}
