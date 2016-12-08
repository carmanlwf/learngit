<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateAdminPassword.aspx.cs" Inherits="Admin_UpdateAdminPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>更改登录密码</title>
     <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    
    <script type="text/javascript">
 function Cleared()
 {
 alert('aa');
  var old = document.getElementById("oldPass");
  var newpass = document.getElementById("newPass");
  var yesPass = document.getElementById("yesPass");
  old.value = "";
  newpass.value = "";
  yesPass.value = "";
   }
 
</script>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 300px;">
            <tr>
                <th align="right" colspan="2" style="text-align: center">
                    更新当前用户密码</th>
            </tr>
                <tr>
                <th align="right">
                    旧密码</th>
                <td>
                    <input id="oldPass" name="oldPass" type="text"  class="inputgreen   ime_engish" style="width: 120px"  
                        value="" runat="server" vdisp="旧密码" onblur ="this.value=this.value.toLowerCase()" onfocusout="SetDefaultValue(this)"   vmode="not null" maxlength="20"/></td>
            </tr>
                <tr>
                <th align="right">
                    新密码</th>
                <td>
                    <input id="newPass" name="newPass" type="text"  class="inputgreen   ime_engish" style="width: 120px"
                        value="" runat="server" vdisp="新密码" onblur ="this.value=this.value.toLowerCase()" onfocusout="SetDefaultValue(this)"   vmode="not null" maxlength="20"/></td>
            </tr>
            <tr>
                <th align="right">
                    确认密码</th>
                <td>
                    <input id="yesPass" name="yesPass" type="text"  class="inputgreen   ime_engish" 
                        style="width: 120px"  runat="server" vdisp="确认密码" vmode="not null" onblur ="this.value=this.value.toLowerCase()" onfocusout="SetDefaultValue(this)" maxlength="20" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="text-align: right">
                    <input id="ButtOk" name="ButtOk" type="button" value="确 定"  runat="server" 
                        onclick="if(!doAllMessageBoxValidate(form1)) return false;"  
                        onserverclick="ButtOk_ServerClick" class="xybtn"/>
                    <input id="ButtNo" runat="server" class="btn003" name="ButtNo" onclick="JavaScript:window.close()" style="display:none;"
                        type="button" value="取 消" /></td>
            </tr>
        </table>
    </form>


</body>
</html>
