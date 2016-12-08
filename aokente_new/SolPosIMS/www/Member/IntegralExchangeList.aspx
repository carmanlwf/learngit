<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntegralExchangeList.aspx.cs" Inherits="Member_IntegralExchangeList"  StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>积分兑换记录</title>
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
    <script type="text/javascript">
WaitHelper.showWaitMessage();
    </script>

    <style type="text/css">
        .style1
        {
            width: 365px;
        }
    </style>

</head>
<body style="width: 98%;">
    <form runat="server" id="Form1">
    <ul class="sitemappath">
        <li><strong>积分兑换记录</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%">
            <tr>
                <th width="100">
                    车牌号
                </th>
                <td style="width: 226px">
                    <input type="text" class="inputblue" style="width: 100px" id="card" runat="server"
                        name="card" maxlength="16" />
                </td>
                <th width="100">
                    时间
                </th>
                <td class="style1">
                    <input type="text" class="inputblue" style="width: 130px" id="addeddate1"
                        runat="server" onfocus="setdatetime(this)" vdisp="起始时间" vtype="date" name="addeddate1"
                        maxlength="20" />～<input type="text" class="inputblue" style="width: 130px" id="addeddate2"
                            runat="server" onfocus="setdatetime(this)" vdisp="截止时间" vtype="date" name="addeddate2"
                            maxlength="20" />
                </td>
                                <th width="100">
                                    操作员</th>
                <td>
                    <input type="text" class="inputblue" style="width: 100px" id="operatorid"
                            runat="server" vdisp="操作员" vtype="date" name="operatorid"
                            maxlength="20" /></td>
            </tr>

            <tr>
                <td align="right" colspan="6" style="height: 18px">
                    &nbsp;&nbsp; 
                    <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                        onclick="if(!checkdate('addeddate1','addeddate2'))  return false;" onserverclick="Button3_ServerClick" />
                   
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>积分兑换记录</strong></div>
        <asp:GridView Width="100%" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("transid") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="28px" />
                </asp:TemplateField>
                <asp:BoundField DataField="transid" HeaderText="业务流水号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="card" HeaderText="车牌号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="old_point" HeaderText="原有积分">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="point" HeaderText="兑换积分">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="new_point" HeaderText="剩余积分">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="operatorid" HeaderText="操作员">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="addeddate" HeaderText="操作时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="memo" HeaderText="备注">
                    <ItemStyle HorizontalAlign="Left" />
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
        TypeName="Ims.Member.BLL.card_integralexchangeBLL" OldValuesParameterFormatString="">
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
