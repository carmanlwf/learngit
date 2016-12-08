<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
	<title>Error</title>

	<script language="JavaScript" type="text/javascript" src="js/app.edit.js"></script>

	<style type="text/css">
<!--
body
{
	font-family: "宋体";
	font-size: 12px;
}
li {
	color:red;
	line-height:22px;
}

h1{
	color:red;
	font-size:13px;
	margin: 0;
	padding: 0;
}
table td {
	text-align: left;
	vertical-align:top;
}
a {
	COLOR: green; TEXT-DECORATION: none
}

a:hover {
	COLOR: #f30; TEXT-DECORATION: none
}
-->
</style>

	<script>
function dologin()
{
    var mainWin = GetMainWindow();
    if(mainWin != null) mainWin.logout();
	window.close();
}
function showDetail()
{
    errorAllMsgs.style.display = "";
}
	</script>

</head>
<body>
	<h1>
		错误信息</h1>
	<hr />
	<table width="100%" border="0" cellspacing="0">
		<tr>
			<td style="width: 80%">
				<ul>
					<li>
						<asp:Literal ID="errorMsg" runat="server"></asp:Literal></li>
					<li>错误页：<asp:Literal ID="errorPage" runat="server"></asp:Literal></li>
				</ul>
			</td>
			<td width="20%">
				<br />
				<a href="javascript:history.go(-1)">返回</a>&nbsp; <a href="javascript:showDetail()">详情</a>&nbsp;
				<a href="javascript:window.close()">关闭</a>&nbsp; <a href="javascript:dologin()">重新登录</a>
			</td>
		</tr>
	</table>
	<div id="divErrorAllMsgs" style="display: none">
		<hr />
		<pre>
<asp:Literal ID="errorAllMsgs" runat="server"></asp:Literal>
</pre>
	</div>
</body>
</html>