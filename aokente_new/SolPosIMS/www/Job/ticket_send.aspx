<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ticket_send.aspx.cs" Inherits="Job_ticket_send" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
<link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

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
        /*等待状态样式结束*/
        .style1
        {
            color: #808080;
        }
    </style>
    <script type="text/javascript">
        function CloseWin(msg) {
            alert(msg);
            window.location.href = 'ticket_sendlist.aspx'

        }
    </script>
    <script type="text/javascript">
        function AppearProgress() {

            //            $("#DivCover").css("display", "block");
            //            $("#Waiting").css("display", "block");
            document.getElementById("DivCover").style.display = "block";
            document.getElementById("Waiting").style.display = "block";
        }
    
    </script>
</head>
<body onload="OnLoadtime()" style=" width:98%">

 

    <form id="Form1" runat="server">
        <ul class="sitemappath">
        <li>票据管理 > 票据发放</li></ul>
    <div class="table_data form_table clearfix">
			<table>
				<tbody>
                    <tr  id="isfront">
						<td class="xyfml">票据总额</td>
						<td class="xyfmr">
                    <input id="amount" runat="server" class="xyin_s" maxlength="5" name="amount"
                        vdisp="卡号前缀" style="width: 136px" type="text" vmode="not null" /></td>
					</tr>
                    <tr>
						<td class="xyfml">操作摘要</td>
						<td class="xyfmr">
                    <input id="memo" runat="server" class="xyin_s" maxlength="200" name="memo"
                        vdisp="起始序号" vmode="not null" vtype="number" onpropertychange="count()" 
                                style="width: 500px" onclick="this.value = ''" onblur="javascript:if(this.value==''){this.value = '按照既定的规章制度定期为收费人员发放收费票据.['+((new Date()).toLocaleString())+']'}"
                        type="text" value="按照既定的规章制度定期为收费人员发放收费票据" /><span class="style1">(200个汉字以内)</span></td>
					</tr>
                    <tr>
						<td class="xyfml">领取人员</td>
						<td class="xyfmr">
                    <asp:RadioButtonList ID="rdbl_select" runat="server" RepeatDirection="Horizontal" 
                                RepeatColumns="10">
                    </asp:RadioButtonList>
                        </td>
					</tr>
                    <tr>
						<td class="xyfml">提 示</td>
						<td class="xyfmr">1、请按照公司制度按期定量发送定额票据<br />
                                                        2、每次发放会在系统生成一条记录,为了保证能及时准确地汇总票据消耗量,请严格按照发放信息填写票据发放信息<br />
                            3、如若遗漏发放记录,请及时准确地补录到系统,以免发生账务信息错乱</td>
					</tr>
                    <tr>
						<td class="xyfml">&nbsp;</td>
						<td class="xyfmr">
                &nbsp;<input id="cardsnr" type="hidden"  runat="server"/>
                            <input id="bt_Batch" runat="server" class="xybtn" name="btnCon" onserverclick="bt_Batch_ServerClick"
            type="button" value="确认提交" 
            
            
                                onclick="javascript:AppearProgress();" /></td>
					</tr>
				</tbody>
			</table>
		</div>
    <div align="center" class="section_operators">
        &nbsp;
        &nbsp;&nbsp; <input class="btn003" style=" height:18px; width:59px; display:none;" value="导入制卡"  onclick="doInfornew()" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
    <%--      遮罩层--%>
    <div id="DivCover" runat="server" style="display: none">
    </div>
    <div id="Waiting" runat="server" style="display: none;">
   <img src="../images/loadingbar.gif" width="100" height="7" alt="发送提示" /><br />
        <asp:Label ID="textid" runat="server" Text="正在执行，请稍后……"></asp:Label>  <br />
        <br />
        <a href="SentCard.aspx" target="_self">[返回列表]</a>
         </div>
    <%--      遮罩层结束--%>
    </form>



</body>
</html>
