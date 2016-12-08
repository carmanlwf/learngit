<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardInput.aspx.cs" Inherits="CardMonthly_CardInput" %>

<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请输入车牌号</title>
    <script type="text/javascript" src="../js/common.js"></script>
    <script src="../jquery/jquery.min.js" type="text/javascript"></script>
<script src="../layer/layer.js" type="text/javascript"></script>
<style type="text/css"> 
    
.btn
{
	padding:0px 8px 5pt 3px; 
    height:25px; 
    border:#999999 1px solid; 
	
    <%--border-right: #999999 1px solid;
    border-left: #999999 1px solid;
    border-bottom: #999999 1px solid;
    border-top: #999999 1px solid;--%>
    
    padding-right: 2px;
   
    padding-left: 2px;
    font-size: 14px;
    FILTER: progid:DXImageTransform.Microsoft.Gradient(GradientType=0,  StartColorStr=#ffffff,  EndColorStr=#cecfde);
    
    cursor: hand;
    color: black;
    
    height:20px;
    
    
}

*{ 
    margin:0; 
    padding:0; 
} 

/*input*/ 
.input_on{ 
    padding:2px 8px 0pt 3px; 
    height:25px; 
    border:1px solid #999; 
    background-color:#FFFFCC; 
} 
.input_off{ 
    padding:10px 8px 0pt 3px; 
    height:25px; 
    border:1px solid #CCC; 
    background-color:#FFF; 
} 
.input_move{ 
    padding:2px 8px 0pt 3px; 
    height:25px; 
    border:1px solid #999; 
    background-color:#FFFFCC; 
} 
.input_out{ 
    /*height:16px;默认高度*/ 
    padding:2px 8px 0pt 3px; 
   
    height:25px; 
    border:1px solid #CCC; 
    background-color:#FFF; 
} 
/*form*/ 
ul.input_test{ 
    margin:20px auto 0 auto; 
    width:500px; 
    list-style-type:none; 
} 
ul.input_test li{ 
    width:500px; 
    height:25px; 
    margin-bottom:10px; 
} 
.input_test label{ 
    float:left; 
    padding-right:10px; 
    width:100px; 
    line-height:25px; 
    text-align:right; 
    font-size:14pt; 
} 
.input_test p{ 
    float:left; 
    _margin-top:-1px; 
} 
.input_test span{ 
    float:left; 
    padding-left:10px; 
    line-height:25px; 
    text-align:left; 
    font-size:14pt; 
    color:#999; 
} 
</style> 
<script type="text/javascript" >
    function CheckCarNum(str) {
        return /(^[\u4E00-\u9FA5]{1}[A-Z0-9]{6}$)|(^[A-Z]{2}[A-Z0-9]{2}[A-Z0-9\u4E00-\u9FA5]{1}[A-Z0-9]{4}$)|(^[\u4E00-\u9FA5]{1}[A-Z0-9]{5}[挂学警军港澳]{1}$)|(^[A-Z]{2}[0-9]{5}$)|(^(08|38){1}[A-Z0-9]{4}[A-Z0-9挂学警军港澳]{1}$)/.test(str);
    }
</script>

<script type="text/javascript">
    layer.config({
        extend: '../layer/skin/espresso/style.css'
    });
    function openOperWin() {
        //自定页
        var carnum = document.getElementById("carnum").value;
        carnum = Trim(carnum);
        if (!CheckCarNum(carnum)) {
            msg = "<font color = orangered>输入的车牌号有误!</font>";
            layer.msg(msg, 2, 1, 0);
            document.getElementById("carnum").select();
            return;
        }
        layer.open({
            title: "办理月卡",
            type: 1,
            skin: 'layer-ext-espresso',
            closeBtn: 0, //不显示关闭按钮
            shift: 2,
            shadeClose: false, //开启遮罩关闭,
            btn: ['确 认', '取 消'],
            yes: function(index, layero) { //或者使用btn1
            window.location.href = 'CreatMonthlyCardInfo.aspx?carnum=' + carnum; //按钮【按钮一】的回调
            }, cancel: function(index) { //或者使用btn2
                //按钮【按钮二】的回调
            },
            content: '<p style="margin-left:18px;font-size:14pt; font-weight:bold; color:Blue;"><font color="black" font-size:14pt;>车牌号:</font>' + carnum + '</p><p style = "margin-left:6px;padding-top:5px;line-hight:30px;"><font color = "gray">&nbsp;&nbsp;办理开通月卡，将启用包月消费模式，已开通月卡用户将以当前开通的最新天数计算。</font></p>'
        });
    }
    function showdialogWin(msg) {
        msg = "<font color = orangered>"+msg+"</font>";
        layer.msg(msg,2,1,0);
    }
</script>
</head>
<body onload="javascript:document.getElementById('carnum').focus()">
    <form id="form1" runat="server">
    <div style=" margin-top:150px; margin-left:300px;">
            
            <p>车牌号：<input id="carnum" class="input_out" style="font-size:18pt; font-weight:bold; color:Green; width:120px;" maxlength = "8" name="" type="text" onfocus="this.className='input_on';this.onmouseout=''" onblur="this.className='input_off';this.onmouseout=function(){this.className='input_out'};" onmousemove="this.className='input_move'" onmouseout="this.className='input_out'" />
            &nbsp;<input id="Button1" type="button" value="下一步" onclick="openOperWin()" class="btn"/>
            </p> 
            <span style=" font-size:10pt; font-weight:normal;color:Gray; margin-left:50px;">请输入车牌号。如:粤B569CU</span> 
    </div>
    </form>
<p>
    </p>
</body>
</html>
