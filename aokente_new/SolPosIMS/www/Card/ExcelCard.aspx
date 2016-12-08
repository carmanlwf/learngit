<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExcelCard.aspx.cs" Inherits="Card_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导入制卡</title>
   <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script src="../lib/jquery/jquery-1.3.2.min.js"  type="text/javascript"></script>
    
    
    <script type="text/javascript" src="../js/json.js"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>
           <script  type="text/javascript">
           
         function onAreaSelectChange() {
            var selectArea = document.getElementById('Area_Code');
            var Area = selectArea.value;
            document.all.Site_Code.options.length = 0;
            BindNormalTableToListControl('Site_Code', "id", "sitename", "tb_site", "id", "areacode = '" + Area + "'", "请选择");
        }
              //单选
         function rd(){
           
            var a=document.getElementById("ZJ").checked;
         
            if(a==true)
            {
            document.getElementById("SJ").checked=false;
            }else
            {
            document.getElementById("SJ").checked=true;
            }
          
         }
             function rd1(){
       
            var a=document.getElementById("SJ").checked;
            //$("#ZJ").val("12");
          
            if(a==true)
            {
            document.getElementById("ZJ").checked=false;
            }else
            {
            document.getElementById("ZJ").checked=true;
            }
          
         }
             function ischool3() {
             
               var a=document.getElementById("Checkbox1").checked;
         
            if(a==true)
            {
              siteID.style.display = "none";
            document.getElementById("Checkbox2").checked=false;
            }else
            {
             siteID.style.display = "";
            document.getElementById("Checkbox2").checked=true;
            }
           
        }


        function ischool4() {
            var a=document.getElementById("Checkbox2").checked;
         
            if(a==true)
            {
             siteID.style.display = "";
            document.getElementById("Checkbox1").checked=false;
            }else
            {
            siteID.style.display = "none";
            document.getElementById("Checkbox1").checked=true;
            }
        }
                   function AppearProgress() {

//            $("#DivCover").css("display", "block");
//            $("#Waiting").css("display", "block");
            document.getElementById("DivCover").style.display = "block";
            document.getElementById("Waiting").style.display = "block";
        }
        
        
          function OnLoadtime() {
            //   Isjihuo.style.display= "none"; 
            onAreaSelectChange();
        }
           </script>
           
            <style type="text/css">
        /*等待状态样式开始*/#DivCover
        {
            background-color: #cccccc;
            filter: Alpha(Opacity=50, Style=0);
            opacity: 0.50;
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            _height: 768px;
            z-index: 999;
        }
        #Waiting
        {
            position: absolute;
            text-align: center;
            left: 50%;
            top: 50%;
            margin-left: -110px;
            margin-top: -50px;
            z-index: 1000;
            width: 200px;
            background-color: #FFFFFF;
            border-top: 1px dashed #52D3EA;
            border-right: 1px dashed #52D3EA;
            border-bottom: 1px dashed #52D3EA;
            border-left: 1px dashed #52D3EA;
            padding: 15px 10px 10px 10px;
        }
        #Waiting img
        {
            margin-bottom: 10px;
        }
        /*等待状态样式结束*/</style>
           
        <script  type="text/javascript">
         function MarkInput() {
                   var isIE = (document.all) ? true : false;
                    var isIE7 = isIE && (navigator.userAgent.indexOf('MSIE 7.0') != -1);
                    var isIE8 = isIE && (navigator.userAgent.indexOf('MSIE 8.0') != -1);
                    var isIE6 = isIE && (navigator.userAgent.indexOf('MSIE 6.0') != -1);
                    var filepath = document.getElementById("FileCell").value;
                    if (isIE6) { path = filepath; }
                    var file = document.getElementById("FileCell");
                    if (isIE7 || isIE8) {
                        file.select(); //获取欲上传的文件路径
                        var path = document.selection.createRange().text;
                        document.selection.empty();
                        document.getElementById("pathX").value=path;  
                    }
         }
      
         </script>
         
    <style type="text/css">
        .style1
        {
            color: #FF0000;
        }
        .style2
        {
            height: 18px;
            width: 282px;
        }
        .style3
        {
            width: 282px;
        }
        .style4
        {
            height: 18px;
            width: 115px;
        }
        .style5
        {
            width: 115px;
        }
        .style6
        {
            height: 27px;
            width: 115px;
        }
        .style7
        {
            height: 27px;
            width: 282px;
        }
        .style8
        {
            color: #FF3300;
        }
        .style9
        {
            width: 115px;
            height: 82px;
        }
        .style10
        {
            width: 282px;
            height: 82px;
        }
    </style>
    </head>
<body onload="OnLoadtime()">

    <script>
