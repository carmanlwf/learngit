// JavaScript Document

function reportError(msg,url,line) {
	var str = "Javascript Error: \n\n";
	str += "Err: " + msg + " on line: " + line+"\r\n";
	str += "url: " + url;
	//alert(str);
	//ClientLogHelper.write(str);
	return true;
}

window.onerror = reportError;

function switchAppSection()
{
	var followImg = event.srcElement;
	var appSection = followImg.parentElement.parentElement;
	var i;
	if(appSection.children(1).currentStyle.display == "none")
	{
		for(i=1;i<appSection.children.length;i++)
		{
			appSection.children(i).style.display = "block";
		}
		followImg.src = "../images/collapsed_no.gif";
	}else
	{
		for(i=1;i<appSection.children.length;i++)
		{
			appSection.children(i).style.display = "none";
		}
		followImg.src = "../images/collapsed_yes.gif";
	}
}

function setPopupSection(followImgId,isShow)
{
    var followImg = document.getElementById(followImgId);
	if(followImg.tagName != "IMG") 
	{
	   followImg = followImg.lastChild;
	}
	var appSection = followImg.parentElement.parentElement;
	var i;
	if(isShow=="1")
	{
		for(i=1;i<appSection.children.length;i++)
		{
			appSection.children(i).style.display = "block";
		}
		followImg.src = "../images/nofollow.gif";
		return "1";//show
	}else
	{
		for(i=1;i<appSection.children.length;i++)
		{
			appSection.children(i).style.display = "none";
		}
		followImg.src = "../images/plus.gif";
		return "0";//hidden
	}
}

function switchPopupSection()
{
	var followImg = event.srcElement;
	if(followImg.tagName != "IMG") 
	{
	   followImg = followImg.lastChild;
	}
	var appSection = followImg.parentElement.parentElement;
	var i;
	if(appSection.children(1).currentStyle.display == "none")
	{
		for(i=1;i<appSection.children.length;i++)
		{
			appSection.children(i).style.display = "block";
		}
		followImg.src = "../images/nofollow.gif";
		return "1";//show
	}else
	{
		for(i=1;i<appSection.children.length;i++)
		{
			appSection.children(i).style.display = "none";
		}
		followImg.src = "../images/plus.gif";
		return "0";//hidden
	}
}

var ClipboardHelper ={
    IsAutoCopy:true,
    Copy:function(text)
    {
	    var mainWin =  GetMainWindow();
	    if(mainWin == null ) mainWin = window ;
	    mainWin.clipboardData.setData("Text",text);
	},
	AutoCopy:function(text)
	{
	    if(!this.IsAutoCopy) return ;
	    this.Copy(text);
	}
}

function GridViewHelper()
{
	
}

//tableObj - 表对象
//isChecked - null 获取所有的 true 获取选择的  false 获取没选择的
//ctlCheckBoxObj - 触发获取请求的对象,此对象将不包含在列表中
//valueIsArr - 值（以,分割）自身是否要分解为数组
//返回value数组
function GridViewHelper.getCheckedValues(name,isChecked,valueIsArr)
{
    var values = [];
	var checkBoxs = GridViewHelper.getCheckedObjs(name,isChecked);
	for(i=0;i<checkBoxs.length;i++)
	{
	    if(valueIsArr)
	    {
	       values[values.length] = checkBoxs[i].value.split(",");
	    }else
	    {
	        values[values.length] = checkBoxs[i].value;
	    }
	}
    return values;
}

//tableObj - 表对象
//isChecked - null 获取所有的 true 获取选择的  false 获取没选择的
//ctlCheckBoxObj - 触发获取请求的对象,此对象将不包含在列表中
//
function GridViewHelper.getCheckedObjs(name,isChecked)
{
	var objs = [];
	
    var checkBoxs = document.all(name);
    if(typeof(checkBoxs) == 'undefined' || checkBoxs == null) return objs;
    if(typeof(checkBoxs.length) == 'undefined')
    {
        checkBoxs[0] = checkBoxs;
        checkBoxs.length = 1;
    }
	for(var i=0;i<checkBoxs.length;i++)
	{
	    var currCheckBox = checkBoxs[i];
		if(typeof(isChecked) == "undefined" || isChecked == null)
		{
			objs[objs.length] = currCheckBox;
		}
		else if(isChecked && currCheckBox.checked)
		{
			objs[objs.length] = currCheckBox;
		}
		else if(!isChecked && !currCheckBox.checked)
		{
			objs[objs.length] = currCheckBox;
		}
	}
	return objs;
}

