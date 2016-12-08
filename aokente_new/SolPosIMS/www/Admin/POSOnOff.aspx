<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POSOnOff.aspx.cs" Inherits="Admin_POSOnOff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>开启与关闭</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
</head>
<body>
<form id="form1" runat="server">
<div class="appsection">
	<img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>终端设置</strong><table width="845" cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th style="width: 185px; height: 18px;" >
            设置终端设备</th>
		<td style="width: 211px; height: 18px;" >
            <asp:RadioButton ID="RadioTerminalOn" runat="server" GroupName="PosTerminal" Text="开启" /><asp:RadioButton ID="RadioTerminalOff" runat="server" GroupName="PosTerminal" Text="关闭" /></td>
		<th style="width: 110px; height: 18px;" >
            </th>
		<td colspan="4" style="height: 18px" >
            </td>
	  </tr>
	  <tr> 
		<th style="width: 185px; height: 17px" >
            终端充值交易</th>
		<td style="height: 17px; width: 211px;" >
            <asp:RadioButton ID="RadioChargeOn" runat="server" GroupName="PosCharge" Text="开启" /><asp:RadioButton
                ID="RadioChargeOff" runat="server" GroupName="PosCharge" Text="关闭" /></td>
		<th style="width: 110px; height: 17px;" ><label style="color:Red; height:18px;">
            </label></th>
		<td style="height: 17px;" colspan="4" >
            <label style="color:Red; height:18px;">
                </label></td>
	  </tr>
	  <tr> 
          <td colspan="7">
              <input id="ButtOK" runat="server" onserverclick="ButtOK_ServerClick" style="width: 62px"
                  type="button" value="确定" class="btn003" /></tr>	
  </table>
</div>

</form>

</body>
</html>