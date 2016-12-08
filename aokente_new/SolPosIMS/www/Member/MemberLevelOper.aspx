<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberLevelOper.aspx.cs" Inherits="Member_MemberLevelOper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>会员等级管理操作</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
</head>

<body>
     <script language="javascript" type="text/javascript">

function myReplace()
{
var name = document.getElementById("Name").value;//名字 
var point = document.getElementById("Point").value;//积分
var scale = document.getElementById("scale").value;//比例
var pattern=/^0\.\d{2}$/;   
if(name==null||name==""||point==null||point==""||scale==null||scale=="")
{
    alert("等级名称,所需积分,会员充值比例任何一个都不能为空!");
    btnInsertCustomer.Attributes.Add( "onclick ",   "if(!myReplace())   return   false; ");
}
else
{
 
  if(isNaN(point))
  {
      alert("所需积分应为正整数");
    btnInsertCustomer.Attributes.Add( "onclick ",   "if(!myReplace())   return   false; ");
  }
   else
   {
   if(!pattern.exec(scale))
     {
       alert("请输入一个小于1的非负小数，并且小数点后保留两位!如:0.00");
        document.getElementById("scale").value="0.00";
        btnInsertCustomer.Attributes.Add( "onclick ",   "if(!myReplace())   return   false; ");
     }
     else
     {
       return true;
     }
   }
}



 
                         
 }
                    
                    
                    

</script>
<script>
WaitHelper.showWaitMessage();
</script>
<form id="form1" runat="server">
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>基本信息</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 351px" >
	  <tr> 
		<th style="height: 18px; width: 75px;" ><label style="color:Red; height:18px;">
            <span style="color: #1e3739;">等级编号</span><label style="color:Red; height:18px;">*</label></label></th>
		<td style="height: 18px" >
		  <input type="text" class="inputblue" id="id" style="width:250px" runat="server" maxlength="20" vdisp="等级编号" vtype="number" vmode="not null" name="id" onkeyup="javascript:this.value = parseInt(this.value)"/>&nbsp;</td>
	  </tr>
        <tr>
            <th style="width: 75px; height: 18px">
                <span style="color: #1e3739">等级名称</span><label style="color: red; height: 18px">*</label></th>
            <td style="height: 18px">
                <input type="text" class="inputblue" id="Name" style="width:250px" runat="server" maxlength="20" vdisp="等级名称" vmode="not null" name="Name" /></td>
        </tr>
        <tr>
            <th style="width: 75px; height: 18px">
                <span style="color: #1e3739">积分比例</span><label style="color:Red; height:18px;">*</label><span style="color: red"></span></th>
            <td style="height: 18px">
                <input type="text" class="inputblue" id="Point" style="width:250px" runat="server" maxlength="5" vdisp="所需积分" vmode="not null" vtype="int" name="Point" /></td>
        </tr>
        <tr>
            <th style="width: 75px">
                充值比例<label style="color:Red; height:18px;">*</label>
            </th>
            <td><input type="text" class="inputblue" id="scale" style="width:250px" runat="server" maxlength="20" vdisp="会员充值比例" vmode="not null" name="scale" /></td>
        </tr>
	  <tr> 
		<th style="width: 75px" >
            描述&nbsp;</th>
          <td colspan="1">
              <textarea id="description" runat="server" class="inputblue" maxlength="200" name="description"
                  style="width: 250px; height: 50px" vdisp="备注" vtextarea="yes"></textarea>
              </td>
	  </tr>	
        <tr>
            <th style="width: 75px">
                说明&nbsp;
            </th>
            <td colspan="1" style="color: red">
                ①积分比例为整数如设置为1,哪么消费1元,则获取1个积分,在会员用积分支付时，比例也是根据这里来设定.<br />
                ②充值比例为两位小数,赠送的金额为充值金额乘以充值比例后得出的结果。如0.12则表示充100元,则送12元,充值的实际金额为112元.<br />
                ③充值比例适用于在线充值以及终端充值,积分比例仅适用于终端消费时产生的积分.</td>
        </tr>
  </table>
</div>



<div class="appsection">
  <div class="section_operators" style="width:350px" align="center">
	<%--  <input type="button" id="btnInsert" onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" value="提交" class="btn003" onserverclick="btnInsert_Click" />
	  <input type="button" id="btnUpdate" onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" value="提交" class="btn003" onserverclick="btnUpdate_Click" />--%>
            <input id="chflag" runat="server" type="checkbox" name="chflag" style="width:30px; display :none" checked="CHECKED" />
	    <input type="button" id="btnInsert" onclick="javascript:if(!doAllMessageBoxValidate(form1)) return false;if(myReplace())"  runat="server" value="提交" class="btn003" onserverclick="btnInsert_Click" />
	  <input type="button" id="btnUpdate" onclick="javascript:if(!doAllMessageBoxValidate(form1)) return false;if(myReplace())"  runat="server" value="提交" class="btn003" onserverclick="btnUpdate_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2" />
	</div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Member.Model.tb_MemberRanks" InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Member.BLL.MemberRanksHelper" UpdateMethod="UpdateObject">
        <SelectParameters>
            <asp:Parameter Name="Userid" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>