<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="InforSearch.aspx.cs" Inherits="PM_InforSearch" StylesheetTheme="app" EnableSessionState="ReadOnly"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>��Ա������Ϣ</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/PM.js" charset="gb2312"></script>

<script type="text/javascript">

function doInforEdit(code)
{
    openBrWindow('Infor.aspx?getcode='+code,'EditEmployeeInfo','850','580')  ;
}


function doInfornew()
{
    openBrWindow('Infor.aspx','NewEmployeeInfo','850','580')  ;
}

</script>

</head>

<body style="width:98%;">
<script>
WaitHelper.showWaitMessage();
</script><form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>��Ա������Ϣ</strong></li></ul>
			
<div class="appsection">
	<table width="835" cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th width="100" >����</th>
		<td style="width: 235px" >
		  <input type="text" class="inputblue" style="width:100px" id="pname"  runat="server" maxlength="10" />		
		</td>
		<th width="100" >Ա�����</th>
		<td width="150" >
		  <select id="code" runat="server" class="inputblue" style="width:100px">
		    <option value="" selected="selected"></option>
		  </select>
	    </td>
		<th width="100" >�Ա�</th>
		<td style="width: 156px">
            <select id="sex" runat="server" class="inputblue" name="sex" style="width: 100px">
                <option selected="selected" value="1">��</option>
                <option value="0">Ů</option>
            </select>
        </td>
	  </tr>
	  <tr>
	    <th >
            ��ְʱ��</th>
	    <td style="width: 245px">
		  <select class="inputblue" style="width:100px" id="beginentertime" runat="server">
			<option selected="selected" value=""></option>
			<option value="0.5">����</option>
			<option value="1">һ��</option>
			<option value="2">����</option>
			<option value="3">����</option>
			<option value="4">���꼰����</option>
		  </select>
            ��&nbsp;
		  <select class="inputblue" style="width:100px" id="endentertime" runat="server">
			<option selected="selected" value=""></option>
			<option value="0.5">����</option>
			<option value="1">һ��</option>
			<option value="2">����</option>
			<option value="3">����</option>
			<option value="4">����</option>
		  </select></td>
		  <th >��Ч��</th>
		<td colspan="3">
		  <select name="Station" class="inputblue" style="width:100px" id="flag" runat="server">
			<option value=""></option>
			<option selected="selected" value="true">��Ч</option>
			<option value="false">��Ч</option>
		  </select>
            <input type="button" name="btnCon" class="btn003" value="����" onclick="doInfornew()" id="btnNew" runat="server" />
	        <input type="button" name="btnCon" class="btn003" value="��ѯ" onclick="if(!doAllMessageBoxValidate(Form1)) return false;" id="Button3" runat="server" onserverclick="Button3_ServerClick" /></td>
		</tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>��Ա��Ϣ</strong></div>
    <asp:GridView Width="835px" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
        <Columns>
           <asp:TemplateField>
                <ItemTemplate>
                     <%# (GridView1.PageIndex * GridView1.PageSize + Container.DataItemIndex+1).ToString()%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th"/>
               <HeaderStyle Width="25px" />
            </asp:TemplateField>
            <asp:BoundField DataField="code" HeaderText="Ա�����" SortExpression="code" >
                <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="����" SortExpression="pname">
                <HeaderStyle Width="80px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doSeeInfo('<%# Eval("code")%>');"><%# Eval("pname")%></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="entertime" HeaderText="��ְʱ��" SortExpression="entertime" >
                <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ControlStyle Width="55px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("code")%>')"><img style="border:0;" alt="�༭" src="../images/edit.gif" id="imedit" /></a>
                </ItemTemplate>
                <ItemStyle Width="50px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>	

</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.PM.PmEmployeeInfo" OldValuesParameterFormatString="original_{0}">
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
