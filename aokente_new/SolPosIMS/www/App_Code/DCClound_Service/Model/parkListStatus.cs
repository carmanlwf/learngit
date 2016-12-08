using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Collections.Generic;
/// <summary>
///parkListStatus 的摘要说明
/// </summary>
public class parkListStatus
{
    public parkListStatus()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private List<magicStatus> _parkList;

    public List<magicStatus> parkList
    {
        get { return _parkList; }
        set { _parkList = value; }
    }
}
