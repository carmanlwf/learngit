// JavaScript Document


function UI( parent , path )
{
	var _this = null;
	var root = null;
	var strCommand = "";
	
	this.divwindow = null;
	this.skinpath = "";
	this.skinName = "";
	this.skinAuthor = "";
	this.skinAuthorEmail = "";
	this.css = null;
	this.css2=null;
	this.player_window={
		window : null,
		btnPlay : null,
		btnPause : null,
		btnStop : null,
		btnPrev : null,
		btnNext : null,
		btnMute : null,
		btnOpen : null,
		progress : null,
		volume : null,
		visual : null,
		icon : null,
		info : null,
		led : null,
		stereo : null,
		status : null
	};
	this.equalizer_window={
		window : null,
		close : null,
		enabled : null,
		profile : null,
		reset : null,
		balance : null,
		surround : null,
		preamp : null,
		eqfactor : []
	};
	this.playlist_window={
		window:null,
		close:null,
		toolbar:null,
		scrollbar:null,
		playlist:null,
		framewindow:null,
		leftwindow:null,
		rightwindow:null,
		leftlist:null,
		rightlist:null,
		css:null
	};
	this.lyric_window={
		window:null,
		close:null,
		ontop:null,
		lyric:null,
		css:null
	};
	
//Constructor
	this._init = function(){
		_this = this;
		
		_this.divwindow = document.createElement("div");
		_this.divwindow.setAttribute("id",parent.id + "_window");
		_this.divwindow.setAttribute("name",parent.id + "_window");
		_this.divwindow.style.position = "absolute";
		_this.divwindow.style.top = "0px";
		_this.divwindow.style.left = "0px";
		_this.divwindow.style.width = "100%";
		_this.divwindow.style.height = "100%";
		//_this.divwindow.style.border = "1px solid;";
		document.body.appendChild(_this.divwindow);
		
		_this.setSkin(path);
		
		
		parent.addEventListener("onplay",function(){
			_this._statusInit();
		});
		parent.addEventListener("onplaying",function(){
			_this.player_window.progress.setValue( parseInt(parent.player.getCurrentPosition()*100 / parent.player.getDuration()) );
			_this.player_window.led.setValue( FXPlayer.getTime(parent.player.getCurrentPosition()) );
			if(parent.lyrics != null){
			    parent.lyrics.refreshTimer();
			}
		});
		parent.addEventListener("onstop",function(){
			_this.player_window.status.setText("状态: 停止");
			_this.refreshUI();
			_this.player_window.progress.setValue( 0 );
			_this.player_window.led.setValue( "0:0" );
		});
		parent.addEventListener("onpause",function(){
			_this.player_window.status.setText("状态: 暂停");
			_this.refreshUI();
		});
		parent.addEventListener("onbuffer",function(){
			_this.player_window.status.setText("正在缓冲...");
			_this.refreshUI();
		});
		parent.addEventListener("onend",function(){
			_this.player_window.status.setText("状态: 停止");
			_this.refreshUI();
		});
	};
//public operations
	this.setSkin = function( strPath ){
		if( strPath )
			_this.skinpath = strPath;
		else
			_this.skinpath = "skin/wmp10/";

		FXPlayer.loadXMLFile(_this.skinpath + "skin.xml",function(xmlDoc){

			root = xmlDoc.getElementsByTagName("skin")[0];
			if (root != null){
				_this.divwindow.innerHTML = "";
				_this.skinVersion = root.getAttribute("version");
				_this.skinName = root.getAttribute("name");
				_this.skinAuthor = root.getAttribute("author");
				_this.skinAuthorEmail = root.getAttribute("email");
				
				_this._createPlayWindow();
				//_this._createEqualizerWindow();
				//_this._createLyricWindow();
				//_this._createPlaylistWindow();
				_this.refreshUI();
				_this._statusInit();
			}
		});
	};
	//刷新静态控件
	this.refreshUI = function()
	{
		if (parent.player.status == 0 || parent.player.status == 1)
		{
			_this.player_window.btnPlay.show();
			_this.player_window.btnPause.hide();
		}
		else
		{
			_this.player_window.btnPlay.hide();
			_this.player_window.btnPause.show();
		}
		if (parent.player.getVolume() == 0)
			_this.player_window.stereo.setText("静音");
		else
			_this.player_window.stereo.setText("立体声");
	};

//private operation
	this._statusInit = function(){
		if (parent.player.getMediaName())
			_this.player_window.info.setText( "标题: " + parent.player.getMediaName() );
		else
			_this.player_window.info.setText( "正在获取媒体信息" );
		var percent = parent.player.getDownloadProgress();
		if (percent < 100)
		{
			_this.player_window.status.setText("已下载"+percent+"%");
			setTimeout(_this._statusInit,1000);
		}
		else
		{
			_this.player_window.status.setText("状态: 播放");
		}
	};

	this._createPlayWindow = function()
	{
		var player_window = root.getElementsByTagName("player_window")[0];
		strCommand = "_this.player_window.window = new UI.Window('player_window',_this.divwindow,0,0,null,null,'"+ _this.skinpath + player_window.getAttribute("image") +"');";
		eval (strCommand);
		var div_player_window = _this.player_window.window.getDiv();

		
		var player_window_play = player_window.getElementsByTagName("play")[0];
		strCommand = "_this.player_window.btnPlay = new UI.Button('play',div_player_window,"+player_window_play.getAttribute("position") + ",'" + _this.skinpath + player_window_play.getAttribute("image") + "',parent.player.play);";
		eval (strCommand);
		
		var player_window_pause = player_window.getElementsByTagName("pause")[0];
		strCommand = "_this.player_window.btnPause = new UI.Button('pause',div_player_window,"+player_window_pause.getAttribute("position") + ",'" + _this.skinpath + player_window_pause.getAttribute("image") + "',parent.player.pause);";
		eval (strCommand);
		
		var player_window_stop = player_window.getElementsByTagName("stop")[0];
		strCommand = "_this.player_window.btnStop = new UI.Button('stop',div_player_window,"+player_window_stop.getAttribute("position") + ",'" + _this.skinpath + player_window_stop.getAttribute("image") + "',parent.player.stop);";
		eval (strCommand);
		
		var player_window_prev = player_window.getElementsByTagName("prev")[0];
		strCommand = "_this.player_window.btnPrev = new UI.Button('prev',div_player_window,"+player_window_prev.getAttribute("position") + ",'" + _this.skinpath + player_window_prev.getAttribute("image") + "');";
		eval (strCommand);

		var player_window_next = player_window.getElementsByTagName("next")[0];
		strCommand = "_this.player_window.btnNext = new UI.Button('next',div_player_window,"+player_window_next.getAttribute("position") + ",'" + _this.skinpath + player_window_next.getAttribute("image") + "');";
		eval (strCommand);

		var player_window_mute = player_window.getElementsByTagName("mute")[0];
		if (player_window_mute)
		{
			strCommand = "_this.player_window.btnMute = new UI.Button('mute',div_player_window,"+player_window_mute.getAttribute("position") + ",'" + _this.skinpath + player_window_mute.getAttribute("image") + "',function(){parent.player.mute();_this.player_window.stereo.setText('静音');} , function(){parent.player.setVolume();_this.player_window.stereo.setText('立体声');});";
			eval (strCommand);
		}

		var player_window_open = player_window.getElementsByTagName("open")[0];
		strCommand = "_this.player_window.btnOpen = new UI.Button('open',div_player_window,"+player_window_open.getAttribute("position") + ",'" + _this.skinpath + player_window_open.getAttribute("image") + "');";
		eval (strCommand);
		var player_window_lyric = player_window.getElementsByTagName("lyric")[0];
		strCommand = "_this.player_window.btnLyrics = new UI.Button('lyric',div_player_window,"+player_window_lyric.getAttribute("position") + ",'" + _this.skinpath + player_window_lyric.getAttribute("image") + "',function(){},function(){});";
		eval (strCommand);

		var player_window_equalizer = player_window.getElementsByTagName("equalizer")[0];
		strCommand = "_this.player_window.btnEqualizer = new UI.Button('equalizer',div_player_window,"+player_window_equalizer.getAttribute("position") + ",'" + _this.skinpath + player_window_equalizer.getAttribute("image") + "',function(){},function(){});";
		eval (strCommand);

		var player_window_playlist = player_window.getElementsByTagName("playlist")[0];
		strCommand = "_this.player_window.btnPlaylist = new UI.Button('playlist',div_player_window,"+player_window_playlist.getAttribute("position") + ",'" + _this.skinpath + player_window_playlist.getAttribute("image") + "',function(){},function(){});";
		eval (strCommand);

		var player_window_minimize = player_window.getElementsByTagName("minimize")[0];
		strCommand = "_this.player_window.btnMinimize = new UI.Button('minimize',div_player_window,"+player_window_minimize.getAttribute("position") + ",'" + _this.skinpath + player_window_minimize.getAttribute("image") + "');";
		eval (strCommand);


		var player_window_minimode = player_window.getElementsByTagName("minimode")[0];
		strCommand = "_this.player_window.btnMinimode = new UI.Button('minimode',div_player_window,"+player_window_minimode.getAttribute("position") + ",'" + _this.skinpath + player_window_minimode.getAttribute("image") + "');";
		eval (strCommand);

		var player_window_exit = player_window.getElementsByTagName("exit")[0];
		strCommand = "_this.player_window.btnExit = new UI.Button('exit',div_player_window,"+player_window_exit.getAttribute("position") + ",'" + _this.skinpath + player_window_exit.getAttribute("image") + "');";
		eval (strCommand);
		
		var fnprogresschanged = function(value){
			parent.player.setCurrentPosition( value*parent.player.getDuration()/100 );
		}
		var fnvolumechanging = function(value){
			parent.player.setVolume(value);
			_this.player_window.status.setText("音量: " + value + "%");
		}
		var fnvolumechanged = function(value){
			parent.player.setVolume(value);
		}
		var startvalue = 0;
		if (_this.player_window.progress)
			startvalue = _this.player_window.progress.getValue();
		
		var player_window_volume = player_window.getElementsByTagName("volume")[0];
		strCommand = "_this.player_window.volume = new UI.ProgressBar('volume',div_player_window,"+player_window_volume.getAttribute("vertical")+","+player_window_volume.getAttribute("position") + ",'" + _this.skinpath + player_window_volume.getAttribute("thumb_image") + "','"+ _this.skinpath + player_window_volume.getAttribute("fill_image")+"',";
		strCommand += "fnvolumechanged,null,"+parent.player.getVolume()+");";
		eval (strCommand);
		
		var player_window_progress = player_window.getElementsByTagName("progress")[0];
		strCommand = "_this.player_window.progress = new UI.ProgressBar('progress',div_player_window,"+player_window_progress.getAttribute("vertical")+","+player_window_progress.getAttribute("position") + ",'" + _this.skinpath + player_window_progress.getAttribute("thumb_image") + "','"+ _this.skinpath + player_window_progress.getAttribute("fill_image")+"',";
		strCommand += "fnprogresschanged,null,startvalue);";
		eval (strCommand);
		
		
		var player_window_visual = player_window.getElementsByTagName("visual")[0];
		strCommand = "_this.player_window.visual = new UI.Label('visual',div_player_window,"+player_window_visual.getAttribute("position") + ",null,null,null,null,null);";
		eval (strCommand);

		var player_window_icon = player_window.getElementsByTagName("icon")[0];
		var icon = player_window_icon.getAttribute("icon");
		if (!icon)
			icon = "icon.ico";
		strCommand = "_this.player_window.icon = new UI.Image('icon',div_player_window,"+player_window_icon.getAttribute("position") + ",'" + _this.skinpath + icon + "',null);";
		eval (strCommand);

		var player_window_info = player_window.getElementsByTagName("info")[0];
		strCommand = "_this.player_window.info = new UI.Label('info',div_player_window,"+ player_window_info.getAttribute("position") +",'"+player_window_info.getAttribute("bkgnd")+"','"+player_window_info.getAttribute("color")+"','"+player_window_info.getAttribute("font")+"',"+player_window_info.getAttribute("font_size")+",'"+player_window_info.getAttribute("align")+"');";
		eval (strCommand);

		var player_window_stereo = player_window.getElementsByTagName("stereo")[0];
		if (player_window_stereo)
		{
			strCommand = "_this.player_window.stereo = new UI.Label('stereo',div_player_window,"+ player_window_stereo.getAttribute("position") +",'"+player_window_stereo.getAttribute("bkgnd")+"','"+player_window_stereo.getAttribute("color")+"','"+player_window_stereo.getAttribute("font")+"',"+player_window_stereo.getAttribute("font_size")+",'"+player_window_stereo.getAttribute("align")+"');";
			eval (strCommand);
		}

		var player_window_status = player_window.getElementsByTagName("status")[0];
		strCommand = "_this.player_window.status = new UI.Label('status',div_player_window,"+ player_window_status.getAttribute("position") +",'"+player_window_status.getAttribute("bkgnd")+"','"+player_window_status.getAttribute("color")+"','"+player_window_status.getAttribute("font")+"',"+player_window_status.getAttribute("font_size")+",'"+player_window_status.getAttribute("align")+"');";
		eval (strCommand);

		var player_window_led = player_window.getElementsByTagName("led")[0];
		strCommand = "_this.player_window.led = new UI.Led('led',div_player_window,"+ player_window_led.getAttribute("position") +",'"+ _this.skinpath + player_window_led.getAttribute("image")+"','"+player_window_led.getAttribute("align")+"');";
		eval (strCommand);
		
	};
	this._createEqualizerWindow = function()
	{
		var equalizer_window = root.getElementsByTagName("equalizer_window")[0];
		strCommand = "_this.equalizer_window.window = new UI.Window('equalizer_window',_this.divwindow,"+equalizer_window.getAttribute("position")+",'"+ _this.skinpath + equalizer_window.getAttribute("image") +"');";
		eval (strCommand);
		var div_equalizer_window = _this.equalizer_window.window.getDiv();
		
		var equalizer_window_close = equalizer_window.getElementsByTagName("close")[0];
		strCommand = "_this.equalizer_window.close = new UI.Button('close',div_equalizer_window,"+equalizer_window_close.getAttribute("position") + ",'" + _this.skinpath + equalizer_window_close.getAttribute("image") + "',function(){});";
		eval (strCommand);
		var equalizer_window_enabled = equalizer_window.getElementsByTagName("enabled")[0];
		strCommand = "_this.equalizer_window.enabled = new UI.Button('enabled',div_equalizer_window,"+equalizer_window_enabled.getAttribute("position") + ",'" + _this.skinpath + equalizer_window_enabled.getAttribute("image") + "',function(){},function(){});";
		eval (strCommand);
		var equalizer_window_profile = equalizer_window.getElementsByTagName("profile")[0];
		strCommand = "_this.equalizer_window.profile = new UI.Button('profile',div_equalizer_window,"+equalizer_window_profile.getAttribute("position") + ",'" + _this.skinpath + equalizer_window_profile.getAttribute("image") + "',function(){});";
		eval (strCommand);
		var equalizer_window_reset = equalizer_window.getElementsByTagName("reset")[0];
		strCommand = "_this.equalizer_window.profile = new UI.Button('reset',div_equalizer_window,"+equalizer_window_reset.getAttribute("position") + ",'" + _this.skinpath + equalizer_window_reset.getAttribute("image") + "',function(){});";
		eval (strCommand);

		var equalizer_window_balance = equalizer_window.getElementsByTagName("balance")[0];
		strCommand = "_this.equalizer_window.balance = new UI.ProgressBar('balance',div_equalizer_window,"+equalizer_window_balance.getAttribute("vertical")+","+equalizer_window_balance.getAttribute("position") + ",'" + _this.skinpath + equalizer_window_balance.getAttribute("thumb_image") + "','"+ _this.skinpath + equalizer_window_balance.getAttribute("fill_image")+"',";
		strCommand += "null,null,50);";
		eval (strCommand);
		var equalizer_window_surround = equalizer_window.getElementsByTagName("surround")[0];
		strCommand = "_this.equalizer_window.surround = new UI.ProgressBar('surround',div_equalizer_window,"+equalizer_window_surround.getAttribute("vertical")+","+equalizer_window_surround.getAttribute("position") + ",'" + _this.skinpath + equalizer_window_surround.getAttribute("thumb_image") + "','"+ _this.skinpath + equalizer_window_surround.getAttribute("fill_image")+"',";
		strCommand += "null,null,0);";
		eval (strCommand);
		var equalizer_window_preamp = equalizer_window.getElementsByTagName("preamp")[0];
		strCommand = "_this.equalizer_window.preamp = new UI.ProgressBar('preamp',div_equalizer_window,true,"+equalizer_window_preamp.getAttribute("position") + ",'" + _this.skinpath + equalizer_window_preamp.getAttribute("thumb_image") + "','"+ _this.skinpath + equalizer_window_preamp.getAttribute("fill_image")+"',";
		strCommand += "null,null,50);";
		eval (strCommand);
		
		var i=0;
		_this.equalizer_window.eqfactor = [];
		var equalizer_window_eqfactor = equalizer_window.getElementsByTagName("eqfactor")[0];
		var interval = parseInt(equalizer_window.getAttribute("eq_interval"));
		if (!interval)
			interval = 0;

		var pos = equalizer_window_eqfactor.getAttribute("position").split(",");
		var left = parseInt(pos[0]);
		var top = parseInt(pos[1]);
		var right = parseInt(pos[2]);
		var bottom = parseInt(pos[3]);
		var width = right-left;
		for (i=0;i<10;i++)
		{
			//alert (left + width + interval);
			strCommand = "_this.equalizer_window.eqfactor.push( new UI.ProgressBar('eqfactor',div_equalizer_window,true,"+left+","+top+","+right+","+bottom+ ",'" + _this.skinpath + equalizer_window_eqfactor.getAttribute("thumb_image") + "','"+ _this.skinpath + equalizer_window_eqfactor.getAttribute("fill_image")+"',";
			strCommand += "null,null,50) );";
			eval (strCommand);
			left = (left + width + interval);
			right = (right + width + interval);
		}
	};
	this._createLyricWindow = function()
	{
		var lyric_window = root.getElementsByTagName("lyric_window")[0];
		strCommand = "_this.lyric_window.window = new UI.ResizableWindow('lyric_window',_this.divwindow,"+lyric_window.getAttribute("position")+","+lyric_window.getAttribute("resize_rect")+",'"+ _this.skinpath + lyric_window.getAttribute("image") +"',1000,1000,_this._createLyricWindowContent,_this._lyricWindowResizing);";
		eval (strCommand);
		var div_lyric_window = _this.lyric_window.window.getDiv();

/*
		var lyric_window_close = lyric_window.getElementsByTagName("close")[0];
		strCommand = "_this.lyric_window.close = new UI.Button('close',div_lyric_window,"+lyric_window_close.getAttribute("position") + ",'" + _this.skinpath + lyric_window_close.getAttribute("image") + "',function(){},null,1);";
		eval (strCommand);

		var lyric_window_ontop = lyric_window.getElementsByTagName("ontop")[0];
		strCommand = "_this.lyric_window.ontop = new UI.Button('ontop',div_lyric_window,"+lyric_window_ontop.getAttribute("position") + ",'" + _this.skinpath + lyric_window_ontop.getAttribute("image") + "',function(){},function(){},1);";
		eval (strCommand);
*/
	};
	this._createLyricWindowContent = function(wnd)
	{
		var position = root.getElementsByTagName("lyric_window")[0].getElementsByTagName("lyric")[0].getAttribute("position");
		var arrTemp = position.split(",");
		var left = arrTemp[0];
		var top = arrTemp[1];
		var right = arrTemp[2];
		var bottom = arrTemp[3];

		var size = wnd.getSize();
		var minwidth = size.minw;
		var minheight = size.minh;
		var width = size.w;
		var height = size.h;
		
		var div_lyric_window = wnd.getDiv();
		
		_this.lyric_window.lyric = document.createElement("div");
		_this.lyric_window.lyric.setAttribute("id","lyrics");
		_this.lyric_window.lyric.style.position = "absolute";
		_this.lyric_window.lyric.style.left = left+"px";
		_this.lyric_window.lyric.style.top = top+"px";
		_this.lyric_window.lyric.style.width = (right-left+width-minwidth)+"px";
		_this.lyric_window.lyric.style.height = (bottom-top+height-minheight)+"px";
		//_this.lyric_window.lyric.style.border = "1px solid";
		_this.lyric_window.lyric.style.overflow = "hidden";
		_this.lyric_window.lyric.style.textAlign = "center";
		_this.lyric_window.lyric.style.zIndex = "5";
		div_lyric_window.appendChild(_this.lyric_window.lyric);
		
		_this._createLyricStyle();
		
		parent.lyrics.setDiv(_this.lyric_window.lyric);
	};
	this._createLyricStyle = function()
	{
		FXPlayer.loadXMLFile(_this.skinpath + "lyric.xml",function(xmlDoc){
			var rootlyric = xmlDoc.getElementsByTagName("Lyric")[0];
			
			if (rootlyric != null){
				var font = rootlyric.getAttribute("Font");
				var color = rootlyric.getAttribute("TextColor");
				var hilightcolor = rootlyric.getAttribute("HilightColor");
				var bgcolor = rootlyric.getAttribute("BkgndColor");
				
				if (font)
				{
					var arrTemp = font.split(",");
					var fontfamily = arrTemp[13];
					var fontweight = arrTemp[4];
					var fontsize = (-arrTemp[0]);
				}
				else
				{
					var fontfamily = "Tahoma";
					var fontweight = "400";
					var fontsize = "11";
				}

				if (FXPlayer.browserDetect() == "ie")
				{
					if (!_this.lyric_window.css)
						_this.lyric_window.css = window.document.createStyleSheet();
					_this.lyric_window.css.addRule(".fxlyrics_normal","font-family:"+fontfamily+";font-size:"+fontsize+"px;font-weight:"+fontweight+";color:"+color+";");
					_this.lyric_window.css.addRule(".fxlyrics_playing","font-family:"+fontfamily+";font-size:"+fontsize+"px;font-weight:"+fontweight+";color:"+hilightcolor+";");
				}
				else
				{
					if (_this.lyric_window.css)
						document.getElementsByTagName("head")[0].removeChild(_this.lyric_window.css);
					_this.lyric_window.css = document.createElement("style");
					_this.lyric_window.css.setAttribute("id","lyricStyle");
					_this.lyric_window.css.setAttribute("type","text/css");
					var text = document.createTextNode("<!--.fxlyrics_normal{font-family:"+fontfamily+";font-size:"+fontsize+"px;font-weight:"+fontweight+";color:"+color+";}.fxlyrics_playing{font-family:"+fontfamily+";font-size:"+fontsize+"px;font-weight:"+fontweight+";color:"+hilightcolor+";}-->");
					_this.lyric_window.css.appendChild(text);
					document.getElementsByTagName("head")[0].appendChild(_this.lyric_window.css);
				}
			}
		});
	};
	
	this._lyricWindowResizing = function(wnd)
	{
		var position = root.getElementsByTagName("lyric_window")[0].getElementsByTagName("lyric")[0].getAttribute("position");
		var arrTemp = position.split(",");
		var left = arrTemp[0];
		var top = arrTemp[1];
		var right = arrTemp[2];
		var bottom = arrTemp[3];
		var size = wnd.getSize();
		var minwidth = size.minw;
		var minheight = size.minh;
		var width = size.w;
		var height = size.h;
		_this.lyric_window.lyric.style.width = (right-left+width-minwidth)+"px";
		_this.lyric_window.lyric.style.height = (bottom-top+height-minheight)+"px";
		
		parent.lyrics.resize(_this.lyric_window.lyric);
	};
	
	this._createPlaylistWindow = function()
	{
		var playlist_window = root.getElementsByTagName("playlist_window")[0];
		strCommand = "_this.playlist_window.window = new UI.ResizableWindow('playlist_window',_this.divwindow,"+playlist_window.getAttribute("position")+","+playlist_window.getAttribute("resize_rect")+",'"+ _this.skinpath + playlist_window.getAttribute("image") +"',1000,1000,_this._createPlaylistWindowContent,_this._playlistWindowResizing);";
		eval (strCommand);
	};
	this._createPlaylistWindowContent = function(wnd)
	{
		var position = root.getElementsByTagName("playlist_window")[0].getElementsByTagName("playlist")[0].getAttribute("position");
		var arrTemp = position.split(",");
		var left = arrTemp[0];
		var top = arrTemp[1];
		var right = arrTemp[2];
		var bottom = arrTemp[3];

		var size = wnd.getSize();
		var minwidth = size.minw;
		var minheight = size.minh;
		var width = size.w;
		var height = size.h;
		
		var div_playlist_window = wnd.getDiv();
		
		_this.playlist_window.playlist = document.createElement("div");
		_this.playlist_window.playlist.setAttribute("id","playlist");
		_this.playlist_window.playlist.style.position = "absolute";
		_this.playlist_window.playlist.style.left = left+"px";
		_this.playlist_window.playlist.style.top = top+"px";
		_this.playlist_window.playlist.style.width = (right-left+width-minwidth)+"px";
		_this.playlist_window.playlist.style.height = (bottom-top+height-minheight)+"px";
		//_this.playlist_window.playlist.style.border = "1px solid";
		_this.playlist_window.playlist.style.overflow = "hidden";
		_this.playlist_window.playlist.style.textAlign = "center";
		_this.playlist_window.playlist.style.zIndex = "5";
		div_playlist_window.appendChild(_this.playlist_window.playlist);
		
		_this.playlist_window.framewindow = new UI.FrameWindow("playlist",_this.playlist_window.playlist);
		_this.playlist_window.leftwindow=_this.playlist_window.framewindow.getLeftDiv();
		_this.playlist_window.rightwindow=_this.playlist_window.framewindow.getRightDiv();
		
		
		_this._createPlaylistStyle();

		
	};
	this._createPlaylistStyle = function()
	{
		FXPlayer.loadXMLFile(_this.skinpath + "playlist.xml",function(xmlDoc){
			
			var rootPlaylist = xmlDoc.getElementsByTagName("PlayList")[0];
			if (rootPlaylist != null){
				var font = rootPlaylist.getAttribute("Font");
				var color = rootPlaylist.getAttribute("Color_Text");
				var hilightcolor = rootPlaylist.getAttribute("Color_Hilight");
				var bgcolor1 = rootPlaylist.getAttribute("Color_Bkgnd");
				var bgcolor2 = rootPlaylist.getAttribute("Color_Bkgnd2");
				var numbercolor = rootPlaylist.getAttribute("Color_Number");
				var durationcolor = rootPlaylist.getAttribute("Color_Duration");

				var fontfamily;
				var fontweight;
				var fontsize;
				

				
				if (font)
				{
					arrTemp = font.split(",");
					fontfamily = arrTemp[13];
					fontweight = arrTemp[4];
					fontsize = (-arrTemp[0]);
				}
				else
				{
					fontfamily = "Tahoma";
					fontweight = "400";
					fontsize = "11";
				}
				
				if (FXPlayer.browserDetect() == "ie")
				{
					if (!_this.playlist_window.css)
						_this.playlist_window.css = window.document.createStyleSheet();

					_this.playlist_window.css.addRule(".fxplaylistitem","font-family:"+fontfamily+";font-size:"+fontsize+"px;font-weight:"+fontweight+";color:"+color+";text-align:left;cursor:pointer;");
					_this.playlist_window.css.addRule(".fxplaylistitem1","background-color:"+bgcolor1+";");
					_this.playlist_window.css.addRule(".fxplaylistitem2","background-color:"+bgcolor2+";");
					_this.playlist_window.css.addRule(".fxplaylistitemmousemove","color:"+hilightcolor+";");
					_this.playlist_window.css.addRule(".fxplaylistitemselected","color:"+hilightcolor+";");
				}
				else
				{
					if (_this.playlist_window.css)
						document.getElementsByTagName("head")[0].removeChild(_this.playlist_window.css);
					_this.playlist_window.css = document.createElement("style");
					_this.playlist_window.css.setAttribute("id","playlistStyle");
					_this.playlist_window.css.setAttribute("type","text/css");
					var text = document.createTextNode("<!--.fxplaylistitem{font-family:"+fontfamily+";font-size:"+fontsize+"px;font-weight:"+fontweight+";color:"+color+";text-align:left;cursor:pointer;}.fxplaylistitem1{background-color:"+bgcolor1+";}.fxplaylistitem2{background-color:"+bgcolor2+";}.fxplaylistitemmousemove{color:"+hilightcolor+";}.fxplaylistitemselected{color:"+hilightcolor+";}");
					_this.playlist_window.css.appendChild(text);
					document.getElementsByTagName("head")[0].appendChild(_this.playlist_window.css);
				}
				_this.playlist_window.framewindow.setDurationColor(durationcolor);
				new UI.List( "playlistleft",_this.playlist_window.leftwindow,["张含韵","张震岳","周杰伦"],null,null);
				new UI.List( "playlistright",_this.playlist_window.rightwindow,["song1","song2","song3"],numbercolor,null);
			}
		});
	};

	this._playlistWindowResizing = function(wnd)
	{
		var position = root.getElementsByTagName("playlist_window")[0].getElementsByTagName("playlist")[0].getAttribute("position");
		var arrTemp = position.split(",");
		var left = arrTemp[0];
		var top = arrTemp[1];
		var right = arrTemp[2];
		var bottom = arrTemp[3];
		var size = wnd.getSize();
		var minwidth = size.minw;
		var minheight = size.minh;
		var width = size.w;
		var height = size.h;
		_this.playlist_window.playlist.style.width = (right-left+width-minwidth)+"px";
		_this.playlist_window.playlist.style.height = (bottom-top+height-minheight)+"px";
		
		_this.playlist_window.framewindow.resize((right-left+width-minwidth),(bottom-top+height-minheight));
	};
	//call Constructor
	this._init();
}


