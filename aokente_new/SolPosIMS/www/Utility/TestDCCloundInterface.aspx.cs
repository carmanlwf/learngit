using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Text;

public partial class Utility_TestDCCloundInterface : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            TestDCClound();
    }
    public void TestDCClound()
    {
        string DCCServiceURL = ConfigurationManager.AppSettings["DCCloundServiceURL"];
        string url_test = DCCServiceURL + "getApplication.do?mac=EEEEEEEEEEE1";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_test);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream ResStream = response.GetResponseStream();
        Encoding encoding = Encoding.GetEncoding("utf-8");
        StreamReader streamReader = new StreamReader(ResStream, encoding);
        Response.Write(streamReader.ReadToEnd());
    }
}