function GridViewHelper.getParentElement(currObj,parentTagName)
{
	var currParentObj = currObj;
	while(currParentObj.tagName != parentTagName)
	{
		currParentObj = currParentObj.parentElement;
		if(currParentObj == null ) break; 
	}
	return currParentObj;
}

function GridViewHelper.doSelectAllCheckBox()
{
	var currCheckBox = event.srcElement;
	var currTable = currCheckBox.parentElement;
	var currChecked = currCheckBox.checked;
    var checkHelperObj = GridViewHelper.getCheckBoxHelperObj(currCheckBox);
    if(checkHelperObj == null) return null;
	var checkBoxs = checkHelperObj.checkBoxs;
	for(var i=0;i<checkBoxs.length;i++)
	{
		checkBoxs[i].checked =  currChecked;
		var currTrObj = checkHelperObj.trObjs[i];
		currTrObj.className = (checkBoxs[i].checked?"selected":"");
	}
	if(checkBoxs[0].checked) return checkBoxs[0];
	return null;
}


function GridViewHelper.getCheckBoxHelperObj(currCheckObj)
{
    var currCheckName = currCheckObj.name;
    if(currCheckName.substring(0,3) == 'all') currCheckName = currCheckName.substring(3);
	var checkHelperObjName = currCheckName+"helper";
	var checkHelperObj = window[checkHelperObjName];
	if(typeof(checkHelperObj) == 'undefined' || checkHelperObj == null)
	{
	    var allcheckbox = null;
	    
	    if(currCheckName.substring(0,3) == 'all')
	        allcheckbox = currCheckObj;
	    else
	        allcheckbox = document.getElementById("all"+currCheckName);
	    if(allcheckbox == null) return null;

	    checkHelperObj = window[checkHelperObjName] = {};
        var checkBoxs = document.all(currCheckName);
        if(typeof(checkBoxs.length) == 'undefined')
        {
            checkBoxs[0] = checkBoxs;
            checkBoxs.length = 1;
        }
	    checkHelperObj.checkBoxs = checkBoxs;
	    checkHelperObj.allcheckbox = allcheckbox;
	    checkHelperObj.trObjs = [];
	    for(var i=0;i<checkBoxs.length;i++)
	    {
		    var currTrObj = GridViewHelper.getParentElement(checkBoxs[i],"TR");
	        checkHelperObj.trObjs[i] = currTrObj;
	    }
	}
	return checkHelperObj;
}

function GridViewHelper.doSelectCheckBox(currCheckObj)
{
	if(typeof(currCheckObj) == "undefined" || currCheckObj == null) currCheckObj = event.srcElement;
	
	ClipboardHelper.AutoCopy(currCheckObj.value);
	
    var checkHelperObj = GridViewHelper.getCheckBoxHelperObj(currCheckObj);
    if(checkHelperObj == null) return null;
	var currTrObj = GridViewHelper.getParentElement(currCheckObj,"TR");
	if(currTrObj == null) return null;
	currTrObj.className = (currCheckObj.checked?"selected":"");
	
	var allcheckbox = checkHelperObj.allcheckbox;
	var checkBoxs = checkHelperObj.checkBoxs;

    var firstCheckedObj = null;
	allcheckbox.checked = true;
	for(var i=0;i<checkBoxs.length;i++)
	{
		if(!checkBoxs[i].checked)
		{
			allcheckbox.checked = false;
		}else if(firstCheckedObj == null)
		{
		    firstCheckedObj = checkBoxs[i];
		}
		if(!allcheckbox.checked && firstCheckedObj != null) break;
	}
	return firstCheckedObj;
}

function GridViewHelper.setSelectCheckBoxs(name,value)
{
	var allRadio = document.all(name);
	if(allRadio == null || typeof(allRadio) == 'undefined' ) return ;
    if(typeof(allRadio.length) == 'undefined')
    {
        allRadio[0] = allRadio;
        allRadio.length = 1;
    }
    value = ","+value+",";
	for(var i=0;i<allRadio.length;i++)
	{
		if(value.indexOf(","+allRadio[i].value+",")>=0) allRadio[i].click();
	}
}

