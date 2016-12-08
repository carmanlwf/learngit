<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUserWithAuthority.aspx.cs"
    Inherits="Admin_AddUserWithAuthority" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加带权限的系统用户</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script src="../js/app.date.js" type="text/javascript" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script language="javascript" type="text/javascript">
    function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);
        window.setTimeout('document.all("btnclose").click();parent.location.href="UserListByAuthority.aspx";',1*1000);
    }
    </script>
    <script type="text/javascript">

        function onSelectedDateTime(obj, datetime) {
            if (obj.name == "birthday") {
                GetAge(obj);
            }
        }
        function GetAge(obj) {
            var e = document.getElementById("birthday");
            var a = document.getElementById("age");
            var mydate = new Date();
            var year = mydate.getFullYear();
            var month = mydate.getMonth() + 1;
            var day = mydate.getDate();
            var pyear = parseInt(e.value.substring(0, 4));
            var pmonth = parseInt(e.value.substring(5, 7));
            var pday = parseInt(e.value.substring(8, 10));
            var realage = 0;
            realage = year - pyear;
            if ((month - pmonth) < 0) {
                realage = realage - 1;
            }
            if ((month == pmonth) && (day < pday)) {
                realage = realage - 1;
            }
            a.value = realage;
            return;
        }

        //对总店管理
        function RadioButtonList2Changed() {
            var radListCheckedValue = "";
            var radListItems = document.all("RadioButtonList1");
            var radListItesCount = radListItems.getElementsByTagName("INPUT").length;
            for (var i = 0; i < radListItesCount; i++) 
            {
                var ss = "RadioButtonList1_" + i;
                var aa = document.getElementById(ss);
                if (aa != 'undefined' && aa != null && aa != '')
                 {
                     if (aa.checked) 
                    {
                        //alert(ss + "-" + aa.value);
                        radListCheckedValue = aa.value;
                        break;
                    }
                }
            }
            //alert(radListCheckedValue);
            if (radListCheckedValue == "admin") {
              //  siteidsiteid.style.display = "none";
              //  trGroup.style.display = "none";
            }
            else if (radListCheckedValue == "seller") {
               // siteidsiteid.style.display = "none";
              //trGroup.style.display = "";
            }
            else if (radListCheckedValue == "agent") {
            document.getElementById('areaTr').style.display = "";
            }
            else {
              //  trGroup.style.display = "none";
              //  siteidsiteid.style.display = "";
                document.getElementById('areaTr').style.display = "none";
                document.getElementById('areaid').children[0].selected = true;
            }
            //      ||radListCheckedValue=="seller"
        }

        function GroupManger() {
            openBrWindow('../Member/GroupList.aspx', 'NewProductInfo', '370', '350');
        }

        function valiform() {
            var rolelist = document.getElementsByName("RadioButtonList1");
            var selectVal = "";
            for (var i = 0; i < rolelist.length; i++) {
                if (rolelist[i].checked == true) {
                    selectVal= rolelist[i].value;
                }
            }
            if (selectVal === "agent") {
                if (!document.getElementById('areaid').value) {  //如果权限选择的是商户 且没有选择区域则提示
                    alert("请选择区域");
                    return false
                }
            }
            return true;
        }
    </script>

