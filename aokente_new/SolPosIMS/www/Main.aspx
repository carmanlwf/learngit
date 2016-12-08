<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<title>路泊停车_路边占道停车收费管理系统首选!</title>
<link href="css/app.main.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/app.log.js"></script>
<script type="text/javascript" src="js/app.main.js"></script>
<script type="text/javascript" src="js/app.dateex.js"></script>
<script type="text/javascript" src="js/app.xmlhttp.js"></script>
<script type="text/javascript" src="jquery/layer/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src="jquery/layer/layer.min.js"></script>

<link href="./jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="./jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="./jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>

    <script type="text/javascript">
        var url = window.location.href;
        if (window != parent)
            parent.navigate("default.aspx");
    </script>
<script type="text/javascript">
    var webSoftPhone = null;
    var nclAgentInfo = null;
    var nclCallData = null;
   
    var nclAgentApp = null;
    
    var noSaveServices = "";
    var servertime = null;
    var userId = "<%=Ims.Main.ImsInfo.CurrentUserId%>";
    var AppPath = "<%=ZsdDotNetLibrary.Web.Server.WebServerHelper.ApplicationPath%>";
    

	//事件
	function doOnLoad()
	{
	    CheckBatch();
        //main.location.href="Notice/NoticeBoard.aspx";
       //logHelper.write('<strong>CurrUserInfo:</strong><br/><%=currUserStr%>');
      // logHelper.write('<strong>currRolesInfo:</strong><br/><%=currRolesStr%>');
      //document.all('rightfollowImg').click();

	}
	
	var isReLogin = false;
    function logout(logoutReason)
    {
        if(typeof(logoutReason) == 'string')
        {
            alert("系统现在需要退出,原因是:" +logoutReason);
        }
         
        isReLogin = true;
//        alert(AppPath);
        window.location.href = AppPath + "/exit.html?relogin="+isReLogin;
    }
    
    function doBeforeUnload() {
        ExecBatchForCasher();
    /*
        try
        {
        
            if(noSaveServices != "")
            {
                isReLogin = false;
                event.returnValue = "注意：还有未保存的表单！";
                return ;
            }
            //closeOpenWins();
            XmlHttpHelper.asynCall("Logout.aspx");
            if(!isReLogin)
            {
                openBrWindow(AppPath + "/exit.html?relogin="+isReLogin,"_blank","width=500,height=300");
            }
        }catch(e){}
        */
    }
    
    function BusinessQuery()
    {
        var url = 'Biz/BizQuery.aspx?userid='+userId;
        openBrWindow(url,'BizQueryWin','width=860,height=660,resizable=yes');
    }
    function MemberSendCard()
    { 
    /*
        var url = 'Member/MemberSendCard.aspx';
        openBrWindow(url,'MemberSendCard','width=405,height=450,resizable=no');
    */
    $.layer({
    type: 2,
    border: [1],
    title: ['办理新户'],
    area: ['420px', '480px'],
    fix: false,
    border: [10, 0.3, '#3A61F5'],
    shadeClose: true,
    closeBtn: [0,true],
    offset: [($(window).height() - 500)/2+'px', ''], //上下垂直居中
    shade : [0.3, '#000'],
    iframe: {src: './Member/MemberSendCard.aspx'}
    });
    }
    function SetMyPass()
    {
    /*
        var url = 'Admin/UpdateAdminPassword.aspx';
        openBrWindow(url,'SetPass','width=305,height=150,resizable=no');
     */
         $.layer({
    type: 2,
    border: [1],
    title: ['设置密码'],
    area: ['320px', '180px'],
    fix: false,
    border: [10, 0.3, '#3A61F5'],
    shadeClose: true,
    closeBtn: [0,true],
    offset: [($(window).height() - 500)/2+'px', ''], //上下垂直居中
    shade : [0.3, '#000'],
    iframe: {src: './Admin/UpdateAdminPassword.aspx'}
});
    }

    function CardCharge()
    {
    /*
        var url = 'Money/ChargeSelect.aspx';
        openBrWindow(url,'BizQueryWin','width=500,height=450,resizable=no');
    
        //var url = 'Card/CardChongZhi.aspx';
       // openBrWindow(url,'BizQueryWin','width=500,height=550,resizable=no');
    $("#isFrameOpt").wBox({requestType: "iframe",target:"./Card/CardChongZhi.aspx"});
    $("#isFrameOpt").trigger("click");
    */
    $.layer({
    type: 2,
    border: [1],
    title: ['会员卡充值'],
    area: ['500px', '510px'],
    fix: false,
    border: [10, 0.3, '#3A61F5'],
    shadeClose: true,
    closeBtn: [0,true],
    offset: [($(window).height() - 500)/2+'px', ''], //上下垂直居中
    shade : [0.3, '#000'],
    iframe: {src: './Card/CardChongZhi.aspx'}
});

    }
   function MonthCard_Add()
   {
         $.layer({
        type: 2,
        border: [1],
        title: ['会员开卡'],
        area: ['500px', '510px'],
        fix: false,
        border: [10, 0.3, '#3A61F5'],
        shadeClose: true,
        closeBtn: [0,true],
        offset: [($(window).height() - 500)/2+'px', ''], //上下垂直居中
        shade : [0.3, '#000'],
        iframe: {src: './Card/MonthCard_Add.aspx'}
    });
   }
   
      function Recharge()
   {
         $.layer({
        type: 2,
        border: [1],
        title: ['会员续费'],
        area: ['500px', '510px'],
        fix: false,
        border: [10, 0.3, '#3A61F5'],
        shadeClose: true,
        closeBtn: [0,true],
        offset: [($(window).height() - 500)/2+'px', ''], //上下垂直居中
        shade : [0.3, '#000'],
        iframe: {src: './Card/Recharge.aspx'}
    });
   }
    
    
    function setservertime(stime)
    {
        if(servertime == null)
        {
            window.setInterval("tickservertime()",1*1000);
        }
        servertime = Date.instanceFromString(stime);
        userstatusframe.servertime.innerHTML = stime.substring(11);
    }
    
    function tickservertime()
    {
        servertime = servertime.dateAdd("s",1);
    }    
    //logHelper.open()
    logHelper.isShowLog = false;
    

