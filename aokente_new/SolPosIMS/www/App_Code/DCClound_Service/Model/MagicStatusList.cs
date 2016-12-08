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
///MagicStatusList 的摘要说明
/// </summary>
public class MagicStatusList
{
    public MagicStatusList()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private string _dataId;
    /// <summary>
    /// 数据流水号
    /// </summary>
    public string dataId
    {
        get { return _dataId; }
        set { _dataId = value; }
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
    private string _infor;
    /// <summary>
    /// 地磁信息
    /// </summary>
    public string infor
    {
        get { return _infor; }
        set { _infor = value; }
    }
    private string _mac;
    /// <summary>
    /// 物理地址(mac)
    /// </summary>
    public string mac
    {
        get { return _mac; }
        set { _mac = value; }
    }
    private string _descr;
    /// <summary>
    /// 物理地址(mac)
    /// </summary>
    public string descr
    {
        get { return _descr; }
        set { _descr = value; }
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
    private string _applicationName;
    /// <summary>
    /// 应用名称
    /// </summary>
    public string applicationName
    {
        get { return _applicationName; }
        set { _applicationName = value; }
    }

    private bool _forwarded;
    /// <summary>
    /// 未知字段1
    /// </summary>
    public bool forwarded
    {
        get { return _forwarded; }
        set { _forwarded = value; }
    }
    private int _forwardTimes;
    /// <summary>
    /// 未知字段2
    /// </summary>
    public int forwardTimes
    {
        get { return _forwardTimes; }
        set { _forwardTimes = value; }
    }
}
