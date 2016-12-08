<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_SiteCount.aspx.cs" StylesheetTheme="app" Inherits="Report_Rpt_SiteCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>路段营收信息</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/ST.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>
<script type="text/javascript">

WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>路段基本信息</strong></li></ul>
			
<div class="appsection">
	<table  cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%">
	  <tr> 
		<th >
            路段名称</th>
		<td >
		  <input type="text" class="inputblue" style="width:100px" id="sitename"  
                runat="server" maxlength="30" name="sitename" />		
		</td>
		<th >
            路段编号</th>
		<td ><input type="text" class="inputblue" style="width:100px" id="id"  runat="server" maxlength="20" />&nbsp;</td>
		<th >
            时间段</th>
		<td>
		  &nbsp;<input id="regtime1" runat="server" class="inputblue" maxlength="20" 
                onfocus="setdatetime(this)" style="width:130px" type="text" vdisp="起始时间" 
                vtype="date" name="regtime1" />～<input id="regtime2" runat="server" class="inputblue" 
                maxlength="20" onfocus="setdatetime(this)" style="width:130px" type="text" 
                vdisp="截止时间" vtype="date" name="regtime2" /></td>
	  </tr>
	    <tr>  
            <td align="right" colspan="6">
                &nbsp;&nbsp; &nbsp;
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server"  onserverclick="Button3_ServerClick" />&nbsp;
            <asp:Button ID="btnOut" runat="server" Text="导出" class="btn003" OnClick="btnOut_Click"  style="display:none;"/> &nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>营收信息</strong></div>
    <asp:GridView Width="100%" PageSize="12" ID="GridView1" runat="server" 
        SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True">
        <Columns>
           <asp:TemplateField HeaderText="路段编号">
                <ItemTemplate>
                     <%# Eval("id")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="路段名称">
                <HeaderStyle Width="80px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doSeeInfo('<%# Eval("id")%>');"><%# Eval("sitename")%></a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="XFTJ_Count" HeaderText="消费交易笔数" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="XFTJ_Amount" HeaderText="消费交易总额" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CZTJ_Count" HeaderText="充值交易笔数" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CZTJ_Amount" HeaderText="充值交易总额" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CDTJ_Count" HeaderText="撤单交易笔数" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CDTJ_Amount" HeaderText="撤单交易总额" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>	


    <br />

<div id="SumPan"  runat = "server" style="width: 500px" >
    <span class="btngrey">累计消费笔数:<asp:Label ID="Label1" runat="server" 
        ForeColor="#C00000" Text="0"></asp:Label>&nbsp; 累计营收金额:<asp:Label ID="Label4" 
        runat="server" ForeColor="#C00000" Text="0.00"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    EnablePaging="True" MaximumRowsParameterName="pageSize" 
    OnSelecting="ObjectDataSource1_Selecting" 
    SelectCountMethod="RptSiteCountDataCount" 
    SelectMethod="RptSiteCountGetPagedObject" SortParameterName="sortedBy" 
    StartRowIndexParameterName="startIndex" TypeName="Ims.Site.BLL.SiteHelperBLL" 
    OldValuesParameterFormatString="">
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
