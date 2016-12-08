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
///Rpt_CardRechargeHistoryDAL 的摘要说明
/// </summary>
public class Rpt_CardRechargeHistoryDAL
{
    public Rpt_CardRechargeHistoryDAL()
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
        string sql = "select SUM(balance) AS NUMBalance  ,memo='" + memo + "' from v_CardRechargeHistory  where 1=1  " + condition + "";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
        return dt;
    }
}
