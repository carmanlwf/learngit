<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="GroupBranchRelate.aspx.cs"
    StylesheetTheme="app" Inherits="Admin_GroupBranchRelate"  EnableSessionState="ReadOnly"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>分公司与组对照关系管理</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>

</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
        <table width="840px" cellpadding="1" cellspacing="1" class="table_default table_green">
            <tr>
                <td style="vertical-align: top; width: 230px">
                    <div class="apphead">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>组信息</strong>
                    </div>
                    <asp:ListBox ID="groupinfo" Width="230px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="groupinfo_SelectedIndexChanged"
                        Rows="36"></asp:ListBox>
                </td>
                <td style="vertical-align: top; width: 230px">
                    <div class="apphead">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>当前组操作的分公司</strong></div>
                    <select id="branchIn" name="branchIn" size="36" multiple="true"  style="width: 230px" runat="server">
                    </select>
                </td>
                <td style="vertical-align: center; width: 30px">
                    <table width="20" height="220">
                        <tr>
                            <td>
                                <asp:ImageButton ID="imsbtnRight" runat="server" ImageUrl="../images/btn_gmove_right.gif"
                                    OnClick="imsbtnRight_Click" />
                                <asp:ImageButton ID="imsbtnLeft" runat="server" ImageUrl="../images/btn_gmove_left.gif"
                                    OnClick="imsbtnLeft_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align: top; width: 230px">
                    <div class="apphead">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>待选分公司</strong></div>
                    <select id="branchOut" name="branchOut" multiple="true" size="36" style="width: 230px" runat="server">
                    </select>
                </td>
                <td style="vertical-align: bottom; width: 110px"></td>
                <td>
                </td>
            </tr>
        </table>
    </form>
    <script>
WaitHelper.initWaitMessageForms("form1");  
</script>  
</body>
</html>
