<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberRankRules.aspx.cs" Inherits="Member_MemberRankRules" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>积分规则</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/MB.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script type="text/javascript">

function doInforEdit(Userid)
{
    openBrWindow('MemberOperation.aspx?getcode='+Userid,'EditMemberInfo','850','230')  ;
}


function doInfornew()
{
    openBrWindow('PointRateSet.aspx','NewPointRateSet','455','230');
}

</script>
<script>
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>积分规则调整查询</strong></li></ul>
			
<div class="appsection">
	<table width="835" cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th width="100" >
            操作时间</th>
		<td style="width: 235px" >
            <input id="operate_date_begin" runat="server" class="inputgreen" maxlength="20" name="operate_date_begin"
                onfocus="setday(this)" style="width: 100px" type="text" vdisp="起始时间" vtype="date" />～<input
                    id="operate_date_end" runat="server" class="inputgreen" maxlength="20" name="operate_date_end"
                    onfocus="setday(this)" style="width: 100px" type="text" vdisp="截止时间" vtype="date" /></td>
		<th width="100" >
            操作工号</th>
		<td width="150" >
            <input id="operater" runat="server" class="inputgreen" maxlength="10" name="operater"
                style="width: 100px" type="text" />&nbsp;</td>
		<th width="100" >
            记录编号</th>
		<td style="width: 156px">
            <input id="id" runat="server" class="inputgreen" maxlength="15" name="id" style="width: 100px"
                type="text" /></td>
	  </tr>
	    <tr>  
            <td align="right" colspan="6">
                <input type="button" name="btnCon" class="btn003" value="设置" onclick="doInfornew()" id="btnNew" runat="server" />
	        <input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;" id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>规则调整信息</strong></div>
    <asp:GridView Width="835px" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
        <Columns>
           <asp:TemplateField HeaderText="记录编号">
                <ItemTemplate>
                     <%# Eval("logid")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" Width="100px"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="员工工号">
                <ItemTemplate>
                    <%# Eval("operater")%>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="operate_date" HeaderText="操作时间" >
                <HeaderStyle Width="150px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="logmsg" HeaderText="操作备注" >
            </asp:BoundField>
        </Columns>
    </asp:GridView>	

</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Log.BLL.LogHelperBLL" OldValuesParameterFormatString="">
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
