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
///RptConsumePointDAL 消费积分统计
/// </summary>
public class RptConsumePointDAL
{
    public RptConsumePointDAL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    ///会员积分与余额统计
    /// </summary>
    /// <returns></returns>
    public static DataTable MemberCountOrder(string condition,string memo)
    {
        string sql = "select SUM(balance) AS NUMbalance ,SUM(Points) AS NUMPoints ,memo='" + memo + "' from v_card_MemberCardInfo  where 1=1  " + condition + "";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
        return dt;
    }
}
