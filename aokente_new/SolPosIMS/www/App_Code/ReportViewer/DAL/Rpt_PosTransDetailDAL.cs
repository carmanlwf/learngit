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
using ZsdDotNetLibrary.Data;

/// <summary>
///Rpt_PosTransDetailDAL 终端消费统计
/// </summary>
public class Rpt_PosTransDetailDAL
{
    public Rpt_PosTransDetailDAL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    ///终端消费统计
    /// </summary>
    /// <returns></returns>
    public static DataTable POS_TransactionCountOrder(string condition, string memo)
    {
        string sql = "select SUM(Money) AS NUMMoney  ,memo='" + memo + "' from POS_Transaction where 1=1 " + condition + "";
        DataTable dt = DataExecSqlHelper.ExecuteQuerySql(sql);
        return dt;
    }
}
