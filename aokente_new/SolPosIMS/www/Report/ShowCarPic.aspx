<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowCarPic.aspx.cs" Inherits="Report_ShowCarPic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="carnum" runat="server">车牌号</title>
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
    <div style=" text-align:center; vertical-align:middle;">
    <img id="carImage" alt="车牌照片" style=" width:220px;" src ="~/Report/images/nopic.png"  runat="server" />
        <br />
        <asp:Label ID="lbCarNum" runat="server" BackColor="#FFFF99" Font-Bold="True" 
            Font-Size="XX-Large" Font-Underline="True" ForeColor="#009900"></asp:Label>
    </div>
    </form>
</body>
</html>
