<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AchievementChartByOne.aspx.cs" Inherits="ReportViewer_AchievementChartByOne"  StylesheetTheme="app"%>

<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
    .left {
        float: left;
    }
</style>
</head>
<body style="width: 98%;" bgcolor="#999999" >
    <form runat="server" id="form1">
    <input id="type" type="hidden" runat="server" />
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
                        <input id="Button2" type="button" value="查看天业绩"  style=" margin-left:20px;"  runat="server"  onserverclick="btnDay_ServerClick" onclick="if(!doAllMessageBoxValidate(form1)) return false;"/>
                        <input id="Button4" type="button" value="查看月业绩" runat="server"  style=" margin-left:20px;" onserverclick="btnMonth_ServerClick" onclick="if(!doAllMessageBoxValidate(form1)) return false;"/>
                        <input id="Button6" type="button" value="查看年业绩"  runat="server"  style=" margin-left:20px;" onserverclick="btnYear_ServerClick" onclick="if(!doAllMessageBoxValidate(form1)) return false;"/></td>
                </tr>
                <tr>
                    <td align="right" style="height: 18px; text-align: left;">
                        <div id ="SearchPannel" >
                          <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="addeddate_begin" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:130px;"/></div><span style=" float:left; color:Red; font-size:16px;">~</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="addeddate_end" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:130px;"/></div>
                            <input id="Button1" type="button" value="查 询" runat="server"  style=" margin-left:20px; width: 72px;" onserverclick="btnSearch_ServerClick" onclick="if(!doAllMessageBoxValidate(form1)) return false;"/>
                    </div></td>
                </tr>
            </table>
        </div>
        <div class="appsection" id="search_result" runat="server">
            <div class="apphead">
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>业绩统计信息</strong></div>
             <div id="container">
            <table style="width:100%;">
                <tr>
                    <td>
                        <asp:Chart ID="Chart1" runat="server" DataSourceID="ObjectDataSource1" Width="500px" CssClass="left">
                            <Titles>
                                <asp:Title Name="Title1" Font="微软雅黑, 10.5pt, style=Bold" Text="应收总额统计图">
                                </asp:Title>
                            </Titles>
                            <series>
                                <asp:Series Name="Series1" XValueMember="newtime" YValueMembers="receivable" IsValueShownAsLabel="True" ChartType="Spline" Label="#VAL 元">
                                </asp:Series>
                            </series>
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Title="应收总额">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Title="时间">
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </td>
                    <td>
                        <asp:Chart ID="Chart2" runat="server" DataSourceID="ObjectDataSource1" Width="500px" CssClass="left">
                            <Titles>
                                <asp:Title Name="Title1" Font="微软雅黑, 10.5pt, style=Bold" Text="押金总额统计图">
                                </asp:Title>
                            </Titles>
                            <series>
                                <asp:Series Name="Series1" XValueMember="newtime" YValueMembers="pledge" IsValueShownAsLabel="True" ChartType="Spline" Label="#VAL 元">
                                </asp:Series>
                            </series>
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Title="押金总额">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Title="时间">
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Chart ID="Chart3" runat="server" DataSourceID="ObjectDataSource1" Width="500px" CssClass="left">
                            <Titles>
                                <asp:Title Name="Title1" Font="微软雅黑, 10.5pt, style=Bold" Text="欠缴总额统计图">
                                </asp:Title>
                            </Titles>
                            <series>
                                <asp:Series Name="Series1" XValueMember="newtime" YValueMembers="unpaid" IsValueShownAsLabel="True" ChartType="Spline" Label="#VAL 元">
                                </asp:Series>
                            </series>
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Title="欠缴总额">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Title="时间">
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </td>
                    <td>
                        <asp:Chart ID="Chart4" runat="server" DataSourceID="ObjectDataSource1" Width="500px" CssClass="left">
                            <Titles>
                                <asp:Title Name="Title1" Font="微软雅黑, 10.5pt, style=Bold" Text="无线充值总额统计图">
                                </asp:Title>
                            </Titles>
                            <series>
                                <asp:Series Name="Series1" XValueMember="newtime" YValueMembers="wirelessRecharge" IsValueShownAsLabel="True" ChartType="Spline" Label="#VAL 元">
                                </asp:Series>
                            </series>
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Title="无线充值总额">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Title="时间">
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Chart ID="Chart5" runat="server" DataSourceID="ObjectDataSource1" Width="500px" CssClass="left">
                            <Titles>
                                <asp:Title Name="Title1" Font="微软雅黑, 10.5pt, style=Bold" Text="返还押金总额统计图">
                                </asp:Title>
                            </Titles>
                            <series>
                                <asp:Series Name="Series1" XValueMember="newtime" YValueMembers="rebates" IsValueShownAsLabel="True" ChartType="Spline" Label="#VAL 元">
                                </asp:Series>
                            </series>
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Title="返还押金总额">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Title="时间">
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </td>
                    <td>
                        <asp:Chart ID="Chart6" runat="server" DataSourceID="ObjectDataSource1" Width="500px" CssClass="left">
                            <Titles>
                                <asp:Title Name="Title1" Font="微软雅黑, 10.5pt, style=Bold" Text="出场补交总额统计图">
                                </asp:Title>
                            </Titles>
                            <series>
                                <asp:Series Name="Series1" XValueMember="newtime" YValueMembers="afterPayment" IsValueShownAsLabel="True" ChartType="Spline" Label="#VAL 元">
                                </asp:Series>
                            </series>
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Title="出场补交总额">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Title="时间">
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Chart ID="Chart7" runat="server" DataSourceID="ObjectDataSource1" Width="500px" CssClass="left">
                            <Titles>
                                <asp:Title Name="Title1" Font="微软雅黑, 10.5pt, style=Bold" Text="入场车辆统计图">
                                </asp:Title>
                            </Titles>
                            <series>
                                <asp:Series Name="Series1" XValueMember="newtime" YValueMembers="carCount" IsValueShownAsLabel="True" ChartType="Spline" Label="#VAL 元">
                                </asp:Series>
                            </series>
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Title="入场车辆">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Title="时间">
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </td>
                    <td>
                        <asp:Chart ID="Chart8" runat="server" DataSourceID="ObjectDataSource1" Width="500px" CssClass="left">
                            <Titles>
                                <asp:Title Name="Title1" Font="微软雅黑, 10.5pt, style=Bold" Text="实收现金总额统计图">
                                </asp:Title>
                            </Titles>
                            <series>
                                <asp:Series Name="Series1" XValueMember="newtime" YValueMembers="officialReceipts" IsValueShownAsLabel="True" ChartType="Spline" Label="#VAL 元">
                                </asp:Series>
                            </series>
                            <chartareas>
                                <asp:ChartArea Name="ChartArea1">
                                    <AxisY Title="实收现金总额">
                                        <MajorGrid Enabled="False" />
                                    </AxisY>
                                    <AxisX Title="时间">
                                        <MajorGrid Enabled="False" />
                                    </AxisX>
                                </asp:ChartArea>
                            </chartareas>
                        </asp:Chart>
                    </td>
                </tr>
            </table>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount_job_statistics"
            SelectMethod="GetPagedObjects_job_statistics_One" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
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

