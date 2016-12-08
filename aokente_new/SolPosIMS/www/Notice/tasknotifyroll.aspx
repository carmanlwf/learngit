<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableSessionState="ReadOnly" CodeFile="tasknotifyroll.aspx.cs" Inherits="main_tasknotifyroll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<script language="JavaScript" type="text/javascript" src="../js/app.edit.js"></script>
<style type="text/css">



marquee {
	font-family: "宋体";
	font-size: 12px;
	color: #13258b;
	padding-top: 6px;
	font-weight: normal;
	height: 17px;
	width: 100%;
}
body {
	background-color: #FFF;
	margin: 0;
}

</style>
<script>
    function doOnLoad()
    {
       window.setInterval("onTimer()",120*1000);
    }
    
    function onTimer()
    {
        window.location.href = window.location.href;
    }
</script>
</head>
<body onload="doOnLoad()">
<form>
<%--<marquee scrolldelay="250" runat="server" id="rollnotice"><a href="" runat="server" id="notice">公告： 欢迎使用智胜达自行车租赁系统。</a></marquee>
--%>
<marquee scrolldelay="250" runat="server" id="rollnotice" onmouseover="this.stop()" onmouseout="this.start()">
公告:<span runat="server" id="noinfo">无新公告</span>
<asp:Repeater runat="server" ID="Repeater1">
<ItemTemplate>
 <a href="#"
  onclick="javascript:openBrWindow('../Notice/NoticeDetailAgent.aspx?id=<%#DataBinder.Eval(Container.DataItem,"id")%>','_blank','width=570,height=280')"
  ><%#DataBinder.Eval(Container.DataItem,"title")%></a>   
</ItemTemplate>
</asp:Repeater>
</marquee>
</form>
</body>
</html>