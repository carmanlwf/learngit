<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="AgentAuthority.aspx.cs" Inherits="Admin_AgentAuthority" %>
<%@ Import Namespace="ZsdDotNetLibrary.Utility" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>用户授权管理</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script>


//根据ID找所有的checkbox
function getItems(itemId,filterValue,isFilterEnd)
{
    var childItems = document.all(itemId);
 	if(childItems == null || typeof(childItems) == 'undefined' ) return null;
 	if(isFilterEnd == null || typeof(isFilterEnd) == 'undefined' ) isFilterEnd = true;
   
    if(typeof(childItems.length) == 'undefined')
    {
        childItems[0] = childItems;
        childItems.length = 1;
    }
    if(filterValue == null) return childItems;
    var codelen = filterValue.length;
    var fChildItems = [];
	for(var i=0;i<childItems.length;i++)
	{
		var value = childItems[i].value;
		if(isFilterEnd)
		{
	        if(value.substr(value.length-codelen) == filterValue)
	            fChildItems[fChildItems.length] = childItems[i];
	    }else
	    { 
	        if(value.substr(0,codelen) == filterValue)
	            fChildItems[fChildItems.length] = childItems[i];
	        
	    }
    }
    
    return fChildItems;
}

function setChildItems(itemId,filterValue,isChecked)
{
    var fChildItems = [];
    
    var childItems = getItems(itemId,null);
    if(childItems == null) return ;
    var codelen = filterValue.length;
    var tvHaveAuthority = null;
    if(itemId == "cbauthorityitem") 
        tvHaveAuthority = document.getElementById("tvHaveAuthority");
	for(var i=0;i<childItems.length;i++)
	{
		var currChildTrObj = GridViewHelper.getParentElement(childItems[i],"TR");
		var value = childItems[i].value;
	    if(value.substr(value.length-codelen) == filterValue)
		{
	        if(isChecked!=null)
	            fChildItems[fChildItems.length] = childItems[i];
	        else
	            fChildItems[fChildItems.length] = childItems[i].nextSibling;
		    currChildTrObj.style.display ="";
   		    if(isChecked!=null)
		    {
		        childItems[i].checked = isChecked;
		        if(tvHaveAuthority != null) 
		        {
		           var items = authorityItemObjs[getItemValue(childItems[i].value)];
                   for(var j=0;j<items.length;j++)
                   {
                        if(items[j] == childItems[i]) continue;
                        items[j].checked = childItems[i].checked;
                        setHaveAuthorityItem(items[j].rowIndex,items[j].checked);
                   }

		            var tr = tvHaveAuthority.rows[i];
		            if(childItems[i].checked)
		            {
		                tr.style.display ="";
		            }else
		            {
		                tr.style.display ="none";
		            }
                }
		        

		    }
		}
	    else
		{
		    currChildTrObj.style.display ="none";
		}
	} 
    return fChildItems;
    
}

function getItemValue(itemValue)
{
    var pos = itemValue.indexOf("|");
    if(pos <0) return itemValue;
    return itemValue.substr(0,pos);
}

function getParentItemValue(itemValue)
{
    var pos = itemValue.indexOf("|");
    if(pos <0) return "";
    return itemValue.substr(pos+1);
}

function getParentItem(parentItemId,itemValue)
{
    var items = getItems(parentItemId,getParentItemValue(itemValue));
    if(items == null || items.length<=0) return null;
    return items[0];
}
function doItemClick(currItem,currItemId,filterValue,childItemId)
{
    var isCheckBox = currItem.tagName == "INPUT";
    var currAllItems = document.all(currItemId);
    var currItemsIsChecked = false;
	for(var i=0;i<currAllItems.length;i++)
	{
		var currTrObj = GridViewHelper.getParentElement(currAllItems[i],"TR");
		currTrObj.style.fontWeight ="normal";
		
		if(currTrObj.currentStyle.display != "none" && currAllItems[i].checked) 
		    currItemsIsChecked = true;
    }   
	var currTrObj = GridViewHelper.getParentElement(currItem,"TR");
	currTrObj.style.fontWeight ="bold";
	
    var obj ={};
    
    if(childItemId != "")
        obj.childItems = setChildItems(childItemId,"|"+filterValue,isCheckBox?currItem.checked:null);
    obj.currItemsIsChecked = currItemsIsChecked;
    return obj;
    
}

