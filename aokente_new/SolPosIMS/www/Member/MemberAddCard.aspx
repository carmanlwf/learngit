<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="MemberAddCard.aspx.cs" Inherits="Member_MemberAddCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
     <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>会员发卡</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/json.js"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
	<script type="text/javascript">
	function onAreaSelectChange()
	{
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.Site_Code.options.length = 0;
		BindNormalTableToListControl('Site_Code', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
	}
	</script>
	<script type="text/javascript">
	function GetIdelCard_Random(selectId)
    {
        var oInput = document.getElementById(selectId);
        if(oInput == null) return false;
        
        var result = doAjaxCallTools("GetIdelCard_Random");
        
        if(result == null || result == "")
        {oInput.value ='';}
        else{oInput.value = result;}
        document.all('physicalno').value = oInput.value
    }
	</script>
</head>
<body onload="onAreaSelectChange()">
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="form1" runat="server">
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 450px">
            <tr>
                <th style="height: 2px; width: 80px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员卡号<label style="color: red; height: 18px">*</label>
                        </span></label></th>
                <td style="height: 2px; width: 130px;"><input id="Card" runat="server" class="inputblue" maxlength="20" name="Card" style="width: 100px" type="text" vdisp="会员卡号"  onchange="javascript:document.all('physicalno').value = this.value"/>
                    <img src="../images/catchcard1.jpg" onclick="GetIdelCard_Random('Card');" style="cursor:hand; width: 15px; height: 15px;" runat="server" alt="点击随机获取空闲卡号"/></td>
                <th style="width: 80px; height: 2px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">会员编号&nbsp; </span>
                    </label>
                </th>
                <td style="height: 2px; width: 120px;">
                    <asp:Label ID="Labnum" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                    <th style="width: 80px; height: 18px">
                        <span style="color: #1e3739">物理卡号</span><label style="color: red; height: 18px">*</label>
                </th>
                <td style="width: 130px; height: 18px"><input id="physicalno" runat="server" class="inputblue" maxlength="20" name="physicalno" style="width: 100px" type="text" vdisp="会员卡号" onchange="javascript:document.all('physicalno').value = this.value" readonly="readOnly"/></td>
                <th style="width: 80px; height: 18px">
                    会员名称&nbsp;
                </th>
                <td style="width: 120px; height: 18px">
                    <asp:Label ID="LabName" runat="server" Text="Label"></asp:Label></td>
            </tr>
               <tr>
                    <th style="width: 80px; height: 18px">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739"></span><span style="color: #333333"><span style="background-color: #8cc2dd">
                    有效日期</span></span>*</label>
                </th>
                <td style="width: 130px; height: 18px">
                    <input id="validDate" runat="server" class="inputblue" name="validDate" onfocus="setday(this)"
                        style="width: 100px" type="text" vdisp="有效日期" vtype="date" maxlength="25" value="2030-12-31" /></td>
                <th style="width: 80px; height: 18px">
                    会员等级&nbsp;
                </th>
                <td style="width: 120px; height: 18px">
                    <asp:Label ID="LabRead" runat="server" Text="Label"></asp:Label></td>
            </tr>
                  <tr>
                <th style="width: 80px; height: 18px">
                    <span style="color: #1e3739">所在区域&nbsp; </span></th>
                <td style="width: 130px; height: 18px">
                    <select id="Area_Code" runat="server" name="Area_Code" style="width: 100px" onchange="onAreaSelectChange()" class="inputblue">
                    </select>
                </td>
                <th style="width: 80px; height: 18px">
                    所属门店&nbsp;</th>
                <td style="width: 120px; height: 18px">
                    <select id="Site_Code" name="Site_Code" style="width: 100px" runat="server" class="inputblue">
                    </select>
                </td>
            </tr>
            <tr>
                <th style="width: 80px; height: 18px">
                    提示&nbsp;</th>
                <td colspan="3" style="height: 18px">
                    <span style="color: red">
                        <br />
                        会员卡号是一组有规则的由商家定义的数字序列，因具有唯一性，一旦系统中已包含待添加的卡号，则不能进行发卡操作。<br />
                    </span>
                </td>
            </tr>
        </table>
    
    </div>
    <div align="center" class="section_operators" style="width: 450px">
        <input id="btSend" runat="server" class="btn001" name="btSend" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnUpdate_Click" style="height: 19px" type="button" value="发 卡" />
        <input id="BtnCancel" runat="server" class="btn001" name="BtnCancel" onclick="JavaScript:window.close()"
             style="height: 19px" type="button" value="关 闭" />&nbsp;</div>
    </form>
    <script>
WaitHelper.initWaitMessageForms("form1");  
</script>  
</body>
</html>
