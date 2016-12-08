<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthCardList.aspx.cs" Inherits="Card_MonthCardList" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员卡信息管理</title>

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

function doViewSites(id)
   {
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"viewSites.aspx?getcode="+id
    });
    $("#isFrameOpt").trigger("click");
   //openBrWindow('SiteOperation.aspx?getcode='+id,'EditSiteInfo','405','350')  ;
}
</script>

<script type="text/javascript">
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

     function onAreaSelectChange()
	{		
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.Site_Code.options.length = 0;
		BindNormalTableToListControl('Site_Code', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
		

	}
    </script>
<style> a:hover{TEXT-DECORATION:underline} </style>
    <script type="text/javascript">
WaitHelper.showWaitMessage();
    </script>

</head>
<body style="width: 98%;"  >
    <form runat="server" id="Form1">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
    <ul class="sitemappath">
        <li><strong>会员基本信息</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%">
            <tr>
                <th>
                    车牌号
                </th>
                <td>
                    <input type="text" class="inputblue" style="width: 120px" id="card" runat="server"
                        name="card" maxlength="30" /></td>
                <th style="width: 97px">
                    姓名
                </th>
                <td>
                    <input type="text" class="inputblue" style="width: 120px" id="RealName" runat="server"
                        name="RealName" maxlength="10" /></td>
                <th>
                     <!-- 账户状态-->
                   会员卡类型
                </th>
                <td>
                    <!--<select class="inputblue" style="width: 100px" id="Status" runat="server" name="Status">
                    </select>-->
                    <select class="inputblue" style="width: 100px" id="TypeID" runat="server" name="TypeID">
                    </select>
                    </td>
                    
                
            </tr>
            <tr>
                <th style="height: 18px">
                    有效期
                </th>
                <td style="height: 18px;">
      
                         <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="uptotime_begin" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:12px; width:153px;" /></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="uptotime_end" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:153px;"/></div>
                        
                        </td>
                <th style="height: 18px; width: 97px;">
                    <asp:Label ID="Label2" runat="server" Text="街道路段"></asp:Label>
                </th>
                <td colspan="3" style="height: 18px">
                    <asp:DropDownList ID="Area_Code" runat="server" Width="120px"  style=" margin-left:20px;"
                            AutoPostBack="True" onselectedindexchanged="Area_Code_SelectedIndexChanged">
                        </asp:DropDownList>
                     <asp:DropDownList ID="Site_Code" runat="server" Width="120px">
                        </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td align="right" colspan="6" style="height: 18px">
                    &nbsp;&nbsp; &nbsp; 
                    <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                        onserverclick="Button3_ServerClick" onclick="if(!doAllMessageBoxValidate(Form1)) return false; if(!checkdate('uptotime_begin','uptotime_end'))  return false;" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>会员账户信息</strong></div>
        <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" PageSize="15"
            Height="45px" DataSourceID="ObjectDataSource1">
            <Columns>
            
            <asp:TemplateField HeaderText="编号">
                        <ItemTemplate>
                            <asp:Label  runat="server" Text='<%# this.GridView1.PageIndex * this.GridView1.PageSize + this.GridView1.Rows.Count + 1%>'/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    
                <asp:TemplateField HeaderText="车牌号">
                <ItemStyle HorizontalAlign="center" />
                    <ItemTemplate>
                        <a href="javascript:void(0)"  onclick="javascript:top.window.ShowCardInfo('<%# Eval("Card") %>');" target="_self"><font color='darkgreen' style="font-weight:bold; font-size:large;"><%# Eval("Card")%></font></a>
                    </ItemTemplate>
                    <ItemStyle />
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
                <asp:BoundField DataField="userid" HeaderText="车主编号" Visible="False" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="RealName" HeaderText="姓名" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TypeName" HeaderText="客户类型" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="账户余额">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("balance") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="label1" runat="server" Text='<%# Bind("balance") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:BoundField DataField="activitytime" HeaderText="创建时间" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                    
                 <asp:TemplateField HeaderText="有效期时间">
                        <ItemTemplate>
                            
                            <%# string.Compare(Eval("Uptotime").ToString(), DateTime.Now.ToString("yyyy-MM-dd 00:00:00")) > 0 ? "<font color=blue>" + Eval("Uptotime") + "</font>" : "<font color=red>" + Eval("Uptotime") + "</font>"%>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center"  Font-Bold="true"/>
                 </asp:TemplateField>
                            
                 <%--<asp:BoundField DataField="Uptotime" HeaderText="有效期时间" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>--%>
                <asp:BoundField DataField="statusname" HeaderText="账户状态" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="操作">
                    <ControlStyle Width="55px" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="doViewSites('<%# Eval("Card")%>')">
                            <span style="color:orange">查看路段</span></a>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Card.BLL.CardHelperBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource> 
    </div>
    </form>
    <script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>
    </body>
</html>
