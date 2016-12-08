<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardBatchRegistration.aspx.cs" Inherits="Card_CardBatchRegistration"  StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>不记名卡发放</title>

<link rel="stylesheet" href="../css/table.css" />
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
 <script type="text/javascript" src="../js/app.xmlhttp.js"></script>

<script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>
    
<script type="text/javascript">

function batchMakeCard()
{
    openBrWindow('SentCard.aspx','NewMemberInfo','455','455')  ;
}

function UpdateMemberInfo(Userid)
{
    openBrWindow('../Member/MemberOperation.aspx?getcode='+Userid,'EditMemberInfo','850','230')  ;
}
function ActiveMemberInfo(Userid)
{
$("#isFrame2").wBox({
requestType: "iframe",
target:"CardActive.aspx?type=activenoinfo&getcode="+Userid
});
$("#isFrame2").trigger("click");
 //   openBrWindow('CardActive.aspx?type=activenoinfo&getcode='+Userid,'ActiveMemberInfo','455','260')  ;
}	
</script>
    <script type="text/javascript">
WaitHelper.showWaitMessage();
    </script>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<a id="isFrame2" href="javascript:void(0)" style="display:none">isFrame2</a>
<ul class="sitemappath"><li><strong>基本信息</strong></li></ul>
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%" >
	  <tr> 
		<th >
            会员卡号</th>
		<td >
            <input type="text" class="inputblue" style="width:100px" id="card"  runat="server" name="card" maxlength="30" /></td>
		<th >
            状态</th>
		<td colspan="3" >
            <select id="cardstatus" runat="server" class="inputblue" name="cardstatus" style="width: 100px">
            </select></td>
	  </tr>
        <tr>
            <th>
                卡类型</th>
            <td>
                <select id="TypeID" runat="server" class="inputblue" name="TypeID" 
                    style="width: 100px">
                </select></td>
          <%--  <th width="100">
                所属人员</th>
            <td colspan="3">
                <select id="GroupID1" runat="server" class="inputblue" name="GroupID1" onchange="OnGroup()"
                    style="width: 96px">
                </select><select id="Member1" runat="server" class="inputblue" name="Member1" style="width: 96px">
                </select></td>--%>
             <th>
            发卡时间</th>
            <td colspan="3">
            <input type="text" class="inputblue" style="width:100px" id="addeddate1"  runat="server" onfocus="setday(this)" vdisp="起始时间" vtype="date" name="addeddate1" maxlength="20" />～<input type="text" class="inputblue" style="width:100px" id="addeddate2"  runat="server" onfocus="setday(this)" vdisp="截止时间" vtype="date" name="addeddate2" maxlength="20"/></tr>
       <%-- <tr>
            <th width="100">
            发卡时间</th>
            <td style="width: 235px" colspan="5">
            <input type="text" class="inputblue" style="width:100px" id="addeddate1"  runat="server" onfocus="setday(this)" vdisp="起始时间" vtype="date" name="addeddate1" maxlength="20" />～<input type="text" class="inputblue" style="width:100px" id="addeddate2"  runat="server" onfocus="setday(this)" vdisp="截止时间" vtype="date" name="addeddate2" maxlength="20"/></td>
            
        </tr>--%>
	    <tr>  
            <td align="right" colspan="6">
<%--                &nbsp;<input id="btnBatch" runat="server" class="btn003" name="btnBatch" onclick="batchMakeCard()"
                    type="button" value="批量发卡" />--%>
                &nbsp; &nbsp;<input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>未激活卡信息</strong></div>
    <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue" 
        AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" Height="1px" 
        DataSourceID="ObjectDataSource1" PageSize="15">
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
                <ItemStyle CssClass="tbody_th"/>
               <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="balance" HeaderText="卡内金额" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TypeName" HeaderText="类型"  
                ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        <%--    <asp:BoundField DataField="GroupName" HeaderText="销售组"  ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="name" HeaderText="销售人员"  ItemStyle-HorizontalAlign="Center"/>--%>
            <asp:BoundField DataField="cardstatus" HeaderText="状态"  
                ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AddedDate" HeaderText="发卡时间" HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
                        <asp:BoundField DataField="initvalue" HeaderText="初始金额" HtmlEncode="False"  >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
              <asp:TemplateField ShowHeader="False">
                <ControlStyle Width="55px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="ActiveMemberInfo('<%# Eval("Card")%>')"><span style="color:orange">[卡片激活]</span></a>
                </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>         <div class="table_data_title xytact">
			<ul>
					<li><input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)"
                runat="server" /><label for="checkitall">全选</label><em>|</em></li>
					<li><input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)"
                runat="server" /><label for="chkChouse">反选</label><em>|</em></li>
                    <li><asp:Button ID="btnDelete" runat="server"
                Text="批量删除"  OnClientClick="return confirm('确定要删除选定项吗？');" OnClick="btnDelete_Click" 
                            Width="62px" BackColor="Transparent" BorderStyle="None" Height="25px" /></li>
			</ul>
		</div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.v_CardNoActiveBLL" OldValuesParameterFormatString="">
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
