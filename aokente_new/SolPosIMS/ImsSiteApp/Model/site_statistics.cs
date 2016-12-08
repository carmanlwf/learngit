using System;
using System.Collections.Generic;
using System.Text;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;

namespace Ims.Site.Model
{
    [BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
    public class site_statistics
    {
        private string _siteid;
        /// <summary>
        /// 路段编号
        /// </summary>
        public string siteid
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        private string _siteids;
        /// <summary>
        /// 路段编号(集合)
        /// </summary>
        public string siteids
        {
            get { return _siteids; }
            set { _siteids = value; }
        }
        private string _sitename;
        /// <summary>
        /// 路段名称
        /// </summary>
        public string sitename
        {
            get { return _sitename; }
            set { _sitename = value; }
        }

        private string _amount_real;
        /// <summary>
        /// 实收金额总额
        /// </summary>
        public string amount_real
        {
            get
            {
                if (string.IsNullOrEmpty(_amount_real))
                    return "0.00";
                else
                    return _amount_real;
            }
            set { _amount_real = value; }
        }
        private string _amount_receivable;
        /// <summary>
        /// 应收金额总额
        /// </summary>
        public string amount_receivable
        {
            get
            {
                if (string.IsNullOrEmpty(_amount_receivable))
                    return "0.00";
                else
                    return _amount_receivable;
            }

            set { _amount_receivable = value; }
        }
        private string _giving_amount;
        /// <summary>
        /// 押金金额总额
        /// </summary>
        public string giving_amount
        {
            get
            {
                if (string.IsNullOrEmpty(_giving_amount))
                    return "0.00";
                else
                    return _giving_amount;
            }

            set { _giving_amount = value; }
        }
        private string _returnMoney;
        /// <summary>
        /// 返回金额
        /// </summary>
        public string ReturnMoney
        {
            get
            {
                if (string.IsNullOrEmpty(_returnMoney))
                    return "0.00";
                else
                    return _returnMoney;
            }

            set { _returnMoney = value; }
        }


        private string _num;
        ///// <summary>
        ///// 充值金额
        ///// </summary>
        public string num
        {
            get
            {
                if (string.IsNullOrEmpty(_num))
                    return "0.00";
                else
                    return _num;
            }

            set { _num = value; }

        }
        // y.operatorid,y.name,x.ReturnMoney,x.amount_real,x.amount_receivable,x.giving_amount,

        private string _amount1;
        /// <summary>
        /// 充值金额
        /// </summary>
        public string amount1
        {
            get
            {
                if (string.IsNullOrEmpty(_amount1))
                    return "0.00";
                else
                    return _amount1;
            }
            set { _amount1 = value; }
        }
        private string _amount3;
        /// <summary>
        /// 充值金额
        /// </summary>
        public string amount3
        {
            get
            {
                if (string.IsNullOrEmpty(_amount3))
                    return "0";
                else
                    return _amount3;
            }
            set { _amount3 = value; }
        }

        private string _aftermoney1;
        /// <summary>
        /// 充值金额
        /// </summary>
        public string aftermoney1
        {
            get
            {
                if (string.IsNullOrEmpty(_aftermoney1))
                    return "0";
                else
                    return _aftermoney1;
            }
            set { _aftermoney1 = value; }
        }
        private string _beforemoney1;
        /// <summary>
        /// 充值金额
        /// </summary>
        public string beforemoney1
        {
            get
            {
                if (string.IsNullOrEmpty(_beforemoney1))
                    return "0";
                else
                    return _beforemoney1;
            }
            set { _beforemoney1 = value; }
        }
        private string _aftermoney;
        public string aftermoney
        {
            get
            {
                if (string.IsNullOrEmpty(_aftermoney))
                    return "0";
                else
                    return _aftermoney;
            }
            set { _aftermoney = value; }
        }
        private string _beforemoney;
        /// <summary>
        /// 充值金额
        /// </summary>
        public string beforemoney
        {
            get
            {
                if (string.IsNullOrEmpty(_beforemoney))
                    return "0";
                else
                    return _beforemoney;
            }
            set { _beforemoney = value; }
        }
        private string _beforemoney3;
        /// <summary>
        /// 充值金额
        /// </summary>
        public string beforemoney3
        {
            get
            {
                if (string.IsNullOrEmpty(_beforemoney3))
                    return "0";
                else
                    return _beforemoney3;
            }
            set { _beforemoney3 = value; }
        }
        public string _tuition;
        public string Tuition
        {
            get
            {
                if (string.IsNullOrEmpty(_tuition))
                    return "0";
                else
                    return _tuition;
            }
            set { _tuition = value; }

            //giving_amount + amount_real + 充值金额 - ReturnMoney
            //Convert.ToDecimal(amount_real) + Convert.ToDecimal(giving_amount)  + Convert.ToDecimal(amount1)  - Convert.ToDecimal(ReturnMoney);
            //decimal money = Convert.ToDecimal(aftermoney1) + Convert.ToDecimal(beforemoney3);

            //if (money <= 0)
            //    return "0.00";
            //else
            //    return money.ToString();


        }
        //x.aftermoney1,x.beforemoney1,x.beforemoney,x.aftermoney,x.amount1,x.amount3
        /// <summary>
        /// 累计实收金额
        /// </summary>
        public string _totality;
        public string Totality
        {
            get
            {
                if (string.IsNullOrEmpty(_totality))
                    return "0";
                else
                    return _totality;
            }
            set { _totality = value; }
            //giving_amount + amount_real + 充值金额 - ReturnMoney
            //Convert.ToDecimal(amount_real) + Convert.ToDecimal(giving_amount)  + Convert.ToDecimal(amount1)  - Convert.ToDecimal(ReturnMoney);
            //decimal money = Convert.ToDecimal(beforemoney1) + Convert.ToDecimal(aftermoney1) - Convert.ToDecimal(amount3) + Convert.ToDecimal(beforemoney) + Convert.ToDecimal(aftermoney);

            //if (money <= 0)
            //    return "0.00";
            //else
            //    return money.ToString();

        }
        private string _addeddate_begin;
        /// <summary>
        /// 交易时间(开始)
        /// </summary>
        [SqlField(QueryOperator = "<=", FieldFormatString = "addeddate")]
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
