<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="GroupAgentRelate.aspx.cs"
    StylesheetTheme="app" Inherits="Admin_GroupAgentRelate" EnableSessionState="ReadOnly" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�ֵ곤����</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script src="../js/app.edit.js"></script>

    <script>
        function EditAgent(select) 
        { 
            if(select == null || select == "undefined" ) 
            {
                alert('δѡ���û������ܱ༭��');
                return;
            }
            if(select.selectedIndex<0) 
            {
                alert('δѡ���û������ܱ༭��');
                return;
            }
             if(select.id=="agentIn")
             {
                
                var url = "AgentInfo.aspx?pub_agentid=" + select.options[select.selectedIndex].value + "&pub_agent_status=edit";
                //��תҳ��
                openBrWindow(url,'AgentInfo','605','220');
            }
            else if(select.id=="agentOut")
            {
                var url = "AgentInfo.aspx?pub_employeeid=" + select.options[select.selectedIndex].value + "&pub_agent_status=edit";
                //��תҳ��
                openBrWindow(url,'AgentInfo','605','220');
            }
        }
    </script>

</head>
<body>

    <script>
WaitHelper.showWaitMessage();
    </script>

    <form id="form1" runat="server">
        <table cellspacing="0" style="width: 840px; margin-top: 3px; border-left-color: darkgray; border-bottom-color: darkgray; border-top-style: solid; border-top-color: darkgray; border-right-style: solid; border-left-style: solid; border-collapse: collapse; border-right-color: darkgray; border-bottom-style: solid;" border="1">
            <tr>
                <td style="vertical-align: top; width: 440px; height: 498px;">
                    <div class="apphead" style="width: 440px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>�ֵ�곤��Ϣ</strong></div>
                        <table width="100%" cellpadding="1" cellspacing="1" class="table_default table_blue">
                            <tr>
                                <th width="20%">
                                    �ֵ���</th>
                                <td>
                                    <input id="id" name="groupidquery" type="text" class="inputgreen ime_engish" style="width: 100px" runat="server" /></td>
                                <th width="20%">
                                    ��������</th>
                                <td>
                                    <select id="areacode" runat="server" class="inputgreen" name="areacode" style="width: 100px">
                                        <option selected="selected" value=""></option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">
                                    �Ƿ�����</th>
                                <td>
                                    <select id="flag" runat="server" class="inputgreen" name="flag" style="width: 60px">
                                        <option value="false">ͣ��</option>
                                        <option selected="selected" value="true">����</option>
                                    </select>
                                </td>
                                <td  align="right" colspan="2"><input id="btnQuery" type="button" name="btnQuery" class="btn003" value="��ѯ" runat="server" onserverclick="btnQuery_ServerClick" />
                                    &nbsp;</td>
                            </tr>
                        </table>
                    <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AllowSorting="True" DataKeyNames="id"
                        Width="440px" PageSize="15">
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="35px" HorizontalAlign="Center" CssClass="tbody_th" />
                                <ItemTemplate>
                                    <asp:RadioButton ID="radBtnSel" AutoPostBack="true" OnCheckedChanged="radBtnSel_CheckedChanged"
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="id" HeaderText="�ֵ���" >
                                <HeaderStyle Width="114px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sitename" HeaderText="�ֵ�����" >
                                <HeaderStyle Width="209px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="areacode" HeaderText="��������" >
                                <HeaderStyle Width="180px" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="flag" HeaderText="�Ƿ���Ч" >
                                <HeaderStyle Width="112px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CheckBoxField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
                        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
                        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
                        TypeName="Ims.Site.BLL.SiteHelperBLL" DataObjectTypeName="">
                        <SelectParameters>
                            <asp:Parameter Name="o" Type="Object" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    &nbsp;
                </td>
                <td style="vertical-align: top; width: 175px; height: 498px;">
                    <div class="apphead" style="width: 175px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>�곤�û�</strong></div>
                    <select id="agentIn" name="agentIn" size="34" multiple="true" style="width: 175px"
                        runat="server" ondblclick="EditAgent(this)">
                    </select>
                </td>
                <td style="vertical-align: center; width: 30px; height: 498px;">
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
                <td style="vertical-align: top; width: 175px; height: 498px;">
                    <div class="apphead" style="width: 175px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>�������û�</strong></div>
                    <select id="agentOut" name="agentOut" size="34" multiple="true" style="width: 175px"
                        runat="server" ondblclick="EditAgent(this)">
                    </select>
                </td>
            </tr>
        </table>
    </form>

    <script>
WaitHelper.initWaitMessageForms("form1");  
    </script>

</body>
</html>
