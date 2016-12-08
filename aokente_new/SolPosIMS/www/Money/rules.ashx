<%@ WebHandler Language="C#" Class="rules" %>

using System;
using System.Web;

public class rules : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context == null) return;
        //context.Response.Write("Hello World");
        string amount = context.Request["amount"].ToString();
        string type = context.Request["ctype"].ToString();
        decimal money = !string.IsNullOrEmpty(amount) ? decimal.Parse(amount) : 0;
        Ims.Card.Model.card_chargerule o = new Ims.Card.Model.card_chargerule();
        context.Response.Write(Ims.Card.BLL.CardRuleHelperBLL.getRule(money,type));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}