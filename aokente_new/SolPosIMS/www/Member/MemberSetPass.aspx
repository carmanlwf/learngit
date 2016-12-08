<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberSetPass.aspx.cs" Inherits="Member_MemberSetPass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>密码重设</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script language="javascript" type="text/javascript">
        function CloseWin(msg) {
            alert(msg);
            close();

        }

        function ischoolse1() {
            if (document.getElementById('Checkbox1').checked) {
                document.getElementById('Checkbox2').checked = false;
            }
            else {
                document.getElementById('Checkbox2').checked = true;
            }
        }

        function ischoolse2() {
            if (document.getElementById('Checkbox2').checked) {
                document.getElementById('Checkbox1').checked = false;
            }
            else {
                document.getElementById('Checkbox1').checked = true;

            }
        }
    
    
    </script>

</head>
<body>

    <script>
        WaitHelper.showWaitMessage();
    </script>

    <form id="form1" runat="server">
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 450px"
            id="TABLE1" runat="server">
            <tr>
                <th style="height: 18px; width: 100px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员卡号&nbsp;</span></label>
                </th>
                <td colspan="3" style="height: 18px">
                    <asp:Label ID="Label3" runat="server" Width="173px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 100px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员编号&nbsp;</span></label>
                </th>
                <td style="height: 18px; width: 116px;">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <th style="width: 65px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员名称&nbsp; </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <asp:Label ID="Label2" runat="server" Width="46px"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
               <%-- <th style="width: 100px; height: 18px">
                    重设类型
                </th>
                <td colspan="3" style="height: 18px">
                    <input id="Checkbox1" runat="server" type="checkbox" onclick="ischoolse1()" /><asp:Label
                        ID="Label4" runat="server" Text="卡后六位"></asp:Label>&nbsp;
                    <input id="Checkbox2" runat="server" type="checkbox" onclick="ischoolse2()" /><asp:Label
                        ID="Label5" runat="server" Text="指定六位(000000)"></asp:Label>
                </td>--%>
                  <th style="height: 18px; width: 100px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">新密码&nbsp;</span></label>
                </th>
                <td style="height: 18px; width: 116px;">
                    <input  type="password" id="newpass" runat="server"  vmode="not null"  vtype="number" vdisp="新密码"/>
                </td>
                <th style="width: 65px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">再次输入&nbsp; </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                   <input  type="password" id="password1" vmode="not null"  vtype="number" runat="server" vdisp="再次输入"/>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; height: 18px">
                    操作备注<label style="color: red; height: 18px">*</label>
                </th>
                <td colspan="3" style="height: 18px">
                    <textarea id="Memo1" runat="server" class="inputblue" maxlength="500" name="Memo1"
                        style="width: 330px; height: 50px" vdisp="操作备注" vtextarea="yes"></textarea>
                </td>
            </tr>
            <tr>
                <th style="width: 100px; height: 18px">
                    提示&nbsp;
                </th>
                <td colspan="3" style="height: 18px">
                    <span style="color: red">
                        <br />
                        重设密码后，原始密码将失效，请慎重操作!<br />
                        &nbsp;</span>
                </td>
            </tr>
        </table>
    </div>
    <div align="center" class="section_operators" style="width: 450px">
        <input id="btSure" runat="server" class="btn001" name="btSure" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="提 交" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
            style="height: 19px" type="button" value="关 闭" />&nbsp;</div>
    </form>

    <script>
        WaitHelper.initWaitMessageForms("form1");  
    </script>

</body>
</html>
