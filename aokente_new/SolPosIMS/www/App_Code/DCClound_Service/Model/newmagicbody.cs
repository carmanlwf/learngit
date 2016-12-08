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
///newmagicbody 的摘要说明
/// </summary>
public class newmagicbody
{

    private int _id;
    public int id
    {
        get { return _id; }
        set { _id = value; }
    }

    private string _name;

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }

    private int _streetId;
    public int streetId
    {
        get { return _streetId; }
        set { _streetId = value; }
    }

    private int _portCount;
    public int portCount
    {
        get { return _portCount; }
        set { _portCount = value; }
    }

    private int _channelCount;
    public int channelCount
    {
        get { return _channelCount; }
        set { _channelCount = value; }
    }

    private int _feeCriterionId;
    public int feeCriterionId
    {
        get { return _feeCriterionId; }
        set { _feeCriterionId = value; }
    }

    private int _status;

    public int status
    {
        get { return _status; }
        set { _status = value; }
    }

    private int _isFree;

    public int isFree
    {
        get { return _isFree; }
        set { _isFree = value; }
    }

    private int _floor;
    public int floor
    {
        get { return _floor; }
        set { _floor = value; }

    }

    private int _type;

    public int type
    {
        get { return _type; }
        set { _type = value; }
    }

    private int _longitude;

    public int longitude
    {
        get { return _longitude; }
        set { _longitude = value; }
    }

    private int _latitude;

    public int latitude
    {
        get { return _latitude; }
        set { _latitude = value; }
    }

    private string _alias;

    public string alias
    {
        get { return _alias; }
        set { _alias = value; }
    }


    private string _position;
    public string position
    {
        get { return _position; }
        set { _position = value; }
    }

    private string _mapAddr;

    public string mapAddr
    {
        get { return _mapAddr; }
        set { _mapAddr = value; }
    }

    private string _date;
    public string date
    {
        get { return _date; }
        set { _date = value; }
    }

    private int _isDeleted;

    public int isDeleted
    {
        get { return _isDeleted; }
        set { _isDeleted = value; }
    }

    private string _contact;
    public string contact
    {
        get { return _contact; }
        set { _contact = value; }
    }

    private string _number;
    public string number
    {
        get { return _number; }
        set { _number = value; }
    }


    private int _portLeftCount;

    public int portLeftCount
    {
        get { return _portLeftCount; }
        set { _portLeftCount = value; }
    }

}