//public static class


UI.getTop=function(e){
	//获取元素的纵坐标
	var offset=e.offsetTop;
	if(e.offsetParent!=null) 
		offset+=UI.getTop(e.offsetParent);
	return offset;
};
UI.getLeft=function(e){
	//获取元素的横坐标
	var offset=e.offsetLeft;
	if(e.offsetParent!=null) 
		offset+=UI.getLeft(e.offsetParent);
	return offset;
};
UI.getImageSize = function(src,fncallback){
	var img = new Image;
	var width = 0;
	var height = 0;
	img.onload = function(){
		fncallback({width:img.width,height:img.height});
	};
	img.onerror = function(){
		
		fncallback();
	};
	img.src = src;
};

UI.Button = function(id,divwindow,left,top,right,bottom,backgroundimage,fnclick1,fnclick2,zindex)
{
	var _this = null;
	var status = 0;	//0-普通按钮，按下以后自动弹起；1-按下以后保持凹下去的状态；2-本来是凹下去的，现在弹起来，
	var btn = null;
	var width = (right-left);
	var height = (bottom-top);
//Constructor
	this._init = function(){
		_this = this;
		
		if (fnclick2)//设置按钮的状态，如果有按起来的响应函数，则为2态按钮，否则就保持普通状态
			status = 1;

		btn = document.createElement("div");
		btn.setAttribute("id",id);
		btn.setAttribute("name",id);
		btn.style.position = "absolute";
		btn.style.top = top+"px";
		btn.style.left = left+"px";
		btn.style.width = width+"px";
		btn.style.height = height+"px";
		btn.style.backgroundImage = "url("+backgroundimage+")";
		if (zindex)
			btn.style.zIndex = zindex;
		btn.style.backgroundPosition = "0px 0px";

		btn.style.cursor = "pointer";
		UI.addEventListener(btn,"mouseover",function(){
			if (status == 2)
				btn.style.backgroundPosition = (0-width)*2+"px 0px";
			else
				btn.style.backgroundPosition = (0-width)+"px 0px";
		});

		UI.addEventListener(btn,"mouseout",function(){
			if (status == 2)
				btn.style.backgroundPosition = (0-width)*2+"px 0px";
			else
				btn.style.backgroundPosition = "0px 0px";
		});

		UI.addEventListener(btn,"mousedown",function(e){
			if(status ==1)
				status = 2;
			else if (status == 2)
				status = 1;
			btn.style.backgroundPosition = (0-width)*2+"px 0px";
			if (e && e.stopPropagation) //停止事件冒泡
				e.stopPropagation();
			else
				window.event.cancelBubble = true;
		});
		UI.addEventListener(btn,"mouseup",function(){
			if (status == 2)
				btn.style.backgroundPosition = (0-width)*2+"px 0px";
			else
				btn.style.backgroundPosition = "0px 0px";
		});

		if (fnclick1)
		{	
			UI.addEventListener(btn,"click",function(){
				if (status == 1)
					fnclick2();
				else
					fnclick1();
			});
		}

		divwindow.appendChild(btn);
		
		UI.getImageSize(backgroundimage,function(size){
			if (size)
			{
				size.width /=4;
				width = size.width;
				height = size.height;
				btn.style.width = width+"px";
				btn.style.height = height+"px";
			}
		});

	};
	this.hide=function()
	{
		btn.style.display = "none";
	};
	this.show=function()
	{
		btn.style.display = "";
	};
	//call Constructor
	this._init();
};


