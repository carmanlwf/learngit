using System;
using System.Collections.Generic;
using System.Text;

namespace Ims.Card.Model.MonthlyCard
{
    public class MonthlyCardCreate
    {
        string _carnum;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string carnum
        {
            get { return _carnum; }
            set { _carnum = value; }
        }
        string _realname;
        /// <summary>
        /// 姓名
        /// </summary>
        public string realname
        {
            get { return _realname; }
            set { _realname = value; }
        }
        int? _sex;
        /// <summary>
        /// 性别
        /// </summary>
        public int? sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        string _cellphone;
        /// <summary>
        /// 手机号
        /// </summary>
        public string cellphone
        {
            get { return _cellphone; }
            set { _cellphone = value; }
        }
        string _typeid;
        /// <summary>
        /// 类别编号
        /// </summary>
        public string typeid
        {
            get { return _typeid; }
            set { _typeid = value; }
        }
        decimal? _balance;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        decimal? _monthlyamount;
        /// <summary>
        /// 本次开月卡金额
        /// </summary>
        public decimal? monthlyamount
        {
            get { return _monthlyamount; }
            set { _monthlyamount = value; }
        }
        string _uptotime;
        /// <summary>
        /// 截至日期
        /// </summary>
        public string uptotime
        {
            get { return _uptotime; }
            set { _uptotime = value; }
        }
        string _supportSites;
        /// <summary>
        /// 支持的站点
        /// </summary>
        public string supportSites
        {
            get { return _supportSites; }
            set { _supportSites = value; }
        }

        string _Sections;
        //是否是所有路段
        public string Sections
        {
            get { return _Sections; }
            set { _Sections = value; }
        }
    }
}
