using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Job.Model
{
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class ticket_statistics
    {
        private string _operatorid;
        /// <summary>
        /// 收费员编号
        /// </summary>
        public string operatorid
        {
            get { return _operatorid; }
            set { _operatorid = value; }
        }
        private string _name;
        /// <summary>
        /// 收费员姓名
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _pson_amount;
        /// <summary>
        /// 个人领取统计
        /// </summary>
        public string pson_amount
        {
            get { return _pson_amount; }
            set { _pson_amount = value; }
        }
        private string _pson_RealMoney;
        /// <summary>
        /// 个人消耗统计
        /// </summary>
        public string pson_RealMoney
        {
            get { return _pson_RealMoney; }
            set { _pson_RealMoney = value; }
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
