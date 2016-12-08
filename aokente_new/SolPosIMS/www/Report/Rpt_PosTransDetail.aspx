<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Rpt_PosTransDetail.aspx.cs"
    Inherits="Report_Rpt_PosTransDetail" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>停车记录查询</title>

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
                target: "ShowCarPic.aspx?getcode=" + id
             });
            $("#isFrameOpt").trigger("click");  
        }
</script>
        <ul class="sitemappath">
            <li><strong>停车记录查询</strong></li>
        </ul>
        <div class="appsection">
            <table cellpadding="1" cellspacing="1" class="table_default table_blue" id="TABLE1" runat="server" style="width:100%">
                <tr>
                    <th>
                        车牌号</th>
                    <td>
                        <input type="text" class="inputblue" style="width: 130px" id="CardSnr" runat="server"
                            name="CardSnr" maxlength="20" />&nbsp; </td>
                    <th>
                        流水号</th>
                    <td>
                        <input type="text" class="inputblue" style="width: 130px" id="CredenceSnr" runat="server"
                            name="CredenceSnr" maxlength="20" /> <select id="Mode" runat="server" class="inputblue" name="Mode" 
                            style="width: 130px">
                        </select></td>
                </tr>
                <tr>
                    <th class="style6">
                        终端机(设备)号</th>
                    <td class="style6">
                        <input type="text" class="inputblue" style="width: 130px" id="PosSnr" runat="server"
                            name="PosSnr" maxlength="20" /></td>
                    <th class="style6">
                        所在路段</th>
                    <td class="style6">
                        <asp:DropDownList ID="Area_Code" runat="server" Width="135px"  style="margin-left:20px"
                            AutoPostBack="True" 
                            onselectedindexchanged="Area_Code_SelectedIndexChanged">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="Site_Code" runat="server" Width="130px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                </tr>
   
                <tr>
                    <th class="style6">
                        进场时间</th>
                    <td class="style6">
                        <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; font-size:12px; width:132px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss" runat="server"  id="start_date_begin" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" /></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; font-size:12px; width:132px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss" runat="server"  id="start_date_end" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  /></div>
                            
                            </td>
                    <th class="style6">
                        离场时间</th>
                    <td class="style6">

                            
                            <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:152px; height:25px;"><input style="font-size:12px" placeholder="YYYY-MM-DD hh:mm:ss" runat="server"  id="end_date_begin" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" /></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:152px; height:25px;"><input style="font-size:12px" placeholder="YYYY-MM-DD hh:mm:ss" runat="server"  id="end_date_end" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  /></div>
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
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>停车记录明细</strong></div>
            <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" SkinID="GridView_Blue"
            AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
            DataSourceID="ObjectDataSource1" 
        onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="车牌号">
                        <ItemTemplate>
                            
                            <%#Eval("CardType").ToString() == "1" ? "<div style='width:65px; height:20px;line-height:20px; border:1px;color:white; background-color:Blue' >" + Eval("CardSnr") + "</div>" : "<div style='width:65px; height:20px;line-height:20px; border:1px;color:Black; background-color:orange' >" + Eval("CardSnr") + "</div>"%>
                        </ItemTemplate>
                        <ItemStyle Width="70px" />
                         <ItemStyle HorizontalAlign="Center"  Font-Bold="true"/>
                 </asp:TemplateField>
                <asp:TemplateField HeaderText="车辆类型">
                        <ItemTemplate>
                            <%#Eval("CardType").ToString() == "1" ? "<font color=blue>小车</font>" : "<font color=orange>大车</font>"%>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                         <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
               <asp:BoundField DataField="sitename" HeaderText="所在路段" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="CredenceSnr" HeaderText="流水号" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="PosSnr" HeaderText="终端机号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="BackByte" HeaderText="车位号" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="UserID" HeaderText="操作员号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="giving" HeaderText="押金" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="Money" HeaderText="应缴金额" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="RealMoney" HeaderText="实缴金额" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="CarStatus" HeaderText="交易类型" 
                    ItemStyle-HorizontalAlign="Center" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="StartTime" HeaderText="进场时间" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                 <asp:BoundField DataField="EndTime" HeaderText="离场时间" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Datetime" HeaderText="地磁感应时间" HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="version" HeaderText="APP版本号" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="累计时长">
                    <ItemTemplate>
                        <font color="blue" size="9pt"><%#RtnTimeStr(Eval("SumMins"))%></font>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看车牌">
                    <ItemTemplate>
                        <a href="javascript:void(0);" onclick="ShowCarPic('<%# Eval("CredenceSnr")%>')"><img src="images/search.gif" alt="车牌图片" border="0" />车牌图片</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

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
            TypeName="Ims.Card.BLL.POS_TransactionBLL" OldValuesParameterFormatString="">
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
