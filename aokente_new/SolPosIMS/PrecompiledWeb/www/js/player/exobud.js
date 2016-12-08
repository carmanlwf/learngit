
var objMmInfo = null;
var intMmCnt = 0;
var intSelMmCnt = 0;
var intActMmCnt = 0;
var cActIdx = 0;
var cActTit = "nAnT";
var strMmInfo = "媒体档案信息";
var blnfpl = false;
var blnEnabled = false;
var blnEOT = false;
var arrSelMm = null;
var arrActMm = null;
var intExobudStat = 0;
var tidTLab = null;
var tidErr = null;
var tidMsg = null;
var intErrCnt = 0;
var blnRept = false;
// true = 自动连续播放
// false = 不要自动连续播放，让使用者自行挑选下一首曲目
var blnAutoProc = true;
// 设定播放面板上所显示的时间长度，预设是以正常方式(Elapse)抑或倒数方式(Lapse)显示：
// true = 以正常方式显示时间长度，即动态地显示曲目已播放的时间
// false = 以倒数方式显示时间长度，即动态地显示曲目剩余的时间
var blnElaps = true;
// 设定播放每首曲目之间的延迟时间(Delay Time)，单位是毫秒(msec)。
// 每100毫秒代表0.1秒，默认值是500毫秒(即0.5秒)，最少也要设为100毫秒。
var intDelay = 500;
// wmpInit() 函式: 使用 wmp-obj v7.x 链接库建立环境设定
function wmpInit(){
var wmps = Exobud.settings;
var wmpc = Exobud.ClosedCaption;
wmps.autoStart = true;
wmps.balance = 0;
wmps.enableErrorDialogs = false;
wmps.invokeURLs = false;
wmps.mute = false;
wmps.playCount = 1;
wmps.rate = 1;
wmps.volume = 100;
//if(blnUseSmi){wmpc.captioningID="capText"; capText.style.display="";}
Exobud.enabled = true;
}
// mkMmPath() 函式: 准备建立 Multi-object 的数组
function mkMmPath(u,t,f,s){
this.mmUrl = u;
this.mmTit = t;
this.mmDur = 0;
this.selMm = f;
this.actMm = f;
if(blnUseSmi){this.mmSmi=s;}
}
// mkList() 函式: 建立 Multi-object 的数组
function mkList(u,t,s,f){
var cu = u;
var ct = t;
var cs = s;
var cf = f;
var idx = 0;
if(objMmInfo == null){objMmInfo=new Array(); idx=0;}
else {idx=objMmInfo.length;}
if(u=="" || u==null){cu="mms://";}
if(t=="" || t==null){ct="nAnT";}
if(f=="f" || f=="F"){cf="f";}
else {cf="t"; intSelMmCnt++;}
if(blnUseSmi){
objMmInfo[idx]=new mkMmPath(cu,ct,cf,cs);
} else {
objMmInfo[idx]=new mkMmPath(cu,ct,cf);
}
intActMmCnt = intSelMmCnt;
intMmCnt = objMmInfo.length;
}
// mkSel() 函式: 建立已选取播放项目(Selected Media)的数组
function mkSel(){
arrSelMm = null;
intSelMmCnt = 0;
var selidx = 0;
if(intMmCnt<=0){intExobudStat=1; blnEnabled=false; return;} // 没有任何播放清单项目
arrSelMm = new Array();
for(var i=0; i<intMmCnt; i++){
if(objMmInfo[i].selMm =="t"){arrSelMm[selidx]=i;selidx++;}
}
intSelMmCnt=arrSelMm.length;
if(intSelMmCnt<=0){blnEnabled=false; intExobudStat=2; arrSelMm=null; return;}
else {blnEnabled=true; mkAct();}
}
// mkAct() 函式: 建立已启用播放项目(Activated Media)的数组
function mkAct(){
arrActMm = null;
intActMmCnt = 0;
var selidx = 0;
var actidx = 0;
if(blnEnabled){
arrActMm=new Array();
for(var i=0; i<intSelMmCnt; i++){
selidx=arrSelMm[i];
if(objMmInfo[selidx].actMm=="t"){arrActMm[actidx]=selidx; actidx++;}
}
intActMmCnt=arrActMm.length;
}
else { return;}
if(intActMmCnt<=0){blnEOT=true;arrActMm=null;}
else {blnEOT=false;}
}
// chkAllSel() 函式: 全部选取所有的播放清单项目
function chkAllSel(){
for(var i=0; i<intMmCnt; i++){
objMmInfo[i].selMm="t";
objMmInfo[i].actMm="t";
}
mkSel();
}
// chkAllDesel() 函式: 不选取所有的播放清单项目
function chkAllDesel(){
for(var i=0; i<intMmCnt; i++){
objMmInfo[i].selMm="f";
objMmInfo[i].actMm="f";
}
mkSel();
}
// chkItemSel() 函式: 选取或不选取播放清单项目
function chkItemSel(idx){
if(objMmInfo[idx].selMm =="t"){
objMmInfo[idx].selMm="f";objMmInfo[idx].actMm="f";
} else {
objMmInfo[idx].selMm="t";objMmInfo[idx].actMm="t";
}
mkSel();
}
// chkItemAct() 函式: 将某个已启用播放项目(Activated Media)冻结
function chkItemAct(idx){
objMmInfo[idx].actMm="f";
mkAct();
}
// mkSelAct() 函式: 将已选取播放项目(Selected Media)加入到已启用播放项目(Activated Media)
function mkSelAct(){
var idx=0;
for(var i=0; i<intSelMmCnt; i++){
idx=arrSelMm[i];
objMmInfo[idx].actMm="t";
}
mkAct();
}
// initExobud() 函式: 初始化 ExoBUD MP 媒体播放程序
function initExobud(){
wmpInit();
mkSel();
blnfpl = false;
if(!blnShowVolCtrl) {
document.images['vmute'].style.display = "none";
document.images['vdn'].style.display = "none";
document.images['vup'].style.display = "none";
}
if(!blnShowPlist){ document.images['plist'].style.display = "none";}
if(blnRept){imgChange('rept',1);}
else {imgChange('rept',0);}
if(blnRndPlay){imgChange('pmode',1);}
else {imgChange('pmode',0);}
showTLab();
disp1.innerHTML = " ";
//if(blnStatusBar){ window.status=('Cuiz.Net 无限精彩');}
if(blnAutoStart){startExobud();}
}
// startExobud() 函式: 开始播放曲目
function startExobud(){
var wmps = Exobud.playState;
if(wmps==2){
Exobud.controls.play(); 
try{clearInterval(play_time)}catch(e){}
return;
}
if(wmps==3){ return;}
blnfpl=false;
if(!blnEnabled){waitMsg();return;}
if(blnEOT){mkSelAct();}
if(intErrCnt>0){intErrCnt=0;tidErr=setTimeout('retryPlay(),1000');return;}
if(blnRndPlay){rndPlay();}
else {cActIdx=arrActMm[0]; selMmPlay(cActIdx);}
}
// selMmPlay() 函式: 处理媒体标题
function selMmPlay(idx){
clearTimeout(tidErr);
cActIdx=idx;
var trknum=idx+1;
var ctit =objMmInfo[idx].mmTit;
if(ctit=="nAnT"){ctit="(没有媒体标题)"}
if(blnUseSmi){Exobud.ClosedCaption.SAMIFileName = objMmInfo[idx].mmSmi;}
Exobud.URL = objMmInfo[idx].mmUrl;
cActTit = trknum + ". " + ctit;
disp1.innerHTML = cActTit;
//if(blnStatusBar){ window.status=(cActTit);}
chkItemAct(cActIdx);
}
// wmpPlay() 函式: 使用 wmp-obj v7.x 链接库播放曲目
function wmpPlay(){Exobud.controls.play();}
// wmpStop() 函式: 停止播放曲目及显示「就绪」状态讯息
function wmpStop(){
intErrCnt=0;
clearTimeout(tidErr);
clearInterval(tidTLab);
imgChange("stopt",1);
imgChange("pauzt",0);
imgChange("scope",0);
showTLab();
mkSelAct();
Exobud.controls.stop();
Exobud.close();
CourseButton.style.pixelLeft=0
disp1.innerHTML = "<font class=title></font>";
//if(blnStatusBar){ window.status=('Cuiz.Net 无限精彩');return true;}
}
// wmpPause() 函式: 使用 wmp-obj v7.x 链接库暂停播放曲目
function wmpPause(){Exobud.controls.pause();}
// wmpPP() 函式: 在暂停播放和继续播放之间进行切换
function wmpPP(){
var wmps = Exobud.playState;
var wmpc = Exobud.controls;
clearInterval(tidTLab);
clearTimeout(tidMsg);
if(wmps==2){wmpc.play();}
if(wmps==3){wmpc.pause(); disp2.innerHTML="<font color=#FFFFFF><b>暂停</b></font>"; tidMsg=setTimeout('rtnTLab()',1500);}
return;
}
// rndPlay() 函式: 随机播放(Random Play)的运算方式
function rndPlay(){
if(!blnEnabled){waitMsg();return;}
intErrCnt=0;
var idx=Math.floor(Math.random() * intActMmCnt);
cActIdx=arrActMm[idx];
selMmPlay(cActIdx);
}
// playAuto() 函式: 对已启用播放项目进行「自动连续播放」的处理
// 这是根据上面 blnAutoProc 的设定值而决定的动作。
function playAuto(){
if(blnRept){selMmPlay(cActIdx);return;}
if(!blnAutoProc){wmpStop();return;}
if(blnfpl){wmpStop();return;}
if(!blnEnabled){wmpStop();return;}
if(blnEOT){
if(blnLoopTrk){startExobud();}
else {wmpStop();}
} else {
if(blnRndPlay){rndPlay();}
else {cActIdx=arrActMm[0]; selMmPlay(cActIdx);}
}
}
// 播放使用者在播放清单上所点选的单一曲目
function selPlPlay(idx){
blnfpl=true;
selMmPlay(idx);
}
// playPrev() 函式: 播放上一首已启用播放项目
function playPrev(){
var wmps = Exobud.playState;
if(wmps==2 || wmps==3){Exobud.controls.stop();}
blnfpl=false;
if(!blnEnabled){waitMsg();return;}
if(blnEOT){mkSelAct();}
intErrCnt=0;
if(blnRndPlay){rndPlay();}
else {
var idx=cActIdx;
var blnFind=false;
for(var i=0;i<intSelMmCnt;i++){ if(cActIdx==arrSelMm[i]){idx=i-1; blnFind=true;}}
if(!blnFind){startExobud();return;}
if(idx<0){idx=intSelMmCnt-1;cActIdx=arrSelMm[idx];}
else {cActIdx=arrSelMm[idx];}
selMmPlay(cActIdx);
}
}
// playNext() 函式: 播放下一首已启用播放项目
function playNext(){
var wmps = Exobud.playState;
if(wmps==2 || wmps==3){Exobud.controls.stop();}
blnfpl=false;
if(!blnEnabled){waitMsg();return;}
if(blnEOT){mkSelAct();}
intErrCnt=0;
if(blnRndPlay){rndPlay();}
else {
var idx=cActIdx;
var blnFind=false;
for(var i=0;i<intSelMmCnt;i++){ if(cActIdx==arrSelMm[i]){idx=i+1; blnFind=true;}}
if(!blnFind){startExobud();return;}
if(idx>=intSelMmCnt){idx=0;cActIdx=arrSelMm[idx];}
else {cActIdx=arrSelMm[idx];}
selMmPlay(cActIdx);
}
}
// retryPlay() 函式: 再次尝试联机到媒体档案
function retryPlay(){
selMmPlay(cActIdx);
}
// chkRept() 函式: 切换是否重复播放目前的曲目(已启用播放项目)
function chkRept(){
var wmps = Exobud.playState;
if(wmps==3){clearInterval(tidTLab);}
if(blnRept){
blnRept=false; imgChange('rept',0); disp2.innerHTML="<font color=#FFFFFF><b>不重复播放</b></font>";
} else {
blnRept=true; imgChange('rept',1); disp2.innerHTML="<font color=#FFFFFF><b>重复播放</b></font>";
}
tidMsg=setTimeout('rtnTLab()',1000);
}
// chgPMode() 函式: 切换以循序(Sequential)抑或随机(Random)的方式来播放媒体项目
function chgPMode(){
var wmps = Exobud.playState;
if(wmps==3){clearInterval(tidTLab);}
if(blnRndPlay){
blnRndPlay=false; imgChange('pmode',0); disp2.innerHTML="<font color=#FFFFFF><b>循序播放</b></font>";
} else {
blnRndPlay=true; imgChange('pmode',1); disp2.innerHTML="<font color=#FFFFFF><b>随机播放</b></font>";
}
tidMsg=setTimeout('rtnTLab()',1000);
}
// evtOSChg() 函式: 以弹出窗口方式显示媒体档案信息
function evtOSChg(f){
// 以下是状态值 (f) 的说明:
// 0(未定义) 8(转换媒体中) 9(寻找媒体中) 10(联机媒体中) 11(加载媒体中)
// 12(开启媒体中) 13(媒体已开启) 20(等待播放中) 21(正在开启不明的连结)
if(f==8){capText.innerHTML="<p class=title>&copy;&nbsp;Cuiz.Net&nbsp;&trade;";}
if(f==13){
var strTitle = Exobud.currentMedia.getItemInfo("Title");
if(strTitle.length <= 0){strTitle = "(未命名的标题)"}
var strAuthor = Exobud.currentMedia.getItemInfo("Author");
if(strAuthor.length <= 0){strAuthor = "(未命名的作者)"}
var strCopy = Exobud.currentMedia.getItemInfo("Copyright");
if(strCopy.length <= 0){strCopy = "(没有著作权信息)"}
var strType = Exobud.currentMedia.getItemInfo("MediaType");
var strDur = Exobud.currentMedia.durationString;
var strUrl = Exobud.URL;
var trknum = cActIdx+1;
var ctit = objMmInfo[cActIdx].mmTit;
if(ctit=="nAnT"){
objMmInfo[cActIdx].mmTit = strAuthor + " - " + strTitle;
ctit = strAuthor + " - " + strTitle;
cActTit = trknum + ". " + ctit;
disp1.innerHTML = cActTit;
}
strMmInfo = "　　标题： " + strTitle + " (形式: " + strType +")" + "\n\n";
strMmInfo += "　演出者： " + strAuthor + "\n\n";
strMmInfo += "档案位置： " + strUrl + "\n\n";
strMmInfo += "　著作权： " + strCopy + "\n\n";
strMmInfo += "时间长度： " + strDur + "\n\n\n";
strMmInfo += "　　 Cuiz.Net.\n";
strMmInfo += "　　 ALL RIGHTS RESERVED.\n";
if(blnShowMmInfo){alert(strMmInfo);}
}
}
// evtPSChg() 函式: 切换播放程序的动作
function evtPSChg(f){
// 以下是状态值 (f) 的说明:
// 0(未定义) 1(已停止播放) 2(已暂停播放) 3(正在播放中) 4(向前搜索) 5(向后搜索)
// 6(缓冲处理中) 7(等待中) 8(已播放完毕) 9(转换曲目中) 10(就绪状态)
switch(f){
case 1:
evtStop();
break;
case 2:
evtPause();
break;
case 3:
evtPlay();
break;
case 8:
setTimeout('playAuto()', intDelay);
break;
}
}
// evtWmpBuff() 函式: 对媒体档案进行缓冲处理(Buffering)的动作
function evtWmpBuff(f){
if(f){
disp2.innerHTML = "缓冲处理中";
var msg = cActTit;
disp1.innerHTML = msg;
if(blnStatusBar){ 
//window.status=(msg);
}
} else {
disp1.innerHTML = cActTit; showTLab();
}
}
// evtWmpError() 函式: 当无法联机到媒体档案时，显示错误讯息
function evtWmpError(){
intErrCnt++;
Exobud.Error.clearErrorQueue();
if(intErrCnt<=3){
disp2.innerHTML = "<font color=#FFFFFF><b>尝试联机 (" + intErrCnt + ")</font>";
var msg = "<font color=#FFFFFF><b>(尝试第 " + intErrCnt + " 次联机) " + cActTit+"</font>";
disp1.innerHTML = "<font color=#FFFFFF><b><无法播放> " + cActTit +"</font>";
if(blnStatusBar){
 //window.status=(msg);
 }
tidErr=setTimeout('retryPlay()',1000);
} else {
clearTimeout(tidErr);
intErrCnt=0;showTLab();
var msg = "<font color=#FFFFFF><b>已放弃尝试再联机。现在将会播放下一首曲目。</font>";
if(blnStatusBar){ 
//window.status=(msg);
}
setTimeout('playAuto()',1000);}
}
// evtStop() 函式: 停止播放
function evtStop(){
clearTimeout(tidErr);
clearInterval(tidTLab);
showTLab();
intErrCnt=0;
imgChange("pauzt",0);
imgChange("playt",0);
imgChange("scope",0);
disp1.innerHTML = "<font class=title>等待中…</font>";
if(blnStatusBar){ 
//window.status=('等待…');return true;
}
}
// evtPause() 函式: 暂停播放
function evtPause(){
imgChange("pauzt",1)
imgChange("playt",0);
imgChange("stopt",0);
imgChange("scope",0);
clearInterval(tidTLab);
showTLab();
}
// evtPlay() 函式: 开始播放
function evtPlay(){
imgChange("pauzt",0)
imgChange("playt",1);
imgChange("stopt",0);
imgChange("scope",1);
tidTLab=setInterval('showTLab()',1000);
}
// showTLab() 函式: 显示时间长度
function showTLab(){
var ps = Exobud.playState;
if(ps==2 || ps==3){
var cp=Exobud.controls.currentPosition;
var cps=Exobud.controls.currentPositionString;
var dur=Exobud.currentMedia.duration;
var durs=Exobud.currentMedia.durationString;
if(blnElaps){
disp2.innerHTML = "<font color=#FFFFFF><b>"+cps + " | " + durs+"</b></font>";
var msg = "<font color=#FFFFFF><b>"+cActTit + " (" + cps + " | " + durs + ")</b></font>";
if(ps==2){msg = "(暂停) " + msg;}
if(blnStatusBar){ 
//window.status=(msg);
CourseButton.style.pixelLeft=Math.round((CourseButtonBox.offsetWidth-CourseButton.offsetWidth)*Exobud.controls.currentposition/Exobud.currentMedia.duration)
return true;
}
} else {
var laps = dur-cp;
var strLaps = wmpTime(laps);
disp2.innerHTML = "<font color=#FFFFFF><b>"+strLaps + " | " + durs+"</b></font>";
var msg = "<font color=#FFFFFF><b>"+cActTit + " (" + strLaps + " | " + durs + ")</b></font>";
if(ps==2){msg = "(暂停) " + msg;}
if(blnStatusBar){ 
//window.status=(msg);
CourseButton.style.pixelLeft=Math.round((CourseButtonBox.offsetWidth-CourseButton.offsetWidth)*Exobud.controls.currentposition/Exobud.currentMedia.duration)
return true;}
}
} else {
disp2.innerHTML = "<font color=#FFFFFF><b>00:00 | 00:00</b></font>";
}
}
// chgTimeFmt() 函式: 变更时间长度的显示方式
function chgTimeFmt(){
var wmps = Exobud.playState;
if(wmps==3){clearInterval(tidTLab);}
if(blnElaps){
blnElaps=false; disp2.innerHTML="<font color=#FFFFFF><b>倒数方式</b></font>";
} else {
blnElaps=true; disp2.innerHTML="<font color=#FFFFFF><b>正常方式</b></font>";
}
tidMsg=setTimeout('rtnTLab()',1000);
}
// rtnTLab() 函式: 传回时间长度
function rtnTLab(){
clearTimeout(tidMsg);
var wmps = Exobud.playState;
if(wmps==3){tidTLab=setInterval('showTLab()',1000);}
else {showTLab();}
}
// wmpTime() 函式: 计算时间长度
function wmpTime(dur){
var hh, min, sec, timeLabel;
hh=Math.floor(dur/3600);
min=Math.floor(dur/60)%60;
sec=Math.floor(dur%60);
if(isNaN(min)){ return "00:00";}
if(isNaN(hh) || hh==0){timeLabel="";}
else {
if(hh>9){timeLabel = hh.toString() + ":";}
else {timeLabel = "0" + hh.toString() + ":";}
}
if(min>9){timeLabel = timeLabel + min.toString() + ":";}
else {timeLabel = timeLabel + "0" + min.toString() + ":";}
if(sec>9){timeLabel = timeLabel + sec.toString();}
else {timeLabel = timeLabel + "0" + sec.toString();}
return timeLabel;
}

