//<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
/*
FXPlayer
	Construction
		FXPlayer ( url , autoStart = "true")
	Operations
		void createPlaylist(ttplaylistpath=null)
		void createLyrics( lrcpath=null )
		void addEventListener ( actionName , fncallback )
			actionName:
				"onready"
				"onplaying"		the fncallback will be called by every sometime second,when the media is playing


		static String browserDetect()
		static void loadFile( url , method , fncallback)
		XMLDocument void loadFile( url , fncallback , async=true)
	Attributes
		static int count		//the number of created FXPlayer
		static Array instance	//keep all FXPlayer instances
*/

function FXPlayer( url , autoStart )
{
//private Attributes:
	var _this = null;

	this.id = "";
	this.browser = "undetected";
	this.domready = false;
	
	this.player = null;		//播放器
	this.playlist = null;	//播放列表
	this.lyrics = null;		//歌词列表
	
	this.ui = null;

	this.timer = null;	//播放状态时，每半秒钟调用1次_onPlaying函数
	
	this.evtOnDomReady = new Array();
	this.evtOnPlay = new Array();
	this.evtOnPlaying = new Array();
	this.evtOnPause = new Array();
	this.evtOnEnd = new Array();
	this.evtOnStop = new Array();
	this.evtOnBuffer = new Array();
	this.evtOnWaiting = new Array();
	
	
	this.divdebug = null;

//Constructor:
	this._init = function(){
		_this = this;
		_this.browser = FXPlayer.browserDetect();
		FXPlayer.count ++;
		FXPlayer.instance.push(_this);
		_this.id = "FXPlayer" + FXPlayer.count;

		if (autoStart == false || autoStart == "false" )
			autoStart = "false";
		else if (autoStart == true || autoStart == "true" )
			autoStart = "true";
		else
			autoStart = "true";

		_this.player = new Player( _this , url , autoStart);
		
		//_this._isReady();
		setTimeout(_this._isReady,500);
		
		_this._createDebug();
	};
	
//public operations:
	this.createPlaylist = function( ttplaylistpath ){
		_this.playlist = new Playlist( _this );
		if ( ttplaylistpath )
		{
			_this.playlist.loadTTPlaylist(ttplaylistpath);
		}
		else
		{
			/*
			_this.addEventListener("ondomready",function(){
				_this.playlist.add( _this.player.getMediaName(),"Unknow",_this.player.getUrl() );
			});
			*/
		}
	};
	this.createLyrics = function( lrcpath ){
		_this.lyrics = new Lyrics( _this );

		if ( lrcpath )
		{
			_this.lyrics.loadLrcFile(lrcpath);
		}
	};
	this.createUI = function( path ){
		_this.ui = new UI( _this , path );
	};
	
	this.addEventListener = function( actionName , fncallback ){
		if (actionName.toLowerCase() == "ondomready"){
			if (_this.domready == false)
			{
				//如果播放器还未加载，则会被加入到domready事件响应中
				_this.evtOnDomReady.push ( fncallback );
			}
			else
			{
				//如果播放器已经被加载，那么回调函数将被立刻执行
				fncallback();
			}
		}
		else if (actionName.toLowerCase() == "onplay"){
			_this.evtOnPlay.push ( fncallback );
		}
		else if (actionName.toLowerCase() == "onplaying"){
			_this.evtOnPlaying.push ( fncallback );
		}
		else if (actionName.toLowerCase() == "onpause"){
			_this.evtOnPause.push ( fncallback );
		}
		else if (actionName.toLowerCase() == "onend"){
			_this.evtOnEnd.push ( fncallback );
		}
		else if (actionName.toLowerCase() == "onstop"){
			_this.evtOnStop.push ( fncallback );
		}
		else if (actionName.toLowerCase() == "onbuffer"){
			_this.evtOnBuffer.push ( fncallback );
		}
		else if (actionName.toLowerCase() == "onwaiting"){
			_this.evtOnWaiting.push ( fncallback );
		}
	};
//private methods:
	this._isReady = function(){
		if ( !_this.player.wmp.controls )
		{
			setTimeout(_this._isReady,100);
		}
		else
		{
			_this._onDomReady();
		}
	}
	this._onPlay = function(){
		_this.player.status = 2;
		for (var i in _this.evtOnPlay){
			_this.evtOnPlay[i]();
		}
		clearInterval(_this.timer);
		_this.timer = setInterval(_this._onPlaying,500);
	};
	this._onPlaying = function(){
		//Callback Onplaying
		for (var i in _this.evtOnPlaying){
			_this.evtOnPlaying[i]();
		}
	};
	this._onStop = function(){
		_this.player.status = 0;
		clearInterval(_this.timer);

		for (var i in _this.evtOnStop){
			_this.evtOnStop[i]();
		}

	};
	this._onPause = function(){
		_this.player.status = 1;
		for (var i in _this.evtOnPause){
			_this.evtOnPause[i]();
		}
		clearInterval(_this.timer);
	};
	this._onEnd = function(){
		for (var i in _this.evtOnEnd){
			_this.evtOnEnd[i]();
		}
	};
	this._onBuffer = function(){
		for (var i in _this.evtOnBuffer){
			_this.evtOnBuffer[i]();
		}
	};
	this._onReady = function(){
	};
	this._onWaiting = function(){
		for (var i in _this.evtOnWaiting){
			_this.evtOnWaiting[i]();
		}
	};
	
	//fired when object is ready
	this._onDomReady = function(){
		_this.domready = true;
		for (var i in _this.evtOnDomReady){
			_this.evtOnDomReady[i]();
		}
	};
	
//test method
	this._createDebug = function()
	{
		_this.divdebug = document.createElement("div");
		_this.divdebug.setAttribute("id",_this.id+"_debug");
		_this.divdebug.setAttribute("name",_this.id+"_debug");

		_this.divdebug.style.position = "absolute";
		_this.divdebug.style.top = "100px";
		_this.divdebug.style.right = "0px";
		_this.divdebug.style.width = "200px";
		_this.divdebug.style.height = "70px";

		//insert hidden div into page
		x=document.getElementsByTagName("body")[0];
		if (x)
			x.appendChild(_this.divdebug);
	};
	this.printPlaylist=function()
	{
		var str="";
		for (var i in _this.playlist.playlistitem)
		{
			str+=(_this.playlist.playlistitem[i].title + "<br />");
		}
		_this.divdebug.innerHTML = str;
		
	};
	this.printLyrics=function()
	{
		var str="";
		for (var i in _this.lyrics.array)
		{
			str+=(_this.lyrics.array[i].time + "," + _this.lyrics.array[i].word + "<br />");
			//alert (_this.playlist.playlistitem[i].title);
		}
		_this.divdebug.innerHTML = str;
	};


	this._init();	//call Constructor
}

