<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add_price_Set.aspx.cs" Inherits="ST_Add_price_Set" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>路段价格新增</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script language="javascript" type="text/javascript">

        function chargeByTimes() {
            var ChargeByTimes = document.getElementById("ChargeByTimes");
            var clickCharge = document.getElementById("clickCharge");
            if (ChargeByTimes.checked == true) {
                clickCharge.value = ChargeByTimes.checked;
            }

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
            window.setTimeout('document.all("btnclose").click();parent.location.href="Intemp_feetype.aspx";', 1 * 1000);
        }
    </script>
</head>
<body>

    <script>
        WaitHelper.showWaitMessage();
    </script>


    <form id="form1" runat="server" onsubmit="chargeByTimes()">
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
    <div class="appsection">
        <div class="apphead">
            <img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()"
                alt="" /><strong>基本信息</strong></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px">
            <tr>
                <th style="height: 18px; width: 105px;">
                    <label style="color: Red; height: 18px;">
                        <span style="color: #1e3739;">编&nbsp; &nbsp;号</span><label style="color: Red; height: 18px;">*</label></label>
                </th>
                <td style="height: 18px">
                    <input type="text"  class="inputblue" id="Pid" style="width: 240px" runat="server" vdisp="编号"  />&nbsp;
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">
                    名&nbsp; &nbsp;称<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" id="Pname" style="width: 240px" runat="server"  vdisp="名称"/>
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">
                   车&nbsp; &nbsp;型<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                 <select id="Cartype" class="inputblue" style="width:240px" vdisp="车型" runat="server"  />
                </td>
            </tr>
            <tr>
                <th style="width: 105px; height: 18px">
                  起 步 价<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" id="minPayment" style="width: 240px" runat="server" vdisp="起步价" />
                </td>
            </tr>
              <tr>
                <th style="width: 105px; height: 18px">
                 起步时长/分<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" id="FirstChargingTimeSeg" style="width: 240px" runat="server" vdisp="起步时间/分" />
                </td>
            </tr>
             <tr>
                <th style="width: 105px">
                 间隔时长/分<label style="color: Red; height: 18px;">*</label>
                </th>
                <td colspan="1">
                   <input type="text" class="inputblue" id="NormalChargingTimeSeg" style="width: 240px" runat="server" vdisp="超出时间/分"  />
                </td>
            </tr>
            <tr>
                <th style="width: 105px; height: 18px">
                 超出缴费/元<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" id="normalChargingPrice" style="width: 240px" runat="server" vdisp="超出缴费/元"/>
                </td>
            </tr>
            <tr>
                <th style="width: 105px">
                  最高收费/元<label style="color: Red; height: 18px;">*</label>
                </th>
                <td colspan="1">
                   <input type="text" class="inputblue" id="maxPayment" style="width: 240px" runat="server"  vdisp="最高收费/元"  />
                </td>
            </tr>
            <tr>
                <th style="width: 105px">
                  免费时段/分<label style="color: Red; height: 18px;">*</label>
                </th>
                <td colspan="1">
                   <input type="text" class="inputblue" id="FreeTimeSeg" style="width: 240px" runat="server" vdisp="免费时段/分"  />
                </td>
            </tr>
     
            
            <tr>
                <th style="width: 105px">
                   备&nbsp;&nbsp;注
                </th>
                <td colspan="1">
                    <textarea id="Memo" runat="server" class="inputblue"  name="memo" style="width: 240px; height: 50px" vdisp="备注" ></textarea>
                </td>
            </tr>
            
            <tr>
                <th style="width: 105px">
                   是否按次收费
                </th>
                <td colspan="1">
                   &nbsp;<input type="checkbox"  checked="checked" id="ChargeByTimes"  runat=server />
                </td>
            </tr>
        </table>
        <input type="hidden" value="" id="istrue"  runat=server />
        <input type="hidden" value="false" id="clickCharge"  runat=server />
    </div>
    <div class="appsection">
        <div class="section_operators" style="width: 400px" align="center">
          <%--  <input id="chflag" runat="server" type="checkbox" style="display: none" />--%>
            <input type="button" id="btnInsert" runat="server" value="提交" class="xybtn" onserverclick="btnInsert_Click" />
            <input type="button" id="btnUpdate"  runat="server" value="提交" class="xybtn" onserverclick="btnUpdate_Click" />
            <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" style="display:none;"
                id="Button2" />
        </div>
    </div>
    

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Site.Model.price_temp_feetype"
        InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Site.BLL.InPriceBLL" >
        <SelectParameters>
            <asp:Parameter Name="Pid" Type="String"/>
        </SelectParameters>
    </asp:ObjectDataSource>
 
    </form>

    <script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
