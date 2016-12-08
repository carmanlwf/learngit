<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParkingSiteBatchOperation.aspx.cs" Inherits="ST_ParkingSiteBatchOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>批量新增车位</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script language="javascript" type="text/javascript">
    function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);
    window.setTimeout('document.all("btnclose").click();parent.location.href="parkSiteinfo.aspx";', 1 * 1000);
}

function btnTiJiao_click() {
//    var cp = document.getElementById("preNum").value;

//    if (cp.trim() == "") {
//        alert("车位编号前缀不能为空！");
//        return false;
//    }

    var parkingid = document.getElementById("parkingid").value;
    if(parkingid.trim()==""){
        alert("起始序号不能为空！");
        return false;
    }

    var parksiteCount = document.getElementById("parksiteCount").value;
    if (parksiteCount.trim() == "") {
        alert("车位个数不能为空！");
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
<body >
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
		<th class="style4" >车位编号前缀</th>
		<td class="style2" >
		  <input type="text" class="inputblue" id="preNum" style="width:250px" 
                runat="server" maxlength="20" vdisp="车位编号"  vtype="NumAndStr"
                name="parkingid0" /></td>
	  </tr>
	  <tr> 
		<th class="style4" >
            <label style="color:Red; height:18px;">
            <span style="color: #1e3739; ">起始序号</span>*</label></th>
		<td class="style2" >
		  <input type="text" class="inputblue" id="parkingid" style="width:250px" 
                runat="server" maxlength="20" vdisp="起始序号" vmode="not null" vtype="NumStr" name="parkingid" />&nbsp;</td>
	  </tr>
        <tr>
            <th class="style4">
                车位个数<label style="color:Red; height:18px;">*</label></th>
            <td class="style4">
                <input type="text" class="inputblue" id="parksiteCount" style="width:250px" 
                    runat="server" maxlength="3" vdisp="车位个数(自定义)" vmode="not null"  vtype="int"
                    name="parksiteCount" /></td>
        </tr>
	  <tr> 
		<th >
            所属区域&nbsp;</th>
		<td >
<asp:DropDownList ID="Area_Code" runat="server" Width="250px"  AutoPostBack="True"   
                style=" margin-left:20px;" onselectedindexchanged="Area_Code_SelectedIndexChanged"
                >
                        </asp:DropDownList>
                        </td>
	  </tr>
        <tr>
            <th>
                所属路段&nbsp;</th>
            <td>
                        <asp:DropDownList ID="Site_Code" runat="server" Width="250px"  
                            style=" margin-left:20px;">
                        </asp:DropDownList>
                        </td>
        </tr>
        </table>
  <div class="section_operators" style="width:500px" align="center">
	  <input id="chflag" runat="server" type="checkbox" style="display: none" />
	  <input type="button" id="btnInsert" 
          onclick="return btnTiJiao_click();" runat="server" 
          value="提交" class="xybtn" onserverclick="btnInsert_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2"  style="display:none;"/></div>
</div>

</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>
