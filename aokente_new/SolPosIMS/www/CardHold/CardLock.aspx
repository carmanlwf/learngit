﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardLock.aspx.cs" Inherits="CardHold_CardLock" %>
<%@ Register Src="../usercontrol/UserCardInfo.ascx" TagName="UserCardInfo" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>账户锁定</title>
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
           window.location.href="CardLock.aspx";
       }
    </script>
    <script type="text/javascript">
        //2013-4-14 *ZSD
        function OnSubmit() {
            var ValidBool = false;
            if (!doAllMessageBoxValidate(Form1)) {
                ValidBool = false;
            }
            else {
                if ($("#UserCardInfo1_CellPhone").val() != $("#Mobile").val()) {
                    $.ligerDialog.question('手机号码不正确!');
                ValidBool = false }
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

    <script>
        WaitHelper.showWaitMessage();
    </script>

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
            持卡管理 > 卡锁定</li></ul>
    <uc1:UserCardInfo ID="UserCardInfo1" runat="server" />
    <div class="table_data form_table clearfix">
			<table>
				<tbody>
					<tr>
						<td class="xyfml">验证手机号码<font color="red">*</font></td>
						<td class="xyfmr"><input type="text" class="xyin_s" style="width: 180px" 
                                id="Mobile" runat="server"
                    vmode="not null" name="Mobile" vdisp="手机号" maxlength="11" 
                    enableviewstate="True" /></td>
					</tr>
                    <tr>
						<td class="xyfml">摘 要</td>
						<td class="xyfmr">
                            <input type="text" class="xyin_s" style="width: 460px" id="memo" runat="server"
                    name="memo" vdisp="卡号" maxlength="11" onclick="this.value = ''" onblur="javascript:if(this.value==''){this.value = '账户异常,车主本人申请锁定.['+((new Date()).toLocaleString())+']'}"
                    value="账户异常,车主本人申请锁定." /></td>
					</tr>
                    <tr>
						<td class="xyfml">提 示</td>
						<td class="xyfmr">1、该业务执行后,客户将不能进行所有相关的业务操作,包括POS终端上的停车消费/充值/查询等操作<br />
                                                        2、该操作仅在账户异常，须暂停服务时启用,启用后相关业务暂停,账户信息及交易记录不变<br />
                            3、可通过验证用户手机号来执行此项业务,未注册手机号的用户须先注册相关资料后使用</td>
					</tr>
                    <tr>
						<td class="xyfml">&nbsp;</td>
						<td class="xyfmr">
                <input id="btnSubmit" type="button" class="xybtn" value="提交" 
                                onclick="return cardinfo(OnSubmit)"/>
                                <input id="cardsnr" type="hidden"  runat="server"/>
                            <div style="display:none;"><asp:Button ID="Button1" runat="server" onclick="btnLock_Click" Text="Button" /></div>
                        </td>
					</tr>
				</tbody>
			</table>
		</div>
    </form>

    <script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>

