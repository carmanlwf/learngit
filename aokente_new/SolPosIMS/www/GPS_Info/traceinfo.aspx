<%@ Page Language="C#" AutoEventWireup="true" CodeFile="traceinfo.aspx.cs" Inherits="GPS_Info_traceinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../js/app.edit.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
body{margin:0;padding:10px;font-size:12px;}
#mapcontainer{width:98%; height:500px;border:1px #999 solid;text-align:center;margin-top:10px}
-->
</style>
    <script type="text/javascript">
        WaitHelper.showWaitMessage();
    </script>
  
</head>
<body>
<div style=" background-color:whitesmoke; width:98%; float:left; margin-bottom:5px; line-height:20px;"><form id="From1" runat="server">
		选择查询人员<asp:DropDownList ID="list_operator" runat="server" Width="80px">
                        </asp:DropDownList>
                        &nbsp;选择查询日期<input type="text" class="inputblue" 
            style="width: 80px" id="start_date_begin"
                            runat="server" onfocus="setday(this)" vdisp="起始时间" 
            vtype="datetime" name="start_date_begin"
                            maxlength="20" />&nbsp; 
        <input type="button" name="btnSearch" value="查 询" id="btnSearch" runat="server" onserverclick="btnSearch_ServerClick" /> <input 
            type="button" name="btnRtn" value="返 回" id="btnRtn" runat="server" 
            onserverclick="btnRtn_ServerClick" visible="True" /></form></div>
<div id="mapcontainer"></div>
</body>
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
<script type="text/javascript">

    //定义全局变量
    var mySquare = "";
    var marker;   //图标
    var label; //信息标签
    var map = new BMap.Map("mapcontainer");
    var longi = 105.055137;
    var lati = 29.609006;
    var timepoint = "00:00:00";
    var point = new BMap.Point(<%=Ims.Main.BLL.ConfigParmsInfo.mapPositionXY.longitude %>, <%=Ims.Main.BLL.ConfigParmsInfo.mapPositionXY.latitude %>);
    map.centerAndZoom(point, 12); //初始化地图
    map.enableKeyboard(); //启用键盘操作
    map.enableScrollWheelZoom(); //启用滚轮放大缩小
    //map 增加操作
    map.addControl(new BMap.MapTypeControl({ mapTypes: [BMAP_NORMAL_MAP, BMAP_HYBRID_MAP] }));
    map.addControl(new BMap.MapTypeControl({ anchor: BMAP_ANCHOR_TOP_LEFT }));
    map.addControl(new BMap.NavigationControl());
    map.addControl(new BMap.ScaleControl());
    map.addControl(new BMap.OverviewMapControl());
    // 搜索
    function mapSearch(longi, lati) {
        point = new BMap.Point(longi, lati);
        if (longi == "undefined" || longi == "" || lati == "undefined" || lati == "") {
            alert("请输入完整的经纬度！");
            return;
        }
        if (map == "" || map == "undefined")
        { return; }
        map.centerAndZoom(point, 15);
    }
    //标记
    var i = -1;
    function addMarker(longi, lati, timepoint) {
        point = new BMap.Point(longi, lati);
        map.centerAndZoom(point, 15);
        //timepoint = timepoint.substring(11,timepoint.length);//仅显示时间
            //显示图标
            label = new BMap.Label("", { offset: new BMap.Size(10, -15) });
            label.setStyle({ 
                            color:"#000000", 
                            fontSize:"12px", 
                            backgroundColor:"orange",
                            border:"1",
                            borderColor:"#000000", 
                            fontWeight:"normal"
                            });
            marker = new BMap.Marker(point, { icon: new BMap.Icon("test.gif", new BMap.Size(20, 20), { imageOffset: new BMap.Size(0, 0) }) });
            //marker.setLabel(label);
            i++;
            //信息窗口  
  var message = "<strong>当前坐标:</strong><p><font color = 'green'>经度:" +point.lng+" 纬度:" +point.lat+"</font><p><font color = 'blue'>时间:" + timepoint+"</font>";    
        var opts = { width:200,height:100,title:"收费员位置信息"}; //信息窗口  
        var infoWindow = new BMap.InfoWindow(message,opts); //创建信息窗口对象
        //marker.openInfoWindow(infoWindow);  //自动打开信息窗口  
        
        marker.addEventListener("mouseover", function () {     
        this.openInfoWindow(infoWindow); });  //当鼠标移到标注时，打开信箱窗口口
        
        marker.addEventListener("mouseout", function () {         
        this.closeInfoWindow(); });  //当鼠标移到标注时，打开信箱窗口口
        
            /*
            marker.addEventListener("mouseover", function(e){
            label.setContent(timepoint);
                   label.setStyle({display:"block"});    //给label设置样式，任意的CSS都是可以的                   
                   });    
            marker.addEventListener("mouseout", function(e){
                  label.setStyle({display:"none"});   //给label设置样式，任意的CSS都是可以的 
                  });        
                   */
            map.addOverlay(marker);
            map.centerAndZoom(point, 18);
 //var marker = new BMap.Marker(point);    
 //map.addOverlay(marker);    

        
        //var circle = new BMap.Circle(point, 5);
       // map.addOverlay(circle);
    }
    
    //按顺序标出轨迹
    /*
    function addLobcus(longi1, lati1, longi2, lati2) {
        point1 = new BMap.Point(longi1, lati1);
        point2 = new BMap.Point(longi2, lati2);
        var polyline = new BMap.Polyline([point1, point2], { strokeColor: "blue", strokeWeight: 3, strokeOpacity: 0.5 });
        map.addOverlay(polyline);

    }
  */
  var points = new Array();
    <% foreach (System.Data.DataRow dr in dt_Points.Rows)
   { %>
   
   addMarker(<%=dr["lng"]%>,<%=dr["lat"]%>,'<%=dr["logtime"]%>');
  <%} %>

    <%for(int i=0; i< dt_Points.Rows.Count;i++)
    {
        if(i>0)
        {%>
            addLobcus(<%=dt_Points.Rows[i-1]["lng"]%>,<%=dt_Points.Rows[i-1]["lat"]%>,<%=dt_Points.Rows[i]["lng"]%>,<%=dt_Points.Rows[i]["lat"]%>)
        <%}
    }%>

</script>  
    <script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>
</html>