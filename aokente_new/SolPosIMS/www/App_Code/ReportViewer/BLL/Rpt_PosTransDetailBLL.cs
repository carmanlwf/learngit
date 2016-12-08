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
///Rpt_PosTransDetailBLL ///终端消费统计
/// </summary>
public class Rpt_PosTransDetailBLL
{
    public Rpt_PosTransDetailBLL()
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
       return  Rpt_PosTransDetailDAL.POS_TransactionCountOrder(condition, memo);
    }
}
