<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="NoticeBoard.aspx.cs" Inherits="Notice_NoticeBoard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>��Ϣ</title>
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
            <div style=" text-align:left; color:#3B8B39; font-size:11pt; font-family:����; font-weight:bold;">��λʹ�øſ�
            </div>
          </th>
	  </tr>
	  </table>	
</div>
<div style=" color:Gray; margin-left:10px;">
<asp:Literal ID="ParkingStatics" runat="server"></asp:Literal>
</div>
<script type="text/javascript" src='js/jquery.js'></script>
<script type="text/javascript">
    $(document).ready(function() {
        $('.skillbar').each(function() {
            $(this).find('.skillbar-bar').animate({
                width: $(this).attr('data-percent')
            }, 6000);
        });
    });
</script>
<div class="appsection">
<table style="width:100%; height: 30px;">
<tr>
<td style="width:45%">
	<table cellpadding="1" style="width:100%" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th class="style2" >
            <div style=" text-align:left; color:#3B8B39; font-size:11pt; font-family:����; font-weight:bold;">
                ������Ϣ 
	  </tr>
	  </table>	
</td>
<td style="width:45%">
	<table cellpadding="1" style="width:100%" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th class="style2" >
            <div style=" text-align:left; color:#3B8B39; font-size:11pt; font-family:����; font-weight:bold;">
                ϵͳ��Ϣ
            </div>
          </th>
	  </tr>
	  </table>	
</td>
</tr>
<tr>
<td>
<div style=" color:Gray; margin-left:10px;">
<p>��¼ID��<%=Ims.Main.ImsInfo.CurrentUserId %></p>
<p>�û�������<%=Ims.Main.ImsInfo.CurrentUser.Name%></p>
<p>����Ȩ�ޣ�<%=Ims.Main.ImsInfo.CurrentRoles[0].ToString()%></p>
<p>�ͻ���IP��<%=Ims.Main.ImsInfo.CurrentUser.HostName%></p>
<p>������IP��<%=Ims.Main.ImsInfo.CurrentUser.ServerIp%></p>
</div>
</td>
<td>
<div style=" color:Gray; margin-left:10px;">
<p>��λģʽ��<asp:Label ID="lbSpot" runat="server"></asp:Label></p>
<p>�Զ�ǩ�ˣ�<asp:Label ID="lbAutoSign" runat="server"></asp:Label></p>
<p>ͼƬģʽ��<asp:Label ID="lbPic" runat="server"></asp:Label></p>
<p>������־��<asp:Label ID="lbTradeLog" runat="server"></asp:Label></p>
<p>ϵͳ�汾�ţ�·��ռ��ͣ������ϵͳ_Vip1.1.0���ٰ�</p>
</div>
</td>
</tr>
</table>
</div>
</form>
</body>
</html>
