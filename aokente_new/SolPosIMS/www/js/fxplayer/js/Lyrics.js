//<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
function Word(time,word){
	this.time = time;
	this.word = word;
}


function Lyrics( parent )
{
	var _this = null;

	this.ar = "";
	this.ti = "";
	this.al = "";
	this.by = "";
	this.offset = "";
	this.key = "";
	
	this.array = new Array();

	this.divlyrics = null;	//放歌词的div
	this.formerid = 0;	//之前播放的那句歌词
	this.currentid = 0;	//正在播放的歌词
	
	this.baseTop = 0;		//基准线
	this.count = 0;
	this.step = 3;
	this.timer = null;
	
	var lrcpath = "";

//Constructor
	this._init = function(){
		_this = this;
	};
	this.setDiv = function( o )
	{
		if (o)
		{
			o.innerHTML = "";
			o.style.overflow = "hidden";

			_this.baseTop = parseInt(o.offsetHeight/3);
			
			var div = document.createElement("div");
			div.style.position = "absolute";
			div.align = "center";
			div.style.width = "100%";
			div.style.top = _this.baseTop + "px";
			div.style.left = "0px";
			o.appendChild(div);
			_this.divlyrics = div;
			
			_this._refresh();
		}
	};
	this.resize = function(o)
	{
		if (o)
		{
			_this.baseTop = parseInt(o.offsetHeight/3);
		}
	}

//public operations:
	this.search = function( title , author ){
		//alert ("search");
		//alert ("title=" + title + ",author=" + author);
		//根据title和author搜索歌词
		if (title){
			FXPlayer.loadFile("searchlrc.asp?title="+title+"&author="+author , "get" , _this.loadLrcFile );
		}
		else{
			_this._loadLyrics(FXPlayer.Error.LOADFILE);
		}
	};
	this.loadLrcFile = function( str ){
		if (str != FXPlayer.Error.LOADFILE && str != lrcpath){
			lrcpath = str;
			FXPlayer.loadFile(str, "get" ,_this._loadLyrics);
		}
		else{
			_this._loadLyrics(FXPlayer.Error.LOADFILE);
		}
	};
	this.getTime = function(str){
		//将lrc中的时间格式转换成整数
		var time =0;
		//t1[0]:mm
		//t1[1]:ss.ff
		var t1 = str.split(":");
		if(t1.length < 2)
			return 0;
		if(isNaN(t1[0]))
			return 0;
		if(t1[1].indexOf(".")>0){
			//t2[0]:ss
			//t2[1]:ff
			var t2 = t1[1].split(".");
			time = t1[0]*60*1000+t2[0]*1000+t2[1]*10;
		}
		else
			time = t1[0]*60*1000+t1[1]*1000;
		return time;
	};
	
	this.getCurrentId = function( pos ){
		var temp = 0;
		if (_this.array.length>0){
			//分析出当前歌词的位置
			for (var i = 0; i < _this.array.length;i++){
				if (_this.array[i].time >= pos * 1000 ){
					i=i-1;
					break;
				}
			}
			if (i<_this.array.length)
				temp = i;
			else
				temp = _this.array.length-1
		}
		return temp;
	};
//private operations:
	this._loadLyrics = function( str ){
		if(str != FXPlayer.Error.LOADFILE){
			if (_this._load(str) == true){
				//alert ("ti" + _this.ti);
				_this.count = _this.array.length+1;
				_this.formerid = 0;
				_this.currentid = 0;
				_this._refresh();
				return true;
			}
			else{
				//alert ("false:" + _this.array.length);
				return false;
			}
		}
		else{
			return false;
		}
	};
	this._refresh = function(){
		if (_this.divlyrics)
		{
			if (_this.array.length>0)
			{
				var str = "";
				var temp;
				for ( var i=0;i<_this.array.length ;i++ ){
					temp = _this.array[i];
					str += "<div id='ll" + i + "' class='fxlyrics_normal'>" + temp.word + "</div>";
				}
				_this.divlyrics.innerHTML=_this.divlyrics.innerHTML+str;
			}
		}
	}
	this._move = function(){
		var currentWord = document.getElementById("ll" + (_this.currentid));
		try{
			if (_this.formerid>=0){
				document.getElementById("ll" + (_this.formerid)).setAttribute("class","fxlyrics_normal");
				document.getElementById("ll" + (_this.formerid)).setAttribute("className","fxlyrics_normal");
			}
			
			_this.formerid = _this.currentid;
			currentWord.setAttribute("class","fxlyrics_playing");
			currentWord.setAttribute("className","fxlyrics_playing");
			
			if ( (currentWord.offsetTop+_this.divlyrics.offsetTop) - _this.baseTop > _this.step  ){
				_this.divlyrics.style.top = (_this.divlyrics.offsetTop - _this.step ) + "px";
				
			}
			else if ( _this.baseTop - (currentWord.offsetTop+_this.divlyrics.offsetTop)  > _this.step  ){
				_this.divlyrics.style.top = (_this.divlyrics.offsetTop + _this.step ) + "px";
			}
			else{
				_this.divlyrics.style.top = (_this.baseTop - currentWord.offsetTop) + "px";
				window.clearInterval(_this.timer);
			}
		}
		catch(e){
		}
	}
	this.refreshTimer = function(){
		if (_this.array.length>0){
			//分析出当前歌词的位置
			//document.getElementById("out").innerHTML = parent.player.getCurrentPosition();
			for (var i = 1; i < _this.array.length-1;i++){
				if (_this.array[i].time >= parent.player.getCurrentPosition() * 1000 ){
					i=i-1;
					break;
				}
			}
			//设置currentid为当前位置，并进行动态移动
			if (_this.currentid != i){
				_this.currentid = i;
				window.clearInterval(_this.timer);
				_this.timer = setInterval(_this._move,100);
			}
		}
	}
	
	//解析lrc格式的文本，将歌词存放到array数组中，数组按时间降序排列
	//时间以整数形式存储
	//解析失败返回false
	this._load = function ( str ){
		_this.array = new Array();
		var lrc =str.split(/\n/);
		//alert (lrc);
		if(lrc.length>5){
			for (var i=0;i<lrc.length ;i++ ){
				if (lrc[i].replace(/(^\s*)|(\s*$)/g, "") != ""){
					var l1 = lrc[i].split("[");
					if (l1.length > 1){
						var l2 = l1[l1.length-1].split("]");	//最后一条记录分割，用于判断是否是时间还是参数，另外，如果是时间，则将歌词保存到word

						if ( _this.getTime(l2[0]) == 0 ){
							//不是时间，则是歌词的参数
							var s = l2[0].split(":");
							if (s[0]=="ar")
								_this.ar = s[1];
							else if (s[0]=="ti")	
								_this.ti = s[1];
							else if (s[0]=="al")	
								_this.al = s[1];
							else if (s[0]=="by")	
								_this.by = s[1];
							else if (s[0]=="offset")	
								_this.offset = s[1];
							else if (s[0]=="key")	
								_this.key = s[1];
						}
						else{
							var word = l2[1];
							for (var j = 1; j < l1.length ; j++){
								var l3 = l1[j].split("]");
								var t = _this.getTime(l3[0]);
								if(t>0){
									_this.array.push( new Word( t,word ) );
								}
							}
						}
					}
				}
			}
			_this.array.sort(_this._sortcmp);
			
//			var tmpstr = "";
//			for (var j = 0; j < _this.array.length ; j++){
//				tmpstr = (tmpstr + '\n' + _this.array[j].time + ':' + _this.array[j].word);
//			}
//			alert (tmpstr);
			return true;
		}
		else{
			return false;
		}
	};
	this._sortcmp = function(x,y){
		if (x.time>y.time)  
			return 1;
		else if(x.time<y.time)
			return -1;
		else
			return 0;
	};



	//call Constructor
	this._init();
}
