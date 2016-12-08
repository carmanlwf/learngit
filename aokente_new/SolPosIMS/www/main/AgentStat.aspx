<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="AgentStat.aspx.cs" Inherits="main_AgentStat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
<meta http-equiv=Content-Type content="text/html; charset=gb2312">
<style type="text/css">
body {
	background-color: #FFF;
	margin: 0;
	font-family: "宋体";
	font-size: 12px;
}

table th 
{
	color: #0d5178;
	height: 20px;
	width:40px;
	font-weight:normal;
}
table td
{
	color: #b6291f;
}

#verno
{
	font-weight: bold;
	color: #660000;    
}
</style>
</head>
<body>
    <form id="form1" runat="server">
	<table width="100%" height="20" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td width="5"><span id="activeCount">&nbsp;</span></td>
          <th style="width: 35px" >工号</th>
          <td style="width: 80px"><span id="agentId"><%=Ims.Main.ImsInfo.CurrentUserId %></span></td>
          <th style="width: 35px" >姓名</th>
          <td style="width: 80px"><span id="agentName"><%=Ims.Main.ImsInfo.CurrentUser.Name%></span></td>
          <th style="width: 35px" >本机</th>
          <td style="width: 80px"><span id="groupName"><%=Ims.Main.ImsInfo.CurrentUser.HostName%></span></td>
<%--      <th >角色</th>
          <td><span id="agentRoles"></span></td>
--%>   
           <th style="width: 40px">服务器</th>
           <td style="width: 130px"><span id="servername"><%=Ims.Main.ImsInfo.CurrentUser.ServerIp%></span></td>
           <th style="width: 35px" >日期</th>
           <td style="width: 120px"><span id="servertime"><%=DateTime.Now.Date.ToString("yyyy-MM-dd")%></span></td>
           <th style="width: 35px" >版本</th>
           <td style="text-align: left;"><span id="verno">&nbsp;连锁店会员管理系统V1.1</span></td>
       </tr>
      </table>
    </form>
</body>
</html>