UI.ProgressBar = function(id,divwindow,vertical,left,top,right,bottom,thumb_image,fill_image,fnonchanged,fnonchanging,startvalue)
{
	var _this = null;
	var divprogresswindow = null;
	var divprogressfill = null;
	var divprogressthumbposition = null;
	var divprogressthumb = null;
	var thumb_image_size = null;
	var pvalue = 0;
	var setting = false;
//Constructor
	this._init = function(){
		_this = this;
		
		if (!startvalue || startvalue <0 || startvalue >100)
			startvalue=0;
		if (!vertical || vertical!=true)
			vertical = false;
		pvalue = startvalue;

		divprogresswindow = document.createElement("div");
		divprogresswindow.setAttribute("id",id+"_progress_window");
		divprogresswindow.setAttribute("name",id+"_progress_window");
		divprogresswindow.style.position = "absolute";
		divprogresswindow.style.left = left + "px";
		divprogresswindow.style.top = top + "px";
		divprogresswindow.style.width = (right-left) + "px";
		divprogresswindow.style.height = (bottom-top) + "px";




		divprogressfill = document.createElement("div");
		divprogressfill.setAttribute("id",id+"_progress_fill");
		divprogressfill.setAttribute("name",id+"_progress_fill");
		divprogressfill.style.position = "absolute";
		divprogressfill.style.left = "0px";
		if (vertical == false)
		{
			divprogressfill.style.top = "0%";
			divprogressfill.style.bottom = "";
			divprogressfill.style.width = pvalue + "%";
			divprogressfill.style.height = "100%";
		}
		else
		{
			divprogressfill.style.top = "";
			divprogressfill.style.bottom = "0%";
			divprogressfill.style.width = "100%";
			divprogressfill.style.height = pvalue + "%";
		}
		divprogressfill.style.backgroundImage = "url("+fill_image+")";
		divprogressfill.style.backgroundRepeat = "no-repeat";
		divprogresswindow.appendChild(divprogressfill);
		
		
		divprogressthumbposition = document.createElement("div");
		divprogressthumbposition.setAttribute("id",id+"_progress_thumb_position");
		divprogressthumbposition.setAttribute("name",id+"_progress_thumb_position");
		divprogressthumbposition.style.position = "absolute";
		divprogressthumbposition.style.left = "0px";
		divprogressthumbposition.style.top = "0px";

		divprogressthumbposition.style.width = (right-left)+"px";
		divprogressthumbposition.style.height = (bottom-top) + "px";
		divprogressthumbposition.style.cursor = "pointer";
		divprogresswindow.appendChild(divprogressthumbposition);
		

		divprogressthumb = document.createElement("div");
		divprogressthumb.setAttribute("id",id+"_progress_thumb");
		divprogressthumb.setAttribute("name",id+"_progress_thumb");
		divprogressthumb.style.position = "absolute";
		if (vertical == false)
		{
			divprogressthumb.style.left = pvalue + "%";
			divprogressthumb.style.top = "0%";
		}
		else
		{
			divprogressthumb.style.left = "0%";
			divprogressthumb.style.top = pvalue + "%";
		}
		
		divprogressthumb.style.width = "0px";
		divprogressthumb.style.height = "0px";
		divprogressthumb.style.backgroundImage = "url("+thumb_image+")";
		divprogressthumb.style.backgroundRepeat = "no-repeat";
		divprogressthumb.style.cursor = "pointer";
		divprogressthumb.style.backgroundPosition = "0px 0px";
		
		divprogressthumbposition.appendChild(divprogressthumb);

		divwindow.appendChild(divprogresswindow);

		UI.addEventListener(document,"mouseup",function(){
			UI.removeEventListener(document,'mousemove', handle);
			if (setting==true && fnonchanged)
			{
				setting = false;
				fnonchanged(pvalue);
			}
		});
		UI.addEventListener(divprogresswindow,"mousedown",function(e){
			setting = true;
			handle(e);
			if (e && e.stopPropagation) //停止事件冒泡
				e.stopPropagation();
			else
				window.event.cancelBubble = true;
		});

		UI.getImageSize(thumb_image,function(size){
			if (size)
			{
				thumb_image_size = size;
				thumb_image_size.width /=4;
				if (thumb_image_size)
				{
					//if (fill_image == "skin/orange/eqfactor_full.gif")
					//	alert ("debug:"+(right-left-thumb_image_size.width));
					
					if (vertical == false)
					{
						divprogressthumbposition.style.width = (right-left-thumb_image_size.width)+"px";
						divprogressthumbposition.style.height = thumb_image_size.height + "px";
					}
					else
					{
						divprogressthumbposition.style.width = thumb_image_size.width+"px";
						divprogressthumbposition.style.height = (bottom-top-thumb_image_size.height) + "px";
					}
					divprogressthumb.style.width = thumb_image_size.width + "px";
					divprogressthumb.style.height = thumb_image_size.height + "px";


					divprogressthumb.onmouseover = function(){
						divprogressthumb.style.backgroundPosition = (0-thumb_image_size.width) + "px 0px";
					};
					divprogressthumb.onmousedown = function(e){
						setting = true;
						divprogressthumb.style.backgroundPosition = ((0-thumb_image_size.width)*2)+"px 0px";
						UI.addEventListener(document,"mousemove",handle);
						//alert (e.stopPropagation);
						if (e && e.stopPropagation) //停止事件冒泡
							e.stopPropagation();
						else
							window.event.cancelBubble = true;
					};
					divprogressthumb.onmouseout = function(){
						divprogressthumb.style.backgroundPosition = "0px 0px";
					};
					divprogressthumb.onmouseup = function(){
						divprogressthumb.style.backgroundPosition = "0px 0px";
					};
					
				}
			}
		});
		UI.getImageSize(fill_image,function(size){
			if (size)
			{
				//fill_image是居中的，所以要计算位置，将背景调整过去
				if (vertical == true)
				{
					if (size.width<(right-left))
					{
						divprogressfill.style.backgroundPosition = (parseInt((right-left)-size.width)/2)+"px 0px";
					}
				}
				else
				{
					if (size.height<(bottom-top))
					{
						divprogressfill.style.backgroundPosition = "0px "+(parseInt((bottom-top)-size.height)/2)+"px";
					}
				}
			}
		});
	};
	

	var handle = function(e){
		var evt;
		
		if(!e)
			e=window.event;
			
		var _clientX = e.clientX + document.documentElement.scrollLeft;
		var _clientY = e.clientY + document.documentElement.scrollTop;
		if (vertical == false)
		{
			var leftmin = UI.getLeft(divprogressthumbposition);
			var leftmax = leftmin + divprogressthumbposition.offsetWidth;
			var percent = 0;
			if (_clientX<leftmin)
				percent = 0;
			else if (_clientX > leftmax)
				percent = 100;
			else{
				percent = parseInt((_clientX-leftmin)/(leftmax-leftmin) * 100);
			}
		}
		else
		{
			var topmin = UI.getTop(divprogressthumbposition);
			var topmax = topmin + divprogressthumbposition.offsetHeight;
			var percent = 0;
			if (_clientY<topmin)
				percent = 100;
			else if (_clientY > topmax)
				percent = 0;
			else{
				percent = parseInt((topmax-_clientY)/(topmax-topmin) * 100);
			}
		}
		
		_this.setValue(percent,true);
	};

	this.setValue = function( newValue , inside){
		//inside被赋了值就表示这个setValue是在类内部调用的，也就是用户通过鼠标操作进行复制，这时，外部的赋值将不起作用
		if (setting && !inside)
			return;
		if (!isNaN(newValue) && newValue >=0 && newValue <=100)
		{
			pvalue = newValue;
			if (vertical == false)
			{
				if (divprogressfill)
					divprogressfill.style.width = pvalue + "%";
				if (divprogressthumb)
					divprogressthumb.style.left = pvalue + "%";
			}
			else
			{
				if (divprogressfill)
					divprogressfill.style.height = pvalue + "%";
				if (divprogressthumb)
					divprogressthumb.style.top = (100-pvalue) + "%";
			}
			if (fnonchanging)
				fnonchanging(pvalue);
		}

	};
	this.getValue = function(){
		return pvalue;
	};

	//call Constructor
	this._init();
};

