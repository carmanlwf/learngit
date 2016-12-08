<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardList.aspx.cs" Inherits="Card_CardList"
    StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账户管理</title>

    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="../css/table.css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/json.js"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>
      <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
function doInforJieGua(Cardid)
{
    openBrWindow('CardJieGua.aspx?getcode='+Cardid,'JieGuaMemberCard','455','300')  ;
}
function doInforGuashi(Cardid)
{
    openBrWindow('CardGuaShi.aspx?getcode='+Cardid,'GuaShiMemberCard','455','300')  ;
}
function doInforBuKa(Cardid)
{
    openBrWindow('CardBuKa.aspx?getcode='+Cardid,'BuKaMemberCard','455','300')  ;
}
function doInforZhuxiao(Cardid)
{
    openBrWindow('CardXiaoKa.aspx?getcode='+Cardid,'ZhuXiaoMemberCard','455','300')  ;
}
function doInforZhuanZhang(Cardid)
{
    openBrWindow('CardZhuanZhang.aspx?getcode='+Cardid,'ZhuZhangMemberCard','455','300')  ;
}
function doInforChongZhi(Cardid)
{
//    openBrWindow('ChargeWay.aspx?getcode='+Cardid,'ChongZhiMemberCard','490','350')  ;
    openBrWindow('CardAddMoney.aspx?getcode='+Cardid,'CardAddMoney','455','300')  ;
}
function doInfornew()
{
    openBrWindow('../Member/MemberSendCard.aspx','NewMemberInfo','405','420')  ;
}
//function ChangePass(Userid)
//{
//    openBrWindow('../Member/MemberSetPass.aspx?getcode='+Userid,'EditMemberInfo','455','230')  ;
//}
function ChangePass(Cardid)
{
    openBrWindow('../Member/MemberSetPass.aspx?getcode='+Cardid,'EditMemberInfo','455','250')  ;
}
function ChangePassCardAddDate(Cardid)
{
  openBrWindow('CardAddDate.aspx?getcode='+Cardid,'CardAddDate','455','300')  ;
}
function ChangeType(Cardid)
{
  openBrWindow('CardTurnType.aspx?getcode='+Cardid,'CardAddDate','455','300')  ;
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
    <ul class="sitemappath">
        <li><strong>账户基本信息</strong></li></ul>
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
                    开户时间
                </th>
                <td style="height: 18px;">
      
                         <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:142px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="addeddate1" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:11px; width:152px;" /></div><span style=" float:left; color:Red; font-size:16px;">～</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:142px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="addeddate2" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:11px; width:152px;"/></div>
                        
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
                    &nbsp;&nbsp; &nbsp; <input type="button" name="btnCon" class="btn003" value="办理开户"
                        onclick="doInfornew()" id="btnNew" runat="server" />
                    <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                        onserverclick="Button3_ServerClick" onclick="if(!doAllMessageBoxValidate(Form1)) return false; if(!checkdate('addeddate1','addeddate2'))  return false;" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>账户信息</strong></div>
        <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" PageSize="15"
            Height="45px" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Card") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
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
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("balance") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:BoundField DataField="giftamount" HeaderText="赠送金额" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="activitytime" HeaderText="创建时间" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="initvalue" HeaderText="初始金额" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="LastSaleTime1" HeaderText="上次消费" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="Uptotime" HeaderText="有效期时间" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="statusname" HeaderText="账户状态" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False" Visible="false">
                    <ControlStyle Width="55px" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="doInforGuashi('<%# Eval("Card")%>')">
                            <span style="color:orange">[挂失]</span></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" Visible="false">
                    <ControlStyle Width="55px" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="doInforJieGua('<%# Eval("Card")%>')">
                            <span style="color:orange">[解挂]</span></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" Visible="false">
                    <ControlStyle Width="55px" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="doInforBuKa('<%# Eval("Card")%>')">
                           <span style="color:orange">[补登]</span></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <ControlStyle Width="55px" />
                    <ItemTemplate >
                        <a href="javascript:void(0)" onclick="doInforZhuxiao('<%# Eval("Card")%>')">
                           <span style="color:orange">[注销]</span></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" Visible="false">
                    <ControlStyle Width="55px" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="doInforChongZhi('<%# Eval("Card")%>')">
                            <span style="color:orange">[充值]</span></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false">
                    <ControlStyle Width="55px" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="ChangePass('<%# Eval("Card")%>')">
                            <span style="color:orange">[改密]</span></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" Visible="false">
                    <ControlStyle Width="55px" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="ChangePassCardAddDate('<%# Eval("Card")%>')">
                            <span style="color:orange">[延期]</span></a>
                    </ItemTemplate>
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
