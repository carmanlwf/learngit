function fileManager(currentPath,currentFile,controlId)
{
    if(typeof(currentPath) == "undefined" || currentPath == null || currentPath=="") return ;
    if(typeof(currentFile) == "undefined" || currentFile == null) currentFile = "";
    if(typeof(controlId) == "undefined" || controlId == null) controlId = "";
    currentPath = encodeURIComponent(currentPath);
    currentFile = encodeURIComponent(currentFile);
    var url = "../Utility/FileManager.aspx?"+
    "currentPath="+currentPath+"&currentFile=" + currentFile+"&controlId=" + controlId;
    openBrWindow(url,'FileManagerWin','width=750,height=560,top=80,left=80,resizable=yes, scrollbars=yes');
}