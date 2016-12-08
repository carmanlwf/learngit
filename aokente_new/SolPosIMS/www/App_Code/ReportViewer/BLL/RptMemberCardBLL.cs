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
using Ims.Card.Model;
using System.Collections.Generic;
using ZsdDotNetLibrary.Project.DAL;

/// <summary>
///RptMemberCardBLL 的摘要说明
/// </summary>
public class RptMemberCardBLL
{
    public RptMemberCardBLL()
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
        return RptMemberCardDAL.GetMemberCardList();
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
        int pageSize = GetObjectsCount(o);
        if (string.IsNullOrEmpty(sortedBy))
            sortedBy = "LastSaleTime DESC";
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
