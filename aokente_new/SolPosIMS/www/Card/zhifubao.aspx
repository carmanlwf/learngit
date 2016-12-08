<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhifubao.aspx.cs" Inherits="Card_zhifubao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="1" cellspacing="0" style="font-size: 10pt; width: 460px; height: 276px;">
            <tr>
                <td style="width: 70px">
                    充值金额：</td>
                <td colspan="2" style="width: 300px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox>元</td>
            </tr>
            <tr>
                <td colspan="3">
                    ---------------------------------------------------------------</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
                    <img src="../images/logo-alipay.gif" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    ---------------------------------------------------------------</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" />
                    <img src="../images/shouxinlogo.gif" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    ---------------------------------------------------------------</td>
            </tr>
            <tr>
                <td colspan="3" style="height: 90px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: right">
                    <input id="Button1" class="btn001" type="button" value="提交" onclick="javascript:alert('请先设定商户的支付帐号及交易密钥!')" />&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
