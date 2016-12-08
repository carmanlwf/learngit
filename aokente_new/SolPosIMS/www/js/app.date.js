/*
用法：
1.在页面上加入：
<script src="../js/app.date.js" language=javascript charset ="gb2312"></script>
function onSelectedDateTime(obj,datetime)
{

}
2.isTop参数: true:在控件上方显示 ; 为空表示在控件下方显示
*/

/*
FlexDate
*/


/**
xl:返回年：yyyy
*/
function setyear(tt,obj,isTop)
{
    FlexDateWin.setyear(tt,obj,isTop);
}


/**
显示日期选择框 返回年月：yyyy-mm<br>
FlexDateWin.setmonth(this,[object])和setmonth(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、<input name=txt><input type=button value=setmonth onclick="setmonth(this,document.all.txt)"><br>
 二、<input onfocus="setmonth(this)"><br>
*/
function setmonth(tt,obj,isTop) 
{
	FlexDateWin.setmonth(tt,obj,isTop);
}

/**
显示日期选择框 返回年月日：yyyy-mm-dd<br>
FlexDateWin.setday(this,[object])和setday(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、<input name=txt><input type=button value=setday onclick="setday(this,document.all.txt)"><br>
 二、<input onfocus="setday(this)"><br>
*/
function setday(tt,obj,isTop)
{
	FlexDateWin.setday(tt,obj,isTop);
}

/**
xl:返回年月日小时：yyyy-mm-dd hh:00:00
*/
function sethour(tt,obj,isTop)
{
    FlexDateWin.sethour(tt,obj,isTop);
}

/**
xl:返回年月日小时：yyyy-mm-dd hh
*/
function sethouronly(tt,obj,isTop)
{
    FlexDateWin.sethouronly(tt,obj,isTop);
}

/**
显示日期选择框 返回年月日小时分：yyyy-mm-dd hh:nn:00<br>
FlexDateWin.setdatetime(this,[object])和setdatetime(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、<input name=txt><input type=button value=FlexDateWin.setdatetime onclick="setdatetime(this,document.all.txt)"><br>
 二、<input onfocus="setdatetime(this)"><br>
*/
function setdatehhnn(tt,obj,isTop) 
{
	FlexDateWin.setdatehhnn(tt,obj,isTop);
}

/**
xl:返回年月日小时分：yyyy-mm-dd hh:ss
*/
function setminuteonly(tt,obj,isTop)
{
    FlexDateWin.setminuteonly(tt,obj,isTop);
}

/**
显示日期选择框 返回年月日时分秒：yyyy-mm-dd hh:mm:ss<br>
FlexDateWin.setdatetime(this,[object])和setdatetime(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、<input name=txt><input type=button value=FlexDateWin.setdatetime onclick="setdatetime(this,document.all.txt)"><br>
 二、<input onfocus="setdatetime(this)"><br>
*/
function setdatetime(tt,obj,isTop) 
{
	FlexDateWin.setdatetime(tt,obj,isTop);
}

/**
显示日期选择框 返回日期<br>
setdayfmt(this,[object])和setdayfmt(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、<input name=txt><input type=button value=setdayfmt onclick="setdayfmt(this,document.all.txt)"><br>
 二、<input onfocus="setdayfmt(this)"><br>
*/
function setdayfmt(tt,obj,fmt,isTop)
{
	FlexDateWin.setdayfmt(tt,obj,fmt,isTop);
}

/**
FlexDate End
*/



/**
FlexDateCtl 
*/

/**
获得当前时间 HH:NN:SS
*/
function CurrentTime()
{ 
    return ToStrTime(new Date());
} 

function ToStrTime(t)
{
    var now = t; 
    var hh = 0+now.getHours(); 
    var mm = 0+now.getMinutes(); 
    var ss = 0+now.getTime() % 60000; 
	ss = (ss - (ss % 1000)) / 1000; 

    var clock = "";
	if(hh <10) clock += '0';
    clock += ''+hh+':'; 
    if (mm < 10) clock += '0'; 
    clock += ''+mm+':'; 
    if (ss < 10) clock += '0'; 
    clock += ''+ss; 

    return(clock); 
	
}

/**
获取当前日期 YYYY-MM-DD
*/
function CurrentDate()
{
    return ToStrDate(new Date());
}

function ToStrDate(t)
{
    var now = t; 
    var yy = now.getYear(); 
    var mm = now.getMonth()+1; 
	if(mm  <10) mm = "0" +mm;
	var dd = now.getDate();
	if(dd <10) dd = "0" +dd;

	var currdate = '' + yy + "-" + mm +"-"+dd;
	return currdate;
	
}
/**
获取当前日期时间 YYYY-MM-DD HH:NN:SS
*/
function CurrentDateTime()
{
	return ToStrDateTime(new Date());
}

function ToStrDateTime(t)
{
	var currdatetime = ToStrDate(t)+" "+ToStrTime(t);
	return currdatetime;
	
}
/**
获取当前时间串 HHNNSS
*/
function CurrentTimeStr()
{ 
    var now = new Date(); 
    var hh = 0+now.getHours(); 
    var mm = 0+now.getMinutes(); 
    var ss = 0+now.getTime() % 60000; 
    ss = (ss - (ss % 1000)) / 1000; 

    /*var clock = ''+hh; 
    if (mm < 10) clock += '0'; 
    clock += mm; 
    if (ss < 10) clock += '0'; 
    clock += ss;*/

	var clock = '';
    if (hh < 10) clock += '0'; 
    clock += hh; 
    if (mm < 10) clock += '0'; 
    clock += mm; 
    if (ss < 10) clock += '0'; 
    clock += ss;

    return(clock); 
} 

/**
获取当前日期串 YYYYMMDD
*/
function CurrentDateStr()
{
    var now = new Date(); 
    var yy = now.getYear(); 
    var mm = now.getMonth()+1; 
	if(mm  <10) mm = "0" +mm;
	var dd = now.getDate();
	if(dd <10) dd = "0" +dd;

	var currdate = ''+ yy + mm +dd;
	return currdate;
}


/*
获取当前日期时间串 YYYYMMDDHHNNSS
*/
function CurrentDateTimeStr()
{
	var currdatetime = CurrentDateStr() +CurrentTimeStr();
	return currdatetime;
}

