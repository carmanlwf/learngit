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
using System.Web.UI.MobileControls;
using System.Collections.Generic;

/// <summary>
///JsonResponse 的摘要说明
/// </summary>
public class JsonResponse
{
    public JsonResponse()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    private int _total;
    /// <summary>
    /// 记录行数
    /// </summary>
    public int total
    {
        get { return _total; }
        set { _total = value; }
    }
    private bool _success;
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool success
    {
        get { return _success; }
        set { _success = value; }
    }
    private string _message;
    /// <summary>
    /// 返回信息
    /// </summary>
    public string message
    {
        get { return _message; }
        set { _message = value; }
    }
    private string _login;
    /// <summary>
    /// 登录状态
    /// </summary>
    public string login
    {
        get { return _login; }
        set { _login = value; }
    }
    private string _username;
    /// <summary>
    /// 用户名
    /// </summary>
    public string username
    {
        get { return _username; }
        set { _username = value; }
    }
    private List<JsongItems> _items;
    /// <summary>
    /// 内容条目
    /// </summary>
    public List<JsongItems> items
    {
        get { return _items; }
        set { _items = value; }
    }
    private string _statusCode;
    /// <summary>
    /// 返回的状态值
    /// </summary>
    public string statusCode
    {
        get { return _statusCode; }
        set { _statusCode = value; }
    }
}
