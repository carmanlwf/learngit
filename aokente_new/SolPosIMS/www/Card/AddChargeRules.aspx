<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddChargeRules.aspx.cs" Inherits="Card_AddChargeRules" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加充值规则</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
<script type="text/javascript" language ="javascript">
    function checkInput() {
        var num_begin = document.getElementById('txtStartMoney').value;//起始金额
        var num_end = document.getElementById('txtendMoney').value; //结束金额
        var num_actual = document.getElementById('txtMoney').value; //起赠金额
        var num_MaxValue = document.getElementById('hd_MaxChargeValue').value //区间最大值
        var num_MinValue = document.getElementById('hd_MinChargeValue').value //区间最小值
        if (parseFloat(num_end) < parseFloat(num_begin)) {
            alert('结束金额不能小于起始金额!'); 
            return false;//不正常,结束金额不能小于起始金额
        }
        if (parseFloat(num_actual) < parseFloat(num_begin) || parseFloat(num_actual) > parseFloat(num_end)) {
            alert('起赠金额不能不在赠送区间内!');
            return false; //不正常,起赠金额不能不在区间之内
        }
        //alert('0.充值赠送区间设置不能有交叉(与已有区间:' + num_MinValue + '~' + num_MaxValue + ')重合,当前:' + num_begin + '~' + num_end + ',请检查已有记录!');
        if (parseFloat(num_begin) >= parseFloat(num_MinValue) && parseFloat(num_end) <= parseFloat(num_MaxValue) ) {
            alert('1.充值赠送区间设置不能有交叉(与已有区间:' + num_MinValue + '~' + num_MaxValue + ')重合,当前:' + num_begin + '~' + num_end + ',请检查已有记录!');
            return false; //不正常,结束金额不能小于起始金额
        }
        if (parseFloat(num_begin) < parseFloat(num_MinValue) && parseFloat(num_end) > parseFloat(num_MinValue) && parseFloat(num_end) < parseFloat(num_MaxValue)) {
            alert('2.充值赠送区间设置不能有交叉(与已有区间:' + num_MinValue + '~' + num_MaxValue + ')重合,当前:' + num_begin + '~' + num_end + ',请检查已有记录!');
            return false; //不正常,结束金额不能小于起始金额
        }
        if (parseFloat(num_begin) > parseFloat(num_MinValue) && parseFloat(num_begin) < parseFloat(num_MaxValue) && parseFloat(num_end) > parseFloat(num_MaxValue)) {
            alert('3.充值赠送区间设置不能有交叉(与已有区间:' + num_MinValue + '~' + num_MaxValue + ')重合,当前:' + num_begin + '~' + num_end + ',请检查已有记录!');
            return false; //不正常,结束金额不能小于起始金额
        }
        return true;   
    }
    function CloseWin(msg) {
        alert(msg);
        window.setTimeout('document.all("btnclose").click();parent.location.href="CardChargeRuleList.aspx";',1*1000);

    }
    
</script>
    <style type="text/css">
        .style5
        {
            height: 18px;
        }
        .style6
        {
            height: 18px;
            width: 197px;
        }
        .style7
        {
            width: 197px;
        }
    </style>

</head>
<body >
<script>
WaitHelper.showWaitMessage();
</script>
<form id="form1" runat="server">
<a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>基本信息</strong></div>
  	<div class="apphead">
          <table cellpadding="1" cellspacing="1" class="table_default table_blue" 
              style="width: 100%" id="TABLE1" runat="server">
              <tr>
                  <th class="style6">
                      <label style="color: red; height: 18px">
                          <span style="color: #1e3739">规则编号</span></label></th>
                  <td>
                      <asp:Label ID="lbbounsid" runat="server"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <th class="style6">
                      规则名称</th>
                  <td class="style5">
                      <input id="txtName" runat="server" class="inputblue" maxlength="18" 
                          name="txtName" style="width: 285px"
                          type="text" vdisp="规则名称" vmode="not null" /></td>
              </tr>
              <tr>
                  <th class="style7">
                      起始金额</th>
                  <td>
                      <input id="txtStartMoney" runat="server" class="inputblue" maxlength="10" name="txtStartMoney"
                          style="width: 285px" type="text" vdisp="起始金额" vmode="not null" /></td>
              </tr>
              <tr>
                  <th class="style6">
                      截至金额</th>
                  <td class="style5">
                      <input id="txtendMoney" runat="server" class="inputblue" maxlength="10" name="txtendMoney"
                          style="width: 285px" type="text" vdisp="截至金额" vtype="float" 
                          vmode="not null" /></td>
              </tr>
              <tr>
                  <th class="style6">
                      起赠金额</th>
                  <td class="style5">
                      <input id="txtMoney" runat="server" class="inputblue" maxlength="10" name="txtMoney"
                          style="width: 285px" type="text" vdisp="起赠金额" vtype="float" vmode="not null" /></td>
              </tr>
              <tr>
                  <th class="style6">
                      赠送金额</th>
                  <td class="style5">
                      <input id="txtGiftMoney" runat="server" class="inputblue" maxlength="10" name="txtGiftMoney"
                          style="width: 285px" type="text" vdisp="赠送金额" vtype="float" vmode="not null" /></td>
              </tr>
              <tr>
                  <th class="style6">
                      &nbsp;</th>
                  <td class="style5">
                      <input id="hd_MaxChargeValue" runat ="server" type="hidden" />
                      <input id="hd_MinChargeValue" runat ="server" type="hidden" />
                  </td>
              </tr>
              </table>
      </div>
</div>



<div >
  <div style="width:100%; text-align: right;" align="center">
      &nbsp;<input type="button" id="btnInsert" 
          onclick="if(!doAllMessageBoxValidate(form1)||!checkInput()) return false;" 
          runat="server" value="提交" class="xybtn" onserverclick="btnInsert_Click" />&nbsp;
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2"  style="display:none;"/>&nbsp;
      &nbsp;</div>
</div>

</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>
