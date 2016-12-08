<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="SystemParameter.aspx.cs"
    StylesheetTheme="app" Inherits="Admin_SystemParameter"  EnableSessionState="ReadOnly" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>系统参数设置</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>
</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
        <div class="apphead" style="width: 840px">
            <img src="../images/bullet02.gif" class="appnavimg" /><strong>参数信息</strong></div>
        <asp:GridView Width="840px" ID="gvPara" runat="server" AutoGenerateColumns="False"
            DataSourceID="ObjectDataSource1" SkinID="GridView_Red" AllowPaging="True" AllowSorting="True"
            DataKeyNames="id" PageSize="20" OnRowUpdating="gvPara_RowUpdating" OnRowUpdated="gvPara_RowUpdated" >
            <Columns>
                <asp:TemplateField HeaderText="行号">
                    <ItemStyle Width="40px" CssClass="tbody_th" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%# (gvPara.PageIndex * gvPara.PageSize + Container.DataItemIndex + 1).ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ReadOnly="True" DataField="PARA_ID" HeaderText="参数代码" SortExpression="PARA_ID">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="PARA_CATNAME" HeaderText="参数名称" SortExpression="PARA_CATNAME">
                </asp:BoundField>
                <asp:BoundField DataField="PARA_IDNAME" HeaderText="参数值" SortExpression="PARA_IDNAME">
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField ReadOnly="True"  DataField="AGENT_ID" HeaderText="维护人" SortExpression="AGENT_ID">
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField ReadOnly="True"  DataField="REFRESH_DATE" HeaderText="维护时间" SortExpression="REFRESH_DATE">
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="VALID_FLAG" HeaderText="是否有效" SortExpression="VALID_FLAG">
                    <HeaderStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
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
            TypeName="Ncl.Admin.BLL.SysParaBLL" DataObjectTypeName="Ncl.Admin.Model.SysParaData"
            UpdateMethod="UpdateObject">
            <SelectParameters>
                <asp:Parameter Name="o" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
    <script>
WaitHelper.initWaitMessageForms("form1");  
</script>  
</body>
</html>
