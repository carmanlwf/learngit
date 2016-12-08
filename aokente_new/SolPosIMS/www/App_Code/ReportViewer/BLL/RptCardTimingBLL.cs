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
///RptCardTimingBLL 计时消费统计
/// </summary>
public class RptCardTimingBLL
{
    public RptCardTimingBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    ///计时消费统计
    /// </summary>
    /// <returns></returns>
    public static DataTable CardTimingCountOrder(string condition, string memo)
    {
        return RptCardTimingDAL.CardTimingCountOrder(condition, memo);
    }
}
