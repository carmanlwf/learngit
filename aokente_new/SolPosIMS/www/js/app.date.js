/*
�÷���
1.��ҳ���ϼ��룺
<script src="../js/app.date.js" language=javascript charset ="gb2312"></script>
function onSelectedDateTime(obj,datetime)
{

}
2.isTop����: true:�ڿؼ��Ϸ���ʾ ; Ϊ�ձ�ʾ�ڿؼ��·���ʾ
*/

/*
FlexDate
*/


/**
xl:�����꣺yyyy
*/
function setyear(tt,obj,isTop)
{
    FlexDateWin.setyear(tt,obj,isTop);
}


/**
��ʾ����ѡ��� �������£�yyyy-mm<br>
FlexDateWin.setmonth(this,[object])��setmonth(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��<input name=txt><input type=button value=setmonth onclick="setmonth(this,document.all.txt)"><br>
 ����<input onfocus="setmonth(this)"><br>
*/
function setmonth(tt,obj,isTop) 
{
	FlexDateWin.setmonth(tt,obj,isTop);
}

/**
��ʾ����ѡ��� ���������գ�yyyy-mm-dd<br>
FlexDateWin.setday(this,[object])��setday(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��<input name=txt><input type=button value=setday onclick="setday(this,document.all.txt)"><br>
 ����<input onfocus="setday(this)"><br>
*/
function setday(tt,obj,isTop)
{
	FlexDateWin.setday(tt,obj,isTop);
}

/**
xl:����������Сʱ��yyyy-mm-dd hh:00:00
*/
function sethour(tt,obj,isTop)
{
    FlexDateWin.sethour(tt,obj,isTop);
}

/**
xl:����������Сʱ��yyyy-mm-dd hh
*/
function sethouronly(tt,obj,isTop)
{
    FlexDateWin.sethouronly(tt,obj,isTop);
}

/**
��ʾ����ѡ��� ����������Сʱ�֣�yyyy-mm-dd hh:nn:00<br>
FlexDateWin.setdatetime(this,[object])��setdatetime(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��<input name=txt><input type=button value=FlexDateWin.setdatetime onclick="setdatetime(this,document.all.txt)"><br>
 ����<input onfocus="setdatetime(this)"><br>
*/
function setdatehhnn(tt,obj,isTop) 
{
	FlexDateWin.setdatehhnn(tt,obj,isTop);
}

/**
xl:����������Сʱ�֣�yyyy-mm-dd hh:ss
*/
function setminuteonly(tt,obj,isTop)
{
    FlexDateWin.setminuteonly(tt,obj,isTop);
}

/**
��ʾ����ѡ��� ����������ʱ���룺yyyy-mm-dd hh:mm:ss<br>
FlexDateWin.setdatetime(this,[object])��setdatetime(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��<input name=txt><input type=button value=FlexDateWin.setdatetime onclick="setdatetime(this,document.all.txt)"><br>
 ����<input onfocus="setdatetime(this)"><br>
*/
function setdatetime(tt,obj,isTop) 
{
	FlexDateWin.setdatetime(tt,obj,isTop);
}

/**
��ʾ����ѡ��� ��������<br>
setdayfmt(this,[object])��setdayfmt(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��<input name=txt><input type=button value=setdayfmt onclick="setdayfmt(this,document.all.txt)"><br>
 ����<input onfocus="setdayfmt(this)"><br>
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
��õ�ǰʱ�� HH:NN:SS
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
��ȡ��ǰ���� YYYY-MM-DD
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
��ȡ��ǰ����ʱ�� YYYY-MM-DD HH:NN:SS
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
��ȡ��ǰʱ�䴮 HHNNSS
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
��ȡ��ǰ���ڴ� YYYYMMDD
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
��ȡ��ǰ����ʱ�䴮 YYYYMMDDHHNNSS
*/
function CurrentDateTimeStr()
{
	var currdatetime = CurrentDateStr() +CurrentTimeStr();
	return currdatetime;
}

/**
������ʱ���ʽת�����޸�ʽ�� 
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
���޸�ʽ��ת��������ʱ���ʽ
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
 ���� Javascript ҳ��ű��ؼ���������΢��� IE ��5.0���ϣ������<br>
 �����ú����� FlexDateWin.setday(this,[object])��setday(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��<input name=txt><input type=button value=FlexDateWin.setday onclick="FlexDateWin.setday(this,document.all.txt)"><br>
 ����<input onfocus="FlexDateWin.setday(this)"><br>
 ����������������ǣ�1000 - 9999��<br>
 ��ESC���رոÿؼ�<br>
 ������µ���ʾ�ط����ʱ��ֱ�������µ�������<br>
 �ؼ���������һ�㼴�ɹرոÿؼ�<br>
<br>
<br>
***************************************************************************<br>
* ѡ��ʱ������ڵ�JavaScriptҳ��ű��ؼ���������΢��� IE ��5.0���ϣ������ <br>
* ���ú�����sel_time(timeName,timeSel,isDisabled,show),ֱ��������ں�ʱ��ؼ�,ʹ<br>
* ��timeName.value���ɻ��ѡ�е����ں�ʱ�䡣������ѡ���text�ؼ����Ѿ����������setday <br>
* <br>
* �汾 1.01 <br>
* ����: timeName: �����ؼ��������ر������֣�Ҳ����Ϊ3���ֿؼ���ǰ׺ <br>
* timeSel: 3���ֿؼ�Ԥ����ʾ������ <br>
* isDisabled��3���ֿؼ��Ƿ�disabled <br>
* show�� һ���������ԣ���;�Զ���<br>
***************************************************************************<br>
˵����<br>
1.�ܵ�iframe�����ƣ�����϶����������ڣ���������ֹͣ�ƶ���<br>
<br>
*/
function FlexDateWin()
{

}
//==================================================== �����趨���� =======================================================
FlexDateWin.bMoveable=true; //���������Ƿ�����϶�
FlexDateWin._VersionInfo="Version:2.0&#13;2.0����:walkingpoison&#13;1.0����: F.R.Huang(meizz)&#13;MAIL: meizz@hzcnc.com" //�汾��Ϣ

