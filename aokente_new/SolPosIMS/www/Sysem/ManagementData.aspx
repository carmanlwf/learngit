<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagementData.aspx.cs" Inherits="Sysem_ManagementData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>数据管理</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
           <link rel="stylesheet" href="../css/table.css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
</head>
<script>
    var webSoftPhone = null;
    var nclAgentInfo = null;
    var nclCallData = null;
   
    var nclAgentApp = null;
    
    var noSaveServices = "";
    var servertime = null;
    var userId = "<%=Ims.Main.ImsInfo.CurrentUserId%>";
    var AppPath = "<%=ZsdDotNetLibrary.Web.Server.WebServerHelper.ApplicationPath%>";
    

	//事件

	

    function logout(logoutReason)
    {
        if(typeof(logoutReason) == 'string')
        {
            alert("系统现在需要退出,原因是:" +logoutReason);
        }
         
        isReLogin = true;
        window.location.href = AppPath + "/exit.html?relogin="+isReLogin;
    }
//    
//    function doBeforeUnload()
//    {
//        try
//        {
//        
//            if(noSaveServices != "")
//            {
//                isReLogin = false;
//                event.returnValue = "注意：还有未保存的表单！";
//                return ;
//            }
//            //closeOpenWins();
//            XmlHttpHelper.asynCall("Logout.aspx");
//            if(!isReLogin)
//            {
//                openBrWindow(AppPath + "/exit.html?relogin="+isReLogin,"_blank","width=500,height=300");
//            }
//        }catch(e){}
//    }
//    
//    function BusinessQuery()
//    {
//        var url = 'Biz/BizQuery.aspx?userid='+userId;
//        openBrWindow(url,'BizQueryWin','width=860,height=660,resizable=yes');
//    }
//    function MemberSendCard()
//    {
//        var url = 'Member/MemberSendCard.aspx';
//        openBrWindow(url,'MemberSendCard','width=850,height=500,resizable=yes');
//    }
//    function ProductBuy()
//    {
//        var url = 'Product/Productlist.aspx';
//        openBrWindow(url,'ProductBuy','width=850,height=360,resizable=yes');
//    }
//    function MemberList()
//    {
//        var url = 'Member/MemberList.aspx';
//        openBrWindow(url,'BizQueryWin','width=905,height=800,resizable=yes');
//    }
//    function NoticeBoard()
//    {
//        leftnavframe.nav("../Notice/NoticeBoard.aspx");
//    }
//    
//    function KMBrowse()
//    {
//        leftnavframe.kmbrowse();
////        openBrWindow('KM/QryKm.aspx','_blank','width=1024,height=670,resizable=yes,toolbar=yes');
//    }
//    
//    function setservertime(stime)
//    {
//        if(servertime == null)
//        {
//            window.setInterval("tickservertime()",1*1000);
//        }
//        servertime = Date.instanceFromString(stime);
//        userstatusframe.servertime.innerHTML = stime.substring(11);
//    }
//    
//    function tickservertime()
//    {
//        servertime = servertime.dateAdd("s",1);
//    }    
//    //logHelper.open()
//    logHelper.isShowLog = false;
//    

</script>
<body style="width:98%">
<form id="form1" runat="server">
<div class="appsection">
	<div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>数据库备份</strong></div>
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%";height:1px" >
	  <tr> 
		<th style="width: 88px; text-align: center;" colspan="3" >
            手动备份</th>
		<td style="text-align: left; width: 750px;" colspan="4" >
            <input id="bakName" runat="server" maxlength="30" type="text" />
                &nbsp;
            <input id="Button1" runat="server" onserverclick="Button1_ServerClick" style="width: 70px"
                type="button" value="备份" class="btn2" /></td>
	  </tr>
  </table>
 <div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>记录信息</strong></div>
	</div>
	<div class="apphead">
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    Width="100%" AllowSorting="True" OnSorting ="GridView1_Sorting" 
            AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" 
            OnRowCommand="GridView1_RowCommand" BackColor="Whitesmoke" BorderColor="#3366FF" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" PageSize="20" 
            GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="备份名称" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="size" HeaderText="大小(kb)" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="date" HeaderText="日期" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
<asp:TemplateField HeaderText="备份下载">
<ItemTemplate>
<a href="<%# "../Data/" + Eval("name")%>" target="_blank"><span style=" color:orange"><img src="../images/dl.png" alt="dl" style="border:0;width:15px;height:21px;"/>将该备份文件下载到本地..</span></a>
</ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemStyle Width="50px" />
                <ItemTemplate>
            <asp:LinkButton CommandArgument='<%# Eval("name") %>' ID="LinkButton2" ForeColor="Green" runat="server" OnClientClick="return confirm('确定进行此备份还原？');"  OnCommand="LinkButton2_Command">[还原]</asp:LinkButton>
                   
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemStyle Width="50px" />
                <ItemTemplate>
                    <asp:LinkButton CommandArgument='<%# Eval("name") %>' ForeColor="OrangeRed" ID="LinkButton1" runat="server" OnClientClick="return confirm('确定要删除这一备份吗？');" OnCommand="LinkButton1_Command" >[删除]</asp:LinkButton>
                   
                </ItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                        CommandArgument='<%# Eval("name") %>' ForeColor="OrangeRed" 
                        OnClientClick="return confirm('确定要删除这一备份吗？');" OnCommand="LinkButton1_Command">[删除]</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>
                    </Columns>
                  <PagerTemplate> 
   <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>     
       <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton>    
          <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton>      
           <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>       
           <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton> 
        到第<asp:TextBox runat="server" ID="inPageNum" Width="21px"></asp:TextBox>页 <asp:Button ID="Button1" CommandName="go" runat="server" Width="49px" Text="跳转" />  
         <br />  
         </PagerTemplate>   
           <HeaderStyle BackColor="Silver" Font-Bold="True" ForeColor="White" />
           <RowStyle ForeColor="#000066" />
           <FooterStyle BackColor="White" ForeColor="#000066" />
           <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
           <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
       <input id="Text1" runat="server" style="width:38px; display:none" type="text" />
       </div>
</div>

</form>
</body>
</html>