/**
把日期时间格式转换成无格式串 
*/
function DateTimeFmtToStr(dt)
{
	var str ="";
	for(var i=0;i<dt.length;i++)
    {
		if(dt.charAt(i) =="-" || dt.charAt(i) ==" " || dt.charAt(i) ==':') continue;
		str += dt.charAt(i);
	}
    return str;
}

/**
把无格式串转换成日期时间格式
*/
function StrToDateTimeFmt(dt)
{
	var str ="";
	for(var i=0;i<dt.length;i++)
    {
		if(i==4 || i==6 ) str +="-";
		if(i==8) str +=" ";
		if(i==10 || i==12 ) str +=":";
		str += dt.charAt(i);
	}
    return str;
}

      function GuangBiao()
     {             
         document.getElementById("regtime1").focus();                     
     }
     function GuangBiao2()
     {
        var add1=document.getElementById("regtime1").value;
        var add2=document.getElementById("regtime2").value;
        if(add2==""&&add1!="")
        {
           document.getElementById("regtime2").focus() ; 
        }          
     }
     function GuangBiaoTwo()
     {
         document.getElementById("regtime2").focus() ; 
     }



/**
----------------------------------------------------------------------------<br>
 日历 Javascript 页面脚本控件，适用于微软的 IE （5.0以上）浏览器<br>
 主调用函数是 FlexDateWin.setday(this,[object])和setday(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、<input name=txt><input type=button value=FlexDateWin.setday onclick="FlexDateWin.setday(this,document.all.txt)"><br>
 二、<input onfocus="FlexDateWin.setday(this)"><br>
 本日历的年份限制是（1000 - 9999）<br>
 按ESC键关闭该控件<br>
 在年和月的显示地方点击时会分别出年与月的下拉框<br>
 控件外任意点击一点即可关闭该控件<br>
<br>
<br>
***************************************************************************<br>
* 选择时间和日期的JavaScript页面脚本控件，适用于微软的 IE （5.0以上）浏览器 <br>
* 调用函数是sel_time(timeName,timeSel,isDisabled,show),直接输出日期和时间控件,使<br>
* 用timeName.value即可获得选中的日期和时间。在日期选择的text控件中已经引用上面的setday <br>
* <br>
* 版本 1.01 <br>
* 参数: timeName: 整个控件包含隐藏表单的名字，也会做为3个分控件的前缀 <br>
* timeSel: 3个分控件预先显示的内容 <br>
* isDisabled：3个分控件是否disabled <br>
* show： 一个附加属性，用途自定义<br>
***************************************************************************<br>
说明：<br>
1.受到iframe的限制，如果拖动出日历窗口，则日历会停止移动。<br>
<br>
*/
function FlexDateWin()
{

}
//==================================================== 参数设定部分 =======================================================
FlexDateWin.bMoveable=true; //设置日历是否可以拖动
FlexDateWin._VersionInfo="Version:2.0&#13;2.0作者:walkingpoison&#13;1.0作者: F.R.Huang(meizz)&#13;MAIL: meizz@hzcnc.com" //版本信息

