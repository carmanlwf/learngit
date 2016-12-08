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
///RptItemChargeBLL 的摘要说明
/// </summary>
public class RptItemChargeBLL
{
    public RptItemChargeBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    ///充时充次统计
    /// </summary>
    /// <returns></returns>
    public static DataTable ItemChargeCountOrder(string condition, string memo)
    {
      return RptItemChargeDAL.ItemChargeCountOrder(condition, memo);
    }
}
