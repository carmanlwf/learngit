<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ChangePwd.aspx.cs" Inherits="Admin_ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>更改个人登录密码</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

</head>
<body>

    <script>
    WaitHelper.showWaitMessage();
    </script>

    <form id="form1" runat="server">
        <table width="40%" cellpadding="1" cellspacing="1" class="table_default table_green">
            <tr>
                <th width="107" align="right">
                    新登录密码</th>
                <td style="width: 230px">
                    <input id="pwd" runat="server" class="inputgreen ime_engish" maxlength="25"
                        name="pwd" style="width: 150px" type="password" /></td>
            </tr>
            <tr>
                <th width="107" align="right">
                    确认密码</th>
                <td style="width: 230px">
                    <input id="pwdconfirm" runat="server" class="inputgreen ime_engish" maxlength="25"
                        name="pwdconfirm" style="width: 150px" type="password" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 18px">
                    <input id="btnConfirm" type="button" name="btnConfirm" class="btn003" visible="true"
                        value="确定" onclick="if (!doAllMessageBoxValidate(form1)) return false;" onserverclick="btnConfirm_ServerClick"
                        runat="server" >&nbsp;&nbsp;<input id="btnCancel"
                                type="button" name="btnCancel" class="btn003" value="关闭" onclick="JavaScript:window.close()"
                                runat="server"></td>
            </tr>
        </table>
    </form>

    <script>
WaitHelper.initWaitMessageForms("form1");  
    </script>

</body>
</html>
