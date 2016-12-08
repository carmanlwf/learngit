
function PlayRecord()
{

}

function play(con,str) 
{
return PlayRecord.play(con,str);
}

 PlayRecord.bMoveable=true; 
 //PlayRecord.recordstr="";
 PlayRecord.init = function()
{
	document.writeln('<iframe id=playrecordLayer  frameborder=0 style="position: absolute; width:310px;height:290px; left:100px;top:100px; z-index: 9998; display:none" scrolling=no src="../QC/player.html"></iframe>');
}

PlayRecord.init();


 PlayRecord.play= function(cont,str) 
 {
  // PlayRecord.recordstr=str;

	var dads = document.all.playrecordLayer.style;
	var th = cont;
	var ttop = cont.offsetTop;
	var thei = cont.clientHeight; 
	var tleft = cont.offsetLeft;
	var ttyp = cont.type;
	while (cont = cont.offsetParent){ttop+=cont.offsetTop; tleft+=cont.offsetLeft;}
	var whei = typeof(window.dialogHeight)=="undefined"?parseInt(document.body.offsetHeight):parseInt(window.dialogHeight);
	dads.top = (ttyp=="image")? ttop+thei : ttop+thei+6;
	dads.left = tleft;
	dads.display = '';
	playrecordLayer.location.href ='../QC/player.html?id='+str;
	event.returnValue=false;
}
if(typeof(JsDebug) != "undefined" && JsDebug)
    alert("app.player.js");