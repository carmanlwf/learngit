<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardRecord.aspx.cs" Inherits="Card_CardRecord"
    StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车牌变更记录</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
   <link rel="stylesheet" href="../css/table.css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../lib/jquery/jquery-1.3.2.min.js"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>

    <script type="text/javascript">

 function CheckAll(form)  {
 document.getElementById('chkChouse').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if(e.name.indexOf('chkChouse')>-1)
    continue;
    if (e.name.indexOf('checkitall')==-1)   e.checked = form.checkitall.checked; 
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

</head>
<body style="width: 98%;">
    <form runat="server" id="Form1">
    <ul class="sitemappath">
        <li><strong>车牌变更信息</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%">
            <tr>
                <th width="100">
                    车牌号
                </th>
                <td style="width: 226px">
                    <input type="text" class="inputblue" style="width: 100px" id="NewCardId" runat="server"
                        name="NewCardId" maxlength="20" />
                </td>
                <th width="100">
                    时间
                </th>
                <td colspan="3">
                    &nbsp;<input type="text" class="inputblue" style="width: 100px" id="OperateDate1"
                        runat="server" onfocus="setday(this)" vdisp="起始时间" vtype="date" name="OperateDate1"
                        maxlength="20" />～<input type="text" class="inputblue" style="width: 100px" id="OperateDate2"
                            runat="server" onfocus="setday(this)" vdisp="截止时间" vtype="date" name="OperateDate2"
                            maxlength="20" />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="6" style="height: 18px">
                    &nbsp;&nbsp;<asp:Label ID="Label3" runat="server"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp;
                    <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                        onclick="if(!checkdate('OperateDate1','OperateDate2'))  return false;" onserverclick="Button3_ServerClick" />
                    <asp:Button ID="btnOut" runat="server" Text="导出" class="btn003" OnClick="btnOut_Click1" style=" display:none;" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>变更记录信息</strong></div>
        <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NewCardId") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="28px" />
                </asp:TemplateField>
                <asp:BoundField DataField="NewCardId" HeaderText="新车牌号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="OldCardId" HeaderText="旧车牌号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="username" HeaderText="车主姓名">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="balance" HeaderText="账户余额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CardTime" HeaderText="变更时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Card.BLL.Card_RecordBLL" OldValuesParameterFormatString="">
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
