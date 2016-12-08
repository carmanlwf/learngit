function reportError(msg,url,line) {
	var str = "Javascript Error: \n\n";
	str += "Err: " + msg + " on line: " + line+"\r\n";
	str += "url: " + url;
	//alert(str);
	return true;
}

window.onerror = reportError;


var IsOpen = false;
var MainApp  =new Object;
var openWins = [];

function closeOpenWins()
{
    var win = null;
    for(var i=0;i<openWins.length;i++)
    {
        try
        {
            win = openWins[i].win;
        }catch(e){win = null;}
        if(typeof(win) != 'undefined' && win != null && !win.closed)
            win.close();
    }
    openWins = [];
}

var isSaveOpenWin = true;

function getOpenWin(winName,url)
{
    if(!isSaveOpenWin) return null;
    if(winName.charAt(0) == '_') return null;
    var mainWin = GetMainWindow();
    if(typeof(url) == "undefined" || url == null ) url ="";
    try
    {
        var win = null;
        for(var i=mainWin.openWins.length-1;i>=0;i--)
        {
            try
            {
                win = mainWin.openWins[i].win;
            }catch(e){win = null;}
            if(typeof(win) == 'undefined' || win == null || win.closed)
            {
                mainWin.openWins.splice(i,1);
            }
        }
        win = null;
        for(var i=0;i<mainWin.openWins.length;i++)
        {
            if(mainWin.openWins[i].name == winName)
            {   
                win = mainWin.openWins[i].win;
                if(typeof(win) == 'undefined' || win == null || win.closed)
                {
                    win = null;
                    mainWin.openWins.splice(i,1);
                }
                break;
            }
        }
      //  var win = mainWin.openWins[winName];
        if(typeof(win) != 'undefined' && win != null && !win.closed)
        {
            win.focus();
            var winurl ="";
            if(url != "")
            {
                if(url.lastIndexOf("/")>0) url = url.substring(url.lastIndexOf("/")+1);
                winurl = win.location.href;
                winurl = winurl.substring(winurl.lastIndexOf("/")+1);
            }
            if(url=="" || winurl == url ) return win;
        }
//        else
//           mainWin.openWins[winName] = null;
    }catch(e)
    {
    
    }
    return null;
}

function putOpenWin(winName,win)
{
    if(!isSaveOpenWin) return null;
    var mainWin = GetMainWindow();
    var win1 = null;
    for(var i=mainWin.openWins.length-1;i>=0;i--)
    {
        try
        {
            win1 = mainWin.openWins[i].win;
        }catch(e){win1 = null;}
        if(typeof(win1) == 'undefined' || win1 == null || win1.closed || win1 == win)
        {
            mainWin.openWins.splice(i,1);
        }else if(winName.charAt(0) != '_' && mainWin.openWins[i].name == winName)
        {
            win1.close();
            mainWin.openWins.splice(i,1);
        }
        
    }    
    var winObj = {};
    winObj.name = winName;
    winObj.win = win;
    mainWin.openWins[mainWin.openWins.length] = winObj;
    return null;
}

function openBrWindow(url,winName,width ,height)
{
     if(!isSaveOpenWin) winName = "_blank";
    if(arguments.length >=2 && winName.charAt(0) != '_')
    {
	    var win = getOpenWin(winName,url);
	    if(win != null) return win;   
    }
    var trueWinName = "_blank";
	if(arguments.length <3)
	{
		var win = window.open(url,trueWinName);
		putOpenWin(winName,win);
		return win;
	}
    var win = openCenterWindow(url,trueWinName,width ,height);
    putOpenWin(winName,win);
    return win;
}

