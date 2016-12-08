// JScript 文件

var LocalLogHelper = 
{
    logPath:"c:\\temp",
    logFileName:"localLog.log",
    isWriteLog:true,
    fileObject:null,
    init:function()
    {
        if(this.fileObject == null)
        {
            this.fileObject = new ActiveXObject("Scripting.FileSystemObject");
            if(!this.fileObject.FolderExists(this.logPath))
            {  
                this.fileObject.CreateFolder(this.logPath);
            }
            this.logPath += "\\log";
            if(!this.fileObject.FolderExists(this.logPath))
            {  
                this.fileObject.CreateFolder(this.logPath);
            }
            this.logPath += "\\" + this.formatDate();
            if(!this.fileObject.FolderExists(this.logPath))
            {  
                this.fileObject.CreateFolder(this.logPath);
            }
        }
    },
    formatDate:function()
    {
        var dateTime = new Date();
        var year = dateTime.getFullYear();
        var month = dateTime.getMonth() + 1;
        var date = dateTime.getDate();
        if(month < 10 ) month = "0" + month;
        if(date < 10) date = "0" + date;
        return "" + year + month + date;
    },
    write:function(content)
    {
        if(this.isWriteLog)
        {
            try
            {
                this.init();
                var ts = this.fileObject.OpenTextFile(this.logPath+"\\"+this.logFileName,8,true,-2);
                ts.WriteLine(content);
                ts.Close();
            }
            catch(e)
            {
                //alert(e.description);
            }
        }
    },
    writeObLog:function(agentId,custId,msg)
    {
        if(typeof(agentId) == "undefiend") agentId = "";
        if(typeof(custId) == "undefiend") custId = "";
        if(typeof(msg) == "undefiend") msg = "";
        var content = Date()+"|"+agentId+"|"+custId+"|"+msg;
        this.write(content);
    }
}