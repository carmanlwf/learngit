<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="AreaCode.aspx.cs" StylesheetTheme="app"
    Inherits="Admin_AreaCode"  EnableSessionState="ReadOnly"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>������������</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
        <asp:Panel ID="panelQuery" Width="100%" runat="server">
            <div class="apphead">
                <img src="../images/bullet02.gif" class="appnavimg" /><strong>��ѯ����</strong></div>
            <table width="840px" cellpadding="1" cellspacing="1" class="table_default table_green">
                <tr>
                    <th width="85">
                        ����</th>
                    <td width="157">
                        <input id="area" name="area" type="text" class="inputgreen ime_engish" style="width: 120px"
                            runat="server" /></td>
                    <th width="88">
                        ʡ��</th>
                    <td width="191">
                        <select name="ddlProvince" class="inputgreen" style="width: 120px" id="ddlProvince"
                            runat="server">
                            <option value="" selected="selected">ȫ��</option>
                        </select>
                    </td>
                    <td align="right">
                        <input id="btnQuery" type="button" name="btnQuery" class="btn003" value="��ѯ" onserverclick="btnQuery_ServerClick"
                            runat="server"></td>
                </tr>
            </table>
        </asp:Panel>
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appnavimg" /><strong>����������Ϣ</strong></div>
        <asp:GridView ID="gvArea" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
            SkinID="GridView_Red" AllowPaging="True" AllowSorting="True" DataKeyNames="area_code"
            Width="840px" PageSize="17">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="radBtnSel" AutoPostBack="true" OnCheckedChanged="radBtnSel_CheckedChanged"
                            runat="server" />
                    </ItemTemplate>
                    <ItemStyle CssClass="tbody_th" />
                    <HeaderStyle Width="25px" />
                </asp:TemplateField>
                <asp:BoundField DataField="area_code" HeaderText="����" SortExpression="area_code">
                    <HeaderStyle Width="114px" />
                </asp:BoundField>
                <asp:BoundField DataField="area_name" HeaderText="��������" SortExpression="area_name">
                    <HeaderStyle Width="209px" />
                </asp:BoundField>
                <asp:BoundField DataField="province_name" HeaderText="ʡ��" SortExpression="province_code">
                    <HeaderStyle Width="180px" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="have_gateway" HeaderText="�Ƿ�������" SortExpression="have_gateway">
                    <HeaderStyle Width="112px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
                <asp:BoundField DataField="gateway_code" HeaderText="���غ�" SortExpression="gateway_code">
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ncl.Admin.BLL.AreaCodeBLL">
            <SelectParameters>
                <asp:Parameter Name="o" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appnavimg" /><strong>��ϸ��Ϣ</strong></div>
        <asp:Panel ID="panelAreaInfo" Width="100%" runat="server">
            <table width="845" cellpadding="1" cellspacing="1" class="table_default table_yellow">
                <tr>
                    <th width="9%">
                        ����</th>
                    <td width="20%">
                        <input id="areacode" name="areacode" type="text" class="inputgreen ime_engish"  vdisp="����" vmode="not null" maxlength="8"  vtype="NumAndStr" style="width: 120px"
                            runat="server"><span style="color: #ff0000">*</span></td>
                    <th width="10%">
                        ��������</th>
                    <td width="22%">
                        <input id="city" name="city" type="text" class="inputgreen " maxlength="32"  style="width: 120px"
                            value="����" runat="server"></td>
                    <th width="11%">
                        ʡ��</th>
                    <td width="28%">
                        <select name="province" class="inputgreen" style="width: 120px" id="province" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <th>
                        ���غ�</th>
                    <td>
                        <input id="gatewaycode" name="gatewaycode" type="text"  vdisp="���غ�"  vtype="NumAndStr"   maxlength="16" class="inputgreen ime_engish" style="width: 120px"
                            runat="server"></td>
                    <td colspan="3">
                        <input id="gatewayflag" type="checkbox" name="gatewayflag" value="checkbox" checked="CHECKED"
                            runat="server" />
                        �Ƿ��б�������</td>
                    <td align="right">
                        <input id="btnAdd" type="button" name="btnAdd" class="btn003" value="����" onserverclick="btnAdd_ServerClick"
                            runat="server">
                        <input id="btnSave" type="button" name="btnSave" class="btn003" value="����"  onclick="if (!doAllMessageBoxValidate(form1)) return false;"  onserverclick="btnSave_ServerClick"
                            runat="server"></td>
                </tr>
            </table>
        </asp:Panel>
    </form>
    <script>
WaitHelper.initWaitMessageForms("form1");  
</script>  
</body>
</html>
