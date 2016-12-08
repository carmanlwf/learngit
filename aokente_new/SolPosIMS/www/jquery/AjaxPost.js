var AjaxPost=function(url){
　　　　　　var request;
　　　　　　var raulst='';
　　　　　　var CreateRquest=function(){
　　　　　　　　var httpRequest;
　　　　　　　　try{
　　　　　　　　　　httpRequest=new ActiveXObject("Msxml2.XMLHTTP");
　　　　　　　　}catch(e){
　　　　　　　　　　try{
　　　　　　　　　　　　httpRequest=new ActiveXObject("Microsoft.XMLHTTP");
　　　　　　　　　　}catch(e1){
　　　　　　　　　　　　httpRequest=new XMLHttpRequest();
　　　　　　　　　　}
　　　　　　　　}
　　　　　　　　return httpRequest;
　　　　　　}
　　　　　　var SendRequest=function(){
　　　　　　　　request=CreateRquest();
　　　　　　　　request.open("post",url,false);
　　　　　　　//　alert(url);
　　　　　　　　request.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
　　　　　　　　//request.setRequestHeader("Content-Type","text/html; charset=UTF-8");
　　　　　　　//　request.onreadystatechange=ResponseRequest;
　　　　　　　　request.send(null);
　　　　　　　if(request.readystate==4){
　　　　　　　　　　if(request.status==200){
　　　　　　　　　　　　raulst=　request.responseText;
　　　　　　　　　　}
　　　　　　　　　　else{
　　　　　　　　　　　　raulst= "False";
　　　　　　　　　　}
　　　　　　　　}
　　　　　　}
　　　　　　//var ResponseRequest=function(){
//　　　　　　　if(request.readystate==4){
//　　　　　　　　　　if(request.status==200){
//　　　　　　　　　　　　raulst=　request.responseText;
//　　　　　　　　　　}
//　　　　　　　　　　else{
//　　　　　　　　　　　　raulst= "False";
//　　　　　　　　　　}
//　　　　　　　　}
//　　　　　　　　return raulst;
//　　　　　　}
　　　　　　SendRequest();
　　　　
return raulst;
　　　　}
//var OnBlur=function(el)
//　　　　{
//　　　　　　var option={
//　　　　　　　　Url:el,
//　　　　　　　Param:"text=123",
////　　　　　　　　Success:function(request){
////　　　　　　　　//alert(request.responseText);
////　　　　　　　　//return　request.responseText;
////　　　　　　　　},
////　　　　　　　　Failure:function(request){
////　　　　　　　   // return "False";
//　　　　　　　}
//　　　　　　};
//　　　　　　
//　　　　　return　new Ajax(option);
//　　　　}
//var resualt=function(request)
//　　　　　　{
//　　　　　　
//　　　　　　}