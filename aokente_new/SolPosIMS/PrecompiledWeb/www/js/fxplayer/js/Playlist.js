//<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
/*
Playlist
	Construction
		Playlist( id , title , author , url )
	Operations
		void loadTTPlaylist ( path )
		void add ( title , author , url )
		PlaylistItem removeByTitle ( title )
		PlaylistItem removeById ( id )
		PlaylistItem getItem ( id )
		int getCurrent ()
		void previous()
		void next()
		void first()
		void last()
	Attributes
		String title
		String version
		String generator
		PlaylistItem[] playlistitem
		int currentID
	
	Attention
		the page must has tag "body"
		each FXPlayer Object must only have only have ONE Player Object
*/
function PlaylistItem( id , title , author , url )
{
	this.id = id;
	this.title = title;
	this.author = author;
	this.url = url;
}

function Playlist( parent )
{
//private attributes
	var _this = null;
	var _parent = null;
//public attributes	
	this.title = "";
	this.version = "";
	this.generator = "";
	this.currentID = 0;

	this.playlistitem = new Array();
//Constructor
	this.init = function(){
		_this = this;
		if (parent)
			_parent = parent;
	};
//public operations
	this.loadTTPlaylist = function( path ){
		_this.playlistitem = new Array();
		if( path ){
			FXPlayer.loadXMLFile(path,function( xmlDoc ){
				var root = xmlDoc.getElementsByTagName("ttplaylist")[0];
				if (root != null){
					_this.title = root.getAttribute("title");
					_this.version = root.getAttribute("version");
					_this.generator = root.getAttribute("generator");
					var items = xmlDoc.getElementsByTagName("item");
					for (var i=0;i<items.length;i++){
						_this.add( items[i].getAttribute("title") , "", items[i].getAttribute("file") );
					}
				}																		
			});
		}
	};
	this.add = function ( title , url , author){
		if ( title && url ){
			if (!author)
				author = "";
			_this.playlistitem.push( new PlaylistItem( _this.playlistitem.length , title , author , url ) );
		}
	};
	this.removeByTitle = function ( title ) {
		var temp = null;
		for( var i=0;i<_this.playlistitem.length;i++ ){
			if( _this.playlistitem[i].title == title){
				temp = _this.playlistitem[i];
				for (var j=i ; j<_this.playlistitem.length-1 ; j++ )
					_this.playlistitem[j]=_this.playlistitem[j+1];
				_this.playlistitem.pop();
			}
		}
		return temp;
	};
	this.removeById = function ( id ) {
		var temp = null;
		id = parseInt(id);
		if (isNaN(id) == false && id >= 0 && id< _this.playlistitem.length){
			temp = _this.playlistitem[id];
			for (var j=id ; j<_this.playlistitem.length-1 ; j++ )
				_this.playlistitem[j]=_this.playlistitem[j+1];
			_this.playlistitem.pop();
		}
		return temp;
	};
	this.getItem = function( id ){
		if (_this.playlistitem.length > 0)
			return _this.playlistitem[ id ];
		else
			return null;
	};
	this.getCurrent = function(){
		return _this.getItem( _this.currentID );
	};
	this.previous = function(){
		if (_this.playlistitem.length > 0 ){
			var id = _this.currentID - 1;
			if (id < 0 )
				id = _this.playlistitem.length-1;
			_this.currentID = id;
		}
	};
	this.next = function(){
		if (_this.playlistitem.length > 0 ){
			var id = _this.currentID + 1;
			if (id >= _this.playlistitem.length)
				id = 0;
			_this.currentID = id;
		}
	};
	this.first = function(){
		if (_this.playlistitem.length >0 ){
			var id = 0;
			_this.currentID = id;
		}
	};
	this.last = function(){
		if (_this.playlistitem.length >0 ){
			var id = _this.playlistitem.length-1;
			_this.currentID = id;
		}
	};
	
	//call Constructor
	this.init();
}