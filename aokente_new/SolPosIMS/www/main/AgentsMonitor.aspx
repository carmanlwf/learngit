<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="AgentsMonitor.aspx.cs" Inherits="main_AgentsMonitor" EnableSessionState="ReadOnly" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<title>实时用户状态监控</title>
<script language="JavaScript" type="text/javascript" src="../js/app.edit.js"></script>
<script language="JavaScript" type="text/javascript" src="../js/app.dateex.js" charset="gb2312"></script>
<script language="JavaScript" type="text/javascript" src="../Msger/sendmsg.js" charset="gb2312"></script>
<style>
#agentsstatus {
	table-layout:fixed;
	 border-top:3px;
	 margin-top:2px;
	 width:100%;
	 }
</style>
<script>
ClipboardHelper.IsAutoCopy = false;
var agentState = {
        eAvailable:3,//空闲
        eBusyOther:7,//
        eHold:10,//
        eLogin:0,//
        eLogout:1,//
        eNotReady:2,//休息
        eReserved:8,//
        eTalking:4,//通话
        eUnknown: 9,//
        eWorkNotReady:5,//案头
        eWorkReady: 6//案头
}

var btnRefesh = null;
var refeshsecond =null;
var nextrefeshtime = new Date();
var agentsstatus = null;

var currSelectAgentId = "";
var currSelectAgentStatus = 9;
var currSelectCallId = "";
var currAgentIsSuper = <%=Ims.Main.ImsInfo.CurrentUser.IsSupervisor?"true":"false"%>;
var mainWin = null;
function onTimer()
{
    if(nextrefeshtime.dateDiff(new Date()) <= 0)
    {
        doCalNextRefreshTime();
        btnRefesh.click();
    }
    doCalAccessTime();
}

function doOnLoad()
{
    mainWin = GetMainWindow();
    try
    {
        if(mainWin != null) mainWin.webSoftPhone.winAgentsMonitor = window;
    }catch(e){}
    
    agentsstatus = document.getElementById("agentsstatus");
    btnRefesh = document.getElementById("btnRefesh");
    refeshsecond = document.getElementById("refeshsecond");
    
    GridViewHelper.setSelectCheckBoxs("selectCheckboxButton1",'<%=currSelectAllAgentId%>');
    doCalNextRefreshTime();
    doCalAccessTime();
    window.setInterval("onTimer()",5*1000);
    var allSelectCbx = document.getElementById("allselectCheckboxButton1");
    if(!allSelectCbx.checked)
    {
        allSelectCbx.click();
    }
    
}

function doCalNextRefreshTime()
{
    nextrefeshtime = (new Date()).dateAdd("s",parseInt(refeshsecond.value==""?99999:refeshsecond.value));
}

function doCalAccessTime()
{
    if(agentsstatus == null) return ;
    for(var i=1;i<agentsstatus.rows.length;i++)
    {
        var tr = agentsstatus.rows(i);
        if(tr.cells.length < 8) continue;
        var access_status = 9;
        try
        {
            access_status = parseInt(tr.cells(5).innerHTML);
        }catch(e){};
        switch(access_status)
        {
            case agentState.eLogout:
            case agentState.eUnknown:
            tr.cells(8).innerHTML = "";
            continue;
            break;
        } 
        
        var access_time = tr.cells(7).innerHTML;
        if(access_time.length != 19) continue;
        var t = Date.instanceFromString(access_time);
        tr.cells(8).innerHTML = Date.secondsToFormatStr( (mainWin.servertime).dateDiff(t));
    }

}

function setupBtns(btnIds,enabled,display)
{
    btnIds = btnIds.split(",");
    for(var i=0;i<btnIds.length;i++)
    {
        var btnId = btnIds[i];
	    var btnObj = document.getElementById(btnId);
	    if(btnObj == null) continue;
    	
	    btnObj.disabled = !enabled;
	    var liObj = btnObj.parentElement;
	    if(display)
	    {
		     liObj.style.display = "block";
		     btnObj.style.display = "";
	    }
	    else 
	    {
		     liObj.style.display = "none";
		     btnObj.style.display = "none";
	    }
	}
}

function onRefeshSecondChange()
{
    doCalNextRefreshTime();
}

function onSelectAllCheckBox()
{
   var currRadioObj = GridViewHelper.doSelectAllCheckBox();
   onSelectAgentChange(currRadioObj); 
}

function onSelectCheckBox()
{
   var currRadioObj = GridViewHelper.doSelectCheckBox();
   onSelectAgentChange(currRadioObj); 
}

