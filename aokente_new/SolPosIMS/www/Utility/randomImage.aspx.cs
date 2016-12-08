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
using System.IO;

public partial class Utility_randomImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Index();
    }

    public void Index()
    {

        Response.ClearContent();

        Response.ContentType = "image/Gif";

        using (MemoryStream m = new MemoryStream())
        {

            VerificationCode va = new VerificationCode(105, 30);

            var s = va.Create(m);

            string code = WebHelper.Encrypt(MembershipPasswordFormat.Encrypted,va.IdentifyingCode.ToLower(),"!@#$%^&*");

            var cookie = new HttpCookie("checkcode", code);

            if (Request.Url.Host.ToLower() != "localhost")
            {

                cookie.Domain = Request.Url.Host;

            }

            cookie.HttpOnly = false;

            Response.Cookies.Add(cookie);

            Response.BinaryWrite(m.ToArray());

        }

    }
}
