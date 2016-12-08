using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

/// <summary>
///outputMagicStatus 的摘要说明
/// </summary>
public class outputMagicStatus
{
    public outputMagicStatus()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    //private string _sign;

    //public string sign
    //{
    //    get { return _sign; }
    //    set { _sign = value; }
    //}

    private string _message;

    public string message
    {
        get { return _message; }
        set { _message = value; }
    }

    private string _status;

    public string status
    {
        get { return _status; }
        set { _status = value; }
    }

    //private int _resultCode;

    //public int resultCode
    //{
    //    get { return _resultCode; }
    //    set { _resultCode = value; }
    //}

    //private string _data;

    //public string data
    //{
    //    get {return _data;}
    //    set {_data = value;}
    //}

    private List<magicStatus> _body;

    public List<magicStatus> body
    {
        get { return _body; }
        set { _body = value; }
    }
}