//滚动条事件
var EventObject=0,Old_X,New_X;
function button_down(){//拖动按钮按下事件
    EventObject=event.srcElement;
    Old_X=event.clientX;
    EventObject.setCapture();
    }
function button_move(){//拖动按钮移动事件
    if(EventObject){
        New_X=event.clientX;
        var MovePels=EventObject.style.pixelLeft+New_X-Old_X;
        var MaxBound=document.all(EventObject.id+"Box").offsetWidth-EventObject.offsetWidth;
        if(EventObject&&MovePels<=MaxBound&&MovePels>=0){
            EventObject.style.pixelLeft=MovePels;
            eval(EventObject.id+"Event("+EventObject.style.pixelLeft+","+MaxBound+")");
            Old_X=New_X;
            }
        }
    }
function button_up(){//拖动按钮松开事件
    if(EventObject){
        EventObject.releaseCapture();
        EventObject=0;
        }
    }
function CourseButtonEvent(l,m){//播放进程控制
    Exobud.controls.currentposition=Math.round(Exobud.currentMedia.duration*l/m);
    }
function VolumeButtonEvent(l,m){//音量控制
    var wmps=Exobud.playState;
    if(wmps == 3){clearInterval(tidTLab);}
    var ps = Exobud.settings;
    ps.volume=Math.round((l/m)*100);
    disp2.innerHTML = "<font color=#FFFFFF><b>音量: " + ps.volume + "%</b></font>";
    }
