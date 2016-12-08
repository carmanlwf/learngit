<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PosposListOperation.aspx.cs" Inherits="ST_ParkingSiteOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>终端管理操作</title>
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
    window.setTimeout('document.all("btnclose").click();parent.location.href="PosposList.aspx";', 1 * 1000);
    }
    </script>
    <script type="text/javascript" >
    function selectMB()
    {
        var a = $("#femaleonly").attr("checked");
     if(a==true)
     {
         $("#femaleonly").attr("disabled", "");
       
     }else
     {
         $("#femaleonly").attr("disabled", "disabled");
     }
  
    }
    </script>
        <style type="text/css">
            .style2
            {
                height: 13px;
            }
            .style4
            {
                height: 23px;
            }
            </style>
</head>
<body  onload="selectMB()">
<script>
WaitHelper.showWaitMessage();
</script>
<form id="form1"  runat="server">
<input 
                    id="siteid" type="hidden" runat="server" />
<a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>基本信息</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" 
        style="width: 500px" >
	  <tr> 
		<th class="style4" >终端<label style="color:Red; height:18px;"><span style="color: #1e3739; ">编号</span><label style="color:Red; height:18px;">*</label></label></th>
		<td class="style2" >
		  <input type="text" class="inputblue" id="posnum" style="width:250px" 
                runat="server" maxlength="20" vdisp="终端编号" vmode="not null" name="posnum" />&nbsp;</td>
	  </tr>
        <tr>
            <th class="style4">
                设备类型<label style="color:Red; height:18px;">*</label></th>
            <td class="style4">
                <input type="text" class="inputblue" id="postype" style="width:250px" 
                    runat="server" maxlength="8" vdisp="设备类型(自定义)" vmode="not null"  vtype="postype"
                    name="postype" /></td>
        </tr>
         <tr>
            <th class="style4">
                设备型号<label style="color:Red; height:18px;">*</label></th>
            <td class="style4">
                <input type="text" class="inputblue" id="productno" style="width:250px" 
                    runat="server" maxlength="8" vdisp="设备型号(自定义)" vmode="not null"  vtype="productno"
                    name="productno" /></td>
        </tr>
         <tr>
            <th >
            所属路段</th>
		<td >
		    <asp:DropDownList ID="Area_Code" runat="server" Width="100px" style=" margin-left:20px"
                            AutoPostBack="True" onselectedindexchanged="Area_Code_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="Site_Code" runat="server" Width="100px">
                        </asp:DropDownList>&nbsp;</td>
        </tr>
        <tr>
            <th class="style4">
                 管理员姓名<label style="color:Red; height:18px;">*</label></th>
            <td class="style4">
                <input type="text" class="inputblue" id="opt_user" style="width:250px" 
                    runat="server" maxlength="8" vdisp="管理员姓名(自定义)" vmode="not null"  vtype="opt_user"
                    name="opt_user" /></td>
        </tr>
        
        </table>
  <div class="section_operators" style="width:500px" align="center">
	  <input id="chflag" runat="server" type="checkbox" style="display: none" />
	  <input type="button" id="btnInsert" 
         runat="server" 
          value="提交" class="xybtn" onserverclick="btnInsert_Click" />
	  <input type="button" id="btnUpdate" 
           runat="server" 
          value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2"  style="display:none;"/>
	</div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    DataObjectTypeName="Ims.Site.Model.pos_poslist" InsertMethod="InsertObject" 
    SelectMethod="GetObject" TypeName="Ims.Site.BLL.PosposListinfoHelper" 
    UpdateMethod="UpdateObject">
        <SelectParameters>
            <asp:Parameter Name="posnum" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>