</script>
	<script type="text/javascript" language="javascript">

	    function ExecBatchForCasher() {

	        var gNow = new Date();

	        $.ajax({

	            type: 'GET',

	            url: 'LogOut.ashx',

	            dataType: 'text',

	            data: 'y=' + gNow.getSeconds(),

	            success: function(msg) {
	                //var values = msg.split(",");
	                //alert(values[0]);
	                //alert(values[1]);
	                //$("#rulename").val(values[0]);
	                //$("#gift").val(values[1]);
	                if (msg != "")
	                    alert(msg);
	                if (!confirm('您确定要交班结算吗?')) return false;
	                ExecBatchForCasher_Sure();
	            },

	            error: function(data) {

	                alert(data);

	            }

	        });

	    }
	    function ExecBatchForCasher_Sure() {        
	        var gNow = new Date();

	        $.ajax({

	            type: 'GET',

	            url: 'ShitStuffDuty.ashx',

	            dataType: 'text',

	            data: 'z=' + gNow.getSeconds(),

	            success: function(msg) {
	                if (msg != "") {
	                    alert("结算成功!");
	                    logout();
	                } else {
	                    alert("操作失败,请重试!");
	                }
	            },

	            error: function(data) {

	                alert(data);

	            }

	        });

	    }
</script>

<script type="text/javascript" language="javascript">

    function CheckBatch() {
        $.ajaxSetup({ cache: false });
        var gNow = new Date();
        
        $.ajax({

            type: 'GET',

            url: 'checkbatchforlogin.ashx',

            dataType: 'text',

            data: 'x='+gNow.getSeconds(),

            success: function(msg) {
                //var values = msg.split(",");
                //alert(values[0]);
                //alert(values[1]);
                //$("#rulename").val(values[0]);
                //$("#gift").val(values[1]);
                if(msg != "")
                alert(msg);

            },

            error: function(data) {

                alert(data);

            }

        })

    } 
