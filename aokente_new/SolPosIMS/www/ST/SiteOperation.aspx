<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SiteOperation.aspx.cs" Inherits="ST_SiteOperation" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>路段管理操作</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
     <link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
    <script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
    <script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>
    
    <script language="javascript" type="text/javascript">
        window.onload = function() {
            var val = document.getElementById("IsOpenFence").value;
            if (val == "True") {
                document.getElementById("Isfence").checked = true;
            }
        }
    function doInfornew()
     {
         window.parent.Map();
     }
     function returnMap(Longitude, latitude) {
         $("#Longitude").val(Longitude);
         $("#latitude").val(latitude);
     }
    
    function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);
        window.setTimeout('document.all("btnclose").click();parent.location.href="SiteList.aspx";',1*1000);
    }
    </script>
    <script type="text/javascript" >
        function Checkid(msg) {
            var id = document.getElementById(msg);
            alert(id.getAttribute("vdisp") + ":请输入小数！");  
        } 
    
    function selectMB()
    {
       var a =$("#isBalance").attr("checked");
     if(a==true)
     {
       $("#balance").attr("disabled","");
       
     }else
     {
      $("#balance").attr("disabled","disabled");
     }
  
    }
    </script>
        <style type="text/css">
            .style1
            {
                width: 75px;
                height: 23px;
            }
            .style2
            {
                height: 13px;
            }
            .style3
            {
                width: 75px;
                height: 23px;
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
<a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
<a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>基本信息</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px" >
	  <tr> 
		<th class="style1" ><label style="color:Red; height:18px;">
            <span style="color: #1e3739; ">路段编号</span><label style="color:Red; height:18px;">*</label></label></th>
		<td class="style2" >
		  <input type="text" class="inputblue" id="id" style="width:250px" runat="server" maxlength="20" vdisp="分店编号" vmode="not null" name="id" />&nbsp;</td>
	  </tr>
        <tr>
            <th class="style3">
                <span style="color: #1e3739">
            路段名称</span><label style="color:Red; height:18px;">*</label></th>
            <td class="style4">
                <input type="text" class="inputblue" id="sitename" style="width:250px" 
                    runat="server" maxlength="20" vdisp="分店名称" vmode="not null" name="sitename" /></td>
        </tr>
	  <tr> 
		<th style="width: 75px" >
            所属区域&nbsp;</th>
		<td >
		  <select id="areacode" class="inputblue" style="width:250px" vdisp="所属区域" runat="server" name="areacode" >
	      </select></td>
	  </tr>
        <tr>
            <th style="width: 75px">
                路段类型&nbsp;</th>
            <td>
            <select id="Category" runat="server" class="inputblue" name="Category" style="width: 250px">
            </select>
            </td>
        </tr>
        <tr>
            <th style="width: 75px">
                <span style="color: #1e3739">
            联系人</span><label style="color:Red; height:18px;">*</label></th>
            <td>
                <input type="text" class="inputblue" id="linkman" style="width:250px" 
                    runat="server" maxlength="4" vdisp="联系人" vmode="not null" name="linkman" /></td>
        </tr>
        <tr>
            <th style="width: 75px">
                <span style="color: #1e3739">
            联系电话</span><label style="color:Red; height:18px;">*</label></th>
            <td>
                <input type="text" class="inputblue" id="linkphone" style="width:250px" runat="server" maxlength="15" vdisp="联系电话" vtype="number" vmode="not null" name="linkphone" /></td>
        </tr>
        <tr>
         <th >
             限制距离</th>
	    <td colspan="3"><input type="text" class="inputblue" style="width:250px" id="LimitsFar"  runat="server"  vdisp="限制距离" vtype="float" maxlength="20" /><label style="color:Red; height:18px;">/m</label></td>
		</tr> 

	    <tr>
		 <th >
            经度</th>
	        <td>
	              <input type="text" class="inputblue" style="float:left; width:250px; z-index:1;" id="Longitude" runat="server"  vdisp="经度" vtype="float" maxlength="20" />
	      <div onclick="doInfornew()" style="float:left; margin-top:2px;width:0px; margin-left:-20px; z-index:500;"><b style="float:left; cursor:pointer; background-size:cover;  background:url(../images/us_mk_icon.png) no-repeat 39% 49%; width:20px; height:20px;" ></b> </div>
	        </td>
	    </tr> 
	    <tr>
		 <th >
            纬度</th>
	        <td>
	              <input type="text" class="inputblue" style="float:left;width:250px; z-index:1;" id="latitude"  runat="server" vdisp="纬度" vtype="float" maxlength="20" />
	       <div onclick="doInfornew()" style="float:left; margin-top:2px;width:0px; margin-left:-20px; z-index:500;"><b style="float:left; cursor:pointer; background-size:cover;  background:url(../images/us_mk_icon.png) no-repeat 39% 49%; width:20px; height:20px;" ></b> </div>
	        </td>
	    </tr> 
   	  <tr> 
		<th style="width: 90px" >
            是否开启围栏</th>
          <td colspan="1">
                <input type="checkbox" class="inputblue"  id="Isfence" runat="server"  vdisp="是否开启围栏"  maxlength="20"  />
	           <input type="text" id="IsOpenFence" style=" display:none;"  runat="server" />
	        </td>
	  </tr>	     
	  <tr> 
		<th style="width: 75px" >
            备注&nbsp;</th>
          <td colspan="1">
              <textarea id="note" runat="server" class="inputblue" maxlength="200" name="note"
                  style="width: 250px; height: 50px" vdisp="备注" vtextarea="yes"></textarea> &nbsp; 
              &nbsp; &nbsp; &nbsp; </td>
	  </tr>	  
  </table>

  <div class="section_operators" style="width:400px" align="center">
	  <input id="chflag" runat="server" type="checkbox" style="display: none" />
	  <input type="button" id="btnInsert" 
          onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" 
          value="提交" class="xybtn" onserverclick="btnInsert_Click" />
	  <input type="button" id="btnUpdate" 
          onclick="if(!doAllMessageBoxValidate(form1)) return false;" runat="server" 
          value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
	  <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" id="Button2"  style="display:none;"/>
	</div>
</div>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Site.Model.tb_site" InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Site.BLL.SiteHelperBLL" UpdateMethod="UpdateObject">
        <SelectParameters>
            <asp:Parameter Name="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>
