function downloadFile(filepath)
{
    if(typeof(filepath) == "undefined" || filepath == null || filepath=="") return ;
    filepath = encodeURIComponent(filepath);
    var url = "../Utility/DownLoadFile.aspx?filepath="+filepath;
    openBrWindow(url,'DownLoadFileWin','width=720,height=460,top=80,left=80,resizable=yes, scrollbars=yes');
    
}
