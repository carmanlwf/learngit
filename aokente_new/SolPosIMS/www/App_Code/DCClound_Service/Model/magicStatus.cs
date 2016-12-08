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
///magicStatus 的摘要说明
/// </summary>
public class magicStatus
{
    public magicStatus()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private int _id;
    public int id
    {
        get { return _id; }
        set { _id = value; }
    }

    private int _parkId;
    public int parkId
    {
        get { return _parkId; }
        set { _parkId = value; }
    }

    private string _parkName;

    public string parkName
    {
        get { return _parkName; }
        set { _parkName = value; }
    }

    private int _carportNumber;
    public int carportNumber
    {
        get { return _carportNumber; }
        set { _carportNumber = value; }
    }

    private int _macId;
    public int macId
    {
        get { return _macId; }
        set { _macId = value; }
    }

    private string _mac;
    public string mac
    {
        get { return _mac; }
        set { _mac = value; }
    }

    //private string _postionName;

    //public string postionName
    //{
    //    get { return _postionName; }
    //    set { _postionName = value; }
    //}

    private int _status;

    public int status
    {
        get { return _status; }
        set { _status = value; }
    }

    private int _floor;
    public int floor
    {
        get { return _floor; }
        set { _floor = value; }

    }

    private string _position;
    public string position
    {
        get { return _position; }
        set { _position = value; }
    }

    private string _description;
    public string description
    {
        get { return _description; }
        set { _description = value; }
    }

    private string _date;
    public string date
    {
        get { return _date; }
        set { _date = value; }
    }
}
