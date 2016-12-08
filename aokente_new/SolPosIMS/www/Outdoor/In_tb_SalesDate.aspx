<%@ Page Language="C#" AutoEventWireup="true" CodeFile="In_tb_SalesDate.aspx.cs" Inherits="In_tb_SalesDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>路外停车信息</title>
    <link rel="stylesheet" href="../css/table.css" />
    <script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script language="javascript" type="text/javascript">

        function doInfornew() {

            window.parent.Map();
        }
        function returnMap(Longitude, latitude) {
            debugger

            $("#rdLongitude").val("经度" + Longitude);
            $("#rdlatitude").val("纬度" + latitude);
        }
      
        var getid = document.getElementById("showTable");
        //调用
        function ShowTsite() {
            //width:335px;background-color:#C3D3F7;
            getid.style.cssText = "position:absolute;z-index:100;width:320px;background-color:#C3D3F7;display:block;border:0px;";
        }

        function hedeTsite(obj) {
            if (obj == "Confirm") {
                getid.style.cssText = "display:none;";
            }
            else {
                var getid = document.getElementById("Tsiet");
                getid.c
            }
        }

        function Check(msg) {
            if (msg != "")
                alert(msg);
        }

        function CloseWin(msg) {
            if (msg != "")
                alert(msg);
            window.setTimeout('document.all("btnclose").click();parent.location.href="tb_SalesDate.aspx";', 1 * 1000);
        }
    </script>
</head>
<body>

    <script>
        WaitHelper.showWaitMessage();
    </script>


    <form id="form1" runat="server" >
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
    <div class="appsection">
        <div class="apphead">
            <img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()"
                alt="" /><strong>路外停车信息</strong></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px">
            <tbody>
                                <tr>
                <th style="height: 18px; width: 105px;">
                    <label style="color: Red; height: 18px;">
                        <span style="color: #1e3739;">停车场名称</span><label style="color: Red; height: 18px;">*</label></label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" style="width:150px" id="rdStopCName"  runat="server" maxlength="20" name="pid" />&nbsp;
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">
                   停车场服务器IP<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                  <input type="text" class="inputblue" style="width:150px" id="rdParkServerIP"  runat="server" maxlength="20" name="pid" />
                </td>
            </tr>
          <tr>
	        <th >经度</th>
		    <td >
		         <input type="text" class="inputblue" style="float:left; width:150px; z-index:1;" id="rdLongitude" runat="server"  vdisp="经度" vtype="float" maxlength="20" />
	          <div onclick="doInfornew()" style="float:left; margin-top:2px;width:0px; margin-left:-20px; z-index:500;"><b style="float:left; cursor:pointer; background-size:cover;  background:url(../images/us_mk_icon.png) no-repeat 39% 49%; width:20px; height:20px;" ></b> </div>
	            <td>
	        </tr>
            <tr>
		     <th >纬度 </th>
	            <td>
	                  <input type="text" class="inputblue" style="float:left;width:150px; z-index:1;" id="rdlatitude"  runat="server" vdisp="纬度" vtype="float" maxlength="20" />
	           <div onclick="doInfornew()" style="float:left; margin-top:2px;width:0px; margin-left:-20px; z-index:500;"><b style="float:left; cursor:pointer; background-size:cover;  background:url(../images/us_mk_icon.png) no-repeat 39% 49%; width:20px; height:20px;" ></b> </div>
        </tr>
         <tr>
                <th style="height: 18px; width: 105px;">
                  车位信息编码<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                <input type="text" class="inputblue" style="width:150px" id="rdFier"  runat="server" maxlength="20" name="pid" />
                </td>
            </tr>
        <tr>
             <th style="height: 18px; width: 105px;">
                  车位信息发布<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                     <textarea id="rdDescription" runat="server" class="inputblue"  name="memo" style="width: 150px; height: 50px" vdisp="车位信息发布" ></textarea>
                </td>
            
        </tr>
            </tbody>
        </table>
        <input type="hidden" value="" id="rdID"  runat=server />
      
    </div>
    <div class="appsection">
        <div class="section_operators" style="width: 400px" align="center">
          <%--  <input id="chflag" runat="server" type="checkbox" style="display: none" />--%>
            <input type="button" id="btnInsert" runat="server" value="提交" class="xybtn" onserverclick="btnInsert_Click" />
            <input type="button" id="btnUpdate"  runat="server" value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
            <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" style="display:none;" id="Button2" />
        </div>
    </div>
    

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Job.Model.RoadDate"
        InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Job.BLL.RoadDateBLL" >
        <SelectParameters>
            <asp:Parameter Name="rdID" Type="String"/>
        </SelectParameters>
    </asp:ObjectDataSource>
 
    </form>

    <script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
