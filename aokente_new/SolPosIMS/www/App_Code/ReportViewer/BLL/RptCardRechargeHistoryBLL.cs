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
///RptCardRechargeHistoryBLL 卡片充值统计
/// </summary>
public class RptCardRechargeHistoryBLL
{
    public RptCardRechargeHistoryBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    ///卡片充值统计
    /// </summary>
    /// <returns></returns>
    public static DataTable CardRechargeCountOrder(string condition, string memo)
    {
        return Rpt_CardRechargeHistoryDAL.CardRechargeCountOrder(condition,memo);
    }
}