function GridViewHelper.getRadioHelperObj(currRadioObj)
{
	var checkHelperObjName = currRadioObj.name+"helper";
	var checkHelperObj = window[checkHelperObjName];
	if(typeof(checkHelperObj) == 'undefined' || checkHelperObj == null)
	{
        checkHelperObj = window[checkHelperObjName] = {};

	    var allRadio = document.all(currRadioObj.name);
	    if(allRadio == null || typeof(allRadio) == 'undefined' ) return ;
        if(typeof(allRadio.length) == 'undefined')
        {
            allRadio[0] = allRadio;
            allRadio.length = 1;
        }
        checkHelperObj.allRadio = allRadio;
        checkHelperObj.trObjs = [];
	    for(var i=0;i<allRadio.length;i++)
	    {
	        allRadio[i].index = i;
		    var currTrObj = GridViewHelper.getParentElement(allRadio[i],"TR");
		    checkHelperObj.trObjs[i] = currTrObj;
	    }
	    checkHelperObj.checkedRadio = currRadioObj.checked?currRadioObj:null;
    }
    
    return checkHelperObj;
}
function GridViewHelper.doSelectRadio(currRadioObj)
{
	if(typeof(currRadioObj) == "undefined" || currRadioObj == null) currRadioObj = event.srcElement;

	ClipboardHelper.AutoCopy(currRadioObj.value);
	
    var checkHelperObj = GridViewHelper.getRadioHelperObj(currRadioObj);
    if(checkHelperObj == null) return null;
    var beforeSelectRadio = checkHelperObj.checkedRadio;
    if(beforeSelectRadio != null && beforeSelectRadio != currRadioObj)
    {
		var currTrObj = checkHelperObj.trObjs[beforeSelectRadio.index];
		currTrObj.className = "";
    }
	var currTrObj = checkHelperObj.trObjs[currRadioObj.index];
	currTrObj.className = "selected";
    checkHelperObj.checkedRadio = currRadioObj;
	return currRadioObj.value;
}

function GridViewHelper.setSelectRadio(name,value)
{
	var allRadio = document.all(name);
	if(allRadio == null || typeof(allRadio) == 'undefined' ) return ;
    if(typeof(allRadio.length) == 'undefined')
    {
        allRadio[0] = allRadio;
        allRadio.length = 1;
    }
	for(var i=0;i<allRadio.length;i++)
	{
		if(allRadio[i].value == value) allRadio[i].click();
			
	}
	
}

function getUserId()
{
    var mainWin = GetMainWindow();
    if(mainWin == null) return "";
    return mainWin.userId;
}

