<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExitCard.aspx.cs" Inherits="Card_ExitCard"
    StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>卡类型信息</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/json.js"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>

    <script type="text/javascript">

        function doInforEdit(id) {
            openBrWindow('CardTypeOper.aspx?getcode=' + id, 'EditProductInfo', '420', '300');
        }
        function doSeeInfo(id) {
            openBrWindow('CardTypeOper.aspx?statu=readonly&getcode=' + id, 'SeeClassInfoInfo', '420', '300');
        }

        function CheckAll(form) {
            document.getElementById('chkChouse').checked = false;
            for (var i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.name.indexOf('chkChouse') > -1)
                    continue;
                if (e.name.indexOf('checkitall') == -1) e.checked = form.checkitall.checked;
            }
        }

        function FanCheckAll(form) {
            document.getElementById('checkitall').checked = false;
            for (var i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.name.indexOf('chkChouse') == -1) {
                    if (e.name.indexOf('checkitall') == -1) {
                        if (e.checked)
                            e.checked = false;
                        else
                            e.checked = true;
                    }
                }
            }
        }
    </script>

    <script>
        WaitHelper.showWaitMessage();
       
    </script>

    <style type="text/css">
        .style2
        {
            width: 190px;
        }
        .style4
        {
            width: 1025px;
        }
    </style>
</head>
<body>
    <form runat="server" id="Form1">
    <ul class="sitemappath">
        <li><strong>退卡信息</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%">
            <tr>

                <td class="style2">
                    <input id="card" runat="server" class="inputblue" maxlength="30" name="card"
                        style="width: 100px" type="text" />
                    请输入卡号</td>
                <td class="style4">                
                    <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                        onserverclick="Button3_ServerClick" />
                </td>
               
                </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>退卡信息</strong></div>
        <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_FixedWidth_blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" Height="1px"
            DataSourceID="ObjectDataSource1">
            <Columns>
                
                <asp:BoundField DataField="card" HeaderText="卡号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="realname" HeaderText="姓名" ItemStyle-HorizontalAlign="right">
                    <ItemStyle HorizontalAlign="center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="balance" HeaderText="余额" ItemStyle-HorizontalAlign="right">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="addeddate" HeaderText="办卡时间" ItemStyle-HorizontalAlign="right">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="validDate" HeaderText="有效期" ItemStyle-HorizontalAlign="right">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="statusname" HeaderText="卡状态" ItemStyle-HorizontalAlign="right">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                
            </Columns>
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Card.BLL.CardHelperBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
