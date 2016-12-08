<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Con_banners.aspx.cs" Inherits="Report_Con_banners" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>小票通知设置</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../css/table.css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../ST/js/ST.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>
<script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript" src="../js/jquery.hDialog.min.js"></script>

<script type="text/javascript">
    $('.demo0').hDialog({ title: '测试弹框标题', height: 300 });

    function Msg(er) {
        alert(er);
    }

    function addAgent(areacode) {
        openBrWindow('../Admin/AddUserWithAuthority.aspx?type=addagent&code=' + areacode, 'addAgent', '850', '300');
    }
    function agentList(areacode) {
        openBrWindow('../Admin/UserListByAuthority.aspx?type=agentlist&code=' + areacode, 'agentList', '850', '600');
    }


    function CheckAll(form) {
        document.getElementById('chkChouse').checked = false;
        for (var i = 0; i < form.elements.length; i++) {
            var e = form.elements[i];
            if (e.name.indexOf('chkChouse') > -1)
                continue;
            if (e.name.indexOf('checkitall') == -1) e.checked = form.checkitall.checked;
        }
    }
   
    function FanCheckAll(form) {
        document.getElementById('checkitall').checked = false;
        for (var i = 0; i < form.elements.length; i++) {
            var e = form.elements[i];
            if (e.name.indexOf('chkChouse') == -1) {
                if (e.name.indexOf('checkitall') == -1) {
                    if (e.checked)
                        e.checked = false;
                    else
                        e.checked = true;
                }
            }
        }
    }

</script>
<style type="text/css">
    ul{list-style:none;} 
    .none{ display:none;}
    .style1
    {
        height: 18px;
        width: 224px;
    }
    .style2
    {
        width: 224px;
    }
    
.animated
{
position: fixed; 
top: 50%; left: 50%; 
margin: -105px 0px 0px -200px; 
z-index: 10; 
width: 300px; 
height: 180px; 
box-shadow:1px 1px 5px #333;
-o-box-shadow:1px 1px 5px #333;
-moz-box-shadow:1px 1px 5px #333;
-webkit-box-shadow:1px 1px 5px #333;
zoom: 1;
filter: progid:DXImageTransform.Microsoft.Shadow(Color=#969696, Strength=7, Direction=0),
        progid:DXImageTransform.Microsoft.Shadow(Color=#969696, Strength=7, Direction=90),
        progid:DXImageTransform.Microsoft.Shadow(Color=#969696, Strength=7, Direction=180),
        progid:DXImageTransform.Microsoft.Shadow(Color=#969696, Strength=7, Direction=270),
        progid:DXImageTransform.Microsoft.Chroma(Color='#ffffff');
background-color:#FFFFFF;
border:1px solid #333;
}
.animated.flip{-webkit-backface-visibility:visible;-ms-backface-visibility:visible;backface-visibility:visible;-webkit-animation-name:flip;animation-name:flip}
.animated{-webkit-animation-duration:1s;animation-duration:1s;-webkit-animation-fill-mode:both;animation-fill-mode:both}
.animated.infinite{-webkit-animation-iteration-count:infinite;animation-iteration-count:infinite}
.animated.hinge{-webkit-animation-duration:2s;animation-duration:2s}
.list{padding:0;}
.list li{width:80%;margin:0px auto auto;  overflow: hidden;}
.list li strong{width:20%;float:left;display:inline-block;margin-right:10px;text-align: right;}
.list .fl{width:72%;}
</style>
<script>
    WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;  background-color: #eee;">
<form runat="server" id="Form1">
<ul class="sitemappath" style=" height:30px;"><li><strong>小票通知设置</strong></li></ul>



<div class="animated" >
<div style=" width:100%; text-align:center; padding-top:5px; font-size:14px; height:25px; ">小票通知</div>

    <ul class="list" style="width:100%;">
    <li style="float:left; height:50px;  padding:30px 0 0 0; width:280px; margin-left:10px; border:1px solid #B1B2B5; "> 
    <strong style="float:left; width:60px; margin-top:5px;" >小票通知<font color="#ff0000">*</font></strong>
     <input type="text" class="inputblue" style="width: 200px; float:left; margin-left:-9px; " id="Banners" runat="server" name="machineid" maxlength="25"  />
    </li>
    <li style="float:left; width:100%;">
     <input type="button" name="btnCon"  class="btn003" value="修改" runat="server" style=" float:left; margin-top:18px; margin-left:70%;" onserverclick="btnNew_Confirm"  id="Button1"  />
     </li>
    </ul>
   
    <!-- HBox end -->
</div>



</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>

