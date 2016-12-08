using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///RptCardRechargeHistory 卡片充值统计
/// </summary>
public class RptCardRechargeHistory
{
    public RptCardRechargeHistory()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    string _NUMBalance;
    /// <summary>
    /// 卡片充值金额统计
    /// </summary>
    [RptColumnName("卡片充值金额统计")]
    public string NUMBalance
    {
        get { return _NUMBalance; }
        set { _NUMBalance = value; }
    }

    string _memo;
    /// <summary>
    /// 统计条件
    /// </summary>
    [RptColumnName("统计条件")]
    public string memo
    {
        get { return _memo; }
        set { _memo = value; }
    }
}
