// JScript 文件

var logHelper = {
 	logWin:null,
 	isShowLog:true,
	currLogLine:1,
	open:function()
	{
		if(logHelper.isShowLog)
		{
			logHelper.logWin = window.open("about:blank","applogwin","resizable=yes,scrollbars=yes");
		}
	},
	write:function(Msg)
	{
		try
		{	
			if(logHelper.logWin != null)
			{
				if(logHelper.currLogLine >10000)
				{
					logHelper.logWin.close();
					logHelper.open();
					logHelper.currLogLine = 1;
				}
				if(Msg.charAt(0)=='*') Msg = "<strong>" + Msg +"</strong>";
				Msg = logHelper.currLogLine + "# " + Msg.replace(/\r\n/ig,"<br/>");
				if(logHelper.currLogLine % 2)
				{ 
					logHelper.logWin.document.writeln("<span style='color:rgb(0,66,174);'>"+Msg+"</span>");
				}else
				{
					logHelper.logWin.document.writeln("<span>"+Msg+"</span>");
				}
				logHelper.currLogLine++;	
				
			}
		}catch(ex){logHelper.open();}
	},
	close:function()
	{
		if(typeof(logHelper.logWin) != 'undefined' && logHelper.logWin != null)
		{
			logHelper.logWin.close();
			logHelper.logWin = null;
		}
	}
	
}



			 

// IE 
if ( typeof window.attachEvent != "undefined" ) {
	window.attachEvent( "onunload", logHelper.close );
}

if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.log.js");