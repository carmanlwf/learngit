﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay_memberrecord.aspx.cs" Inherits="Pay_pay_memberrecord" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员开卡记录</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
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
            <li><strong>会员开卡记录</strong></li>
        </ul>
        <div class="appsection">
            <table cellpadding="1" cellspacing="1" class="table_default table_blue" id="TABLE1" runat="server" style="width:100%">
                <tr>
                    <th>
                        操作员</th>
                    <td>
                        <input type="text" class="inputblue" style="width: 130px" id="operatorid" runat="server"
                            name="operatorid" maxlength="12" /></td>
                    <th>
                        数据来源</th>
                    <td>
                        <select class="inputblue" style="width: 130px" id="tradeway" runat="server" 
                            name="tradeway">
                        </select></td>
                </tr>
                <tr>
                    <th class="style6">
                        车牌号</th>
                    <td class="style6">
                        <input type="text" class="inputblue" style="width: 130px" id="carnum" runat="server"
                            name="carnum" maxlength="8" /></td>
                    <th class="style6">
                        交易起止时间</th>
                    <td class="style6">
                            <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; font-size:12px; width:152px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss" runat="server"  id="tradetime_begin" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" /></div><span style=" float:left; color:Red; font-size:16px;">～</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; font-size:12px; width:152px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss" runat="server"  id="tradetime_end" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  /></div>

                          </td>
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
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>会员开卡记录</strong></div>
            <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
            DataSourceID="ObjectDataSource1">
            <Columns>
                
                <asp:TemplateField HeaderText="编号">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# this.GridView1.PageIndex * this.GridView1.PageSize + this.GridView1.Rows.Count + 1%>'/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                </asp:TemplateField>
                
                <asp:BoundField DataField="carnum" HeaderText="车牌号" 
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="tradetime" HeaderText="开卡时间" 
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="月卡类型">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("tradetypename").ToString().Substring(0,2)%>'/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="amount" HeaderText="金额" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="tradewayname" HeaderText="交易来源" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
               
                <asp:BoundField DataField="operatorid" HeaderText="操作员">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                 
            </Columns>
        </asp:GridView>
            <br />
            <div id="SumPan"  runat = "server" style="width: 500px" >
                <span class="btngrey"><asp:Label ID="Label1" runat="server" ForeColor="#C00000" 
                    Text="0.00" Visible="False"></asp:Label>&nbsp; <asp:Label ID="Label4" 
                    runat="server" ForeColor="#C00000" Text="0" Visible="False"></asp:Label>&nbsp;</span></div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
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
