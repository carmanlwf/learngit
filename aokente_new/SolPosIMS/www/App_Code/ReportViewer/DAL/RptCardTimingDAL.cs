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
///RptCardTimingDAL 计时消费统计
/// </summary>
public class RptCardTimingDAL
{
    public RptCardTimingDAL()
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
        string sql = "select SUM(money) AS NUMMoney ,SUM(TotalMins) AS NUMTotalMins ,memo='" + memo + "' from v_CardTimingHistroy_Items  where 1=1   " + condition + "";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
        return dt;
    }
}
