<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserListByChannel.aspx.cs" Inherits="Admin_UserListByChannel" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>用户查询</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../../js/CD.js" charset="gb2312"></script>
    <script src="../js/app.edit.js"></script>

    <script language="JAVASCRIPT">
        function Authority() 
        { 
            
             var gvAgent = document.getElementById("gvAgent");
            if(gvAgent == null || gvAgent == "undefined" ) 
            {
                alert('未选择用户，不能授权！');
                return;
            }
            var selectedValues = GridViewHelper.getCheckedValues("selectCheckboxButton1",true,true);
            var agentidsel="";
            for(i=0;i<selectedValues.length;i++)
            {
                if(selectedValues[i][0]=="")
                {   
                    alert('未分配员工工号用户不能授权！');
                    return;
                }
                agentidsel += selectedValues[i][0]+",";
            }
            if(agentidsel!="") 
            {
                agentidsel=agentidsel.substring(0,agentidsel.length-1);
                var url="AgentAuthority.aspx?pub_agentid="+agentidsel;
                //调转页面
                openBrWindow(url,'AgentAuthority','width=860,height=500');
            }
            else alert('未选择用户，不能授权！');
            
        }
        function EditAgent(employee_id) 
        { 
            if(employee_id == null || employee_id == "undefined" ) 
            {
                alert('未选择用户，不能编辑！');
                return;
            }

            var url = "AgentInfo.aspx?pub_employeeid=" + employee_id + "&pub_agent_status=edit";
            //调转页面
            openBrWindow(url,'AgentInfo','605','220');
            
        }
    </script>
    <script type="text/javascript">
    function openInsertPage()
    {
        openBrWindow(' AddUserWithChannel.aspx','NewMemberInfo','830','600')  ; 
    }
    
    function UpdatePassWord(id)
{
    openBrWindow('UpdatePassWord.aspx?getcode='+id,'UpdatePassWord','342','300')  ;
}
</script>
<script>
function doOnLoad()
{
    FormViewHelper.EnterToSumbit("form1","agentid","btnQuery");
}
function doOnFocus()
{
    FormViewHelper.SetFocus("agentid");
}


function doInfornew()
{
    openBrWindow('ProductSortOperation.aspx','NewProductTypesInfo','705','200')  ;
}
 function CheckAll(form)  {
 document.getElementById('chkChouse').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if(e.name.indexOf('chkChouse')>-1)
    continue;
    if (e.name.indexOf('checkitall')==-1)       e.checked = form.checkitall.checked; 
   }
  }
  
   function FanCheckAll(form)  {
   document.getElementById('checkitall').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if (e.name.indexOf('chkChouse')==-1)
    {    
    if(e.name.indexOf('checkitall')==-1)
    {
    if(e.checked)
    e.checked = false;     
    else   
    e.checked = true;
    }    
    }
   }
  }
</script>
</head>
<body onload="doOnLoad();">
<script>
    WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
        <asp:Panel ID="panelQuery" Width="845px" runat="server">
            <div class="apphead" style="width: 845px">
                <img src="../images/bullet02.gif" class="appnavimg" /><strong>查询条件</strong></div>
            <table width="845" cellpadding="1" cellspacing="1" class="table_default table_blue">
                <tr>
                    <th width="100">
                        员工工号</th>
                    <td width="180">
                        <input id="agentid" name="agentid" type="text" class="inputgreen ime_engish" style="width: 120px"
                            runat="server" /></td>
                    <th width="100">
                        员工编号</th>
                    <td width="180">
                        <input id="pm_employee_id" name="pm_employee_id" type="text" class="inputgreen ime_engish"
                            style="width: 120px" runat="server" />
                    </td>
                    <th width="100">
                        姓名</th>
                    <td>
                        <input id="name" name="name" type="text" class="inputgreen " style="width: 120px"
                            runat="server" />&nbsp;</td>
                </tr>
                <tr>
                    <th>
                        产品品牌</th>
                    <td>
                        <select id="sort" runat="server" class="inputblue" name="sort" style="width: 100px">
                        </select>
                    </td>
                    <th>
                        是否经理</th>
                    <td>
                        <input id="superflag" runat="server" name="superflag" type="checkbox" /></td>
                    <td align="right" colspan="2">
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td colspan="2">
                    </td>
                    <td align="right" colspan="2">
                        <span style="font-size: 9pt; color: #333333; background-color: #8cc2dd"></span>&nbsp;&nbsp;
                        <input id="btnNew" runat="server" class="btn003" name="btnCon" onclick="openInsertPage()"
                            type="button" value="新增" />
                        <input id="btnQuery" type="button" name="btnQuery" class="btn003" value="查询" onserverclick="btnQuery_ServerClick"
                            runat="server">
                        </td>
                </tr>
            </table>
        </asp:Panel>
        <div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>用户信息</strong></div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" PageSize="20" SkinID="GridView_AutoWidth_Blue" Width="845px">
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("pm_employee_id") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="id" HeaderText="员工工号" />
                    <asp:BoundField DataField="pm_employee_id" HeaderText="员工编号" />
                    <asp:BoundField DataField="name" HeaderText="姓名" />
                    <asp:BoundField DataField="sexname" HeaderText="性别" />
                    <asp:BoundField DataField="sort" HeaderText="品牌" />
                    <asp:BoundField DataField="access_time" HeaderText="访问时间" />
                    <asp:BoundField DataField="access_ip" HeaderText="访问ip" />
                    <asp:BoundField DataField="access_serverip" HeaderText="服务器ip" />
                       <asp:TemplateField ShowHeader="False">
                <ControlStyle Width="55px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="UpdatePassWord('<%# Eval("id")%>')"><img style="border:0;" alt="重设密码" src="../images/set.gif" id="imedit" /></a>
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
            </asp:GridView>
                <asp:Panel ID="delPanel" runat="server" Width="200px">
        &nbsp;<input id="checkitall" class="inputblue" name="checkitall" onclick="CheckAll(this.form)"
            type="checkbox" /><label for="checkitall">全选</label>
        <input id="chkChouse" class="inputblue" name="chkChouse" onclick="FanCheckAll(this.form)"
            type="checkbox" /><label for="chkChouse">反选</label>
        <span class="btngrey">
            <asp:Button ID="btnDelete" runat="server" class="icondel" CssClass="btn004" 
                OnClientClick="return confirm('确定要删除选定项吗？');" Text="删除所选" Width="70px" OnClick="btnDelete_Click" /></span></asp:Panel>
            
           
            </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OldValuesParameterFormatString="" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ims.Admin.BLL.AgentInfoBLL">
            <SelectParameters>
                <asp:Parameter Name="o" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
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
</body>
</html>
