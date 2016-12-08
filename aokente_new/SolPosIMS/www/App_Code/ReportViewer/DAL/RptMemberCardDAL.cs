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
///RptMemberCardDAL 的摘要说明
/// </summary>
public class RptMemberCardDAL
{
    public RptMemberCardDAL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 获取会员信息
    /// </summary>
    /// <returns></returns>
    public static DataTable GetMemberCardList()
    {
        string strSql = "select a.userid,a.[card],b.realname,a.balance,c.TypeName,a.addeddate,a.initvalue,a.LastSaleTime,a.[status],case a.[status] when 0 then '未激活' when 1 then '正常' when 2 then '挂失' when 3 then '销卡' when 4 then '补卡' end as statusname from tb_Card as a inner join tb_Member as b on a.userid = b.UserId left join tb_CardType as c on a.TypeID = c.TypeID";
        return DataExecSqlHelper.ExecuteQuerySql(strSql);
    }
}
