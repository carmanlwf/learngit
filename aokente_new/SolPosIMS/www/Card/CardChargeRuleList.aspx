<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardChargeRuleList.aspx.cs" Inherits="Card_CardChargeRuleList" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>充值规则列表</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="js/CD.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>
    
    <script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
WaitHelper.showWaitMessage();
    </script>

    <script type="text/javascript">
   function onAreaSelectChange()
	{		
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.Site_Code.options.length = 0;
		BindNormalTableToListControl('Site_Code', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
		

	}
   function doInfornew() {
      // openBrWindow('../Card/AddChargeRules.aspx', 'NewChargeRule', '405', '320');
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"AddChargeRules.aspx"
    });
    $("#isFrameOpt").trigger("click");
	}
function doInforEdit(id)
{
    //openBrWindow('CardActiveOpen.aspx?getcode='+id,'EditAreaInfo','405','260')  ;
        $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"SetAmount.aspx?getcode="+id
    });
    $("#isFrameOpt").trigger("click");
}
function CheckAll(form) {
    document.getElementById('chkChouse').checked = false;
    for (var i = 0; i < form.elements.length; i++) {
        var e = form.elements[i];
        if (e.name.indexOf('chkChouse') > -1)
            continue;
        if (e.name.indexOf('checkitall') == -1) e.checked = form.checkitall.checked;
    }
}
function ArrangeAmount(bounsid) {
    //openBrWindow('SetAmount.aspx?getcode=' + bounsid, 'SetAmount', '400', '300');
            $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"SetAmount.aspx?getcode="+bounsid
    });
    $("#isFrameOpt").trigger("click");
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

    <style type="text/css">
        .style1
        {
            width: 77px;
        }
        .style9
        {
            width: 118px;
        }
        .style10
        {
        }
        .style13
        {
        }
        .style18
        {
            width: 332px;
        }
        .style19
        {
            width: 285px;
        }
        .style20
        {
            width: 190px;
        }
        </style>
</head>
<body >
    <form id="form1" runat="server">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
    <ul class="sitemappath">
        <li><strong>规则查看</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue">
            <tr>
               
                <td class="style10" align="right">
                    &nbsp;
                </td>
                 <td class="style13">
                  &nbsp;&nbsp;</td>
                <td class="style20">
                    &nbsp;</td>
                <td class="style18">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
               
                
                <td class="style19">
                    &nbsp;&nbsp;&nbsp;<input id="btnNew" runat="server" class="btn003" 
                        name="btnCon1" onclick="doInfornew()" type="button" value="添加规则" />&nbsp;
                    <input type="button" name="btnCon" class="btn003" value="查询规则" id="Button3" runat="server"
                        onserverclick="Button3_ServerClick"  />
                    </td>
            </tr>
        </table>
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>充值赠送信息<strong></div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" PageSize="12" SkinID="GridView_Blue" Width="100%"
            DataSourceID="ObjectDataSource1">
            <Columns>
               <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("bounsid") %>' Visible="False"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <ControlStyle Width="10px" />
                <HeaderStyle Width="25px" />
            </asp:TemplateField>
                <asp:BoundField DataField="bounsid" HeaderText="编号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="bounsname" HeaderText="规则名称">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="beginAmount" HeaderText="充值最小额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                  <asp:BoundField DataField="endAmount" HeaderText="充值最大额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="actualMoney" HeaderText="起赠金额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="giftMoney" HeaderText="赠送金额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="addeddate" HeaderText="添加时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="operatorid" HeaderText="添加人">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False" >
                <ControlStyle Width="55px" />
                    <ItemTemplate>
                        <a href="javascript:void(0)" onclick="ArrangeAmount('<%# Eval("bounsid")%>')">
                            修改赠送金额>></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
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
        OldValuesParameterFormatString="" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount_ChargeRules"
        SelectMethod="GetPagedObjects_ChargeRules" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Card.BLL.tb_CardActive_HistroyBLL">
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
