<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberSendCard.aspx.cs" Inherits="Member_MemberSendCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<%--<head runat="server">
    <title>会员发卡</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
</head>--%>
<head>
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>会员发卡</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src="../lib/jquery/jquery-1.3.2.min.js" charset="gb2312"></script>
	<script language="javascript" type="text/javascript">
		    function CloseWin(msg) {
		        if (msg != "")
		            alert(msg);

		        var index = parent.layer.getFrameIndex(window.name);
		        parent.layer.close(index);       
		        
		    }
    </script>
     <style type="text/css">
         .style1
         {
             height: 18px;
             width: 91px;
         }
         .style2
         {
             width: 91px;
         }
     </style>
</head>
<body >
<script>
WaitHelper.showWaitMessage();
</script>
<form id="form1" runat="server">
<a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
<div class="appsection" >
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>基本信息</strong></div>
  	<div class="apphead">
          <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px" id="TABLE1" runat="server">
              <tr>
                  <th class="style1">
                      <label style="color: red; height: 18px">
                          <span style="color: #1e3739">车主编号</span>*</label></th>
                  <td style="height: 18px">
                      <input id="Userid" runat="server" class="inputblue" maxlength="20" name="Userid"
                          style="width: 280px; background-color: gainsboro;" type="text" 
                          vdisp="车主编号" vmode="not null" readonly="readOnly" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      车主姓名<label style="color: red; height: 18px">*</label></th>
                  <td style="height: 18px">
                      <input id="RealName" runat="server" class="inputblue" maxlength="10" name="RealName"
                          style="width: 280px" type="text" vdisp="姓名" vmode="not null" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      车主性别</th>
                  <td style="height: 18px">
                      <select id="gender" runat="server" class="inputblue" name="gender" 
                          style="width: 280px">
                          <option selected="selected" value="1">男</option>
                          <option value="0">女</option>
                      </select></td>
              </tr>
              <tr>
                  <th class="style1">
                      车牌号<label style="color: red; height: 18px">*</label></th>
                  <td style="height: 18px">
		  <input type="text" class="inputblue" id="Card" style="width:280px" runat="server" 
                          maxlength="20" vdisp="车牌号" vmode="not null" name="Card" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      有效期<label style="color:Red; height:18px;">*</label></th>
                  <td style="height: 18px">
                <input type="text" class="inputblue" style="width:280px" id="Validdate"  
                          runat="server" onfocus="setday(this)" vmode="not null" vdisp="有效日期" 
                          vtype="date" name="Validdate" maxlength="25" value="2030-12-31"/></td>
              </tr>
              <tr>
                  <th class="style1">
                      移动电话</th>
                  <td style="height: 18px">
                      <input id="CellPhone" runat="server" class="inputblue" maxlength="11" name="CellPhone"
                          style="width: 280px" type="text" vdisp="手机"  vtype="mobiletel" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      固定电话</th>
                  <td style="height: 18px">
                      <input id="Telphone" runat="server" class="inputblue" maxlength="15" name="Telphone"
                          style="width: 280px" type="text" vdisp="固定电话" vtype="phone" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      出生年月</th>
                  <td style="height: 18px">
                      <input id="birthdate" runat="server" class="inputblue" maxlength="20" name="birthdate"
                          onfocus="setday(this)" style="width: 280px" type="text" vdisp="会员生日" 
                          vtype="date" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      联系qq</th>
                  <td style="height: 18px">
                      <input id="QQ" runat="server" class="inputblue" maxlength="20" name="QQ" style="width: 280px"
                          type="text" vdisp="QQ" vtype="NumStr" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      电子邮箱</th>
                  <td style="height: 18px">
                      <input id="email" runat="server" class="inputblue" maxlength="50" name="email"
                          style="width: 280px" type="text" vdisp="email" vtype="email" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      证件号码</th>
                  <td style="height: 18px">
                      <select id="IdType" runat="server" class="inputblue" name="IdType" style="width: 80px">
                          <option selected="selected" value="0">身份证</option>
                          <option value="1">军官证</option>
                          <option value="2">学生证</option>
                          <option value="3">护照</option>
                          <option value="4">其它</option>
                      </select><input id="IdNo" runat="server" class="inputblue" maxlength="18" 
                          name="IdNo" style="width: 160px"
                          type="text" vdisp="证件号码" vtype="idcard" /></td>
              </tr>
              <tr>
                  <th class="style2">
                      地 址</th>
                  <td>
                      <input id="Address" runat="server" class="inputblue" maxlength="150" name="Address"
                          style="width: 280px" type="text" vdisp="地址" /></td>
              </tr>
              <tr>
                  <th class="style2">
                      邮 编</th>
                  <td>
                      <input id="Zipcode" runat="server" class="inputblue" maxlength="6" name="Zipcode"
                          style="width: 280px" type="text" vdisp="邮政编码" vtype="postcode" /></td>
              </tr>
              <tr>
                  <th class="style1">
                      备 注</th>
                  <td style="height: 18px">
                      <textarea id="memo" runat="server" class="inputblue" maxlength="200" name="memo" 
                          style="width: 280px; height: 70px" vdisp="备注" vtextarea="yes"></textarea><br />
                  </td>
              </tr>
          </table>
      </div>
</div>



<div class="appsection">
  <div class="section_operators" style="width:400px" align="center">
      <input type="button" id="btnInsert" 
          onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" 
          value="提交" class="xybtn" onserverclick="btnInsert_Click" />&nbsp; 
      </div>
</div>

</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>