UI.Label = function( id,divwindow,left,top,right,bottom,backgroundcolor,color,font,fontsize,align )
{
	var _this = null;
	var lbl = null;
//Constructor
	this._init = function(){
		_this = this;
		

		lbl = document.createElement("div");
		lbl.setAttribute("id","lbl_"+id);
		lbl.setAttribute("name","lbl_"+id);
		lbl.style.position = "absolute";
		lbl.style.top = top+"px";
		lbl.style.left = left+"px";
		lbl.style.width = (right-left)+"px";
		lbl.style.height = (bottom-top)+"px";
		
		if (backgroundcolor && backgroundcolor != "null")
			lbl.style.backgroundColor = backgroundcolor;
		if (color && color != "null")
		{
			lbl.style.color = color;
		}
		
		if (font && font!="null")
			lbl.style.fontFamily = font;
		if (fontsize)
			lbl.style.fontSize = (fontsize-1) + "px";

		if (align && align!= "null")
		{
			if (align != "left" && align != "right")
				align = "left";
		}
		else
			align = "left";
		lbl.style.textAlign = align;

		divwindow.appendChild(lbl);
	};
	this.setText = function(str)
	{
		lbl.innerHTML = str;
	};
	//call Constructor
	this._init();
};
UI.Image = function( id,divwindow,left,top,right,bottom,backgroundimage,backgroundpos )
{
	var _this = null;
	var img = null;
//Constructor
	this._init = function(){
		_this = this;
		

		img = document.createElement("div");
		img.setAttribute("id","img_"+id);
		img.setAttribute("name","img_"+id);
		img.style.position = "absolute";
		img.style.top = top+"px";
		img.style.left = left+"px";
		img.style.width = (right-left)+"px";
		img.style.height = (bottom-top)+"px";
		
		if (backgroundimage && backgroundimage != "null")
		{
			img.style.backgroundImage = "url("+backgroundimage+")";

			if (backgroundpos && backgroundpos != "null")
				img.style.backgroundPosition = backgroundpos;
			else
				img.style.backgroundPosition = "0px 0px";
		}
		divwindow.appendChild(img);
	};
	this.setBackgroundPosition = function(bkpos)
	{
		img.style.backgroundPosition = bkpos;
	};
	//call Constructor
	this._init();
};

