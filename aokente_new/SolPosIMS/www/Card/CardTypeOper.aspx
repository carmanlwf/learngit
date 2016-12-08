<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardTypeOper.aspx.cs" Inherits="Card_CardTypeOper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>卡类型管理</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css"rel="stylesheet" type="text/css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/app.validate.js"charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js"charset="gb2312"></script>

    <script language="javascript" type="text/javascript">
        window.onload = function() {
            CbDayCard_click();
        }
        function CloseWin(msg) {
            if (msg != "")
                alert(msg);
            window.setTimeout('document.all("btnclose").click();parent.location.href="CardTypeList.aspx";', 1 * 1000);
        }
		function btnTiJiao_click() {
            var cp = document.getElementById("TypeName").value;

            if (cp== "") {
                alert("请输入正确的类型名称！");
                return false;
            }

            __doPostBack('btnInsert', '');

            return true;
        }

        function CbDayCard_click() {
            var CbDayCardState = document.getElementById("CbDayCard").checked;
            if (CbDayCardState == true) {
                document.getElementById("countDay").innerHTML = "包含天数";
            } else {
                document.getElementById("countDay").innerHTML = "包含月数";
            }
        }
    </script>

    <style type="text/css">
        .style1
        {
            color: #666666;
        }
    </style>

</head>
<body>
<script>
    WaitHelper.showWaitMessage();
</script>
<form id="form1" runat="server">
<a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>卡类型信息</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 504px" >
	  <tr> <th style="width: 83px; height: 18px">
          &nbsp; 类型编号<label style="color:Red; height:18px;">*</label></th>
          <td class="style1">
              <input id="TypeID" runat="server" class="inputblue" maxlength="20" name="TypeID" style="width: 250px"
                    type="text" vdisp="类型编号" vmode="not null" /></td>
	  </tr>
        <tr>
            <th style="width: 83px; height: 18px">
                &nbsp;类型名称<label style="color:Red; height:18px;">*</label></th>
            <td class="style1">
                <input id="TypeName" runat="server" class="inputblue" maxlength="6" 
                    name="TypeName" style="width: 250px"
                    type="text" vdisp="类型名称" vmode="not null" /></td>
        </tr>
        <tr>
            <th style="width: 83px; height: 18px">
                消费模式</th>
            <td >
                &nbsp;&nbsp;&nbsp;
                <input id="cbMonthlyCard" runat="server" checked="CHECKED" name="cbMonthlyCard" 
                     title="勾选后，该类型将出现在开通月卡界面" type="checkbox" />月卡优惠 <span class="style1">
                (勾选后,该类型将出现在开通月卡界面)</span></td>
        </tr>
        <tr>
            <th style="width: 83px; height: 18px"> <span id="countDay">包含月数</span></th>
            <td >  
                <input id="months" runat="server" class="inputblue" maxlength="3" 
                    name="months" style="width: 250px"
                    type="text" vdisp="包含月数" vtype="string" /></td>
        </tr>
        <tr>
            <th style="width: 83px; height: 18px">
                该卡类型</th>
            <td >
                &nbsp;&nbsp;&nbsp;
                <input id="CbDayCard" runat="server" name="cbDayCard" 
                     title="勾选后,该类型卡为日卡，单位为天" type="checkbox" onclick="javascript:CbDayCard_click();" />是否为多日卡 <span class="style1">
                (勾选后,该类型卡为日卡，单位为天)</span></td>
        </tr>
        
        <tr>
            <th style="width: 83px; height: 18px"> 套餐价格</th>
            <td >  
                <input id="price" runat="server" class="inputblue" maxlength="6" 
                    name="price" style="width: 250px"
                    type="text" vdisp="套餐价格" vtype="integer" /></td>
        </tr>
        <tr>
            <th style="width: 83px; height: 18px">
              备注</th>
            <td >
              <input id="Memo" runat="server" class="inputblue" maxlength="20" name="Memo" style="width: 250px; height: 62px;"
                    type="text" />
              </td>
        </tr>
  </table>
</div>
<div class="appsection">
  <div class="section_operators" style="width:500px" align="center">
	  <input type="button" id="btnInsert" 
          onclick="return btnTiJiao_click();" runat="server" 
          value="提交" class="xybtn" onserverclick="btnInsert_Click" />
	  <input type="button" id="btnUpdate" 
          onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" 
          value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2"  style="display:none;"/>
	</div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Card.Model.tb_CardType" InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Card.BLL.tb_CardTypeBLL" UpdateMethod="UpdateObject">
        <SelectParameters>
            <asp:Parameter Name="TypeId" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</form>
<script>
    WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>