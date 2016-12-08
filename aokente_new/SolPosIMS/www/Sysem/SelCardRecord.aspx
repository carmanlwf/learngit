<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelCardRecord.aspx.cs" Inherits="Sysem_SelCardRecord"
    StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>每日充值信息</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="js/MB.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../lib/jquery/jquery-1.3.2.min.js"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>

    <script type="text/javascript">

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

</head>
<body style="width: 98%;">
    <form runat="server" id="Form1">
    <ul class="sitemappath">
        <li><strong>每日充值信息</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%">
            <tr>
                <th width="100">
                    操作员
                </th>
                <td style="width: 226px">
                    <input type="text" class="inputblue" style="width: 100px" id="operid" runat="server"
                        name="operid" maxlength="20" />
                </td>
                <td colspan="5">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right" colspan="6" style="height: 18px">
                    <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                        onserverclick="Button3_ServerClick" />
                    <asp:Button ID="btnOut" runat="server" Text="导出" class="btn003" OnClick="btnOut_Click1" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>充值记录信息</strong></div>
        <asp:GridView Width="100%" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="operid" HeaderText="操作员姓名">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NumCZ" HeaderText="操作笔数">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Money" HeaderText="操作总额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ZCCount" HeaderText="充值总数">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ZCMoney" HeaderText="充值金额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="KCount" HeaderText="扣款总数">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="KMoney" HeaderText="扣款金额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPageObject" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Card.BLL.CardChargeListBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>

    <script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