function TrackButtonEvent(l,m){//声道控制
    var n=Math.round(l/m*100);
    var ps = Exobud.settings;
    ps.balance=n==50?0:n>50?(n-50)*1.8:n<50?-(50-n)*1.8:0;
    }

vArray = new Array();
vArray[0] = 0;
vArray[1] = 10;
vArray[2] = 20;
vArray[3] = 30;
vArray[4] = 40;
vArray[5] = 50;
vArray[6] = 60;
vArray[7] = 70;
vArray[8] = 80;
vArray[9] = 90; 
vArray[10] = 100; 

function SetVolume(index)
{
var wmps=Exobud.playState;
if(wmps == 3){clearInterval(tidTLab);}
var ps = Exobud.settings;
ps.volume = vArray[index];
document.images["meter"].src = eval("meter" + index + ".src");
disp2.innerHTML="<font color=#FFFFFF><b>Vol. " + ps.volume +"%</b></font>";
if(ps.volume != 0 && ps.mute){ps.mute = false;imgChange("vmute", 0);}
if(ps.volume == 0 && !ps.mute){ps.mute = true;disp2.innerHTML="<font color=#FFFFFF><b>静音模式</b></font>"; imgChange("vmute", 1);}
tidMsg=setTimeout('rtnTLab()',1000);
}
function MeterClick(n)
{
SetVolume(n);
}
// wmpMute() 函式: 静音模式(Mute)
function wmpMute(){ 
var wmps=Exobud.playState;
if(wmps == 3){clearInterval(tidTLab);}
var ps = Exobud.settings;
if(!ps.mute){ps.mute = true;disp2.innerHTML="<font color=#FFFFFF><b>静音模式启动</b></font>"; imgChange("vmute", 1);}
else {ps.mute = false;disp2.innerHTML="<font color=#FFFFFF><b>静音模式关闭</b></font>"; imgChange("vmute", 0);}
tidMsg=setTimeout('rtnTLab()',1000);
}
//function wmpMute(){
// var wmps = Exobud.playState;
// if(wmps==3){clearInterval(tidTLab);}
// var ps = Exobud.settings;
// if(!ps.mute){
// ps.mute=true; disp2.innerHTML="开启静音模式"; imgChange("vmute",1);
// } else {
// ps.mute=false; disp2.innerHTML="关闭静音模式"; imgChange("vmute",0);
// }
// tidMsg=setTimeout('rtnTLab()',1000);
//}
// waitMsg() 函式: 显示因播放列表空白而无法播放的讯息
function waitMsg(){
capText.innerHTML="<p class=title>&nbsp;&copy;&nbsp;Cuiz.Net&nbsp;&trade;";
if(intExobudStat==1){disp1.innerHTML = "无法播放 － 播放列表上没有设定任何曲目。";}
if(intExobudStat==2){disp1.innerHTML = "无法播放 － 您没有选取播放列表上任何一首曲目。";}
//if(blnStatusBar){
//if(intExobudStat==1){ window.status=('无法播放 － 播放列表上没有设定任何曲目。'); return true;}
//if(intExobudStat==2){ window.status=('无法播放 － 您没有选取播放列表上任何一首曲目。'); return true;}
//}
}
// openPlist() 函式: 以弹出窗口显示播放清单内容
function openPlist(){
window.open("exobudpl.htm","mplist","top=50,left=320,width=400,height=400,scrollbars=no,resizable=yes,copyhistory=no");
}
// chkWmpState() 函式: 当播放程序动作变更时，传回 playState 的状态值
function chkWmpState(){
// 以下是状态值的说明:
// 0(未定义) 1(已停止播放) 2(已暂停播放) 3(正在播放中) 4(向前搜索) 5(向后搜索)
// 6(缓冲处理中) 7(等待中) 8(已播放完毕) 9(转换曲目中) 10(就绪状态)
return Exobud.playState;
}
// chkWmpOState() 函式: 当播放程序开启媒体档案准备播放时，传回 openState 的状态值
function chkWmpOState(){
// 以下是状态值的说明:
// 0(未定义) 8(转换媒体中) 9(寻找媒体中) 10(联机媒体中) 11(加载媒体中)
// 12(开启媒体中) 13(媒体已开启) 20(等待播放中) 21(正在开启不明的连结)
return Exobud.openState;
}
// chkOnline() 函式: 检查使用者的联机状态 (不一定每款面板都会使用)
function chkOnline(){
// 传回值: true(已联机到因特网) false(没有联机到因特网)
return Exobud.isOnline;
}



