<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClearBill.aspx.cs" Inherits="InterFace_ClearBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=no"/>
        <script type="text/javascript" src="../js/common.js"></script>
    <script src="../jquery/jquery.min.js" type="text/javascript"></script>
<script src="../layer/layer.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showdialogWin(msg) {
            layer.msg(msg, 2, 1, 0);
        }
        
        function GetElementsByTagName(node, tagName) { 
           var elements = [], i = 0, anyTag = tagName === "*", next = node.firstChild; 
           
           while ((node = next)) {
               
               if (anyTag ? node.nodeType === 1 : node.nodeName.trim().toLowerCase() === tagName.trim().toLowerCase()) elements[i++] = node; 
              next = node.firstChild || node.nextSibling; 
              while (!next && (node = node.parentNode)) next = node.nextSibling; 
            } 
           return elements; 
         }; 

        function IsChecked() {
        
            
            
            var GridView1 = document.getElementById("<%=gv_bill.ClientID %>");
            var flag = false;
            
            //var temp = GridView1.rows[0].cells[0].getElementsByTagName("asp:CheckBox")[0];
            //alert(temp);
            for (i = 0; i < GridView1.rows.length; i++) {
            
                if (GetElementsByTagName(GridView1.rows[i].cells[0], "input")[0].checked) {
                    flag = true;
                    break;
                }
                
            }
            
            if (!flag) {
                alert("请选择要补缴的欠费记录");
                return false;
            }
            if (confirm("确定要补缴选中的记录吗？"))
            {
                
                return true;
            }
            else
                return false;
        }
        function getElementsByTagName(node, tagName) {
            var elements = [], i = 0, anyTag = tagName === "*", next = node.firstChild;
            while ((node = next)) {
                if (anyTag ? node.nodeType === 1 : node.nodeName === tagName) elements[i++] = node;
                next = node.firstChild || node.nextSibling;
                while (!next && (node = node.parentNode)) next = node.nextSibling;
            }
            return elements;
        };

        function OnSelectItem(obj) {
            var cb = getElementsByTagName(obj, "INPUT");
            if (cb[0].checked == true) {
                cb[0].checked = false;
                obj.style.backgroundColor = "#FFFFCC";
                obj.style.color = "#000000";
            }
            else {
                cb[0].checked = true;
                obj.style.backgroundColor = "#99CC00";
                obj.style.color = "#003300";
            }
        }
    </script>
<style type="text/css">
    .btn
{
    border-right: #999999 1px solid;
    padding-right: 2px;
    border-top: #999999 1px solid;
    padding-left: 2px;
    font-size: 14px;
    FILTER: progid:DXImageTransform.Microsoft.Gradient(GradientType=0,  StartColorStr=#ffffff,  EndColorStr=#cecfde);
    border-left: #999999 1px solid;
    cursor: hand;
    color: black;
    padding-top: 2px;
    border-bottom: #999999 1px solid;
    height:29px;
}
</style>
</head>
<body style=" margin-top:0px;">
    <form id="form1" runat="server">
    <div style=" height:350px; width:100%; overflow:scroll">
    
        <asp:GridView ID="gv_bill" runat="server" AutoGenerateColumns="False"
            ForeColor="#333333" GridLines="Both" AllowSorting="True">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFFCC" ForeColor="#333333" />
            <%--<Columns>
                <asp:TemplateField HeaderText="选择" FooterStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Medium">
                    <ItemTemplate>
                         <asp:CheckBox ID="CheckBox1" runat="server" Height="16px" /><asp:Label ID="Label1" runat="server" Text='<%# Eval("CredenceSnr") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                 </asp:TemplateField>
                             <asp:BoundField DataField="sitename" HeaderText="路段">
                                <ItemStyle HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="starttime" HeaderText="进场时间">
                                <ItemStyle HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="endtime" HeaderText="出场时间">
                                <ItemStyle HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="sumMins" HeaderText="时长">
                                <ItemStyle HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="arrears" HeaderText="欠费">
                                <ItemStyle HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="tradecomment" HeaderText="交易详情">
                                <ItemStyle HorizontalAlign="left" />
                             </asp:BoundField>
                               
            </Columns>--%>
            
            <Columns>
                <asp:TemplateField HeaderText="停车欠费记录" FooterStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="Medium">
                    <ItemTemplate>
                        <table  style="width:100%">
                            <tr>
                                <td>
                                <asp:CheckBox ID="CheckBox1" runat="server"  Width="166px" Height="16px" 
                                        Text="选中该条欠费记录" /><asp:Label ID="Label1" runat="server" Text='<%# Eval("CredenceSnr") %>' Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><b>路段：</b><asp:Label ID="Label3" runat="server" Text='<%#Eval("sitename")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td><b>进场时间：</b><asp:Label ID="Label4" runat="server" Text='<%#Eval("starttime")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td><b>出场时间：</b><asp:Label ID="Label5" runat="server" Text='<%#Eval("endtime")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td><b>时长：</b><asp:Label ID="Label6" runat="server" Text='<%#Eval("sumMins")%>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td><b>欠费：</b><asp:Label ID="Label2" runat="server" Text='<%# Eval("arrears") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <b>欠费详情：</b><%#Eval("tradecomment")%>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>

<FooterStyle HorizontalAlign="Center"></FooterStyle>

<HeaderStyle Font-Size="Medium"></HeaderStyle>
                </asp:TemplateField>       
            </Columns>
            
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#3366CC" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
        </asp:GridView>
    
    </div>
    <div style="height:50px; margin-top:5px; border-top:solid 1px gray">
        <asp:Button ID ="btnClear" Text="点击清缴已选欠费"  runat="server" OnClientClick="return IsChecked();"
            Height="40px" Width="100%" Font-Size="Medium" onclick="btnClear_Click" CssClass="btn"/>
            <span style=" display:block;width:100%; text-align:center;">三个月内，10笔欠费记录</span>
        </div>
    </form>
</body>
</html>
