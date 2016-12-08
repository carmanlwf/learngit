<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AchievementChartByPerson.aspx.cs" Inherits="RptChart_AchievementChartByPerson"  StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收费员业绩图表</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/table.css" />
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script src="../js/app.edit.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
       <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />
    <script>
WaitHelper.showWaitMessage();
    </script>
<script type="text/javascript" language="javascript">
    function ChangePannelDispaly() {
        var cbPannel = document.getElementById('cbSerarchByTimeSpan');
        if (cbPannel.checked)
            document.getElementById('SearchPannel').style.display = "";
            else
            document.getElementById('SearchPannel').style.display = "none"; 
    }
</script>
<style type="text/css">
    .xytact { color:#CCC;}
    .checkitall
    { width:80px; color:#000;}
      .checkitall a
    {color:Red; cursor:pointer; width:20px; text-decoration:none; }	
 
    .style1
    {
        height: 12px;
    }
 
</style>
</head>
<body style="width: 98%;" bgcolor="#999999" >
    <form runat="server" id="form1">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
        <ul class="sitemappath">
            <li><strong>收费员基本信息</strong></li>
        </ul>
        <div class="appsection">
            <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%" id="TABLE1" runat="server">
                <tr>
                    <td align="right" style="text-align: left; height:20px;" >
                    <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input id="operatorid" runat="server" style="width:130px;height:25px; font-size:8pt;"  value="请输入员工号" onclick="javascript:this.value=''" /></div></td>
                </tr>
                <tr>
                    <td align="right" style="text-align: left;" class="style1">
                   <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="searchDay" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:130px;"/></div>
                            
                            <input id="Button2" type="button" 
                            value="查看天业绩"  style=" margin-left:20px;"  runat="server"  onserverclick="btnDay_ServerClick" onclick="if(!doAllMessageBoxValidate(form1)) return false;"/>
                        <input id="Button4" type="button" value="查看月业绩" runat="server"  style=" margin-left:20px;" onserverclick="btnMonth_ServerClick" onclick="if(!doAllMessageBoxValidate(form1)) return false;"/>
                        <input id="Button6" type="button" value="查看年业绩"  runat="server"  style=" margin-left:20px;" onserverclick="btnYear_ServerClick" onclick="if(!doAllMessageBoxValidate(form1)) return false;"/></td>
                </tr>
                <tr>
                    <td align="right" style="height: 18px; text-align: left;">
                        <div id ="SearchPannel" >
                          <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="addeddate_begin" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:130px;"/></div><span style=" float:left; color:Red; font-size:16px;">～</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="addeddate_end" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:130px;"/></div>
                            <input id="Button1" type="button" value="查 询" runat="server"  
                                                    style=" margin-left:20px; width: 72px;" onserverclick="btnSearch_ServerClick" 
                                                    onclick="if(!doAllMessageBoxValidate(form1)) return false;"/>
                                                    <input id="Button3" type="button" value="导 出" runat="server"  
                                                    style=" margin-left:20px; width: 72px;" onserverclick="btnExport_ServerClick" 
                                                     />
                                                    </div></td>
                </tr>
            </table>
        </div>
        <div class="appsection" id="search_result" runat="server">
            <div class="apphead">
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>业绩统计信息</strong></div>
             <div id="container">
             <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" 
                SkinID="GridViewNoPaging_Blue" AutoGenerateColumns="False" AllowSorting="True" 
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                 <asp:Label ID="Label2" runat="server" Text='<%# this.GridView1.PageIndex * this.GridView1.PageSize + this.GridView1.Rows.Count + 1%>'/>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                </asp:TemplateField>
                <asp:BoundField DataField="operatorid" HeaderText="收费员编号" 
                    ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="name" HeaderText="收费员姓名" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="receivable" HeaderText="应收总额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
       
                <asp:BoundField DataField="pledge" HeaderText="押金总额" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="unpaid" HeaderText="欠缴总额" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                  <asp:BoundField DataField="wirelessRecharge" HeaderText="无线充值总额" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
               <asp:BoundField DataField="rebates" HeaderText="返还押金总额" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="afterPayment" HeaderText="出场补交总额" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
             <asp:BoundField DataField="carCount" HeaderText="入场车辆" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 <asp:BoundField DataField="officialReceipts" HeaderText="实收现金总额" >
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                 
                </Columns>
        </asp:GridView>
        <div class="table_data_title xytact">
			<ul>		
			        <li><label class="checkitall">合计车辆:<a title="<% =num %>"><% =num%></a></label>|</li>				
					<li><label class="checkitall">合计应收:<a title="<% =amount_receivable %>"><% =amount_receivable%></a></label>|</li>
					<li><label class="checkitall">合计押金:<a title="<% =giving_amount %>"><% =giving_amount%></a></label>|</li>
					<li><label class="checkitall">合计欠缴:<a title="<% =Balanceb %>"><%=Balanceb%></a></label>|</li>
					<li><label class="checkitall">合计无线充值:<a style=" title="<% =amount %>"><% =amount%></a></label>|</li>
					<li><label class="checkitall">出场补交总额:<a title="<% =amount_real %>"><% =amount_real%></a></label>|</li>
					<li><label class="checkitall">合计返还押金:<a  title="<% =ReturnMoney %>"><% =ReturnMoney%></a></label>|</li>
					<li><label class="checkitall">合计实收现金:<a  title="<% =Totality %>"><% =Totality%></a></label>|</li>
			</ul>
		</div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount_job_statistics"
            SelectMethod="GetPagedObjects_job_statistics" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ims.Job.BLL.JobHelperBLL" OldValuesParameterFormatString="">
            <SelectParameters>
                <asp:Parameter Name="o" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
        </div>
        </div>
    </form>

    <script>
WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>

