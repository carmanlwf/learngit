<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardChargeStatics.aspx.cs" Inherits="Sysem_CardChargeStatics" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>充值金额统计</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>
<script type="text/javascript">

WaitHelper.showWaitMessage();
</script>
    <style type="text/css">
        .style2
        {
            height: 18px;
            width: 98px;
        }
        .style4
        {
            height: 18px;
            width: 148px;
        }
        .style6
        {
            height: 18px;
            width: 120px;
        }
        .style7
        {
            height: 18px;
            width: 384px;
        }
        .style8
        {
            height: 18px;
            width: 340px;
        }
    </style>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>充值统计信息</strong></li></ul>
			
<div class="appsection">
	<table  cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%">
	  <tr>
	    <th class="style6" >
              操作员工号</th>
		<td class="style4" >
                    <input type="text" class="inputblue" style="width: 100px" 
                id="operatorid" runat="server"
                        name="operatorid" maxlength="15" /></td>
		<th class="style2" >
            时间段</th>
		<td class="style7" >
            <input id="OperateDate1" runat="server" class="inputblue" maxlength="20" 
                onfocus="setdatetime(this)" style="width:130px" type="text" vdisp="起始时间" 
                vtype="date" name="OperateDate1" />～<input id="OperateDate2" runat="server" class="inputblue" 
                maxlength="20" onfocus="setdatetime(this)" style="width:130px" type="text" 
                vdisp="截止时间" vtype="date" name="OperateDate2" /> </td> 
		<td class="style8" >
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem>查询本年</asp:ListItem>
                <asp:ListItem>查询本月</asp:ListItem>
                <asp:ListItem>查询今天</asp:ListItem>
                <asp:ListItem Selected="True">自定义</asp:ListItem>
            </asp:RadioButtonList>
                </td>
	  </tr>
	    <tr>  
            <td align="right" colspan="5">
                                &nbsp;&nbsp;&nbsp;
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="btnSelect" 
                    runat="server" 
                    onclick="if(!checkdate('OperateDate1','OperateDate2'))  return false;" 
                    onserverclick="Button3_ServerClick" />&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>充值统计信息</strong></div>
    <asp:GridView Width="100%" PageSize="12" ID="GridView1" runat="server" 
        SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True">
        <Columns>
           <asp:TemplateField HeaderText="编号">
                <ItemTemplate>
                     <%# Eval("serialid")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:BoundField DataField="operatorid" HeaderText="操作员工号" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="starttime" HeaderText="接班时间" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="endtime" HeaderText="交班时间" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ZCCount" HeaderText="累计充值笔数" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ZCMoney" HeaderText="累计充值金额" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="KCount" HeaderText="累计退款笔数" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="KMoney" HeaderText="累计退款金额" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="SumMoney" HeaderText="累计金额" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="VipCount" HeaderText="充值笔数(会员)" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="VipAmount" HeaderText="充值金额(会员)" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="logtime" HeaderText="记录时间" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>	
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    EnablePaging="True" MaximumRowsParameterName="pageSize" 
    OnSelecting="ObjectDataSource1_Selecting" 
    SelectCountMethod="GetObjectsCount_statics" 
    SelectMethod="GetPagedObjects_statics" SortParameterName="sortedBy" 
    StartRowIndexParameterName="startIndex" 
    TypeName="Ims.Card.BLL.CardChargeListBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br>
                    <div id="SumPan"  runat = "server" style="width: 800px" >
                    交易总额:<asp:Label ID="Label1" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    充值总额:<asp:Label ID="Label2" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    扣款总额:<asp:Label ID="Label3" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    营业总额:<asp:Label ID="Label4" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    充值笔数(会员):<asp:Label ID="Label5" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    充值总额(会员):<asp:Label ID="Label6" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    &nbsp;&nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
function Button4_onclick() {

}

</script>
</body>
</html>