WaitHelper.showWaitMessage();
    </script>

    <form id="form2" runat="server">
    <div class="appsection">
        <div class="apphead">
            <img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()"
                alt="" /><strong>导入制卡</strong></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" 
            style="width: 400px; height: 130px;">
            <tr>
                <th class="style6">
                    密码类型<label style="color: Red; height: 18px;">*</label>
                </th>
                <td class="style7">
                    &nbsp;
                    <input id="ZJ"  runat="server" type="checkbox" checked="checked"  onclick="rd()" />直接导入密码&nbsp;&nbsp; 
                    <input id="SJ" type="checkbox" runat="server"  onclick="rd1()" />随机生成密码</td>
            </tr>
            <tr>
                <th class="style4">
                    导入文件<label style="color: Red; height: 18px;">*</label>
                </th>
                <td class="style2">
        &nbsp;&nbsp;
        <input id="FileCell" style=" width:184px;" class="inputblue" onchange="MarkInput();" type="file" runat="server" /></td>
            </tr>
              <tr>
                <th class="style5">
                    卡期限&nbsp;
                </th>
                <td colspan="1" class="style3">
                  
                    &nbsp;&nbsp;
                <input id="validDate" runat="server" class="inputblue" maxlength="30" vtype="date"
                        onfocus="setday(this)" name="validDate" vdisp="有效日期" style="width: 104px" type="text"
                        readonly="readOnly" value="2020-12-31" />
                  
                   </td>
            </tr>
           <tr>
                <th class="style5">
                    表名（Sheet）&nbsp;
                </th>
                <td colspan="1" class="style3">
                  
                    &nbsp;&nbsp; <input id="name" style=" width:104px;" class="inputblue" type="text" runat="server" /><span class="style8"> 
                    *不填为Sheet1</span></td>
            </tr>
            
            
             <tr>
                <th class="style5">
                    卡类型&nbsp;
                </th>
                <td colspan="1" class="style3">
                  
                    &nbsp;&nbsp;
                    <select id="TypeID" runat="server" class="inputblue" name="TypeID" style="width: 96px">
                    </select>
                  
                   </td>
            </tr>
             <tr>
                <th class="style5">
                    是否直接激活&nbsp;
                </th>
                <td colspan="1" class="style3">
                  
                    &nbsp;&nbsp;&nbsp;<input id="Checkbox1" runat="server" type="checkbox" checked="CHECKED" onclick="ischool3()" />否
                    &nbsp;&nbsp;
                    <input id="Checkbox2" runat="server" type="checkbox" onclick="ischool4()" />是
                  
                   </td>
            </tr>
             <tr  id="siteID" style=" display:none">
                <th class="style5">
                    激活分店&nbsp;
                </th>
                <td colspan="1" class="style3">
                  
                    &nbsp;&nbsp;
                       <select id="Area_Code" runat="server" class="inputblue" name="Area_Code" onchange="onAreaSelectChange()"
                        style="width: 96px">
                    </select><select id="Site_Code" runat="server" class="inputblue" name="Site_Code"
                        style="width: 96px">
                    </select>
                   </td>
            </tr>
            <tr>
                <th class="style5">
                    下载&nbsp;
                </th>
                <td colspan="1" class="style3">
                  
                    &nbsp;&nbsp;
                    <asp:Label ID="lbDown" runat="server" ForeColor="Green"></asp:Label>
                  
                   </td>
            </tr>
            <tr>
                <th class="style9">
                    提示&nbsp;
                </th>
                <td colspan="1" class="style10">
                    &nbsp;&nbsp;<span class="style1">*必须为Excel文件格式“.xls”</span>&nbsp; 
                    <br />
&nbsp; <span class="style1">*Excel表中一行只允许有三列卡名</span><br />
&nbsp; <span class="style8">*请在选择文件时输入相应的表名，如图：</span>&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;<img src="../images/表名.jpg" style="width: 169px; height: 31px" />
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection">
        <div class="section_operators" style="width: 399px" align="center">
             <asp:Button ID="Button1" CssClass="btn003" runat="server" Text="开始制卡" 
                 onclick="Button1_Click" Height="18px"  OnClientClick="AppearProgress()"/>
            &nbsp;
            <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();"
                id="Button3" />
        </div>
    </div>
    <div>
          <input type="hidden" id="pathX" runat="server" />
        </div>
        
          <%--      遮罩层--%>
    <div id="DivCover" runat="server" style="display: none">
    </div>
    <div id="Waiting" runat="server" style="display: none;">
   <img src="../images/loadingbar.gif" width="100" height="7" alt="发送提示" /><br />
        <asp:Label ID="textid" runat="server" Text="正在执行，请稍后……"></asp:Label>  <br />
        <br />
        <a href="SentCard.aspx" target="_self">[返回列表]</a>
         </div>
    <%--      遮罩层结束--%>
    </form>

    <script>
WaitHelper.initWaitMessageForms("form2");  
    </script>

</body>  
    

</html>
