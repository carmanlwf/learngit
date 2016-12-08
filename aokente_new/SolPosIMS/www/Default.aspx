<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
<title>页面载入中...</title>
<!--[if lt IE 7]> <html class="lt-ie9 lt-ie8 lt-ie7" lang="en"> <![endif]-->
<!--[if IE 7]> <html class="lt-ie9 lt-ie8" lang="en"> <![endif]-->
<!--[if IE 8]> <html class="lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]><!-->
<html lang="en">
<!--<![endif]-->
<!--[if lt IE 9]><script src="./images/jquery/html5.js" type="text/javascript"></script><![endif]-->
<script src='./images/jquery/jquery-1.9.1.min.js' type="text/javascript"></script>

    
<script language="javascript" type="text/javascript">
    function GetWHinfo() {
        document.all('WH').value = screen.width + "x" + screen.height;
    }
</script>
<link rel="stylesheet" href="styles/progressbar.css"/>
</head>
<body onload="GetWHinfo();">
<form id="form1" runat="server">
 <input id="WH" type="hidden"  runat="server"/>
<div id="jquery-script-menu">
<div class="jquery-script-center">


<div class="jquery-script-clear"></div>
</div>
</div>
<section class="container">
<div class="progress"> <span class="blue" style="width:0%;"><span>0%</span></span> </div>
</section>

<script type='text/javascript'>
    function loading(percent) {
        $('.progress span').animate({ width: percent }, 100, function() {
            $(this).children().html(percent);
            if (percent == '100%') {
                $(this).children().html('Loading ...&nbsp;&nbsp;&nbsp;&nbsp;');
                setTimeout(function() {
                    $('.container').fadeOut();
                    top.location.href = "Login.aspx?WH=" + document.all('WH').value;
                }, 100);
            }
        })
    }
  </script> 
<script type="text/javascript">    loading('5%');</script> 
<script type="text/javascript">    loading('10%');</script>
<script type="text/javascript">    loading('15%');</script>
<script type="text/javascript">    loading('20%');</script>
<script type="text/javascript">    loading('25%');</script>
<script type="text/javascript">    loading('30%');</script>
<script type="text/javascript">    loading('35%');</script>
<script type="text/javascript">    loading('40%');</script> 
<script type="text/javascript">    loading('45%');</script> 
<script type="text/javascript">    loading('50%');</script> 
<script type="text/javascript">    loading('55%');</script> 
<script type="text/javascript">    loading('60%');</script>
<script type="text/javascript">    loading('65%');</script>
<script type="text/javascript">    loading('70%');</script>
<script type="text/javascript">    loading('75%');</script>
<script type="text/javascript">    loading('80%');</script>
<script type="text/javascript">    loading('85%');</script>
<script type="text/javascript">    loading('90%');</script>
<script type="text/javascript">    loading('95%');</script>
<script type="text/javascript">    loading('100%');</script>
</form>
</body>
</html>
