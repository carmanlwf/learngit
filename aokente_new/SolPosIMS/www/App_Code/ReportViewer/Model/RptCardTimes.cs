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
///RptCardTimes 计次消费统计
/// </summary>
public class RptCardTimes
{
    public RptCardTimes()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    string _NUMMoney;
    /// <summary>
    /// 消费金额
    /// </summary>
    [RptColumnName("消费金额")]
    public string NUMMoney
    {
        get { return _NUMMoney; }
        set { _NUMMoney = value; }
    }

    string _NUMTimes;
    /// <summary>
    /// 消费次数
    /// </summary>
    [RptColumnName("消费次数")]
    public string NUMTimes
    {
        get { return _NUMTimes; }
        set { _NUMTimes = value; }
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