//==================================================== WEB ҳ����ʾ���� =====================================================
FlexDateWin.init = function()
{
	document.writeln('<iframe id=calendarDateLayer  frameborder=0 style="position: absolute; width: 148px; height: 236px; z-index: 9998; display: none"></iframe>');
	var strFrame; //����������HTML����
	strFrame='<style>';
	strFrame+='INPUT.button{BORDER-RIGHT: #99CCFF 1px solid;BORDER-TOP: #99CCFF 1px solid;BORDER-LEFT: #99CCFF 1px solid;';
	strFrame+='BORDER-BOTTOM: #99CCFF 1px solid;BACKGROUND-COLOR: #fff8ec;font-family:����;}';
	strFrame+='TD{FONT-SIZE: 9pt;font-family:����;}';
	strFrame+='</style>';
	strFrame+='<scr' + 'ipt>';
	strFrame+='var datelayerx,datelayery; /*��������ؼ������λ��*/';
	strFrame+='var bDrag; /*����Ƿ�ʼ�϶�*/';
	strFrame+='function document.onmousemove() /*������ƶ��¼��У������ʼ�϶����������ƶ�����*/';
	strFrame+='{if(bDrag && window.event.button==1)';
	strFrame+=' {var DateLayer=parent.document.all.calendarDateLayer.style;';
	strFrame+=' DateLayer.posLeft += window.event.clientX-datelayerx;/*����ÿ���ƶ��Ժ����λ�ö��ָ�Ϊ��ʼ��λ�ã����д����div�в�ͬ*/';
	strFrame+=' DateLayer.posTop += window.event.clientY-datelayery;}}';
	strFrame+='function DragStart() /*��ʼ�����϶�*/';
	strFrame+='{var DateLayer=parent.document.all.calendarDateLayer.style;';
	strFrame+=' datelayerx=window.event.clientX;';
	strFrame+=' datelayery=window.event.clientY;';
	strFrame+=' bDrag=true;}';
	strFrame+='function DragEnd(){ /*���������϶�*/';
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
	strFrame+=' onclick="parent.FlexDateWin.calendarPrevM()" title="��ǰ�� 1 ��" ><b >&lt;</b>';
	strFrame+=' </td><td width=60 align=center style="font-size:12px;cursor:default"  ';
	strFrame+='onmouseover="style.backgroundColor=\'#99ccff\'" onmouseout="style.backgroundColor=\'white\'" ';
	strFrame+='onclick="parent.FlexDateWin.tmpSelectYearInnerHTML(this.innerText.substring(0,4))" title="�������ѡ�����"><span  id=calendarYearHead></span></td>';
	strFrame+='<td width=48 align=center style="font-size:12px;cursor:default"  onmouseover="style.backgroundColor=\'#99ccff\'" ';
	strFrame+=' onmouseout="style.backgroundColor=\'white\'" onclick="parent.FlexDateWin.tmpSelectMonthInnerHTML(this.innerText.length==3?this.innerText.substring(0,1):this.innerText.substring(0,2))"';
	strFrame+=' title="�������ѡ���·�"><span id=calendarMonthHead ></span></td>';
	strFrame+=' <td width=16 bgcolor=#99CCFF align=center style="font-size:12px;cursor: hand;color: #ffffff" ';
	strFrame+=' onclick="parent.FlexDateWin.calendarNextM()" title="��� 1 ��" ><b >&gt;</b></td></tr>';
	strFrame+=' </table></td></tr>';

	strFrame+=' <tr ><td width=142 height=23  bgcolor=#FFFFFF><table border=0 cellspacing=1 cellpadding=0 width=140  height=23>';
	strFrame+=' <tr align=center >'
	strFrame+=' <td width=4 align=center bgcolor=#99CCFF style="font-size:12px;color: #ffffff" ><b ></b></td>';
	strFrame+=' <td width=60 align=center style="font-size:12px;cursor:default"  ';
	strFrame+='onmouseover="style.backgroundColor=\'#99ccff\'" onmouseout="style.backgroundColor=\'white\'" ';
	strFrame+='onclick="parent.FlexDateWin.tmpSelectHourInnerHTML(this.innerText.length==3?this.innerText.substring(0,1):this.innerText.substring(0,2))" title="�������ѡ��ʱ"><span  id=calendarHourHead></span></td>';
	strFrame+=' <td width=60 align=center style="font-size:12px;cursor:default"  ';
	strFrame+='onmouseover="style.backgroundColor=\'#99ccff\'" onmouseout="style.backgroundColor=\'white\'" ';
	strFrame+='onclick="parent.FlexDateWin.tmpSelectMinuteInnerHTML(this.innerText.length==3?this.innerText.substring(0,1):this.innerText.substring(0,2))" title="�������ѡ���"><span  id=calendarMinuteHead></span></td>';
	strFrame+=' <td width=60 align=center style="font-size:12px;cursor:default"  ';
	strFrame+='onmouseover="style.backgroundColor=\'#99ccff\'" onmouseout="style.backgroundColor=\'white\'" ';
	strFrame+='onclick="parent.FlexDateWin.tmpSelectSecondInnerHTML(this.innerText.length==3?this.innerText.substring(0,1):this.innerText.substring(0,2))" title="�������ѡ����"><span  id=calendarSecondHead></span></td>';
	strFrame+=' <td width=4 align=center bgcolor=#99CCFF style="font-size:12px;color: #ffffff" ><b ></b></td>';
	strFrame+=' </table></td></tr>';

	strFrame+=' <tr ><td width=142 height=18 >';
	strFrame+='<table border=1 cellspacing=0 cellpadding=0 bgcolor=#99CCFF ' + (FlexDateWin.bMoveable? 'onmousedown="DragStart()" onmouseup="DragEnd()"':'');
	strFrame+=' BORDERCOLORLIGHT=#99CCFF BORDERCOLORDARK=#FFFFFF width=140 height=20  style="cursor:' + (FlexDateWin.bMoveable ? 'move':'default') + '">';
	strFrame+='<tr  align=center valign=bottom><td style="font-size:12px;color:#FFFFFF" >��</td>';
	strFrame+='<td style="font-size:12px;color:#FFFFFF" >һ</td><td style="font-size:12px;color:#FFFFFF" >��</td>';
	strFrame+='<td style="font-size:12px;color:#FFFFFF" >��</td><td style="font-size:12px;color:#FFFFFF" >��</td>';
	strFrame+='<td style="font-size:12px;color:#FFFFFF" >��</td><td style="font-size:12px;color:#FFFFFF" >��</td></tr>';
	strFrame+='</table></td></tr><!-- Author:F.R.Huang(calendar) http://www.calendar.com/ mail: calendar@hzcnc.com 2002-10-8 -->';
	strFrame+=' <tr ><td width=142 height=120 >';
	strFrame+=' <table border=1 cellspacing=2 cellpadding=0 BORDERCOLORLIGHT=#99CCFF BORDERCOLORDARK=#FFFFFF bgcolor=#fff8ec width=140 height=120 >';
	var n=0; for (var j=0;j<5;j++){ strFrame+= ' <tr align=center >'; for (i=0;i<7;i++){
	strFrame+='<td width=20 height=20 id=calendarDay'+n+' style="font-size:12px"  onclick=parent.FlexDateWin.calendarDayClick(this.innerText,0)></td>';n++;}
	strFrame+='</tr>';}
	strFrame+=' <tr align=center >';
	for (var i=35;i<39;i++)strFrame+='<td width=20 height=20 id=calendarDay'+i+' style="font-size:12px"  onclick="parent.FlexDateWin.calendarDayClick(this.innerText,0)"></td>';
	strFrame+=' <td colspan=3 align=right ><span onclick=parent.FlexDateWin.closeLayer() style="font-size:12px;cursor: hand"';
	strFrame+='  title="' + FlexDateWin._VersionInfo + '"><u>�ر�</u></span>&nbsp;</td></tr>';
	strFrame+=' </table></td></tr><tr ><td >';
	strFrame+=' <table border=0 cellspacing=1 cellpadding=0 width=100%  bgcolor=#FFFFFF>';
	strFrame+=' <tr ><td  align=left><input  type=button class=button value="<<" title="��ǰ�� 1 ��" onclick="parent.FlexDateWin.calendarPrevY()" ';
	strFrame+=' onfocus="this.blur()" style="font-size: 12px; height: 20px"><input  class=button title="��ǰ�� 1 ��" type=button ';
	strFrame+=' value="<" onclick="parent.FlexDateWin.calendarPrevM()" onfocus="this.blur()" style="font-size: 12px; height: 20px"></td><td ';
	strFrame+='  align=center><input  type=button class=button value="����" onclick="parent.FlexDateWin.calendarToday()" ';
	strFrame+=' onfocus="this.blur()" title="��ǰ����" style="font-size: 12px; height: 20px; cursor:hand"></td><td ';
	strFrame+='  align=center><input  type=button class=button value="����" onclick="parent.FlexDateWin.calendarNow()" ';
	strFrame+=' onfocus="this.blur()" title="��ǰ����" style="font-size: 12px; height: 20px; cursor:hand"></td><td ';
	strFrame+='  align=right><input  type=button class=button value=">" onclick="parent.FlexDateWin.calendarNextM()" ';
	strFrame+=' onfocus="this.blur()" title="��� 1 ��" class=button style="font-size: 12px; height: 20px"><input ';
	strFrame+='  type=button class=button value=">>" title="��� 1 ��" onclick="parent.FlexDateWin.calendarNextY()"';
	strFrame+=' onfocus="this.blur()" style="font-size: 12px; height: 20px"></td>';
	strFrame+='</tr></table></td></tr></table></div>';

	window.frames.calendarDateLayer.document.writeln(strFrame);
	window.frames.calendarDateLayer.document.close(); //���ie������������������
}

