<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Wait.aspx.cs" Inherits="Wait" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>正在加载页面，请稍等......</title>
<style type="text/css">
span
{
	font-family:"宋体";
	font-size: 10pt;
	color:#1E3739;
	font-weight:bold;
}
</style>
<script type="text/javascript">
function doOnLoad()
{
    var form1 = document.getElementById("form1");
    form1.submit();
}
</script>
</head>

<body onload="doOnLoad()">
<span><%=msg%></span>
<form action="<%=url%>" target="_self" id="form1" method="post">
<input type="hidden" name="param" value="<%=param%>" />
</form>
</body>
</html>
