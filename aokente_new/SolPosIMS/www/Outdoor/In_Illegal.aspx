<%@ Page Language="C#" AutoEventWireup="true" CodeFile="In_Illegal.aspx.cs" Inherits="Outdoor_In_Illegal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>违章状态信息</title>
    <link rel="stylesheet" href="../css/table.css" />
   
    <script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
   
    <script language="javascript" type="text/javascript">

       
      
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
            window.setTimeout('document.all("btnclose").click();parent.location.href="tb_Illegal.aspx";', 1 * 1000);
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
                alt="" /><strong>基本信息</strong></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px">
            <tbody>
                                <tr>
                <th style="height: 18px; width: 105px;">
                    <label style="color: Red; height: 18px;">
                        <span style="color: #1e3739;">车牌号码</span><label style="color: Red; height: 18px;">*</label></label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" style="width:150px" id="igCarNumber"  runat="server" maxlength="20" name="pid" />&nbsp;
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">
                   车身照片<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                  <input type="text" class="inputblue" style="width:150px" id="igBodyworkImg"  runat="server" maxlength="20" name="pid" />
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">
                   车牌照片<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                  <input type="text" class="inputblue" style="width:150px" id="igPlateImg"  runat="server" maxlength="20" name="pid" />
                </td>
            </tr>
          <tr>
	        <th >取证地址<label style="color: Red; height: 18px;">*</label></th>
		    <td >
		         <input type="text" class="inputblue" style="float:left; width:150px; z-index:1;" id="igArea" runat="server"  vtype="float" maxlength="20" />
	         
	            <td>
	        </tr>
            
         <tr>
                <th style="height: 18px; width: 105px;">
                 拍照手持机号<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                <input type="text" class="inputblue" style="width:150px" id="igTerminalCard"  runat="server" maxlength="20" name="pid" />
                </td>
            </tr>
            <tr>
             <th style="height: 18px; width: 105px;">
                  交警名称<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                   <input type="text" class="inputblue" style="width:150px" id="igPoliceName"  runat="server" maxlength="20" name="pid" />
                </td>
            
        </tr>
       <%-- <tr>
		     <th >拍照时间<label style="color: Red; height: 18px;">*</label></th>
	            <td>
	                 <div class="inline layinput"  style="float:left; margin-left:20px; border:1px solid #B8E1F6; width:152px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss" runat="server" id="igCreateTime" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" /></div>
	          </td>
        </tr>--%>
        <tr>
             <th style="height: 18px; width: 105px;">
                  上传交警后台间隔<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
         
                   <input type="text" class="inputblue" style="width:150px" id="igUploadTime"  runat="server" maxlength="20" name="pid" />
                </td>
            
        </tr>
         <tr>
             <th style="height: 18px; width: 105px;">
                  交警后台内网IP<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                   <input type="text" class="inputblue" style="width:150px" id="igPoliceIP"  runat="server" maxlength="20" name="pid" />
                </td>
        </tr>
            </tbody>
        </table>
        <input type="hidden" value="" id="igID"  runat=server />
      
    </div>
    <div class="appsection">
        <div class="section_operators" style="width: 400px" align="center">
          
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