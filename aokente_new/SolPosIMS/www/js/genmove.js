///////////////////////////////////////////////////////////////////////
//     This script was designed by Erik Arvidsson for WebFX          //
//                                                                   //
//     For more info and examples see: http://webfx.eae.net          //
//     or contact Erik at http://webfx.eae.net/contact.html#erik     //
//                                                                   //
//     Feel free to use this code as lomg as this disclaimer is      //
//     intact.                                                       //
///////////////////////////////////////////////////////////////////////

var checkZIndex = true;

var dragobject = null;
var tx;
var ty;

var ie5 = document.all != null && document.getElementsByTagName != null;

function getReal(el) {
	temp = el;

	while ((temp != null) && (temp.tagName != "BODY")) {
		if ((temp.className == "noticeboard") || (temp.className == "handle")){
			el = temp;
			return el;
		}
		temp = temp.parentElement;
	}
	return el;
}


function noticeboard_onmousedown() {
	el = getReal(window.event.srcElement)
	
	if (el.className == "noticeboard" || el.className == "handle") {
		if (el.className == "handle") {
			tmp = el.getAttribute("handlefor");
			if (tmp == null) {
				dragobject = null;
				return;
			}
			else
				dragobject = eval(tmp);
		}
		else 
			dragobject = el;
		
		if (checkZIndex) makeOnTop(dragobject);
		
		ty = window.event.clientY - getTopPos(dragobject);
		tx = window.event.clientX - getLeftPos(dragobject);
		
		window.event.returnValue = false;
		window.event.cancelBubble = true;
	}
	else {
		dragobject = null;
	}
}

function noticeboard_onmouseup() {
	if(dragobject) {
		dragobject = null;
	}
}

function noticeboard_onmousemove() {
	if (dragobject) {
		if (window.event.clientX >= 0 && window.event.clientY >= 0) {
			dragobject.style.left = window.event.clientX - tx;
			dragobject.style.top = window.event.clientY - ty;
		}
		window.event.returnValue = false;
		window.event.cancelBubble = true;
	}
}

function getLeftPos(el) {
	if (ie5) {
		if (el.currentStyle.left == "auto")
			return 0;
		else
			return parseInt(el.currentStyle.left);
	}
	else {
		return el.style.pixelLeft;
	}
}

function getTopPos(el) {
	if (ie5) {
		if (el.currentStyle.top == "auto")
			return 0;
		else
			return parseInt(el.currentStyle.top);
	}
	else {
		return el.style.pixelTop;
	}
}

function makeOnTop(el) {
	var daiz;
	var max = 0;
	var da = document.all;
	
	for (var i=0; i<da.length; i++) {
		daiz = da[i].style.zIndex;
		if (daiz != "" && daiz > max)
			max = daiz;
	}
	
	el.style.zIndex = max + 1;
}

if (document.all) { //This only works in IE4 or better
	document.onmousedown = noticeboard_onmousedown;
	document.onmouseup = noticeboard_onmouseup;
	document.onmousemove = noticeboard_onmousemove;
}

document.write("<style>");
document.write(".noticeboard		{cursor: move;}");
document.write(".handle		{cursor: move;}");
document.write("</style>");