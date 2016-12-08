<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserListByAuthority.aspx.cs"
    Inherits="Admin_UserListByAuthority" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户查询</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
    <script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
    <script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>

    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script language="JAVASCRIPT" type="text/javascript">
        function Authority() {

            var gvAgent = document.getElementById("gvAgent");
            if (gvAgent == null || gvAgent == "undefined") {
                alert('未选择用户，不能授权！');
                return;
            }
            var selectedValues = GridViewHelper.getCheckedValues("selectCheckboxButton1", true, true);
            var agentidsel = "";
            for (i = 0; i < selectedValues.length; i++) {
                if (selectedValues[i][0] == "") {
                    alert('未分配员工工号用户不能授权！');
                    return;
                }
                agentidsel += selectedValues[i][0] + ",";
            }
            if (agentidsel != "") {
                agentidsel = agentidsel.substring(0, agentidsel.length - 1);
                var url = "AgentAuthority.aspx?pub_agentid=" + agentidsel;
                //调转页面
                openBrWindow(url, 'AgentAuthority', 'width=860,height=500');
            }
            else alert('未选择用户，不能授权！');

        }
        function EditAgent(employee_id) {
            if (employee_id == null || employee_id == "undefined") {
                alert('未选择用户，不能编辑！');
                return;
            }

            var url = "AgentInfo.aspx?pub_employeeid=" + employee_id + "&pub_agent_status=edit";
            //调转页面
            openBrWindow(url, 'AgentInfo', '605', '220');

        }
        function addadmin() {
            $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"AddUserWithAuthority.aspx?type=addadmin&code=1"
    });
    $("#isFrameOpt").trigger("click");
           // openBrWindow('AddUserWithAuthority.aspx?type=addadmin&code=1', 'addManager', '405', '450');
        }
    </script>

    <script>
        function doOnLoad() {
            FormViewHelper.EnterToSumbit("form1", "agentid", "btnQuery");
        }
        function doOnFocus() {
            FormViewHelper.SetFocus("agentid");
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

        function UpdatePassWord(id, roleName) {
                $("#isFrameOpt").wBox({
                requestType: "iframe",
                target:"UpdatePassWord.aspx?getcode="+ id + "&rolesName=" + roleName
                });
                $("#isFrameOpt").trigger("click");
            //openBrWindow('UpdatePassWord.aspx?getcode=' + id, 'UpdatePassWord', '195', '50');
        }

        function onAreaSelectChange() {
            var selectArea = document.getElementById('Area_Code');
            var Area = selectArea.value;
            document.all.Site_Code.options.length = 0;
            BindNormalTableToListControl('Site_Code', "id", "sitename", "tb_site", "id", "areacode = '" + Area + "'", "请选择");


        }
    </script>
    <script>
        WaitHelper.showWaitMessage();
    </script>
</head>
<body onload="doOnLoad()" style="width:98%">
    <form id="form1" runat="server">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
    <strong>添加管理员</strong>
    <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%"">
        <tr>
            <th width="100">
                员工工号
            </th>
            <td style="width: 267px">
                <input id="id" name="id" type="text" class="inputblue" style="width: 120px" runat="server"
                    maxlength="20" />
            </td>
            <th width="100">
                员工编号
            </th>
            <td width="180">
                <input id="pm_employee_id" name="pm_employee_id" type="text" class="inputblue" style="width: 120px"
                    runat="server" maxlength="20" />
            </td>
            <th width="100">
                姓名
            </th>
            <td>
                <input id="name" name="name" type="text" class="inputblue" style="width: 120px" runat="server"
                    maxlength="10" />&nbsp;
            </td>
        </tr>
        <tr>
            <th>
                权限</th>
            <td style="width: 267px">
             
                <select id="roles" runat="server" class="inputblue" name="roles" style="width: 120px">
                </select></td>
            <th>
            </th>
            <td>
                &nbsp;</td>
            <td align="right" colspan="2">
                <select id="flag" runat="server" class="inputgreen" name="flag" style="width: 60px;
                    display: none">
                    <option value="false">停用</option>
                    <option selected="selected" value="true">启用</option>
                </select>
                &nbsp;<input id="btnNew" runat="server" class="btn003" name="btnCon" onclick="addadmin()"
                    type="button" value="新增" />
                <input id="btnQuery" type="button" name="btnQuery" class="btn003" value="查询" onserverclick="btnQuery_ServerClick"
                    runat="server" />
            </td>
        </tr>
    </table>
    <div class="apphead">
        <img src="../images/bullet02.gif" class="appnavimg" /><strong>用户信息<asp:GridView ID="gvAgent"
            runat="server" AutoGenerateColumns="False" SkinID="GridView_Blue" Width="100%"
            AllowPaging="True" AllowSorting="True" DataSourceID="ObjectDataSource1" 
            PageSize="15">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("pm_employee_id") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="员工工号" >
                    <HeaderStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pm_employee_id" HeaderText="员工编号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="姓名" >
                    <HeaderStyle Width="130px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="sexname" HeaderText="性别" >
                    <HeaderStyle Width="80px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="rolesName" HeaderText="权限" >
                <HeaderStyle Width="70px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="access_time" HeaderText="最后登录时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="access_ip" HeaderText="最后访问IP">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="access_serverip" HeaderText="服务器名称">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="修改密码">
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="UpdatePassWord('<%# Eval("id")%>', '<%# Eval("rolesName")%>')">
                            <span style="color:orange">[编辑]</span></a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </strong>
    </div>
<div class="table_data_title xytact">
			<ul>
					<li><input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)"
                runat="server" /><label for="checkitall">全选</label><em>|</em></li>
					<li><input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)"
                runat="server" /><label for="chkChouse">反选</label><em>|</em></li>
                    <li><asp:Button ID="btnDelete" runat="server"
                Text="批量删除"  OnClientClick="return confirm('确定要删除选定项吗？');" OnClick="btnDelete_Click" 
                            Width="62px" BackColor="Transparent" BorderStyle="None" Height="25px" /></li>
			</ul>
		</div>
    <%--        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ncl.Admin.BLL.AgentInfoBLL">
            <SelectParameters>
                <asp:Parameter Name="o" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
--%>
    </form>

    <script>
        WaitHelper.initWaitMessageForms("form1");  
    </script>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OldValuesParameterFormatString="" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Admin.BLL.AgentInfoBLL">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</body>
</html>