UI.Led = function( id,divwindow,left,top,right,bottom,backgroundimage,align )
{
	var _this = null;
	var led = null;
	var imgsize = null;
	var imagesrc = null;
	var led1 = null;
	var led2 = null;
	var ledsplit = null;
	var led3 = null;
	var led4 = null;
//Constructor
	this._init = function(){
		_this = this;

		led = document.createElement("div");
		led.setAttribute("id","led_"+id);
		led.setAttribute("name","led_"+id);
		led.style.position = "absolute";
		led.style.top = top+"px";
		led.style.left = left+"px";
		led.style.width = (right-left)+"px";
		led.style.height = (bottom-top)+"px";
		
		//led.style.border = "1px #FFFFFF solid";

		
		UI.getImageSize(backgroundimage,function(size){
			if (size)
			{
				//0123456789:-
				imgsize = size;
				imgsize.width = parseInt(imgsize.width/12);
				imagesrc = backgroundimage;

				if (align && align!= "null")
				{
					if (align != "left" && align != "right")
						align = "left";
				}
				else
					align = "left";
				if (align == "left")
				{
					led1=new UI.Image( "led1",led,imgsize.width*0,0,imgsize.width*1,imgsize.height,backgroundimage,null );
					led2=new UI.Image( "led2",led,imgsize.width*1,0,imgsize.width*2,imgsize.height,backgroundimage,null );
					ledsplit=new UI.Image( "ledsplit",led,imgsize.width*2,0,imgsize.width*3,imgsize.height,backgroundimage,(0-imgsize.width*10)+"px 0px" );
					led3=new UI.Image( "led3",led,imgsize.width*3,0,imgsize.width*4,imgsize.height,backgroundimage,null );
					led4=new UI.Image( "led4",led,imgsize.width*4,0,imgsize.width*5,imgsize.height,backgroundimage,null );
				}
				else
				{
					led1=new UI.Image( "led1",led,(right-left-imgsize.width*5)+imgsize.width*0,0,(right-left-imgsize.width*5)+imgsize.width*1,imgsize.height,backgroundimage,null );
					led2=new UI.Image( "led2",led,(right-left-imgsize.width*5)+imgsize.width*1,0,(right-left-imgsize.width*5)+imgsize.width*2,imgsize.height,backgroundimage,null );
					ledsplit=new UI.Image( "ledsplit",led,(right-left-imgsize.width*5)+imgsize.width*2,0,(right-left-imgsize.width*5)+imgsize.width*3,imgsize.height,backgroundimage,(0-imgsize.width*10)+"px 0px" );
					led3=new UI.Image( "led3",led,(right-left-imgsize.width*5)+imgsize.width*3,0,(right-left-imgsize.width*5)+imgsize.width*4,imgsize.height,backgroundimage,null );
					led4=new UI.Image( "led4",led,(right-left-imgsize.width*5)+imgsize.width*4,0,(right-left-imgsize.width*5)+imgsize.width*5,imgsize.height,backgroundimage,null );
				}

			}
		});

		divwindow.appendChild(led);
	};
	this.setValue = function(strTime){
		if (led1 && led2 && led3 && led4)
		{
			if (strTime)
			{
				var arr = strTime.split(":");
				if (arr.length >1)
				{
					var minute = arr[arr.length-2];
					var second = arr[arr.length-1];
					
					led4.setBackgroundPosition ( (0-(second%10)*imgsize.width) + "px 0px" );
					led3.setBackgroundPosition ( (0-parseInt(second/10)%10)*imgsize.width + "px 0px" );
					led2.setBackgroundPosition ( (0-(minute%10)*imgsize.width) + "px 0px" );
					led1.setBackgroundPosition ( (0-parseInt(minute/10)%10)*imgsize.width + "px 0px" );
				}
			}
		}
	};
	//call Constructor
	this._init();
};


UI.Window = function( id,divwindow,left,top,right,bottom,backgroundimage )
{
	var _this = null;
	var div_new_window = null;
	var oldClientX;
	var oldClientY;
	var setting = false;
	var div_new_window_clone = null;
//Constructor
	this._init = function(){
		_this = this;

		div_new_window = document.createElement("div");
		div_new_window.setAttribute("id",id);
		div_new_window.setAttribute("name",id);
		div_new_window.style.position = "absolute";
		div_new_window.style.top = top + "px";
		div_new_window.style.left = left + "px";
		div_new_window.style.width = "100%";
		div_new_window.style.height = "100%";
		
		
		if (right && bottom)
		{
			div_new_window.style.width = (right-left) + "px";
			div_new_window.style.height = (bottom-top) + "px";
		}
		else
		{
			UI.getImageSize(backgroundimage,function(size){
				//alert (size);
				if (size)
				{
					div_new_window.style.width = size.width + "px";
					div_new_window.style.height = size.height+"px";
				}
			});
		}

		
		div_new_window.style.backgroundImage = "url("+ backgroundimage+")";
		div_new_window.style.backgroundRepeat = "no-repeat";
		div_new_window.style.backgroundPosition = "0px 0px";
		divwindow.appendChild(div_new_window);
		
		
		UI.addEventListener(div_new_window,"mousedown",function(e){
			//document.getElementById("out").innerHTML = (e.clientX+","+e.clientY);
			setting = true;
			oldClientX = e.clientX;
			oldClientY = e.clientY;
			div_new_window_clone = div_new_window.cloneNode(true);
			divwindow.appendChild(div_new_window_clone);
			if (FXPlayer.browserDetect()=="ie")
			{
				//document.getElementById("out1").innerHTML = div_new_window_clone.style;
				div_new_window_clone.style.filter = "alpha(opacity=50)";
			}
			else
				div_new_window_clone.style.opacity=0.5;
		});
		UI.addEventListener(document,"mousemove",function(e){
			if (setting == true)
			{
				//document.getElementById("out1").innerHTML = (newLeft + "," + newTop);
				div_new_window_clone.style.left = div_new_window.offsetLeft + (e.clientX-oldClientX) + "px";
				div_new_window_clone.style.top = div_new_window.offsetTop + (e.clientY-oldClientY) + "px";
			}
		});
		UI.addEventListener(document,"mouseup",function(e){
			if (setting == true)
			{
				div_new_window.style.left = div_new_window.offsetLeft + (e.clientX-oldClientX) + "px";
				div_new_window.style.top = div_new_window.offsetTop + (e.clientY-oldClientY) + "px";
				setting = false;
				
				divwindow.removeChild(div_new_window_clone);
				div_new_window_clone = null;
			}
		});
		

	};
	this.getDiv = function(){
		return div_new_window;
	};
	//call Constructor
	this._init();
};