FlexDateWin.init();

//==================================================== WEB ҳ����ʾ���� ======================================================
FlexDateWin.outObject = null;
FlexDateWin.outButton = null; //����İ�ť
FlexDateWin.outDate=""; //��Ŷ��������
FlexDateWin.odatelayer=window.frames.calendarDateLayer.document.all; //�����������
FlexDateWin.outDateFmt='date';//date = yyyy-mm-dd ;datestr=yyyymmdd ;datetime=yyyy-mm-dd 00:00:00;datetimestr=yyyymmdd000000

/**
��ʾ����ѡ��� ��������<br>
FlexDateWin.setmonth(this,[object])��setmonth(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��&lt;input name=txt&gt;&lt;input type=button value=FlexDateWin.setmonth onclick="FlexDateWin.setmonth(this,document.all.txt)"&gt;<br>
 ����&lt;input onfocus="FlexDateWin.setmonth(this)"&gt;<br>
*/
FlexDateWin.setmonth= function(tt,obj,isTop) //��������
{
	if (arguments.length > 3){alert("�Բ��𣡴��뱾�ؼ��Ĳ���̫�࣡");return;}
	if (arguments.length == 0){alert("�Բ�����û�д��ر��ؼ��κβ�����");return;}
	FlexDateWin.outDateFmt='yearmonth';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//xl:

FlexDateWin.setyear= function(tt,obj,isTop) //��������
{
	if (arguments.length > 3){alert("�Բ��𣡴��뱾�ؼ��Ĳ���̫�࣡");return;}
	if (arguments.length == 0){alert("�Բ�����û�д��ر��ؼ��κβ�����");return;}
	FlexDateWin.outDateFmt='year';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//xl:
FlexDateWin.sethour= function(tt,obj,isTop) //��������
{
	if (arguments.length > 3){alert("�Բ��𣡴��뱾�ؼ��Ĳ���̫�࣡");return;}
	if (arguments.length == 0){alert("�Բ�����û�д��ر��ؼ��κβ�����");return;}
	FlexDateWin.outDateFmt='yearmonthhour';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//xl:
FlexDateWin.sethouronly= function(tt,obj,isTop) //��������
{
	if (arguments.length > 3){alert("�Բ��𣡴��뱾�ؼ��Ĳ���̫�࣡");return;}
	if (arguments.length == 0){alert("�Բ�����û�д��ر��ؼ��κβ�����");return;}
	FlexDateWin.outDateFmt='yearmonthhouronly';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//xl:
FlexDateWin.setminuteonly= function(tt,obj,isTop) //��������
{
	if (arguments.length > 3){alert("�Բ��𣡴��뱾�ؼ��Ĳ���̫�࣡");return;}
	if (arguments.length == 0){alert("�Բ�����û�д��ر��ؼ��κβ�����");return;}
	FlexDateWin.outDateFmt='yearmonthhourminuteonly';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

//����������������������

/**
��ʾ����ѡ��� ����������<br>
FlexDateWin.setday(this,[object])��setday(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��&lt;input name=txt&gt;&lt;input type=button value=FlexDateWin.setday onclick="FlexDateWin.setday(this,document.all.txt)"&gt;<br>
 ����&lt;input onfocus="FlexDateWin.setday(this)"&gt;<br>
*/
FlexDateWin.setday= function(tt,obj,isTop) //��������
{
	if (arguments.length > 3){alert("�Բ��𣡴��뱾�ؼ��Ĳ���̫�࣡");return;}
	if (arguments.length == 0){alert("�Բ�����û�д��ر��ؼ��κβ�����");return;}
	FlexDateWin.outDateFmt='date';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

/**
��ʾ����ѡ��� ��������ʱ��<br>
FlexDateWin.setdatetime(this,[object])��setdatetime(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��&lt;input name=txt&gt;&lt;input type=button value=FlexDateWin.setdatetime onclick="FlexDateWin.setdatetime(this,document.all.txt)"&gt;<br>
 ����&lt;input onfocus="FlexDateWin.setdatetime(this)"&gt;<br>
*/
FlexDateWin.setdatetime= function(tt,obj,isTop) //��������
{
	if (arguments.length > 3){alert("�Բ��𣡴��뱾�ؼ��Ĳ���̫�࣡");return;}
	if (arguments.length == 0){alert("�Բ�����û�д��ر��ؼ��κβ�����");return;}
	FlexDateWin.outDateFmt='datetime';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}

FlexDateWin.setdatehhnn= function(tt,obj,isTop) //��������
{
	if (arguments.length > 3){alert("�Բ��𣡴��뱾�ؼ��Ĳ���̫�࣡");return;}
	if (arguments.length == 0){alert("�Բ�����û�д��ر��ؼ��κβ�����");return;}
	FlexDateWin.outDateFmt='datehhnn';
	if(typeof(obj) == 'undefined' ) obj = tt;
	FlexDateWin.setdayfmt(tt,obj,FlexDateWin.outDateFmt,isTop);
}


/**
��ʾ����ѡ��� ��������<br>
FlexDateWin.setdayfmt(this,[object])��setdayfmt(this)��[object]�ǿؼ�����Ŀؼ��������������ӣ�<br>
 һ��&lt;input name=txt&gt;&lt;input type=button value=FlexDateWin.setdayfmt onclick="FlexDateWin.setdayfmt(this,document.all.txt)"&gt;<br>
 ����&lt;input onfocus="FlexDateWin.setdayfmt(this)"&gt;<br>
*/
FlexDateWin.setdayfmt= function(tt,obj,fmt,isTop) //��������
{
	if (arguments.length !=4 ){alert("�Բ��𣡴��뱾�ؼ��Ĳ�������ȷ��");return;}
	FlexDateWin.outDateFmt=fmt;
	var dads = document.all.calendarDateLayer.style;
	var th = tt;
	if(tt==null) tt = obj;
	if(obj==null) obj = tt;
	var ttop = tt.offsetTop; //TT�ؼ��Ķ�λ���
	var thei = tt.clientHeight; //TT�ؼ�����ĸ�
	var tleft = tt.offsetLeft; //TT�ؼ��Ķ�λ���
	var ttyp = tt.type; //TT�ؼ�������
	while (tt = tt.offsetParent){ttop+=tt.offsetTop; tleft+=tt.offsetLeft;}
	var whei = typeof(window.dialogHeight)=="undefined"?parseInt(document.body.offsetHeight):parseInt(window.dialogHeight);
	
	//alert(whei);
	//alert(document.body.currentStyle.height);
	
	if ( isTop == false ) //��������Ļ��
	{ 
	  dads.top =  0;
	  //alert(dads.top);
	}
    else if (isTop == true) //�ڿؼ��Ϸ�
    {
	  dads.top = ttop - 236;
	//  alert(dads.top);
	}
	else��// �ڿؼ��·�
	  dads.top = (ttyp=="image")? ttop+thei : ttop+thei+6;
	dads.left = tleft;
	FlexDateWin.outObject =  obj;
	FlexDateWin.outButton =  th; //�趨�ⲿ����İ�ť

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

	FlexDateWin.outDate=new Date(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth-1,calendarTheDay,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond); //�����ⲿ���������

	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);

	/*
	//���ݵ�ǰ������������ʾ����������
	var reg = /^(\d+)-(\d{1,2})-(\d{1,2})$/; 
	var r = FlexDateWin.outObject.value.match(reg); 
	if(r!=null)
	{
		r[2]=r[2]-1; 
		var d= new Date(r[1], r[2],r[3]); 
		if(d.getFullYear()==r[1] && d.getMonth()==r[2] && d.getDate()==r[3]){
			FlexDateWin.outDate=d; //�����ⲿ���������
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

FlexDateWin.MonHead = new Array(12); //����������ÿ���µ��������
FlexDateWin.MonHead[0] = 31; FlexDateWin.MonHead[1] = 28; FlexDateWin.MonHead[2] = 31; FlexDateWin.MonHead[3] = 30; FlexDateWin.MonHead[4] = 31; FlexDateWin.MonHead[5] = 30;
FlexDateWin.MonHead[6] = 31; FlexDateWin.MonHead[7] = 31; FlexDateWin.MonHead[8] = 30; FlexDateWin.MonHead[9] = 31; FlexDateWin.MonHead[10] = 30; FlexDateWin.MonHead[11] = 31;

FlexDateWin.calendarTheYear=new Date().getFullYear(); //������ı����ĳ�ʼֵ
FlexDateWin.calendarTheMonth=new Date().getMonth()+1; //�����µı����ĳ�ʼֵ
FlexDateWin.calendarWDay=new Array(39); //����д���ڵ�����
FlexDateWin.calendarTheHour = 0+(new Date().getHours());
FlexDateWin.calendarTheMinute = 0+(new Date().getMinutes());
FlexDateWin.calendarTheSecond = 0+(new Date().getTime()) % 60000; 
FlexDateWin.calendarTheSecond = (FlexDateWin.calendarTheSecond - (FlexDateWin.calendarTheSecond % 1000)) / 1000; 

document.onclick= function() //������ʱ�رոÿؼ� //ie6�����������������л����㴦�����
{ 
	with(window.event)
	{ if (srcElement.getAttribute("Author")==null && srcElement != FlexDateWin.outObject && srcElement != FlexDateWin.outButton)
	FlexDateWin.closeLayer();
	}
}

document.onkeyup= function() //��Esc���رգ��л�����ر�
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

FlexDateWin.calendarWriteHead= function(yy,mm,hh,nn,ss) //�� head ��д�뵱ǰ��������
{
	FlexDateWin.odatelayer.calendarYearHead.innerText = yy + " ��";
	FlexDateWin.odatelayer.calendarMonthHead.innerText = mm + " ��";
	FlexDateWin.odatelayer.calendarHourHead.innerText = hh + " ʱ";
	FlexDateWin.odatelayer.calendarMinuteHead.innerText = nn + " ��";
	FlexDateWin.odatelayer.calendarSecondHead.innerText = ss + " ��";
}

FlexDateWin.tmpSelectYearInnerHTML= function(strYear) //��ݵ�������
{
	if (strYear.match(/\D/)!=null){alert("�����������������֣�");return;}
	var m = (strYear) ? strYear : new Date().getFullYear();
	if (m < 1000 || m > 9999) {alert("���ֵ���� 1000 �� 9999 ֮�䣡");return;}
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
	{selectInnerHTML += "<option  value='" + i + "' selected>" + i + "��" + "</option>\r\n";}
	else {selectInnerHTML += "<option  value='" + i + "'>" + i + "��" + "</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectYearLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectYearLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectYear.focus();
}

FlexDateWin.tmpSelectMonthInnerHTML= function(strMonth) //�·ݵ�������
{
	if (strMonth.match(/\D/)!=null){alert("�·���������������֣�");return;}
	var m = (strMonth) ? strMonth : new Date().getMonth() + 1;
	var s = "<select  name=tmpSelectMonth style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectMonthLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectMonthLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheMonth = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = 1; i < 13; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='"+i+"' selected>"+i+"��"+"</option>\r\n";}
	else {selectInnerHTML += "<option  value='"+i+"'>"+i+"��"+"</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectMonthLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectMonthLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectMonth.focus();
}



FlexDateWin.tmpSelectHourInnerHTML= function(strHour) //Сʱ��������
{
	if (strHour.match(/\D/)!=null){alert("ʱ����������������֣�");return;}
	var m = (strHour) ? strHour : new Date().getMonth() + 1;
	var s = "<select  name=tmpSelectHour style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectHourLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectHourLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheHour = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = 0; i < 24; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='"+i+"' selected>"+i+"ʱ"+"</option>\r\n";}
	else {selectInnerHTML += "<option  value='"+i+"'>"+i+"ʱ"+"</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectHourLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectHourLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectHour.focus();
}

FlexDateWin.tmpSelectMinuteInnerHTML= function(strHour) //Сʱ��������
{
	if (strHour.match(/\D/)!=null){alert("ʱ����������������֣�");return;}
	var m = (strHour) ? strHour : new Date().getMonth() + 1;
	var s = "<select  name=tmpSelectMinute style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectMinuteLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectMinuteLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheMinute = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = 0; i < 60; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='"+i+"' selected>"+i+"��"+"</option>\r\n";}
	else {selectInnerHTML += "<option  value='"+i+"'>"+i+"��"+"</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectMinuteLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectMinuteLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectMinute.focus();
}

FlexDateWin.tmpSelectSecondInnerHTML= function(strHour) //Сʱ��������
{
	if (strHour.match(/\D/)!=null){alert("ʱ����������������֣�");return;}
	var m = (strHour) ? strHour : new Date().getMonth() + 1;
	var s = "<select  name=tmpSelectSecond style='font-size: 12px' "
	s += "onblur='document.all.tmpSelectSecondLayer.style.display=\"none\"' "
	s += "onchange='document.all.tmpSelectSecondLayer.style.display=\"none\";"
	s += "parent.FlexDateWin.calendarTheSecond = this.value; parent.FlexDateWin.calendarSetDay(parent.FlexDateWin.calendarTheYear,parent.FlexDateWin.calendarTheMonth,parent.FlexDateWin.calendarTheHour,parent.FlexDateWin.calendarTheMinute,parent.FlexDateWin.calendarTheSecond)'>\r\n";
	var selectInnerHTML = s;
	for (var i = 0; i < 60; i++)
	{
	if (i == m)
	{selectInnerHTML += "<option  value='"+i+"' selected>"+i+"��"+"</option>\r\n";}
	else {selectInnerHTML += "<option  value='"+i+"'>"+i+"��"+"</option>\r\n";}
	}
	selectInnerHTML += "</select>";
	FlexDateWin.odatelayer.tmpSelectSecondLayer.style.display="";
	FlexDateWin.odatelayer.tmpSelectSecondLayer.innerHTML = selectInnerHTML;
	FlexDateWin.odatelayer.tmpSelectSecond.focus();
}



FlexDateWin.closeLayer= function() //�����Ĺر�
{
	document.all.calendarDateLayer.style.display="none";
	//GuangBiao2();
}

FlexDateWin.IsPinYear= function(year) //�ж��Ƿ���ƽ��
{
	if (0==year%4&&((year%100!=0)||(year%400==0))) return true;else return false;
}

FlexDateWin.GetMonthCount= function(year,month) //�������Ϊ29��
{
	var c=FlexDateWin.MonHead[month-1];if((month==2)&&FlexDateWin.IsPinYear(year)) c++;return c;
}
FlexDateWin.GetDOW= function(day,month,year) //��ĳ������ڼ�
{
	var dt=new Date(year,month-1,day).getDay()/7; return dt;
}

FlexDateWin.calendarPrevY= function() //��ǰ�� Year
{
	if(FlexDateWin.calendarTheYear > 999 && FlexDateWin.calendarTheYear <10000){FlexDateWin.calendarTheYear--;}
	else{alert("��ݳ�����Χ��1000-9999����");}
	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);
}
FlexDateWin.calendarNextY= function() //���� Year
{
	if(FlexDateWin.calendarTheYear > 999 && FlexDateWin.calendarTheYear <10000){FlexDateWin.calendarTheYear++;}
	else{alert("��ݳ�����Χ��1000-9999����");}
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
	FlexDateWin.calendarTheYear=new Date().getFullYear(); //������ı����ĳ�ʼֵ
	FlexDateWin.calendarTheMonth=new Date().getMonth()+1; //�����µı����ĳ�ʼֵ
	FlexDateWin.calendarTheHour = 0+(new Date().getHours());
	FlexDateWin.calendarTheMinute = 0+(new Date().getMinutes());
	FlexDateWin.calendarTheSecond = 0+(new Date().getTime()) % 60000; 
	FlexDateWin.calendarTheSecond = (FlexDateWin.calendarTheSecond - (FlexDateWin.calendarTheSecond % 1000)) / 1000; 
	var today;
	today=new Date().getDate();
	//FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth);
	FlexDateWin.calendarValue(today);

}
FlexDateWin.calendarPrevM= function() //��ǰ���·�
{
	if(FlexDateWin.calendarTheMonth>1){FlexDateWin.calendarTheMonth--}else{FlexDateWin.calendarTheYear--;FlexDateWin.calendarTheMonth=12;}
	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);
}
FlexDateWin.calendarNextM= function() //�����·�
{
	if(FlexDateWin.calendarTheMonth==12){FlexDateWin.calendarTheYear++;FlexDateWin.calendarTheMonth=1}else{FlexDateWin.calendarTheMonth++}
	FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth,FlexDateWin.calendarTheHour,FlexDateWin.calendarTheMinute,FlexDateWin.calendarTheSecond);
}

FlexDateWin.calendarSetDay= function(yy,mm,hh,nn,ss) //��Ҫ��д����**********
{
	FlexDateWin.calendarWriteHead(yy,mm,hh,nn,ss);
	//���õ�ǰ���µĹ�������Ϊ����ֵ
	FlexDateWin.calendarTheYear=yy;
	FlexDateWin.calendarTheMonth=mm;
	for (var i = 0; i < 39; i++){FlexDateWin.calendarWDay[i]=""}; //����ʾ�������ȫ�����
	var day1 = 1,day2=1,firstday = new Date(yy,mm-1,1).getDay(); //ĳ�µ�һ������ڼ�
	for (i=0;i<firstday;i++)FlexDateWin.calendarWDay[i]=FlexDateWin.GetMonthCount(mm==1?yy-1:yy,mm==1?12:mm-1)-firstday+i+1 //�ϸ��µ������
	for (i = firstday; day1 < FlexDateWin.GetMonthCount(yy,mm)+1; i++){FlexDateWin.calendarWDay[i]=day1;day1++;}
	for (i=firstday+FlexDateWin.GetMonthCount(yy,mm);i<39;i++){FlexDateWin.calendarWDay[i]=day2;day2++}
	for (i = 0; i < 39; i++)
	{ var da = eval("FlexDateWin.odatelayer.calendarDay"+i) //��д�µ�һ���µ�������������
	if (FlexDateWin.calendarWDay[i]!="")
	{ 
	//��ʼ���߿�
	da.borderColorLight="#99CCFF";
	da.borderColorDark="#FFFFFF";
	if(i<firstday) //�ϸ��µĲ���
	{
	da.innerHTML="<b><font color=gray>" + FlexDateWin.calendarWDay[i] + "</font></b>";
	da.title=(mm==1?12:mm-1) +"��" + FlexDateWin.calendarWDay[i] + "��";
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
	//��ѡ�е�������ʾΪ����ȥ
	if((mm==1?yy-1:yy)==FlexDateWin.outDate.getFullYear() && (mm==1?12:mm-1)== FlexDateWin.outDate.getMonth() + 1 && 
	FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())
	{
	da.borderColorLight="#FFFFFF";
	da.borderColorDark="#99CCFF";
	}
	}
	}
	else if (i>=firstday+FlexDateWin.GetMonthCount(yy,mm)) //�¸��µĲ���
	{
	da.innerHTML="<b><font color=gray>" + FlexDateWin.calendarWDay[i] + "</font></b>";
	da.title=(mm==12?1:mm+1) +"��" + FlexDateWin.calendarWDay[i] + "��";
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
	//��ѡ�е�������ʾΪ����ȥ
	if((mm==12?yy+1:yy)==FlexDateWin.outDate.getFullYear() && (mm==12?1:mm+1)== FlexDateWin.outDate.getMonth() + 1 && 
	FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())
	{
	da.borderColorLight="#FFFFFF";
	da.borderColorDark="#99CCFF";
	}
	}
	}
	else //���µĲ���
	{
	da.innerHTML="<b>" + FlexDateWin.calendarWDay[i] + "</b>";
	da.title=mm +"��" + FlexDateWin.calendarWDay[i] + "��";
	da.onclick=Function("FlexDateWin.calendarDayClick(this.innerText,0)"); //��td����onclick�¼��Ĵ���
	//����ǵ�ǰѡ������ڣ�����ʾ����ɫ�ı���������ǵ�ǰ���ڣ�����ʾ����ɫ����
	if(!FlexDateWin.outDate)
	da.style.backgroundColor = (yy == new Date().getFullYear() && mm == new Date().getMonth()+1 && FlexDateWin.calendarWDay[i] == new Date().getDate())?
	"#99ccff":"#e0e0e0";
	else
	{
	da.style.backgroundColor =(yy==FlexDateWin.outDate.getFullYear() && mm== FlexDateWin.outDate.getMonth() + 1 && FlexDateWin.calendarWDay[i]==FlexDateWin.outDate.getDate())?
	"#ff9900":((yy == new Date().getFullYear() && mm == new Date().getMonth()+1 && FlexDateWin.calendarWDay[i] == new Date().getDate())?
	"#99ccff":"#e0e0e0");
	//��ѡ�е�������ʾΪ����ȥ
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

FlexDateWin.calendarDayClick= function(n,ex) //�����ʾ��ѡȡ���ڣ������뺯��*************
{
	var yy=FlexDateWin.calendarTheYear;
	//alert(FlexDateWin.calendarTheMonth)
	var mm = parseInt(FlexDateWin.calendarTheMonth)+ex; //ex��ʾƫ����������ѡ���ϸ��·ݺ��¸��·ݵ�����
	//�ж��·ݣ������ж�Ӧ�Ĵ���
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
	FlexDateWin.outObject.value= yy + "-" + mm + "-" + n ; //ע�����������������ĳ�����Ҫ�ĸ�ʽ
	FlexDateWin.calendarTheYear=yy; //������ı����ĳ�ʼֵ
	FlexDateWin.calendarTheMonth=mm; //�����µı����ĳ�ʼֵ
	//FlexDateWin.calendarSetDay(FlexDateWin.calendarTheYear,FlexDateWin.calendarTheMonth);
	FlexDateWin.calendarValue(n);

	//FlexDateWin.outObject.focus();
	}
	else {FlexDateWin.closeLayer(); alert("����Ҫ����Ŀؼ����󲢲����ڣ�");}
}

/**********************************************************************************
����sel_time

�汾 1.01
����: timeName: �����ؼ��������ر������֣�Ҳ����Ϊ3���ֿؼ���ǰ׺
timeSel: 3���ֿؼ�Ԥ����ʾ������
isDisabled��3���ֿؼ��Ƿ�disabled
show: һ�������ֶΣ���������д���Լ��Ķ���
***********************************************************************************/
FlexDateWin.sel_time= function(timeName,timeSel,isDisabled,show){
	var hour=0;
	var min=0;
	//alert(hourSel+" "+minSel);
	//alert(houName+" "+minName);
	//alert(isDisabled);
	//alert(hourSel+" "+minSel);
	//alert(hourSel.length+" "+minSel.length)
	///////////////////////ȡ��timeSel�е����ں�ʱ��///////////////////////////
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

	//���3�����ڷֿؼ�
	//������ڿؼ�
	document.write("<input name="+timeName+"_date type='text' readonly onclick='FlexDateWin.setday(this);' show='"+show+"' size=10 value='"+dateSel+"' "+isDisabled+" onfocus='FlexDateWin.setHidden("+timeName+"_date,"+timeName+"_hou,"+timeName+"_min,"+timeName+")'>&nbsp;");
	//���Сʱ�ؼ�
	document.write("<select name="+timeName+"_hou size=1 "+isDisabled+" onchange='FlexDateWin.setHidden("+timeName+"_date,"+timeName+"_hou,"+timeName+"_min,"+timeName+")'>");
	for(;hour<24;hour++){
	if(hour<10) hour="0"+hour;
	document.write("<option value="+hour)
	if(hour==hourSel) document.write(" selected");
	document.write(">"+hour+"</option>");

	}

	document.write("</select>ʱ&nbsp;");
	//������ӿؼ�
	document.write("<select name="+timeName+"_min size=1 "+isDisabled+" onchange='FlexDateWin.setHidden("+timeName+"_date,"+timeName+"_hou,"+timeName+"_min,"+timeName+")'>");
	for(;min<60;min++){
	if(min<10) min="0"+min;
	document.write("<option value="+min)
	if(min==minSel) document.write(" selected");
	document.write(" "+isDisabled+" >"+min+"</option>");
	}
	document.write("</select>��");
	//�����������
	document.write("<input name="+timeName+" type=hidden value='"+timeSel+"'>");
	//FlexDateWin.setHidden(timeName+"_date,"+timeName+"_hou,"+timeName+"_min,"+timeName);
}

FlexDateWin.setHidden = function(t,s1,s2,h){
	//alert(t.value);
	h.value=t.value+" "+s1.value+":"+s2.value+":00";
}

FlexDateWin.sd = function(){
	if (s.value!=""){
	alert('��ѡ���ʱ����:'+s.value);
	}
	else{
	alert('����û��ѡ��ʱ��')
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
<input type="button" value="�����ʾ��ѡ���ʱ��" onclick="FlexDateWin.sd();">
</form>
</body>
</html>
*/
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.date.js");