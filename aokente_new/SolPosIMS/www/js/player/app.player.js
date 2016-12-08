

function playbycallid(con,callid)
{
    if(arguments.length ==1)
    {
        callid = con;
    }
    var result = XmlHttpHelper.synCall("../QC/GetRecordId.aspx?callid="+callid);
    var results = result.split(";");
    if(results[0] == "false")
    {
        alert("≤È—Ø ß∞‹£°");
        return ;
    }
    var recordid = results[1];
    play(con,recordid);
}

function play(con,str) 
{
    return PlayRecord.play(con,str);
}


var PlayRecord={
    bMoveable:true, 
    inWin:window,
    init : function()
    {
        var mainWin = null;
		try
		{
			mainWin = GetMainWindow();
		}
		catch (e)
		{
		}
        if(mainWin != null && mainWin == window.top)
        {
            PlayRecord.inWin = mainWin;
        }
        else
        {
            PlayRecord.inWin.document.writeln('<iframe id=playrecordLayer  frameborder=0 style="position: absolute; width:310px;height:290px; left:100px;top:100px; z-index: 9998; display:none" scrolling=no src="../js/player/player.html"></iframe>');
        }
    },
    play : function(cont,str) 
    {
        var dads = PlayRecord.inWin.document.all.playrecordLayer.style;
        dads.top=150;
        dads.left =PlayRecord.inWin.document.body.offsetWidth/2-150;
        dads.display = '';
        PlayRecord.inWin.playrecordLayer.location.href ='../js/player/player.html?id='+str;
        event.returnValue=false;
    }
}

PlayRecord.init();
