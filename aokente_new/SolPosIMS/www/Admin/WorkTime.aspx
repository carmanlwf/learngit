<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="WorkTime.aspx.cs" StylesheetTheme="app"
    Inherits="Admin_WorkTime"  EnableSessionState="ReadOnly" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>上班时间设置</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>

</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appnavimg" /><strong>时间设定</strong></div>
        <asp:GridView Width="835px" ID="gvWorkTime" runat="server" AutoGenerateColumns="False"
            DataSourceID="ObjectDataSource1" SkinID="GridView_Red" AllowPaging="True"  DataKeyNames="WHATDAY">
            <Columns>
                <asp:BoundField ReadOnly="True" DataField="WHATDAY_NAME" HeaderText="星期">
                    <ItemStyle  CssClass="tbody_th" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="AGENTSTART_TIME" HeaderText="上班时间" SortExpression="AGENTSTART_TIME">
                 <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="AGENTEND_TIME" HeaderText="下班时间" SortExpression="AGENTEND_TIME">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="SERVICESTART_TIME" HeaderText="服务开始时间" SortExpression="SERVICESTART_TIME">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="SERVICEEND_TIME" HeaderText="服务结束时间" SortExpression="SERVICEEND_TIME">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="TRANSFER_FLAG" HeaderText="是否转接" SortExpression="TRANSFER_FLAG">
                    <ItemStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:CheckBoxField DataField="WORK_FLAG" HeaderText="是否正常上班" SortExpression="WORK_FLAG">
                    <ItemStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:CheckBoxField DataField="HAVE_AGENT" HeaderText="是否有人值守" SortExpression="HAVE_AGENT">
                    <ItemStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:CommandField HeaderText="操作" ButtonType="Image" EditImageUrl="~/images/edit.gif"
                    ShowEditButton="True" CancelImageUrl="~/images/cancel.gif" UpdateImageUrl="~/images/save.gif">
                    <HeaderStyle Width="60px" />
                     <ItemStyle Width="60px" HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ncl.Admin.BLL.WorkTimeBLL" DataObjectTypeName="Ncl.Admin.Model.WorkTimeInfo"
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
