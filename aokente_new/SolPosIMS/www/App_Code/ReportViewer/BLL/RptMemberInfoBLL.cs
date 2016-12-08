using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Ims.Member.Model;
using ZsdDotNetLibrary.Project.DAL;

 

/// <summary>
///RptMemberInfoBLL 的摘要说明
/// </summary>
public class RptMemberInfoBLL
{
    public RptMemberInfoBLL()
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
        return RptMemberInfoDAL.GetMemberInfoList();
    }
    /// <summary>
    /// 多个对象
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="sortedBy"></param>
    /// <param name="o"></param>
    /// <returns></returns>
    public static List<tb_Member> GetPagedObjects(int startIndex, string sortedBy, tb_Member o)
    {
        o.flag = true;
        int pageSize = GetObjectsCount(o);
        if (string.IsNullOrEmpty(sortedBy))
            sortedBy = "addeddate desc";
        List<tb_Member> objects = ObjectData.GetPagedObjects<tb_Member>(startIndex, pageSize, sortedBy, o, "v_member_MemberInfo", true);
        return objects;
    }
    /// <summary>
    /// 记录行数
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public static int GetObjectsCount(tb_Member o)
    {
        return ObjectData.GetObjectsCount(o, "v_member_MemberInfo");
    }
}
