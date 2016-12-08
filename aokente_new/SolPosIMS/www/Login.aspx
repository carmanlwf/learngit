<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>路泊占道停车收费管理系统V1.0 —— 支持车牌快速自动识别终端集成!</title>
    <link type="text/css" rel="stylesheet" href="css/app.login2.css" />
    <style type="text/css">

body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
    background-color:#41546F;
}
        .style1
        {
            height: 54px;
        }
        .style2
        {
            height: 9px;
            width: 227px;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 9px;
        }
        .style4
        {
            height: 20px;
            width: 227px;
        }
        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 20px;
        }
        .style6
        {
            height: 17px;
            width: 227px;
        }
        .style7
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            line-height: 25px;
            color: #666666;
            height: 17px;
        }
        .style8
        {
            height: 13px;
        }
        .style9
        {
            width: 227px;
        }

</style>
    <script type="text/javascript">
        var url = window.location.href;
        if (window != parent)
            parent.navigate("default.aspx");
    </script>
    <script language="JavaScript">
function correctPNG()
{
    var arVersion = navigator.appVersion.split("MSIE")
    var version = parseFloat(arVersion[1])
    if ((version >= 5.5) && (document.body.filters)) 
    {
       for(var j=0; j<document.images.length; j++)
       {
          var img = document.images[j]
          var imgName = img.src.toUpperCase()
          if (imgName.substring(imgName.length-3, imgName.length) == "PNG")
          {
             var imgID = (img.id) ? "id='" + img.id + "' " : ""
             var imgClass = (img.className) ? "class='" + img.className + "' " : ""
             var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
             var imgStyle = "display:inline-block;" + img.style.cssText 
             if (img.align == "left") imgStyle = "float:left;" + imgStyle
             if (img.align == "right") imgStyle = "float:right;" + imgStyle
             if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
             var strNewHTML = "<span " + imgID + imgClass + imgTitle
             + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
             + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
             + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>" 
             img.outerHTML = strNewHTML
             j = j-1
          }
       }
    }    
}
window.attachEvent("onload", correctPNG);
    </script>

    <script type="text/javascript">
    function doOnLoad()
    {
        var UserLogin_UserName = document.getElementById("UserLogin_UserName");
        
        var UserLogin_Password = document.getElementById("UserLogin_Password");
        if(UserLogin_UserName.value == "")
            UserLogin_UserName.focus();
        else
            UserLogin_Password.focus();
	    window.moveTo(0,0);
	    window.resizeTo(screen.availWidth,screen.availHeight);
	 
    }
    
    function login()
    {
	    window.open("./main.html","_self");
    }
    </script>

    <script type="text/javascript">
