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
using System.Data;
using ZsdDotNetLibrary.Project.DAL;
using ZsdDotNetLibrary.Data;
using Ims.Member.Model;
using System.Collections.Generic;
using Ims.Card.Model;

/// <summary>
///RptConsumePoint 客户流失统计
/// </summary>
public class RptLossMemberInfoBLL
{
    public RptLossMemberInfoBLL()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 多个对象
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortedBy"></param>
    /// <param name="o"></param>
    /// <returns></returns>
    public static List<tb_Card> GetPagedObjects(int startIndex, string sortedBy, tb_Card o)
    {
        o.Status = 1;
        int pageSize = GetObjectsCount(o);
        if (string.IsNullOrEmpty(sortedBy))
            sortedBy = "addeddate desc";
        List<tb_Card> objects = ObjectData.GetPagedObjects<tb_Card>(startIndex, pageSize, sortedBy, o, "v_card_MemberCardInfo", true);
        return objects;
    }
    /// <summary>
    /// 记录行数
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static int GetObjectsCount(tb_Card o)
    {
        return ObjectData.GetObjectsCount(o, "v_card_MemberCardInfo");
    }

}
