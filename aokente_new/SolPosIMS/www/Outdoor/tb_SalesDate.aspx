<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tb_SalesDate.aspx.cs" Inherits="Outdoor_tb_SalesDate"  StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>路外停车信息</title>
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
    function Map() {
        $("#isFrameMap").wBox({
            wBoxi: "1", //第一个
            requestType: "iframe",
            target: "../ST/select_map.html"
        });

        $("#isFrameMap").trigger("click");
    }

    function returnmap(lng, lat) {

        for (var i = 0; i < 3; i++) {
            var name = window.frames[i];
            if (name.name == "wBoxIframe") {
                name.returnMap(lng, lat);
            }

        }
    }
    function doInforEdit(id) {
        $("#isFrameOpt").wBox({
            requestType: "iframe",
            target: "In_tb_SalesDate.aspx?id=" + id
        });
        $("#isFrameOpt").trigger("click");
        //openBrWindow('SiteOperation.aspx?getcode='+id,'EditSiteInfo','405','350')  ;
    }
    function doInfornew() {
        $("#isFrameOpt").wBox({
            requestType: "iframe",
            target: "In_tb_SalesDate.aspx"
        });
        $("#isFrameOpt").trigger("click");
        //openBrWindow('SiteOperation.aspx','NewSiteInfo','405','350')  ;
    }
    function managerList(siteid) {
        openBrWindow('../Admin/UserListByAuthority.aspx?type=managerlist&code=' + siteid, 'managerList', '850', '600');
    }
    function addManager(sitecode) {
        openBrWindow('../Admin/AddUserWithAuthority.aspx?type=addmanager&code=' + sitecode, 'addManager', '850', '300');
    }
    
    
    function CheckAll(form) {
        document.getElementById('chkChouse').checked = false;
        for (var i = 0; i < form.elements.length; i++) {
            var e = form.elements[i];
            if (e.name.indexOf('chkChouse') > -1)
                continue;
            if (e.name.indexOf('checkitall') == -1)
                e.checked = form.checkitall.checked;
        }
    }

    function FanCheckAll(form) {
        document.getElementById('checkitall').checked = false;
        for (var i = 0; i < form.elements.length; i++) {
            var e = form.elements[i];
            if (e.name.indexOf('chkChouse') == -1) {
                if (e.name.indexOf('checkitall') == -1) {
                    if (e.checked)
                        e.checked = false;
                    else
                        e.checked = true;
                }
            }
        }
    }
    function CloseWin(msg) {
        if (msg != "")
            alert(msg);
        window.setTimeout('document.all("btnclose").click();parent.location.href="tb_SalesDate.aspx";', 1 * 1000);
    }
</script>
<style type="text/css">
    .gleft{ float:left; width:110px; height:15px; font-size:16px;}
</style>
</head>
<body style="width: 98%;" bgcolor="#999999" >
    <form runat="server" id="form1">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
    <a id="isFrameMap" href="javascript:void(0)" style="display:none">isFrameMap</a>
        <ul class="sitemappath">
            <li><strong>基本信息</strong></li>
        </ul>
        <div class="appsection">
         	<table cellpadding="1" cellspacing="1" class="table_default table_blue"  style="width:100%">
	  <tr> 
		<th >
            停车场名称</th>
		<td >
		 	<input type="text" class="inputblue" style="width:150px" id="rdStopCName"  runat="server" maxlength="20" name="pid" />
		</td>
		<%--<th >
           停车场服务器IP</th>
		<td colspan="3" ><input type="text" class="inputblue" style="width:150px" id="rdParkServerIP"  runat="server" maxlength="20" name="pid" /></td>--%>
	  </tr>
	  <tr> 
	    <td align="right" colspan="4">
	      <input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew()" id="btnNew" runat="server" />
		    <input type="button" name="btnCon" class="btn003" style=" margin-right:50px;"  value="查询"  id="Button3" runat="server" onserverclick="Button3_ServerClick" />
		    </td>
	  </tr>
 

  </table>	
        </div>
<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>车位状态信息</strong></div>
<asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" 
        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="选择" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server"  />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("rdID") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="2%"  />
            </asp:TemplateField>
         <asp:TemplateField HeaderText="停车场名称">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("rdStopCName")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="停车场服务器IP">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("rdParkServerIP")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
          </asp:TemplateField>
               <asp:TemplateField HeaderText="地图位置">
                <HeaderStyle  />
                <ItemTemplate>
                    <div style=" width:110px; ">
                         <span class="gleft"><%# Eval("rdLongitude")%></span> 
                        <span class="gleft"><%# Eval("rdlatitude")%></span> 
                    </div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="车位信息编码">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("rdFier")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="车位信息发布">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("rdDescription")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
          
            
            <asp:TemplateField HeaderText="编辑">
                <ControlStyle />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("rdID")%>')"><span style="color:orange">[编辑]</span></a>
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
     SelectMethod="GetPagedObjects" 
     SortParameterName="sortedBy" 
     StartRowIndexParameterName="startIndex" 
     TypeName="Ims.Job.BLL.RoadDateBLL" >
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


