<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberOperation.aspx.cs" Inherits="Member_MemberOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>会员管理操作</title>
   <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
     <script type="text/javascript" src="../js/json.js"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
    <script type="text/javascript">
	function CloseWin(msg)
    {
    alert(msg);
    window.setTimeout('document.all("btnclose").click();parent.location.href="MemberList.aspx";',1*1000);
    }
    function startSms()
    {
        if(document.all('CellPhone').value!="")
        {
            document.all('cbIsSms').checked = true;
        }
        else
        { 
            document.all('cbIsSms').checked = false;
        }
    }
    </script>
</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
<form id="form1" runat="server">
<a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>基本信息</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px" >
	  <tr> 
		<th style="height: 18px" ><label style="color:Red; height:18px;">
            <span style="color: #1e3739;">会员编号</span><label style="color:Red; height:18px;">*</label></label></th>
		<td style="height: 18px" >
		  <input type="text" class="inputblue" id="Userid" style="width:100px" runat="server" maxlength="20" vdisp="会员编号" vmode="not null" name="Userid" /></td>
		<th style="height: 18px;" >
           
            姓名<label style="color:Red; height:18px;">*</label></th>
		<td style="height: 18px" >
            <input type="text" class="inputblue" id="RealName" style="width:100px" runat="server" maxlength="10" vdisp="姓名" vmode="not null" name="RealName" /></td>
	  </tr>
        <tr>
            <th style="height: 18px">
                <span style="color: #1e3739">卡片类型&nbsp;</span></th>
            <td style="height: 18px">
		  <input type="text" class="inputblue" id="TypeName" style="width:100px" runat="server" 
                    maxlength="20"  name="TypeName" 
                    readonly="readonly" /></td>
            <th style="height: 18px">
            性别&nbsp;</th>
            <td style="height: 18px">
            <select id="gender" runat="server" class="inputblue" name="gender" style="width: 100px">
                <option selected="selected" value="1">男</option>
                <option value="0">女</option>
            </select>
            </td>
        </tr>
        <tr>
            <th style="height: 18px">
                手机 
            </th>
            <td style="height: 18px">
                <input type="text" class="inputblue" id="CellPhone" style="width:100px" runat="server" maxlength="11" vdisp="手机"  vtype="mobiletel"  name="CellPhone"  onkeyup="startSms()" /></td>
            <th style="height: 18px">
            固话&nbsp;
            </th>
            <td style="height: 18px">
                <input type="text" class="inputblue" id="Telphone" style="width:100px" runat="server" maxlength="15" vdisp="固定电话" vtype="phone"  name="Telphone" /></td>
        </tr>
        <tr style="display:none">
            <th style="height: 18px">
                所在组</th>
            <td style="height: 18px">
                <select id="GroupID" runat="server" class="inputblue" name="GroupID" onchange="OnGroup()"
                    style="width: 100px">
                </select>
            </td>
            <th style="height: 18px">
                销售员</th>
            <td style="height: 18px">
                <select id="SaleMemID" runat="server" class="inputblue" name="SaleMemID" style="width: 100px">
                </select>
            </td>
        </tr>
        <tr>
            <th style="height: 18px">
                QQ&nbsp;</th>
            <td style="height: 18px">
                <input type="text" class="inputblue" id="QQ" style="width:100px" runat="server" maxlength="20" vdisp="QQ" vtype="NumStr"   name="QQ" /></td>
            <th style="height: 18px">
                email&nbsp;
            </th>
            <td style="height: 18px">
                <input type="text" class="inputblue" id="email" style="width:100px" runat="server" maxlength="50" vdisp="email" vtype="email"   name="email" /></td>
        </tr>
        <tr>
            <th style="height: 18px">
                证件类型&nbsp;
            </th>
            <td style="height: 18px">
                <select id="IdType" runat="server" class="inputblue" name="IdType" style="width: 100px">
                <option selected="selected" value="0">身份证</option>
                <option value="1">军官证</option>
                <option value="2">学生证</option>
                <option value="3">护照</option>
                <option value="4">其它</option>
            </select>
            </td>
            <th style="height: 18px">
                生日&nbsp;</th>
            <td style="height: 18px">
                <input type="text" class="inputblue" style="width:100px" id="birthdate"  runat="server" onfocus="setday(this)" vdisp="会员生日" vtype="date" name="birthdate" maxlength="20"/></td>
        </tr>
        <tr>
            <th style="height: 18px">
                证件号码&nbsp;
            </th>
            <td colspan="3" style="height: 18px">
                <input type="text" class="inputblue" id="IdNo" style="width:300px" runat="server" maxlength="25" vdisp="证件号码"  vtype="idcard"   name="IdNo" />
                <input id="CardID" runat="server" class="inputgreen " maxlength="50" name="CardID"
                    style="display: none; width: 148px; height: 21px" type="text" /></td>
        </tr>
        <tr>
            <th>
                地址&nbsp;
            </th>
            <td colspan="3">
            <input type="text" class="inputblue" id="Address" style="width:300px" runat="server" maxlength="150" vdisp="地址" name="Address" /></td>
        </tr>
        <tr>
            <th>
                邮编&nbsp;
            </th>
            <td colspan="3">
                <input id="Zipcode" runat="server" class="inputblue" maxlength="6" name="Zipcode"
                    style="width: 100px" type="text" vdisp="邮政编码" vtype="postcode" />
                &nbsp; &nbsp; &nbsp;
                <input id="cbIsSms" runat="server" type="checkbox" name="cbIsSms" checked="CHECKED" title="开通后,用户将接收平台发送的所有短信" style="display:none;" /></td>
        </tr>
	  <tr> 
		<th style="height: 18px" >
            备注&nbsp;</th>
          <td colspan="3" style="height: 18px">
              <textarea id="memo" runat="server" class="inputblue" maxlength="200" name="memo"
                  style="width: 280px; height: 70px" vdisp="备注" vtextarea="yes"></textarea></td>
	  </tr>	
  </table>
    </div>



<div class="appsection">
  <div class="section_operators" style="width:400px" align="center">
            <input id="chflag" runat="server" type="checkbox" name="chflag" style="display: none" checked="CHECKED" />
	  <input type="button" id="btnInsert" 
                onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" 
                value="提交" class="xybtn" onserverclick="btnInsert_Click" />
	  <input type="button" id="btnUpdate" 
                onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" 
                value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2" style="display:none;"/>
	</div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Member.Model.tb_Member" InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Member.BLL.MemberHelperBLL" UpdateMethod="UpdateObject">
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