using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Data.Attribute;
using ZsdDotNetLibrary.Web.BindParameter;

namespace Ims.Job.Model
{
    [DbObject("ticket_sendlist", ObjType = DbObjectAttribute.ObjectType.View)]
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class ticket_sendlist
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
        private string _operatorid;
        /// <summary>
        ///操作人员id
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
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
        private string _memo;
        /// <summary>
        /// 备注
        /// </summary>
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        private int _state;
        /// <summary>
        /// 记录状态
        /// </summary>
        public int state
        {
            get { return _state; }
            set { _state = value; }
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

    }
}