//static variable
FXPlayer.count = 0;	
FXPlayer.instance = new Array();

//static methods
FXPlayer.browserDetect = function(){
	if ( navigator.appName == "Microsoft Internet Explorer" )
		return "ie";
	else if ( navigator.appName == "Netscape" )
		return "firefox"
	else
		return "unknow"
};
FXPlayer.Error = {
	LOADFILE : "fxplayerlferror"
};
FXPlayer.loadFile = function ( url , method , fncallback){
	var request = false;
	try {
		request = new XMLHttpRequest();
	} 
	catch (trymicrosoft) {   
		try {     
			request = new ActiveXObject("Msxml2.XMLHTTP");   
		} 
		catch (othermicrosoft) {     
			try {       
				request = new ActiveXObject("Microsoft.XMLHTTP");     
			} 
			catch (failed) {      
				request = false;     
			}   
		}
	}
	if (!request){
		fncallback( FXPlayer.Error.LOADFILE );
	}
	else{
		method += "";
		if (method.toLowerCase()!="post")
			method = "get";
		request.open(method, url, true);
		request.setRequestHeader("charset","UTF-8");
		request.onreadystatechange = function(){
			if (request.readyState == 4)
				if (request.status == 200){
					fncallback( request.responseText );
				}
				else{
					fncallback( FXPlayer.Error.LOADFILE );
				}
		};
		request.send(null);
	}
};
FXPlayer.getTime = function(duration)
{
	var str="";

	str += (parseInt(duration/3600) + ":" );
	duration -= parseInt(duration/3600)*3600;
	str += (parseInt(duration/60) + ":" );
	duration -= parseInt(duration/60)*60;
	str += (parseInt(duration));

	return str;
};
FXPlayer.loadXMLFile = function( path , fncallback , async )
{
	var xmlDoc = null;
	if (async!= true && async != false)
		async = true;
		
	if (window.ActiveXObject){
		xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
		xmlDoc.async=async;
	}
	else if (document.implementation && document.implementation.createDocument){
		xmlDoc= document.implementation.createDocument("","doc",null);
	}
	if (typeof xmlDoc!="undefined"){
		xmlDoc.load(path);
	}  
	if (window.ActiveXObject){
		xmlDoc.onreadystatechange = function(){
			if (xmlDoc.readyState == 4)
			{
				fncallback( xmlDoc );
			}
		};
	}
	else if (typeof xmlDoc!="undefined"){
		xmlDoc.onload = function (){
			fncallback( xmlDoc );
		};
	}
	return xmlDoc;
};
FXPlayer._PlayStateChange = function( id , NewState){
	var _this = null;
	for (var i in FXPlayer.instance){
		if (FXPlayer.instance[i].id == id ){
			_this = FXPlayer.instance[i];
			break;
		}
	}
	if (_this){
		//document.getElementById("out").innerHTML = document.getElementById("out").innerHTML + NewState + ",";
		switch (NewState){
			case 1:	//Stopped
				_this._onStop();
				break;
			case 2:	//Paused
				_this._onPause();
				break;
			case 3:	//Playing
				_this._onPlay();
				break;
			case 6:	//Buffering
				_this._onBuffer();
				break;
			case 7://Waiting
				_this._onWaiting();
				break;
			case 8:	//Ended
				_this._onEnd();
				break;
			case 10:	//Ready
				_this._onReady();
				break;
		}
	}
};