UI.ResizableWindow=function( id,divwindow,left,top,right,bottom,rectleft,recttop,rectright,rectbottom,backgroundimage,maxwidth,maxheight,fnoncreate,fnonresizing)
{
	var _this = null;
	
	var width = right - left;
	var height = bottom - top;
	var rectwidth = rectright - rectleft;
	var rectheight = rectbottom - recttop;
	var imagewidth = 0;
	var imageheight = 0;
	var size = null;
	var widthex;
	var heightex;
	
	var divbg = [];
	var divbgArr = [];

	var div_new_window;
	var div_new_window_background;
	var div_new_window_clone = null;
	var div_resize = null;
	
	var settingResize = false;
	var settingMove = false;
	var lockCreateBg = false;
	var oldClientX = 0;
	var oldClientY = 0;
	this._init = function()
	{
		_this=this;	
		if (!maxwidth)
			maxwidth = 1000;
		if (!maxheight)
			maxheight = 1000;
		
		div_new_window = document.createElement("div");
		div_new_window.setAttribute("id",id);
		div_new_window.style.position="absolute";
		div_new_window.style.overflow="hidden";
		div_new_window.style.zIndex = "1";

		divwindow.appendChild(div_new_window);
		
		UI.getImageSize(backgroundimage,function(imagesize){
			if (imagesize)
			{
				imagewidth = imagesize.width;
				imageheight = imagesize.height;

				if ( width > maxwidth )
					width = maxwidth;
				else if (width < imagewidth)
					width = imagewidth;
				if ( height > maxheight )
					height = maxheight;
				else if (height < imageheight)
					height = imageheight;
		
				div_new_window.style.left=left+"px";
				div_new_window.style.top=top+"px";
				div_new_window.style.width=width+"px";
				div_new_window.style.height=height+"px";
		
			
			/*
				var temp = document.createElement("div");
				temp.setAttribute("id","rect");
				temp.style.position="absolute";
				temp.style.left=rectleft+"px";
				temp.style.top=recttop+"px";
				temp.style.width=rectwidth+"px";
				temp.style.height=rectheight+"px";
				temp.style.border = "1px #FFFFFF solid";
				temp.style.zIndex="2";
				div_new_window.appendChild(temp);
		*/
		
				div_new_window_background = document.createElement("div");
				div_new_window_background.setAttribute("id",id+"_background");
				div_new_window_background.style.position="absolute";
				div_new_window_background.style.left="0px";
				div_new_window_background.style.top="0px";
				div_new_window_background.style.width="100%";
				div_new_window_background.style.height="100%";
				div_new_window_background.style.zIndex = "1";
				div_new_window.appendChild(div_new_window_background);
				
				
				
				div_resize = document.createElement("div");
				div_resize.setAttribute("id",id+"_resize");
				div_resize.style.position="absolute";
				div_resize.style.right="0px";
				div_resize.style.bottom="0px";
				div_resize.style.width="10px";
				div_resize.style.height="10px";
				div_resize.style.cursor="se-resize";
				div_resize.style.zIndex = "5";
				
				div_new_window.appendChild(div_resize);

				var div;
				//1
				div = document.createElement("div");
				div.style.position="absolute";
				div.style.left="0px";
				div.style.top="0px";
				div.style.width=(rectleft)+"px";
				div.style.height=(recttop)+"px";
				div.style.backgroundImage = "url(" + backgroundimage + ")";
				div.style.backgroundRepeat = "no-repeat";
				div.style.backgroundPosition = "left top";
				div.style.zIndex = "4";
				div_new_window.appendChild(div);
				divbg.push(div);
				//3
				div = document.createElement("div");
				div.style.position="absolute";
				div.style.right="0px";
				div.style.top="0px";
				div.style.width=(imagewidth-rectleft-rectwidth)+"px";
				div.style.height=(recttop)+"px";
				div.style.backgroundImage = "url(" + backgroundimage + ")";
				div.style.backgroundRepeat = "no-repeat";
				div.style.backgroundPosition = "right top";
				div.style.zIndex = "4";
				div_new_window.appendChild(div);
				divbg.push(div);
				//7
				div = document.createElement("div");
				div.style.position="absolute";
				div.style.left="0px";
				div.style.bottom="0px";
				div.style.width=(rectleft)+"px";
				div.style.height=(imageheight-recttop-rectheight)+"px";
				div.style.backgroundImage = "url(" + backgroundimage + ")";
				div.style.backgroundRepeat = "no-repeat";
				div.style.backgroundPosition = "left bottom";
				div.style.zIndex = "4";
				div_new_window.appendChild(div);
				divbg.push(div);
				//9
				div = document.createElement("div");
				div.style.position="absolute";
				div.style.right="0px";
				div.style.bottom="0px";
				div.style.width=(imagewidth-rectleft-rectwidth)+"px";
				div.style.height=(imageheight-recttop-rectheight)+"px";
				div.style.backgroundImage = "url(" + backgroundimage + ")";
				div.style.backgroundRepeat = "no-repeat";
				div.style.backgroundPosition = "right bottom";
				div_new_window.appendChild(div);
				div.style.zIndex = "4";
				divbg.push(div);		
		
				UI.addEventListener(div_new_window,"mousedown",function(e){
					//document.getElementById("out").innerHTML = (e.clientX+","+e.clientY);
					settingMove = true;
					oldClientX = e.clientX;
					oldClientY = e.clientY;
					div_new_window_clone = div_new_window.cloneNode(true);
					divwindow.appendChild(div_new_window_clone);
					if (FXPlayer.browserDetect()=="ie")
					{
						//document.getElementById("out1").innerHTML = div_new_window_clone.style;
						div_new_window_clone.style.filter = "alpha(opacity=50)";
					}
					else
						div_new_window_clone.style.opacity=0.5;
				});
				UI.addEventListener(div_resize,"mousedown",function(e){
					//document.getElementById("out").innerHTML = (e.clientX+","+e.clientY);
					settingResize = true;
					oldClientX = e.clientX;
					oldClientY = e.clientY;
					if (e && e.stopPropagation) //停止事件冒泡
						e.stopPropagation();
					else
						window.event.cancelBubble = true;
				});
				UI.addEventListener(document,"mousemove",function(e){
					if (settingMove == true)
					{
						//document.getElementById("out1").innerHTML = (newLeft + "," + newTop);
						div_new_window_clone.style.left = div_new_window.offsetLeft + (e.clientX-oldClientX) + "px";
						div_new_window_clone.style.top = div_new_window.offsetTop + (e.clientY-oldClientY) + "px";
					}
					else if (settingResize == true)
					{
						if (lockCreateBg == false)
						{
							var w = div_new_window.offsetWidth + (e.clientX-oldClientX);
							var h = div_new_window.offsetHeight + (e.clientY-oldClientY);
							if (w<imagewidth)
								w=imagewidth;
							else if (w>maxwidth)
								w=maxwidth;
							else
								oldClientX = e.clientX;
								
							if (h<imageheight)
								h=imageheight;
							else if (h>maxheight)
								h=maxheight;
							else
								oldClientY = e.clientY;
								
							_this._changeSize(w,h);
							fnonresizing(_this)
						}
					}
				});
				UI.addEventListener(document,"mouseup",function(e){
					if (settingMove == true)
					{
						div_new_window.style.left = div_new_window.offsetLeft + (e.clientX-oldClientX) + "px";
						div_new_window.style.top = div_new_window.offsetTop + (e.clientY-oldClientY) + "px";
						settingMove = false;
						
						divwindow.removeChild(div_new_window_clone);
						div_new_window_clone = null;
					}
					else if (settingResize == true)
					{
						settingResize = false;
					}
				});

				_this._createBackground();
				
				fnoncreate(_this);
				
			}
		});
	};
	
	this._createBackground = function(newWidth,newHeight)
	{
		lockCreateBg = true;
		widthex = maxwidth - imagewidth + rectwidth;
		heightex = maxheight - imageheight + rectheight;
		size={x:0,y:0};
		if (widthex%rectwidth==0)
			size.x= (parseInt(widthex / rectwidth));
		else
			size.x= (parseInt(widthex / rectwidth) + 1);
		if (heightex%rectheight==0)
			size.y= (parseInt(heightex / rectheight));
		else
			size.y= (parseInt(heightex / rectheight) + 1);
			
		
		if (newWidth && newHeight)
		{
			width = newWidth;
			height = newHeight;
		}
		
		//alert (width + "," +height);
		var widthreal = width - imagewidth + rectwidth;
		var heightreal = height - imageheight + rectheight;
		var sizereal={x:0,y:0};
		if (widthreal%rectwidth==0)
			sizereal.x= (parseInt(widthreal / rectwidth));
		else
			sizereal.x= (parseInt(widthreal / rectwidth) + 1);
		if (heightreal%rectheight==0)
			sizereal.y= (parseInt(heightreal / rectheight));
		else
			sizereal.y= (parseInt(heightreal / rectheight) + 1);


		var i;
		for (i=0;i<size.y+4;i++)
			divbgArr.push([]);
		
		var iv = 0;
		var ia = 0;
		
		for (ia=0;ia<size.x-1;ia++)
		{
			//2ex
			div = document.createElement("div");
			div.style.position="absolute";
			div.style.left=(rectleft + (rectwidth*ia))+"px";
			div.style.top="0px";
			div.style.width=(rectwidth)+"px";
			div.style.height=(recttop)+"px";
			div.style.backgroundImage = "url(" + backgroundimage + ")";
			div.style.backgroundRepeat = "no-repeat";
			div.style.backgroundPosition = (0-rectleft)+"px top";
			div.style.zIndex = "3";
			if (ia>=sizereal.x-1)
				div.style.display = "none";
			div_new_window_background.appendChild(div);
			divbgArr[0][ia] = div;
			
			//8ex
			div = document.createElement("div");
			div.style.position="absolute";
			div.style.left=(rectleft + (rectwidth*ia))+"px";
			div.style.bottom="0px";
			div.style.width=(rectwidth)+"px";
			div.style.height=(imageheight-recttop-rectheight)+"px";
			div.style.backgroundImage = "url(" + backgroundimage + ")";
			div.style.backgroundRepeat = "no-repeat";
			div.style.backgroundPosition = (0-rectleft)+"px bottom";
			div.style.zIndex = "3";
			if (ia>=sizereal.x-1)
				div.style.display = "none";
			div_new_window_background.appendChild(div);
			divbgArr[size.y+1][ia] = div;
		}
		
		//2ex
		div = document.createElement("div");
		div.style.position="absolute";
		div.style.left=(rectleft + (rectwidth*(size.x-1)))+"px";
		div.style.top="0px";
		div.style.width=(widthex-(size.x-1)*rectwidth)+"px";
		div.style.height=(recttop)+"px";
		div.style.backgroundImage = "url(" + backgroundimage + ")";
		div.style.backgroundRepeat = "no-repeat";
		div.style.backgroundPosition = (0-rectleft)+"px top";
		div.style.display = "none";
		div.style.overflow = "hidden";
		div.style.zIndex = "3";
		div_new_window_background.appendChild(div);
		divbgArr[0][size.x-1] = div;

		divbgArr[0][sizereal.x-1].style.width=(widthreal-(sizereal.x-1)*rectwidth)+"px";
		divbgArr[0][sizereal.x-1].style.display="";
		//8ex
		div = document.createElement("div");
		div.style.position="absolute";
		div.style.left=(rectleft + (rectwidth*(size.x-1)))+"px";
		div.style.bottom="0px";
		div.style.width=(widthex-(size.x-1)*rectwidth)+"px";
		div.style.height=(imageheight-recttop-rectheight)+"px";
		div.style.backgroundImage = "url(" + backgroundimage + ")";
		div.style.backgroundRepeat = "no-repeat";
		div.style.backgroundPosition = (0-rectleft)+"px bottom";
		div.style.display = "none";
		div.style.overflow = "hidden";
		div.style.zIndex = "3";
		div_new_window_background.appendChild(div);
		divbgArr[size.y+1][size.x-1] = div;
		
		divbgArr[size.y+1][sizereal.x-1].style.width=(widthreal-(sizereal.x-1)*rectwidth)+"px";
		divbgArr[size.y+1][sizereal.x-1].style.display="";
		
		for (ia=0;ia<size.y-1;ia++)
		{
			//4ex
			div = document.createElement("div");
			div.style.position="absolute";
			div.style.left="0px";
			div.style.top=(recttop + (rectheight*ia))+"px";
			div.style.width=(rectleft)+"px";
			div.style.height=(rectheight)+"px";
			div.style.backgroundImage = "url(" + backgroundimage + ")";
			div.style.backgroundRepeat = "no-repeat";
			div.style.backgroundPosition = "left "+(-recttop)+"px";
			div.style.overflow = "hidden";
			div.style.zIndex = "3";
			if (ia>=sizereal.y-1)
				div.style.display = "none";
			div_new_window_background.appendChild(div);
			divbgArr[size.y+2][ia] = div;
			//6ex
			div = document.createElement("div");
			div.style.position="absolute";
			div.style.right="0px";
			div.style.top=(recttop + (rectheight*ia))+"px";
			div.style.width=(imagewidth-rectleft-rectwidth)+"px";
			div.style.height=(rectheight)+"px";
			div.style.backgroundImage = "url(" + backgroundimage + ")";
			div.style.backgroundRepeat = "no-repeat";
			div.style.backgroundPosition = "right "+(-recttop)+"px";
			div.style.overflow = "hidden";
			div.style.zIndex = "3";
			if (ia>=sizereal.y-1)
				div.style.display = "none";
			div_new_window_background.appendChild(div);
			divbgArr[size.y+3][ia] = div;
		}
		
		//4ex
		div = document.createElement("div");
		div.style.position="absolute";
		div.style.left="0px";
		div.style.top=(recttop + (rectheight*(size.y-1)))+"px";
		div.style.width=(rectleft)+"px";
		div.style.height=(heightex-(size.y-1)*rectheight)+"px";
		div.style.backgroundImage = "url(" + backgroundimage + ")";
		div.style.backgroundRepeat = "no-repeat";
		div.style.backgroundPosition = "left "+(-recttop)+"px";
		div.style.display="none";
		div.style.overflow = "hidden";
		div.style.zIndex = "3";
		div_new_window_background.appendChild(div);
		divbgArr[size.y+2][size.y-1] = div;

		divbgArr[size.y+2][sizereal.y-1].style.height=(heightreal-(sizereal.y-1)*rectheight)+"px";
		divbgArr[size.y+2][sizereal.y-1].style.display="";
		
		//6ex
		div = document.createElement("div");
		div.style.position="absolute";
		div.style.right="0px";
		div.style.top=(recttop + (rectheight*(size.y-1)))+"px";
		div.style.width=(imagewidth-rectleft-rectwidth)+"px";
		div.style.height=(heightex-(size.y-1)*rectheight)+"px";
		div.style.backgroundImage = "url(" + backgroundimage + ")";
		div.style.backgroundRepeat = "no-repeat";
		div.style.backgroundPosition = "right "+(-recttop)+"px";
		div.style.display="none";
		div.style.overflow = "hidden";
		div.style.zIndex = "3";
		div_new_window_background.appendChild(div);
		divbgArr[size.y+3][size.y-1] = div;
	
		divbgArr[size.y+3][sizereal.y-1].style.height=(heightreal-(sizereal.y-1)*rectheight)+"px";
		divbgArr[size.y+3][sizereal.y-1].style.display="";
		
		//5ex
		for (iv=0;iv<size.y-1;iv++)
		{
			for (ia=0;ia<size.x-1;ia++)
			{
				div = document.createElement("div");
				div.style.position="absolute";
				div.style.left=(rectleft + (rectwidth*ia))+"px";
				div.style.top=(recttop+(rectheight*iv))+"px";
				div.style.width=(rectwidth)+"px";
				div.style.height=(rectheight)+"px";
				div.style.backgroundImage = "url(" + backgroundimage + ")";
				div.style.backgroundRepeat = "no-repeat";
				div.style.zIndex = "2";
				div.style.backgroundPosition = (-rectleft)+"px "+(-recttop)+"px";
				if (iv>=sizereal.y-1 || ia >=sizereal.x-1)
					div.style.display = "none";
				div_new_window_background.appendChild(div);
				divbgArr[iv+1][ia] = div;
			}
		}
		//alert (divbgArr[1] + "\n" + divbgArr[2] + "\n" + divbgArr[3] + "\n" + divbgArr[4] + "\n" + divbgArr[5] + "\n" + divbgArr[6] + "\n" + divbgArr[7] + "\n" + divbgArr[8] + "\n" + divbgArr[9] + "\n" + divbgArr[10]);
		
		//5ex
		for (ia=0;ia<size.x-1;ia++)
		{
			div = document.createElement("div");
			div.style.position="absolute";
			div.style.left=(rectleft + (rectwidth*ia))+"px";
			div.style.top=(recttop + (rectheight*(size.y-1)))+"px";
			div.style.width=(rectwidth)+"px";
			div.style.height=(heightex-(size.y-1)*rectheight)+"px";
			div.style.backgroundImage = "url(" + backgroundimage + ")";
			div.style.backgroundRepeat = "no-repeat";
			div.style.backgroundPosition = (-rectleft)+"px "+(-recttop)+"px";
			div.style.zIndex = "2";
			div.style.display = "none";
			div_new_window_background.appendChild(div);
			divbgArr[size.y][ia] = div;
			
			divbgArr[sizereal.y][ia].style.height=(heightreal-(sizereal.y-1)*rectheight)+"px";
			if (ia<sizereal.x-1)
				divbgArr[sizereal.y][ia].style.display="";
		}
		//5ey
		for (ia=0;ia<size.y-1;ia++)
		{
			div = document.createElement("div");
			div.style.position="absolute";
			div.style.left=(rectleft + (rectwidth*(size.x-1)))+"px";
			div.style.top=(recttop + (rectheight*ia))+"px";
			div.style.width=(widthex-(size.x-1)*rectwidth)+"px";
			div.style.height=(rectheight)+"px";
			div.style.backgroundImage = "url(" + backgroundimage + ")";
			div.style.backgroundRepeat = "no-repeat";
			div.style.backgroundPosition = (-rectleft)+"px "+(-recttop)+"px";
			div.style.zIndex = "2";
			div.style.display = "none";
			div_new_window_background.appendChild(div);
			divbgArr[ia+1][size.x-1] = div;

			//alert (divbgArr[ia+1] + "," + sizereal.x-1);
			
			//alert (divbgArr[ia+1] + "\n" + divbgArr[ia+1].length);
			//alert (sizereal.y + ";" + divbgArr[sizereal.y] +";"+sizereal.x);
			divbgArr[ia+1][sizereal.x-1].style.width=(widthreal-(sizereal.x-1)*rectwidth)+"px";
			if (ia<sizereal.y)
				divbgArr[ia+1][sizereal.x-1].style.display="";
		}
		//5exy
		div = document.createElement("div");
		div.style.position="absolute";
		div.style.left=(rectleft + (rectwidth*(size.x-1)))+"px";
		div.style.top=(recttop + (rectheight*(size.y-1)))+"px";
		div.style.width=(widthex-(size.x-1)*rectwidth)+"px";

		div.style.height=(heightex-(size.y-1)*rectheight)+"px";
		div.style.backgroundImage = "url(" + backgroundimage + ")";
		div.style.backgroundRepeat = "no-repeat";
		div.style.zIndex = "2";
		div.style.backgroundPosition = (-rectleft)+"px "+(-recttop)+"px";
		div_new_window_background.appendChild(div);
		div.style.display = "none";
		divbgArr[size.y][size.x-1] = div;
		
		divbgArr[sizereal.y][sizereal.x-1].width=(widthreal-(sizereal.x-1)*rectwidth)+"px";
		divbgArr[sizereal.y][sizereal.x-1].style.height=(heightreal-(sizereal.y-1)*rectheight)+"px";
		divbgArr[sizereal.y][sizereal.x-1].style.display="";
		
		
		lockCreateBg = false;
	};
	
	this._changeSize =function( newWidth , newHeight )
	{
		if (newWidth <= maxwidth && newWidth>=imagewidth && newHeight<=maxwidth && newHeight>=imageheight)
		{
			//alert ("change");
			div_new_window.style.width = newWidth + "px";
			div_new_window.style.height = newHeight + "px";
			div_new_window_background.innerHTML = "";
			
			divbgArr = [];
			_this._createBackground( newWidth , newHeight );

		}	
	};
	this.getDiv = function(){
		return div_new_window;
	};
	this.getSize = function(){
		
		return {
			w : width,
			h : height,
			minw: imagewidth,
			minh: imageheight,
			maxw: maxwidth,
			maxh: maxheight
		};
	};
	
	
	this._init();
};

