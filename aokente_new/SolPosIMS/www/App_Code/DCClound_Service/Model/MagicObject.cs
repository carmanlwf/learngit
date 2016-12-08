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

/// <summary>
///MagicObject 的摘要说明
/// </summary>
public class MagicObject
{
    public MagicObject()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    private string _mac;
    /// <summary>
    /// 设备地址(mac)
    /// </summary>
    public string mac
    {
        get { return _mac; }
        set { _mac = value; }
    }
    private string _version;
    /// <summary>
    /// 版本号
    /// </summary>
    public string version
    {
        get { return _version; }
        set { _version = value; }
    }
    private string _updateTime;
    /// <summary>
    /// 更新时间
    /// </summary>
    public string updateTime
    {
        get { return _updateTime; }
        set { _updateTime = value; }
    }
    private string _createTime;
    /// <summary>
    /// 创建时间
    /// </summary>
    public string createTime
    {
        get { return _createTime; }
        set { _createTime = value; }
    }
    private string _applicationName;
    /// <summary>
    /// 应用名称
    /// </summary>
    public string applicationName
    {
        get { return _applicationName; }
        set { _applicationName = value; }
    }
    private string _applicationId;
    /// <summary>
    /// 应用标识号
    /// </summary>
    public string applicationId
    {
        get { return _applicationId; }
        set { _applicationId = value; }
    }
    private string _deviceType;
    /// <summary>
    /// 设备类型
    /// </summary>
    public string deviceType
    {
        get { return _deviceType; }
        set { _deviceType = value; }
    }
    private string _starttime;
    /// <summary>
    /// 起始时间
    /// </summary>
    public string starttime
    {
        get { return _starttime; }
        set { _starttime = value; }
    }
    private string _endtime;
    /// <summary>
    /// 结束时间
    /// </summary>
    public string endtime
    {
        get { return _endtime; }
        set { _endtime = value; }
    }
}

