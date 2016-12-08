<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MagicStatusList.aspx.cs" Inherits="ST_MagicStatusList"  StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>地磁状态信息</title>
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

<script type="text/javascript">


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
function doInfornew()
{
   $("#isFrameOpt").wBox({
    requestType: "iframe",
    target: "ParkingSiteOperation.aspx"
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
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
<ul class="sitemappath"><li><strong>地磁状态信息</strong></li></ul>
<div class="appsection">
	<table  cellpadding="1" cellspacing="1" class="table_default table_blue"  
        style="width:100%; height: 93px;">
	  		  <tr>
	    <th class="style9" >
            MAC地址</th>
		<td class="style9" >
                        <input type="text" class="inputblue" style="width:650px" id="mac"  
                runat="server" maxlength="1000" /></td>
	  </tr>
	    <tr>  
            <td align="right" colspan="2" class="style9">
                &nbsp;&nbsp; &nbsp;
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>地磁状态信息</strong></div>
    <asp:GridView Width="100%" PageSize="50" ID="GridView1" runat="server" 
        SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
           <asp:BoundField DataField="dataId" HeaderText="流水号" >
               <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:BoundField DataField="mac" HeaderText="物理地址(MAC)" >
               <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:TemplateField HeaderText="地磁信息">
                <ItemTemplate>
                     <%# Eval("infor")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="地磁状态">
                <ItemTemplate>
                     <%#Eval("infor").ToString().Substring(Eval("infor").ToString().Length - 6, 2) == "01" ? "<font color=red>警报</font>" : "<font color=green>空闲</font>"%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
            </asp:TemplateField>
            <asp:BoundField DataField="createTime" HeaderText="时间戳" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
           <asp:TemplateField HeaderText="创建时间(格式化)">
                <ItemTemplate>
                     <%# (CommunicationHelperBLL.StampToDateTime(Eval("createTime").ToString().Substring(0,Eval("createTime").ToString().Length-3)).ToString("yyyy-MM-dd HH:mm:ss"))%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
            </asp:TemplateField>
            <asp:BoundField DataField="applicationId" HeaderText="应用编号" HtmlEncode="False" 
                Visible="False" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="applicationName" HeaderText="应用名称"  Visible = "false"
                HtmlEncode="False" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>	
<div class="table_data_title xytact">
			<ul>
					<li><em>|</em></li>
					<li><em>|</em></li>
                    <li></li>
			</ul>
		</div>

</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    EnablePaging="True" MaximumRowsParameterName="pageSize" 
    OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount_MagicStatus" 
    SelectMethod="GetPagedObjects_MagicStatus" SortParameterName="sortedBy" 
    StartRowIndexParameterName="startIndex" TypeName="GetMagicStatusHelper" 
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


