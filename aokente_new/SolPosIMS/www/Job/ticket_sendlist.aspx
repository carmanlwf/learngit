<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ticket_sendlist.aspx.cs" Inherits="Job_ticket_sendlist" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>票据发放记录</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/table.css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

   <script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>
      <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />
    <script>
        WaitHelper.showWaitMessage();
    </script>

    <style type="text/css">
        .style6
        {
            height: 18px;
        }
    </style>
    <script type="text/javascript">
        function CheckAll(form) {
            document.getElementById('chkChouse').checked = false;
            for (var i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.name.indexOf('chkChouse') > -1)
                    continue;
                if (e.name.indexOf('checkitall') == -1) e.checked = form.checkitall.checked;
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
<body style="width: 98%;"  >
    <form runat="server" id="Form1">
            <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
    <script type="text/javascript">
        function ShowCarPic(id) {
            $("#isFrameOpt").wBox({
                requestType: "iframe",
                target: "showDetail.aspx?getcode=" + id,
            });
            $("#isFrameOpt").trigger("click");  
        }
</script>
        <ul class="sitemappath">
            <li><strong>票据发放</strong></li>
        </ul>
        <div class="appsection">
            <table cellpadding="1" cellspacing="1" class="table_default table_blue" id="TABLE1" runat="server" style="width:100%">
                <tr>
                    <th class="style6">
                        领取人员id</th>
                    <td class="style6">
                        <input type="text" class="inputblue" style="width: 130px" id="receiverid" runat="server"
                            name="receiverid" maxlength="20" /></td>
                    <th class="style6">
                        操作人员</th>
                    <td class="style6">
                        <input type="text" class="inputblue" style="width: 130px" id="agentid" runat="server"
                            name="agentid" maxlength="20" /></td>
                </tr>
   
                <tr>
                    <th class="style6">
                        领取起止时间</th>
                    <td class="style6">
                                  <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="addeddate_begin" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:12px; width:140px;" /></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="addeddate_end" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:140px;"/></div>
                                
                                
                                </td>
                    <th class="style6">
                        流水号</th>
                    <td class="style6">
                        <input type="text" class="inputblue" style="width: 130px" id="tid" runat="server"
                            name="tid" maxlength="50" /></td>
                </tr>
   
                <tr>
                    <td align="right" colspan="4">
                        &nbsp;
                        <input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;"
                            id="Button3" runat="server" onserverclick="Button3_ServerClick" />
               
                    </td>
                </tr>
            </table>
        </div>
        
            <div class="apphead">
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>发放记录</strong></div>
            <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
            DataSourceID="ObjectDataSource1">
            <Columns>
            <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("tid") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="tid" HeaderText="流水号" 
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="amount" HeaderText="领取金额" 
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="receiverid" HeaderText="领取人ID" 
                    >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="receivername" HeaderText="领取人" 
                    >
                    <ItemStyle HorizontalAlign="Center" Width="80px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="addeddate" HeaderText="领取日期">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="agentid" HeaderText="操作人员" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="statename" HeaderText="记录状态" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="memo" HeaderText="备注" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Left"  Width="350px"/>
                </asp:BoundField>
                </Columns>
        </asp:GridView>
                     <div class="table_data_title xytact">
			<ul>
					<li><input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)"
                runat="server" /><label for="checkitall">全选</label><em>|</em></li>
					<li><input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)"
                runat="server" /><label for="chkChouse">反选</label><em>|</em></li>
                    <li><asp:Button ID="btnDelete" runat="server" ForeColor="blue"
                Text="批量作废"  OnClientClick="return confirm('确定要作废选定项吗？');" OnClick="btnNoUse_Click" 
                            Width="62px" BackColor="Transparent" BorderStyle="None" Height="25px" 
                            CssClass="blue" /></li>
                    <li><asp:Button ID="Button1" runat="server" ForeColor="Red"
                Text="批量删除"  OnClientClick="return confirm('确定要删除选定项吗？删除后将无法恢复！');" OnClick="btnDelete_Click" 
                            Width="62px" BackColor="Transparent" BorderStyle="None" Height="25px" /></li>
			</ul>
		</div>
            <div id="SumPan"  runat = "server" style="width: 500px;display:none;"  >
                <span class="btngrey"><asp:Label ID="Label1" runat="server" ForeColor="#C00000" 
                    Text="0.00" Visible="False"></asp:Label>&nbsp; <asp:Label ID="Label4" 
                    runat="server" ForeColor="#C00000" Text="0" Visible="False"></asp:Label>&nbsp;</span></div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ims.Job.BLL.TicketHelperBLL" OldValuesParameterFormatString="">
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
