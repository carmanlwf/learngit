<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="AgentQuery.aspx.cs" StylesheetTheme="app"
    Inherits="Admin_AgentQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�û���ѯ</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>

    <script language="JAVASCRIPT">
        function Authority() 
        { 
            
             var gvAgent = document.getElementById("gvAgent");
            if(gvAgent == null || gvAgent == "undefined" ) 
            {
                alert('δѡ���û���������Ȩ��');
                return;
            }
            var selectedValues = GridViewHelper.getCheckedValues("selectCheckboxButton1",true,true);
            var agentidsel="";
            for(i=0;i<selectedValues.length;i++)
            {
                if(selectedValues[i][0]=="")
                {   
                    alert('δ����Ա�������û�������Ȩ��');
                    return;
                }
                agentidsel += selectedValues[i][0]+",";
            }
            if(agentidsel!="") 
            {
                agentidsel=agentidsel.substring(0,agentidsel.length-1);
                var url="AgentAuthority.aspx?pub_agentid="+agentidsel;
                //��תҳ��
                openBrWindow(url,'AgentAuthority','width=860,height=500');
            }
            else alert('δѡ���û���������Ȩ��');
            
        }
        function EditAgent(employee_id) 
        { 
            if(employee_id == null || employee_id == "undefined" ) 
            {
                alert('δѡ���û������ܱ༭��');
                return;
            }

            var url = "AgentInfo.aspx?pub_employeeid=" + employee_id + "&pub_agent_status=edit";
            //��תҳ��
            openBrWindow(url,'AgentInfo','605','220');
            
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

// function CheckAll(form)  {
// document.getElementById('chkChouse').checked=false;
//  for (var i=0;i<form.elements.length;i++)    {
//    var e = form.elements[i];
//    if(e.name.indexOf('chkChouse')>-1)
//    continue;
//    if (e.name.indexOf('checkitall')==-1)       e.checked = form.checkitall.checked; 
//   }
//  }
//  
//   function FanCheckAll(form)  {
//   document.getElementById('checkitall').checked=false;
//  for (var i=0;i<form.elements.length;i++)    {
//    var e = form.elements[i];
//    if (e.name.indexOf('chkChouse')==-1)
//    {    
//    if(e.name.indexOf('checkitall')==-1)
//    {
//    if(e.checked)
//    e.checked = false;     
//    else   
//    e.checked = true;
//    }    
//    }
//   }
//  }
</script>
</head>
<body onload="doOnLoad();">
<script>
    WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
        <asp:Panel ID="panelQuery" Width="845px" runat="server">
            <div class="apphead" style="width: 845px">
                <img src="../images/bullet02.gif" class="appnavimg" /><strong>��ѯ����</strong></div>
            <table width="845" cellpadding="1" cellspacing="1" class="table_default table_blue">
                <tr>
                    <th width="100">
                        Ա������</th>
                    <td width="180">
                        <input id="agentid" name="agentid" type="text" class="inputblue" style="width: 120px"
                            runat="server" /></td>
                    <th width="100">
                        Ա�����</th>
                    <td width="180">
                        <input id="pm_employee_id" name="pm_employee_id" type="text" class="inputblue"
                            style="width: 120px" runat="server" />
                    </td>
                    <th width="100">
                        ����</th>
                    <td>
                        <input id="name" name="name" type="text" class="inputblue" style="width: 120px"
                            runat="server" />&nbsp;</td>
                </tr>
                <tr>
                    <th>
                        �Ƿ�����</th>
                    <td>
                        <select id="flag" runat="server" class="inputblue" name="flag" style="width: 60px">
                            <option value="false">ͣ��</option>
                            <option selected="selected" value="true">����</option>
                        </select>
                    </td>
                    <th>
                        </th>
                    <td>
                    </td>
                    <td align="right" colspan="2">
                        <input id="btnQuery" type="button" name="btnQuery" class="btn003" value="��ѯ" onserverclick="btnQuery_ServerClick"
                            runat="server">
                        <input id="btnAuthority" type="button" name="btnAuthority" class="btn003" value="��Ȩ"
                runat="server" onclick="Authority()"></td>
                </tr>
            </table>
        </asp:Panel>
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appnavimg" /><strong>�û���Ϣ</strong></div>
        <div style="width:845px;overflow-y:auto;height:465px;">
        <asp:GridView ID="gvAgent" runat="server" AutoGenerateColumns="False" SkinID="GridView_AutoWidth_Blue" DataKeyNames="pm_employee_id,id" Width="845px" OnRowDataBound="gvAgent_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ѡ��">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("pm_employee_id") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="Ա������" SortExpression="id">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Ա�����" SortExpression="pm_employee_id">
                    <ItemTemplate>
                        <a id="editAgent" runat="server" >
                            <%# Eval("pm_employee_id")%>
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="����" SortExpression="name">
                    <HeaderStyle Width="130px" />
                </asp:BoundField>
                <asp:BoundField DataField="sexname" HeaderText="�Ա�" SortExpression="sexname">
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="groupid" HeaderText="�ֵ���" SortExpression="groupinfo_id">
                </asp:BoundField>
                <asp:BoundField DataField="groupname" HeaderText="�ֵ�����" SortExpression="groupname"></asp:BoundField>
                <asp:BoundField DataField="access_time" HeaderText="����¼ʱ��" />
                <asp:BoundField DataField="access_ip" HeaderText="������IP" />
                <asp:BoundField DataField="access_serverip" HeaderText="����������" />
            </Columns>
        </asp:GridView>
        
<%--                   <input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)" /><label
                for="checkitall">ȫѡ</label>
                 <input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)" /><label
                for="chkChouse">��ѡ</label>
            <span class="btngrey">
                <asp:Button ID="btnDelete" runat="server" Text="ɾ����ѡ" class="icondel" Style="width: 75px"
                    OnClientClick="return confirm('ȷ��Ҫɾ��ѡ������');" 
               onclick="btnDelete_Click" />
            </span>
--%>
        
        
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OnSelecting="ObjectDataSource1_Selecting" 
            SelectMethod="GetObjects" TypeName="Ims.Admin.BLL.AgentInfoBLL">
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
