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
///Rpt_PosTransDetail 终端消费统计
/// </summary>
public class Rpt_PosTransDetail
{
    public Rpt_PosTransDetail()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    string _NUMMoney;
    /// <summary>
    /// 积分统计
    /// </summary>
    [RptColumnName("终端消费金额统计")]
    public string NUMMoney
    {
        get { return _NUMMoney; }
        set { _NUMMoney = value; }
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
