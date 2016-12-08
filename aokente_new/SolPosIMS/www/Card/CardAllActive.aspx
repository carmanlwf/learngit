<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardAllActive.aspx.cs" Inherits="Card_CardAllActive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
        <title>批量卡片激活</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/json.js"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
    <script type="text/javascript">
    function CloseWin(msg)
    {
    alert(msg);
        close();
   
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
</head>
<body onload="onAreaSelectChange()">
<script>
WaitHelper.showWaitMessage();
</script>
<body>
    <form id="form1" runat="server">
    <div class="appsection">
                 <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 450px">
            <tr>
                <th style="width: 80px; height: 18px">
                    所属区域&nbsp;
                </th>
                <td style="width: 100px; height: 18px">
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
                <th style="width: 80px;">
                    会员性别&nbsp;
                </th>
                <td style="width: 100px;">
                    <select id="gender" runat="server" class="inputblue" name="gender" style="width: 100px">
                        <option selected="selected" value="1">男</option>
                        <option value="0">女</option>
                    </select></td>
                <th style="width: 160px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员姓名&nbsp; </span>
                    </label>
                </th>
                <td style="height: 18px; width: 120px;">
                    <input id="RealName" runat="server" class="inputblue" maxlength="10" name="RealName"
                        style="width: 100px" type="text" vdisp="会员姓名" vmode="not null" value="无名单" readonly="readonly" /></td>
            </tr>
            <tr>
                  <th style="width: 80px; height: 18px">
                    证件类型&nbsp;
                </th>
                <td style="width: 100px; height: 18px">
                    <select id="IdType" runat="server" class="inputblue" name="IdType" style="width: 100px">
                        <option selected="selected" value="0">身份证</option>
                        <option value="1">军官证</option>
                        <option value="2">学生证</option>
                        <option value="3">护照</option>
                        <option value="4">其它</option>
                    </select>
                </td>
                <th style="width: 160px;">
                    等级&nbsp;
                </th>
                <td style="width: 120px;">
                    <select id="UserRank" runat="server" class="inputgreen" name="MemberRank" style="width: 100px">
                    </select></td>
            </tr>
            <tr>
                <th style="width: 80px; height: 18px">
                    提示&nbsp;</th>
                <td colspan="3" style="height: 18px">
                    <span>
                        <br />
                        </span><span style="color: red">激活卡操作是针对批量生成的不记名卡执行启用的操作，会员可通过移动终端设备或在线进行。</span><br />
                </td>
            </tr>
        </table>        
    </div>
     <div align="center" class="section_operators" style="width: 450px">
        <input id="btnJieGua" runat="server" class="btn001" name="btnJieGua" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="激 活" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
             style="height: 19px" type="button" value="关 闭" />&nbsp;</div>
    </form>
    <script>
WaitHelper.initWaitMessageForms("form1");  
</script>
</body>
</html>
