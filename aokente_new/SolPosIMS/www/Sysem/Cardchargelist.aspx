<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cardchargelist.aspx.cs" Inherits="Sysem_Cardchargelist"
    StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>充值记录信息</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../lib/jquery/jquery-1.3.2.min.js"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>
  <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />
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
        <li><strong>充值记录信息</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%">
            <tr>
                <th width="100">
                    车牌号
                </th>
                <td style="width: 226px">
                    <input type="text" class="inputblue" style="width: 100px" id="Card" runat="server"
                        name="Card" maxlength="20" />
                </td>
                <th width="100">
                    时间
                </th>
                <td class="style1">

                              <div class="inline layinput"  style=" float:left; margin-left:0px; border:1px solid #B8E1F6; width:130px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="OperateDate1" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:12px; width:130px;" /></div><span style=" float:left; color:Red; font-size:16px;">～</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:130px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="OperateDate2" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:130px;"/></div>
                </td>
                                <th width="100">
                                    操作员</th>
                <td>
                    <input type="text" class="inputblue" style="width: 100px" id="operid"
                            runat="server" vdisp="操作员" vtype="date" name="operid"
                            maxlength="20" /></td>
            </tr>

            <tr>
                <td align="right" colspan="6" style="height: 18px">
                    &nbsp;&nbsp; 
                    <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                        onclick="if(!checkdate('OperateDate1','OperateDate2'))  return false;" onserverclick="Button3_ServerClick" /></td>
            </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>充值记录信息</strong></div>
        <asp:GridView Width="100%" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("transId") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="28px" />
                </asp:TemplateField>
                <asp:BoundField DataField="card" HeaderText="车牌号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cardtype" HeaderText="客户类型">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Chargetype" HeaderText="类型" Visible="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="amount" HeaderText="充值金额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="gift" HeaderText="赠送金额" Visible="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="rulename" HeaderText="赠送规则" Visible="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="logtime" HeaderText="充值时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="chargeway" HeaderText="方式">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="operid" HeaderText="操作员">
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
        TypeName="Ims.Card.BLL.CardChargeListBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource><br>
                    <div id="SumPan"  runat = "server" style="width: 500px; display:none;" >
                    交易总额:<asp:Label ID="Label1" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    充值总额:<asp:Label ID="Label2" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    扣款总额:<asp:Label ID="Label3" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    营业总额:<asp:Label ID="Label4" runat="server" ForeColor="#C00000">0.00</asp:Label>&nbsp;&nbsp;
                    &nbsp;&nbsp;</div>
    </form>

    <script>
WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
