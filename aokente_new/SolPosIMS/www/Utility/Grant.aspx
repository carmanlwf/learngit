<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Grant.aspx.cs" Inherits="Utility_Grant" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统运行授权</title>
    <script src="../js/app.edit.js" type="text/javascript"></script>
    <style type="text/css">
#lock{position:relative;width:178px;height:30px;background:gray; top:1px;left:1px;}
#lock span{position:absolute;width:47px;height:30px;cursor:pointer;background:url(images/btn2.gif) no-repeat; }
.btnlogin{
	width: 75px ;
	height: 28px ;
	border-width: 0px ; 
	background-image: url("./images/login.gif"); 
    background-color:transparent;
	text-align: center ;
	vertical-align: text-bottom;
	font-size: 12px	   
 }
</style>
<script type="text/javascript">
window.onload = function ()
{
// var iPhone = document.getElementById("iphone");
 var oLock = document.getElementById("lock");
 var oBtn1 = oLock.getElementsByTagName("span")[0];
 var disX = 0;
 var maxL = oLock.clientWidth - oBtn1.offsetWidth;
// var oBg = document.createElement("img");
// oBg.src = "http://js.alixixi.com/img/201108/222.jpg";//预加载下第二张背景，其它没什么大用。
 oBtn1.onmousedown = function (e)
 {
  var e = e || window.event;
  disX = e.clientX - this.offsetLeft;
  
  document.onmousemove = function (e)
  {
   var e = e || window.event;
   var l = e.clientX - disX;
   
   l < 0 && (l = 0);
   l > maxL && (l = maxL);
   
   oBtn1.style.left = l + "px";
   
//   oBtn1.offsetLeft == maxL && (iPhone.style.background = "url("+ oBg.src +")", oLock.style.display = "none");
    oBtn1.offsetLeft == maxL
   return false;
  };
  document.onmouseup = function ()
  {
   document.onmousemove = null;
   document.onmouseup = null;
   oBtn1.releaseCapture && oBtn1.releaseCapture();
   
   oBtn1.offsetLeft > maxL / 2 ?
    startMove(maxL, function ()
    {
//    alert('ok!验证通过')
     document.all('username').style.background="url(images/username_bg.gif) #fff no-repeat left 50%";
     document.all('password').style.background="url(images/password_bg.gif) #fff no-repeat left 50%";
     document.all('username').disabled = false;
     document.all('password').disabled = false;
//     iPhone.style.background = "url("+ oBg.src +")";
//     oLock.style.display = "none"
    }) :
      startMove(0);
//    document.all('dis').innerHTML="<font color='red'>自动锁定.</font>";
     document.all('username').style.background="url(images/username_bg.gif) gainsboro no-repeat left 50%";
     document.all('password').style.background="url(images/password_bg.gif) gainsboro no-repeat left 50%";
     document.all('username').disabled = true;
     document.all('password').disabled = true;
  };
  this.setCapture && this.setCapture();
  return false
 };
 function startMove (iTarget, onEnd)
 {
  clearInterval(oBtn1.timer);
  oBtn1.timer = setInterval(function ()
  {
   doMove(iTarget, onEnd)
  }, 30)
 }
 function doMove (iTarget, onEnd)
 {
  var iSpeed = (iTarget - oBtn1.offsetLeft) / 5;
  iSpeed = iSpeed > 0 ? Math.ceil(iSpeed) : Math.floor(iSpeed);
  iTarget == oBtn1.offsetLeft ? (clearInterval(oBtn1.timer), onEnd && onEnd()) : oBtn1.style.left = iSpeed + oBtn1.offsetLeft + "px"
 }
};
</script>
<style type="text/css">
body {text-align:center;}
#all { margin:0px;padding:0px;margin-left:auto; margin-right:auto; text-align: center;width: 540px;overflow:hidden;}
#main {background:url(images/login_mid.gif); height:240px; text-align:center; padding:0x; margin:0px; margin:0 auto;width: 540px;}
#title {height:66px; margin:0px; padding:0px;margin-top: 120px;}
#login { margin-top: 32px; width: 420px; margin-left: auto; margin-right:auto;}
#btm{ margin:0 auto; text-align:center; width:540px;height:21px;}
#btm_left {background:url(images/login_btm_left.gif) no-repeat; width:21px;height:21px; float:left; margin:0px; padding:0px;}
#btm_mid {background:url(images/login_btm_mid.gif); width:498px; float:left; height:21px; margin:0px; padding:0px;}
#btm_right {background:url(images/login_btm_right.gif) no-repeat; width:21px; height:21px; float:left; margin:0px; padding:0px;}
</style>
<script type="text/javascript" language="javascript">
function reset_form()
{
	document.getElementById('username').value = '';
	document.getElementById('password').value = '';
	return false;
}
					 
</script>
</head>

<body>
<form runat="server">
<div id="all">
    <div id="title" style="overflow:hidden;"><img src="images/login_title.gif" /></div>
    <div id="main" style="position:relative; overflow:hidden;">
      <form action="" method="post" id="login_form">
        <table id="login" style="position:relative;">
          <tr>
            <td>U S E R N A M E </td>
            <td style="text-align: left"><input type="text" name="username" id="username" runat="server" style="background:url(images/username_bg.gif) gainsboro no-repeat left 50%; border:1px #ccc solid;height: 20px; font-family:Arial, Helvetica, sans-serif; font-size:14px; font-weight: 800; margin:0; padding-left: 24px; width: 181px;" maxlength="20" disabled="disabled" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                    ErrorMessage="*" Font-Size="Smaller"></asp:RequiredFieldValidator>
            </td>
          </tr>
          <tr>
            <td></td>
            <td style="text-align: left"></td>
          </tr>
          <tr>
            <td>P A S S W O R D </td>
            <td style="text-align: left"><input type="password" name="password" id="password" runat="server" style="background:url(images/password_bg.gif) gainsboro no-repeat left 50%; border: 1px #ccc solid; height: 20px; font-family:Arial, Helvetica, sans-serif; font-size:14px; font-weight: 800; margin:0; padding-left: 24px; width: 181px;" maxlength="20" disabled="disabled" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
                    ErrorMessage="*" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
          </tr>
            <tr>
                <td style="height: 11px">
                </td>
                <td style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; overflow: hidden; padding-top: 0px; height: 11px; text-align: left">
                </td>
            </tr>
          <tr>
          <td></td>
          <td style="height:34px; margin:0px;padding:0px; text-align:left;padding-left:8px;"><div style="width:180px;height:33px; background:#999;float:left;"><div id="lock" style="float:left;"><span></span></div></div><div id="dis" style="float:left; width:78px; height:33px; padding-left:10px; font-size:12px; line-height:33px;">
              </div></td>
          </tr>
            <tr>
                <td style="height: 10px">
                    </td>
                <td style="padding-right: 0px; padding-left: 8px; font-size: 10pt; padding-bottom: 0px;
                    margin: 0px; color: gray; padding-top: 0px; height: 10px; text-align: left">
                    请向箭头所指的方向滑动解锁...</td>
            </tr>
          <tr>
            <td style="text-align: right" colspan="2">
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btnlogin" Height="30px" Width="75px"  onmouseover="this.style.cursor='hand'"/></td>
          </tr>
        </table>
      </form>
    </div>
    </form>
    <div id="btm">
  <div id="btm_left"></div>
        <div id="btm_mid"></div>
        <div id="btm_right"></div>
    </div>
</body>
</html>
