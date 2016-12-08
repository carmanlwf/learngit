// JScript 文件

function sendMail(to,cc,subject,body)
{
    if(typeof(to) == "undefined" || to == null) to = "";
    if(typeof(cc) == "undefined" || cc == null) cc = "";
    if(typeof(subject) == "undefined" || subject == null) subject = "";
    if(typeof(body) == "undefined" || body == null) body = "";
    to = encodeURIComponent(to);
    cc = encodeURIComponent(cc);
    subject = encodeURIComponent(subject);
    body = encodeURIComponent(body);
    var url = "../Utility/SendMail.aspx?"+
    "to="+to+"&cc=" + cc + "&subject="+subject+"&body="+body;
    openBrWindow(url,'SendMailWin','width=720,height=460,top=80,left=80');
}