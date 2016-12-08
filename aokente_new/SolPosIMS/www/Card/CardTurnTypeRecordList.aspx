<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardTurnTypeRecordList.aspx.cs" Inherits="Card_CardTurnTypeRecordList"  StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>会员卡类型转换记录</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/json.js"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
    <script src="../js/checkdate.js" type="text/javascript"></script>
<script type="text/javascript">
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
        <style type="text/css">
            .style1
            {
                width: 297px;
            }
            .style2
            {
                height: 18px;
                width: 297px;
            }
            .style3
            {
                width: 88px;
            }
            .style4
            {
                height: 18px;
                width: 88px;
            }
        </style>
</head>
<body style="width:98%"  >
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>会员卡基本信息</strong></li></ul>
			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%" >
	  <tr> 
		<th class="style3" >
            会员卡号</th>
		<td class="style1" >
            <input type="text" class="inputblue" style="width:120px" id="CardID"  runat="server" name="CardID" maxlength="30" />&nbsp;
		</td>
		<th style="width: 97px" >
            会员姓名</th>
		<td >
		  <input type="text" class="inputblue" style="width:120px" id="RealName"  runat="server" name="RealName" maxlength="10" />&nbsp; </td>
	  </tr>
	  <tr>
	    <th class="style4" >
            转换时间</th>
	    <td class="style2"><input type="text" class="inputblue" style="width:110px" id="AddDate1"  runat="server" onfocus="setday(this)" vdisp="起始时间" vtype="date" name="AddDate1" maxlength="20" />～<input type="text" class="inputblue" style="width:110px" id="AddDate2"  runat="server" onfocus="setday(this)" vdisp="截止时间" vtype="date"   name="AddDate2" maxlength="20"/></td>
		  <th style="height: 18px; width: 97px;" >
              </th>
		<td style="height: 18px">
            </td>
		</tr>
	    <tr>  
            <td align="right" colspan="4" style="height: 18px">
                &nbsp;&nbsp; &nbsp;&nbsp;
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onserverclick="Button3_ServerClick"  onclick="if(!doAllMessageBoxValidate(Form1)) return false;if(!checkdate('AddDate1','AddDate2'))  return false;"/>&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>会员卡信息</strong></div>
    <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue" 
        AllowPaging="True" AutoGenerateColumns="False"  AllowSorting="True" 
        PageSize="15" Height="45px" DataSourceID="ObjectDataSource1" >
        <Columns>
           <asp:TemplateField HeaderText="会员卡号">
                <ItemTemplate>
                     <%# Eval("TID")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
 
            <asp:BoundField DataField="CardID" HeaderText="卡号" >
              <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
              <asp:BoundField DataField="RealName" HeaderText="会员姓名" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
                <asp:BoundField DataField="OTypeName" HeaderText="原类型" >
                  <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
                  <asp:BoundField DataField="NTypeName" HeaderText="新类型" >
                    <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
                    <asp:BoundField DataField="TMan" HeaderText="操作员" >
                      <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
                      <asp:BoundField DataField="AddDate" HeaderText="转换日期" >
            
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            
        </Columns>
    </asp:GridView>	
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.tb_TurnTypeRecordBLL" OldValuesParameterFormatString="">
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
