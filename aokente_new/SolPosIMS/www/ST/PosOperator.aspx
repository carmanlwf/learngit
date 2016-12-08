<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PosOperator.aspx.cs" Inherits="Product_PosOperatorSortOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>添加POS操作员管理</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
        <script type="text/javascript" src="../lib/jquery/jquery-1.3.2.min.js" charset="gb2312"></script>
	<script language="javascript" type="text/javascript">
    function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);
        window.setTimeout('document.all("btnclose").click();parent.location.href="PosOperatorList.aspx";',1*1000);
    }
    </script>
<style type="text/css">
.red {
	color:red;
}
.appsection tbody td input {
	width:280px;
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
    <div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>终端操作员信息</strong></div>
    <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 405px; color: red;" id="TABLE1" runat="server" >
      <tbody>
          <tr>
              <th>
              操作员编号<span class="red">*</span></th>
              <td style="width: 315px">
                  <input type="text" class="inputblue" id="Operatorid"  name="Operatorid" 
                      runat="server" maxlength="10" vdisp="操作员编号" vtype ="NumAndStr" vmode="not null" 
                      style="width: 280px" /></td>
          </tr>
          <tr>
              <th>
                  操作员密码<span style="color: #ff0000">*</span></th>
              <td style="width: 315px">
                  <input type="password" class="inputblue" id="pass"  name="pass" runat="server" maxlength="6" vdisp="密码" vtype ="NumAndStr" vmode="not null" style="width: 280px" /></td>
          </tr>
    <tr>
          <th>
              手机号码<span class="red">*</span></th>
          <td style="width: 315px">
              <input  type="text" class="inputblue" name="Cellphone" id="Cellphone"  runat="server" maxlength="11" vdisp="电话号码" vtype="number"  /></td>
        </tr>
          <tr>
              <th>
                  操作员名称<span class="red">*</span></th>
              <td style="width: 315px">
                  <input  type="text" class="inputblue" id="Name" name="Name"  runat="server" 
                      maxlength="20" vdisp="操作员姓名" vmode="not null" style="width: 280px" /><input 
                  id="cbIsCharge" runat="server" name="cbIsCharge" type="checkbox"  style=" display:none;"/></td>
          </tr>
        
          <tr>
          <th ><label for="Memo">备注：</label>
           </th>
          <td colspan="1" style="width: 315px"><textarea   name="Memo" runat="server" class="inputblue" maxlength="1000"  id="Memo"  type="text" style="width: 280px; height: 70px" vdisp="备注"  vtextarea="yes" ></textarea></td>
        </tr>
          <tr>
              <th>
                  说明：</th>
              <td colspan="1" style="width: 315px; line-height:25px;">
                  ①POS操作员信息用于手持终端的登录验证.<br />
                  ②POS操作员编号建议使用数字依次添加,方便输入.<br />
                  ③POS操作员密码请使用6位数字进行设定,方便输入.<br />
                      </td>
          </tr>
      </tbody>
    </table>
  </div>
  <div class="appsection">
    <div class="section_operators" style="width:400px" align="center">
              <input  type="text" class="inputblue" name="Siteid" id="Siteid"  runat="server" maxlength="20" title="记录分店id_勿删!" style="display: none"/>&nbsp;
      <input type="button" id="btnInsert" 
                  onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" 
                  value="提交" class="xybtn" onserverclick="btnInsert_Click" />
      <input type="button" id="btnUpdate" onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
      <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2" style="display:none;" />&nbsp;
    </div>
      <asp:Label ID="LabePassWord" runat="server" style="display:none;"></asp:Label></div>
  
 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Site.Model.tb_Pos_Operator" InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Site.BLL.PosOperatorHelperBLL" UpdateMethod="UpdateObject">
    <SelectParameters>
      <asp:Parameter Name="Oid" Type="String" />
    </SelectParameters>
  </asp:ObjectDataSource>
  
</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>