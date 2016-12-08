<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_CardNoActive.aspx.cs" Inherits="ReportViewer_Business_CardNoActive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未激活卡清单报表</title>
    <link href="../../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/table.css" />
    <script src="../../lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
<%--jquery引用--%>
    <link href="../../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />

    <script src="../../lib/jquery/jquery-1.3.2.min.js" language="javascript" type="text/javascript"></script>

    <script src="../../lib/ligerUI/js/core/base.js" type="text/javascript"></script>

    <%--    日期js--%>

    <script src="../../lib/ligerUI/js/plugins/ligerDateEditor.js" type="text/javascript"></script>

    <%--       下拉框--%>

    <script src="../../lib/ligerUI/js/plugins/ligerCheckBox.js" type="text/javascript"></script>

    <script src="../../lib/ligerUI/js/plugins/ligerResizable.js" type="text/javascript"></script>

    <script src="../../lib/ligerUI/js/plugins/ligerComboBox.js" type="text/javascript"></script>

    <%--下拉结束--%>
    <%--引用结束--%>

    <script type="text/javascript">
        //2013-5-6 *ZSD
        $(function() {
            $("#sex").ligerComboBox({ width: 150});   //下拉列表控件
            $("#RankId").ligerComboBox({ width: 150});   //下拉列表控件
            $("#begindate").ligerDateEditor({ width: 150, showTime: true ,format:"yyyy-MM-dd hh:mm:ss" }); //         
            $("#enddate").ligerDateEditor({ width: 150, showTime: true ,format:"yyyy-MM-dd hh:mm:ss" }); //日期控件
   
        });
    </script>
    <style type="text/css">
        .style28
        {
            height: 55px;
        }
        </style>
    <style type="text/css">
        /*等待状态样式开始*/#DivCover
        {
            background-color: #cccccc;
            filter: Alpha(Opacity=50, Style=0);
            opacity: 0.50;
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            _height: 768px;
            z-index: 999;
        }
        #Waiting
        {
            position: absolute;
            text-align: center;
            left: 50%;
            top: 50%;
            margin-left: -110px;
            margin-top: -50px;
            z-index: 1000;
            width: 200px;
            background-color: #FFFFFF;
            border-top: 1px dashed #52D3EA;
            border-right: 1px dashed #52D3EA;
            border-bottom: 1px dashed #52D3EA;
            border-left: 1px dashed #52D3EA;
            padding: 15px 10px 10px 10px;
        }
        #Waiting img
        {
            margin-bottom: 10px;
        }
        /*等待状态样式结束*/</style>

    <script type="text/javascript">

        function AppearProgress() {

            $("#DivCover").css("display", "block");
            $("#Waiting").css("display", "block");
        }
    
    </script>

</head>
<body>
    <form runat="server" id="Form1">
    <input id="comm" type="hidden" value="1" runat="server" />
    <input id="idev" type="hidden" value="-1" runat="server" />
    <input id="sector" type="hidden" value="0" runat="server" />
    <input id="block" type="hidden" value="1" runat="server" />
    <input id="readsign" style="width: 29px" type="hidden" value="0" runat="server" />
    <ul class="sitemappath">
        <li>
                        报表管理 &gt; 清单报表</li></ul>
    <table cellpadding="1" cellspacing="1" class="table_blue" 
        style="width: 100%; ">
        <tr>
            <th>
                注册日期</th>
            <td>
                 <table style="margin-left: 20px;">
                    <tr>
                        <td>
                            <input id="begindate" runat="server" name="begindate" type="text" vdisp="起始时间" vmode="not null" />
                        </td>
                        <td>
                            ~
                        </td>
                        <td>
                            <input id="enddate" runat="server" name="enddate" type="text" vdisp="截止时间" vmode="not null" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <th >
            </th>
            <td style="color: #009999; line-height:20px; " class="style28">
                &nbsp;1.数据报表导出业务会占用较多的服务器资源,建议您在系统空闲时段(非业务繁忙时段)进行操作<br />
                &nbsp;2.数据报表导出的文档格式为Excel,如需打印请下载完成后在Excel中执行打印<br />
            </td>
        </tr>
        <tr>
            <th>
            </th>
            <td>
     &nbsp;<input type="button" id="btnSubmit" onclick="AppearProgress();" runat="server"
                    value="执行导出" class="xybtn" name="btnSubmit" 
                    onserverclick="btnSubmit_ServerClick" /><a href="../RptList.aspx" target="_self">返回列表<img src="../../images/back.png" style="border:0;" /></a></td>
        </tr>
    </table>
    <div id="DivCover" runat="server" style="display: none">
    </div>
    <div id="Waiting" runat="server" style="display: none;">
        <img src="../../images/loadingbar.gif" width="100" height="7" alt="发送提示" /><br />
        正在执行，请稍后……<br>
        <br>
        <a href="../RptList.aspx" target="_self">[返回列表]</a></div>
    </form>
</body>
</html>