</script>
    <script language="JavaScript" type="text/javascript">
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

var loadi = layer.load('资源加载中…');
    </script>
</head>

<body  scroll="no" bgcolor="#e6e6e6" >

    <div id="header" style="left: 0px; top: 0px; height: 70px; background-image:images/topbg.gif">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
	<div id="callboardbar" style="left: 0px; top: 0px; height: 70px;display:block ">
	  
	  <img src="images/top_left.gif" id="logo" 
                style=" height:70px; width: 288px; margin-left:0px; margin-top:0px;vertical-align:baseline;float:left" />
                
	  <ul id="sortable1" runat=server style="background-image: none; background-color: transparent;">
	   <li style="left: 0px; height: 40px;" title="退出系统"><a <%if (Ims.Main.ImsInfo.UserIsInRole("admin,small")){ %>href="#"  <%} %> onclick="logout();">
            <img src="main/headimg/exit.png" alt="退出系统" 
               style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" 
               height="20" width="15"  onmouseover="this.src='main/headimg/xtpz2.png'"  onmouseout="this.src='main/headimg/xtpz.png'"/><br />退出系统</a>
        </li>
       <li style=" <%=style%> left: 0px; height: 40px;" title="数据维护"><a <%if (Ims.Main.ImsInfo.UserIsInRole("admin")){ %>href="./Sysem/DataMaintenance.aspx"   target="main"<%} %>>
            <img src="main/headimg/chart.white.png" alt="数据维护" 
               style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" 
               height="20" width="15"  onmouseover="this.src='main/headimg/xtpz2.png'"  onmouseout="this.src='main/headimg/xtpz.png'"/><br />数据维护</a>
        </li>
	    <li  style=" <%=style%> left: 0px; top: 0px; height: 41px" title="修改密码">
	    <a <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,channel,agent")!=""){ %>href="javascript:void(0)" onclick="SetMyPass();" target="tempwin" <%} %>>
            <img src="main/headimg/552cc44b14700_32.png" alt="修改密码" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" height="20" width="20"  onmouseover="this.src='main/headimg/bggl2.png'"  onmouseout="this.src='main/headimg/bggl.png'"/><br />修改密码</a>
	    </li>

	    <li style=" <%=style%> left: 0px; top: 0px; height: 40px;" title="车位管理"><a <%if (Ims.Main.ImsInfo.UserIsInRoles("admin")!=""){ %>href="./ST/parkSiteinfo.aspx"  target="main" <%} %>>
             <img src="main/headimg/552cc538f3a3f_32.png" alt="车位管理" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" height="20" width="20" onmouseover="this.src='main/headimg/jdjc2.png'"  onmouseout="this.src='main/headimg/jdjc.png'"/><br />车位管理</a></li>

                 <li style=" <%=style%> left: 0px; top: 0px; height: 40px;" title="免停记录"><a <%if (Ims.Main.ImsInfo.UserIsInRole("admin")){ %>href="./Report/Rpt_FreeParkList.aspx" target="main"<%} %>>
             <img src="main/headimg/552cc248f10ed_32.png" alt="免停记录" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" height="20" width="20"  onmouseover="this.src='main/headimg/wlcz2.png'"  onmouseout="this.src='main/headimg/wlcz.png'"/><br />免停记录</a></li>
        	    
        <li style=" <%=style%> left: 0px; top: 0px; height: 40px;" title="账户充值"><a <%if (Ims.Main.ImsInfo.UserIsInRoles("admin")!=""){ %>href="javascript:void(0)" onclick="CardCharge()"  target="main" <%} %>>
            <img src="main/headimg/552cc5f827c08_32.png" alt="账户充值" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" height="20" width="20"  onmouseover="this.src='main/headimg/ggxx2.png'"  onmouseout="this.src='main/headimg/ggxx.png'"/><br />账户充值</a></li>
             
            <li style=" <%=style%> left : 0px; top: 0px; height: 40px;" title="月卡续费"><a <%if (Ims.Main.ImsInfo.UserIsInRole("admin")){ %>href="./CardMonthly/CardInput.aspx"   target="main"<%} %>>
            <img src="main/headimg/552cc5f827c08_32.png" alt="开通月卡" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" height="20" width="20"  onmouseover="this.src='main/headimg/ggxx2.png'"  onmouseout="this.src='main/headimg/ggxx.png'"/><br />月卡续期</a></li>
        <li style=" <%=style%> left : 0px; top: 0px; color: #ffffff; height: 40px;" title="开通月卡">
	    <a <%if (Ims.Main.ImsInfo.UserIsInRole("admin")){ %>href="./CardMonthly/CardInput.aspx"   target="main"<%} %> >
            <img src="main/headimg/552cc531218cd_32.png" alt="办理新户" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" height="20" width="20"  onmouseover="this.src='main/headimg/grsw2.png'"  onmouseout="this.src='main/headimg/grsw.png'"/><br />开通月卡</a></li>
        <li style=" <%=style%> left : 0px; top: 0px; height: 40px;" title="停车记录"><a <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,channel")!=""){ %>href="./Report/Rpt_PosTransDetail.aspx" target="main" <%} %> >
             <img src="main/headimg/552cc4649bf52_32.png" alt="停车记录" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" height="20" width="20" onmouseover="this.src='main/headimg/rsgz2.png'"  onmouseout="this.src='main/headimg/rsgz.png'"/><br />停车记录</a></li>
        <li style=" <%=style%> left : 0px; height: 40px;" title="系统首页"><a href="./Notice/NoticeBoard.aspx" target="main">
            <img src="main/headimg/flatscreen.white.png" alt="系统首页" style="border-top-width: 0px; border-left-width: 0px; border-bottom-width: 0px; border-right-width: 0px;" height="20" width="20" onmouseover="this.src='main/headimg/index2.png'"  onmouseout="this.src='main/headimg/index.png'"/><br />首页</a>
        </li>
	</ul>	
 
	

    </div>

  </div>
 
  
  <!-- -->
  <div id="primary" style=" height:600px" class="primaryheight">
   <div id="leftsidebar" class="primaryheight" >
   	 <!--<img src="images/index_r5_c1.gif" /> -->
	 <div id="leftnavlayout"><iframe id="leftnavframe" name="leftnavframe" class="primaryiframe" src="main/Left.aspx?userid=<%=Ims.Main.ImsInfo.CurrentUserId%>" frameborder="0" scrolling="auto"></iframe></div>
   </div>
   <div id="leftfollowbar" class="primaryheight" style=" display:none;"><img id="followImg38103" class="followimg" src="images/main_switchpicl.gif" onclick="switchFollowSiderBar(leftsidebar)" onmousemove="/*switchFollowSiderBar(leftsidebar)*/"/></div>
   <div id="maincontent" class="primaryheight">
   <iframe id="main" name="main" class="primaryiframe" src="./Notice/NoticeBoard.aspx" frameborder="0" scrolling="auto"></iframe></div>
    <div id="rightfollowbar" class="primaryheight"><img id="rightfollowImg" class="followimg" src="images/main_switchpicl.gif" onclick="switchFollowSiderBar(event, 'rightsidebar')" onmousemove="switchFollowSiderBar(event, 'rightsidebar')"/></div>
   <div id="rightsidebar" class="primaryheight"><iframe id="rightcustomerframe" class="primaryiframe" src="main/RightMenuList.aspx" frameborder="0" scrolling="no"></iframe></div>
 </div>
 
<%-- <div id="footer" >
     <iframe id="userstatusframe" class="infoiframe" src="main/AgentStat.aspx" frameborder="0" scrolling="no"></iframe>
 </div>--%>
 <iframe id="tempwin" name="tempwin" style="display:none"></iframe>
 <iframe id="activereporterwin" name="activereporterwin" style="display:none" src="./main/ActiveReporter.html"></iframe>
 <iframe id="peekmsgwin" name="peekmsgwin" style="display:none" src="<%=MsgAppSite%>/Msger/PeekMsg.html"></iframe>
<script type="text/javascript">
layer.close(loadi);
</script>

</body>
</html>