</head>
<body onload="RadioButtonList2Changed()">

    <script>
        WaitHelper.showWaitMessage();
    </script>

    <form id="Form1" runat="server">
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
    <div class="appsection">
        <div class="apphead">
            <img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()"
                alt="" /><strong>基本信息</strong></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 416px;
            height: 81px;" id="TABLE1" runat="server">
            <tr>
                <th style="height: 18px; width: 75px;">
                    登录帐号<label style="color: red; height: 18px">*</label>
                </th>
                <td width="205" style="height: 18px">
                    <input id="empid" runat="server" class="inputblue" extendname="7位数字" maxlength="7"
                        name="empid"  style="width: 280px" type="text"
                        vdisp="员工工号" voperate="custom" />&nbsp;
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 75px;">
                    员工编号<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px" width="205">
                    <input type="text" class="inputblue" id="code" style="width: 280px;" runat="server"
                        vdisp="员工编号" maxlength="25" vtype="number" vmode="not null" name="code" />
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 75px;">
                    姓名<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px" width="205">
                    <input type="text" class="inputblue" id="pname" style="width: 280px" runat="server"
                        maxlength="10" vdisp="姓名" vmode="not null" name="pname" />
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 75px;">
                    性别<span style="font-size: 12px; color: red">&nbsp;</span>
                </th>
                <td style="height: 18px" width="205">
                    <select id="gender" runat="server" class="inputblue" name="gender" style="width: 280px">
                        <option selected="selected" value="1">男</option>
                        <option value="0">女</option>
                    </select>
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 75px;">
                    登录密码<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px" width="205">
                    <input id="pwd" runat="server" class="inputblue" maxlength="15" name="pwd" vmode="not null"
                        style="width: 280px" type="password" />
                </td>
            </tr>
            <tr >
                <th style="width: 75px; height: 18px">
                    权限设置
                </th>
                <td style="height: 18px" width="205">
                    <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" onclick="RadioButtonList2Changed()" style="margin-left:20px;"
                        RepeatDirection="Horizontal" RepeatLayout="Flow" Width="201px" 
                        Height="16px">
                        <asp:ListItem Value="admin" Selected="True">系统管理员</asp:ListItem>
                        <asp:ListItem Value="small" Selected="True">普通员</asp:ListItem>
                    </asp:RadioButtonList>--%>
                    <select id="roleid" class="inputblue" style="width: 280px" vdisp="角色" runat="server" name="roleid" >
	                </select>
                </td>
            </tr>
            <tr id="areaTr" style="display:none;">
                <th style="width: 75px; height: 18px">
                    区域选择
                </th>
                <td style="height: 18px" width="205">
                    <select id="areaid" name="areaid"  style="margin-left:20px;" visible="False">
                    <option value="">请选择</option>
                    <%
                       var areaTB =  ZsdDotNetLibrary.Data.DataExecSqlHelper.ExecuteQuerySql("select * from tb_Area  order by areacode asc");
                       for (var i = 0; i < areaTB.Rows.Count;i++ )
                       {
                           Response.Write("<option value ='" + areaTB.Rows[i]["areacode"] + "'>" + areaTB.Rows[i]["areaname"] + "</option>");
                       }
                    %>
                    </select>
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 75px;">
                    入职时间&nbsp;
                </th>
                <td style="height: 18px" width="205">
                    <input id="entertime" type="text" class="inputblue" onfocus="setday(this)" style="width: 280px"
                        runat="server" vtype="date" maxlength="20" name="entertime" />
                </td>
            </tr>
            <tr style="font-size: 12px">
                <th style="width: 75px">
                    邮箱地址&nbsp;
                </th>
                <td>
                    <input id="email" type="text" class="inputblue" style="width: 280px" runat="server"
                        vtype="email" maxlength="50" />
                </td>
            </tr>
            <tr>
                <th style="width: 75px">
                    备注&nbsp;
                </th>
                <td colspan="1">
                    <input id="memo" runat="server" class="inputblue" maxlength="200" name="memo" style="width: 280px;
                        height: 50px" type="text" />
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection">
        <div class="section_operators" style="width: 400px" align="center">
            <input id="chflag" runat="server" name="chflag" type="checkbox" checked="CHECKED"
                style="display: none" />
            <input type="button" id="btnInsert" onclick="if(!valiform()) return false; if(!doAllMessageBoxValidate(Form1)) return false;"
                runat="server" value="提交" class="xybtn" onserverclick="btnInsert_Click" />&nbsp;
            <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" style="display:none;"
                id="Button2" />
        </div>
    </div>
    </form>

    <script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
