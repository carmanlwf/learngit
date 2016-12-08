// JScript 文件
//合并表格
function MergeTable(source,dest)
{
    var row;
    var cell;
    var sourceTb = document.all(source);
    var destTb = document.all(dest);
    for (var i=0; i<sourceTb.rows.length; i++)
   {
         row = document.createElement("tr");
         for (var j=0; j<sourceTb.rows(i).cells.length; j++)
        {
             cell = document.createElement("td");
             row.appendChild(cell);
             //复制对象
             for(k=0;k<sourceTb.rows(i).cells(j).all.length;k++)
                 cell.appendChild(sourceTb.rows(i).cells(j).all.item(k));
        }
        destTb.tBodies(0).appendChild(row);
    }
    for (var i=sourceTb.rows.length-1; i>=0; i--)
    {
        sourceTb.deleteRow(i)
    }
}
function ChangeTableLayout()
{
     if(document.all('tbHeader1') == null)
        MergeTable('tbForm1','GridView1');
    else
        MergeTable('tbForm1','tbHeader1');
}
//验证字符串空值
function checkNull(str,isAlert,name){
    if(typeof(str)=="undefined") str ="";
    if(typeof(isAlert) == "undefined") isAlert = false;
    if(typeof(name) == "undefined") name = ""; 
	if(str == null || str.replace(/(^\s*)|(\s*$)/g,"") == "")
	{
	    if(isAlert)
	    {
            alert(name+"不能为空！");
	    }
	    return false;
	}
    else
    {
        return true;
    }

}
function checkEleValue(id,isAlert,name)
{
    var value = document.getElementById(id).value;
    return checkNull(value,isAlert,name);
}
function checkNumber(num,isAlert,name)
{
    if(typeof(num)=="undefined") str ="";
    if(typeof(isAlert) == "undefined") isAlert = false;
    if(typeof(name) == "undefined") name = ""; 
    var thePat = /^(\d{1,9})?$/;
    var gotIt = thePat.exec(num);
    if(gotIt == null)
    {
        if(isAlert)
        {
            alert(name+'输入不合法，格式应为正整数');
        }
        return false
    }else
    {
        return true;
    }
}
function checkEleNum(id,isAlert,name)
{
    if(typeof(id)=="undefined") return false;
    if(typeof(isAlert) == "undefined") isAlert = false;
    if(typeof(name) == "undefined") name = ""; 
    var value = document.getElementById(id).value;
    return checkNumber(value,isAlert,name);
}
