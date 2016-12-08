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
///RptConsumePointBLL 消费积分统计
/// </summary>
public class RptConsumePointBLL
{
    public RptConsumePointBLL()
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
        return RptConsumePointDAL.MemberCountOrder(condition,memo);
    }
}
