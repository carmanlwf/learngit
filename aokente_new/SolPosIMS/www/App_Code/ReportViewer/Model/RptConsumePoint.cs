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
///RptConsumePoint 消费积分统计
/// </summary>
[DbObject("MB_Member", ObjType = DbObjectAttribute.ObjectType.Table)]
[DbObject("v_card_MemberCardInfo", ObjType = DbObjectAttribute.ObjectType.View)]
[BindControlParameter("", "value", ParamUsage = BindParameterUsage.OpInsert | BindParameterUsage.OpQuery | BindParameterUsage.OpUpdate | BindParameterUsage.BindToObjectAndParameter)]
public class RptConsumePoint
{
    public RptConsumePoint()
    {
        
    }
    string _NUMbalance;
    /// <summary>
    /// 余额统计
    /// </summary>
    [RptColumnName("余额统计")]
    public string NUMbalance
    {
        get { return _NUMbalance; }
        set { _NUMbalance = value; }
    }

    string _NUMPoints;
    /// <summary>
    /// 积分统计
    /// </summary>
    [RptColumnName("积分统计")]
    public string NUMPoints
    {
        get { return _NUMPoints; }
        set { _NUMPoints = value; }
    }

    string _memo;
    /// <summary>
    /// 统计条件
    /// </summary>
    [RptColumnName("统计条件")]
    public string memo
    {
        get { return _memo; }
        set { _memo = value; }
    }
}