function onSelectAgentChange(currRadioObj)
{
    if(currRadioObj == null)
    {
        currSelectAgentId = "";
        return ;
    }
    var currTrObj = GridViewHelper.getParentElement(currRadioObj,"TR");
    currSelectAgentId = currRadioObj.value;
    currSelectAgentStatus = 9;
    try
    {
        currSelectAgentStatus = parseInt(currTrObj.cells(5).innerHTML);
    }catch(e){};
    currSelectCallId = "";
    
    setupBtns("sbtnReady,sbtnLogout,sbtnSilentMonitor,sbtnStopSilentMonitor,sbtnBargeIn,sbtnInterceptCall",false,true);
    switch(currSelectAgentStatus)
    {
        case agentState.eLogin:
        case agentState.eLogout:
        case agentState.eUnknown:
        case agentState.eBusyOther:
        break;
        case agentState.eAvailable:
            setupBtns("sbtnLogout",true,true);
        break;
        case agentState.eHold:
        case agentState.eReserved:
        case agentState.eTalking:
            currSelectCallId = currTrObj.cells(9).innerHTML;
            setupBtns("sbtnSilentMonitor,sbtnStopSilentMonitor,sbtnBargeIn,sbtnInterceptCall",true,true);
        break;
        case agentState.eNotReady:
            setupBtns("sbtnReady,sbtnLogout",true,true);
        break;
        case agentState.eWorkNotReady:
        case agentState.eWorkReady:
            setupBtns("sbtnReady,sbtnLogout",true,true);
        break;
        
    } 
    
   //alert(currSelectCallId);
}

function getCurrentSelectAgentId()
{
    if(currSelectAgentId == null || currSelectAgentId.length <=0 )
    {
      currSelectAgentId = "";
      return "";
    }
    if(currSelectAgentId.charAt(0) == '*') return currSelectAgentId.substr(1);
    return currSelectAgentId;
}

function getCurrentSelectAgentIsSuper()
{
    if(currSelectAgentId == null || currSelectAgentId.length <=0 )
    {
      return false;
    }
    if(currSelectAgentId.charAt(0) == '*') return true;
    return false;
    
}

function doMonitorAgent(toDo)
{
    var mainWin = GetParentWindowForObject("webSoftPhone");
    if(mainWin == null)
    {
        alert("???你从哪里进来的???");
        return ;
    }
    if(mainWin.webSoftPhone == null)
    {
        alert("???请确认你是否登录了软电话???");
        return ;
    }
    var result = mainWin.nclAgentInfo.doMonitorAgent(getCurrentSelectAgentId(),toDo);
//    if(result >0)
//    {
//        alert("操作成功！");
//    }else
//    {
//        alert("操作失败！");
//    }
    
    btnRefesh.click();
}

function doSendMsg()
{
    var cAgentId = getCurrentSelectAgentId();
    if(cAgentId =="" )
    {
        alert("请选择用户！");
        return ;
    }
/*  if(!currAgentIsSuper && !getCurrentSelectAgentIsSuper())
    {
        alert("只能和组长交谈！");
        return ;
    }
    if(!currAgentIsSuper) 
    {
        sendAgentMsg(cAgentId);
    }
    else*/
    {
        var currallselectValues = GridViewHelper.getCheckedValues("selectCheckboxButton1",true,false);
        currallselectValues = currallselectValues.join(",").replace(/\*/g,"");
        sendAgentMsg(currallselectValues);
    }
    //(currSelectAgentId,"");
}

function doQC()
{
    var cAgentId = getCurrentSelectAgentId();
    if(cAgentId =="" )
    {
        alert("请选择用户！");
    }
    else
    {
    if(cAgentId == "")
    {
       cAgentId="148416.4670";
    }
    window.open('../QC/QcOnlineMonitor.aspx?agentid='+cAgentId+'&callid='+currSelectCallId , 'aaQcOperation') ;
    }
}
</script>
</head>

<body onload="doOnLoad()">
<div class="popupsection" style="width:570px;">
<h1 class="titlepopupred" style="width:100%" onclick="switchPopupSection()">∴ 用户状态监控<img src="../images/nofollow.gif" class="titlepopupimg" /></h1>
<form id="Form1" runat="server">
 <div style="width:572px;" class="grid_section"><div class="data" style="height:530px;overflow:auto;">
