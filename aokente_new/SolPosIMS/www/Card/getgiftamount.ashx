<%@ WebHandler Language="C#" Class="getgiftamount" %>

using System;
using System.Web;

public class getgiftamount : IHttpHandler {
    
     public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string chargeAmount_str = context.Request.QueryString["amount"];
        string RtnStr = "0";
        decimal amount = 0;
        decimal.TryParse(chargeAmount_str, out amount);
        string strSql = "Select Top 1 BounsName, ISNULL(giftMoney,0) as giftMoney,ISNULL(beginAmount,0) as beginAmount,ISNULL(endAmount,0) as endAmount,ISNULL(actualMoney,0) as actualMoney from dbo.cardchargerule where beginAmount <= " + amount + " And endAmount >" + amount + " And actualMoney <= "+amount+"";
        System.Data.DataTable dt = ZsdDotNetLibrary.Data.DataExecSqlHelper.ExecuteQuerySql(strSql);
        if (dt != null && dt.Rows.Count > 0)
        {
            string bon_name = "";
            decimal sAmount = 0;
            decimal eAmount = 0;
            decimal aAmount = 0;
            decimal gAmount = 0;
            decimal rAmount = 0;
            decimal n = 0;
            
            decimal.TryParse(dt.Rows[0]["beginAmount"].ToString(), out sAmount);
            decimal.TryParse(dt.Rows[0]["endAmount"].ToString(), out eAmount);
            decimal.TryParse(dt.Rows[0]["actualMoney"].ToString(), out aAmount);
            decimal.TryParse(dt.Rows[0]["giftMoney"].ToString(), out gAmount);

            bon_name = dt.Rows[0]["bounsname"].ToString();
            
            n = amount / aAmount;//赠送的倍数(支持小数)
            rAmount = ((int)n) * gAmount;//应该赠送的额度
            RtnStr = bon_name + "," + rAmount.ToString();//"规则1,50"
        }
        context.Response.Write(RtnStr);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}