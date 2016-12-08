<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="InterFace_bill"  StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-type" name="viewport" content="initial-scale=1.0, maximum-scale=1.0, user-scalable=no, width=device-width" />
    <title id="carbill" runat="server">查询账单</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

   <script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>

    <script>
        WaitHelper.showWaitMessage();
    </script>

    </head>
<body style="width: 98%;"  >
    <form runat="server" id="Form1">
            <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
            DataSourceID="ObjectDataSource1">
            <Columns>

                <asp:BoundField DataField="tradetypename" HeaderText="交易类型" 
                    ItemStyle-HorizontalAlign="Center" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
               <asp:BoundField DataField="amount" HeaderText="欠费金额" 
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="tradetime" HeaderText="交易时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:BoundField DataField="tradecomment" HeaderText="交易详情" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="left" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetArrearsObjectsCount"
            SelectMethod="GetPagedArrearsObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ims.Pay.BLL.PayHelperBLL" OldValuesParameterFormatString="">
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


