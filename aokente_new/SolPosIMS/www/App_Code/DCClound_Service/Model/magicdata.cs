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
///magicdata 的摘要说明
/// </summary>
public class magicdata
{
    public magicdata()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
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
    /// 地磁编号(物理地址)
    /// </summary>
    public string mac
    {
        get { return _mac; }
        set { _mac = value; }
    }
    private string _descr;
    /// <summary>
    /// 描述
    /// </summary>
    public string descr
    {
        get { return _descr; }
        set { _descr = value; }
    }
    private string _createTime;
    /// <summary>
    /// 记录时间
    /// </summary>
    public string createTime
    {
        get { return _createTime; }
        set { _createTime = value; }
    }
}
