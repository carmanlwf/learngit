using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{

   // <summary>
    /// 卡账户操作日志文件
    /// </summary>
    [Serializable]
    [DbObject("card_chargestatics", ObjType = DbObjectAttribute.ObjectType.Table)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class card_chargestatics
    {
        private string _serialid;//交易编号
        /// <summary>
        /// 编号
        /// </summary>
        [DataField(IsKey = true)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string serialid
        {
            get { return _serialid; }
            set { _serialid = value; }
        }

        string _starttime;
        /// <summary>
        /// 上班时间
        /// </summary>
        public string starttime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }
        private string _endtime;
        /// <summary>
        /// 下班时间
        /// </summary>
        public string endtime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }
        int? _ZCCount;
        /// <summary>
        /// 累计充值笔数
        /// </summary>
        public int? ZCCount
        {
            get { return _ZCCount; }
            set { _ZCCount = value; }
        }

        decimal? _ZCMoney;
        /// <summary>
        /// 累计充值金额
        /// </summary>
        public decimal? ZCMoney
        {
            get { return _ZCMoney; }
            set { _ZCMoney = value; }
        }

        int? _KCount;
        /// <summary>
        /// 累计退款笔数
        /// </summary>
        public int? KCount
        {
            get { return _KCount; }
            set { _KCount = value; }
        }
        decimal? _KMoney;
        /// <summary>
        /// 累计退款金额
        /// </summary>
        public decimal? KMoney
        {
            get { return _KMoney; }
            set { _KMoney = value; }
        }

        decimal? _SumMoney;
        /// <summary>
        /// 累计金额
        /// </summary>
        public decimal? SumMoney
        {
            get { return _SumMoney; }
            set { _SumMoney = value; }
        }
        int? _VipCount;
        /// <summary>
        /// 累计充值张数（会员）
        /// </summary>
        public int? VipCount
        {
            get { return _VipCount; }
            set { _VipCount = value; }
        }
        decimal? _VipAmount;
        /// <summary>
        /// 累计金额（会员）
        /// </summary>
        public decimal? VipAmount
        {
            get { return _VipAmount; }
            set { _VipAmount = value; }
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
        //以下查询用
        private string _OperateDate1;
        private string _OperateDate2;

        [DataField("logtime", OnlyQuery = true)]
        [SqlField("<=")]
        public string OperateDate2
        {
            get { return _OperateDate2; }
            set { _OperateDate2 = value; }
        }

        [DataField("logtime", OnlyQuery = true)]
        [SqlField(">=")]
        public string OperateDate1
        {
            get { return _OperateDate1; }
            set { _OperateDate1 = value; }
        }
        private string _logtime;
        public string logtime
        {
            get { return _logtime; }
            set { _logtime = value; }
        }
        bool _flag;
        /// <summary>
        /// 有效状态
        /// </summary>
        public bool flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
    }
}

