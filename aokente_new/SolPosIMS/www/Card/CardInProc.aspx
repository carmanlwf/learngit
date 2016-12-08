<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardInProc.aspx.cs" Inherits="Card_CardInProc" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
      <title>卡片信息批量导入</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script type="text/javascript">
  function ISAcitve()
  {
      var ui = document.getElementById("Label2");
       if(document.getElementById('Checkbox2').checked)
       {
          ui.style.display="";
//          ISchooJIhuo
document.getElementById("ISchooJIhuo").value="1";
          openBrWindow('ChoolSiteAndRanks.aspx','NewAreaInfo','405','120')  ;
       }
       else
       {
           ui.style.display="none";
           document.getElementById("ISchooJIhuo").value="0";
       }
  }
  function Onloard()
  {
   var ui = document.getElementById("Label2");
   if(document.getElementById("ISchooJIhuo").value=="0")
   {
   ui.style.display="none";
   }
  else
  {
    ui.style.display="";
  }
  }
  function choolesMoney()
  {
   if(document.getElementById("FileUpload1").value==""||document.getElementById("FileUpload1").value==null)
   {
        alert("未选择任何的文件!");
     btnInsertCustomer.Attributes.Add( "onclick ",   "if(!choolesMoney())   return   false; ");
   }
  else
  {
  	var Moneyvalue=document.getElementById('Money');
	var Moneyvalue2 = Moneyvalue.value;
		
    if(Moneyvalue2=="请选择初始金额")
    {
     alert("请选择初始金额");
     btnInsertCustomer.Attributes.Add( "onclick ",   "if(!choolesMoney())   return   false; ");
    }
    else
    {
       return true;
    }
  }
  }
 
 function InSql()
 {
   if(document.getElementById('Checkbox2').checked)
   {
     if(document.getElementById("siteID1").value==""||document.getElementById("RanksID1").value==""||document.getElementById("siteID1").value==null||document.getElementById("RanksID1").value==null)
     {
     alert("选择卡片直接激活，请选择所要激活的分店与会员的等级");
     btnInsertCustomer.Attributes.Add( "onclick ",   "if(!InSql())   return   false; ");
     }
     else
     {
       return true;
     }
   }
   else
   {
       return true;
   }
 }

</script>
<script>
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;" onload="Onloard()">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>批量导入未激活卡片信息</strong></li></ul>
			
<div class="appsection">
	<table width="850" cellpadding="1" cellspacing="1" class="table_default table_blue" >
	  <tr> 
		<th style="height: 1px; width: 64px;" >
            选择文件&nbsp;
        </th>
		<td style="height: 1px;" colspan="5" >
            <asp:FileUpload ID="FileUpload1" runat="server" Width="128px" />
            &nbsp;初始金额:<select id="Money" style="width: 112px" name="Money" runat="server">
                <option selected="selected" value="请选择初始金额">请选择初始金额</option>
                <option value="500">500</option>
                <option value="1000">1000</option>
                <option value="2000">2000</option>
                <option value="5000">5000</option>  
            </select>&nbsp;
            <input id="Checkbox2" type="checkbox" runat="server"  onclick="ISAcitve()"/>直接激活<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="直接激活时全为无名单" Width="120px"></asp:Label><input id="Button2" runat="server" style="width: 64px; height: 20px;" type="button" value="数据预览"   onclick="javascript:if(choolesMoney())"   onserverclick="Button2_ServerClick" />
            &nbsp;<input id="Button1" runat="server" style="width: 64px; height: 20px;" type="button" value="执行导入" onclick="javascript:if(InSql())"   onserverclick="Button1_ServerClick" />&nbsp;
            <a href="javascript:document.all('Button4').click();" target="_self">模版下载</a>&gt;&gt;</td>
	  </tr>
  </table>	
</div>

 
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/>
	
	<strong>卡片信息预览</strong></div>
    <div style="overflow: auto; width:850px;height:350px;" >
            <span class="btngrey">
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    Width="100%" AllowSorting="True" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" PageSize="15" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="序号" HeaderText="序号" />
                        <asp:BoundField DataField="卡面卡号" HeaderText="卡面卡号" />
                        <asp:BoundField DataField="内部卡号" HeaderText="内部卡号" />
                        <asp:BoundField DataField="初始金额" HeaderText="初始金额" />
                        <asp:BoundField DataField="密码" HeaderText="密码" />
                        <asp:BoundField DataField="直接激活" HeaderText="直接激活" />
                        <asp:BoundField DataField="导入日期" HeaderText="导入日期" />
                        <asp:BoundField DataField="导入者" HeaderText="导入者" />
                        
                    </Columns>
                        <PagerTemplate> 
   <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>     
       <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton>    
          <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton>      
           <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>       
           <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton> 
        到第<asp:TextBox runat="server" ID="inPageNum" Width="21px"></asp:TextBox>
        页 <asp:Button ID="Button1" CommandName="go" runat="server" Width="49px" Text="跳转" />  
         <br />  
         </PagerTemplate>   
                     <RowStyle ForeColor="#000066" />
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                     <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                     <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
           
    </div>
                <input id="Button4" runat="server" onserverclick="Button4_ServerClick"  
                type="button" value="下载" style="width:38px; display:none" /><br />
    <input id="siteID1" runat="server" class="inputblue" maxlength="11" name="siteID1"
       style="width: 224px; display :none " type="text" 
       vtype="mobiletel" />
    <input id="ISchooJIhuo" runat="server" class="inputblue" maxlength="11" name="ISchooJIhuo"
       style="width: 224px;display :none  " type="text" 
       vtype="mobiletel" value="0" /><br />
    <input id="RanksID1" runat="server" class="inputblue" maxlength="11" name="RanksID1"
        style="width: 224px; display :none " type="text"  /></form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>
