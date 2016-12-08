using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ZsdDotNetLibrary.Data;

/// <summary>
///RptMemberInfoDAL 的摘要说明
/// </summary>
public class RptMemberInfoDAL
{
    public RptMemberInfoDAL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 获取会员信息
    /// </summary>
    /// <returns></returns>
    public static DataTable GetMemberInfoList()
    {
        string strSql = "select userid,realname,sex,points,cellphone,addeddate from tb_Member";
        return DataExecSqlHelper.ExecuteQuerySql(strSql);
    }
}
