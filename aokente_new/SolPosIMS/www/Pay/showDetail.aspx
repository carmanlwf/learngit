<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showDetail.aspx.cs" Inherits="Pay_showDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账单交易摘要</title>
 <script language="javascript" type="text/javascript">
    function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);
        window.setTimeout('document.all("btnclose").click();',1*1000);
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
    <div style=" text-align:left;">
     <p><asp:Label ID="lbCarNum" runat="server" Font-Bold="True" 
            Font-Size="Medium" Font-Underline="False" ForeColor="#009900"></asp:Label>
     </p>
     <p><asp:Label ID="lbContent" runat="server" 
            Font-Size="Small" Font-Underline="True" ></asp:Label>
     </p>
    </div>
    </form>
</body>
</html>
