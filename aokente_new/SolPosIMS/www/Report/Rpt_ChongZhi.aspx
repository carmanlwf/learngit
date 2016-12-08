<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_ChongZhi.aspx.cs" Inherits="Rpt_ChongZhi" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>会员卡管理</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/CD.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
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
    openBrWindow('CardXiaoKa.aspx?getcode='+Cardid,'ZhuXiaoMemberCard','500','300')  ;
}
function doInforZhuanZhang(Cardid)
{
    openBrWindow('CardZhuanZhang.aspx?getcode='+Cardid,'ZhuZhangMemberCard','455','300')  ;
}
function doInforChongZhi(Cardid)
{
    openBrWindow('ChargeWay.aspx?getcode='+Cardid,'ChongZhiMemberCard','490','350')  ;
}
function doInfornew()
{
    openBrWindow('../Member/MemberSendCard.aspx','NewMemberInfo','850','400')  ;
}
//function ChangePass(Userid)
//{
//    openBrWindow('../Member/MemberSetPass.aspx?getcode='+Userid,'EditMemberInfo','455','230')  ;
//}
function ChangePass(Cardid)
{
    openBrWindow('../Member/MemberSetPass.aspx?getcode='+Cardid,'EditMemberInfo','455','250')  ;
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
<script type="text/javascript">
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>会员卡期限信息</strong></li></ul>
			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%"" >
	  <tr> 
		<th >
            会员卡号</th>
		<td style="width: 275px" >
            <input type="text" class="inputblue" style="width:120px" id="card"  runat="server" name="card" maxlength="30" />&nbsp;
		</td>
		<th >
            会员姓名</th>
		<td colspan="3" >
		  <input type="text" class="inputblue" style="width:120px" id="RealName"  runat="server" name="RealName" maxlength="10" />&nbsp;</td>
	  </tr>
	  <tr>
	    <th style="height: 18px" >
            有效状态</th>
	    <td style="height: 18px; width: 275px;">
            <select id="validDatetuse" runat="server" class="inputblue" style="width: 120px" name="validDatetuse">
            </select>
        </td>
		  <th style="height: 18px" >
              </th>
		<td colspan="3" style="height: 18px">
            </td>
		</tr>
	    <tr>  
            <td align="right" colspan="6" style="height: 18px">
                &nbsp;
                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
	        <input type="button" name="btnCon" class="btn003" value="查询"  id="Button3" runat="server" onserverclick="Button3_ServerClick"  onclick="if(!doAllMessageBoxValidate(Form1)) return false;"/>	
          <asp:Button ID="btnOut" runat="server" Text="导出" class="btn003" OnClick="btnOut_Click" />&nbsp;&nbsp;	
            </td>
	  </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>会员卡期限信息</strong></div>
    <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" PageSize="5" EnableViewState="False">
        <Columns>
           <asp:TemplateField HeaderText="会员卡号">
                <ItemTemplate>
                     <%# Eval("Card")%>
                </ItemTemplate>
                <ItemStyle CssClass="tbody_th"/>
               <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:BoundField DataField="userid" HeaderText="会员编号" Visible="False" />
            <asp:BoundField DataField="RealName" HeaderText="会员姓名" />
            <asp:BoundField DataField="sitename" HeaderText="所属门店" />
            <asp:BoundField DataField="areaname" HeaderText="所在区域" />
            <asp:BoundField DataField="activitytime" HeaderText="卡激活时间" />
            <asp:BoundField DataField="validDate" HeaderText="有效时间" />
            <asp:BoundField DataField="activityway" HeaderText="激活方式" />
            <asp:BoundField DataField="validDatetuse" HeaderText="有效状态" />
        </Columns>
    </asp:GridView>	&nbsp;
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.CardHelperBLL" OldValuesParameterFormatString="">
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