//
// ■ 进行动态按钮图文件的切换动作
// 
toggleKey = new Object();
toggleKey[0] = "_off";
toggleKey[1] = "_on";
toggleKey[2] = "_ovr";
toggleKey[3] = "_out";
toggleKey[4] = "_mdn";
toggleKey[5] = "_mup";
function imgChange(id,act){
if(document.images){ document.images[id].src = eval("img." + id + toggleKey[act] + ".src");}
}
// 当这段程序代码应用到播放器使用时：
// 以函式 imgChange('按钮识别名称',0) 进行的动作即使用 "off" 的图档；
// 以函式 imgChange('按钮识别名称',1) 进行的动作即使用 "on" 的图档。
// 下面的部份就是设定 "off" 与 "on" 的动态按钮图文件。
// vmute, pmode, rept, playt, pauzt, stopt 这些都是「按钮识别名称」。
if(document.images){
img = new Object();
// 「静音模式」按钮的图文件 (已关闭／已开启)
img.vmute_off = new Image();
img.vmute_off.src = "images/wave.gif";
img.vmute_on = new Image();
img.vmute_on.src = "images/waveup.gif";

// 「播放顺序模式」按钮的图文件 (循序／随机)
img.pmode_off = new Image();
img.pmode_off.src = "images/xunhuan.gif";
img.pmode_on = new Image();
img.pmode_on.src = "images/suiji.gif";
// 「是否重复播放」按钮的图文件 (不重复／重复)
img.rept_off = new Image();
img.rept_off.src = "images/s.gif";
img.rept_on = new Image();
img.rept_on.src = "images/r.gif";
// 「播放」按钮的图文件 (非播放中／播放中／鼠标移至时)
img.playt_off = new Image();
img.playt_off.src = "images/play.gif";
img.playt_on = new Image();
img.playt_on.src = "images/playup.gif";
img.playt_ovr = new Image();
img.playt_ovr.src = "images/playup.gif";
// 「暂停」按钮的图文件 (非暂停中／暂停中／鼠标移至时)
img.pauzt_off = new Image();
img.pauzt_off.src = "images/pause.gif";
img.pauzt_on = new Image();
img.pauzt_on.src = "images/pauseup.gif";
img.pauzt_ovr = new Image();
img.pauzt_ovr.src = "images/pauseup.gif";
// 「停止」按钮的图文件 (未被停止／已停止／鼠标移至时)
img.stopt_off = new Image();
img.stopt_off.src = "images/stop.gif";
img.stopt_on = new Image();
img.stopt_on.src = "images/stopup.gif";
img.stopt_ovr = new Image();
img.stopt_ovr.src = "images/stopup.gif";
// 「上一首曲目」按钮的图文件 (一般显示／鼠标移至时)
img.prevt_out = new Image();
img.prevt_out.src = "images/pre.gif";
img.prevt_ovr = new Image();
img.prevt_ovr.src = "images/preup.gif";
// 「下一首曲目」按钮的图文件 (一般显示／鼠标移至时)
img.nextt_out = new Image();
img.nextt_out.src = "images/bef.gif";
img.nextt_ovr = new Image();
img.nextt_ovr.src = "images/befup.gif";
// 「增加音量」按钮的图文件 (一般显示／鼠标移至时)
img.vup_out = new Image();
img.vup_out.src = "images/g_vup.gif";
img.vup_ovr = new Image();
img.vup_ovr.src = "images/g_vup_ovr.gif";
// 「减少音量」按钮的图文件 (一般显示／鼠标移至时)
img.vdn_out = new Image();
img.vdn_out.src = "images/g_vdn.gif";
img.vdn_ovr = new Image();
img.vdn_ovr.src = "images/g_vdn_ovr.gif";
// 「显示播放清单内容」按钮的图文件 (一般显示／鼠标移至时)
img.plist_out = new Image();
img.plist_out.src = "images/g_plist.gif";
img.plist_ovr = new Image();
img.plist_ovr.src = "images/g_plist.gif";
// 显示播放状态的 Scope 动态图文件 (静止／转动)
img.scope_off = new Image();
img.scope_off.src = "images/act.gif";
img.scope_on = new Image();
img.scope_on.src = "images/actup.gif";
}
function imgtog(tg,act){
if(tg=="vmute") { if(act=="2"){imgChange("vmute",1);} else {imgmute("vmute",0);} }
if(tg=="vdn") { if(act=="2"){imgChange("vdn",2);} else {imgChange("vdn",3);} }
if(tg=="vup") { if(act=="2"){imgChange("vup",2);} else {imgChange("vup",3);} }
if(tg=="pmode") { if(act=="2"){imgChange("pmode",1);} else {imgrnd();} }
if(tg=="rept") { if(act=="2"){imgChange("rept",1);} else {imgrept();} }
if(tg=="nextt") { if(act=="2"){imgChange("nextt",2);} else {imgChange("nextt",3);} }
if(tg=="prevt") { if(act=="2"){imgChange("prevt",2);} else {imgChange("prevt",3);} }
if(tg=="pauzt") { if(act=="2"){imgpauz(2);} else {imgpauz();} }
if(tg=="playt") { if(act=="2"){imgplay(2);} else {imgplay();} }
if(tg=="stopt") { if(act=="2"){imgstop(2);} else {imgstop();} }
if(tg=="plist") { if(act=="2"){imgChange("plist",2);} else {imgChange("plist",3);} }
}
function imgmute(){
var ps=Exobud.settings;
if(ps.mute){imgChange("vmute",1);}
else {imgChange("vmute",0);}
}
function imgrnd(){
if(blnRndPlay){imgChange("pmode",1);}
else {imgChange("pmode",0);}
}
function imgrept(){
if(blnRept){imgChange("rept",1);}
else {imgChange("rept",0);}
}
function imgpauz(f){
var wmps=Exobud.playState;
if(f==2){imgChange("pauzt",2);}
else {
if(wmps==2){imgChange("pauzt",1);}
else {imgChange("pauzt",0);}
}
}
function imgplay(f){
var wmps=Exobud.playState;
if(f==2){imgChange("playt",2);}
else {
if(wmps==3){imgChange("playt",1);}
else {imgChange("playt",0);}
}
}
function imgstop(f){
var wmps=Exobud.playState;
if(f==2){imgChange("stopt",2);}
else {
if(wmps==2 || wmps==3){imgChange("stopt",0);}
else {imgChange("stopt",1);}
}
}

