<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_TransRecord.aspx.cs" Inherits="Report_Rpt_TransRecord" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>转账记录查询</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script type="text/javascript">

function doInforEdit(Userid)
{
    openBrWindow('MemberOperation.aspx?getcode='+Userid,'EditMemberInfo','850','230')  ;
}


function doInfornew()
{
    openBrWindow('MemberOperation.aspx','NewMemberInfo','850','230')  ;
}

</script>
<script>
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>转账记录查询</strong></li></ul>
			
<div class="appsection">
	<table width="835" cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th width="100" >
            交易编号</th>
		<td style="width: 235px" >
		  <input type="text" class="inputgreen" style="width:100px" id="TransNo"  runat="server" name="TransNo" maxlength="25" />		
		</td>
		<th width="100" >
            转出人姓名</th>
		<td width="150" ><input type="text" class="inputgreen" style="width:100px" id="name1"  runat="server" name="name1" maxlength="10" />&nbsp;</td>
		<th width="100" >
            转入人姓名</th>
		<td style="width: 156px"><input type="text" class="inputgreen" style="width:100px" id="name2"  runat="server" name="name2" maxlength="10" />&nbsp;</td>
	  </tr>
        <tr>
            <th style="height: 18px" width="100">
                转出卡号</th>
            <td style="width: 235px; height: 18px">
                <input type="text" class="inputgreen" style="width:100px" id="card1"  runat="server" name="card1" maxlength="20" /></td>
            <th style="height: 18px" width="100">
                转入卡号</th>
            <td style="height: 18px" width="150">
                <input type="text" class="inputgreen" style="width:100px" id="card2"  runat="server" name="card2" maxlength="20" /></td>
            <th style="height: 18px" width="100">
                </th>
            <td style="width: 156px; height: 18px">
            </td>
        </tr>
	  <tr>
	    <th >
            注册时间</th>
	    <td style="width: 245px"><input type="text" class="inputgreen" style="width:100px" id="operate_date_begin"  runat="server" onfocus="setday(this)" vdisp="起始时间" vtype="date" name="operate_date_begin" maxlength="20" />～<input type="text" class="inputgreen" style="width:100px" id="operate_date_end"  runat="server" onfocus="setday(this)" vdisp="截止时间" vtype="date" name="operate_date_end" maxlength="20"/></td>
		  <th >
              </th>
		<td colspan="3">
        </td>
		</tr>
	    <tr>  
            <td align="right" colspan="6">
                &nbsp;&nbsp; &nbsp;
	        <input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;" id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>会员信息</strong></div>
    <asp:GridView Width="835px" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="TransNo" HeaderText="交易号" >
            </asp:BoundField>
            <asp:BoundField DataField="card1" HeaderText="转出卡号" >
            </asp:BoundField>
            <asp:BoundField DataField="card1_OldBalance" HeaderText="转出卡原金额" />
            <asp:BoundField DataField="card2" HeaderText="转入卡号" />
            <asp:BoundField DataField="card2_OldBalance" HeaderText="转入卡原金额" >
            </asp:BoundField>
            <asp:BoundField DataField="Amount" HeaderText="发生金额" />
            <asp:BoundField DataField="card1_NewBalance" HeaderText="转出卡后金额" />
            <asp:BoundField DataField="card2_NewBalance" HeaderText="转入卡后金额" />
            <asp:BoundField DataField="operator" HeaderText="操作员" />
            <asp:BoundField DataField="operatedate" HeaderText="操作时间" HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}" >
            </asp:BoundField>
        </Columns>
    </asp:GridView>	

</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.TransHelperBLL" OldValuesParameterFormatString="">
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
