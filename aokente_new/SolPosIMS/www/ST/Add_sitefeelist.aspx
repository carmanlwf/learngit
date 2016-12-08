<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_sitefeelist.aspx.cs" Inherits="ST_Add_sitefeelist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>路段价格</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js"  ></script>
<script src="../jquery/js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="../js/timeinputtext.js" type="text/javascript"></script>
    
    <script language="javascript" type="text/javascript">

     
        //调用
        function ShowTsite() {
            var sitename = document.getElementById("sitename");
            if (sitename.value != "") {
                var getid = document.getElementById("showTable");
                getid.style.display = "block";
            }
            else {
                alert("请选择区域名称!");
            }
        }

        function hedeTsite(obj) {
            var getid = document.getElementById("Tsiet");
            var input = getid.getElementsByTagName("input");

            if (obj == "Confirm") {
                var pids = document.getElementById("pids");
                for (var i = 0; i < input.length; i++) {
                    if (input[i].checked == true) {
                        input[i].checked = true;
                        pids.value += input[i].id+",";
                    }
                }
            }
            
            var getid = document.getElementById("showTable");
            getid.style.display = "none";
        }
        
        $.ajaxSetup({
            async: false
        });
        function Ajax_areacode() {
            var areacode = document.getElementById("areacode").value;
           
         if (areacode != "") {
             $.ajax({
                 type: "POST",
                 url: "Add_sitefeelist.aspx/Aareacode",
                 contentType: "application/json; charset=utf-8",
                 data: "{areacode:'" + areacode + "'}",
                 dataType: "json",
                 success: function(result) {
                     var data = eval(result.d);
                     document.getElementById("sitename").options.length = 1;

                     for (var i = 0; i < data.length;i++ ) {
                         document.getElementById("sitename").options.add(new Option(data[i]["sitename"], data[i]["id"]));
                     }


                 }
             });
            }
       }

       function refleshList() {

           var site = document.getElementById("sitename");

           var snainput = document.getElementById("snainput");
           snainput.value = site.options[site.selectedIndex].text;
           
            $.ajax({
                type: "POST",
               //方法所在页面和方法名
               url: "Add_sitefeelist.aspx/refleshList",
               contentType: "application/json; charset=utf-8",
               data: "{site:'" + site.value + "'}",
               dataType: "json",
               success: function(result) {
                   var tid = document.getElementById("Tsiet");
                   tid.innerHTML = result.d;
               }
           });

       }

        
    function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);
    window.setTimeout('document.all("btnclose").click();parent.location.href="In_Price_Set.aspx";', 1 * 1000);
}
    </script>
    <script type="text/javascript">


        function istruef() {
            var startspan = document.getElementById("startspan");
            var startWorkTime = startspan.getElementsByTagName("input")[0].value;
            var startW = document.getElementById("startW");
            startW.value = startWorkTime;

            var endspan = document.getElementById("endspan");
            var endWorkTime = endspan.getElementsByTagName("input")[0].value;
            var endW = document.getElementById("endW");
            endW.value = endWorkTime;

            var istrue = document.getElementById("istrue");
            istrue.value = "";
		      var getid = document.getElementById("Tsiet");
              var input = getid.getElementsByTagName("input");
              var sitename = document.getElementById("sitename");

		      var mns = "";
		      var num = 0;
		      for (var i = 0; i < input.length; i++) {
		          if (input[i].checked == true) {
		              num = 1;
		          }
		      }
		      
		      if (sitename.value == "") {
		          mns = "请选择区域！";
		      }
		     else if (num==0)
		      {
		          mns = "请选择收费规格！";
		      }

		      if (mns != "") {
		          istrue.value = mns;
		          alert(mns);
		          return false;
		      }
		   }
    </script>
    <style type="text/css">
        #showTable{position:absolute; margin-left: 16px; width:360px;z-index:100;background-color:#C3D3F7; border:0;}
        .tb_none{ display:none;}
        .style1
        {
            width: 105px;
            height: 30px;
        }
        .style2
        {
            height: 30px;
        }
        .style3
        {
            width: 105px;
        }
    </style>
