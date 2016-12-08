<%@ Page Language="C#" AutoEventWireup="true" CodeFile="setting.aspx.cs" Inherits="Sysem_setting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>小票通知</title>
<script src="../js/app.edit.js" type="text/javascript"></script>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../css/table.css" />
<link rel="stylesheet" href="css/style.css" media="screen" type="text/css" />
</head>
<body>
<form runat="server" id="Form1">			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th class="style2" >
            <div style=" text-align:left; color:#3B8B39; font-size:11pt; font-family:黑体; font-weight:bold;">车位使用概况
            </div>
          </th>
	  </tr>
	  </table>	
</div>
<div style=" color:Gray; margin-left:10px;">

</div>
<script type="text/javascript" src='js/jquery.js'></script>
<div class="appsection">
<table style="width:100%; height: 30px;">
<tr>
<td style="width:45%">
	<table cellpadding="1" style="width:100%" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th class="style2" >
            <div style=" text-align:left; color:#3B8B39; font-size:11pt; font-family:黑体; font-weight:bold;">
                个人信息 
	  </tr>
	  </table>	
</td>
<td style="width:45%">
	<table cellpadding="1" style="width:100%" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th class="style2" >
            <div style=" text-align:left; color:#3B8B39; font-size:11pt; font-family:黑体; font-weight:bold;">
                系统信息
            </div>
          </th>
	  </tr>
	  </table>	
</td>
</tr>
<tr>
<td>
<div style=" color:Gray; margin-left:10px;">
<p>登录ID：<%=Ims.Main.ImsInfo.CurrentUserId %></p>
<p>用户姓名：<%=Ims.Main.ImsInfo.CurrentUser.Name%></p>
<p>所属权限：<%=Ims.Main.ImsInfo.CurrentRoles[0].ToString()%></p>
<p>客户端IP：<%=Ims.Main.ImsInfo.CurrentUser.HostName%></p>
<p>服务器IP：<%=Ims.Main.ImsInfo.CurrentUser.ServerIp%></p>
</div>
</td>
<td>
<div style=" color:Gray; margin-left:10px;">
<p>运行环境：Windows2003 32位</p>
<p>IIS版本号：6.0</p>
<p>ASP.NET版本：.Net FrameWork 3.5</p>
<p>数据库环境：Microsoft SQL SERVER 2008</p>
<p>系统版本号：路边占道停车管理系统_Vip1.1.0极速版</p>
</div>
</td>
</tr>
</table>
</div>
</form>
</body>
</html>
