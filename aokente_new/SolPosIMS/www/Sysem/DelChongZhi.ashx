<%@ WebHandler Language="C#" Class="DelChongZhi" %>

using System;
using System.Web;
using Ims.Card.BLL;
using Ims.Card.Model;

public class DelChongZhi : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string trandno = context.Request.Form["idno"];
        decimal money = Convert.ToDecimal(context.Request.Form["money"]);
        string card = context.Request.Form["card"];
        if (TransLogHelperBLL.DeleteChongZhi(trandno, money, card))
        {
            context.Response.Write("yes");
        }
        else
        {
            context.Response.Write("no");
        }
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}