<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransLog.aspx.cs" Inherits="Sysem_TransLog" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>充值记录信息</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/MB.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script type="text/javascript" src="../lib/jquery/jquery-1.3.2.min.js"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>
 <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

function Delpayment(transNo,money1,card1)
{
            $.post("DelChongZhi.ashx", 
            { idno: transNo,money:money1,card:card1},function(data) {
            if (data == "yes") {
                alert("充值撤销成功!");//结算时返回余额不足
            }      
            else
            {
            alert("已经撤销，不能再次撤销");
            }       
        });
}

 function CheckAll(form)  {
 document.getElementById('chkChouse').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if(e.name.indexOf('chkChouse')>-1)
    continue;
    if (e.name.indexOf('checkitall')==-1)   e.checked = form.checkitall.checked; 
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
<body style="width:98%;">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>充值记录信息</strong></li></ul>
			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%" >
	  <tr> 
		<th width="100" >
            会员卡号</th>
		<td style="width: 226px" >
		  <input type="text" class="inputblue" style="width:100px" id="Card"  runat="server" name="Card" maxlength="20" />		
		</td>
		<th width="100" >
            时间</th>
		<td colspan="3" >
        
            <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="OperateDate1" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:12px; width:130px;" /></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="OperateDate2" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:130px;"/></div>
            
            </td>
	  </tr>
	   <tr>
             <th width="100">
                        交易类型</th>
                    <td colspan="5">
                        <select id="typename" runat="server" style="width: 103px">
                        </select>
                    </td>
                </tr>
	    <tr>  
            <td align="right" colspan="6" style="height: 18px">
                实际发生金额汇总:<asp:Label ID="Label2" runat="server">0.00</asp:Label>
                &nbsp; &nbsp; 交易金额汇总:<asp:Label ID="Label3" runat="server">0.00</asp:Label>
                &nbsp;&nbsp; &nbsp;&nbsp;
	        <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server" onclick="if(!checkdate('OperateDate1','OperateDate2'))  return false;" onserverclick="Button3_ServerClick" />		
           <asp:Button ID="btnOut" runat="server" Text="导出" class="btn003" OnClick="btnOut_Click1" />&nbsp;&nbsp;
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>充值记录信息</strong></div>
    <asp:GridView Width="100%" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("transNo") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="28px" />
            </asp:TemplateField>
            <asp:BoundField DataField="transNo" HeaderText="流水号" />
            <asp:BoundField DataField="typename" HeaderText="操作类型" />
            <asp:BoundField DataField="Card" HeaderText="卡号" />
             <asp:BoundField DataField="RealName" HeaderText="会员姓名" />
            <asp:BoundField DataField="remainMoney" HeaderText="充值前余额" />
            <asp:BoundField DataField="chargeRate" HeaderText="充值时比率" />
            <asp:BoundField DataField="ActualCost" HeaderText="实际发生金额" />
            <asp:BoundField DataField="ChargeAmount" HeaderText="交易金额" />
            <asp:BoundField DataField="finallyCost" HeaderText="充值后金额" />
            <asp:BoundField DataField="transTypeName" HeaderText="付款方式" />
            <asp:BoundField DataField="OperateDate" HeaderText="充值时间" />
                     <asp:TemplateField ShowHeader="False" HeaderText="充值撤销">
                        <ControlStyle Width="55px" />
                        <ItemTemplate>
                            &nbsp;&nbsp; <a href="javascript:void(0)" onclick="Delpayment('<%# Eval("transNo")%>','<%# Eval("ActualCost")%>','<%# Eval("Card")%>')">
                                <%# Eval("typename").ToString().Trim()  != "撤销充值" ? "<img style=border:0; alt=充值撤销 src=../images/pic12.gif id=Img1 runat=server />":""%>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
        </Columns>
    </asp:GridView>	
     <asp:Panel ID="delPanel" runat="server" Width="352px" Height="16px">
           <input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)" /><label
                for="checkitall">全选</label>
                 <input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)" /><label
                for="chkChouse">反选</label>
            <span class="btngrey">
                <asp:Button ID="btnDelete" runat="server" Text="删除所选" class="icondel"
                    OnClientClick="return confirm('确定要删除选定项吗？');" 
               onclick="btnDelete_Click" CssClass="btn004" Width="70px" /></span>
    </asp:Panel>

</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.TransLogHelperBLL" OldValuesParameterFormatString="">
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
