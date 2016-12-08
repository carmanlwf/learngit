<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AreaList.aspx.cs" Inherits="ST_AreaList" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>区域基本信息</title>
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

function doInforEdit(id)
{
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"AreaOperation.aspx?getcode="+id
    });
    $("#isFrameOpt").trigger("click");
    //openBrWindow('AreaOperation.aspx?getcode='+id,'EditAreaInfo','405','260')  ;
}
function addAgent(areacode)
{
    openBrWindow('../Admin/AddUserWithAuthority.aspx?type=addagent&code='+areacode,'addAgent','850','300')  ;
}
function agentList(areacode)
{
    openBrWindow('../Admin/UserListByAuthority.aspx?type=agentlist&code='+areacode,'agentList','850','600')  ;
}
function doInfornew()
{
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"AreaOperation.aspx"
    });
    $("#isFrameOpt").trigger("click");
    //openBrWindow('AreaOperation.aspx','NewAreaInfo','405','260')  ;
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
    </head>
<body style="width:98%">
<form runat="server" id="Form1">
<a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
<ul class="sitemappath"><li><strong>区域基本信息</strong></li></ul>
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue"  style="width:100%">
	  <tr> 
		<th >
            区域名称</th>
		<td >
		  <input type="text" class="inputblue" style="width:100px" id="areaname"  runat="server" maxlength="30" name="areaname" />		
		</td>
		<th >
            区域编号</th>
		<td colspan="3" ><input type="text" class="inputblue" style="width:100px" id="areacode"  runat="server" maxlength="20" name="areacode" /></td>
	  </tr>
	  <tr>
	    <th >
            添加时间</th>
	    <td>
	           <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="regtime1" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:12px; width:153px;" /></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="regtime2" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:153px;"/></div>
	    
	    </td>
		  <th >
              </th>
		<td colspan="3">
            &nbsp;</td>
		</tr>
	    <tr>  
            <td align="right" colspan="6">
                &nbsp;&nbsp; &nbsp;<input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew()" id="btnNew" runat="server" />
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onclick="if(!checkdate('regtime1','regtime2'))  return false;" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>停车区域信息</strong></div>
    <asp:GridView Width="100%" PageSize="20" ID="GridView1" runat="server" 
        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("areacode") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           <asp:TemplateField HeaderText="区域编号">
                <ItemTemplate>
                     <%# Eval("areacode")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th" HorizontalAlign="Center"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="区域名称">
                <HeaderStyle Width="80px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doSeeInfo2('<%# Eval("areacode")%>');"><%# Eval("areaname")%></a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="linkman" HeaderText="联系人" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="linkphone" HeaderText="联系电话" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="regtime" HeaderText="添加时间" HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}" >
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="memo" HeaderText="备注信息">
                <HeaderStyle Width="500px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ControlStyle Width="55px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("areacode")%>')"><span style="color:orange">[编辑]</span></a>
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Site.BLL.AreaHelperBLL" OldValuesParameterFormatString="">
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
