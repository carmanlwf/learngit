<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardBatchSend.aspx.cs" Inherits="Card_CardBatchSend" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>不记名卡发放</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/CD.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>
<script type="text/javascript">

function doInfornew()
{
    openBrWindow('CardBatchOper.aspx','NewMemberInfo','455','240')  ;
}

function UpdateMemberInfo(Userid)
{
    openBrWindow('../Member/MemberOperation.aspx?getcode='+Userid,'EditMemberInfo','850','230')  ;
}
function ActiveMemberInfo(Userid)
{
    openBrWindow('CardActive.aspx?getcode='+Userid,'ActiveMemberInfo','455','210')  ;
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
<script type="text/javascript">
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
			
<div class="appsection">
<ul class="sitemappath"><li><strong>基本信息</strong></li></ul>
			
<div class="appsection">
	<table width="100%" cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th width="100" >
            会员卡号</th>
		<td style="width: 235px" >
            <input type="text" class="inputblue" style="width:100px" id="card"  
                runat="server" name="card" maxlength="30" /></td>
		<th width="100" >
            会员姓名</th>
		<td width="150" >
		  <input type="text" class="inputblue" style="width:100px" id="RealName"  
                runat="server" name="RealName" maxlength="10" />&nbsp;</td>
		<th width="100" >
            卡状态</th>
		<td style="width: 156px">
		  <select class="inputgreen" style="width:100px" id="Status" runat="server" name="Status">
			<option selected="selected" value="1">正常</option>
              <option value="2">挂失</option>
              <option value="3">注销</option>
              <option value="0">未激活</option>
              <option value="4">补卡</option>
		  </select>
        </td>
	  </tr>
	  <tr>
	    <th >
            发卡时间</th>
	    <td style="width: 245px"><input type="text" class="inputblue" style="width:100px" 
                id="addeddate1"  runat="server" onfocus="setday(this)" vdisp="起始时间" 
                vtype="date" name="addeddate1" maxlength="20" />～<input type="text" class="inputgreen" style="width:100px" id="addeddate2"  runat="server" onfocus="setday(this)" vdisp="截止时间" vtype="date" name="addeddate2" maxlength="20"/></td>
		  <th >
              是否启用</th>
		<td colspan="3">
            <select id="flag" runat="server" class="inputgreen" name="flag" style="width: 60px">
                <option value="false">禁用</option>
                <option selected="selected" value="true">启用</option>
            </select>
        </td>
		</tr>
	    <tr>  
            <td align="right" colspan="6">
                &nbsp;<input id="btnBatch" runat="server" class="btn003" name="btnBatch" onclick="doInfornew()"
                    type="button" value="批量发卡" />
                &nbsp; &nbsp;<input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;if(!checkdate('addeddate1','addeddate2'))  return false;" id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>
<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>激活卡信息</strong></div>
    <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue" 
                AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
                DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Card") %>' Visible="False"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="会员卡号">
                <ItemTemplate>
                     <%# Eval("Card")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:BoundField DataField="RealName" HeaderText="姓名" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="RankName" HeaderText="会员等级" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="points" HeaderText="积分" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="balance" HeaderText="账户余额" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Expenditure" HeaderText="消费总额" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="sitename" HeaderText="所属门店" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="AddedDate" HeaderText="发卡时间" HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:TemplateField ShowHeader="False">
                <ControlStyle Width="55px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="UpdateMemberInfo('<%# Eval("userid")%>')"><img style="border:0;" alt="添加用户信息" src="../images/man.gif" id="imedit" /></a>
                </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField ShowHeader="False">
                <ControlStyle Width="55px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="ActiveMemberInfo('<%# Eval("Card")%>')"><img style="border:0;" alt="激活用户卡片" src="../images/unlink.gif" id="imedit" /></a>
                </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>	
    
        
     <input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)" /><label
                for="checkitall">全选</label>
                 <input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)" /><label
                for="chkChouse">反选</label>
            <span class="btngrey">
                <asp:Button ID="btnDelete" runat="server" Text="删除所选" class="icondel" Style="width: 75px"
                    OnClientClick="return confirm('确定要删除选定项吗？');" 
               onclick="btnDelete_Click" />
            </span>
    
    
    
    
    
    
    
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount_NoActive" SelectMethod="GetPagedObjects_NoActive" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.CardHelperBLL" OldValuesParameterFormatString="">
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
