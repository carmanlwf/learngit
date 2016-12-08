<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardAddMoney.aspx.cs" Inherits="Card_CardAddMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>会员充值</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript">
    function CloseWin(msg)
    {
    alert(msg);
    close();
   
    }
     function SetChargeAmount()
    {
 
        var amount = document.getElementById("balance1").value;
        if(amount==""||amount==null)
        {
          alert("充值金额不能为空!");
             document.getElementById("ChargeAmount").value ="0";
        }
        else
        {
           if(isNaN(amount))
           { 
              alert("充值金额为正整数!");
              document.getElementById("ChargeAmount").value ="0";
           }
           else
           {
                   var rate = document.getElementById("DisCrad").value;
                   var result = amount*rate;
                    document.getElementById("ChargeAmount").value =(Number(amount)*(Number(rate)));
                   document.getElementById("balance2").value =(Number( document.getElementById("balance").value)+(Number( document.getElementById("ChargeAmount").value ))+(Number( document.getElementById("balance1").value )));
                    document.getElementById("Bance3").value =(Number(amount)*(1+Number(rate)));
           }
        }

    }
    </script>
</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 450px">
            <tr>
                <th colspan="4" style="height: 18px; text-align: center">
                    <strong>会员充值</strong></th>
            </tr>
            <tr>
                <th style="height: 18px; width: 127px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员卡号 </span></label></th>
                <td style="height: 18px; width: 62px;">
                    <input id="card" runat="server" class="inputgreen " maxlength="37" name="card"
                        style="width: 114px; height: 23px;" type="text" vdisp="会员卡号" vmode="not null" readonly="readOnly" />&nbsp;</td>
                <th style="width: 101px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员姓名 </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <input id="RealName" runat="server" class="inputgreen " maxlength="37" name="RealName"
                        style="width: 114px; height: 23px;" type="text" vdisp="会员姓名" vmode="not null" readonly="readOnly" />&nbsp;</td>
            </tr>
 
            <tr>
                <th style="width: 127px; height: 18px">
                    当前余额</th>
                <td style="width: 62px; height: 18px"><input id="balance" runat="server" class="inputgreen" name="balance" 
                        style="width: 114px; height: 23px;" type="text" readonly="readOnly" /></td>
                <th style="width: 101px; height: 18px">
                    卡类型</th>
                <td style="width: 120px; height: 18px"><input id="TypeName" runat="server" class="inputgreen" name="TypeName" 
                        style="width: 114px; height: 23px;" type="text" readonly="readOnly" /></td>
            </tr>
            <tr>
                <th style="width: 127px; height: 18px">
                    充值金额<label style="color: red; height: 18px">*</label></th>
                <td style="width: 62px; height: 18px">
                    <input id="balance1" runat="server" class="inputgreen" name="balance1" 
                        style="width: 114px; height: 23px;" type="text" vdisp="充值金额"  vtype="double"  vmode="not null" onkeyup="SetChargeAmount()"/></td>
                <th style="width: 101px; height: 18px">
                    当前赠送率</th>
                <td style="width: 120px; height: 18px"><input id="DisCrad" runat="server" class="inputgreen" name="DisCrad" 
                        style="width: 114px; height: 23px;" type="text" vdisp="当前赠送率" readonly="readOnly" /></td>
            </tr>
            <tr>
                <th style="width: 127px; height: 18px">
                    赠送金额</th>
                <td style="width: 62px; height: 18px">
                    <input id="ChargeAmount" runat="server" class="inputgreen" name="ChargeAmount" 
                        style="width: 114px; height: 23px; background-color: buttonface;" type="text" vdisp="充值金额" readonly="readOnly"  /></td>
                <th style="width: 101px; height: 18px">
                    充值后总金额</th>
                <td style="width: 120px; height: 18px"><input id="balance2" runat="server" class="inputgreen" name="balance2" 
                        style="width: 114px; height: 23px; background-color: buttonface;" type="text" vdisp="充值金额" readonly="readOnly"  /></td>
            </tr>
            <tr>
                <th style="width: 127px; height: 18px">
                    充值备注&nbsp;</th>
                <td colspan="3" style="height: 18px">
                    <span style="color: red">
                        <textarea id="Memo" runat="server" class="inputblue" maxlength="500" name="Memo"
                            style="width: 345px; height: 50px" vdisp="备注说明" ></textarea></span><br /><input id="Bance3" runat="server" class="inputgreen" name="Bance3" 
                        style="width: 114px; height: 23px; background-color: buttonface;" type="text" vdisp="充值金额" readonly="readOnly"  /></td>
            </tr>
        </table>
    
    </div>
    <div align="center" class="section_operators" style="width: 450px">
        <input id="btnJieGua" runat="server" class="btn001" name="btnJieGua" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="充 值" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
             style="height: 19px" type="button" value="取 消" />&nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>