function doSelectSysItem(currSysItem,syscode)
{
    var obj = doItemClick(currSysItem,"cbsysitem",syscode,"cbroleitem");
    if(obj.childItems.length >0) obj.childItems[0].click();
}

function doCheckSysItem(currSysItem,syscode)
{
    var obj = doItemClick(currSysItem,"cbsysitem",syscode,"cbroleitem");
    var childItems = obj.childItems;
/*    for(var i=childItems.length-1;i>=0;i--)
    {
         doSelectRoleItem(childItems[i],obj.childItems[i].value);
    }*/
    if(childItems.length>0)
    {
        doSelectRoleItem(currSysItem,syscode);
        doSelectRoleItem(childItems[0],obj.childItems[0].value);
    }
}

function doSelectRoleItem(currRoleItem,rolecode)
{
    doItemClick(currRoleItem,"cbroleitem",rolecode,"cbauthorityitem");
}


function doCheckRoleItem(currRoleItem,rolecode)
{
   var obj = doItemClick(currRoleItem,"cbroleitem",rolecode,"cbauthorityitem");
   var parentItem = getParentItem("cbsysitem",currRoleItem.value);
   parentItem.checked =  obj.currItemsIsChecked;
}

function doCheckAuthorityItem(currAuthorityItem,authoritycode)
{
   var obj =  doItemClick(currAuthorityItem,"cbauthorityitem",authoritycode,"");
   var items = authorityItemObjs[getItemValue(authoritycode)];
   for(var i=0;i<items.length;i++)
   {
        if(items[i] == currAuthorityItem) continue;
        items[i].checked = currAuthorityItem.checked;
        setHaveAuthorityItem(items[i].rowIndex,items[i].checked);
   }
   var parentItem = getParentItem("cbroleitem",currAuthorityItem.value);
   parentItem.checked =  obj.currItemsIsChecked;
   obj = doItemClick(parentItem,"cbroleitem",parentItem.value,"");
   parentItem = getParentItem("cbsysitem",parentItem.value);
   parentItem.checked =  obj.currItemsIsChecked;
   setHaveAuthorityItem(currAuthorityItem.rowIndex,currAuthorityItem.checked);
}

function setHaveAuthorityItem(rowIndex,isShow)
{
    var tvHaveAuthority = document.getElementById("tvHaveAuthority");
    var tr = tvHaveAuthority.rows[rowIndex];
    if(isShow)
    {
        tr.style.display ="";
    }else
    {
        tr.style.display ="none";
    }
   
}

function doFillHaveAuthorityItems()
{
    var tvHaveAuthority = document.getElementById("tvHaveAuthority");
    var items = getItems("cbauthorityitem",null);
	for(var i=0;i<items.length;i++)
	{
		var tr = tvHaveAuthority.insertRow(tvHaveAuthority.rows.length);
		tr.rowindex = i;
		var td = tr.insertCell(tr.cells.length);
        td.innerHTML = items[i].fullname;
		if(items[i].checked)
		{
		    tr.style.display ="";
		}else
		{
		    tr.style.display ="none";
		}
    }   
    
}
var authorityItemObjs = {};
function doInitAuthorityItems()
{
    var childItems = document.all("cbauthorityitem");
    if(typeof(childItems.length) == 'undefined')
    {
        childItems[0] = childItems;
        childItems.length = 1;
    }    
    for(var i=0;i<childItems.length;i++)
    {
        var itemvalue = getItemValue(childItems[i].value);
        var obj = authorityItemObjs[itemvalue];
        if(typeof(obj) !="object" )
        {
             obj = [];
             authorityItemObjs[itemvalue] = obj;
        }
        obj[obj.length] = childItems[i];
    }
}

