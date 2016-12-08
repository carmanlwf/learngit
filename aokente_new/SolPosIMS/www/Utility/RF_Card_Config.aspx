<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RF_Card_Config.aspx.cs" Inherits="Utility_RF_Card_Config" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>读卡配置</title>
    
<link href="../css/app.newedit.css"rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js"charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js"charset="gb2312"></script>

<script type="text/javascript">
    var aa = 1;
    var bb = 1;
    var ret;
    var address, address1, address2, address3;

    MWRFATL.CloseReader();

    function RfInit()//打开设备
    {
        MWRFATL.CloseReader();
        var pass = "明泰";
        bb = MWRFATL.OpenReader(pass);
        aa = MWRFATL.LastRet;
        if (aa == 0)
            alert("硬件版本号为：" + bb);
        else
            alert("打开设备Fail!");
    }

    function RfExit()//关闭设备
    {
        MWRFATL.CloseReader();
        aa = MWRFATL.LastRet;
        if (aa == 0)
            alert("关闭设备Sucess!");
        else
            alert("关闭设备Fail!");
    }
    </script>

<script>
WaitHelper.showWaitMessage();
</script>
    <style type="text/css">
        .style1
        {
            width: 180px;
        }
    </style>
</head>
<body style="width:98%;">
<OBJECT id=MWRFATL style="WIDTH: 0px; HEIGHT: 0px" 
codeBase=MwRFReader.cab#version=2,0,0,1
data=data:application/x-oleobject;base64,VPpLUhUXNkSyudxeJIvBwwADAAAAAAAAAAAAAA== 
classid=CLSID:BDE9B6B3-4C1D-4C05-8A71-3696F3BF81F5></OBJECT> 
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>设置串口</strong></li></ul>
			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" 
        style="width: 233px; height: 1px" >
	  <tr> 
		<th style="width: 116px" >
            所在块号</th>
		<td class="style1" >
            &nbsp;</td>
	  </tr>
	    <tr>  
            <td align="right" colspan="2" style="height: 18px">
                &nbsp;<input type="button" name="btnCon0" class="btn003" value="取消" id="Button3" 
                    runat="server"  />&nbsp;<input 
                    type="button" name="btnCon" class="btn003" value="应用" onclick="RfInit()" 
                    id="btnNew" runat="server"  />
	        &nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
</div>
</form>

</body>
</html>
