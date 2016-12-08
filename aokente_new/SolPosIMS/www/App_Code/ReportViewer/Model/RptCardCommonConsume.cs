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
///RptCardCommonConsume 快速消费统计
/// </summary>
public class RptCardCommonConsume
{
    public RptCardCommonConsume()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    string _NUMBalance;
    /// <summary>
    /// 充值金额
    /// </summary>
    [RptColumnName("应消费金额")]
    public string NUMBalance
    {
        get { return _NUMBalance; }
        set { _NUMBalance = value; }
    }

    string _NUMRealbalance;
    /// <summary>
    /// 实充金额
    /// </summary>
    [RptColumnName("实消费金额")]
    public string NUMRealbalance
    {
        get { return _NUMRealbalance; }
        set { _NUMRealbalance = value; }
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
