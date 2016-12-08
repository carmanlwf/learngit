<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay_owedetail.aspx.cs" Inherits="Pay_pay_owedetail" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欠费追缴明细</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
     <link rel="stylesheet" href="../css/table.css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/json.js"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>
    <script type="text/javascript">
        function doInforJieGua(Cardid) {
            openBrWindow('CardJieGua.aspx?getcode=' + Cardid, 'JieGuaMemberCard', '455', '300');
        }
        function doInforGuashi(Cardid) {
            openBrWindow('CardGuaShi.aspx?getcode=' + Cardid, 'GuaShiMemberCard', '455', '300');
        }
        function doInforBuKa(Cardid) {
            openBrWindow('CardBuKa.aspx?getcode=' + Cardid, 'BuKaMemberCard', '455', '300');
        }
        function doInforZhuxiao(Cardid) {
            openBrWindow('CardXiaoKa.aspx?getcode=' + Cardid, 'ZhuXiaoMemberCard', '455', '300');
        }
        function doInforZhuanZhang(Cardid) {
            openBrWindow('CardZhuanZhang.aspx?getcode=' + Cardid, 'ZhuZhangMemberCard', '455', '300');
        }
        function doInforChongZhi(Cardid) {
            //    openBrWindow('ChargeWay.aspx?getcode='+Cardid,'ChongZhiMemberCard','490','350')  ;
            openBrWindow('CardAddMoney.aspx?getcode=' + Cardid, 'CardAddMoney', '455', '300');
        }
        function doInfornew() {
            openBrWindow('../Member/MemberSendCard.aspx', 'NewMemberInfo', '405', '420');
        }
        //function ChangePass(Userid)
        //{
        //    openBrWindow('../Member/MemberSetPass.aspx?getcode='+Userid,'EditMemberInfo','455','230')  ;
        //}
        function ChangePass(Cardid) {
            openBrWindow('../Member/MemberSetPass.aspx?getcode=' + Cardid, 'EditMemberInfo', '455', '250');
        }
        function ChangePassCardAddDate(Cardid) {
            openBrWindow('CardAddDate.aspx?getcode=' + Cardid, 'CardAddDate', '455', '300');
        }
        function ChangeType(Cardid) {
            openBrWindow('CardTurnType.aspx?getcode=' + Cardid, 'CardAddDate', '455', '300');
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

        function onAreaSelectChange() {
            var selectArea = document.getElementById('Area_Code');
            var Area = selectArea.value;
            document.all.Site_Code.options.length = 0;
            BindNormalTableToListControl('Site_Code', "id", "sitename", "tb_site", "id", "areacode = '" + Area + "'", "请选择");


        }
    </script>
<style> a:hover{TEXT-DECORATION:underline} </style>
    <script type="text/javascript">
        WaitHelper.showWaitMessage();
    </script>

</head>
<body style="width: 98%;"  >
    <form runat="server" id="Form1">
    <ul class="sitemappath">
        <li><strong>账户基本信息</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%">
            <tr>
                <th>
                    车牌号
                </th>
                <td>
                    <input type="text" class="inputblue" style="width: 120px" id="card" runat="server"
                        name="card" maxlength="30" /></td>
                <th style="width: 97px">
                    姓名
                </th>
                <td>
                    <input type="text" class="inputblue" style="width: 120px" id="RealName" runat="server"
                        name="RealName" maxlength="10" /></td>
                <th>
                    &nbsp;</th>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" colspan="6" style="height: 18px">
                    &nbsp;&nbsp; &nbsp;&nbsp;
                    <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                        onserverclick="Button3_ServerClick" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead">
            <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>账户信息</strong></div>
        <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" PageSize="15"
            Height="45px" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="车牌号">
                <ItemStyle HorizontalAlign="center" />
                    <ItemTemplate>
                        <font color='darkgreen' style="font-weight:bold; font-size:large;"><%# Eval("Card")%></font>
                    </ItemTemplate>
                    <ItemStyle />
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
                <asp:BoundField DataField="userid" HeaderText="车主编号" Visible="False" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="RealName" HeaderText="姓名" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
 <asp:BoundField DataField="cellphone" HeaderText="联系电话" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="欠费金额">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("balance") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
                <asp:BoundField DataField="LastSaleTime1" HeaderText="上次消费" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="查看账单">
                    <ItemTemplate>
                        <a href="../Pay/pay_paydetail.aspx?carnum=<%# Eval("card") %>">查看账单</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <div class="table_data_title xytact">
			<ul>
			</ul>
		</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Card.BLL.CardHelperBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource> 
    </div>
    </form>
    <script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>
    </body>
</html>