// 是否自动播放?
// 设定当播放器加载页面时，是否自动播放(Auto Start)媒体文件：
// true = 自动播放 (一般站长会选择这个方式)
// false = 不要自动播放，由使用者手动播放
var blnAutoStart = true;

var blnRndPlay = false; 

var blnStatusBar = true; 

var blnShowVolCtrl = true;

var blnShowPlist = true;

// 是否使用字幕功能，开启字幕框?
// 设定是否使用SMIL字幕功能(Closed Captioning-须配合扩展名为"SMI"的纯文本文件使用)：
// true = 使用字幕功能，在字幕框中显示同步歌词或文字讯息(也可以包含图片等信息)
// false = 关闭字幕功能
var blnUseSmi = true;

var blnLoopTrk = true;

// 是否弹出窗口显示媒体档案信息?
// 设定在开始播放每一首曲目时，是否弹出窗口显示媒体档案信息(Media Info)：
// true = 显示媒体档案信息 (请认真考虑清楚，因为浏览者可能会感到厌烦的，此功能只适合测试用)
// false = 不显示媒体档案信息
var blnShowMmInfo =false;

function openPlaylist(layername)
{
	if (opener)
	{
		if (document.getElementById(layername).style.visibility == 'visible')
			{
				document.getElementById(layername).style.visibility = 'hidden';
				window.resizeTo(screen.availWidth, screen.availHeight);
			}
		else
			{
				document.getElementById(layername).style.visibility = 'visible';
				window.resizeTo(screen.availWidth, screen.availHeight);
			}
	}
	else
	{
		if (document.getElementById(layername).style.visibility == 'visible') 
			document.getElementById(layername).style.visibility = 'hidden';
		else
			document.getElementById(layername).style.visibility = 'visible';
	}
}


