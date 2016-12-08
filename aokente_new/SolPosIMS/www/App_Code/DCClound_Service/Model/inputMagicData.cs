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
///inputMagicData 的摘要说明
/// </summary>
public class inputMagicData
{
    public inputMagicData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    //private string _dataitems;
    //public string dataitems
    //{
    //    get { return _dataitems; }
    //}
    private List<magicdata> _dataitems;
    /// <summary>
    /// 地磁信息列表
    /// </summary>
    public List<magicdata> dataitems
    {
        get { return _dataitems; }
        set { _dataitems = value; }
    }
}
