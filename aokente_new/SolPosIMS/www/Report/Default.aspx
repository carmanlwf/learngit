<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Report_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

 <head> 
  <title>outputexcel</title> 
 </head> 
 <body> 
  <form id="form1" method="post" runat="server"> 
   <asp:datagrid id="datagrid1" runat="server"> 
    <columns> 
     <asp:boundcolumn></asp:boundcolumn> 
    </columns> 
   </asp:datagrid> 
   <p> 
    <asp:label id="label1" runat="server">文件名：</asp:label> 
    <asp:textbox id="textbox1" runat="server"></asp:textbox> 
    <asp:button id="button1" runat="server" text="输出到excel"></asp:button></p> 
  </form> 
 </body> 
</html> 
