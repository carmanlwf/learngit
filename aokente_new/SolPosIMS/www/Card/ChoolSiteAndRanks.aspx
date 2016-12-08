<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChoolSiteAndRanks.aspx.cs" Inherits="Card_ChoolSiteAndRanks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>选择分店与会员等级</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/json.js"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
    <script type ="text/javascript" >
    function onAreaSelectChange()
	{
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.Site_Code.options.length = 0;
		BindNormalTableToListControl('Site_Code', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
	}
	
	function GetSiteIDvalues()
	{
     var obj= document.getElementById("Site_Code");
     var objText=obj.value;
     document.getElementById("siteid2").value=objText;
	}

  function GetRanksvalues()
  {
     var obj= document.getElementById("UserRank");
     var objText=obj.value;
     document.getElementById("remar2").value=objText;
  }
  function CloseWind()
  {
   window.opener.document.getElementById("siteID1").value= document.getElementById("siteid2").value; 
   window.opener.document.getElementById("RanksID1").value= document.getElementById("remar2").value; 
    window.close();
}

    </script>
</head>
<body  onload="onAreaSelectChange();GetRanksvalues();GetSiteIDvalues()">
<script>
WaitHelper.showWaitMessage();
</script>
    <form id="Form1" runat="server">
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 450px">
            <tr>
                <th colspan="4" style="height: 18px; text-align: center">
                    <strong>请选择分店与会员等级</strong></th>
            </tr>
            <tr id="siteID">
                <th style="width: 125px; height: 18px">
                    激活分店</th>
                <td colspan="3" style="height: 18px">
                    <select id="Area_Code" runat="server" class="inputblue" name="Area_Code" onchange="onAreaSelectChange();GetSiteIDvalues()"
                        style="width: 96px">
                    </select><select id="Site_Code" runat="server" class="inputblue" name="Site_Code" style="width: 96px" onchange="GetSiteIDvalues()">
                    </select>
                </td>
            </tr>
            <tr id ="rankber">
                <th style="width: 125px; height: 18px">
                    会员等级</th>
                <td colspan="3" style="height: 18px">
                    <select id="UserRank" runat="server" class="inputblue" name="UserRank" style="width: 96px" onchange="GetRanksvalues()">
                    </select>
                </td>
            </tr>
        </table>
        <span style="color: #1e3739"></span>
    
    </div>
        <div align="center" class="section_operators" style="width: 450px">
            &nbsp;<input id="bt_Batch" runat="server" class="btn003" name="btnCon" 
                type="button" value="确定" onclick="CloseWind()"/>
            <input id="BtnCancel" runat="server" class="btn003" name="BtnCancel" onclick="JavaScript:window.close()"
                type="button" value="关 闭" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</div>
</form>
<script>
WaitHelper.initWaitMessageForms("Form1"); 
</script>

    <input id="siteid2" runat="server" class="inputblue" maxlength="25" name="siteid2" style="width: 100px; display :none"
        type="text" /><input id="remar2" runat="server" class="inputblue" maxlength="25" name="remar2" style="width: 100px; display :none"
        type="text"  />
</body>
</html>