function openCenterWindow(url,winName,width ,height)
{
	var sFeatures ="";
	if(arguments.length <4 || typeof(height)=="undefined" || height==null || height=="")
	{
		sFeatures = width;
		width = sFeatures.match(/width=\d+/ig);
		if(width != null) width = width[0].substring(6,width[0].length);
		height = sFeatures.match(/height=\d+/ig);
		if(height != null) height = height[0].substring(7,height[0].length);
	}else
	{
		sFeatures = "width="+width+","+"height="+height;
	}
//	var sFeatures = "width="+width+","+"height="+height+",";
	var top = (screen.availHeight - height) /2 -10;
	if(top<0) top = 0;
	var left = (screen.availWidth - width) /2 ;
	if(left<0) left = 0;
	sFeatures += ",top=" + top+"," + "left=" + left ;
	var win = window.open(url,winName,sFeatures);
	return win;    
}

function GetMainWindow()
{
    return window;
}

function showFollowSiderBar(followbarId,sidebarId,isShow)
{
    var sidebar = document.getElementById(sidebarId);
    if(sidebar == null) return ;
    if(sidebar.currentStyle.display == "none" && !isShow) return ;
    if(sidebar.currentStyle.display != "none" &&  isShow) return ;
    var followbar = document.getElementById(followbarId);
    followbar.firstChild.click();
}

function switchFollowSiderBar(event, sidebar1) {

    sidebar = document.getElementById(sidebar1);
     
    event = event ? event : window.event;

    var followImg = event.srcElement ? event.srcElement : event.target;


    var followbar = null;  
    
    if(document.all){
        followbar = followImg.parentElement;
    }
    else {
        // alert("前面")
        followbar = document.getElementById("rightfollowbar")//followImg.parentNode;
        //alert("后面 ")
    }

    //var isleft = sidebar.nextSibling == followbar ? true : false;
    var isleft = null;
    if (document.all) {
        isleft = sidebar.nextSibling == followbar ? true : false;
    }
    else {
        isleft = sidebar.nextSibling.nextSibling == followbar ? true : false;
    }

	var maincontent = null;
	var isDisplay = true;
	if(isleft) {
	  
		maincontent = followbar.nextSibling;
		if(sidebar.currentStyle.display != "none")
		{
		    followImg.src = "images/main_switchpicr.gif";

			maincontent.style.marginLeft = followbar.currentStyle.width;
			followbar.style.left = sidebar.currentStyle.left;
			
			sidebar.style.display = "none";
			isDisplay = false;

		}else
		{
		    followImg.src = "images/main_switchpicl.gif";


		    if (document.all) {
		        followbar.style.left = (parseInt(followbar.currentStyle.left) + parseInt(sidebar.currentStyle.width)) + "px";
		        maincontent.style.marginLeft = (parseInt(followbar.currentStyle.left) + parseInt(followbar.currentStyle.width)) + "px";
		    }
		    else {

		        followbar.style.left = (parseInt(window.getComputedStyle(followbar, null).getPropertyValue("left")) + parseInt(window.getComputedStyle(sidebar, null).getPropertyValue("width"))) + "px";
		        maincontent.style.marginLeft = (parseInt(followbar.currentStyle.left) + parseInt(followbar.currentStyle.width)) + "px";

		        //maincontent.style.marginLeft = (parseInt(window.getComputedStyle(followbar, null).getPropertyValue("right")) + parseInt(window.getComputedStyle(followbar, null).getPropertyValue("width"))) + "px";
		        
		        
		    }

		    
			sidebar.style.display = "block";
			isDisplay = true;

		}
		
	}else
	{
	    maincontent = followbar.previousSibling;

	    var maincontent = document.getElementById("maincontent");
		
		if(sidebar.style.display != "none")
		{
		    followImg.src = "images/main_switchpicl.gif";

		    if (document.all) {
		        maincontent.style.marginRight = followbar.currentStyle.width;
		        followbar.style.right = sidebar.currentStyle.right;
		    } else {
		        maincontent.style.marginRight = (parseInt(window.getComputedStyle(followbar, null).getPropertyValue("right")) + parseInt(window.getComputedStyle(sidebar, null).getPropertyValue("width"))) + "px";
		        followbar.style.right = window.getComputedStyle(sidebar, null).getPropertyValue("right");

		        var followbar_right = parseInt(window.getComputedStyle(followbar, null).getPropertyValue("right"));
		        var followbar_width = parseInt(window.getComputedStyle(followbar, null).getPropertyValue("width"));

		        var marginRight = followbar_right + followbar_width;

		        maincontent.style.marginRight = marginRight + "px"; 
		    }


		    sidebar.style.display = "none";
 
		    isDisplay = false;
		
		}else
		{
		
		    
		    followImg.src = "images/main_switchpicr.gif";
		    
		    if (document.all) {
		    		        followbar.style.right = (parseInt(followbar.currentStyle.right) + parseInt(sidebar.currentStyle.width)) + "px";
		    		        maincontent.style.marginRight = (parseInt(followbar.currentStyle.right) + parseInt(followbar.currentStyle.width)) + "px";
		    }
		    else {

		    	        followbar.style.right = (parseInt(window.getComputedStyle(followbar, null).getPropertyValue("right")) + parseInt(window.getComputedStyle(sidebar, null).getPropertyValue("width"))) + "px";
		    	        
		    	 

		    	        var followbar_right = parseInt(window.getComputedStyle(followbar, null).getPropertyValue("right"));
		    	        var followbar_width = parseInt(window.getComputedStyle(followbar, null).getPropertyValue("width"));

		    	        var marginRight = followbar_right + followbar_width;

		    	        maincontent.style.marginRight = marginRight + "px";  //(parseInt(window.getComputedStyle(followbar, null).getPropertyValue("right")) + parseInt(window.getComputedStyle(followbar, null).getPropertyValue("width"))) + "px";
		    	        
		     
		    }
			
//			followbar.style.right = (parseInt(followbar.currentStyle.right) + parseInt(sidebar.currentStyle.width)) + "px";
//			maincontent.style.marginRight = (parseInt(followbar.currentStyle.right) + parseInt(followbar.currentStyle.width) ) + "px";
		    sidebar.style.display = "block";
		   
		    isDisplay = true;
		}
		
	}
	IsOpen = isDisplay; //赋值右侧窗口的状态

	if (document.all) {
	    followbar.style.height = sidebar.style.height = sidebar.parentElement.currentStyle.height;
	} else {
	    //var divprimary = document.getElementById("primary");
	//followbar.style.height = sidebar.style.height =parseInt(followbar.currentStyle.width);
	      var computedStyle = window.getComputedStyle((sidebar.parentElement), null);
	      followbar.style.height = sidebar.style.height = parseInt(computedStyle.getPropertyValue("height"));

	  }
	
 
	
    return isDisplay ;

}

