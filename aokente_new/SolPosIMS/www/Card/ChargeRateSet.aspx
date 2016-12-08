<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargeRateSet.aspx.cs" Inherits="Card_ChargeRageSet" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>充值比率设置</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script language="javascript" type ="text/javascript">
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
                <th style="width: 75px">
                    充值比率&nbsp;
                </th>
                <td colspan="3"><input id="txt_Start" runat="server" class="inputblue" maxlength="5" name="txt_Start"
                        style="width: 30px" type="text" vdisp="起始比率" vmode="not null" value="1" vtype="number" />元&lt;--&gt;<input id="txt_End" runat="server" class="inputblue" maxlength="3" name="txt_End"
                        style="width: 30px" type="text" vdisp="结尾比率" vmode="not null" value="1" vtype="number" />元 <span style="color: gray">
                            (如：充100元送100元，则设置为1：2)</span></td>
            </tr>
            <tr>
                <th style="width: 75px">
                    操作说明<label style="color: red; height: 18px">*</label></th>
                <td colspan="3">
                    <textarea id="OperMemo" runat="server" class="inputblue" maxlength="500" name="OperMemo"
                        style="width: 260px; height: 50px" vtextarea="yes" vmode="not null" vdisp="操作说明"></textarea></td>
            </tr>
            <tr>
                <th style="width: 75px; height: 18px">
                    提示&nbsp;</th>
                <td colspan="3" style="height: 18px">
                    <span style="color: red">
                        <br />
                        充值比率默认为1：1的比率，设置后即时生效，会员充值按比率进行累加。<br />
                    </span>
                </td>
            </tr>
        </table>
    
    </div>
    <div align="center" class="section_operators" style="width: 450px">
        <input id="btnSet" runat="server" class="btn001" name="btnJieGua" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="设 置" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
             style="height: 19px" type="button" value="关 闭" />&nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>