function wmpVolMove(layername)
{
	if (event.x - 6 > 152 && event.x - 6 < 213)
	{
		document.getElementById(layername).style.posLeft = event.x - 6;

		var wmps=Exobud.playState;

		if (wmps == 3) clearInterval(tidTLab);

		var ps = Exobud.settings;

		if (ps.mute)
		{
			ps.mute = false;
			disp2.innerHTML="Speach";
			imgChange('vmute',0);
		}
		
		else
		{
			//   0% = 161 ~ 166
			//  10% = 167 ~ 172
			//  20% = 173 ~ 178
			//  30% = 179 ~ 184
			//  40% = 185 ~ 190
			//  50% = 191 ~ 196
			//  60% = 197 ~ 202
			//  70% = 203 ~ 208
			//  80% = 209 ~ 214
			//  90% = 215 ~ 220
			// 100% = 221 ~ 226

			if (event.x - 6 >  152 && event.x - 6 <  153) ps.volume = vmin;
			else if (event.x - 6 >= 153 && event.x - 6 <= 156) ps.volume = 5;
			else if (event.x - 6 >= 156 && event.x - 6 <= 159) ps.volume = 10;
			else if (event.x - 6 >= 159 && event.x - 6 <= 162) ps.volume = 15;
			else if (event.x - 6 >= 162 && event.x - 6 <= 165) ps.volume = 20;
			else if (event.x - 6 >= 165 && event.x - 6 <= 168) ps.volume = 25;
			else if (event.x - 6 >= 168 && event.x - 6 <= 171) ps.volume = 30;
			else if (event.x - 6 >= 171 && event.x - 6 <= 174) ps.volume = 35;
			else if (event.x - 6 >= 174 && event.x - 6 <= 177) ps.volume = 40;
			else if (event.x - 6 >= 177 && event.x - 6 <= 180) ps.volume = 45;
			else if (event.x - 6 >= 180 && event.x - 6 <= 183) ps.volume = 50;
			else if (event.x - 6 >= 183 && event.x - 6 <= 186) ps.volume = 55;
			else if (event.x - 6 >= 186 && event.x - 6 <= 189) ps.volume = 60;
			else if (event.x - 6 >= 189 && event.x - 6 <= 192) ps.volume = 65;
			else if (event.x - 6 >= 192 && event.x - 6 <= 195) ps.volume = 70;
			else if (event.x - 6 >= 195 && event.x - 6 <= 198) ps.volume = 75;
			else if (event.x - 6 >= 198 && event.x - 6 <= 201) ps.volume = 80;
			else if (event.x - 6 >= 201 && event.x - 6 <= 204) ps.volume = 85;
			else if (event.x - 6 >= 204 && event.x - 6 <= 207) ps.volume = 90;
			else if (event.x - 6 >= 207 && event.x - 6 <= 210) ps.volume = 95;
			else if (event.x - 6 == 210 && event.x - 6 <= 213) ps.volume = vmax;
			else ps.volume = ps.volume;
			
			disp2.innerHTML="Vol. " + ps.volume +"%";
		}

		tidMsg=setTimeout('rtnTLab()',1000);
	}
}