function resizeMainHeight()
 {
 return ;
 //alert('dsf');
 if(document.body.clientHeight <500) document.body.style.height = "500px";
 if(document.body.clientWidth <500) document.body.style.width = "500px";
 
    alert(window.event.srcElement);
 	//if(event.srcElement != document.body) return ;
    // return ;
 	// container.style.top = header.style.height;
	 var clientHeight = (document.body.clientHeight - header.clientHeight - footer.clientHeight);
	// if(clientHeight < 500) clientHeight = 500;
	 
     maincontent.style.height = rightsidebar.style.height = leftsidebar.style.height = container.style.height
	   = clientHeight +'px';
	 var clientWidth = (document.body.clientWidth - leftsidebar.clientWidth - rightsidebar.clientWidth);
	 //if(clientWidth < 600) clientWidth = 600;
	 maincontent.style.width = clientWidth +'px';
 }
function ShowCardInfo(card)
{
    var mycard = '00000000000000000';
    mycard = card;
    //alert('touch me');
    document.getElementById('rightcustomerframe').src ="./main/RightMenu.aspx?ucard=" +mycard;
    if(IsOpen == false)
    {
        rightfollowImg.click();
    }
}
function doShowWinSwitcher()
{
    if(!event.altKey) return ;
    var win = openCenterWindow("./Utility/WinSwitcher.html","_blank","width=300,height=300");
    win.focus();
}
window.document.attachEvent( "onkeydown", doShowWinSwitcher );

if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.main.js");