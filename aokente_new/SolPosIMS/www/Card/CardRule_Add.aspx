<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardRule_Add.aspx.cs" Inherits="Card_CardRule_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加充值规则</title>
<link rel="stylesheet" href="../css/table.css" />
<link href="../css/app.newedit.css"rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js"charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js"charset="gb2312"></script>
    <style type="text/css">
        .style1
        {
            height: 18px;
            width: 299px;
        }
        .style2
        {
            height: 18px;
            width: 129px;
        }
        .style3
        {
            height: 59px;
            width: 129px;
        }
        .style4
        {
            height: 59px;
            width: 299px;
        }
        .style5
        {
            color: #999999;
        }
    </style>
    <script type="text/javascript">
	function CloseWin(msg)
    {
    alert(msg);
    window.setTimeout('document.all("btnclose").click();parent.location.href="CardChargeRule.aspx";',1*1000);
    }
    </script>
</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
<form id="form1" runat="server">
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>卡类型信息</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" 
        style="width: 374px; height: 200px;" >
	  <tr> <th class="style2">
          &nbsp; 类型编号<label style="color:Red; height:18px;">*</label></th>
          <td class="style1">
              <input id="ruleid" runat="server" class="inputblue" maxlength="20" 
                  name="ruleid" style="width: 180px"
                    type="text" vdisp="类型编号" vmode="not null" /></td>
	  </tr>
        <tr>
            <th class="style2">
                &nbsp;类型名称<label style="color:Red; height:18px;">*</label></th>
            <td class="style1">
                <input id="rulename" runat="server" class="inputblue" maxlength="20" 
                    name="TypeName" style="width: 180px"
                    type="text" vdisp="类型名称" vmode="not null" /></td>
        </tr>
        <tr><th class="style2">
            充值金额<label style="color:Red; height:18px;">*</label></th>
            <td class="style1">
                <input id="amount" runat="server" class="inputblue" maxlength="6" name="amount" style="width: 39px"
                    type="text" vdisp="消费折扣" vmode="not null"  vtype="int"/>
                (实际充值的金额，临时卡除外)</td>
        </tr>
        <tr>
            <th class="style2">
                赠送金额<label style="color:Red; height:18px;">*</label></th>
            <td class="style1">
                <input id="gift" runat="server" class="inputblue" maxlength="6" name="gift" style="width: 39px"
                    type="text" vdisp="充值赠送率" vmode="not null"  vtype="int"/>
                (满足充值金额后系统赠送的金额)</td>
        </tr>
        <tr><th class="style3">
            备 注：</th>
            <td class="style4"  style="line-height:25px;">
                <span class="style5">
                客户充值时，当充值金额与设定赠送规则一致时，系统将根据规则赠送给客户相应的金额，存储到客户卡账户内，临时卡用户不享受赠送政策</span><br />
            </td>
        </tr>
        </table>
</div>
<div class="appsection">
  <div class="section_operators" style="width:370px" align="center">
	  <input type="button" id="btnInsert" onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" value="提交" class="xybtn" onserverclick="btnInsert_Click" /><input type="button" id="btnUpdate" onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" style="display:none;" onclick="JavaScript:window.close();" id="Button2" />
	</div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="Ims.Card.Model.card_chargerule" InsertMethod="InsertObject" 
        SelectMethod="GetObject" TypeName="Ims.Card.BLL.CardRuleHelperBLL" 
        UpdateMethod="UpdateObject">
        <SelectParameters>
            <asp:Parameter Name="ruleid" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <input id="opeid" type="hidden" runat="server" />

</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>