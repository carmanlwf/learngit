<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParkingSiteOperation.aspx.cs" Inherits="ST_ParkingSiteOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车位管理操作</title>
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
    window.setTimeout('document.all("btnclose").click();parent.location.href="parkSiteinfo.aspx";', 1 * 1000);
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

 function btnTiJiao_click() {
//     var parkingname = document.getElementById("parkingname").value;

//     if (parkingname.trim() == "") {
//         alert("车位编号不能为空！");
//         return false;
//     }

     var magicid = document.getElementById("magicid").value;
     if (magicid.trim() == "") {
         alert("地磁编号不能为空！");
         return false;
     }



     __doPostBack('btnInsert', '');

     return true;
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
<a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>基本信息</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" 
        style="width: 500px" >
	  <tr> 
		<th class="style4" ><label style="color:Red; height:18px;">
            <span style="color: #1e3739; ">车位编号</span><label style="color:Red; height:18px;">*</label></label></th>
		<td class="style2" >
		  <input type="text" class="inputblue" id="parkingid" style="width:250px" 
                runat="server" maxlength="20" vdisp="车位编号" vmode="not null" name="parkingid" />&nbsp;</td>
	  </tr>
        <tr>
            <th class="style4">
                <span style="color: #1e3739">
            车位编号(自定义)</span><label style="color:Red; height:18px;">*</label></th>
            <td class="style4">
                <input type="text" class="inputblue" id="parkingname" style="width:250px" 
                    runat="server" maxlength="8" vdisp="车位编号(自定义)" vmode="not null"  vtype="NumAndStr"
                    name="parkingname" /></td>
        </tr>
        <tr>
            <th class="style4">
            地磁编号<label style="color:Red; height:18px;"></label></th>
            <td class="style4">
		  <input type="text" class = "inputblue" id="magicid" style="width:250px;" 
                    runat="server" vdisp="地磁编号" maxlength="20"  
                    name="magicid"  /></td>
        </tr>
	   <tr>
            <th class="style4">
            标准车位<label style="color:Red; height:18px;">*</label></th>
            <td  valign="middle" class="style4"> <input  onclick="selectMB()" runat="server" type="checkbox" id="femaleonly"  style=" margin-left:20px;"/>是否为特殊车位<input 
                    id="siteid" type="hidden" runat="server" /></td>
        </tr>
	  <tr> 
		<th >
            所属区域&nbsp;</th>
		<td >
<asp:DropDownList ID="Area_Code" runat="server" Width="250px"  AutoPostBack="True"   style=" margin-left:20px;"
                onselectedindexchanged="Area_Code_SelectedIndexChanged"  >
                        </asp:DropDownList>
                        </td>
	  </tr>
        <tr>
            <th>
                所属路段&nbsp;</th>
            <td>
                        <asp:DropDownList ID="Site_Code" runat="server" Width="250px"  style=" margin-left:20px;">
                        </asp:DropDownList>
                        </td>
        </tr>
        </table>
  <div class="section_operators" style="width:500px" align="center">
	  <input id="chflag" runat="server" type="checkbox" style="display: none" />
	  <input type="button" id="btnInsert" 
          onclick="return btnTiJiao_click();" runat="server" 
          value="提交" class="xybtn" onserverclick="btnInsert_Click" />
	  <input type="button" id="btnUpdate" 
          onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" 
          value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2"  style="display:none;"/>
	</div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    DataObjectTypeName="Ims.Site.Model.park_parkingsite" InsertMethod="InsertObject" 
    SelectMethod="GetObject" TypeName="Ims.Site.BLL.parkingsiteinfoHelper" 
    UpdateMethod="UpdateObject">
        <SelectParameters>
            <asp:Parameter Name="parkingid" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>