var via = parent;
	var write_via = "parent";
	var iLoc= self.location.href;

	function playSel(){via.wmpStop();via.startExobud();}
	function refreshPl(){ self.location=iLoc;}
	function chkSel(){via.chkAllSel();refreshPl();}
	function chkDesel(){via.chkAllDesel();refreshPl();}

	function dspList(n){
		
		var elmABlock= 10;// 设定每页可显示多少个播放项目
		var totElm = via.intMmCnt;
		var totBlock= Math.floor((via.intMmCnt -1) / elmABlock)+1;
		var cblock;
		if(n==null){cblock=1;}
		else{cblock=n;}
		var seed;
		var limit;
		if(cblock < totBlock){seed= elmABlock * (cblock-1); limit =  cblock*elmABlock -1}
		else{seed=elmABlock * (cblock-1); limit= totElm-1;}

	if(via.intMmCnt >0 ){
		var list_num=0;
		mmList.innerHTML='<p>';
		for (var i=seed; i <= limit; i++)
		{	list_num = i + 1;
			if(via.objMmInfo[i].selMm=="t"){elm='&nbsp;&nbsp;<input type=checkbox  style="cursor:hand;" onfocus=blur() onClick='+ write_via + '.chkItemSel('+ i +'); checked>' ;}
			else{elm = '&nbsp;<input type=checkbox style="cursor:hand;" onfocus=blur() onClick='+ write_via + '.chkItemSel('+ i +');>' ;}
			elm = elm + '&nbsp;' + list_num + '. ' 
			elm = elm + '<a href=javascript:' + write_via + '.selPlPlay(' + i + ');'
			elm = elm + ' onfocus=blur() onclick=\"this.blur();\">'
			if(via.objMmInfo[i].mmTit =="nAnT"){ elm = elm + "未指定媒体标题";}
			else{elm = elm + via.objMmInfo[i].mmTit;}
			elm= elm+  '</a><br>';
			mmList.innerHTML=mmList.innerHTML+elm;
		}

                var pmin=new Number(cblock)-3;
		var pmax=new Number(cblock)+3;
		var ppre=new Number(cblock)-1;
		var pnext=new Number(cblock)+1;
		if(pmin<=3){pmin=1;pmax=7;}
		if(pmax>totBlock){pmax=totBlock;}
		if(ppre<=1){ppre=1;}
		if(pnext>totBlock){pnext=totBlock;}

		for(var j=pmin; j<=pmax; j++){
			page='<a href=javascript:dspList('+j+') onFocus=blur()>['+j+']</a> ';
		}

		pageInfo.innerHTML='&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=javascript:dspList(1) onfocus=blur() title=首页><font face="Webdings">9</font></a>&nbsp;<a href=javascript:dspList('+ppre+') onfocus=blur() title=上一页><font face="Webdings">3</font></a>&nbsp;第<font color=#3399FF><b>'+cblock+ '</b></font>页&nbsp;共'+ totBlock+'页&nbsp;共'+totElm+'首&nbsp;<a href=javascript:dspList('+pnext+') onfocus=blur() title=下一页><font face="Webdings">4</font></a>&nbsp;<a href=javascript:dspList('+totBlock+') onfocus=blur() title=尾页><font face="Webdings">:</font></a>';

	}
	else { mmList.innerHTML='<div align=center> </div>'; }
	 }



// List Popping Up
function openPlaylist_i(layername)
{
	if (parent.opener)
	{
		if (parent.document.getElementById(layername).style.visibility == 'visible')
			{
				parent.document.getElementById(layername).style.visibility = 'hidden';
				parent.resizeTo(255,138);
			}
		else
			{
				parent.document.getElementById(layername).style.visibility = 'visible';
				parent.resizeTo(255,388);
			}
	}
	else
	{
		if (parent.document.getElementById(layername).style.visibility == 'visible') 
			parent.document.getElementById(layername).style.visibility = 'hidden';
		else
			parent.document.getElementById(layername).style.visibility = 'visible';
	}
}
