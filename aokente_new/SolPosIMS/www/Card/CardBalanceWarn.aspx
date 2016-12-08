<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardBalanceWarn.aspx.cs" Inherits="Card_CardBalanceWarn" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>余额信息</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
           <link rel="stylesheet" href="../css/table.css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/json.js"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
<script type="text/javascript">

</script>
<script type="text/javascript">
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>帐户余额信息</strong></li></ul>
			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%" >
	  <tr> 
		<th >
            车牌号</th>
		<td >
            <input type="text" class="inputblue" style="width:120px" id="card"  runat="server" name="card" maxlength="30" />&nbsp;
		</td>
		<th style="width: 97px" >
            姓名</th>
		<td >
		  <input type="text" class="inputblue" style="width:120px" id="RealName"  runat="server" name="RealName" maxlength="10" />&nbsp;</td>
		<th >
            少于金额</th>
		<td><input type="text" class="inputblue" style="width:91px" id="balance2"  runat="server" name="balance2" maxlength="10" value="10" vdisp="少于金额" vmode="not null" vtype="double" /></td>
	  </tr>
	    <tr>  
            <td align="right" colspan="6" style="height: 18px">
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onserverclick="Button3_ServerClick"  onclick="if(!doAllMessageBoxValidate(Form1)) return false;"/>&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>帐户信息</strong></div>
    <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue" 
        AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
        PageSize="15" DataSourceID="ObjectDataSource1">
        <Columns>
           <asp:TemplateField HeaderText="车牌号">
                <ItemTemplate>
                     <%# Eval("Card")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:BoundField DataField="RealName" HeaderText="姓名" 
                ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                       <asp:BoundField DataField="TypeName" HeaderText="客户类型" >  
             <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="balance" HeaderText="帐户余额" 
                ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Points" HeaderText="积分" 
                ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="activitytime" HeaderText="激活时间" 
                ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <%--<asp:BoundField DataField="LastSaleTime" HeaderText="最后消费时间" />--%>
            <asp:BoundField DataField="statusname" HeaderText="状态" 
                ItemStyle-HorizontalAlign="Center">
            
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            
        </Columns>
    </asp:GridView>	
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.CardHelperBLL" OldValuesParameterFormatString="">
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