//==================================================== WEB 页面显示部分 =====================================================
FlexDateWin.init = function()
{
	document.writeln('<iframe id=calendarDateLayer  frameborder=0 style="position: absolute; width: 148px; height: 236px; z-index: 9998; display: none"></iframe>');
	var strFrame; //存放日历层的HTML代码
	strFrame='<style>';
	strFrame+='INPUT.button{BORDER-RIGHT: #99CCFF 1px solid;BORDER-TOP: #99CCFF 1px solid;BORDER-LEFT: #99CCFF 1px solid;';
	strFrame+='BORDER-BOTTOM: #99CCFF 1px solid;BACKGROUND-COLOR: #fff8ec;font-family:宋体;}';
	strFrame+='TD{FONT-SIZE: 9pt;font-family:宋体;}';
	strFrame+='</style>';
	strFrame+='<scr' + 'ipt>';
	strFrame+='var datelayerx,datelayery; /*存放日历控件的鼠标位置*/';
	strFrame+='var bDrag; /*标记是否开始拖动*/';
	strFrame+='function document.onmousemove() /*在鼠标移动事件中，如果开始拖动日历，则移动日历*/';
	strFrame+='{if(bDrag && window.event.button==1)';
	strFrame+=' {var DateLayer=parent.document.all.calendarDateLayer.style;';
	strFrame+=' DateLayer.posLeft += window.event.clientX-datelayerx;/*由于每次移动以后鼠标位置都恢复为初始的位置，因此写法与div中不同*/';
	strFrame+=' DateLayer.posTop += window.event.clientY-datelayery;}}';
	strFrame+='function DragStart() /*开始日历拖动*/';
	strFrame+='{var DateLayer=parent.document.all.calendarDateLayer.style;';
	strFrame+=' datelayerx=window.event.clientX;';
	strFrame+=' datelayery=window.event.clientY;';
	strFrame+=' bDrag=true;}';
	strFrame+='function DragEnd(){ /*结束日历拖动*/';
	strFrame+=' bDrag=false;}';
	strFrame+='</scr' + 'ipt>';
	strFrame+='<div style="z-index:9999;position: absolute; left:0; top:0;" onselectstart="return false"><span id=tmpSelectYearLayer  style="z-index: 9999;position: absolute;top: 3; left: 19;display: none"></span>';
	strFrame+='<span id=tmpSelectMonthLayer  style="z-index: 9999;position: absolute;top: 3px; left: 78px;display: none"></span>';
	strFrame+='<span id=tmpSelectHourLayer  style="z-index: 9999;position: absolute;top: 28px; left: 2px;display: none"></span>';
	strFrame+='<span id=tmpSelectMinuteLayer  style="z-index: 9999;position: absolute;top: 28px; left: 45px;display: none"></span>';
	strFrame+='<span id=tmpSelectSecondLayer  style="z-index: 9999;position: absolute;top: 28px; left: 90px;display: none"></span>';
	strFrame+='<table border=1 cellspacing=0 cellpadding=0 width=142 height=180 bordercolor=#99CCFF bgcolor=#99CCFF >';
	strFrame+=' <tr ><td width=142 height=23  bgcolor=#FFFFFF><table border=0 cellspacing=1 cellpadding=0 width=140  height=23>';
	strFrame+=' <tr align=center ><td width=16 align=center bgcolor=#99CCFF style="font-size:12px;cursor: hand;color: #ffffff" ';
	strFrame+=' onclick="parent.FlexDateWin.calendarPrevM()" title="向前翻 1 月" ><b >&lt;</b>';
	strFrame+=' </td><td width=60 align=center style="font-size:12px;cursor:default"  ';
	strFrame+='onmouseover="style.backgroundColor=\'#99ccff\'" onmouseout="style.backgroundColor=\'white\'" ';
	strFrame+='onclick="parent.FlexDateWin.tmpSelectYearInnerHTML(this.innerText.substring(0,4))" title="点击这里选择年份"><span  id=calendarYearHead></span></td>';
	strFrame+='<td width=48 align=center style="font-size:12px;cursor:default"  onmouseover="style.backgroundColor=\'#99ccff\'" ';
	strFrame+=' onmouseout="style.backgroundColor=\'white\'" onclick="parent.FlexDateWin.tmpSelectMonthInnerHTML(this.innerText.length==3?this.innerText.substring(0,1):this.innerText.substring(0,2))"';
	strFrame+=' title="点击这里选择月份"><span id=calendarMonthHead ></span></td>';
	strFrame+=' <td width=16 bgcolor=#99CCFF align=center style="font-size:12px;cursor: hand;color: #ffffff" ';
	strFrame+=' onclick="parent.FlexDateWin.calendarNextM()" title="向后翻 1 月" ><b >&gt;</b></td></tr>';
	strFrame+=' </table></td></tr>';

	strFrame+=' <tr ><td width=142 height=23  bgcolor=#FFFFFF><table border=0 cellspacing=1 cellpadding=0 width=140  height=23>';
	strFrame+=' <tr align=center >'
	strFrame+=' <td width=4 align=center bgcolor=#99CCFF style="font-size:12px;color: #ffffff" ><b ></b></td>';
	strFrame+=' <td width=60 align=center style="font-size:12px;cursor:default"  ';
	strFrame+='onmouseover="style.backgroundColor=\'#99ccff\'" onmouseout="style.backgroundColor=\'white\'" ';
	strFrame+='onclick="parent.FlexDateWin.tmpSelectHourInnerHTML(this.innerText.length==3?this.innerText.substring(0,1):this.innerText.substring(0,2))" title="点击这里选择时"><span  id=calendarHourHead></span></td>';
	strFrame+=' <td width=60 align=center style="font-size:12px;cursor:default"  ';
	strFrame+='onmouseover="style.backgroundColor=\'#99ccff\'" onmouseout="style.backgroundColor=\'white\'" ';
	strFrame+='onclick="parent.FlexDateWin.tmpSelectMinuteInnerHTML(this.innerText.length==3?this.innerText.substring(0,1):this.innerText.substring(0,2))" title="点击这里选择分"><span  id=calendarMinuteHead></span></td>';
	strFrame+=' <td width=60 align=center style="font-size:12px;cursor:default"  ';
	strFrame+='onmouseover="style.backgroundColor=\'#99ccff\'" onmouseout="style.backgroundColor=\'white\'" ';
	strFrame+='onclick="parent.FlexDateWin.tmpSelectSecondInnerHTML(this.innerText.length==3?this.innerText.substring(0,1):this.innerText.substring(0,2))" title="点击这里选择秒"><span  id=calendarSecondHead></span></td>';
	strFrame+=' <td width=4 align=center bgcolor=#99CCFF style="font-size:12px;color: #ffffff" ><b ></b></td>';
	strFrame+=' </table></td></tr>';

	strFrame+=' <tr ><td width=142 height=18 >';
	strFrame+='<table border=1 cellspacing=0 cellpadding=0 bgcolor=#99CCFF ' + (FlexDateWin.bMoveable? 'onmousedown="DragStart()" onmouseup="DragEnd()"':'');
	strFrame+=' BORDERCOLORLIGHT=#99CCFF BORDERCOLORDARK=#FFFFFF width=140 height=20  style="cursor:' + (FlexDateWin.bMoveable ? 'move':'default') + '">';
	strFrame+='<tr  align=center valign=bottom><td style="font-size:12px;color:#FFFFFF" >日</td>';
	strFrame+='<td style="font-size:12px;color:#FFFFFF" >一</td><td style="font-size:12px;color:#FFFFFF" >二</td>';
	strFrame+='<td style="font-size:12px;color:#FFFFFF" >三</td><td style="font-size:12px;color:#FFFFFF" >四</td>';
	strFrame+='<td style="font-size:12px;color:#FFFFFF" >五</td><td style="font-size:12px;color:#FFFFFF" >六</td></tr>';
	strFrame+='</table></td></tr><!-- Author:F.R.Huang(calendar) http://www.calendar.com/ mail: calendar@hzcnc.com 2002-10-8 -->';
	strFrame+=' <tr ><td width=142 height=120 >';
	strFrame+=' <table border=1 cellspacing=2 cellpadding=0 BORDERCOLORLIGHT=#99CCFF BORDERCOLORDARK=#FFFFFF bgcolor=#fff8ec width=140 height=120 >';
	var n=0; for (var j=0;j<5;j++){ strFrame+= ' <tr align=center >'; for (i=0;i<7;i++){
	strFrame+='<td width=20 height=20 id=calendarDay'+n+' style="font-size:12px"  onclick=parent.FlexDateWin.calendarDayClick(this.innerText,0)></td>';n++;}
	strFrame+='</tr>';}
	strFrame+=' <tr align=center >';
	for (var i=35;i<39;i++)strFrame+='<td width=20 height=20 id=calendarDay'+i+' style="font-size:12px"  onclick="parent.FlexDateWin.calendarDayClick(this.innerText,0)"></td>';
	strFrame+=' <td colspan=3 align=right ><span onclick=parent.FlexDateWin.closeLayer() style="font-size:12px;cursor: hand"';
	strFrame+='  title="' + FlexDateWin._VersionInfo + '"><u>关闭</u></span>&nbsp;</td></tr>';
	strFrame+=' </table></td></tr><tr ><td >';
	strFrame+=' <table border=0 cellspacing=1 cellpadding=0 width=100%  bgcolor=#FFFFFF>';
	strFrame+=' <tr ><td  align=left><input  type=button class=button value="<<" title="向前翻 1 年" onclick="parent.FlexDateWin.calendarPrevY()" ';
	strFrame+=' onfocus="this.blur()" style="font-size: 12px; height: 20px"><input  class=button title="向前翻 1 月" type=button ';
	strFrame+=' value="<" onclick="parent.FlexDateWin.calendarPrevM()" onfocus="this.blur()" style="font-size: 12px; height: 20px"></td><td ';
	strFrame+='  align=center><input  type=button class=button value="今天" onclick="parent.FlexDateWin.calendarToday()" ';
	strFrame+=' onfocus="this.blur()" title="当前日期" style="font-size: 12px; height: 20px; cursor:hand"></td><td ';
	strFrame+='  align=center><input  type=button class=button value="现在" onclick="parent.FlexDateWin.calendarNow()" ';
	strFrame+=' onfocus="this.blur()" title="当前日期" style="font-size: 12px; height: 20px; cursor:hand"></td><td ';
	strFrame+='  align=right><input  type=button class=button value=">" onclick="parent.FlexDateWin.calendarNextM()" ';
	strFrame+=' onfocus="this.blur()" title="向后翻 1 月" class=button style="font-size: 12px; height: 20px"><input ';
	strFrame+='  type=button class=button value=">>" title="向后翻 1 年" onclick="parent.FlexDateWin.calendarNextY()"';
	strFrame+=' onfocus="this.blur()" style="font-size: 12px; height: 20px"></td>';
	strFrame+='</tr></table></td></tr></table></div>';

	window.frames.calendarDateLayer.document.writeln(strFrame);
	window.frames.calendarDateLayer.document.close(); //解决ie进度条不结束的问题
}

