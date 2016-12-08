// JavaScript Document
var Form = {
	toJSONString : function (formid)
	{
		var o = {};
		var _dbfrmobj = document.getElementById(formid);
		for(var i=0;i<_dbfrmobj.length;i++)
		{
			var currobj = _dbfrmobj[i];
			var sfieldName = currobj.name;
			var sFieldValue = "";
			if(sfieldName == null || sfieldName == "")
			{
				sfieldName = currobj.id;
			}
			if(sfieldName == null || sfieldName == "" ) continue;//忽略系统变量
			//获取值
			if(currobj.type == "radio")
			{
				if(!currobj.checked) continue;
				sFieldValue =currobj.value;
			} 	
			else if(currobj.type == "checkbox")
			{
				if(currobj.checked)
					sFieldValue = currobj.value;
				else
					sFieldValue = "0"; 
			}
			else
			{
				sFieldValue = currobj.value;
			}
			o[sfieldName] = sFieldValue;
		}
		return o.toJSONString();
	}
}
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.json.js");