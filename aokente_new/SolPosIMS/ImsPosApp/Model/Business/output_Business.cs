using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.Model
{
    public class output_Business:BaseModel_output
    {
        private string _RecordIDs_OK;
        /// <summary>
        /// 成功的交易凭证号
        /// </summary>
        public string RecordIDs_OK
        {
            get { return _RecordIDs_OK; }
            set { _RecordIDs_OK = value; }
        }
        //private string _BatchSnr;
        ///// <summary>
        ///// 批次号
        ///// </summary>
        //public string BatchSnr
        //{
        //    get { return _BatchSnr; }
        //    set { _BatchSnr = value; }
        //}
        //private string _CredenceSnr;
        ///// <summary>
        ///// 交易凭证号
        ///// </summary>
        //public string CredenceSnr
        //{
        //    get { return _CredenceSnr; }
        //    set { _CredenceSnr = value; }
        //}
        //private string _ReCredenceSnr;
        ///// <summary>
        ///// 返回的交易凭证号
        ///// </summary>
        //public string ReCredenceSnr
        //{
        //    get { return _ReCredenceSnr; }
        //    set { _ReCredenceSnr = value; }
        //}
        //private string _CradSnr;
        ///// <summary>
        ///// 车牌号
        ///// </summary>
        //public string CradSnr
        //{
        //    get { return _CradSnr; }
        //    set { _CradSnr = value; }
        //}
        //private string _UserID;
        ///// <summary>
        ///// 操作员号
        ///// </summary>
        //public string UserID
        //{
        //    get { return _UserID; }
        //    set { _UserID = value; }
        //}
        //private string _Money;
        ///// <summary>
        ///// 扣款金额
        ///// </summary>
        //public string Money
        //{
        //    get { return _Money; }
        //    set { _Money = value; }
        //}
        //private string _Balance;
        ///// <summary>
        ///// 账户余额
        ///// </summary>
        //public string Balance
        //{
        //    get { return _Balance; }
        //    set { _Balance = value; }
        //}
        //private string _Intergral;
        ///// <summary>
        ///// 积分
        ///// </summary>
        //public string Intergral
        //{
        //    get { return _Intergral; }
        //    set { _Intergral = value; }
        //}
        //private string _TotalInterger;
        ///// <summary>
        ///// 累积积分
        ///// </summary>
        //public string TotalInterger
        //{
        //    get { return _TotalInterger; }
        //    set { _TotalInterger = value; }
        //}
        //private string _ShopeCode;
        ///// <summary>
        ///// 路段代码
        ///// </summary>
        //public string ShopeCode
        //{
        //    get { return _ShopeCode; }
        //    set { _ShopeCode = value; }
        //}
        //private string _ShopeName;
        ///// <summary>
        ///// 路段名称
        ///// </summary>
        //public string ShopeName
        //{
        //    get { return _ShopeName; }
        //    set { _ShopeName = value; }
        //}
        //private string _ServerWasterSnr;
        ///// <summary>
        ///// 服务器流水号
        ///// </summary>
        //public string ServerWasterSnr
        //{
        //    get { return _ServerWasterSnr; }
        //    set { _ServerWasterSnr = value; }
        //}
        //private string _ExpDate;
        ///// <summary>
        ///// 过期日期
        ///// </summary>
        //public string ExpDate
        //{
        //    get { return _ExpDate; }
        //    set { _ExpDate = value; }
        //}
        //private string _Mode;
        ///// <summary>
        ///// 停车状态(0/1)
        ///// </summary>
        //public string Mode
        //{
        //    get { return _Mode; }
        //    set { _Mode = value; }
        //}
        //private string _RecordType;
        ///// <summary>
        ///// 记录类型
        ///// </summary>
        //public string RecordType
        //{
        //    get { return _RecordType; }
        //    set { _RecordType = value; }
        //}
        //private string _CardType;
        ///// <summary>
        ///// 车辆类型
        ///// </summary>
        //public string CardType
        //{
        //    get { return _CardType; }
        //    set { _CardType = value; }
        //}
        //private string _Remark;
        ///// <summary>
        ///// 备注
        ///// </summary>
        //public string Remark
        //{
        //    get { return _Remark; }
        //    set { _Remark = value; }
        //}
    }
}
