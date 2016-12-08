<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupList.aspx.cs" Inherits="GroupList" StylesheetTheme="app"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>组信息</title>
    
<link href="../css/app.newedit.css"rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js"charset="gb2312"></script>
<script type="text/javascript" src="js/PD.js"   charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js"charset="gb2312"></script>

<script type="text/javascript">

function doInforEdit(TypeId)
{
    openBrWindow('GroupOperation.aspx?getcode='+id,'EditProductInfo','360','60')  ;
}
function doInfornew()
{
    openBrWindow('GroupOperation.aspx','NewProductInfo','360','60')  ;
}
function doSeeInfoProductCategories(id)
{
    openBrWindow('GroupOperation.aspx?statu=readonly&getcode='+id,'SeeClassInfoInfo','360','60');
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

<script>
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:870px;">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>组名</strong></li></ul>
			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 370px; height: 1px" >
	  <tr> 
		<th style="width: 116px" >
            名称&nbsp;
        </th>
		<td colspan="3" style="width: 264px" >
            <input id="GroupName" runat="server" class="inputblue" maxlength="20" name="GroupName"
                style="width: 142px" type="text" vdisp="名称"  /></td>
	  </tr>
	    <tr>  
            <td align="right" colspan="4" style="height: 18px">
                &nbsp;&nbsp; &nbsp;<input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew()" id="btnNew" runat="server"  />
	        <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>组信息</strong></div>
    <asp:GridView Width="370px" ID="GridView1" runat="server" SkinID="GridView_FixedWidth_blue" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" Height="1px">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("GroupID") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="10px" />
                <HeaderStyle Width="25px" />
            </asp:TemplateField>
            <asp:BoundField DataField="GroupID" HeaderText="编号" >
                <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="GroupName" HeaderText="名称" />
              <asp:BoundField DataField="AddTime" HeaderText="添加时间" >
                  <HeaderStyle Width="120px" />
              </asp:BoundField>
        </Columns>
    </asp:GridView>	
 <asp:Panel ID="delPanel" runat="server" Width="248px" Height="1px">
           <input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)" runat="server" /><label
                for="checkitall">全选</label>
                 <input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)" runat="server" /><label
                for="chkChouse">反选</label>
            <span class="btngrey">
                <asp:Button ID="btnDelete" runat="server" Text="删除所选" class="icondel"
                    OnClientClick="return confirm('确定要删除选定项吗？');" 
               onclick="btnDelete_Click" CssClass="btn004" Width="70px" />&nbsp;&nbsp;&nbsp;</span>
                </asp:Panel>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Member.BLL.tb_GroupBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</form>

</body>
</html>
