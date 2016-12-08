using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZsdDotNetLibrary.Web.BindParameter;
using ZsdDotNetLibrary.Data.Attribute;


/// <summary>
///RptMemberInfo 的摘要说明
/// </summary>
/// <summary>
/// 会员实体
/// </summary>
//[DbObject("tb_Member", ObjType = DbObjectAttribute.ObjectType.Table)]
[DbObject("v_member_MemberInfo", ObjType = DbObjectAttribute.ObjectType.View)]
[BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
public class RptMemberInfo
{
    public RptMemberInfo()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    string _userid;
    /// <summary>
    /// 用户编号
    /// </summary>
    [RptColumnName("用户编号")]
    public string userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    string _realname;
    /// <summary>
    /// 用户姓名
    /// </summary>
    [RptColumnName("用户姓名")]
    public string realname
    {
        get { return _realname; }
        set { _realname = value; }
    }
    private string _sitename;//
    /// <summary>
    /// 分店名称
    /// </summary>
    [RptColumnName("分店名称")]
    public string sitename
    {
        get { return _sitename; }
        set { _sitename = value; }
    }

    //private string _areaname;//
    ///// <summary>
    ///// 区域名称
    ///// </summary>
    //[RptColumnName("区域名称")]
    //public string areaname
    //{
    //    get { return _areaname; }
    //    set { _areaname = value; }
    //}

    string _sex;
    /// <summary>
    /// 用户姓名
    /// </summary>
    [RptColumnName("性别")]
    public string sex
    {
        get { return _sex; }
        set { _sex = value; }
    }
    string _points;
    /// <summary>
    /// 积分
    /// </summary>
    [RptColumnName("积分")]
    public string points
    {
        get { return _points; }
        set { _points = value; }
    }
    string _cellphone;
    /// <summary>
    /// 手机
    /// </summary>
    [RptColumnName("手机")]
    public string cellphone
    {
        get { return _cellphone; }
        set { _cellphone = value; }
    }

    string _addeddate;
    /// <summary>
    /// 注册时间
    /// </summary>
    [RptColumnName("注册时间")]
    public string addeddate
    {
        get { return _addeddate; }
        set { _addeddate = value; }
    }
}
