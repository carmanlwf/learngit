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
using System.Collections.Generic;

/// <summary>
///outputMagicData 的摘要说明
/// </summary>
public class outputMagicData
{
    public outputMagicData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    private string _success;
    /// <summary>
    /// success:true
    /// </summary>
    public string success
    {
        get { return _success; }
        set { _success = value; }
    }
    private string _message;
    /// <summary>
    /// success:true
    /// </summary>
    public string message
    {
        get { return _message; }
        set { _message = value; }
    }
}
