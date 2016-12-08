<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardRenew.aspx.cs" Inherits="CardHold_CardRenew" %>
<%@ Register Src="../usercontrol/UserCardInfo.ascx" TagName="UserCardInfo" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车牌变更</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>

    <%--jquery引用--%>
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />

    <script src="../lib/jquery/jquery-1.3.2.min.js" language="javascript" type="text/javascript"></script>

    <script src="../lib/ligerUI/js/core/base.js" type="text/javascript"></script>

    <script src="../lib/ligerUI/js/plugins/ligerDrag.js" type="text/javascript"></script>

    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>

    <%--引用结束--%>
   <script type="text/javascript">
       function CloseWin(msg) {
           alert(msg);
           window.location.href = "CardRenew.aspx";
       }
    </script>
    <script type="text/javascript">
        //2013 - 4 - 15 * ZSD
        function OnSubmit() {
            var ValidBool = false;
            if (!doAllMessageBoxValidate(Form1)) {
                ValidBool = false;
            }
            else {
                if ($("#UserCardInfo1_CellPhone").val() != $("#Mobile").val()) {
                    $.ligerDialog.question('手机号码不正确!');
                    ValidBool = false
                }
                else {
                    document.getElementById("Button1").click();
                    ValidBool = true;
                }
            }
            return ValidBool;
        }
       
    </script>

    <script type="text/javascript">

        function displayAllInfo(src) {
            var followImg = document.all(src);
            var appSection = followImg.parentElement.parentElement;
            var i;
            if (appSection.children(1).currentStyle.display == "none") {
                for (i = 1; i < appSection.children.length; i++) {
                    appSection.children(i).style.display = "block";
                }
                followImg.src = "../images/collapsed_no.gif";
            } else {
                for (i = 1; i < appSection.children.length; i++) {
                    appSection.children(i).style.display = "none";
                }
                followImg.src = "../images/collapsed_yes.gif";
            }
        }
        function doSearch() {
            if (event.keyCode == 13) {
                document.all('Button1').click();
            }
        }
        function HideMe() {
            displayAllInfo('member');
        }
        function card_find() {
            if (event.keyCode == 13) {
                document.all('Button1').click();
            }
        }
    </script>

    <script>
        WaitHelper.showWaitMessage();
    </script>

    <style type="text/css">
        .style2
        {
            height: 18px;
        }
        .style4
        {
            height: 18px;
            width: 92px;
        }
        .style5
        {
            text-align: left;
        }
        .style7
        {
            text-align: left;
        }
        .style12
        {
            width: 181px;
            height: 18px;
        }
        .style14
        {
            height: 18px;
            width: 226px;
        }
        .style16
        {
            width: 181px;
            height: 19px;
        }
        .style17
        {
            height: 19px;
            width: 92px;
        }
        .style18
        {
            height: 19px;
            width: 226px;
        }
        .CCC
        {
            display: none;
        }
    </style>
</head>
<body onload="HideMe()">
    <form runat="server" id="Form1">
    <input id="comm" type="hidden" value="1" runat="server" />
    <input id="idev" type="hidden" value="-1" runat="server" />
    <input id="sector" type="hidden" value="0" runat="server" />
    <input id="block" type="hidden" value="1" runat="server" />
    <input id="readsign" style="width: 29px" type="hidden" value="0" runat="server" />
    <ul class="sitemappath">
        <li>
            账户信息管理 > 车牌变更</li></ul>
    <uc1:UserCardInfo ID="UserCardInfo1" runat="server" />
    <div class="table_data form_table clearfix">
			<table>
				<tbody>
					<tr>
						<td class="xyfml">验证手机号码<font style=" color:Red">*</font></td>
						<td class="xyfmr">
                            <input type="text" class="xyin_s" style="width: 180px" 
                                id="Mobile" runat="server"
                    vmode="not null" name="Mobile" vdisp="手机号" maxlength="11" 
                    enableviewstate="True" /></td>
					</tr>
					<tr>
						<td class="xyfml">新车牌号<font style=" color:Red">*</font></td>
						<td class="xyfmr">
                            <input type="text" class="xyin_s" style="width: 180px" id="newcard" runat="server"
                    vmode="not null" name="card" vdisp="新卡号" maxlength="16" /></td>
					</tr>
                    <tr>
						<td class="xyfml">摘 要</td>
						<td class="xyfmr">
                            <input type="text" class="xyin_s" style="width: 460px" id="memo" runat="server"
                    name="memo" vdisp="卡号" maxlength="50" onclick="this.value = ''" onblur="javascript:if(this.value==''){this.value = '因客户个人原因,持卡人申请车牌变更.['+((new Date()).toLocaleString())+']'}"
                    value="因客户个人原因,持卡人申请变更车牌." /></td>
					</tr>
                    <tr>
						<td class="xyfml">提 示</td>
						<td class="xyfmr">1、该业务执行后,原车牌将被执行注销操作,同时启用新车牌
                <br />
                            2、原卡注销后,相关交易记录将被保留,用户仍然可查询到原车牌的消费记录等信息<br />
                            3、可通过验证用户手机号来执行此项业务,也可使用主管授权码方式授权执行 </td>
					</tr>
                    <tr>
						<td class="xyfml">&nbsp;</td>
						<td class="xyfmr">
                <input id="btSubmit" type="button" class="xybtn" value="提交" onclick="return cardinfo(OnSubmit)" />
                                <input id="cardsnr" type="hidden"  runat="server"/>
                            <div style="display:none;"><asp:Button ID="Button1" runat="server" onclick="btnRenew_Click" Text="Button" /></div>
                                </td>
					</tr>
				</tbody>
			</table>
		</div>

    <script>
        WaitHelper.initWaitMessageForms("form1");  
    </script>

    </form>
</body>
</html>

