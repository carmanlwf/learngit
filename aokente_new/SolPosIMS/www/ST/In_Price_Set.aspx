<%@ Page Language="C#" AutoEventWireup="true" CodeFile="In_Price_Set.aspx.cs" Inherits="ST_In_Price_Set" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>收费标准信息</title>
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
    target: "Add_sitefeelist.aspx?id=" + id
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
    target: "Add_sitefeelist.aspx"
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
<style type="text/css">
    .none{ display:none;}
</style>
<script>
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%">
<form runat="server" id="Form1">
<a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
<ul class="sitemappath"><li><strong>收费标准</strong></li></ul>
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue"  style="width:100%">
	  <tr> 
		<th >
            名称</th>
		<td >
		 <select id="pname" class="inputblue" style="width:150px" vdisp="名称" runat="server" name="areacode" />	
		</td>
		<th >
            编号</th>
		<td colspan="3" ><input type="text" class="inputblue" style="width:150px" id="spid"  runat="server" maxlength="20"/></td>
	  </tr>
	  <tr>
	    <th >
            起步价</th>
	        <td>
	            <input type="text" class="inputblue" style="width:150px" id="minPayment"  runat="server" maxlength="20" />
	        </td>
	      <th >
                所属路段</th>
		    <td >
		    <asp:DropDownList ID="Area_Code" runat="server" Width="130px"  style=" margin-left:20px;"
                            AutoPostBack="True" 
                onselectedindexchanged="Area_Code_SelectedIndexChanged" Height="20px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="Site_Code" runat="server" Width="130px" 
                Height="20px">
                        </asp:DropDownList>&nbsp;</td> 
		</tr>
	    <tr>  
            <td align="right" colspan="6">
                &nbsp;&nbsp; &nbsp;<input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew()" id="btnNew" runat="server" />
	       <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server"   onserverclick="Button3_ServerClick" />
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>收费标准信息</strong></div>
    <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" 
        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="选择" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server"  />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("spid") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="2%"  />
            </asp:TemplateField>
  
            <asp:TemplateField HeaderText="名称">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("pname")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="路段名称">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("Sitename")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="起步价">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("MinPayment")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="超时加收/元">
                <HeaderStyle />
                <ItemTemplate>
                  <%# Eval("NormalChargingPrice")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="起步时间/分">
                <HeaderStyle />
                <ItemTemplate>
                  <%# Eval("FirstChargingTimeSeg")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="最高收费/元">
                <HeaderStyle />
                <ItemTemplate>
                  <%# Eval("MaxPayment")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="上班时间">
                <HeaderStyle  />
                <ItemTemplate>
                 <%# Eval("StartWorkTime")%> 
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="下班时间">
                <HeaderStyle  />
                <ItemTemplate>
              <%# Eval("EndWorkTime")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="备注">
                <HeaderStyle  />
                <ItemTemplate>
               <span title=" <%# Eval("Memo")%>" style=" float:left; width:50px; overflow:hidden;"> <%# Eval("Memo")%></span>  
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="添加时间">
                <HeaderStyle />
                <ItemTemplate>
                  <%# Eval("Addeddate")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="编辑">
                <ControlStyle />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("spid")%>')"><span style="color:orange">[编辑]</span></a>
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
     OnSelecting="ObjectDataSource1_Selecting" 
     SelectCountMethod="GetObjectsCount"
     SelectMethod="GetPagedObjects_pid" 
     SortParameterName="sortedBy" 
     StartRowIndexParameterName="startIndex" 
     TypeName="Ims.Site.BLL.InPriceBLL" >
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
