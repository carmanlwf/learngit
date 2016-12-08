<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tb_Illegal.aspx.cs" Inherits="Outdoor_ta_CarSeatState" StylesheetTheme="app" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>违章状态信息</title>
  <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../css/table.css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/ST.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>

<script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>

<script type="text/javascript">

    function doInforEdit(id) {
        $("#isFrameOpt").wBox({
            requestType: "iframe",
            target: "In_Illegal.aspx?id=" + id
        });
        $("#isFrameOpt").trigger("click");
        //openBrWindow('SiteOperation.aspx?getcode='+id,'EditSiteInfo','405','350')  ;
    }
    
    function doInfornew() {
        $("#isFrameOpt").wBox({
            requestType: "iframe",
            target: "In_Illegal.aspx"
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
</script>
</head>
<body style="width: 98%;" bgcolor="#999999" >
    <form runat="server" id="form1">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
        <ul class="sitemappath">
            <li><strong>违章状态信息</strong></li>
        </ul>
        <div class="appsection">
         	<table cellpadding="1" cellspacing="1" class="table_default table_blue"  style="width:100%">
	  <tr> 
		<th >
            车牌号码</th>
		<td >
		 	<input type="text" class="inputblue" style="width:150px" id="igCarNumber"  runat="server" maxlength="20" name="pid" />
		</td>
		<%--<th >
           停车时间</th>
		<td colspan="3" ></td>--%>
	  </tr>
	  
	   <tr>  
            <td align="right" colspan="6">
             <input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew()" id="btnNew" runat="server" />
           
	       <input type="button" name="btnCon" class="btn003"  style=" margin-right:50px;"  value="查询"  onserverclick="Button3_ServerClick" id="Button3" runat="server"   />
            </td>
	  </tr>

  </table>	
        </div>
<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>基本信息</strong></div>
<asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" 
        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="选择" >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server"  />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("igID") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="2%"  />
            </asp:TemplateField>
         <asp:TemplateField HeaderText="车牌号码">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("igCarNumber")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="照片详情">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("igBodyworkImg")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:TemplateField HeaderText="取证地址">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("igArea")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="拍照时间">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("igCreateTime")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="拍照手持机号">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("igTerminalCard")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="上传交警后台时间间隔">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("igUploadTime")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="交警后台内网IP">
                <HeaderStyle  />
                <ItemTemplate>
                  <%# Eval("igPoliceIP")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            
               <asp:TemplateField HeaderText="编辑">
                <ControlStyle />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("igID")%>')"><span style="color:orange">[编辑]</span></a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>	
<div class="table_data_title xytact">
			<%--<ul>
					<li><input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)"
                runat="server" /><label for="checkitall">全选</label><em>|</em></li>
					<li><input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)"
                runat="server" /><label for="chkChouse">反选</label><em>|</em></li>
                    <li><asp:Button ID="btnDelete" runat="server"
                Text="批量删除"  OnClientClick="return confirm('确定要删除选定项吗？');" OnClick="btnDelete_Click" 
                            Width="62px" BackColor="Transparent" BorderStyle="None" Height="25px" /></li>
			</ul>--%>
		</div>
</div>
   <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    EnablePaging="True" MaximumRowsParameterName="pageSize"
     OnSelecting="ObjectDataSource1_Selecting" 
     SelectCountMethod="GetObjectsCount"
     SelectMethod="GetPagedObjects" 
     SortParameterName="sortedBy" 
     StartRowIndexParameterName="startIndex" 
     TypeName="Ims.Job.BLL.IllegalBLL" >
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
