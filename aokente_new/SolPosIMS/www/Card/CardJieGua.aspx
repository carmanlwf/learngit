<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardJieGua.aspx.cs" Inherits="Card_CardJieGua" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>卡片解挂</title>
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
                    <input id="Card" runat="server" class="inputgreen " maxlength="37" name="Card"
                        style="width: 100px" type="text" vdisp="会员卡号" vmode="not null" readonly="readOnly" />&nbsp;</td>
                <th style="width: 160px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员姓名&nbsp; </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <input id="RealName" runat="server" class="inputgreen " maxlength="37" name="RealName"
                        style="width: 100px" type="text" vdisp="会员姓名" vmode="not null" />&nbsp;</td>
            </tr>
       <%--     <tr>
                <th style="width: 75px">
                    证件名称&nbsp;
                </th>
                <td colspan="3"><input id="IdTypeName" runat="server" class="inputgreen " maxlength="37" name="IdTypeName"
                        style="width: 100px" type="text" vdisp="证件名称" vmode="not null" /></td>
            </tr>--%>
            <tr>
                <th style="width: 75px">
                    手机号码<label style="color: red; height: 18px">*</label></th>
                <td colspan="3">
                    <input id="Idno1" runat="server" class="inputgreen" name="Idno1" 
                        style="width: 100px" type="text" vdisp="手机号码"  vtype="mobiletel" 
                        vmode="not null" maxlength="11"/>&nbsp;</td>
            </tr>
            <tr>
                <th style="width: 75px; height: 18px">
                    提示&nbsp;</th>
                <td colspan="3" style="height: 18px">
                    <span style="color: red">
                        <br />
                        办理卡片解挂，须本人的注册时的手机号码，进行卡片解挂操作。</span><br />
                </td>
            </tr>
        </table>
    
    </div>
    <div align="center" class="section_operators" style="width: 450px">
        <input id="btnJieGua" runat="server" class="btn001" name="btnJieGua" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="解 挂" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
             style="height: 19px" type="button" value="取 消" />&nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>

