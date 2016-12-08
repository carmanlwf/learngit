<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUserWithChannel.aspx.cs" Inherits="Admin_AddUserWithChannel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>添加带权限的系统用户</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/app.edit.js"></script>
<script src="../js/app.date.js" type="text/javascript" charset ="gb2312"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

<script type="text/javascript">

   function onSelectedDateTime(obj,datetime)
   {
    if ( obj.name == "birthday")
     {
       GetAge(obj);
     }
   }
   function GetAge(obj)
   {
     var e = document.getElementById("birthday");
     var a = document.getElementById("age");
     var mydate = new Date();
     var year = mydate.getFullYear();
     var month = mydate.getMonth() + 1;
     var day = mydate.getDate() ;
     var pyear = parseInt(e.value.substring(0,4));
     var pmonth = parseInt(e.value.substring(5,7));
     var pday = parseInt(e.value.substring(8,10));
     var realage = 0;
     realage = year - pyear;
     if ((month - pmonth) < 0)
     {
         realage = realage - 1;
     }
     if ((month == pmonth) && (day < pday))
     {
             realage = realage - 1;
     }     
     a.value = realage;
     return;
   }
 
</script>

</head>

<body>
<script>
WaitHelper.showWaitMessage();
</script><form id="Form1" runat="server">
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>基本信息</strong></div>
	<table width="845" cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th width="100" style="height: 18px" ><label style="color:Red; height:18px;">
            <span style="color: #333333; background-color: #8cc2dd">
                员工工号</span><label style="color: red;
                height: 18px">*</label></label></th>
		<td width="205" style="height: 18px" >
            <input id="empid" runat="server" class="inputgreen ime_engish" extendname="7位数字"
                maxlength="7" name="empid" onfocusout="SetDefaultValue(this)" style="width: 100px"
                type="text" vdisp="员工工号" voperate="custom" />&nbsp;</td>
		<th style="height: 18px; width: 100px;" >员工编号<label style="color:Red; height:18px;">*</label></th>
		<td width="170" style="height: 18px" >
		  <input type="text" class = "inputgreen  " id="code" style="width:100px;" runat="server" vdisp="员工编号" maxlength="25" vtype="number" vmode="not null" name="code" />
		</td>
		<th width="100" style="height: 18px" >性别<span style="font-size: 12px; color: red">&nbsp; </span>
        </th>
		<td width="170" style="height: 18px; font-size: 12px;">
            <select id="gender" runat="server" class="inputgreen" name="sex" style="width: 100px">
                <option selected="selected" value="1">男</option>
                <option value="0">女</option>
            </select>
        </td>
	  </tr>
        <tr>
            <th style="height: 18px" width="100">
            姓名<label style="color:Red; height:18px;">*</label></th>
            <td style="height: 18px" width="205">
		  <input type="text" class="inputgreen " id="pname" style="width:100px" runat="server" maxlength="10" vdisp="姓名" vmode="not null" name="pname" /></td>
            <th style="height: 18px; width: 100px;">
                登录密码<label style="color:Red; height:18px;">*</label></th>
            <td style="height: 18px" width="170">
                <input id="pwd" runat="server" class="inputgreen ime_engish" maxlength="25" name="pwd"
                    style="width: 100px" type="password" /></td>
            <th style="height: 18px" width="100">
                所属品牌&nbsp;
            </th>
            <td style="font-size: 12px; height: 18px" width="170"><select id="sort" runat="server" class="inputgreen" name="sort" style="width: 100px">
            </select>
            </td>
        </tr>
	  <tr style="font-size: 12px"> 
		<th >出生日期&nbsp;</th>
		<td >
		  <input name="birthday" id="birthday" type="text" class="inputgreen " style="width:100px" runat="server" onfocus="setday(this)" vtype="date" maxlength="20" />&nbsp;</td>
		<th style="width: 100px" >
            入司时间&nbsp;
        </th>
		<td >
		  <input id="entertime" type="text" class="inputgreen " onfocus="setday(this)" style="width:100px" runat="server" vtype="date" maxlength="20" name="entertime" /></td>
		<th >邮箱地址&nbsp;</th>
		<td >
		  <input id="email" type="text" class="inputgreen " value="@qq.com" style="width:100px" runat="server" vtype="email" maxlength="50"/></td>
	  </tr>
	  <tr> 
		<th width="100" >身份证号&nbsp;</th>
		<td width="205" >
		  <input type="text" runat="server" id="idcar" class="inputgreen" maxlength="18" vtype="idcard" style="width: 100px" /></td> 
		<th style="width: 100px" >
            是否启用&nbsp;</th>
		<td width="205" >
            <input id="chflag" runat="server" name="chflag" type="checkbox" checked="CHECKED" /></td>
		<th width="100" >
            是否经理&nbsp;</th>
		<td width="170" >
            <input id="superflag" runat="server" name="superflag" type="checkbox" /></td>
	  </tr>	
        <tr>
            <th width="100">
                备注&nbsp;
            </th>
            <td colspan="5">
                <input id="memo" runat="server" class="inputgreen" maxlength="200" name="memo" style="width: 470px;
                    height: 50px" type="text" /></td>
        </tr>
  </table>
</div>



<div class="appsection">
  <div class="section_operators" style="width:845px" align="center">
	  <input type="button" id="btnInsert" onclick="if(!doAllMessageBoxValidate(Form1)) return false;" runat="server" value="提交" class="btn003" onserverclick="btnInsert_Click" />&nbsp;
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2" />
	</div>
</div>

</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>

</html>



