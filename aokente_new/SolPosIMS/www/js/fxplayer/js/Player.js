//<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
/*
Player
	Construction
		Player( parent , url , autoStart )
	Operations
		void play()
		void stop()
		void pause()
		void setVolume(int volume=lastVolume)
		void mute()
		void setUrl(str)
		
		String getTitle()
		String getAuthor()
		String getMediaName()
		String getUrl(method)
		int getVolume()
		long getCurrentPosition()	
	Attributes
	
	Attention
		the page must has tag "body"
		each FXPlayer Object must only have only have ONE Player Object
*/
function Player( parent , url , autoStart )
{
//private Attributes:
	var _this = null;
	var lastvolume = 0;
	var id = parent.id;
	var browser = parent.browser;
	this.wmp = null;	//播放器的object对象，目前仅支持WMP，以后可能会支持Real Player
	this.status = 0;	//播放器的状态，0-stop;1-pause;2-play
	this.divplayer = null;	//放播放器的隐藏的div，在构造函数中创建
	
	this.title = "";
	this.author = "";
	this.url = url;

//Constructor:
	this._init = function(){
		_this = this;
		//create windows media player for different browser
		_this.wmp = document.createElement("object");
		_this.wmp.setAttribute("id",id);
		_this.wmp.setAttribute("name",id);
		
		if (browser == "ie")
			_this.wmp.setAttribute("classid","CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6");	//for IE
		else if (browser == "firefox")
			_this.wmp.setAttribute("type","application/x-ms-wmp");	//for firefox
		else
			_this.wmp.setAttribute("type","application/x-ms-wmp");	//for other(not test)
		_this.wmp.setAttribute("width","100%");
		_this.wmp.setAttribute("height","100%");
		
		var param;
		param = document.createElement("param");
		param.setAttribute("name","autoStart");
		param.setAttribute("value",autoStart);
		_this.wmp.appendChild( param );
		
		param = document.createElement("param");
		param.setAttribute("name","URL");
		param.setAttribute("value","");
		if (url){
			_this.setUrl(url);
			if (autoStart == "true")
				_this.status = 2;
		}
		_this.wmp.appendChild( param );
		

		//create hidden div
		var x=document.getElementById(id+"_player");
		if ( x )
		{
			x.parentNode.removeChild(x);
		}
		_this.divplayer = document.createElement("div");
		_this.divplayer.setAttribute("id",id+"_player");
		_this.divplayer.setAttribute("name",id+"_player");
		_this.divplayer.style.position = "absolute";
		_this.divplayer.style.top = "0px";
		_this.divplayer.style.right = "0px";
		_this.divplayer.style.width = "200px";
		_this.divplayer.style.height = "70px";
		_this.divplayer.style.visibility = "hidden";
		
		

		//insert wmp into hidden div
		_this.divplayer.appendChild( _this.wmp );
		
		//insert hidden div into page
		document.body.appendChild(_this.divplayer);
			
		
		if (browser == "ie" && _this.status == 0)
			_this.stop();
		_this._createEventHandler();
	};


//public operations:
	this.play = function(){
		_this.wmp.controls.play();
	};
	this.stop = function(){
		_this.wmp.controls.stop();
	};
	this.pause = function(){
		_this.wmp.controls.pause();
	};
	this.mute = function(){
		lastvolume = _this.wmp.settings.volume;
		_this.wmp.settings.volume = 0;
	};
	this.setVolume = function( volume ){
		if (volume){
			if (volume>=0 && volume<=100){
				_this.wmp.settings.volume = volume;
			}
		}
		else{
			_this.wmp.settings.volume = lastvolume;
		}
	};
	this.setUrl = function( str ){
		if ( str != "" ){
			_this.url = str;
			_this.wmp.URL = str;
		}
	};
	this.setCurrentPosition = function(pos){
		if (pos){
			_this.wmp.controls.currentPosition = pos;
		}
	};

	//获取正在播放的媒体名
	this.getMediaName = function(){
		if (_this.wmp.currentMedia)
			return _this.wmp.currentMedia.name;
		else
			return null;
	};
	//获取用户指定的媒体名
	this.getTitle = function(){
		return _this.title;
	};
	this.getAuthor = function(){
		return _this.author;
	};
	this.getUrl = function( method ){
		//method=1则返回相对路径，否则返回绝对路径
		if (method!=null && method == 1)
			return _this.url;
		else
			return _this.wmp.URL;
	};
	this.getVolume = function(){
		return _this.wmp.settings.volume;
	};
	this.getCurrentPosition = function(){
		return _this.wmp.controls.currentPosition;
	};
	this.getDuration = function(){
		return _this.wmp.currentMedia.duration;
	};
	this.getDownloadProgress = function(){
		return _this.wmp.network.downloadProgress;
	};

//private methods:
	//创建PlayStateChange捕获代码
	this._createEventHandler = function(){
		//alert("_createEventHandler");
		document.writeln("<script for=\""+id+"\" event=\"PlayStateChange(NewState)\">");
		document.writeln("FXPlayer._PlayStateChange( \"" + id + "\", NewState );");
		document.writeln("</script>");
	};
	//call Constructor
	this._init();
}