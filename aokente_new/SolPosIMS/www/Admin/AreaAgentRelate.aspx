﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AreaAgentRelate.aspx.cs" Inherits="Admin_AreaAgentRelate" StylesheetTheme="app" EnableSessionState="ReadOnly" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>组与用户对照管理</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script src="../js/app.edit.js"></script>

    <script>
        function EditAgent(select) 
        { 
            if(select == null || select == "undefined" ) 
            {
                alert('未选择用户，不能编辑！');
                return;
            }
            if(select.selectedIndex<0) 
            {
                alert('未选择用户，不能编辑！');
                return;
            }
             if(select.id=="agentIn")
             {
                
                var url = "AgentInfo.aspx?pub_agentid=" + select.options[select.selectedIndex].value + "&pub_agent_status=edit";
                //调转页面
                openBrWindow(url,'AgentInfo','605','220');
            }
            else if(select.id=="agentOut")
            {
                var url = "AgentInfo.aspx?pub_employeeid=" + select.options[select.selectedIndex].value + "&pub_agent_status=edit";
                //调转页面
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
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>区域代理信息</strong></div>
                        <table width="100%" cellpadding="1" cellspacing="1" class="table_default table_blue">
                            <tr>
                                <th width="20%">
                                    代理区域编号</th>
                                <td>
                                    <input id="areacode" name="areacode" type="text" class="inputgreen ime_engish" style="width: 100px" runat="server" maxlength="20" /></td>
                                <th width="20%">
                                    是否启用</th>
                                <td>
                                    <select id="flag" runat="server" class="inputgreen" name="flag" style="width: 60px">
                                        <option value="false">停用</option>
                                        <option selected="selected" value="true">启用</option>
                                    </select>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="4">
                                    <input id="btnQuery" type="button" name="btnQuery" class="btn003" value="查询" runat="server" onserverclick="btnQuery_ServerClick" />
                                    &nbsp;</td>
                            </tr>
                        </table>
                    <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False"
                        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AllowSorting="True" DataKeyNames="areacode"
                        Width="440px" PageSize="15" DataSourceID="ObjectDataSource1">
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle Width="35px" HorizontalAlign="Center" CssClass="tbody_th" />
                                <ItemTemplate>
                                    <asp:RadioButton ID="radBtnSel" AutoPostBack="true" OnCheckedChanged="radBtnSel_CheckedChanged"
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="areacode" HeaderText="代理区域编号" >
                                <HeaderStyle Width="114px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="areaname" HeaderText="代理区域名称" >
                                <HeaderStyle Width="209px" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="flag" HeaderText="是否有效" >
                                <HeaderStyle Width="112px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CheckBoxField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
                        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
                        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
                        TypeName="Ims.Site.BLL.AreaHelperBLL" DataObjectTypeName="">
                        <SelectParameters>
                            <asp:Parameter Name="o" Type="Object" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    &nbsp;
                </td>
                <td style="vertical-align: top; width: 175px; height: 498px;">
                    <div class="apphead" style="width: 175px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>区域代理商</strong></div>
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
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>待分配用户</strong></div>
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
