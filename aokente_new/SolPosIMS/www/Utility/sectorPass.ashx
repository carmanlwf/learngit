<%@ WebHandler Language="C#" Class="sectorPass" %>

using System;
using System.Web;

public class sectorPass : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        context.Response.Write("391630152123");//391630152123
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}