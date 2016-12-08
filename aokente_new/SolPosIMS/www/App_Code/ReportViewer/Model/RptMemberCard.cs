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
using ZsdDotNetLibrary.Data.Attribute;

/// <summary>
///RptMemberCard 的摘要说明
/// </summary>
/// 
[DbObject("v_member_MemberInfo", ObjType = DbObjectAttribute.ObjectType.View)]
[BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
public class RptMemberCard
{
    public RptMemberCard()
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
    string _card;
    /// <summary>
    /// 用户卡号
    /// </summary>
    [RptColumnName("用户卡号")]
    public string card
    {
        get { return _card; }
        set { _card = value; }
    }
    string _realname;
    /// <summary>
    /// 用户姓名
    /// </summary>
    [RptColumnName("用户姓名")]
    public string RealName
    {
        get { return _realname; }
        set { _realname = value; }
    }
    private string _TypeName;//
    /// <summary>
    /// 卡类型名称
    /// </summary>
    [RptColumnName("卡类型名称")]
    public string TypeName
    {
        get { return _TypeName; }
        set { _TypeName = value; }
    }

    private string _addeddate;//
    /// <summary>
    /// 发卡时间
    /// </summary>
    [RptColumnName("发卡时间")]
    public string addeddate
    {
        get { return _addeddate; }
        set { _addeddate = value; }
    }

    string _initvalue;
    /// <summary>
    /// 初始金额
    /// </summary>
    [RptColumnName("初始金额")]
    public string initvalue
    {
        get { return _initvalue; }
        set { _initvalue = value; }
    }
    string _LastSaleTime;
    /// <summary>
    /// 最后消费时间
    /// </summary>
    [RptColumnName("最后消费时间")]
    public string LastSaleTime
    {
        get { return _LastSaleTime; }
        set { _LastSaleTime = value; }
    }
    string _statusname;
    /// <summary>
    /// 持卡状态
    /// </summary>
    [RptColumnName("持卡状态")]
    public string statusname
    {
        get { return _statusname; }
        set { _statusname = value; }
    }

}

