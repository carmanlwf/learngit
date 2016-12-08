using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Utility 的摘要说明
/// </summary>
public class Utility
{
    public Utility()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 验证cookies有效性(用户登录状态判断)
    /// </summary>
    /// <returns></returns>
    public static bool CheckUserLogin()
    {
        if (HttpContext.Current.Session["myTicket"] != null && HttpContext.Current.Session["TicketName"] != null)
        {
            string CookiesName = HttpContext.Current.Session["TicketName"].ToString();
            string UserCookiesValue = HttpContext.Current.Session["myTicket"].ToString();
            string CookiesValue = string.Empty;
            if (HttpContext.Current.Request.Cookies[CookiesName] != null)
            {
                CookiesValue = HttpContext.Current.Request.Cookies[CookiesName].Value;//ticket 内容
                if (!string.IsNullOrEmpty(CookiesValue) && CookiesValue == UserCookiesValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //*************************************分页*********************
    /// <summary>
    /// 分页记录数
    /// </summary>
    /// <param name="TableOrView"></param>
    /// <returns></returns>
    public static int PageRecordCount(string TableOrView, string Where)
    {
        string strSQL = "select count(1) from " + TableOrView +"  Where  "+ Where;
        DataTable dt = SQLHelper.Query(strSQL).Tables[0];
        int count = Convert.IsDBNull(dt.Rows[0][0]) ? 0 : Convert.ToInt32(dt.Rows[0][0]);
        return count;
    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="TableOrView">表 视图</param>
    /// <param name="pagesize">每页显示条数</param>
    /// <param name="pageindex">当前页</param>
    /// <returns>DataSet分页</returns>
    public static DataSet DsPageHelp(string TableOrView, int pagesize, int pageindex, string Where, string order)
    {
        string strSQL = "";
        if (order != "")
        {
            strSQL = "select top(" + pagesize + ") * from (select row_number()over(ORDER BY " + order + ") as asp_net_rownum ,* from " + TableOrView + " WHERE " + Where + ")  as A where A.asp_net_rownum not in (select top (" + (pageindex - 1) * pagesize + ") B.asp_net_rownum from (select row_number()over(ORDER BY " + order + ") as asp_net_rownum from " + TableOrView + " WHERE " + Where + ")  as B order by B.asp_net_rownum desc) order by A.asp_net_rownum desc ";
        }
        else
        {
            strSQL = "select top(" + pagesize + ") * from (select row_number()over(ORDER BY getdate()) as asp_net_rownum ,* from " + TableOrView + " WHERE " + Where + ")  as A where A.asp_net_rownum not in (select top (" + (pageindex - 1) * pagesize + ") B.asp_net_rownum from (select row_number()over(ORDER BY getdate()) as asp_net_rownum from " + TableOrView + " WHERE " + Where + ")  as B order by B.asp_net_rownum desc) order by A.asp_net_rownum desc";

        }
        DataSet ds = SQLHelper.Query(strSQL);
        return ds;
    }
    ///// <summary>
    ///// 数据缓存依赖项分页
    ///// </summary>
    ///// <param name="TableOrView">表 视图</param>
    ///// <param name="pagesize">每页显示条数</param>
    ///// <param name="pageindex">当前页</param>
    ///// <returns>DataSet分页</returns>
    //public static DataTable CacheDsPageHelp(string TableOrView, int pagesize, int pageindex)
    //{
    //    string strSQL = "select top(" + pagesize + ") * from (select row_number()over(ORDER BY getdate()) as asp_net_rownum ,* from " + TableOrView + ")  as A where A.asp_net_rownum not in (select top (" + pageindex - 1 + ") B.asp_net_rownum from (select row_number()over(ORDER BY getdate()) as asp_net_rownum from " + TableOrView + ")  as B order by B.asp_net_rownum) order by A.asp_net_rownum";
    //    DataTable dt = SQLHelper.Query(strSQL).Tables[0];
    //    Cache.Insert("data", dt, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration);
    //    return Cache["data"] as DataTable;
    //}
}