<asp:GridView Width="540px" ID="agentsstatus" name="agentsstatus" runat="server" SkinID="GridView_Red" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="AgentsStatusInfoDataSource" PageSize="20" AllowSorting="True" OnRowCreated="agentsstatus_RowCreated" ShowFooter="True">
    <Columns>
           <asp:TemplateField>
               <HeaderTemplate>
                   <input type="checkbox" id="allselectCheckboxButton1" name="allselectCheckboxButton1"  onclick="onSelectAllCheckBox()" />
              </HeaderTemplate>
                <ItemTemplate>
                    <input type="checkbox" id="selectCheckboxButton1" name="selectCheckboxButton1" value="<%#((bool)Eval("superflag"))?"*":""%><%# Eval("id")%>" onclick="onSelectCheckBox()" />
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th"/>
                <HeaderStyle Width="25px" />
            </asp:TemplateField>
        <asp:TemplateField HeaderText="工号" SortExpression="id">
        <ItemTemplate>
            <a href="javascript:void(0)" onclick="sendAgentMsg('<%#Eval("id")%>')" ><%#((bool)Eval("superflag"))?"*":""%><%#Eval("id")%></a>
        </ItemTemplate>
        <HeaderStyle Width="49px" />
        </asp:TemplateField>
        <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" >
            <HeaderStyle Width="49px" />
        </asp:BoundField>
        <asp:BoundField DataField="groupid" HeaderText="组号" SortExpression="groupid">
            <HeaderStyle Width="38px" />
        </asp:BoundField>
        <asp:BoundField DataField="access_phone" HeaderText="分机" SortExpression="access_phone">
            <HeaderStyle Width="49px" />
        </asp:BoundField>
        <asp:BoundField DataField="access_status">
            <HeaderStyle CssClass="hidden"/>
            <ItemStyle CssClass="hidden" />
        </asp:BoundField>
        <asp:BoundField DataField="access_status_name" HeaderText="状态" SortExpression="access_status_name" >
            <HeaderStyle Width="39px" />
        </asp:BoundField>
        <asp:BoundField DataField="access_time">
            <HeaderStyle CssClass="hidden"/>
            <ItemStyle CssClass="hidden" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="登录时长"  SortExpression="access_status_name,access_time">
        <ItemTemplate></ItemTemplate>
        <HeaderStyle Width="59px" />
        </asp:TemplateField>
        <asp:BoundField DataField="access_callid" >
            <HeaderStyle CssClass="hidden"/>
            <ItemStyle CssClass="hidden" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="用户地址" SortExpression="access_hostname">
            <HeaderStyle Width="80px" />
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("access_hostname") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="服务地址" SortExpression="access_serverip">
            <HeaderStyle Width="150px" />
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("access_serverip") %>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <div class="pagerdata" style="width:150px; margin-right:10px;">
                      在线人数
                <asp:Label ID="TotalCountLabel" runat="server"></asp:Label>
                   </div>
               </FooterTemplate>
        </asp:TemplateField>
        
    </Columns>
    </asp:GridView>
</div></div>    
<table style="text-align:left;width:100%;">
	<tr>
    <td width="15">组</td>
	<td width="95"><div style="width: 145px; height: 75px; overflow: auto;">
	<asp:CheckBoxList ID="groupid_in" runat="server"></asp:CheckBoxList></div></td>
	<td width="27">状态</td>
	<td width="61"><div style="width: 85px; height: 75px; overflow: auto;">
	<asp:CheckBoxList ID="access_status_in" runat="server"></asp:CheckBoxList></div></td>	
    <td width="27">工号</td>
	<td ><input name="id" type="text" id="id" runat="server" class="inputred"  style="width:40px" /></td>
    <td width="27">姓名</td>
	<td ><input name="name" type="text" id="name" runat="server" class="inputred"  style="width:50px" /></td>
	<td width="80">间隔&nbsp;<input type="text" id="refeshsecond" class="inputred" value="5" style="width:22px;" runat="server" onkeyup="onRefeshSecondChange()"/>秒</td>
	</tr>
	<tr>
	  <td colspan="9" align="right">
	<%if (action != "statusmonitor"){ %>
	  <input type="button" id="sbtnReady" class="btn002" value="就绪" disabled="disabled" onclick="doMonitorAgent('Ready')" runat="server"/>
	  <input type="button" id="sbtnLogout" class="btn002" value="签退"  disabled="disabled" onclick="doMonitorAgent('Logout')" runat="server"/>
	  <input type="button" id="sbtnSilentMonitor" class="btn002" value="监听"  disabled="disabled" onclick="doMonitorAgent('SilentMonitor')" runat="server"/>
	  <input type="button" id="sbtnStopSilentMonitor" class="btn004" value="停止监听"  disabled="disabled" onclick="doMonitorAgent('StopSilentMonitor')" runat="server"/>
	  <input type="button" id="sbtnBargeIn" class="btn002" value="强插"  disabled="disabled" onclick="doMonitorAgent('BargeIn')" runat="server"/>
	  <input type="button" id="sbtnInterceptCall" class="btn002" value="强拆"  disabled="disabled" onclick="doMonitorAgent('InterceptCall')" runat="server"/>
	  <input type="button" id="sbtnQC" class="btn002" value="质检"  onclick="doQC()" runat="server"/>
    <%} %>
	  <input type="button" id="sbtnSendMsg" class="btn004" value="发送消息"  onclick="doSendMsg()" runat="server"/>
      <input type="button" id="btnRefesh" class="btn002" value="刷新" runat="server" onserverclick="btnRefesh_ServerClick" />
	  </td>
    </tr>
</table>
</form>
</div>
    <asp:ObjectDataSource ID="AgentsStatusInfoDataSource" runat="server" SelectMethod="GetObjects" TypeName="Ims.Main.BLL.AgentsStatusInfo" OnSelecting="AgentsStatusInfoDataSource_Selecting">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>

</body>
</html>
