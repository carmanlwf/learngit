<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OperatorSchedule.aspx.cs" Inherits="ST_OperatorSchedule" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>操作员签到时间</title>
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

<script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />

<script type="text/javascript">


function doInforEdit(id)
{
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target: "Add_price_Set.aspx?id=" + id
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
    target: "Add_price_Set.aspx"
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
    if (e.name.indexOf('checkitall') == -1) 
        e.checked = form.checkitall.checked; 
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
        .style1
        {
            height: 8px;
        }
    </style>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
<ul class="sitemappath"><li><strong>操作员签到时间</strong></li></ul>
<div class="appsection">
	<table  cellpadding="1" cellspacing="1" class="table_default table_blue"  
        style="width:100%; height: 93px;">
	  <tr> 
		<th class="style1" >
            编 号</th>
		<td class="style1">
            <input type="text" class="inputblue" style="width:130px" id="operatorid" runat="server" maxlength="20" name="operatorid" /></td>
		<th class="style1" >
          姓名</th>
		<td class="style1">
            <input type="text" class="inputblue" style="width:130px" id="name" runat="server" maxlength="20" name="name" /></td>

         </tr>

	   <tr>  
	        <th class="style1">时间</th>
	        <td class="style1">
	        <input type="text" class="inputblue" style="width:130px" id="addtime" runat="server" maxlength="20" name="addtime" onclick="laydate({istime: true, format: 'YYYY-MM-DD '})" /> </td>
            <th class="style1"></th>
            <td align="right" colspan="2">
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>操作员签到、签退时间</strong></div>
     <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" 
        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
    <Columns>
            <asp:TemplateField HeaderText="编号">
                <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# this.GridView1.PageIndex * this.GridView1.PageSize + this.GridView1.Rows.Count + 1%>'/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="操作员编号">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("operatorid")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="姓名">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("name")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="时间">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("addtime")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="终端机号">
                <HeaderStyle />
                <ItemTemplate>
                  <%# Eval("posnum")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="路段">
                <HeaderStyle />
                <ItemTemplate>
                  <%# Eval("sitename")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="操作">
                <HeaderStyle />
                <ItemTemplate>
                  <%#Eval("flag").ToString() == "1" ? "<font color=blue>签退</font>" : "<font color=orange>签到</font>"%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="table_data_title xytact">
		</div>
</div>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    EnablePaging="True" MaximumRowsParameterName="pageSize" 
    OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
    SelectMethod="GetPagedObjects" SortParameterName="sortedBy"
     StartRowIndexParameterName="startIndex" TypeName="Ims.Site.BLL.OperatorScheduleBLL" >
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
