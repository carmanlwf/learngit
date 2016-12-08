<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="BranchManage.aspx.cs" StylesheetTheme="app"
    Inherits="Admin_BranchManage"  EnableSessionState="ReadOnly"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>分公司信息维护</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>

</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
        <table width="750px" cellpadding="1" cellspacing="1">
            <tr>
                <td style="vertical-align: top">
                    <div style="height: 550px; overflow-y: auto">
                        <div class="apphead" style="width: 125px">
                            <img src="../images/bullet02.gif" class="appnavimg" /><strong>公司组织结构</strong></div>
                        <asp:TreeView ID="tvOrg" Style="width: 125px" runat="server" OnSelectedNodeChanged="tvOrg_SelectedNodeChanged">
                            <SelectedNodeStyle BackColor="#A5CED1" />
                        </asp:TreeView>
                        <input id="btnRefresh" type="button" name="btnRefresh" class="btn003" value="刷新" onserverclick="btnRefresh_ServerClick"
                            runat="server">
                    </div>
                </td>
                <td style="vertical-align: top">
                    <div class="apphead" style="width: 600px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>分公司信息</strong></div>
                    <asp:GridView Width="600px" ID="gvBranch" runat="server" AutoGenerateColumns="False"
                        DataSourceID="ObjectDataSource1" SkinID="GridView_Red" AllowPaging="True" AllowSorting="True"
                        DataKeyNames="OrgCode" PageSize="20">
                        <Columns>
                            <asp:TemplateField HeaderText="行号">
                                <ItemStyle Width="40px" CssClass="tbody_th"  HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <%# (gvBranch.PageIndex*gvBranch.PageSize+Container.DataItemIndex+1).ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ReadOnly="True" DataField="OrgCode" HeaderText="代码" SortExpression="orgcode">
                                <HeaderStyle Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField ReadOnly="True" DataField="Name" HeaderText="名称" SortExpression="NAME">
                            </asp:BoundField>
                            <asp:BoundField DataField="ShortName" HeaderText="简称" SortExpression="shortname">
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AreaCode" HeaderText="电话区号" SortExpression="areacode">
                                <HeaderStyle Width="100px" />
                            </asp:BoundField>
                            <asp:CommandField HeaderText="操作" ButtonType="Image" EditImageUrl="~/images/edit.gif"
                                ShowEditButton="True" CancelImageUrl="~/images/cancel.gif" UpdateImageUrl="~/images/save.gif">
                                <HeaderStyle Width="60px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
                        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
                        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
                        TypeName="Ncl.Admin.BLL.BranchManageBLL" DataObjectTypeName="Ncl.Admin.Model.ManageComInfo"
                        UpdateMethod="UpdateObject">
                        <SelectParameters>
                            <asp:Parameter Name="o" Type="Object" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </form>
    <script>
WaitHelper.initWaitMessageForms("form1");  
</script>  
</body>
</html>
