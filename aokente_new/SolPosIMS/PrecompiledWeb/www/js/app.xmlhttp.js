// JavaScript Document
var XmlHttpHelper = {
	getXmlHttp:function()
	{
		var xmlHttp = null;
		if (window.ActiveXObject)
		{
			xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
			if (!xmlHttp)
			{
				xmlHttp = new ActiveXObject("Microsoft.XMLHTTP")
			}
		}
		else if (window.XMLHttpRequest)
		{
			xmlHttp = new XMLHttpRequest();
		}
		return xmlHttp;
	},
	
	asynCall:function(url,callback)
	{
		var xmlhttp = XmlHttpHelper.getXmlHttp();
		xmlhttp.open("GET", url, true);
		xmlhttp.send(null);
		xmlhttp.onreadystatechange = function()
		{
		   if (xmlhttp.readyState == 4 && xmlhttp.status >= 200 && xmlhttp.status < 300)
		   {
			  if(callback)
			  {
				  callback(xmlhttp.responseText);
			  }
		   }
		}
	},
	
	synCall:function(url,callback)
	{
		var xmlhttp = XmlHttpHelper.getXmlHttp();
		xmlhttp.open("GET", url, false);
		xmlhttp.send(null);
		if(callback)
		{
		  callback(xmlhttp.responseText);
		}else
		return xmlhttp.responseText;
	},
	
	synCallLastText:function(url,callback)
	{
	    var responseText = XmlHttpHelper.synCall(url,callback);
	    var arrstrs = responseText.split("<br>");
	    if(arrstrs.length>0) responseText = arrstrs[arrstrs.length-1];
	    return responseText;
	}
	
}
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.xmlhttp.js");