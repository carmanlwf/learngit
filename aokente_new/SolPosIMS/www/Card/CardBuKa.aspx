<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardBuKa.aspx.cs" Inherits="Card_CardBuKa" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>补卡</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript">
    function CloseWin(msg)
    {
    alert(msg);
    close();
   
    }
    </script>
</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 450px">
            <tr>
                <th style="height: 18px; width: 75px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员卡号&nbsp; </span></label></th>
                 
                <td style="height: 18px; width: 100px;">
                    <input id="OldCardId" runat="server" class="inputblue" maxlength="30" name="OldCardId"
                        style="width: 100px" type="text" vdisp="会员卡号" vmode="not null" readonly="readOnly"  />&nbsp;</td>
                <th style="width: 160px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员姓名&nbsp; </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <input id="UserName" runat="server" class="inputblue" maxlength="10" name="UserName"
                        style="width: 100px" type="text" vdisp="会员姓名" vmode="not null" readonly="readOnly" />&nbsp;</td>
            </tr>
    
            <tr>
                <th style="width: 75px">
                    卡内余额&nbsp;
                </th>
                <td colspan="3">
                    <input id="Balance" runat="server" class="inputblue" name="Balance" 
                        style="width: 100px" type="text" vdisp="卡内余额" vtype="double" maxlength="10" readonly="readOnly" />(单位：元)</td>
            </tr>
                        <tr>
                <th style="height: 18px; width: 75px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">新卡卡号<label style="color: red; height: 18px">*</label>
                        </span></label></th>
                <td style="height: 18px; width: 100px;">
                    <input id="NewCardId" runat="server" class="inputblue" maxlength="30" name="NewCardId"
                        style="width: 100px" type="text" vdisp="新卡卡号" vmode="not null" />&nbsp;</td>
                <th style="width: 160px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">验证密码
                        </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <input id="Password" runat="server" class="inputblue" maxlength="6" name="Password"
                        style="width: 100px" type="password" vdisp="验证密码" />&nbsp;</td>
            </tr>
            <tr>
                <th style="width: 75px; height: 18px">
                    提示&nbsp;</th>
                <td colspan="3" style="height: 18px; color: #000000;">
                    <span style="color: red">
                        <br />
                        补办卡片，须本人出示办卡时的相关证件,进行卡片补办操作。进行补卡后，原卡变为不可用状态，并且，原卡上的金额全部转移到新卡上!</span><br />
                    </td>
            </tr>
        </table>
    
    </div>
    <div align="center" class="section_operators" 
        style="width: 446px; color: #000000;">
        <input id="btnJieGua" runat="server" class="btn001" name="btnJieGua" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="补 卡" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
             style="height: 19px" type="button" value="取 消" />&nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>

