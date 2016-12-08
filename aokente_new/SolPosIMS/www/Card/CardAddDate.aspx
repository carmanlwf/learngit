<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardAddDate.aspx.cs" Inherits="Card_CardAddDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>卡片延期</title>
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
                <th style="height: 18px; width: 151px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员卡号&nbsp; </span></label></th>
                <td style="height: 18px; width: 189px;">
                    <input id="Card" runat="server" class="inputblue" maxlength="30" name="Card"
                        style="width: 100px" type="text" vdisp="会员卡号" vmode="not null" readonly="readOnly" />&nbsp;</td>
                <th style="width: 160px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员姓名&nbsp; </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <input id="RealName" runat="server" class="inputblue" maxlength="37" name="RealName"
                        style="width: 100px" type="text" vdisp="会员姓名" vmode="not null" readonly="readOnly" />&nbsp;</td>
            </tr>
 
            <tr>
                <th style="width: 151px">
                    延长有效期</th>
                <td colspan="3">
                    <input id="adddate" runat="server" class="inputblue" maxlength="20" name="adddate"
                        onfocus="setday(this)" style="width: 96px" type="text" vdisp="截止时间" vtype="date" readonly="readOnly" value="2030-12-30" /></td>
            </tr>
            <tr>
                <th style="width: 151px; height: 18px">
                    提示&nbsp;</th>
                <td colspan="3" style="height: 18px">
                    <span style="color: red">如果要给卡延长有效日期，在文本框中直接选择到其时间就可以了！</span></td>
            </tr>
        </table>
        </div>
    <div align="center" class="section_operators" style="width: 450px">
        <input id="btnJieGua" runat="server" class="btn001" name="btnJieGua" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="确 定" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
             style="height: 19px" type="button" value="关 闭" />&nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>