UI.FrameWindow = function( id,divwindow )
{
	var _this = null;
	var divframe = null;
	var divsplit = null;
	var divleft = null;
	var divright = null;
	var width = 0;
	var height = 0;
	var splitwidth = 3;
	var leftwidth = 0;
	var settingmove = false;
	var oldClientX = 0;
	
	this._init = function()
	{
		_this = this;
		
		if (divwindow)
		{
			divframe = divwindow;
			width = divframe.offsetWidth;
			height = divframe.offsetHeight;
			leftwidth = parseInt(width*0.3);
			divleft = document.createElement("div");
			divleft.setAttribute("id",id+"_left");
			divleft.setAttribute("name",id+"_left");
			divleft.style.position = "absolute";
			divleft.style.top = "0px";
			divleft.style.left = "0px";
			divleft.style.width = leftwidth+"px";
			divleft.style.height = height + "px";
			divleft.style.overflow = "auto";
			//divleft.style.border = "1px solid";
			divframe.appendChild(divleft);
			
			divright = document.createElement("div");
			divright.setAttribute("id",id+"_right");
			divright.setAttribute("name",id+"_right");
			divright.style.position = "absolute";
			divright.style.top = "0px";
			divright.style.right = "0px";
			divright.style.width = (width-splitwidth-leftwidth)+"px";
			divright.style.height = height + "px";
			//divright.style.border = "1px solid";
			divright.style.overflow = "auto";
			divframe.appendChild(divright);

			
			divsplit = document.createElement("div");
			divsplit.setAttribute("id",id+"_split");
			divsplit.setAttribute("name",id+"_split");
			divsplit.style.position = "absolute";
			divsplit.style.top = "0px";
			divsplit.style.left = leftwidth+"px";
			divsplit.style.width = "3px";
			divsplit.style.height = height + "px";
			divsplit.style.cursor = "e-resize";

			//divsplit.style.border = "1px solid";
			divframe.appendChild(divsplit);


			UI.addEventListener(divframe,"mousedown",function(e){
				if (e && e.stopPropagation) //停止事件冒泡
					e.stopPropagation();
				else
					window.event.cancelBubble = true; 
			});
			UI.addEventListener(divsplit,"mousedown",function(e){
				if (e && e.stopPropagation) //停止事件冒泡
					e.stopPropagation();
				else
					window.event.cancelBubble = true; 
				
				settingmove = true;
				oldClientX = e.clientX;
			});

			UI.addEventListener(document,"mousemove",function(e){
				if (settingmove == true)
				{
					leftwidth = divsplit.offsetLeft + (e.clientX-oldClientX);
					if (leftwidth>0 && leftwidth<width-splitwidth)
					{
						//document.getElementById("out").innerHTML = (width-3-leftwidth);
						divsplit.style.left = leftwidth + "px";
						divleft.style.width = leftwidth + "px";
						divright.style.width = (width-splitwidth-leftwidth)+"px";
						
						oldClientX = e.clientX;
					}
				}
			});
			UI.addEventListener(document,"mouseup",function(e){
				if (settingmove == true)
				{
					leftwidth = divsplit.offsetLeft + (e.clientX-oldClientX);
					divsplit.style.left = leftwidth + "px";
					
					divleft.style.width = leftwidth+"px";
					divright.style.width = (width-splitwidth-leftwidth)+"px";
					settingmove = false;
				}
			});


		}
	};
	this.getSplitDiv = function()
	{
		return divsplit;
	};
	this.getLeftDiv = function()
	{
		return divleft;
	};
	this.getRightDiv = function()
	{
		return divright;
	};
	this.setDurationColor = function(durationcolor)
	{
		if (durationcolor)
		{
			divsplit.style.backgroundColor = durationcolor;
		}
	};
	this.resize=function(w,h)
	{
		if (w&&h)
		{
			width = w
			height = h;
			divleft.style.width = leftwidth+"px";
			divleft.style.height = height + "px";
			divright.style.width = (width-leftwidth-5)+"px";
			divright.style.height = height + "px";
			divsplit.style.left = leftwidth+"px";
			divsplit.style.height = height + "px";
		}
	};
	this._init();
};