if (window.screen){
  var myw = screen.availWidth; 
  var myh = screen.availHeight;  
  window.moveTo(0, 0);         
  window.resizeTo(myw, myh);
} 
    </script>

    <script type="text/javascript">
   function CheckIsNull() 
    {    
        var cardid=document.getElementById("UserLogin_UserName"); 
        var cardpass=document.getElementById("UserLogin_Password"); 
        var inputCode = document.getElementById("UserLogin_input1");
        if (cardid.value=="") 
        { 
            alert('卡号不能为空'); 
            return;
        }   
        if (cardpass.value=="") 
        { 
            alert('密码不能为空'); 
                 return;
        } 
        
       if(inputCode.length <=0)
        {
            alert('验证码不能为空'); 
                 return;
        }
        if(inputCode.toUpperCase() != code.toUpperCase())
         {
            alert("验证码输入错误！");
//            createCode();//刷新验证码
         } 
        else
        {
        javascript:window.document.all('Button1').click();
        }       
    }

    function SetChangeRanCode() {
        document.all('ck_code').src = "Utility/randomImage.aspx?number=" + Math.random();
    }
    </script>

    <script language="javascript" type="text/javascript">

        var code; //在全局 定义验证码
        function createCode() {
            code = "";
            var codeLength = 4; //验证码的长度
            var checkCode = document.getElementById("checkCode");
            var selectChar = new Array(1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Z', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'); //所有候选组成验证码的字符，当然也可以用中文的

            for (var i = 0; i < codeLength; i++) {


                var charIndex = Math.floor(Math.random() * 36);
                code += selectChar[charIndex];


            }
            // alert(code);
            if (checkCode) {
                checkCode.className = "code";
                checkCode.value = code;
                checkCode.innerHTML = code;
            }

        }

        function validate() {
        var cardid=document.getElementById("UserLogin_UserName"); 
        var cardpass=document.getElementById("UserLogin_Password"); 
        var inputCode = document.getElementById("UserLogin_input1");
        if (cardid.value=="") 
        { 
            alert('用户ID不能为空'); 
            return;
        }   
        if (cardpass.value=="") 
        { 
            alert('密码不能为空'); 
                 return;
        } 
            var inputCode = document.getElementById("input1").value;
            var UserLogin_UserName = document.getElementById("UserLogin_UserName");
        
        var UserLogin_Password = document.getElementById("UserLogin_Password");
            if (inputCode.length <= 0) {
                alert("请输入验证码!");
                 document.all('input1').focus();
                 return false; 
            }
            else if (inputCode.toUpperCase() != code.toUpperCase()) {
                alert("验证码输入错误!");
                 document.all('input1').focus();
                return false;
            }
            return true;

        }
    
    </script>

</head>
<body onload="doOnLoad();createCode()" scroll="no" >
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="100px" valign="top">
                    <table width="100%" height="20%;" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
                        <tr>
                            <td width="1%">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td width="17%">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" class="login_bg">
                        <tr>
                            <td width="49%" align="right">
                                <table border="0" cellpadding="0" cellspacing="0" class="login_bg2">
                                    <tr>
                                        <td height="138" valign="top">
                                            <table height="100%" border="0" cellpadding="0" cellspacing="0" 
                                                style="width: 94%">
                                                <tr>
                                                    <td class="style8">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td height="80" align="right" valign="top">
                                                        <img src="images/logo.png" width="279" height="68" style=" margin-right:80px;"></td>
                                                </tr>
                                                <tr>
                                                    <td height="198" align="left" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0" 
                                                            style="height: 90px; width: 100%;">
                                                            <tr>
                                                                <td class="style2">
                                                                    </td>
                                                                <td class="style3">
                                                                    <p>
                                                                        是中国城市道路停车的一场革命...</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style4">
                                                                    </td>
                                                                <td class="style5">
                                                                    <p>
                                                                        是打造智慧城市道路停车的最佳方案...</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style6">
                                                                    </td>
                                                                <td class="style7">
                                                                    <p>
                                                                        是未来智慧城市道路停车信息化的必然选择...</p>
                                                                </td>
                                                            </tr>
                                                                                                                        <tr>
                                                                <td class="style6">
                                                                    </td>
                                                                <td class="style7">
                                                                    <p>
                                                                        是政府对城市道路停车进行科学管理的最有效手段...</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style9">
                                                                    &nbsp;</td>
                                                                <td width="30%" height="40" style="width: 65%">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                </td>
                            <td width="1%">
                                &nbsp;</td>
                            <td width="50%" valign="bottom">
                                <table width="100%" height="59" border="0" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="4%">
                                            &nbsp;</td>
                                        <td width="96%" height="38">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top">
                                            &nbsp;</td>
                                        <td height="21">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" id="table211" height="328px">
                                                <tr>
                                                    <td colspan="2" align="left" class="aim" style="height: 143px; background-color: transparent;">
                                                        <asp:Login ID="UserLogin" runat="server" DestinationPageUrl="~/Main.aspx" CssClass="UserLogin"
                                                            OnLoggedIn="UserLogin_LoggedIn" VisibleWhenLoggedIn="False" OnLoggingIn="UserLogin_LoggingIn" style="left: 0px; top: 0px">
                                                            <LayoutTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td class="style1" colspan="3">
                                                                            <span class="login_txt_bt">用户登录</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span style="font-size: 9pt; color: #333333; font-family: Arial">账 号：</span></td>
                                                                        <td colspan="2" style="width: 220px; text-align: left;">
                                                                            <asp:TextBox ID="UserName" runat="server" BackColor="White" BorderStyle="solid" Style="border: 1px #ccc solid;
                                                                                line-height: 20px; width: 150px; height: 20px; margin-left: 12px;"></asp:TextBox>
                                                                            <img alt="" height="18" src="images/icon-login-seaver.gif" width="19"/></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span style="font-size: 9pt; color: #333333; font-family: Arial">密 码：</span></td>
                                                                        <td colspan="2" style="width: 220px; text-align: left;">
                                                                            <asp:TextBox ID="Password" BorderStyle="solid" runat="server" TextMode="Password"
                                                                                Style="border: 1px #ccc solid; line-height: 20px; width: 150px; height: 20px;
                                                                                margin-left: 12px;" BackColor="White"></asp:TextBox>
                                                                            <img src="images/luck.gif" width="19" height="18" alt=""></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 18px">
                                                                            <span style="font-size: 9pt; color: #333333; font-family: Arial">验证码：</span></td>
                                                                        <td colspan="2" style="height: 20px; width: 220px; text-align: left;">
                                                                            <div id="lockc" class="lockc" style="width: 50px; height: 20px; padding-left: 12px;
                                                                                float: left;">
                                                                                <asp:TextBox  type="text" id="txtCode" style="width: 65px; font-size: 12pt; height: 25px;"
                                                                                    maxlength="4" name="txtCode"  runat="server" /> </div>
                                                                            <img id="ck_code" alt="" src="Utility/randomImage.aspx" onclick="SetChangeRanCode()" 
                                                                                title="点击更换验证码" 
                                                                                style="border: 1px dashed gainsboro; cursor: hand; float: left;
                                                                                line-height: 20px; padding-top:0px; width: 80px; height:30px; margin-left:20px; color: gray; background-color: transparent; font-weight: bold; text-align: center;"/>
