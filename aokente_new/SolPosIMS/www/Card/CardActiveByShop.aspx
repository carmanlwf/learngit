<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardActiveByShop.aspx.cs" Inherits="Card_CardActiveByShop" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>临时激活卡信息</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/CD.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/json.js"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
	    <script type="text/javascript">
	function onAreaSelectChange()
	{
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.siteid.options.length = 0;
		BindNormalTableToListControl('siteid', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
	}
	</script>
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
    openBrWindow('CardActive.aspx?type=activehasinfo&getcode='+Userid,'ActiveMemberInfo','455','210')  ;
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
	<table width="835" cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th width="100" >
            会员卡号&nbsp;
        </th>
		<td style="width: 265px" >
            <input type="text" class="inputblue" style="width:100px" id="card"  runat="server" name="card" maxlength="30" />&nbsp;
		</td>
		<th style="width: 100px" >
                激活状态&nbsp;</th>
		          <td colspan="3">
                <select class="inputblue" style="width:100px" id="Status" runat="server" name="Status" enableviewstate="true">
                </select></td>
	  </tr>
        <tr>
            <th style="height: 18px" width="100">
                所属区域
            </th>
            <td style="width: 265px; height: 18px">
            <select id="Area_Code" runat="server" class="inputblue" name="Area_Code" onchange="onAreaSelectChange()"
                style="width: 102px" enableviewstate="true">
            </select></td>
            <th style="height: 18px; width: 100px;">
                激活方式</th>
            <td colspan="3" style="height: 18px">
                <select class="inputblue" style="width:100px" id="activityway" runat="server" name="acitivityway" enableviewstate="true">
                </select></td>
        </tr>
        
         <tr>
            <th style="height: 18px" width="100">
            所属分店
            </th>
            <td style="width: 265px; height: 18px">
            <select class="inputblue" style="width:101px" id="siteid" runat="server" name="siteid" enableviewstate="true">
		  </select></td>
            <th style="height: 18px; width: 100px;">
                &nbsp;</th>
            <td colspan="3" style="height: 18px">
                &nbsp;</td>
        </tr>
        <tr>
            <th width="100">
            激活时间
            </th>
            <td style="width: 265px">
                <input type="text" class="inputblue" style="width:100px" id="operate_date_begin"  runat="server" onfocus="setday(this)" vdisp="起始时间" vtype="date" name="operate_date_begin" maxlength="20" />～<input type="text" class="inputblue" style="width:100px" id="operate_date_end"  runat="server" onfocus="setday(this)" vdisp="截止时间" vtype="date" name="operate_date_end" maxlength="20"/></td>
            <th style="width: 100px">
            &nbsp;</th>
            <td colspan="3">
                </td>
        </tr>
	    <tr>  
            <td align="right" colspan="6">
                &nbsp;<input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;" id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>
<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>卡激活信息</strong></div>
    <asp:GridView Width="835px" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
        <Columns>
           <asp:TemplateField HeaderText="会员卡号">
                <ItemTemplate>
                     <%# Eval("Card")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
            <asp:BoundField DataField="initvalue" HeaderText="初始金额">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="balance" HeaderText="账户余额" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="sitename" HeaderText="所属门店" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="logtime" HeaderText="记录时间" HtmlEncode="False" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ActivityWay" HeaderText="激活方式">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="operatorid" HeaderText="操作员">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="activitydate" HeaderText="激活时间" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="statuname" HeaderText="激活状态" HtmlEncode="False" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
              <asp:TemplateField ShowHeader="False">
                <ControlStyle Width="55px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="ActiveMemberInfo('<%# Eval("Card")%>')"><img style="border:0;" alt="激活用户卡片" src="../images/unlink.gif" id="imedit" /></a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>	
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetPagedOActivityCardObjsCount" SelectMethod="GetPagedOActivityCardObjs" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.CardHelperBLL" OldValuesParameterFormatString="">
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