function doOnLoad()
{
    doInitAuthorityItems();
    var items = getItems("asysitem",null);
    if(items == null) return ;
    items[0].click();
    doFillHaveAuthorityItems();
}

</script>
</head>
<body onload="doOnLoad()">
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
        <div class="apphead" style="width: 845px">
            <strong>用户授权</strong></div>
        <table style="width: 845px;" cellspacing="1" cellpadding="1" class="table_default table_yellow">
            <tr>
                <td style="vertical-align: top; width: 150px">
                    <div class="apphead">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>系统列表</strong></div>
                    <div style="width: 150px; height: 440px; overflow-y: auto">
                        <asp:DataList ID="tvsyslist" runat="server" OnItemDataBound="tvsyslist_ItemDataBound" EnableViewState="False">
                            <ItemTemplate>
                                <input id="cbsysitem" name="cbsysitem" type="checkbox" value="<%# Eval("code")%>" <%# TypeHelper.ObjectToNullStr(Eval("checked")) == "1"?"checked=\"checked\"":"" %> onclick="doCheckSysItem(this,'<%# Eval("code")%>')"/><a id="asysitem" href="javascript:void(0)" onclick="doSelectSysItem(this,'<%# Eval("code")%>')"> <%# Eval("name")%></a>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </td>
                <th style="width: 1px">
                </th>
                <td style="vertical-align: top; width: 150px">
                    <div class="apphead">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>角色列表</strong></div>
                    <div style="width: 150px; height: 440px; overflow-y: auto">
                        <asp:DataList ID="tvRolelist" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <input id="cbroleitem" name="cbroleitem"  type="checkbox" value="<%# Eval("itemvalue")%>" <%# TypeHelper.ObjectToNullStr(Eval("checked")) == "1"?"checked=\"checked\"":"" %> onclick="doCheckRoleItem(this,'<%# Eval("itemvalue")%>')"/><a id="aroleitem"  href="javascript:void(0)" onclick="doSelectRoleItem(this,'<%# Eval("itemvalue")%>')"> <%# Eval("name")%></a>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </td>
                <th style="width: 1px">
                </th>
                <td style="vertical-align: top; width: 160px">
                    <div class="apphead" style="width: 160px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>权限列表</strong></div>
                    <div style="width: 160px; height: 440px; overflow-y: auto">
                         <asp:DataList ID="tvAuthoritylist" runat="server">
                            <ItemTemplate>
                                <input rowIndex ="<%# (Container.ItemIndex).ToString()%>" id="cbauthorityitem" name="cbauthorityitem" type="checkbox"  fullname="<%#Eval("sys_name")+" "+Eval("role_name")+" "+Eval("name") %>" value="<%#Eval("itemvalue")%>" <%# TypeHelper.ObjectToNullStr(Eval("checked")) == "1"?"checked=\"checked\"":"" %> onclick="doCheckAuthorityItem(this,'<%# Eval("itemvalue")%>')"/><%# Eval("name")%>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </td>
                <th>
                </th>
                <td style="vertical-align: top; width: 360px">
                    <div class="apphead">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>已授权限列表</strong></div>
                    <div style="width: 350px; height: 440px; overflow-y: auto">
                     <table id="tvHaveAuthority" cellspacing="0" border="0" style="border-collapse:collapse;">
                      </table>
                    </div>
                </td>
            </tr>
        </table>
        <div align="center" style="width: 845px">
            <input id="btnSave" type="button" name="btnCon" class="btn003" value="保存" runat="server"
                onclick="if (!doAllMessageBoxValidate(form1)) return false;" onserverclick="btnSave_ServerClick" />
            &nbsp;&nbsp;
            <input id="btnReturn" type="button" name="btnReturn" class="btn003" value="关闭" onclick="JavaScript:window.close()" />
        </div>
    </form>
    <script>
WaitHelper.initWaitMessageForms("form1");  
</script>  
</body>
</html>
