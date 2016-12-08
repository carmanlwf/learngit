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

public partial class InterFace_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
            Common.AutoSignOutForParkingRecordYesterday();
            DirectPages();
       // }
    }
    public void DirectPages()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["fun"]))
        {
            string funPage = Request.QueryString["fun"].ToString().ToLower().Trim();
            switch (funPage)
            {
                case "signin":
                    Server.Transfer("./FunPages/SignIn.aspx",true);
                    break;
                case "business":
                    Server.Transfer("./FunPages/Business.aspx", true);
                    break;
                case "signout":
                    Server.Transfer("./FunPages/SignOut.aspx", true);
                    break;
                case "magiclist":
                    Server.Transfer("./FunPages/MagicList.aspx", true);
                    break;
                case "data":
                    Server.Transfer("./FunPages/datacenter.aspx", true);
                    break;
                case "arrearage":
                    Server.Transfer("./FunPages/CheckIsArrearage.aspx", true);
                    break;
                case "sync":
                    Server.Transfer("./FunPages/SyncParkingRecord.aspx", true);
                    break;
                case "sitelist":
                    Server.Transfer("./FunPages/GetSiteList.aspx", true);
                    break;
                case "parklist":
                    Server.Transfer("./FunPages/GetParkingRecordBySiteID.aspx", true);
                    break;
                case "fill":
                    Server.Transfer("./FunPages/refill.aspx", true);
                    break;
                case "monthlycardlist":
                    Server.Transfer("./FunPages/GetMonthlyCardList.aspx",true);
                    break;
                case "modifypass":
                    Server.Transfer("./FunPages/ModifyPass.aspx", true);
                    break;
                case "error":
                    Server.Transfer("./FunPages/errReport.aspx", true);
                    break;
                default:
                    break;
            }
        }
        else
        {
            Response.Redirect(Server.MapPath("~/Unauthorized.aspx"));
        }

    }
}

