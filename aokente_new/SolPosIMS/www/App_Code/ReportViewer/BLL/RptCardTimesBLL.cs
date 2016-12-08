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
///RptCardTimesBLL 的摘要说明
/// </summary>
public class RptCardTimesBLL
{
    public RptCardTimesBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    ///计次消费统计
    /// </summary>
    /// <returns></returns>
    public static DataTable CardTimesCountOrder(string condition, string memo)
    {
        return RptCardTimesDAL.CardTimesCountOrder(condition, memo);
    }
}