<%--                                                                            <div id="checkCode" onclick="createCode()" title="点击更换验证码" style="cursor: hand; float: left;
                                                                                line-height: 20px;padding-top:2px; width: 50px; height:18px; margin-left:10px; color: gray; background-color: transparent; border-right: gainsboro 1px dashed; border-top: gainsboro 1px dashed; font-weight: bold; border-left: gainsboro 1px dashed; border-bottom: gainsboro 1px dashed; text-align: center;">
                                                                            </div>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td >
                                                                        </td>
                                                                        <td style="padding-top:10px;">
                                                                            <asp:Button ID="LoginButton" runat="server" OnClientClick="" CommandName="Login"
                                                                                Text="登录" ValidationGroup="Login1" Style="cursor: pointer;margin-left:12px;" 
                                                                                OnClick="LoginButton_Click" CssClass="xybtn" /></td>
                                                                        <td colspan="1" style="padding-top:20px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" style="text-align: center" > <span style="color:Red;"><font style="font-size:10pt;"><asp:Literal EnableViewState="False" ID="FailureText" runat="server"></asp:Literal></font></span></td>
                                                                        </tr>
                                                                </table>
                                                               
                                                            </LayoutTemplate>
                                                        </asp:Login>
                                                    </td>
                                                </tr>
                                                <tr><td height="20px;"></td><td heigt="20px;"></td></tr>
                                                <tr>
                                                    <td width="433" height="164" align="right" valign="bottom">
                                                        &nbsp;</td>
                                                    <td width="57" align="right" valign="bottom">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="20%;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="login-buttom-bg">
                        <tr>
                            <td align="center">
                                <span class="login-buttom-txt">Copyright 2007-2015版权所有<br>建议您在1280*800分辨率 IE8以上系列浏览器兼容模式下使用</span></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