</head>
<body>


       <table id="showTable" class="tb_none" >
    <tbody>
    <tr style=" width:360px;">   
       <td height="33" width="0"></td>    
         <td height="33" style="background-image:url(../images/wbox.gif) !important;background: url(../images/wbox.gif);"><div style="float: left; font-weight: bold; color:#fff;"><span id="_Title_null">收费规格</span></div>        </td>     
          <td  height="33"  width="0"></td> 
  </tr> 
  
    <tr valign="top" style="width:360px;"> 
        <td width="3"></td>     
        <td align="center">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" bgcolor="#ffffff">       
        <tbody><tr id="_MessageRow_null" style="display:none">          
        <td valign="top" height="50">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" style="background:#eaece9 url(../images/dialog_bg.jpg) no-repeat scroll right top;" id="_MessageTable_null">                refleshList
        <tbody><tr>                
          <td width="50" height="50" align="center"></td>           
                 <td align="left" style="line-height: 16px;"><div id="_MessageTitle_null" style="font-weight:bold"></div>                    <div id="_Message_null"></div></td>                </tr>              </tbody></table></td>          </tr>          <tr>            <td valign="top" align="center"><div id="_Container_null" style="position: relative;left:-3px; width: 345px; height: 100px;">                <div style="position: absolute; height: 100%; width: 100%; display: none; background-color:#fff; opacity: 0.5;" id="_Covering_null"> </div><div id="Tsiet" ></div>	</div></td>          </tr>          <tr id="_ButtonRow_null" style="">            <td height="36"><div id="_DialogButtons_null" style="border-top: 1px solid #DADEE5; padding: 8px 20px; text-align: right; background-color:#f6f6f6;">                <input type="button" value="确 定" id="_ButtonOK_null" onclick="hedeTsite('Confirm')">                <input type="button"  value="取 消" onclick="hedeTsite('Cancel')" id="_ButtonCancel_null">              </div></td>          </tr>        </tbody></table>
        </td>    
        <td width="3" ></td>  
        </tr>  
        <tr>   
        <td width="3" height="13" ></td>    
        <td width="3" height="13" >
        <a onfocus="$id(&quot;_forTab_null&quot;).focus();" href="#;"></a>
        </td>   
     </tr> 
     </tbody></table> 

    <form id="form1" runat="server" method="post" onsubmit="istruef()">
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
    <div class="appsection">
        <div class="apphead">
            <img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()"
                alt="" /><strong>基本信息</strong></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px">
            <tr>
                <th class="style1">
                    <label style="color: Red; height: 18px;">
                        <span style="color: #1e3739;">编&nbsp; &nbsp;号</span><label style="color: Red; height: 18px;">*</label></label>
                </th>
                <td class="style2">
                    <input type="text"  class="inputblue" id="spid" style="width: 200px" runat="server"
                        maxlength="20" vdisp="编号" vmode="not null" />&nbsp;
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">
                    选择路段<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                <div style=" float:left;">
                     <select id="areacode" class="inputblue" style="width:90px" vdisp="所属区域" runat="server" onchange="Ajax_areacode()" />&nbsp;
                     <select id="sitename" name="sitename" class="inputblue" style=" margin-left:5px; width:90px" vdisp="所属路段" runat="server"  onchange="refleshList()" />
                 </div>
                 </td>
            </tr>
            <tr>
                 <th style="height: 18px; width: 105px;">
                  收费规格<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style=" height: 18px">
            <input type="button" id="Add" class="btn2"  style=" float:left; margin-left:20px; width:90px; border:1px solid #96C2F1; margin-top:0; float:left;" value="选择收费规格" onclick="ShowTsite()"  /> 
                </td>
            </tr>
          
            <tr>
                <th style="width: 105px; height: 18px">
                    开始收费时间<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <div id="startspan" style=" margin-left:20px;"></div>
                </td>
            </tr>
             <tr>
                <th style="width: 105px">
                   结束收费时间
                </th>
                <td colspan="1">
                  <div id="endspan" style="  margin-left:20px;"></div>
                  <%-- <input type="text" class="inputblue" id="endWorkTime" style="width: 200px" runat="server" maxlength="15" vdisp="结束收费时间"  onBlur="CheckTime('endWorkTime')" value="23:59" vmode="not null" vtype="number" name="linkphone" />--%>
                </td>
            </tr>


        </table>
        <input id="pids" type="hidden" value="" runat="server"  />
        <input id="istrue" type="hidden" value="" runat=server />
        <input id="startW" type="hidden" value="" runat="server" />
        <input id="endW" type="hidden" value=""   runat=server />
        <input id="snainput" type="hidden" value=""   runat=server />
    </div>
    <div class="appsection">
        <div class="section_operators" style="width: 400px" align="center">
          <%--  <input id="chflag" runat="server" type="checkbox" style="display: none" />--%>
            <input type="button" id="btnInsert"  runat="server" value="提交" class="xybtn" onserverclick="btnInsert_Click"/>
            <input type="button" id="btnUpdate" runat="server" value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
            <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" style="display:none;"
                id="Button2" />
        </div>
    </div>
    

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Site.Model.price_temp_sitefeelist" SelectMethod="GetObject" TypeName="Ims.Site.BLL.price_temp_sitefeelistBLL">
        <SelectParameters>
            <asp:Parameter Name="spid" Type="String"/>
        </SelectParameters>
    </asp:ObjectDataSource>
 
    </form>

    <script>
        var startsTime = "08:00";
        var endTime = "21:00";
        var starts = document.getElementById("startspan");
        var a = new TimeInputText(starts, startsTime, 200, 20, 12);
        a.setFormName("startWorkTime");

        var endspan = document.getElementById("endspan");
        var b = new TimeInputText(endspan, endTime, 200, 20, 12);
        b.setFormName("endWorkTime");
    
    </script>

</body>
</html>
