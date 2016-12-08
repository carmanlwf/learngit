<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_LostMember.aspx.cs" Inherits="Report_Rpt_LostMember" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>客户流失信息</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/json.js"></script>
<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
<script type="text/javascript">
	function onAreaSelectChange()
	{
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.Site_Code.options.length = 0;
		BindNormalTableToListControl('Site_Code', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
		var txt = selectArea.options[selectArea.selectedIndex].text;
//		if(txt=="全部")
//		{
           var slt=document.getElementById("Site_Code");   
           var objOption=document.createElement("OPTION");   
           objOption.value='';   
           objOption.text='全部';   
           slt.add(objOption);   
//           alert(slt.options.length);   
           slt.options[slt.options.length-1].selected='selected';
//		}
	}
	
	function turnaddtime1()
	{
	 var time1=document.getElementById('operate_date_begin1').value;
	 document.getElementById('operate_date_begin').value=time1.replace(/-/g,"/");
	}
		function turnaddtime2()
	{
	 var time1=document.getElementById('operate_date_end1').value;
	 document.getElementById('operate_date_end').value=time1.replace(/-/g,"/");
	}
	</script>
<script>
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;" onload="onAreaSelectChange()">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>客户流失信息</strong></li></ul>
			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%" >
	  <tr> 
		<th >
            卡号</th>
		<td >
		  <input type="text" class="inputblue" style="width:100px" id="card"  runat="server" name="card" maxlength="25" />		
		</td>
		<th >
            姓名</th>
		<td ><input type="text" class="inputblue" style="width:100px" id="RealName"  runat="server" name="RealName" maxlength="25" /></td>
		<th >
            多久没来停车(月)</th>
		<td><input type="text" class="inputblue" style="width:100px" id="monthquantry"  runat="server" name="monthquantry" vtype="number" maxlength="10" /></td>
	  </tr>
	    <tr>  
            <td align="right" colspan="6">
                &nbsp;&nbsp;&nbsp;
	        <input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;" id="Button3" runat="server" onserverclick="Button3_ServerClick" />		
           <asp:Button  ID="btnOut" runat="server" class="btn003" Text="导出" OnClick="btnOut_Click"/>&nbsp;&nbsp;	
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>详细信息</strong></div>
    <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" 
        SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="card" HeaderText="卡号" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="RealName" HeaderText="名字" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText=" 等级" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Datetime1" HeaderText="最后消费时间" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="monthquantry" HeaderText="多久没来停车(月)" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>	

</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.v_loss_Member_infoBLL" OldValuesParameterFormatString="">
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
