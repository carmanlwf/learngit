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
///SiteMacAndStatus 的摘要说明
/// </summary>
public class SiteMacAndStatus
{
    public SiteMacAndStatus()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public SiteMacAndStatus(string mac, string info, string createTime)
    {
        this._mac = mac;
        this._info = info;
        this._createTime = createTime;
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    private string _mac;
    /// <summary>
    /// 车位编号(自定义)
    /// </summary>
    public string mac
    {
        get { return _mac; }
        set { _mac = value; }
    }
    private string _info;
    /// <summary>
    /// 地磁信息
    /// </summary>
    public string info
    {
        get { return _info; }
        set { _info = value; }
    }
    private string _createTime;
    /// <summary>
    /// 记录生成时间
    /// </summary>
    public string createTime
    {
        get { return _createTime; }
        set { _createTime = value; }
    }
}
