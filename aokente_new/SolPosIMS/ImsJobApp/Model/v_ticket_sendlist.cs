using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Job.Model
{
    [DbObject("v_ticket_sendlist", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class v_ticket_sendlist
    {
        private string _tid;
        /// <summary>
        /// 记录编号
        /// </summary>
        public string tid
        {
            get { return _tid; }
            set { _tid = value; }
        }
        private decimal? _amount;
        /// <summary>
        /// 发放总额
        /// </summary>
        public decimal? amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        private string _receiverid;
        /// <summary>
        /// 接收人id
        /// </summary>
        public string receiverid
        {
            get { return _receiverid; }
            set { _receiverid = value; }
        }
        private string _receiver;
        /// <summary>
        /// 接收人name
        /// </summary>
        public string receiver
        {
            get { return _receiver; }
            set { _receiver = value; }
        }
        private string _agentid;
        /// <summary>
        /// 平台操作员id
        /// </summary>
        public string agentid
        {
            get { return _agentid; }
            set { _agentid = value; }
        }
        private string _receivername;
        /// <summary>
        /// 接收人name
        /// </summary>
        public string receivername
        {
            get { return _receivername; }
            set { _receivername = value; }
        }
        private string _memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private int? _state;
        /// <summary>
        /// 记录状态
        /// </summary>
        public int? state
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _statename;
        /// <summary>
        /// 状态名称
        /// </summary>
        public string statename
        {
            get { return _statename; }
            set { _statename = value; }
        }
        private string _addeddate;
        /// <summary>
        /// 发放日期
        /// </summary>
        public string addeddate
        {
            get { return _addeddate; }
            set { _addeddate = value; }
        }
        private bool? _flag;
        /// <summary>
        /// 标志
        /// </summary>
        public bool? flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        private string _addeddate_begin;
        /// <summary>
        /// 交易时间(开始)
        /// </summary>
        [SqlField(QueryOperator = ">=", FieldFormatString = "addeddate")]
        [BindControlParameter("addeddate_begin", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string addeddate_begin
        {
            get { return _addeddate_begin; }
            set { _addeddate_begin = value; }
        }
        private string _addeddate_end;
        /// <summary>
        /// 发放时间(结束)
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "addeddate")]
        [BindControlParameter("addeddate_end", "Value", ParamUsage = BindParameterUsage.OpQuery)]
        public string addeddate_end
        {
            get { return _addeddate_end; }
            set { _addeddate_end = value; }
        }
    }
}
