using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Card.Model
{
    
  /// <summary>
    /// 卡账户操作日志文件
    /// </summary>
    [Serializable]

    [DbObject("v_card_chargelist_area", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_card_chargelist_area
    {

        public string regionid { get; set; }
        public string id { get; set; }  
        public string areacode { get; set; }

        private string _TransId;//交易编号
        /// <summary>
        /// 交易编号
        /// </summary>
        [DataField(IsKey = true)]
        [InitListControl("", "transId", "transId", "v_card_chargelist", "transId")]
        [BindQueryStringParameter("getcode", ParamUsage = BindParameterUsage.OpQueryKey)]
        [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.BindToObjectAndParameter)]
        public string transId
        {
            get { return _TransId; }
            set { _TransId = value; }
        }

        string _Card = null;
        /// <summary>
        /// 会员号
        /// </summary>
        public string Card
        {
            get { return _Card; }
            set { _Card = value; }
        }
        private string _typename;//转账类型
        /// <summary>
        /// 卡类型
        /// </summary>
        public string cardtype
        {
            get { return _typename; }
            set { _typename = value; }
        }
        decimal? _Amount;
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal? amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        int? _gift;
        /// <summary>
        /// 赠送金额
        /// </summary>
        public int? gift
        {
            get { return _gift; }
            set { _gift = value; }
        }

       public string _Chargetype;

        public string Chargetype {
            get { return _Chargetype; }
            set { _Chargetype = value; }
        }
        public string _chargeway;
        /// <summary>
        /// 操作方式（1：现金；2：刷卡3:预付款;4在线交易）
        /// </summary>
        public string chargeway
        {
            get { return _chargeway; }
            set { _chargeway = value; }
        }

        string _RuleName;
        public string Rulename {
            get { return _RuleName; }
            set { _RuleName = value; }
        }

        string _Logtime;
        public string Logtime
        {
            get { return _Logtime; }
            set { _Logtime = value; }
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

        
        string _operid;
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string operid
        {
            get { return _operid; }
            set { _operid = value; }
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
