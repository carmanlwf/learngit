<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EndCard2.aspx.cs" Inherits="Card_EndCard2" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注销</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript">
        function AlterTextState(flag) {
            if (flag) {
                document.getElementById("ChargeAmount").readOnly = false;
                document.getElementById("ChargeAmount").style.backgroundColor = "white";
            }
            else {
                document.getElementById("ChargeAmount").readOnly = true;
                document.getElementById("ChargeAmount").style.backgroundColor = "gainsboro";
            }
        }
        function SetChargeAmount() {
            var amount = document.getElementById("ActualCost").value;
            var rate = document.getElementById("Recharge").value;
            var result = amount * rate;
            document.getElementById("ChargeAmount").value = (Number(amount) * (1 + Number(rate)));
        }
        function CloseWin(msg) {
            alert(msg);
            self.location = '../Sysem/Cardchargelist.aspx';

        }
    </script>
    <script type="text/javascript">
        function GetCardSectorPass() {

            $.ajax({

                type: 'GET',

                url: '../utility/sectorPass.ashx',

                dataType: 'text',

                data: 'req=pass',

                success: function(msg) {
                    document.all('spass').value = msg.toString();


                },
                error: function(data) {
                    return "FFFFFFFFFFFF";
                }

            })

        }
        
    </script>
    <style type="text/css">
        .style14
        {
            width: 100px;
        }
        .style15
        {
            height: 18px;
            }
        .style16
        {
            height: 18px;
            width: 341px;
        }
        .style17
        {
            width: 341px;
        }
        .style18
        {
            height: 18px;
            width: 341px;
            color: #FF3300;
        }
        .style19
        {
            height: 28px;
        }
    </style>
</head>
<body style=" width:98%">
    <script>
        WaitHelper.showWaitMessage();
    </script>

    <form id="form1" runat="server">
    <ul class="sitemappath">
        <li><strong>新卡退款</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%;
            height: 180px;">
            <tr>
                <th class="style15">
                    会员卡号
                </th>
                <td class="style16">
                    <input id="Card" runat="server" class="inputblue" maxlength="16" name="Card"
                        style="width: 130px" type="text" vdisp="会员卡号" vmode="not null" />
    <input id="btnJieGua0" runat="server" class="btn001" name="btnJieGua0" 
            onserverclick="Button1_Click" type="button" value="读 卡" /></td>
            </tr>
            <tr>
                <th class="style19" colspan="2" style="border: 1px dotted #C0C0C0">
                </th>
            </tr>
            <tr>
                <th class="style15">
                    会员姓名
                </th>
                <td class="style16">
                    <input id="RealName" runat="server" class="inputblue" maxlength="37" name="RealName"
                        style="width: 130px; background-color: ghostwhite; margin-top: 0px;" 
                        type="text" vdisp="会员姓名"
                        vmode="not null" readonly="readOnly" />
                </td>
            </tr>
            <tr>
                <th class="style15">
                    移动电话
                </th>
                <td class="style16">
                    <input id="CellPhone" runat="server" class="inputblue" maxlength="37" name="CellPhone"
                        style="width: 130px; background-color: ghostwhite;" type="text" vdisp="移动电话"
                        readonly="readOnly" />
                </td>
            </tr>
            <tr>
                <th class="style15">
                    卡类型
                </th>
                <td class="style16">
                    <input id="TypeName" runat="server" class="inputblue" maxlength="37" name="TypeName"
                        style="width: 130px; background-color: ghostwhite;" type="text" 
                        vdisp="卡类型" readonly="readOnly" />
                </td>
            </tr>
            <tr>
                <th class="style15">
                    办卡日期
                </th>
                <td class="style16">
                    <input id="activitytime" runat="server" class="inputblue" maxlength="37" name="activitytime"
                        style="width: 130px; background-color: ghostwhite;" type="text" vdisp="办卡日期"
                        readonly="readOnly" />
                </td>
            </tr>
            <tr>
                <th class="style15">
                    有效日期
                </th>
                <td class="style16">
                    <input id="ValidDate" runat="server" class="inputblue" maxlength="37" name="ValidDate"
                        style="width: 130px; background-color: ghostwhite;" type="text" vdisp="有效日期"
                        readonly="readOnly" />
                </td>
            </tr>
            <tr>
                <th class="style14">
                    卡内金额</th>
                <td class="style17">
                    <span style="color: Red; height: 34px;">
                        <br />
                        &nbsp;￥</span><input id="Balance" runat="server" maxlength="8" 
                        name="balance" style="border-style: none none solid none;
                            width: 100px; background-color: #EEF3F7; height: 27px; font-size: large; font-weight: bold;
                            border-bottom-color: #FF9933; color: #FF6600;" type="text" 
                        vdisp="卡内余额" readonly="readonly" /><span
                                class="style20">元<br />
                            </span>
                </td>
            </tr>
            <tr>
                <th class="style15">
                                        说 明
                </th>
                <td class="style18">
                    此操作不适用于已产生消费记录的卡操作
                </td>
                <tr>
                    <th class="style15">
                        &nbsp;
                    </th>
                    <td>
                        &nbsp;
                    </td>
                 </tr>
        </table>
    </div>
    <div  style="width:100%" align="left">
    <div class="appsection" id="search_result" runat="server">
        <div class="apphead" style=" text-align:left;">
            <img src="../images/bullet02.gif" class="appfollowimg" alt=""  /><strong>交易明细</strong></div>
        <asp:GridView Width="100%" PageSize="20" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
            <Columns>
                  <asp:BoundField DataField="transId" HeaderText="交易号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="card" HeaderText="卡号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cardtype" HeaderText="卡类型">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Chargetype" HeaderText="类型">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="amount" HeaderText="充值金额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="gift" HeaderText="赠送金额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="rulename" HeaderText="赠送规则">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="logtime" HeaderText="充值时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="chargeway" HeaderText="方式">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="operid" HeaderText="添加人">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
      </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Card.BLL.CardChargeListBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </div>
    <div style="width: 100%; text-align: right">
    &nbsp;<asp:Button ID="btnNew" name="btnCon1" class="btn003" runat="server" Text="退 卡" Style="margin-right: 10px;"
            OnClientClick="return confirm('确定要重置此卡的金额吗？');" OnClick="btnNew_Click" 
            CssClass="btn02" /><input 
                        id="RF_Card" type="hidden"  runat="server"/></div>
    </form>

    <script>
        WaitHelper.initWaitMessageForms("form1");  
    </script>
<p>
    <input id="spass" type="hidden"  value="FFFFFFFFFFFF"/>
</p>
</body>
</html>
