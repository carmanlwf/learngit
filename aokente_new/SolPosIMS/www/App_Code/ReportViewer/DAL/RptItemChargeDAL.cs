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
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data;

/// <summary>
///RptItemChargeDAL 充时充次统计
/// </summary>
public class RptItemChargeDAL
{
    public RptItemChargeDAL()
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
        string sql = "select SUM(balance) AS NUMBalance ,SUM(realbalance) AS NUMRealbalance,SUM(chargeCount) AS NUMChargeCount ,memo='" + memo + "' from v_ItemChargeHistroy_Items where 1=1 " + condition + "";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
        return dt;
    }
}
