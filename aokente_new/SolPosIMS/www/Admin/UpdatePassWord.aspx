<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePassWord.aspx.cs" Inherits="Admin_UpdatePassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>更改登录密码</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
        <script language="javascript" type="text/javascript">
    function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);
        window.setTimeout('document.all("btnclose").click();parent.location.href="UserListByAuthority.aspx";',1*1000);
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" 
            >
            <tr>
                <th align="right">
                    新的密码</th>
                <td>
                    <input id="newPass" runat="server" class="inputblue" style="width: 120px" type="password" maxlength="25" vdisp="新密码" vmode="not null"/></td>
            </tr>
            <tr>
                <th align="right">
                    确认密码</th>
                <td>
                    <input id="oKPass" runat="server" class="inputblue" style="width: 120px" type="password" maxlength="25"  vdisp="确认密码" vmode="not null"/></td>
            </tr>
            <tr>
                <th align="right">
                    用户权限</th>
                <td>
                    <select id="authority" runat="server" class="inputblue" style="width: 120px" name="authority" />
                    </select></td>
            </tr>
            <tr>
                <td colspan="2" align="center" class="style1">
                    <input id="ButtOk" name="ButtOk" type="button" value="确 定"  runat="server" 
                        onclick="if(!doAllMessageBoxValidate(form1)) return false;" 
                        onserverclick="ButtOk_ServerClick" class="xybtn"/><input id="ButtNo" name="ButtNo" type="button" value="取 消" runat="server"  onclick="JavaScript:window.close()" class="btn003" style="display:none;"/></td>
            </tr>
        </table>
    </form>


</body>
</html>
