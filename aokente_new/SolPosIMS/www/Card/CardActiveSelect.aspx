<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardActiveSelect.aspx.cs"
    Inherits="Card_CardActiveSelect" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>批量卡激活</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="js/CD.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>

    <script type="text/javascript">
WaitHelper.showWaitMessage();
    </script>

</head>
<body style="width: 98%;">
    <form id="form1" runat="server">
        <ul class="sitemappath">
            <li><strong>激活查询</strong></li></ul>
        <div class="appsection">
            <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%">
                <tr>
                    <th>
                        会员卡号</th>
                    <td>
                        <input type="text" class="inputblue" style="width: 120px" id="card" runat="server"
                            name="card" maxlength="30" /></td>
                    <th>
                        会员姓名</th>
                    <td>
                        <input type="text" class="inputblue" style="width: 120px" id="realname" runat="server"
                            name="RealName" maxlength="10" /></td>
                    <th>
                        操作方式</th>
                    <td>
                        <select class="inputblue" style="width: 120px" id="activeway" runat="server" 
                            name="Status">
                            <option value="在线">在线</option>
                            <option value="终端POS">终端POS</option>
                        </select></td>
                </tr>
                <tr>
                    <th style="height: 18">
                        流水号
                    </th>
                    <td>
                        <input type="text" class="inputblue" style="width: 120px" id="contno" runat="server"
                            maxlength="20" /></td>
                    <th style="height: 18px">
                        操作员
                    </th>
                    <td style="height: 18px">
                        <input type="text" class="inputblue" style="width: 120px" id="activeoperator" runat="server"
                            maxlength="20" /></td>
                    <th style="height: 18px">
                        卡激活时间</th>
                    <td style="height: 18px;">
                        <input type="text" class="inputblue" style="width: 110px" id="addeddate1" runat="server"
                            onfocus="setday(this)" vdisp="起始时间" vtype="date" name="addeddate1" maxlength="20" />～<input
                                type="text" class="inputblue" style="width: 110px" id="addeddate2" runat="server"
                                onfocus="setday(this)" vdisp="截止时间" vtype="date" name="addeddate2" maxlength="20" /></td>
                </tr>
                <tr>
                    <td align="right" colspan="6" style="height: 18px" >
                        <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                            onserverclick="Button3_ServerClick" onclick="if(!doAllMessageBoxValidate(form1)) return false;if(!checkdate('addeddate1','addeddate2'))  return false;" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <div class="apphead">
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>激活卡信息</strong></div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" PageSize="12" SkinID="GridView_Blue" Width="100%"
                DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:BoundField DataField="card" HeaderText="卡号" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="contno" HeaderText="流水号" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="realname" HeaderText="姓名" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="initvalue" HeaderText="初始金额" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="balance" HeaderText="账户余额" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="activetime" HeaderText="卡激活时间" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="validDate" HeaderText="卡有效时间" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="activeway" HeaderText="激活方式" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="activeoperator" HeaderText="操作员" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="memo" HeaderText="备注" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OldValuesParameterFormatString="" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount_Select"
            SelectMethod="GetPagedObjects_Select" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ims.Card.BLL.CardHelperBLL">
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
