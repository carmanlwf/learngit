<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PTracelist_Map.aspx.cs" Inherits="ST_PTracelist_Map" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>围栏警报信息</title>
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

    function Map() 
    {
        $("#isFrameMap").wBox({
            wBoxi: "1", //第一个
            requestType: "iframe",
            target: "select_map.html"
        });

        $("#isFrameMap").trigger("click");
    }

    function returnmap(lng, lat) {

        for (var i = 0; i < 3; i++) 
        {
            var name = window.frames[i];
            if (name.name == "wBoxIframe")
            {
                name.returnMap(lng, lat);
            }

        }
    }

   function doInforEdit(id)
   {
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"SiteOperation.aspx?getcode="+id
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
function doInfornew() {

   $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"SiteOperation.aspx"
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
        .style2
        {
            height: 18px;
            }
        </style>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
<a id="isFrameMap" href="javascript:void(0)" style="display:none">isFrameMap</a>
<ul class="sitemappath"><li><strong>围栏报警信息</strong></li></ul>

<div class="appsection">
	<table  cellpadding="1" cellspacing="1" class="table_default table_blue"  style="width:100%;">
	  <tr> 
		<th >
            操作员名字</th>
		<td >
		  <input type="text" class="inputblue" style="width:100px" id="Name"  runat="server" maxlength="30" />		
		</td>
		<th >
            路段名称</th>
		<td ><input type="text" class="inputblue" style="width:100px" id="Last_sitename"  runat="server" maxlength="20" />&nbsp;</td>
	  </tr>
	  <tr>
	    <th >
            &nbsp;添加时间</th>
	    <td>
	    <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="regtime1" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:12px; width:130px;" /></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="regtime2" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:130px;"/></div>
	    
	    </td>
		  <th class="style2" >
              &nbsp;</th>
		<td class="style2" colspan="3" >
            &nbsp;</td>
		</tr> 

	    <tr>  
            <td align="right" colspan="6">
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onclick="if(!checkdate('regtime1','regtime2'))  return false;" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
           
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>报警信息</strong></div> 
	<asp:GridView Width="100%" PageSize="12" ID="GridView1" runat="server" 
        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1" >
  <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="20px" />
            </asp:TemplateField>
           <asp:TemplateField HeaderText="路段名称">
                <ItemTemplate>
                     <%# Eval("Last_sitename")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="操作员名字" >
                <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Possnr" HeaderText="终端机号" >
                <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Last_sitename" HeaderText="注册时间" HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}" >
                <HeaderStyle Width="100px" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:TemplateField HeaderText="查看位置轨迹" AccessibleHeaderText="oid">
                <ItemTemplate>
                   <a href="../GPS_Info/traceinfo.aspx?opid=<%#Eval("operatorid") %>"><font color="orange">[今日执勤轨迹]</font></a>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center" />
                <HeaderStyle Width="100px" />
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
    StartRowIndexParameterName="startIndex" TypeName="Ims.Site.BLL.AlarmTracelistBLL" 
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
