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
///RptConsumePoint 客户流失统计
/// </summary>
[DbObject("MB_Member", ObjType = DbObjectAttribute.ObjectType.Table)]
[DbObject("v_card_MemberCardInfo", ObjType = DbObjectAttribute.ObjectType.View)]
[BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
public class RptLossMemberInfo
{
    public RptLossMemberInfo()
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

    string _balance;
    /// <summary>
    /// 余额
    /// </summary>
    [RptColumnName("余额")]
    public string balance
    {
        get { return _balance; }
        set { _balance = value; }
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

    private string _finalconsumptiontime;
    /// <summary>
    /// 最后消费时间
    /// </summary>
      [RptColumnName("最后消费时间")]
    public string finalconsumptiontime
    {
        get { return _finalconsumptiontime; }
        set { _finalconsumptiontime = value; }
    }

    int _monthquantry;
    /// <summary>
    /// 离今消费时间（月）
    /// </summary>
    [RptColumnName("离今消费时间（月）")]
    public int monthquantry
    {
        get { return _monthquantry; }
        set { _monthquantry = value; }
    }
}
