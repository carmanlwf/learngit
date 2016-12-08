// JScript 文件

var CallHelper = {
    CallToolsUrl:"CallTools.aspx",
    IsCanNotReady:function()
    {
        var mainWin = GetMainWindow();
	    if(mainWin == null || typeof(mainWin.rightcustomerframe)=="undefined") return true;
	    var cust_id = mainWin.rightcustomerframe.getCurrentCustomerId();
	    if(cust_id == null || cust_id =="")
	    {
	         return false;
	    }
	    return true;
        
    },
    SaveSelectList:function(userid,selectListId, typecode, ContNoValue)
    {
        var selectList ="";
    	var selectCtl = document.getElementById(selectListId);
    	if(selectCtl == null) return ;
    	for(var i=0;i<selectCtl.options.length;i++)
    	{
    	    var option = selectCtl.options[i];
    	    if(selectList != "") selectList += ",";
    	    selectList += option.value;
    	}
        XmlHttpHelper.synCall(CallHelper.CallToolsUrl+"?funname=SaveSelectList&param="+userid+"&param="+selectList+"&param="+typecode+"&param="+ContNoValue);

    },
    setCurrentCustomerInfo:function(params,isCallIn,winMakecallSrc)
    {
        var mainWin = GetMainWindow();
	    if(mainWin == null || typeof(mainWin.rightcustomerframe)=="undefined") return ;
	    mainWin.rightcustomerframe.doReloadCustInfo("../main/curCustInfo.aspx?"+params);
	    if(typeof(isCallIn) != "undefined" && isCallIn)
	    {
	        //mainWin.logHelper.write(params);
	        mainWin.showFollowSiderBar("rightfollowbar","rightsidebar",true);
	    }
	    if(typeof(winMakecallSrc) != 'undefined' && winMakecallSrc != null && winMakecallSrc != mainWin.rightcustomerframe && winMakecallSrc.parent != mainWin.rightcustomerframe)
	    {
	        mainWin.rightcustomerframe.blur();
	        window.setTimeout(winMakecallSrc.focus,"1000");
	    }
    },
    RefreshCallInfoList:function()
    {
        var mainWin = GetMainWindow();
	    if(mainWin == null || typeof(mainWin.rightcustomerframe)=="undefined") return ;
	    mainWin.rightcustomerframe.refreshCallInfoList();
    },
    GetPhoneNo:function(phoneNo,gatewayCode)
    {
/*        var telnumber = phoneNo;
        if(phoneNo.charAt(0) == '0')
        {
            telnumber = '9' + phoneNo + '#';
        }*/
        if(typeof(gatewayCode) == "undefined")
        {
            gatewayCode = "";
        }
        var telnumber = XmlHttpHelper.synCall(CallHelper.CallToolsUrl+"?funname=GetPhoneNo&param="+phoneNo+"&param="+gatewayCode);
        //alert(telnumber);
        return telnumber;
    },
    SplitCallID:function(strPhoneNum)
    {
        return XmlHttpHelper.synCall(CallHelper.CallToolsUrl+"?funname=SplitCallID&param="+strPhoneNum);
    },
    UpdateAgentStatus:function(userId,currState,strCallID)
    {
      XmlHttpHelper.asynCall(CallHelper.CallToolsUrl+"?funname=UpdateAgentStatus&param="+userId+"&param="+currState+"&param="+strCallID);
    },
    InsertCallInfo:function(callid,in_flag,seconds,wrapup_seconds,start_time,agent_id,callnumber,cust_id,area_code)
    {
      if(callnumber == null || callnumber == "") return ;
      XmlHttpHelper.asynCall(CallHelper.CallToolsUrl+"?funname=InsertCallInfo&param="+callid+"&param="+in_flag+"&param="+seconds+"&param="+wrapup_seconds+"&param="+start_time+"&param="+agent_id+"&param="+callnumber+"&param="+cust_id+"&param="+area_code);
      window.setTimeout("CallHelper.RefreshCallInfoList()",1500);
    },
    GetSysPara:function(name)
    {
      return XmlHttpHelper.synCall(CallHelper.CallToolsUrl+"?funname=GetSysPara&param="+name);
    },
    GetCustBizInfo:function(name)
    {
      return XmlHttpHelper.synCall(CallHelper.CallToolsUrl+"?funname=GetCustBizInfo&param="+name);
    },
    GetCustInfo:function(propName)
    {
      return XmlHttpHelper.synCall(CallHelper.CallToolsUrl+"?funname=GetCustInfo&param="+propName);
    },
    PrepareIvrPwdData:function()
    {
        return XmlHttpHelper.synCall(CallHelper.CallToolsUrl+"?funname=PrepareIvrPwdData");
    },
    UscSrvcReqAcceptTransfered:function(g_tmpSerID, g_tmpCustID)
    {
        //mainWin.logHelper.write(g_tmpSerID+"#"+g_tmpCustID);
        //ShowWindowAtMainFrame("../AA/ServiceTabs.aspx?action=AcceptTransfered&SerID="+g_tmpSerID+"&CustID="+g_tmpCustID);
        top.leftnavframe.showNewServices();
        top.newServices.doCopyService(g_tmpSerID);

    },
    ObScreenPopDataArrival:function ( ScreenPopObject)
    {
        return ObHelper.onScreenPopDataArrival(ScreenPopObject);
    }
    
}
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.call.js");