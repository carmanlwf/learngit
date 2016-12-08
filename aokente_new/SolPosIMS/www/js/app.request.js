/**
FlexRequest
*/

function getRequestParameter(name)
{	
	return FlexRequest.getParam(name);
}

function FlexRequest()
{

}

FlexRequest._requestParams = null;

FlexRequest.getParams = function()
{
	if(FlexRequest._requestParams == null)
	{
		FlexRequest._requestParams = new Object();
		var aParams = "";
		if(typeof(window.dialogArguments) == 'string' ) 
			aParams = window.dialogArguments.split('&') ;
		else 
			aParams = window.location.search.substr(1).split('&') ;
		for (var i=0 ; i < aParams.length ; i++) {
			var aParam = aParams[i].split('=') ;
			if(aParam[0] == null || aParam[0] == "") continue;
			FlexRequest._requestParams[aParam[0]] = decodeURIComponent(aParam[1]) ;
		}

		if(typeof(User) != 'undefined' &&  typeof(User.getUserid) != 'undefined')
		{
			FlexRequest._requestParams['userid'] = User.getUserid();
		}
	}
	return FlexRequest._requestParams;
}

FlexRequest.getParam= function(name)
{
	var params = FlexRequest.getParams();
	var value = params[name];
	if(typeof(value) == 'undefined' || value == null) return "";
	return value;
}

FlexRequest.setParam= function(name,value)
{
	FlexRequest.getParams();
	FlexRequest._requestParams[name] = value;
}

FlexRequest.clearParams= function()
{
	FlexRequest._requestParams = new Object();
}

FlexRequest.bindParams =function(str)
{
	var params = FlexRequest.getParams();
	for(var name in params)
	{
	//	alert(name +"=" + params[name]);
		var value = params[name];
		//alert(value);
		var re = new RegExp(':'+name,'ig'); 
//		alert(td.innerHTML);
		str = str.replace(re,value);
	}
	return str;
}

FlexRequest.toQueryString =function()
{
	var str="";
	var params = FlexRequest.getParams();
	for(var name in params)
	{
		var value = params[name];
		if(str != "") str += "&";
		str += name + "=" + encodeURIComponent(value);
	}
	return str;
}

if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.request.js");