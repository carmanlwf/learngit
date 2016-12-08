<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardActive.aspx.cs" Inherits="Card_CardActive" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>卡片激活</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
 <script type="text/javascript" src="../js/app.xmlhttp.js"></script>
  <script type="text/javascript" src="../js/json.js"></script>
    <script type="text/javascript">
    function CloseWin(msg)
    {
   // alert('fdsa')
        alert(msg);
        window.setTimeout('document.all("btnclose").click();parent.location.href="CardBatchRegistration.aspx";',1*1000);
        //parent.wBox.close();
        //document.all("btnclose").click()
    }
    </script>
    <script type="text/javascript">
	function onAreaSelectChange()
	{
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.Site_Code.options.length = 0;
		BindNormalTableToListControl('Site_Code', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
	}
	</script>
    <style type="text/css">
        .style3
        {
            height: 18px;
            width: 136px;
        }
        .style4
        {
            width: 136px;
        }
        .style5
        {
            height: 18px;
            width: 141px;
        }
        .style6
        {
            width: 141px;
        }
    </style>
</head>
<body onload="onAreaSelectChange()">
<script>
WaitHelper.showWaitMessage();
</script>

    <form id="form1" runat="server">
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 450px">
            <tr>
                <th class="style5">所属区域&nbsp;
                </th>
                <td class="style3">
                    <select id="Area_Code" runat="server" name="Area_Code" onchange="onAreaSelectChange()"
                        style="width: 100px" class="inputblue" enableviewstate="true">
                    </select>
                </td>
                <th style="width: 160px; height: 18px">
                    所属门店&nbsp;
                </th>
                <td style="width: 120px; height: 18px">
                    <select id="Site_Code" runat="server" name="Site_Code" style="width: 100px" enableviewstate="true" class="inputblue">
                    </select>
                </td>
            </tr>
            <tr>
                <th class="style5">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员卡号<label style="color: red; height: 18px">*</label> </span></label></th>
                <td class="style3">
                    <input id="Card" runat="server" class="inputblue" maxlength="20" name="Card"
                        style="width: 100px" type="text" vdisp="会员卡号" vmode="not null" />&nbsp;</td>
                <th style="width: 160px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员姓名<label style="color: red; height: 18px">*</label> </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <input id="RealName" runat="server" class="inputblue" maxlength="10" name="RealName"
                        style="width: 100px" type="text" vdisp="会员姓名" vmode="not null" /></td>
            </tr>
            <tr>
                <th class="style6">
                    会员性别&nbsp;
                </th>
                <td class="style4">
                    <select id="gender" runat="server" class="inputblue" name="gender" style="width: 100px">
                        <option selected="selected" value="1">男</option>
                        <option value="0">女</option>
                    </select></td>
                <th style="width: 160px;">
                    手机号码&nbsp;
                </th>
                <td style="width: 120px;">
                    <input id="CellPhone" runat="server" class="inputblue" maxlength="11" name="CellPhone"
                        style="width: 100px" type="text" vdisp="手机"  vtype="mobiletel" /></td>
            </tr>
            <tr>
                <th class="style5">
                    证件类型&nbsp;
                </th>
                <td class="style3">
                    <select id="IdType" runat="server" class="inputblue" name="IdType" style="width: 100px">
                        <option selected="selected" value="0">身份证</option>
                        <option value="1">军官证</option>
                        <option value="2">学生证</option>
                        <option value="3">护照</option>
                        <option value="4">其它</option>
                    </select>
                </td>
                <th style="width: 160px; height: 18px">
                    证件号码&nbsp;
                </th>
                <td style="width: 120px; height: 18px">
                    <input id="IdNo" runat="server" class="inputblue" maxlength="25" name="IdNo" style="width: 100px"
                        type="text" vdisp="证件号码"  vtype="idcard" /></td>
            </tr>
            <tr>
                <th class="style5">
                    地址 </th>
                <td style="height: 18px" colspan="3">
                    <input id="Address" runat="server" 
                        class="inputblue" maxlength="50" name="Address" style="width: 250px"
                        type="text" vdisp="住址"  /></td>
            </tr>
            <tr>
                <th class="style5">
                    提示&nbsp;</th>
                <td colspan="3" style="height: 18px">
                    <span>
                        <br />
                        </span><span style="color: red">激活卡操作是针对批量生成的不记名卡执行启用的操作,仅限于在平台注册过的未激活卡
                        </span><br />
                </td>
            </tr>
        </table>
    
    </div>
    <div align="center" class="section_operators" style="width: 450px">
        <input id="btnJieGua" runat="server" class="xybtn" name="btnJieGua" 
            onserverclick="btnUpdate_Click" type="button" 
            value="激 活" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:parent.close()"
             style="height: 19px; display:none;" type="button" value="关 闭" />&nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>


