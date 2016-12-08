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
///newmagicStatus 的摘要说明
/// </summary>
public class newmagicStatus
{
   

    private string _message;
    public string message
    {
        get { return _message; }
        set { _message = value; }
    }

    private int _status;
    public int status
    {
        get { return _status; }
        set { _status = value; }
    }



    private List<newmagicbody> _body;
    //body信息
    public List<newmagicbody> body
    {
        get { return _body; }
        set { _body = value; }
    }
}
