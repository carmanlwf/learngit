<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardTurnType.aspx.cs" Inherits="Card_CardTurnType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>卡类型转换</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
      <script type="text/javascript" src="../js/app.xmlhttp.js"></script>
 
    <script type="text/javascript">
    function CloseWin(msg)
    {
    alert(msg);
    close();
   
    }
    function GetTypeReard1()
    {
		var typeid=document.getElementById('TypeID1');
		var typeid1 = typeid.value;
        var result =doAjaxCallTools("GetTypeReard",typeid1)
        if(result==""||result==null)
        {
          alert("无此类型卡信息!");
        }
        else
        {
          var parms=result.split(';');
          document.all.Proportion2.innerText=parms[1];
          document.all.ConDiscount2.innerText=parms[0];
          document.all.Recharge2.innerText=parms[2];
          }
    }
    function IsSameType()
    {
       var obj= document.getElementById("TypeID1");
       var objText=obj.value;
      if(objText==document.getElementById("TypeID2").value)
      {
         alert("现两类型为共同卡类型！")
         btnInsertCustomer.Attributes.Add( "onclick ",   "if(!IsSameType())   return   false; ");
      }
      else
      {
        return true;
      }
    }
    
    </script>
    <style type="text/css">
        .style1
        {
            height: 18px;
            width: 98px;
        }
        .style2
        {
            width: 98px;
        }
        .style3
        {
            height: 17px;
            width: 98px;
        }
        .style4
        {
            height: 63px;
            width: 98px;
        }
        .style5
        {
            height: 63px;
        }
        .style6
        {
            height: 18px;
            width: 93px;
        }
        .style7
        {
            height: 18px;
            width: 132px;
        }
    </style>
</head>
<body  onload="GetTypeReard1()">
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 450px">
            <tr>
                <th class="style1">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员卡号&nbsp; </span></label></th>
                 
                <td class="style7">
                    <input id="Card" runat="server" class="inputblue" maxlength="30" name="Card"
                        style="width: 100px" type="text" vdisp="会员卡号" vmode="not null" 
                        readonly="readOnly" disabled="disabled"  />&nbsp;</td>
                <th class="style6">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员姓名&nbsp; </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <input id="RealName" runat="server" class="inputblue" maxlength="10" name="RealName"
                        style="width: 100px" type="text" vdisp="会员姓名" vmode="not null" 
                        readonly="readOnly" disabled="disabled" />&nbsp;</td>
            </tr>
            <tr>
                <th class="style1">
                    当前类型</th>
                <td style="height: 18px" colspan="3">
                    <input id="TypeName" runat="server" class="inputblue" maxlength="30" name="TypeName"
                        style="width: 100px" type="text" vdisp="当前类型" vmode="not null" 
                        readonly="readOnly" disabled="disabled"  /><input id="TypeID2" runat="server" class="inputblue" maxlength="30" name="TypeID2"
                        style="width: 100px; display :none" type="text" vdisp="当前类型" vmode="not null" readonly="readOnly"  /></td>
            </tr>
            <tr>
                <th class="style2">
                    此类型当<br />
                    前消费参数</th>
                <td colspan="3">
                    &nbsp;卡类型折扣:<asp:Label ID="ConDiscount1" runat="server" Text="ConDiscount1"></asp:Label>&nbsp;<br />
                    &nbsp;充值赠送率:<asp:Label ID="Proportion1" runat="server" Text="Proportion1"></asp:Label><br />
                    &nbsp;金额与积分比:<asp:Label ID="Recharge1" runat="server" Text="Recharge1"></asp:Label></td>
            </tr>
            <tr>
                <th class="style3">
                    更换类型</th>
                <td style="height: 17px" colspan="3">
                    <select id="TypeID1" runat="server" class="inputblue" name="TypeID1" 
                        onchange="GetTypeReard1()"  style="width: 100px" >
                    </select></td>
            </tr>
            <tr>
                <th class="style1">
                    更换型当<br />
                    前消费参数</th>
                <td colspan="3" style="height: 18px">
                    &nbsp;卡类型折扣:<asp:Label ID="ConDiscount2" runat="server" Text="ConDiscount2"></asp:Label><br />
                    &nbsp;充值赠送率:<asp:Label ID="Proportion2" runat="server" Text="Proportion2"></asp:Label><br />
                    &nbsp;金额与积分比:<asp:Label ID="Recharge2" runat="server" Text="Recharge2"></asp:Label></td>
            </tr>
            <tr>
                <th class="style4">
                    提示&nbsp;</th>
                <td colspan="3" style="color: #000000;" class="style5">
                    <span style="color: red">
                    <br />
&nbsp;在进行更新卡类型后，此卡消费以及充值，积分将会按照新的类型计算,请慎重更换!<br />
                    </span></td>
            </tr>
        </table>
    
    </div>
    <div align="center" class="section_operators" style="width: 446px; color: #000000;">
        <input id="btnJieGua" runat="server" class="btn001" name="btnJieGua" onclick="javascript:if(!doAllMessageBoxValidate(form1)) return false;if(IsSameType())"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="更 换" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
             style="height: 19px" type="button" value="取 消" />&nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>

