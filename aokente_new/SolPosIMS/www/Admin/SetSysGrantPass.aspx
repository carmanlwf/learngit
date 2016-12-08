<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetSysGrantPass.aspx.cs" Inherits="Admin_SetSysGrantPass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>更改系统授权信息</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
</head>
<body style="text-align: left">
<script>
WaitHelper.showWaitMessage();
</script>
<form id="form1" runat="server">
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>授权账户</strong><br />
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 348px" id="TABLE1">
            <tr>
                <th align="right" width="107">
                    新授权账户</th>
                <td width="230">
                    <input id="uid" name="uid" type="text" class="inputblue   ime_engish" style="width: 120px"
                        value="" runat="server" vdisp="新授权账户" vmode="not null" maxlength="20"></td>
            </tr>
            <tr>
                <th width="107" align="right" style="text-align: right">
                    新登录密码</th>
                <td width="230">
                    <input id="pwd" name="pwd" type="text" class="inputblue   ime_engish" style="width: 120px"
                        value="" runat="server" vdisp="新登录密码" vmode="not null" maxlength="20"></td>
            </tr>
            <tr>
                <th width="107" align="right" style="text-align: right">
                    确认新密码</th>
                <td width="230">
                    <input id="pwdconfirm" name="pwdconfirm" type="text" class="inputblue   ime_engish"
                        style="width: 120px" value="" runat="server" vdisp="确认密码" vmode="not null" maxlength="20"></td>
            </tr>
        </table>
    </div>
</div>
    <div align="center" class="section_operators" style="width: 348px">
        <input id="btnConfirm" type="button" name="btnConfirm" class="btn003" visible="true"
                        value="确定" onclick="if (!doAllMessageBoxValidate(form1)) return false;" onserverclick="btnConfirm_ServerClick"
                        runat="server" ></div>
 </form>
    <script>
WaitHelper.initWaitMessageForms("form1");  
    </script>

</body>
</html>