UI.List = function( id,divwindow,items,colorNumber,fnclick)
{
	var _this = null;
	var width = 0;
	var height = 0;
	var divItems = [];
	var arrItems = [];
	var selectIndex = 1;
	
		
	this._init = function()
	{
		_this = this;
		
		if (divwindow)
		{
			width = divwindow.offsetWidth;
			height = divwindow.offsetHeight;
			_this.setList(items);
		}
	};
	this.setList = function(items)
	{
		var i=0;
		if (items && items.length>0)
		{
			arrItems = items;
			var divlist;
			var divselect;
			var divnumber;
			var divtext;
			for (i=1;i<=arrItems.length;i++)
			{
				divlist = document.createElement("div");
				divlist.setAttribute("id",i);
				divlist.setAttribute("name",i);
				divlist.setAttribute("num",i);
				if (i==selectIndex){
					divlist.className = "fxplaylistitem fxplaylistitemselected";
				}
				else{
					if (i%2==0)
						divlist.className = "fxplaylistitem fxplaylistitem1";
					else
						divlist.className = "fxplaylistitem fxplaylistitem2";
				}
				if (colorNumber)
				{
					divnumber = document.createElement("span");
					divnumber.setAttribute("id","num");
					divnumber.setAttribute("name","num");
					divnumber.setAttribute("num",i);
					divnumber.style.color = colorNumber;
					divnumber.innerHTML = (i+".");
					divlist.appendChild(divnumber);
				}
				divtext = document.createElement("span");
				divtext.setAttribute("id","text");
				divtext.setAttribute("name","text");
				divtext.setAttribute("num",i);
				divtext.innerHTML = arrItems[i];
				divlist.appendChild(divtext);
	
				//divleft.style.border = "1px solid";
				divwindow.appendChild(divlist);
				divItems.push(divlist);
				
				UI.addEventListener(divlist,"mousemove",function(e){
					var obj;
					if (e && e.target)
						obj=e.target;
					else
						obj=e.srcElement;
					
					if (obj)
					{
						obj.className = "fxplaylistitem fxplaylistitemmousemove";
					}
				});
				UI.addEventListener(divlist,"mouseout",function(e){
					var obj;
					if (e && e.target)
						obj=e.target;
					else
						obj=e.srcElement;
					if (obj)
					{
						var i = obj.getAttribute("num");
						document.getElementById("out").innerHTML = (i+","+selectIndex);
						if (i==selectIndex)
						{
							obj.className = "fxplaylistitem fxplaylistitemselected";
						}
						else
						{
							if (i%2==0)
								obj.className = "fxplaylistitem fxplaylistitem1";
							else
								obj.className = "fxplaylistitem fxplaylistitem2";
						}
							
					}	
				});

			}
		}
	};

	this._init();
};


UI.addEventListener = function(objSrc,strEvent,fncallback)
{
	var browser = FXPlayer.browserDetect();
	if ( browser == "ie")
		objSrc.attachEvent("on"+strEvent,fncallback);
	else if ( browser == "firefox" )
		objSrc.addEventListener(strEvent,fncallback,false);
	else
		objSrc.addEventListener(strEvent,fncallback,false);
}
UI.removeEventListener = function(objSrc,strEvent,fncallback)
{
	var browser = FXPlayer.browserDetect();
	if ( browser == "ie")
		objSrc.detachEvent("on"+strEvent,fncallback);
	else if ( browser == "firefox" )
		objSrc.removeEventListener(strEvent,fncallback,false);
	else
		objSrc.removeEventListener(strEvent,fncallback,false);
}
