<%@ Page Language="C#" AutoEventWireup="true" CodeFile="parkSiteinfo.aspx.cs" Inherits="ST_SiteList" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>车位基本信息</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/ST.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>
<script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>
      <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
$(function(){
    //setTimeout('getMagicStatus()', 10000);
    //getMagicStatus();
});
function getMagicStatus()
{
    $.ajax({
    type:"GET",
    url:"../InterFace/FunPages/GetMagicStatus.aspx",
    dataType:"text",
    success:function(data, textStatus, jqXHR){
        //alert("success");
        setTimeout('getMagicStatus()', 1000);
    },
    error:function(xhr, type, exception){
        //alert(xhr.responseText, "Failed");
        //alert(xhr.status);
        //alert("error");
        setTimeout('getMagicStatus()', 1000);
    }
    });
}

function doInforEdit(id)
{
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target: "ParkingSiteOperation.aspx?getcode=" + id
    });
    $("#isFrameOpt").trigger("click");
   //openBrWindow('SiteOperation.aspx?getcode='+id,'EditSiteInfo','405','350')  ;
}
function managerList(siteid)
{
    openBrWindow('../Admin/UserListByAuthority.aspx?type=managerlist&code='+siteid,'managerList','850','600')  ;
}
function addManager(sitecode)
{
    openBrWindow('../Admin/AddUserWithAuthority.aspx?type=addmanager&code='+sitecode,'addManager','850','300')  ;
}
function doInfornew()
{
   $("#isFrameOpt").wBox({
    requestType: "iframe",
    target: "ParkingSiteOperation.aspx"
    });
    $("#isFrameOpt").trigger("click");
    //openBrWindow('SiteOperation.aspx','NewSiteInfo','405','350')  ;
}
function doInforBatchnew() {
    $("#isFrameOpt").wBox({
        requestType: "iframe",
        target: "ParkingSiteBatchOperation.aspx"
    });
    $("#isFrameOpt").trigger("click");
    //openBrWindow('SiteOperation.aspx','NewSiteInfo','405','350')  ;
}
 function CheckAll(form)  {
 document.getElementById('chkChouse').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if(e.name.indexOf('chkChouse')>-1)
    continue;
    if (e.name.indexOf('checkitall')==-1)       e.checked = form.checkitall.checked; 
   }
  }
  
   function FanCheckAll(form)  {
   document.getElementById('checkitall').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if (e.name.indexOf('chkChouse')==-1)
    {    
    if(e.name.indexOf('checkitall')==-1)
    {
    if(e.checked)
    e.checked = false;     
    else   
    e.checked = true;
    }    
    }
   }
  }
</script>
<script>
WaitHelper.showWaitMessage();
</script>
    <style type="text/css">
        .style9
        {
            height: 18px;
        }
    </style>
    
    <script type="text/javascript">
    
        $(document).ready(function() {

            $.ajax({
                type: "GET",
                url: "",
                data: { username: $("#username").val(), content: $("#content").val() },
                dataType: "json",
                success: function(data) {
                   alert(data)
                }
            });
        });
    
    </script>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
<ul class="sitemappath"><li><strong>车位基本信息</strong></li></ul>
<div class="appsection">
	<table  cellpadding="1" cellspacing="1" class="table_default table_blue"  
        style="width:100%; height: 93px;">
	  <tr> 
		<th >
            所属路段</th>
		<td >
		    <asp:DropDownList ID="Area_Code" runat="server" Width="130px"  style=" margin-left:20px;"
                            AutoPostBack="True" 
                onselectedindexchanged="Area_Code_SelectedIndexChanged" Height="20px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="Site_Code" runat="server" Width="130px" 
                Height="20px">
                        </asp:DropDownList></td>
		<th >
            车位编号(自定义)</th>
		<td >
            <input type="text" class="inputblue" style="width:130px" id="parkingname"  
                runat="server" maxlength="20" name="parkingname" /></td>
			  <tr>
	    <th class="style9" >
            地磁编号</th>
		<td class="style9" >
                        <input type="text" class="inputblue" style="width:130px" id="magicid"  
                runat="server" maxlength="30" name="magicid" /></td>
		<th class="style9" >
            当前车牌</th>
		<td class="style9" >
                        <input type="text" class="inputblue" style="width:130px" id="parkingcarnum"  
                runat="server" maxlength="15" name="parkingcarnum" /></td> 
	  </tr>
			  <tr>
	    <th class="style9" >
            车位状态</th>
		<td class="style9" >
                        <select id="isbusy" runat="server" name="isbusy" style=" margin-left:20px; width: 130px; height: 20px;"
                >
                        </select></td>
		<th class="style9" >
            添加时间</th>
		<td class="style9" >
                <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="regtime1" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:12px; width:145px;" /></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="regtime2" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:145px;"/></div>
                
                
                </td> 
	  </tr>
	    <tr>  
            <td align="right" colspan="4" class="style9">
                <input type="button" name="btnBatchNew" class="btn003" value="批量新增" 
                    onclick="doInforBatchnew()" id="btnBatchNew" runat="server" />&nbsp;&nbsp;<input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew()" id="btnNew" runat="server" />
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onclick="if(!checkdate('regtime1','regtime2'))  return false;" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>车位管理</strong></div>
    <asp:GridView Width="100%" PageSize="12" ID="GridView1" runat="server" 
        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1" 
        onrowdatabound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("parkingid") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           <asp:TemplateField HeaderText="车位编号">
                <ItemTemplate>
                     <%# Eval("parkingid")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderText="车位名称">
                <HeaderStyle Width="80px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doSeeInfo('<%# Eval("id")%>');"><%# Eval("sitename")%></a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>--%>
            <asp:BoundField DataField="parkingname" HeaderText="自定义编号" >
               <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="areaname" HeaderText="所属区域" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="sitename" HeaderText="所属路段" >
                <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="magicid" HeaderText="地磁编号" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="parkingstatus" HeaderText="车位状态" HtmlEncode="False" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="parkingcarnum" HeaderText="当前车牌" HtmlEncode="False" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:BoundField DataField="parkingtype" HeaderText="车位类型" HtmlEncode="False" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="updatetime" HeaderText="上次更新时间" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="opt_user" HeaderText="操作人员" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="updateway" HeaderText="感应源" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="操作">
                <ControlStyle Width="55px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("parkingid")%>')"><span style="color:orange">[编辑]</span></a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>	
<div class="table_data_title xytact">
			<ul>
					<li><input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)"
                runat="server" /><label for="checkitall">全选</label><em>|</em></li>
					<li><input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)"
                runat="server" /><label for="chkChouse">反选</label><em>|</em></li>
                    <li><asp:Button ID="btnDelete" runat="server"
                Text="批量删除"  OnClientClick="return confirm('确定要删除选定项吗？');" OnClick="btnDelete_Click" 
                            Width="62px" BackColor="Transparent" BorderStyle="None" Height="25px" /></li>
			</ul>
		</div>

</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    EnablePaging="True" MaximumRowsParameterName="pageSize" 
    OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" 
    SelectMethod="GetPagedObjects" SortParameterName="sortedBy" 
    StartRowIndexParameterName="startIndex" TypeName="Ims.Site.BLL.parkingsiteinfoHelper" 
    OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>