function doMakeCall(phoneNo,areaCode)
{
    if(typeof(phoneNo) != 'string' || phoneNo == null || phoneNo == "") return ;
    if(typeof(areaCode) != 'string' || areaCode == null ) areaCode = "";
    var mainWin = GetMainWindow();
    if(mainWin == null ) return ;
    if(mainWin.nclAgentInfo==null)
    {
        alert("请登录软电话!");
        return ;
    }
    mainWin.nclAgentInfo.doMakeCall(phoneNo,areaCode,window);
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

function openBrWindow(url,winName,width ,height,isMainOpen)
{
    if(typeof(isMainOpen) != "undefined" && isMainOpen)
    {
        try
        {
            return _mainWinRef.openBrWindow(url,winName,width ,height);
        }catch(ex){}
    }
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
	var top = (screen.availHeight - height) /2 ;
	if(top<0) top = 0;
	var left = (screen.availWidth - width) /2 ;
	if(left<0) left = 0;
	sFeatures += ",top=" + top+"," + "left=" + left ;
    var currwin = _mainWinRef;
	var win = window.open(url,winName,sFeatures);
	return win;    
}

function GetParentWindow(currWin)
{
    if(typeof(currWin) == "undefined" || currWin == null) currWin = window;
	var parentWin =	 (((currWin.parent != currWin) ? currWin.parent : null)
			|| currWin.opener || (currWin.dialogArguments
				&& currWin.dialogArguments.window));
	return parentWin;
}

function GetParentWindowForObject(objId)
{
	var parentWin = null;
	var currWin = window;
	while(true)
	{   
		parentWin = GetParentWindow(currWin);
		if(parentWin == currWin) return null;
		currWin = parentWin;
		if(parentWin == null) break;
		if(typeof(parentWin[objId]) != "undefined") break; 
	}
	return parentWin;
	
}

function GetMainWindow(isSearch)
{
    if(typeof(isSearch) != 'undefined' && isSearch)
        return GetParentWindowForObject("MainApp");
    else 
        return _mainWinRef;
}

function ShowWindowAtMainFrame(url)
{
	var mainWin = GetMainWindow();
	if(mainWin == null) return ;
	mainWin.main.location.href = url;
}

function DoResultClientProcess(isOk,msg,isCloseSelfWindow,isRefreshParentWindow)
{
	if(msg != "")
	{
		alert(msg);
	}
	if(isRefreshParentWindow)
	{
		var parentWin =	 GetParentWindow();
		if(parentWin != null)
		{
		    // parentWin.document.execCommand("Refresh");
		    parentWin.location.href = parentWin.location.href;
		}
	}
	
	var selfNow=GetParentWindow();
	if(selfNow.name=="smswindow8") selfNow.close();
	if(isCloseSelfWindow) window.close();	
}

function ShowDialog(url, width, height,modal,args)
{
	if(typeof(modal)=='undefined') modal = true;
	if(typeof(args)=='undefined') args = window;
		
	if(modal)
	{
		return showModalDialog(url, args, "dialogWidth:" + width + "px;dialogHeight:" + height + "px;help:no;scroll:no;status:no");
	}
	else 
	{
		return showModelessDialog(url, args, "dialogWidth:" + width + "px;dialogHeight:" + height + "px;help:no;scroll:no;status:no");
	}

}

var TreeViewHelper = {
    setReadOnly:function(Id)
    {
        var treeObj = document.getElementById(Id);
        var checkBoxs = treeObj.getElementsByTagName("INPUT");
        for(var i=0;i<checkBoxs.length;i++)
        {
            checkBoxs[i].disabled = true;
        }
    },
    setHidden:function(Id,index)
    {
        var treeObj = document.getElementById(Id);
        var tables = treeObj.getElementsByTagName("TABLE");
        for(var i=0;i<tables.length;i++)
        {
            if(i==index)
            {
                tables[i].style.display="none";
                break;
            }
        }
    }
}

var CheckBoxListHelper = {
    doSelectAll:function (checkBoxListId,ctlCheckBoxId)
    {
        var ctlCheckBox = document.getElementById(ctlCheckBoxId);
        var i=0;
        while(true)
        {
            var currCheckBox = document.getElementById(checkBoxListId+"_"+i);
            if(typeof(currCheckBox) == "undefined" || currCheckBox == null) break;
            currCheckBox.checked = ctlCheckBox.checked;
            i++;
        }
    }
}

function doAjaxCallTools(funname,param1,param2)
{
    var params = "";
    var i=0;
    for(i=1;i<arguments.length;i++)
	{
	    params += "&param=" + arguments[i];
	}
   return XmlHttpHelper.synCall("../main/CallTools.aspx?funname="+funname+params)
}

function doAjaxBindSelect(selectId,funname,param)
{   
    var oSelect = document.getElementById(selectId);
    if(oSelect == null) return false;
    var result = doAjaxCallTools(funname,param);
    doBindSelect(oSelect,result,"");
	return true;
}

function doAjaxBindCodesToListControl(selectId, typecode, tablename, defaultValue,connString)
{
    var oSelect = document.getElementById(selectId);
    if(oSelect == null) return false;
    if(typeof(typecode)=="undefined" || typecode == null) typecode = "";
    if(typeof(tablename)=="undefined" || tablename == null) tablename = "";
    if(typeof(defaultValue)=="undefined" || defaultValue == null) defaultValue = "";
    if(typeof(connString)=="undefined" || connString == null) connString = "";
    var result = doAjaxCallTools("BindCodesToListControl",typecode,tablename,connString);
    doBindSelect(oSelect,result,defaultValue);
	return true;    
}


function BindNormalTableToListControl(selectId, codefield, namefield, tablename, sortedby, filter, defaultValue, connString)
{
    var oSelect = document.getElementById(selectId);
    if(oSelect == null) return false;
    if(typeof(codefield)=="undefined" || codefield == null) codefield = "";
    if(typeof(namefield)=="undefined" || namefield == null) namefield = "";
    if(typeof(tablename)=="undefined" || tablename == null) tablename = "";
    if(typeof(sortedby)=="undefined" || sortedby == null) sortedby = "";
    if(typeof(filter)=="undefined" || filter == null) filter = "";
    if(typeof(defaultValue)=="undefined" || defaultValue == null) defaultValue = "";
    if(typeof(connString)=="undefined" || connString == null) connString = "";
    var result = doAjaxCallTools("BindNormalTableToListControl",codefield, namefield, tablename, sortedby, filter, defaultValue, connString);
    doBindSelect(oSelect,result,defaultValue);
	return true;    
}

function doBindSelect(oSelect,shashtable,defaultValue)
{
    var fixedItemCount = oSelect.getAttribute("fixedItemCount");
    if(typeof(fixedItemCount) == "undefined" || fixedItemCount == null)
        fixedItemCount = "1";
    try
    {
        fixedItemCount = parseInt(fixedItemCount);
    }catch(e)
    {
        fixedItemCount = 0;
    }
	while (oSelect.childNodes.length > fixedItemCount) {
		oSelect.removeChild(oSelect.childNodes[fixedItemCount]);
	}
	if(shashtable == null || shashtable == "") return true;
    var hashtable = shashtable.parseJSON();
    for (key in hashtable)
    {
        if (!hashtable.hasOwnProperty(key)) continue;
        var value = hashtable[key];
		var option = document.createElement("OPTION");
		option.value = key;
		option.text = value;
		if(defaultValue == key) option.selected = true;
		oSelect.options.add(option);
	}    
}

function doBindSelectDefault()
{
	for(i=0;i<arguments.length;i+=2)
	{
        var oSelect = document.getElementById(arguments[i]);
        oSelect.value = arguments[i+1];
        if(oSelect.onchange != null) oSelect.onchange();
    }
}

function doShowWinSwitcher() {
    return;
    if(!event.altKey) return ;
    var win = openCenterWindow("../Utility/WinSwitcher.html","_blank","width=300,height=300");
    win.focus();
}
window.document.attachEvent( "onkeydown", doShowWinSwitcher );

var FormViewHelper = {
    SetFocus : function(firstFocusInputId)
    {
		if(typeof(firstFocusInputId) != "undefined" && firstFocusInputId != null)
		{
		    var firstFocusInputObj = document.getElementById(firstFocusInputId); 
		    if(firstFocusInputObj != null)
		    {
		        try
		        {
                    firstFocusInputObj.focus();
                    var   rng   =   firstFocusInputObj.createTextRange();     
                    rng.moveStart("character",firstFocusInputObj.value.length);  
                    rng.collapse(false);       
                    rng.select();     
		        }catch(e){}
		    }
		}
 
    },
    EnterToTab : function(formId,firstFocusInputId)
    {
        FormViewHelper.SetFocus(firstFocusInputId);
        
        var frmobj = document.getElementById(formId); 
	    if(typeof(frmobj) == 'undefined' || frmobj == null)
		    return;
        
        frmobj.attachEvent("onkeydown", frmobj_onkeydown);    
	    function frmobj_onkeydown()
	    {
		    if(event.srcElement.type =='textarea' || event.srcElement.type =='button') 
		    { // button 和 textarea不需要将回车换为tab
			    return ;
		    }
		    if(event.keyCode == 13)
		    {
			    event.keyCode = 9;
		    }
	    }
	    return ;
    },
    EnterToSumbit : function(formId,firstFocusInputId,submitBtnId)
    {
        FormViewHelper.SetFocus(firstFocusInputId);
        
        var frmobj = document.getElementById(formId); 
	    if(typeof(frmobj) == 'undefined' || frmobj == null)
		    return;
        
        var submitBtnObj = null;
 		if(typeof(submitBtnId) != "undefined" && submitBtnId != null)
		    submitBtnObj = document.getElementById(submitBtnId); 
        if(submitBtnObj == null)
        {
	        // 将焦点定位到form的第一个显示的元素上
	        for(i=0;i<frmobj.length;i++)
	        {
		        if(frmobj[i].type == 'button')
		        {
		            submitBtnObj = frmobj[i];
    		        break;
    		    }
	        }	
        }
		if(submitBtnObj == null) return ;
		   
        frmobj.attachEvent("onkeydown", frmobj_onkeydown);    
	    function frmobj_onkeydown()
	    {
		    if(event.srcElement.type =='textarea' || event.srcElement.type =='button') 
		    { // button 和 textarea不需要将回车换为tab
			    return ;
		    }
		    if(event.keyCode == 13)
		    {
			    event.keyCode = 0;
			    submitBtnObj.click();
		    }
	    }
	    return ;
    }   
    
    
}

var WaitHelper = 
{
    showWaitMessage:function(msg) {
        WaitHelper.closeWaitMessage();
        if(typeof(msg) != 'string' || msg == null || msg == "")
        msg = "Please waiting ...";
	    var waitwin = document.createElement("div");
	    document.body.appendChild(waitwin);
 	    var top = 3;
	    var left = 3;
    /*	
	    var html = '<div id="waitwin" style="left:'+left+'px;top:'+top+'px;'
	    +'position:absolute;z-index:79000;background-color:#FFF0C8;'
	    +'white-space:nowrap;border:1px solid #77a;padding:6px;">'
	    +'<img alt="." src="../images/progress.gif"/> '
	    +msg+'</div>';*/
        var style = "left:50%;margin-left:-110px;";
	    var html = '<div id="waitwin" style="left:'+left+'px;top:'+top+'px;'
	    +'position:absolute;z-index:79000;'
	    +'width:300px;height:60px;top:50%;margin-top:-62px;'+style+'">'
	    +'<iframe style="width:180px;margin:0;height:40px;" id="waitwiniframe"'
	    +' name="waitwiniframe" frameborder="0" scrolling="no" src="../js/waiter/WaitWin.html"></iframe></div>';

        waitwin.outerHTML = html;
        if(event == null)
        {
            window.attachEvent( "onload", WaitHelper.closeWaitMessage );
        }
        else
        {
           var btn = event.srcElement ;
           btn.disabled = true;
           //window.setTimeout("try{document.getElementById('"+btn.id+"').disabled=false;}catch(e){}",8000);
        }
    },

    initWaitMessageButtons:function(btnIds)
    {
        if(typeof(btnIds) == "string")
        {
            var btnIds = btnIds.split(",");
            for(var i=0;i<btnIds.length;i++)
            {
                var currBtn = document.getElementById(btnIds[i]);
                if(currBtn == null) continue;
                //objs[objs.length] = currBtn;
                WaitHelper.initWaitMessageButtons(currBtn);
            }
            return ;
         }
        var currBtn = btnIds;
        if ( currBtn.onclick != null )
        {
            var oldOnclick = currBtn.onclick;
            if(oldOnclick.toString().indexOf("__doPostBack")<0) return;
            currBtn.onclick = function ()
            {
	            var result = oldOnclick();
	            if(typeof(result) == "undefined" || result)
	                WaitHelper.showWaitMessage();
            };
        }
        else 
        {
            currBtn.onclick = WaitHelper.showWaitMessage();
        }        
    },

    initWaitMessageForms:function(formId)
    {
        var frmobj = document.getElementById(formId); 
        if(typeof(frmobj) == 'undefined' || frmobj == null)
	        return;
        // 将焦点定位到form的第一个显示的元素上
        for(i=0;i<frmobj.length;i++)
        {
            if(frmobj[i].type == 'button') WaitHelper.initWaitMessageButtons(frmobj[i]);
        }
    },

    closeWaitMessage:function()
    {
        try
        {
            var waitwin = document.getElementById("waitwin");
            if(waitwin != null)
            {
              waitwin.parentNode.removeChild(waitwin);
            }
        }catch(ex){alert(ex);};
    },
    initWaitWin:function(url,msg,param)
    {
        if(typeof(url) == 'undefined' || url == null) url = "";
        if(typeof(msg) == 'undefined' || msg == null || msg == "" ) msg = "正在处理中，请稍候...";
        if(typeof(param) == 'undefined' || param == null) param = "";
        
	    var html = '<form id="waitfrm" action="../Utility/Wait.aspx" target="_blank" method="post">'
                +'<input type="hidden" id="url" name="url" value="'+url+'" />'
                +'<input type="hidden" id="param" name="param" value="'+param+'" />'
                +'<input type="hidden" id="msg" name="msg" value="'+msg+'" />'
                +'</form>';
	    document.write(html);
    },
    showWaitWin:function(param)
    {
        try
        {
            var createExcelfrm = document.getElementById("waitfrm");
            var paramObj = document.getElementById("param");
            paramObj.value = param;
            createExcelfrm.submit();
        }catch(e){}
    },
    initFileDownloadWaitWin:function(url,msg,param)
    {
        if(typeof(url) == 'undefined' || url == null) url = "";
        if(typeof(msg) == 'undefined' || msg == null || msg == "" ) msg = "正在处理中，请稍候...";
        if(typeof(param) == 'undefined' || param == null) param = "";
	   
	    var waitwin = document.createElement("div");
	    document.body.appendChild(waitwin);
        
	    var html = '<form id="filedownloadfrm" action="'+url+'" target="filedownloadwin" method="post">'
                +'<input type="hidden" id="url" name="url" value="'+url+'" />'
                +'<input type="hidden" id="param" name="param" value="'+param+'" />'
                +'<input type="hidden" id="msg" name="msg" value="'+msg+'" />'
                +'</form>'
                +'<iframe id="filedownloadwin" name="filedownloadwin" style="display:none" src=""></iframe>';

	    waitwin.outerHTML = html;
    },
    showFileDownloadWaitWin:function(param)
    {
        try
        {
            WaitHelper.showWaitMessage();
            var filedownloadfrm = document.getElementById("filedownloadfrm");
            var paramObj = document.getElementById("param");
            paramObj.value = param;
            filedownloadfrm.submit();
            if(event != null)
            {
               var btn = event.srcElement ;
               window.setTimeout("try{document.getElementById('"+btn.id+"').disabled=false;}catch(e){}",8000);
            }
        }catch(e){WaitHelper.closeWaitMessage();}
    }

}

var ClientLogHelper = {
    init:function()
    {
	    var clientlogdiv = document.createElement("div");
	    document.body.appendChild(clientlogdiv);
        var html = '<iframe id="clientlogwin" name="clientlogwin" style="display:none" src=""></iframe>';  
  	    clientlogdiv.outerHTML = html;
    },
    write:function(msg,category)
    {
        try
        {
            if(typeof(clientlogwin) == "undefined" || clientlogwin == null) return ;
            if(typeof(msg) == "undefined" || msg == null || msg=="") return ;
            if(typeof(category) == "undefined" || category == null || category=="") category = "Client";
            msg = encodeURIComponent(msg);
            category = encodeURIComponent(category);
            clientlogwin.location.href = "../Utility/ClientLogHelper.aspx?msg="+msg+"&category="+category;
        }catch(e){}
    }

}

window.attachEvent( "onload", ClientLogHelper.init );

function WinOnBeforeUnloadLive()
{
      var msg = "don't close me!";
      event.returnValue = msg;
      var   wsh   =   new   ActiveXObject("WScript.Shell");   
      wsh.sendKeys("{ESC}");              
}

var DivCover = {
    init:function()
    {
        var html = "<iframe id='divCover' name='divCover' frameBorder=0 width=1 height=1></iframe>";
        document.write(html);
    },
    show:function()
    {
        var divCover = document.getElementById("divCover");
        divCover.className = 'divCover_';
    },
    hidden:function()
    {
        var divCover = document.getElementById("divCover");
        divCover.className = 'divCover';
    }
}

if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.edit.js");
    
    
var _mainWinRef = GetMainWindow(true);


//新添加2013-5-15************************************************************************
function cardinfo(callback) {
    $.post("../usercontrol/MemberInfo.ashx", { cardOrcell: encodeURI($.trim($("#UserCardInfo1_card").val())) },
                function(data) {
                    if (data.no == 0) {
                        $.ligerDialog.question('请确认卡号或手机号是否正确!');
                        $("#UserCardInfo1_card").focus();
                    }
                    else {
                        $("#UserCardInfo1_RealName").val(data.RealName);
                        $("#UserCardInfo1_CellPhone").val(data.CellPhone);
                        $("#UserCardInfo1_RankName").val(data.RankName);
                        $("#UserCardInfo1_Birthday").val(data.BirthDate);
                        $("#UserCardInfo1_sex").val(data.Sex);
                        $("#UserCardInfo1_StatuName").val(data.StatuName);
                        $("#UserCardInfo1_status").val(data.status);
                        $("#UserCardInfo1_Points").val(data.Points);
                        $("#UserCardInfo1_Address").val(data.Address);
                        $("#UserCardInfo1_ActiveTime").val(data.ActiveTime);
                        $("#UserCardInfo1_SiteName").val(data.sitename);
                        $("#UserCardInfo1_idtype").val(data.idtype);
                        $("#UserCardInfo1_idno").val(data.idno);
                        /**判断是否为无名单[没手机号] ***/
                        if (data.CellPhone != "")
                            data.isactivename = "True";
                        else
                            data.isactivename = "False";
                        /*********************************/
                        //label控件赋值
                        $("#UserCardInfo1_lbName").html("<font color='red'>" + data.RealName + "</font>");
                        $("#UserCardInfo1_lbRank").html("<font color='red'>" + data.RankName + "</font>");
                        $("#UserCardInfo1_lbPoint").html("<font color='red'>" + data.Points + "</font>");
                        $("#UserCardInfo1_lbBalance").html("<font color='red'>" + data.balance + "</font>");

                        //以下是隐藏inputtext控件赋值
                        $("#UserCardInfo1_UserId").val(data.UserId);
                        $("#UserCardInfo1_balance").val(data.balance);
                        $("#UserCardInfo1_Margcard").val(data.card);

                        //以下是宿主页面隐藏inputtext控件赋值
                        $("#cardsnr").val(data.card);
                        $("#validDate").val(data.validDate);
                        //$("#typeid").val(parseInt(data.typeid)); //卡类型
                        var CurrentPath = window.location.pathname;
                        if (data.isactivename == "False") { //没有手机号码,不能挂失
                            if (CurrentPath.indexOf("CardLock.aspx")> 0 || CurrentPath.indexOf("CardUnLock.aspx")> 0)
                                $.ligerDialog.question('未登记手机号码,不能执行此项操作!');
                            else {
                                if ("undefined" != typeof vtype)
                                    vtype.selectValue(parseInt(data.typeid));
                                //卡有效期
                                if ("undefined" != typeof $("#validDate"))
                                    $("#validDate").val(data.validDate);
                                if (typeof (callback) == "function")
                                { callback(); }
                            }
                        }
                        else if (data.status == "2") {//处于挂失状态的卡,只能在解挂页面操作
                            if (CurrentPath.indexOf("CardUnLock.aspx")> 0 ) {
                                if ("undefined" != typeof vtype)
                                    vtype.selectValue(parseInt(data.typeid));
                                //卡有效期
                                if ("undefined" != typeof $("#validDate"))
                                    $("#validDate").val(data.validDate);
                                if (typeof (callback) == "function")
                                { callback(); }
                            }
                            else {
                                $.ligerDialog.question('此卡已挂失,请先解除挂失!');
                            }
                        }
                        else if (data.status == "3") {//处于注销状态的卡                            
                            $.ligerDialog.question('此卡已注销!');
                        }
                        else
                            if (data.status == "4") {
                            if (CurrentPath.indexOf("CardLock.aspx")> 0)
                            { $.ligerDialog.question('此卡已注销!'); }
                            else {
                                if ("undefined" != typeof vtype)
                                    vtype.selectValue(parseInt(data.typeid));
                                //卡有效期
                                if ("undefined" != typeof $("#validDate"))
                                    $("#validDate").val(data.validDate);
                                if (typeof (callback) == "function")
                                { callback(); }
                            }
                        }
                        else {
                            if ("undefined" != typeof vtype)
                                vtype.selectValue(parseInt(data.typeid));
                            //卡有效期
                            if ("undefined" != typeof $("#validDate"))
                                $("#validDate").val(data.validDate);
                            if (typeof (callback) == "function")
                            { callback(); }
                        }
                    }
                }, "json")
}
//新添加2013-5-15************************************************************************
//新添加2013-5-29***************后台引用前台js关闭窗口方法*********************************************************
//使用方法
//ClientScriptManager cs = Page.ClientScript;
//               Type cstype = this.GetType();
//               string msg = "添加用户成功";
//              if (!cs.IsStartupScriptRegistered(cstype, "ReturnWin"))
//               {
//                   cs.RegisterStartupScript(cstype, "ReturnWin", "<script>CloseWin('" + msg + "');</script>");
//               }
function CloseWin(msg) {
    alert(msg);
    close();
}