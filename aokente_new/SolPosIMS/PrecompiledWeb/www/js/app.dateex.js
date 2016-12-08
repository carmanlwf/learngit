// JavaScript Document
Date.prototype.dateDiff = function(objDate)
{
	return  (this.getTime()-objDate.getTime())/1000;
}

Date.prototype.dateAdd = function(interval,number) 
{
	var date = this; 
	
	switch(interval) 
	{ 
	case "y" : 
	case "Y" : 
		date.setFullYear(date.getFullYear()+number); 
		return date; 
	case "q" : 
	case "Q" : 
		date.setMonth(date.getMonth()+number*3); 
		return date; 
	case "M" : 
		date.setMonth(date.getMonth()+number); 
		return date; 
	case "w" : 
	case "W" : 
		date.setDate(date.getDate()+number*7); 
		return date; 
	case "d" : 
	case "D" : 
		date.setDate(date.getDate()+number); 
		return date; 
	case "h" : 
	case "H" : 
		date.setHours(date.getHours()+number); 
		return date; 
	case "m" : 
		date.setMinutes(date.getMinutes()+number); 
		return date; 
	case "s" : 
	case "S" : 
		date.setSeconds(date.getSeconds()+number); 
		return date; 
	default : 
		date.setDate(d.getDate()+number); 
		return date; 
	} 
} 

/*
//格式化日期格式 
示例：
alert(new Date().Format(yyyy年MM月dd日));
alert(new Date().Format(MM/dd/yyyy));
alert(new Date().Format(yyyyMMdd));
alert(new Date().Format(yyyy-MM-dd hh:nn:ss));
*/ 
Date.prototype.format = function(format)
{
	/*  var o = {
		M+ : this.getMonth()+1, //month
		d+ : this.getDate(),    //day
		h+ : this.getHours(),   //hour
		m+ : this.getMinutes(), //minute
		s+ : this.getSeconds(), //second
		q+ : Math.floor((this.getMonth()+3)/3),  //quarter
		S : this.getMilliseconds() //millisecond
	  }
	  if(/(y+)/.test(format)) format=format.replace(RegExp.$1,
		(this.getFullYear()+).substr(4 - RegExp.$1.length));
	  for(var k in o)if(new RegExp((+ k +)).test(format))
		format = format.replace(RegExp.$1,
		  RegExp.$1.length==1 ? o[k] : 
			(00+ o[k]).substr((+ o[k]).length));
	  return format;*/
	var str = format;
	
	str=str.replace(/yyyy/i,this.getFullYear());
	str=str.replace(/yy/i,(this.getYear() % 100)>9?(this.getYear() % 100).toString():"0" + (this.getYear() % 100));
	
	var month = this.getMonth() +1;
	str=str.replace(/mm/i,month>9?month.toString():"0" + month);
	str=str.replace(/m/ig,month);
	
	str=str.replace(/dd/i,this.getDate()>9?this.getDate().toString():"0" + this.getDate());
	str=str.replace(/d/ig,this.getDate());
	
	str=str.replace(/hh/i,this.getHours()>9?this.getHours().toString():"0" + this.getHours());
	str=str.replace(/h/ig,this.getHours());
	
	str=str.replace(/nn/i,this.getMinutes()>9?this.getMinutes().toString():"0" + this.getMinutes());
	str=str.replace(/n/ig,this.getMinutes());
	
	str=str.replace(/ss/i,this.getSeconds()>9?this.getSeconds().toString():"0" + this.getSeconds());
	str=str.replace(/s/ig,this.getSeconds());
	
	return str;

}


/** 

//由字符串直接实例日期对象 

*/ 
Date.instanceFromString = function(str) 
{ 
	return new Date(str.replace(/-/g, "\/")); 
} 

Date.secondsToFormatStr = function(sec)
{ 
    if(sec <0) sec = 1;
	var hh = parseInt(sec / 3600); 
	var mm = parseInt((sec %3600) / 60) ; 
	var ss = parseInt((sec %3600) % 60) ;

	var clock = "";
	if(hh <10) clock += '0';
	clock += ''+hh+':'; 
	if (mm < 10) clock += '0'; 
	clock += ''+mm+':'; 
	if (ss < 10) clock += '0'; 
	clock += ''+ss; 

	return(clock); 
}
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.dateex.js");