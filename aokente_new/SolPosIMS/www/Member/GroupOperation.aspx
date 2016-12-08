<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GroupOperation.aspx.cs" Inherits="GroupOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>组管理</title>
<link href="../css/app.newedit.css"rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js"charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js"charset="gb2312"></script>
</head>
<body>
<script>
WaitHelper.showWaitMessage();
</script>
<form id="form1" runat="server">
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>组信息</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 360px" >
	  <tr> 
		<th style="height: 18px; width: 92px;" ><label style="color:Red; height:18px;">
            <span style="color: #1e3739;">编号</span><label style="color:Red; height:18px;">*</label></label></th>
		<td style="height: 18px; width: 259px;" colspan="6" >
		  <label style="color:Red; height:18px;"><span style="color: #1e3739;">
              <input id="GroupID" runat="server" class="inputblue" maxlength="20" name="GroupID" style="width: 250px"
                  type="text" vdisp="编号" vmode="not null" /></span></label></td>
	  </tr>
        <tr>
            <th style="width: 92px; height: 18px">
                组名称<label style="color:Red; height:18px;">*</label></th>
            <td colspan="6" style="height: 18px; width: 259px;">
                <input id="GroupName" runat="server" class="inputblue" maxlength="20" name="GroupName" style="width: 250px"
                    type="text" vdisp="组名称" vmode="not null" /></td>
        </tr>
  </table>
</div>
<div class="appsection">
  <div class="section_operators" style="width:284px" align="center">
	  <input type="button" id="btnInsert" onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" value="提交" class="btn003" onserverclick="btnInsert_Click" />
	  <input type="button" id="btnUpdate" onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" value="提交" class="btn003" onserverclick="btnUpdate_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2" />
	</div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Member.Model.tb_Group" InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Member.BLL.tb_GroupBLL" UpdateMethod="UpdateObject">
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