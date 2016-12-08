using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///RptColumnName 的摘要说明
/// </summary>
[AttributeUsage(AttributeTargets.Field|AttributeTargets.Property, AllowMultiple = true)] // multiuse attribute
public class RptColumnName : Attribute
{
    private string strname;
    public RptColumnName(string name)
    {
        strname = name;
    }
    //添加一个允许外部访问的属性
    public string ColumnName
    {
        get { return strname; }
        set { strname = ColumnName; }
    }
}