FlexDateWin.init();

//==================================================== WEB 页面显示部分 ======================================================
FlexDateWin.outObject = null;
FlexDateWin.outButton = null; //点击的按钮
FlexDateWin.outDate=""; //存放对象的日期
FlexDateWin.odatelayer=window.frames.calendarDateLayer.document.all; //存放日历对象
FlexDateWin.outDateFmt='date';//date = yyyy-mm-dd ;datestr=yyyymmdd ;datetime=yyyy-mm-dd 00:00:00;datetimestr=yyyymmdd000000

/**
显示日期选择框 返回年月<br>
FlexDateWin.setmonth(this,[object])和setmonth(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、&lt;input name=txt&gt;&lt;input type=button value=FlexDateWin.setmonth onclick="FlexDateWin.setmonth(this,document.all.txt)"&gt;<br>
 二、&lt;input onfocus="FlexDateWin.setmonth(this)"&gt;<br>
*/
FlexDateWin.setmonth= function(tt,obj,isTop) //主调函数
{
	if (arguments.length > 3){alert("对不起！传入本控件的参数太多！");return;}
	if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
	FlexDateWin.outDateFmt='yearmonth';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//xl:

FlexDateWin.setyear= function(tt,obj,isTop) //主调函数
{
	if (arguments.length > 3){alert("对不起！传入本控件的参数太多！");return;}
	if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
	FlexDateWin.outDateFmt='year';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//xl:
FlexDateWin.sethour= function(tt,obj,isTop) //主调函数
{
	if (arguments.length > 3){alert("对不起！传入本控件的参数太多！");return;}
	if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
	FlexDateWin.outDateFmt='yearmonthhour';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//xl:
FlexDateWin.sethouronly= function(tt,obj,isTop) //主调函数
{
	if (arguments.length > 3){alert("对不起！传入本控件的参数太多！");return;}
	if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
	FlexDateWin.outDateFmt='yearmonthhouronly';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//xl:
FlexDateWin.setminuteonly= function(tt,obj,isTop) //主调函数
{
	if (arguments.length > 3){alert("对不起！传入本控件的参数太多！");return;}
	if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
	FlexDateWin.outDateFmt='yearmonthhourminuteonly';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//～～～～～～～～～～～

/**
显示日期选择框 返回年月日<br>
FlexDateWin.setday(this,[object])和setday(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、&lt;input name=txt&gt;&lt;input type=button value=FlexDateWin.setday onclick="FlexDateWin.setday(this,document.all.txt)"&gt;<br>
 二、&lt;input onfocus="FlexDateWin.setday(this)"&gt;<br>
*/
FlexDateWin.setday= function(tt,obj,isTop) //主调函数
{
	if (arguments.length > 3){alert("对不起！传入本控件的参数太多！");return;}
	if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
	FlexDateWin.outDateFmt='date';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

/**
显示日期选择框 返回日期时间<br>
FlexDateWin.setdatetime(this,[object])和setdatetime(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、&lt;input name=txt&gt;&lt;input type=button value=FlexDateWin.setdatetime onclick="FlexDateWin.setdatetime(this,document.all.txt)"&gt;<br>
 二、&lt;input onfocus="FlexDateWin.setdatetime(this)"&gt;<br>
*/
FlexDateWin.setdatetime= function(tt,obj,isTop) //主调函数
{
	if (arguments.length > 3){alert("对不起！传入本控件的参数太多！");return;}
	if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
	FlexDateWin.outDateFmt='datetime';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

FlexDateWin.setdatehhnn= function(tt,obj,isTop) //主调函数
{
	if (arguments.length > 3){alert("对不起！传入本控件的参数太多！");return;}
	if (arguments.length == 0){alert("对不起！您没有传回本控件任何参数！");return;}
	FlexDateWin.outDateFmt='datehhnn';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}


/**
显示日期选择框 返回日期<br>
FlexDateWin.setdayfmt(this,[object])和setdayfmt(this)，[object]是控件输出的控件名，举两个例子：<br>
 一、&lt;input name=txt&gt;&lt;input type=button value=FlexDateWin.setdayfmt onclick="FlexDateWin.setdayfmt(this,document.all.txt)"&gt;<br>
 二、&lt;input onfocus="FlexDateWin.setdayfmt(this)"&gt;<br>
*/
FlexDateWin.setdayfmt= function(tt,obj,fmt,isTop) //主调函数
{
	if (arguments.length !=4 ){alert("对不起！传入本控件的参数不正确！");return;}
	FlexDateWin.outDateFmt=fmt;
	var dads = document.all.calendarDateLayer.style;
	var th = tt;
	if(tt==null) tt = obj;
	if(obj==null) obj = tt;
	var ttop = tt.offsetTop; //TT控件的定位点高
	var thei = tt.clientHeight; //TT控件本身的高
	var tleft = tt.offsetLeft; //TT控件的定位点宽
	var ttyp = tt.type; //TT控件的类型
	while (tt = tt.offsetParent){ttop+=tt.offsetTop; tleft+=tt.offsetLeft;}
	var whei = typeof(window.dialogHeight)=="undefined"?parseInt(document.body.offsetHeight):parseInt(window.dialogHeight);
	
	//alert(whei);
	//alert(document.body.currentStyle.height);
	
	if ( isTop == false ) //顶点在屏幕上
	{ 
	  dads.top =  0;
	  //alert(dads.top);
	}
    else if (isTop == true) //在控件上方
    {
	  dads.top = ttop - 236;
	//  alert(dads.top);
	}
	else　// 在控件下放
	  dads.top = (ttyp=="image")? ttop+thei : ttop+thei+6;
	dads.left = tleft;
	FlexDateWin.outObject =  obj;
	FlexDateWin.outButton =  th; //设定外部点击的按钮

	var r = DateTimeFmtToStr(FlexDateWin.outObject.value);
	var calendarTheDay=1;
	if(r.length>=4)
		FlexDateWin.calendarTheYear= r.substr(0,4);
	if(r.length>=6)
	{
		FlexDateWin.calendarTheMonth= r.substr(4,2);
		FlexDateWin.calendarTheMonth = FlexDateWin.calendarTheMonth.replace(/^0+/,"");
	}
	
	if(r.length>=8)
		calendarTheDay= r.substr(6,2);
	if(r.length>=10)
		FlexDateWin.calendarTheHour= r.substr(8,2);
	if(r.length>=12)
		FlexDateWin.calendarTheMinute= r.substr(10,2);
	if(r.length>=14)
		FlexDateWin.calendarTheSecond= r.substr(12,2);

	FlexDateWin.outDate=new Date(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth-1,calendarTheDay,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond); //保存外部传入的日期

	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);

	/*
	//根据当前输入框的日期显示日历的年月
	var reg = /^(\d+)-(\d{1,2})-(\d{1,2})$/; 
	var r = FlexDateWin.outObject.value.match(reg); 
	if(r!=null)
	{
		r[2]=r[2]-1; 
		var d= new Date(r[1], r[2],r[3]); 
		if(d.getFullYear()==r[1] && d.getMonth()==r[2] && d.getDate()==r[3]){
			FlexDateWin.outDate=d; //保存外部传入的日期
		}
		else FlexDateWin.outDate="";
		FlexDateWin.calendarSetDay(r[1],r[2]+1);
	}
	else
	{
		FlexDateWin.outDate="";
		FlexDateWin.calendarSetDay(new Date().getFullYear(), new Date().getMonth() + 1);
	}

	*/
	dads.display = '';

	event.returnValue=false;
}

FlexDateWin.MonHead = new Array(12); //定义阳历中每个月的最大天数
FlexDateWin.MonHead[0] = 31; FlexDateWin.MonHead[1] = 28; FlexDateWin.MonHead[2] = 31; FlexDateWin.MonHead[3] = 30; FlexDateWin.MonHead[4] = 31; FlexDateWin.MonHead[5] = 30;
FlexDateWin.MonHead[6] = 31; FlexDateWin.MonHead[7] = 31; FlexDateWin.MonHead[8] = 30; FlexDateWin.MonHead[9] = 31; FlexDateWin.MonHead[10] = 30; FlexDateWin.MonHead[11] = 31;

FlexDateWin.calendarTheYear=new Date().getFullYear(); //定义年的变量的初始值
FlexDateWin.calendarTheMonth=new Date().getMonth()+1; //定义月的变量的初始值
FlexDateWin.calendarWDay=new Array(39); //定义写日期的数组
FlexDateWin.calendarTheHour = 0+(new Date().getHours());
FlexDateWin.calendarTheMinute = 0+(new Date().getMinutes());
FlexDateWin.calendarTheSecond = 0+(new Date().getTime()) % 60000; 
FlexDateWin.calendarTheSecond = (FlexDateWin.calendarTheSecond - (FlexDateWin.calendarTheSecond % 1000)) / 1000; 

document.onclick= function() //任意点击时关闭该控件 //ie6的情况可以由下面的切换焦点处理代替
{ 
	with(window.event)
	{ if (srcElement.getAttribute("Author")==null && srcElement != FlexDateWin.outObject && srcElement != FlexDateWin.outButton)
	FlexDateWin.closeLayer();
	}
}

document.onkeyup= function() //按Esc键关闭，切换焦点关闭
{
	if (window.event.keyCode==27){
	if(FlexDateWin.outObject)FlexDateWin.outObject.blur();
	FlexDateWin.closeLayer();
	}
	else if(document.activeElement)
	if(document.activeElement.getAttribute("Author")==null && document.activeElement != FlexDateWin.outObject && document.activeElement != FlexDateWin.outButton)
	{
	FlexDateWin.closeLayer();
	}
}

FlexDateWin.calendarWriteHead= function(yy,mm,hh,nn,ss) //往 head 中写入当前的年与月
{
	FlexDateWin.odatelayer.calendarYearHead.innerText = yy + " 年";
	FlexDateWin.odatelayer.calendarMonthHead.innerText = mm + " 月";
	FlexDateWin.odatelayer.calendarHourHead.innerText = hh + " 时";
	FlexDateWin.odatelayer.calendarMinuteHead.innerText = nn + " 分";
	FlexDateWin.odatelayer.calendarSecondHead.innerText = ss + " 秒";
}

FlexDateWin.tmpSelectYearInnerHTML= function(strYear) //年份的下拉框
{
	if (strYear.match(/\D/)!=null){alert("年份输入参数不是数字！");return;}
	var m = (strYear) ? strYear : new Date().getFullYear();
	if (m < 1000 || m > 9999) {alert("年份值不在 1000 到 9999 之间！");return;}
	var n = (new Date().getFullYear()) - 70;
	if (n < 1000) n = 1000;
	if (n + 26 > 9999) n = 9974;
	var s = "<select  name=tmpSelectYear style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectYearLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectYearLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheYear = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = n; i < n + 100; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='" + i + "' selected>" + i + "年" + "</option>\r\n";}
	else {selectInnerHTML += "<option  value='" + i + "'>" + i + "年" + "</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectYearLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectYearLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectYear.focus();
}

FlexDateWin.tmpSelectMonthInnerHTML= function(strMonth) //月份的下拉框
{
	if (strMonth.match(/\D/)!=null){alert("月份输入参数不是数字！");return;}
	var m = (strMonth) ? strMonth : new Date().getMonth() + 1;
	var s = "<select  name=tmpSelectMonth style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectMonthLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectMonthLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheMonth = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = 1; i < 13; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='"+i+"' selected>"+i+"月"+"</option>\r\n";}
	else {selectInnerHTML += "<option  value='"+i+"'>"+i+"月"+"</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectMonthLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectMonthLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectMonth.focus();
}



FlexDateWin.tmpSelectHourInnerHTML= function(strHour) //小时的下拉框
{
	if (strHour.match(/\D/)!=null){alert("时间输入参数不是数字！");return;}
	var m = (strHour) ? strHour : new Date().getMonth() + 1;
	var s = "<select  name=tmpSelectHour style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectHourLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectHourLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheHour = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = 0; i < 24; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='"+i+"' selected>"+i+"时"+"</option>\r\n";}
	else {selectInnerHTML += "<option  value='"+i+"'>"+i+"时"+"</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectHourLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectHourLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectHour.focus();
}

FlexDateWin.tmpSelectMinuteInnerHTML= function(strHour) //小时的下拉框
{
	if (strHour.match(/\D/)!=null){alert("时间输入参数不是数字！");return;}
	var m = (strHour) ? strHour : new Date().getMonth() + 1;
	var s = "<select  name=tmpSelectMinute style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectMinuteLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectMinuteLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheMinute = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = 0; i < 60; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='"+i+"' selected>"+i+"分"+"</option>\r\n";}
	else {selectInnerHTML += "<option  value='"+i+"'>"+i+"分"+"</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectMinuteLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectMinuteLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectMinute.focus();
}

FlexDateWin.tmpSelectSecondInnerHTML= function(strHour) //小时的下拉框
{
	if (strHour.match(/\D/)!=null){alert("时间输入参数不是数字！");return;}
	var m = (strHour) ? strHour : new Date().getMonth() + 1;
	var s = "<select  name=tmpSelectSecond style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectSecondLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectSecondLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheSecond = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = 0; i < 60; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='"+i+"' selected>"+i+"秒"+"</option>\r\n";}
	else {selectInnerHTML += "<option  value='"+i+"'>"+i+"秒"+"</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectSecondLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectSecondLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectSecond.focus();
}



FlexDateWin.closeLayer= function() //这个层的关闭
{
	document.all.calendarDateLayer.style.display="none";
	//GuangBiao2();
}

FlexDateWin.IsPinYear= function(year) //判断是否闰平年
{
	if (0==year%4&&((year%100!=0)||(year%400==0))) return true;else return false;
}

FlexDateWin.GetMonthCount= function(year,month) //闰年二月为29天
{
	var c=FlexDateWin.MonHead[month-1];if((month==2)&&FlexDateWin.IsPinYear(year)) c++;return c;
}
FlexDateWin.GetDOW= function(day,month,year) //求某天的星期几
{
	var dt=new Date(year,month-1,day).getDay()/7; return dt;
}

FlexDateWin.calendarPrevY= function() //往前翻 Year
{
	if(FlexDateWin.calendarTheYear > 999 && FlexDateWin.calendarTheYear <10000){FlexDateWin.calendarTheYear--;}
	else{alert("年份超出范围（1000-9999）！");}
	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);
}
FlexDateWin.calendarNextY= function() //往后翻 Year
{
	if(FlexDateWin.calendarTheYear > 999 && FlexDateWin.calendarTheYear <10000){FlexDateWin.calendarTheYear++;}
	else{alert("年份超出范围（1000-9999）！");}
	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);
}

FlexDateWin.calendarValue= function(today)
{
	var yy =""+FlexDateWin.calendarTheYear,mm = ""+FlexDateWin.calendarTheMonth,dd = ""+today,hh = ""+FlexDateWin.calendarTheHour,nn = ""+FlexDateWin.calendarTheMinute,ss=""+FlexDateWin.calendarTheSecond;
	if(mm.length < 2) mm = "0" + mm;
	if(hh.length <2)  hh = "0" + hh;
	if(nn.length < 2) nn = "0" + nn;
	if(ss.length < 2) ss = "0" + ss;

	if(dd.length < 2) dd = "0" + dd;

	if(FlexDateWin.outObject){
		FlexDateWin.outObject.value=yy + "-" + mm + "-" + dd;
	}
	if(FlexDateWin.outDateFmt == 'year')
	{
	    FlexDateWin.outObject.value = "" + yy;
	}
	if(FlexDateWin.outDateFmt == 'yearmonth')
	{
		FlexDateWin.outObject.value="" + yy + "-" + mm;
	}

	if(FlexDateWin.outDateFmt == 'yearmonthstr')
	{
		FlexDateWin.outObject.value="" + yy + mm;
	}
	
	//xl
	if(FlexDateWin.outDateFmt == 'yearmonthhour')
	{
	    FlexDateWin.outObject.value ="" + yy + "-" + mm + "-" + dd + " " + hh + ":00:00" ;
	}
	
	//xl
	if(FlexDateWin.outDateFmt == 'yearmonthhouronly')
	{
	    FlexDateWin.outObject.value ="" + yy + "-" + mm + "-" + dd + " " + hh;
	}	
	
	if(FlexDateWin.outDateFmt == 'date')
	{
		FlexDateWin.outObject.value="" + yy + "-" + mm + "-" + dd;
	}

	if(FlexDateWin.outDateFmt=='datestr' ) 
	{
		FlexDateWin.outObject.value="" + yy +  mm + dd;
	}

	if(FlexDateWin.outDateFmt=='datetimestr')
	{
		FlexDateWin.outObject.value="" + yy +  mm + dd + hh + nn + ss;
	}

	if(FlexDateWin.outDateFmt=='datetime')
	{
		FlexDateWin.outObject.value="" + yy +  "-" +mm + "-" + dd + " " + hh + ":" + nn + ":" + ss;
	}
	
	//xl
	if(FlexDateWin.outDateFmt=='datehhnn')
	{
		FlexDateWin.outObject.value="" + yy +  "-" +mm + "-" + dd + " " + hh + ":" + nn + ":00";
	}
	//xl
	if(FlexDateWin.outDateFmt=='yearmonthhourminuteonly')
	{
		FlexDateWin.outObject.value="" + yy +  "-" +mm + "-" + dd + " " + hh + ":" + nn;
	}
	
	FlexDateWin.closeLayer();
	if(typeof(onSelectedDateTime) != 'undefined')
	{
		onSelectedDateTime(FlexDateWin.outObject,FlexDateWin.outObject.value);
	}

}
FlexDateWin.calendarToday= function() //Today Button
{
	var today;
	FlexDateWin.calendarTheYear = new Date().getFullYear();
	FlexDateWin.calendarTheMonth = new Date().getMonth()+1;
	FlexDateWin.calendarTheHour = 0;
	FlexDateWin.calendarTheMinute = 0;
	FlexDateWin.calendarTheSecond = 0; 
	today=new Date().getDate();
	//FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth);
	FlexDateWin.calendarValue(today);

}
FlexDateWin.calendarNow= function() //Now Button
{
	FlexDateWin.calendarTheYear=new Date().getFullYear(); //定义年的变量的初始值
	FlexDateWin.calendarTheMonth=new Date().getMonth()+1; //定义月的变量的初始值
	FlexDateWin.calendarTheHour = 0+(new Date().getHours());
	FlexDateWin.calendarTheMinute = 0+(new Date().getMinutes());
	FlexDateWin.calendarTheSecond = 0+(new Date().getTime()) % 60000; 
	FlexDateWin.calendarTheSecond = (FlexDateWin.calendarTheSecond - (FlexDateWin.calendarTheSecond % 1000)) / 1000; 
	var today;
	today=new Date().getDate();
	//FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth);
	FlexDateWin.calendarValue(today);

}
FlexDateWin.calendarPrevM= function() //往前翻月份
{
	if(FlexDateWin.calendarTheMonth>1){FlexDateWin.calendarTheMonth--}else{FlexDateWin.calendarTheYear--;FlexDateWin.calendarTheMonth=12;}
	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);
}
FlexDateWin.calendarNextM= function() //往后翻月份
{
	if(FlexDateWin.calendarTheMonth==12){FlexDateWin.calendarTheYear++;FlexDateWin.calendarTheMonth=1}else{FlexDateWin.calendarTheMonth++}
	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);
}

FlexDateWin.calendarSetDay= function(yy,mm,hh,nn,ss) //主要的写程序**********
{
	FlexDateWin.calendarWriteHead(yy,mm,hh,nn,ss);
	//设置当前年月的公共变量为传入值
	FlexDateWin.calendarTheYear=yy;
	FlexDateWin.calendarTheMonth=mm;
	for (var i = 0; i < 39; i++){FlexDateWin.calendarWDay[i]=""}; //将显示框的内容全部清空
	var day1 = 1,day2=1,firstday = new Date(yy,mm-1,1).getDay(); //某月第一天的星期几
	for (i=0;i<firstday;i++)FlexDateWin.calendarWDay[i]=FlexDateWin.GetMonthCount(mm==1?yy-1:yy,mm==1?12:mm-1)-firstday+i+1 //上个月的最后几天
	for (i = firstday; day1 < FlexDateWin.GetMonthCount(yy,mm)+1; i++){FlexDateWin.calendarWDay[i]=day1;day1++;}
	for (i=firstday+FlexDateWin.GetMonthCount(yy,mm);i<39;i++){FlexDateWin.calendarWDay[i]=day2;day2++}
	for (i = 0; i < 39; i++)
	{ var da = eval("FlexDateWin.odatelayer.calendarDay"+i) //书写新的一个月的日期星期排列
	if (FlexDateWin.calendarWDay[i]!="")
	{ 
	//初始化边框
	da.borderColorLight="#99CCFF";
	da.borderColorDark="#FFFFFF";
	if(i<firstday) //上个月的部分
	{
	da.innerHTML="<b><font color=gray>" + FlexDateWin.calendarWDay[i] + "</font></b>";
	da.title=(mm==1?12:mm-1) +"月" + FlexDateWin.calendarWDay[i] + "日";
	da.onclick=Function("FlexDateWin.calendarDayClick(this.innerText,-1)");
	if(!FlexDateWin.outDate)
	da.style.backgroundColor = ((mm==1?yy-1:yy) == new Date().getFullYear() && 
	(mm==1?12:mm-1) == new Date().getMonth()+1 && FlexDateWin.calendarWDay[i] == new Date().getDate()) ?
	"#99ccff":"#e0e0e0";
	else
	{
	da.style.backgroundColor =((mm==1?yy-1:yy)==FlexDateWin.outDate.getFullYear() && (mm==1?12:mm-1)== FlexDateWin.outDate.getMonth() + 1 && 
	FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())? "#ff9900" :
	(((mm==1?yy-1:yy) == new Date().getFullYear() && (mm==1?12:mm-1) == new Date().getMonth()+1 && 
	FlexDateWin.calendarWDay[i] == new Date().getDate()) ? "#99ccff":"#e0e0e0");
	//将选中的日期显示为凹下去
	if((mm==1?yy-1:yy)==FlexDateWin.outDate.getFullYear() && (mm==1?12:mm-1)== FlexDateWin.outDate.getMonth() + 1 && 
	FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())
	{
	da.borderColorLight="#FFFFFF";
	da.borderColorDark="#99CCFF";
	}
	}
	}
	else if (i>=firstday+FlexDateWin.GetMonthCount(yy,mm)) //下个月的部分
	{
	da.innerHTML="<b><font color=gray>" + FlexDateWin.calendarWDay[i] + "</font></b>";
	da.title=(mm==12?1:mm+1) +"月" + FlexDateWin.calendarWDay[i] + "日";
	da.onclick=Function("FlexDateWin.calendarDayClick(this.innerText,1)");
	if(!FlexDateWin.outDate)
	da.style.backgroundColor = ((mm==12?yy+1:yy) == new Date().getFullYear() && 
	(mm==12?1:mm+1) == new Date().getMonth()+1 && FlexDateWin.calendarWDay[i] == new Date().getDate()) ?
	"#99ccff":"#e0e0e0";
	else
	{
	da.style.backgroundColor =((mm==12?yy+1:yy)==FlexDateWin.outDate.getFullYear() && (mm==12?1:mm+1)== FlexDateWin.outDate.getMonth() + 1 && 
	FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())? "#ff9900" :
	(((mm==12?yy+1:yy) == new Date().getFullYear() && (mm==12?1:mm+1) == new Date().getMonth()+1 && 
	FlexDateWin.calendarWDay[i] == new Date().getDate()) ? "#99ccff":"#e0e0e0");
	//将选中的日期显示为凹下去
	if((mm==12?yy+1:yy)==FlexDateWin.outDate.getFullYear() && (mm==12?1:mm+1)== FlexDateWin.outDate.getMonth() + 1 && 
	FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())
	{
	da.borderColorLight="#FFFFFF";
	da.borderColorDark="#99CCFF";
	}
	}
	}
	else //本月的部分
	{
	da.innerHTML="<b>" + FlexDateWin.calendarWDay[i] + "</b>";
	da.title=mm +"月" + FlexDateWin.calendarWDay[i] + "日";
	da.onclick=Function("FlexDateWin.calendarDayClick(this.innerText,0)"); //给td赋予onclick事件的处理
	//如果是当前选择的日期，则显示亮蓝色的背景；如果是当前日期，则显示暗黄色背景
	if(!FlexDateWin.outDate)
	da.style.backgroundColor = (yy == new Date().getFullYear() && mm == new Date().getMonth()+1 && FlexDateWin.calendarWDay[i] == new Date().getDate())?
	"#99ccff":"#e0e0e0";
	else
	{
	da.style.backgroundColor =(yy==FlexDateWin.outDate.getFullYear() && mm== FlexDateWin.outDate.getMonth() + 1 && FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())?
	"#ff9900":((yy == new Date().getFullYear() && mm == new Date().getMonth()+1 && FlexDateWin.calendarWDay[i] == new Date().getDate())?
	"#99ccff":"#e0e0e0");
	//将选中的日期显示为凹下去
	if(yy==FlexDateWin.outDate.getFullYear() && mm== FlexDateWin.outDate.getMonth() + 1 && FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())
	{
	da.borderColorLight="#FFFFFF";
	da.borderColorDark="#99CCFF";
	}
	}
	}
	da.style.cursor="hand"
	}
	else{da.innerHTML="";da.style.backgroundColor="";da.style.cursor="default"}
	}
}

FlexDateWin.calendarDayClick= function(n,ex) //点击显示框选取日期，主输入函数*************
{
	var yy=FlexDateWin.calendarTheYear;
	//alert(FlexDateWin.calendarTheMonth)
	var mm = parseInt(FlexDateWin.calendarTheMonth)+ex; //ex表示偏移量，用于选择上个月份和下个月份的日期
	//判断月份，并进行对应的处理
	if(mm<1){
	yy--;
	mm=12+mm;
	}
	else if(mm>12){
	yy++;
	mm=mm-12;
	}

	if (FlexDateWin.outObject)
	{
	if (!n) {//FlexDateWin.outObject.value=""; 
	return;}
	FlexDateWin.outObject.value= yy + "-" + mm + "-" + n ; //注：在这里你可以输出改成你想要的格式
	FlexDateWin.calendarTheYear=yy; //定义年的变量的初始值
	FlexDateWin.calendarTheMonth=mm; //定义月的变量的初始值
	//FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth);
	FlexDateWin.calendarValue(n);

	//FlexDateWin.outObject.focus();
	}
	else {FlexDateWin.closeLayer(); alert("您所要输出的控件对象并不存在！");}
}

/**********************************************************************************
函数sel_time

版本 1.01
参数: timeName: 整个控件包含隐藏表单的名字，也会做为3个分控件的前缀
timeSel: 3个分控件预先显示的内容
isDisabled：3个分控件是否disabled
show: 一个多余字段，可以用来写你自己的东西
***********************************************************************************/
FlexDateWin.sel_time= function(timeName,timeSel,isDisabled,show){
	var hour=0;
	var min=0;
	//alert(hourSel+" "+minSel);
	//alert(houName+" "+minName);
	//alert(isDisabled);
	//alert(hourSel+" "+minSel);
	//alert(hourSel.length+" "+minSel.length)
	///////////////////////取得timeSel中的日期和时间///////////////////////////
	var dateSel="",hourSel="",minSel="";
	var arry1,arry2;
	if (timeSel!="")
	{
	arry1=timeSel.split(" ");
	dateSel=arry1[0];
	if (arry1[1]==null){arry1[1]='00:00:00';}
	arry2=arry1[1].split(":");
	hourSel=arry2[0];
	minSel=arry2[1];
	if (hourSel.length<2)
	{
	hourSel="0"+hourSel;
	}
	if (minSel.length<2)
	{
	minSel="0"+minSel;
	}
	}
	/////////////////////////////////////////////////////////////////////////

	//输出3个日期分控件
	//输出日期控件
	document.write("<input name="+timeName+"_date type='text' readonly onclick='FlexDateWin.setday(this);' show='"+show+"' size=10 value='"+dateSel+"' "+isDisabled+" onfocus='FlexDateWin.setHidden("+timeName+"_date,"+timeName+"_hou,"+timeName+"_min,"+timeName+")'>&nbsp;");
	//输出小时控件
	document.write("<select name="+timeName+"_hou size=1 "+isDisabled+" onchange='FlexDateWin.setHidden("+timeName+"_date,"+timeName+"_hou,"+timeName+"_min,"+timeName+")'>");
	for(;hour<24;hour++){
	if(hour<10) hour="0"+hour;
	document.write("<option value="+hour)
	if(hour==hourSel) document.write(" selected");
	document.write(">"+hour+"</option>");

	}

	document.write("</select>时&nbsp;");
	//输出分钟控件
	document.write("<select name="+timeName+"_min size=1 "+isDisabled+" onchange='FlexDateWin.setHidden("+timeName+"_date,"+timeName+"_hou,"+timeName+"_min,"+timeName+")'>");
	for(;min<60;min++){
	if(min<10) min="0"+min;
	document.write("<option value="+min)
	if(min==minSel) document.write(" selected");
	document.write(" "+isDisabled+" >"+min+"</option>");
	}
	document.write("</select>分");
	//输出隐藏区域
	document.write("<input name="+timeName+" type=hidden value='"+timeSel+"'>");
	//FlexDateWin.setHidden(timeName+"_date,"+timeName+"_hou,"+timeName+"_min,"+timeName);
}

FlexDateWin.setHidden = function(t,s1,s2,h){
	//alert(t.value);
	h.value=t.value+" "+s1.value+":"+s2.value+":00";
}

FlexDateWin.sd = function(){
	if (s.value!=""){
	alert('您选择的时间是:'+s.value);
	}
	else{
	alert('您还没有选择时间')
	}
}

/*
</head>

<body>
<script language="JavaScript">
<!--
FlexDateWin.sel_time("s","","","")
//-->
</script>
<form method=post action="">
<input type="button" value="点击显示您选择的时间" onclick="FlexDateWin.sd();">
</form>
</body>
</html>
*/
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.date.js");