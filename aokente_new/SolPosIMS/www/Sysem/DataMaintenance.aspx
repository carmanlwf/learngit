<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataMaintenance.aspx.cs" Inherits="Sysem_DataMaintenance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统维护</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
<script type="text/javascript" src="../js/app.edit.js"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/json.js"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
	<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>
<style type="text/css">
.red {
	color:red;
}
.appsection tbody td input {
	width:150px;
}
    .style1
    {
        height: 18px;
    }
</style>
    <script type="text/javascript">
   	function turnaddtime1()
	{
	 var time1=document.getElementById('operate_date_begin1').value;
	 document.getElementById('operate_date_begin').value=time1.replace(/-/g,"/");
	}
		function turnaddtime2()
	{
	 var time1=document.getElementById('operate_date_end1').value;
	 document.getElementById('operate_date_end').value=time1.replace(/-/g,"/");
	}

//------------------------------------
 function deleteTransaction1()
 {
      if(document.getElementById("Transaction1").checked)
      {
       document.getElementById("Transaction2").checked=false;
      }
      else
      {
       document.getElementById("Transaction2").checked=true;
      }
 }
  function deleteTransaction2()
  {
      if(document.getElementById("Transaction2").checked)
      {
       document.getElementById("Transaction1").checked=false;
      }
      else
      {
       document.getElementById("Transaction1").checked=true;
      }
 }
//------------------------------------

function deleteLog1()
{
       if(document.getElementById("systemLog1").checked)
       {
       document.getElementById("systemLog2").checked=false;
       }
      else
      {
       document.getElementById("systemLog2").checked=true;
      }
}
 
 function deleteLog2()
{
       if(document.getElementById("systemLog2").checked)
      {
       document.getElementById("systemLog1").checked=false;
      }
      else
      {
       document.getElementById("systemLog1").checked=true;
      }
}
//------------------------------------activet1

function deleteactivet1()
{
        if(document.getElementById("activet1").checked)
      {
       document.getElementById("activet2").checked=false;
      }
      else
      {
       document.getElementById("activet2").checked=true;
      }
}

function deleteactivet2()
{
        if(document.getElementById("activet2").checked)
      {
       document.getElementById("activet1").checked=false;
      }
      else
      {
       document.getElementById("activet1").checked=true;
      }
}

//-------------------------------
function deleteTransLog1()
{
        if(document.getElementById("TransLog1").checked)
      {
       document.getElementById("TransLog2").checked=false;
      }
      else
      {
       document.getElementById("TransLog2").checked=true;
      }
}

function deleteTransLog2()
{
      if(document.getElementById("TransLog2").checked)
      {
       document.getElementById("TransLog1").checked=false;
      }
      else
      {
       document.getElementById("TransLog1").checked=true;
      }
}
//----------------------------------
function deletecardNoAvtive1()
{
      if(document.getElementById("cardNoAvtive1").checked)
      {
       document.getElementById("cardNoAvtive2").checked=false;
      }
      else
      {
       document.getElementById("cardNoAvtive2").checked=true;
      }
}
function check4()
{
      if(document.getElementById("Checkbox4").checked)
      {
       document.getElementById("Checkbox3").checked=false;
      }
      else
      {
       document.getElementById("Checkbox3").checked=true;
      }
}
function check3()
{
      if(document.getElementById("Checkbox3").checked)
      {
       document.getElementById("Checkbox4").checked=false;
      }
      else
      {
       document.getElementById("Checkbox4").checked=true;
      }
}

function deletecardNoAvtive2()
{
      if(document.getElementById("cardNoAvtive2").checked)
      {
       document.getElementById("cardNoAvtive1").checked=false;
      }
      else
      {
       document.getElementById("cardNoAvtive1").checked=true;
      }
}
//----------------------------- cardYesAvtive1
function deletecardYesAvtive1()
{
       if(document.getElementById("cardYesAvtive1").checked)
      {
       document.getElementById("cardYesAvtive2").checked=false;
      }
      else
      {
       document.getElementById("cardYesAvtive2").checked=true;
      }
}

function deletecardYesAvtive2()
{
       if(document.getElementById("cardYesAvtive2").checked)
      {
       document.getElementById("cardYesAvtive1").checked=false;
      }
      else
      {
       document.getElementById("cardYesAvtive1").checked=true;
      }
}
  //------------------------------------------充值记录
  function deletecardChargeList1()
{
       if(document.getElementById("cb_cardchargelistAll").checked)
      {
       document.getElementById("cb_cardchargelistByTime").checked=false;
      }
      else
      {
       document.getElementById("cb_cardchargelistByTime").checked=true;
      }
}

function deletecardChargeList2()
{
       if(document.getElementById("cb_cardchargelistByTime").checked)
      {
       document.getElementById("cb_cardchargelistAll").checked=false;
      }
      else
      {
       document.getElementById("cb_cardchargelistAll").checked=true;
      }

}
 //------------------------------------------充值统计cb_cardchargeStaticAll
function deletecardChargeStatic1()
{
       if(document.getElementById("cb_cardchargeStaticAll").checked)
      {
       document.getElementById("cb_cardchargeStaticByTime").checked=false;
      }
      else
      {
       document.getElementById("cb_cardchargeStaticByTime").checked=true;
      }
}

function deletecardChargeStatic2()
{
       if(document.getElementById("cb_cardchargeStaticByTime").checked)
      {
       document.getElementById("cb_cardchargeStaticAll").checked=false;
      }
      else
      {
       document.getElementById("cb_cardchargeStaticAll").checked=true;
      }

}
//------------------------------------------补卡cb_ReplaceCardAll
function deleteCardReplaceRecord1()
{
      if(document.getElementById("cb_ReplaceCardAll").checked)
      {
       document.getElementById("cb_ReplaceCardByTime").checked=false;
      }
      else
      {
       document.getElementById("cb_ReplaceCardByTime").checked=true;
      }
}

function deleteCardReplaceRecord2()
{
      if(document.getElementById("cb_ReplaceCardByTime").checked)
      {
       document.getElementById("cb_ReplaceCardAll").checked=false;
      }
      else
      {
       document.getElementById("cb_ReplaceCardAll").checked=true;
      }

}
//------------------------------------------删除交易记录cb_postransactionAll
function deletePosTransDetails1()
{
      if(document.getElementById("cb_postransactionAll").checked)
      {
       document.getElementById("cb_postransactionByTime").checked=false;
      }
      else
      {
       document.getElementById("cb_postransactionByTime").checked=true;
      }
}

function deletePosTransDetails2()
{
      if(document.getElementById("cb_postransactionByTime").checked)
      {
       document.getElementById("cb_postransactionAll").checked=false;
      }
      else
      {
       document.getElementById("cb_postransactionAll").checked=true;
      }

}
</script>
</head>
<body >
<form id="form1" runat="server">
  <div class="appsection">
    <div class="apphead"><img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()" alt="" /><strong>数据维护操作</strong></div>
    <table cellpadding="1" cellspacing="1" 
          style="border-style: solid; border-width: 1px; border-color: #CCCCCC; width: 850px; border-collapse: collapse;" 
          border="1" >
      <tbody>
        <tr>
            <td style="height: 50px; background-color: ivory;">
                <label for="Siteid" style="color: #ff3300">
                    警告：以下操作在执行之后将不可撤销，或导致数据错乱，请慎重操作！<br />
                    <div>
                        注意：如果您不是初次使用本系统，建议您首先将当前数据库备份，此举可以降低风险！ &nbsp;<a href="ManagementData.aspx"><span style="color: #0000ff">数据库备份与恢复</span></a></div>
                </label>
            </td>
        </tr>
          <tr>
              <td id="TD1" runat="server" class="style1">
                  </td>
          </tr>
          <tr >
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="Transaction1" runat="server" style="width: 16px" type="checkbox"  onclick="deleteTransaction1()"/>全部记录
                  &nbsp;<input id="Transaction2" runat="server" style="width: 16px" type="checkbox"  onclick="deleteTransaction2()" checked="CHECKED"/>按时间：<input id="operate_date_begin1"
                          runat="server" class="inputblue" maxlength="20" name="operate_date_begin1" onfocus="setdatetime(this)"
                          onpropertychange="turnaddtime1()" style="width: 150px" type="text" vdisp="起始时间"
                          vtype="date" />
                  -
                  <input id="operate_date_end1" runat="server" class="inputblue" maxlength="20" name="operate_date_end1"
                      onfocus="setdatetime(this)" onpropertychange="turnaddtime2()" style="width: 150px"
                      type="text" vdisp="截止时间" vtype="date" />
                  <input id="Button1" class="btn008" name="A1"  style="width: 111px;  
                      height: 20px" type="button" value="清除停车记录" 
                      onclick="if(!checkdate('operate_date_begin1','operate_date_end1'))  return false;" 
                      OnClientClick="return confirm('确定要删除选定项吗？');"  
                      onserverclick="Button1_ServerClick"  runat="server" />&nbsp;
                  <input id="operate_date_begin" runat="server" class="inputgreen" maxlength="20" name="operate_date_begin"
                      style="display: none; width: 100px" type="text" vdisp="起始时间" /><input id="operate_date_end"
                          runat="server" class="inputgreen" maxlength="20" name="operate_date_end" style="display: none;
                          width: 100px" type="text" vdisp="截止时间" /></td>
          </tr>
          <tr>
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
          <tr >
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="systemLog1" runat="server" style="width: 16px" type="checkbox" onclick="deleteLog1()" />全部记录
                  &nbsp;<input id="systemLog2" runat="server" style="width: 16px" type="checkbox"  onclick ="deleteLog2()" checked="CHECKED"/>按时间：<input id="systemLogtime1" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue" />
                  -
                  <input id="systemLogtime2" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button5" class="btn008" name="A1"  style="width: 111px;
                      height: 20px" type="button" value="清除系统日志" runat="server" onclick="if(!checkdate('systemLogtime1','systemLogtime2'))  return false;"  onserverclick="Button5_ServerClick" />
                  </td>
          </tr>
          <tr style=" display:none">
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
          <tr style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="activet1" runat="server" style="width: 16px" type="checkbox"  onclick ="deleteactivet1()"/>全部记录
                  &nbsp;<input id="activet2" runat="server" style="width: 16px" type="checkbox"  onclick ="deleteactivet2()" checked="CHECKED"/>按时间：<input id="activetime1" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue" />
                  -
                  <input id="activetime2" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button2" class="btn008" name="A1"  style="width: 111px;  
                      height: 20px" type="button" value="清除办卡记录"  
                      onclick="if(!checkdate('activetime1','activetime2'))  return false;"  
                      onserverclick="Button2_ServerClick" runat="server"     /></td>
          </tr>
          <tr style=" display:none">
              <td class="style1">
                  </td>
          </tr>
          <tr style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="TransLog1" runat="server" style="width: 16px" type="checkbox"  onclick ="deleteTransLog1()"/>全部记录
                  &nbsp;<input id="TransLog2" runat="server" style="width: 16px" type="checkbox" onclick ="deleteTransLog2()" checked="CHECKED" />按时间：<input id="TransLogtime1" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue" />
                  -
                  <input id="TransLogtime2" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button4" class="btn008" name="A1"  style="width: 111px;  
                      height: 20px" type="button" value="清除充值记录"    runat="server" onclick="if(!checkdate('TransLogtime1','TransLogtime2'))  return false;"  onserverclick="Button4_ServerClick"     /></td>
          </tr>
          <tr style=" display:none">
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
          <tr style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="cb_postransactionAll" runat="server" style="width: 16px" type="checkbox"  
                      onclick="deletePosTransDetails1()"/>全部记录
                  &nbsp;<input id="cb_postransactionByTime" runat="server" style="width: 16px" 
                      type="checkbox"  onclick ="deletePosTransDetails2()" checked="CHECKED"/>按时间：<input 
                      id="postransTime1" runat="server" type="text" onfocus="setdatetime(this)"  
                      vtype="date" class="inputblue" />
                  -
                  <input id="postransTime2" runat="server" type="text" 
                      onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button12" class="btn008" name="A5"  style="width: 111px;  
                      height: 20px" type="button" value="清除已删除交易"   runat="server" 
                      onclick="if(!checkdate('postransTime1','postransTime2'))  return false;" 
                      onserverclick="btnDelPosTrans_ServerClick"  /></td>
                  </tr>
          <tr style=" display:none">
              <td class="style1">
                  </td>
          </tr>
          <tr style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="cardNoAvtive1" runat="server" style="width: 16px" type="checkbox"  onclick="deletecardNoAvtive1()"/>全部记录
                  &nbsp;<input id="cardNoAvtive2" runat="server" style="width: 16px" type="checkbox" onclick ="deletecardNoAvtive2()" checked="CHECKED"  />按时间：<input id="cardNoAvtivetime1" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue" />
                  -
                  <input id="cardNoAvtivetime2" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button6" class="btn008" name="A1"  style="width: 111px;  
                      height: 20px" type="button" value="清除未激活卡"     runat="server" onclick="if(!checkdate('cardNoAvtivetime1','cardNoAvtivetime2'))  return false;" onserverclick="Button6_ServerClick"     /></td>
          </tr>
          <tr style=" display:none">
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
          <tr style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="cardYesAvtive1" runat="server" style="width: 16px" type="checkbox"  
                      onclick="deletecardYesAvtive1()"/>全部记录
                  &nbsp;<input id="cardYesAvtive2" runat="server" style="width: 16px" 
                      type="checkbox"  onclick ="deletecardYesAvtive2()" checked="CHECKED"/>按时间：<input 
                      id="cardYesAvtivetime1" runat="server" type="text" onfocus="setdatetime(this)"  
                      vtype="date" class="inputblue" />
                  -
                  <input id="cardYesAvtivetime2" runat="server" type="text" 
                      onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button9" class="btn008" name="A2"  style="width: 111px;  
                      height: 20px" type="button" value="清除会员卡"   runat="server" 
                      onclick="if(!checkdate('cardYesAvtivetime1','cardYesAvtivetime2'))  return false;" 
                      onserverclick="Button7_ServerClick"  /></td>
          </tr>
          <tr style=" display:none">
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
          <tr style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="cb_cardchargelistAll" runat="server" style="width: 16px" type="checkbox"  onclick="deletecardChargeList1()"/>全部记录
                  &nbsp;<input id="cb_cardchargelistByTime" runat="server" style="width: 16px" type="checkbox"  onclick ="deletecardChargeList2()" checked="CHECKED"/>按时间：<input id="chargelistTime1" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue" />
                  -
                  <input id="chargelistTime2" runat="server" type="text" onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button7" class="btn008" name="A1"  style="width: 111px;  
                      height: 20px" type="button" value="清除充值记录"   runat="server" 
                      onclick="if(!checkdate('chargelistTime1','chargelistTime2'))  return false;" 
                      onserverclick="btnClearChargeList_ServerClick"  /></td>
          </tr>
          
           <tr style=" display:none">
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
          <tr style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="cb_cardchargeStaticAll" runat="server" style="width: 16px" type="checkbox"  
                      onclick="deletecardChargeStatic1()"/>全部记录
                  &nbsp;<input id="cb_cardchargeStaticByTime" runat="server" style="width: 16px" 
                      type="checkbox"  onclick ="deletecardChargeStatic2()" checked="CHECKED"/>按时间：<input 
                      id="cardStaticsTime1" runat="server" type="text" onfocus="setdatetime(this)"  
                      vtype="date" class="inputblue" />
                  -
                  <input id="cardStaticsTime2" runat="server" type="text" 
                      onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button10" class="btn008" name="A3"  style="width: 111px;  
                      height: 20px" type="button" value="清除充值统计"   runat="server" 
                      onclick="if(!checkdate('cardStaticsTime1','cardStaticsTime2'))  return false;" 
                      onserverclick="btnClearChargeStatic_ServerClick"  /></td>
          </tr>
          <tr>
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
          <tr style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="cb_ReplaceCardAll" runat="server" style="width: 16px" type="checkbox"  
                      onclick="deleteCardReplaceRecord1()"/>全部记录
                  &nbsp;<input id="cb_ReplaceCardByTime" runat="server" style="width: 16px" 
                      type="checkbox"  onclick ="deleteCardReplaceRecord2()" checked="CHECKED"/>按时间：<input 
                      id="replaceCardTime1" runat="server" type="text" onfocus="setdatetime(this)"  
                      vtype="date" class="inputblue" />
                  -
                  <input id="replaceCardTime2" runat="server" type="text" 
                      onfocus="setdatetime(this)"  vtype="date" class="inputblue"  />
                  <input id="Button11" class="btn008" name="A4"  style="width: 111px;  
                      height: 20px" type="button" value="清除补卡记录"   runat="server" 
                      onclick="if(!checkdate('replaceCardTime1','replaceCardTime2'))  return false;" 
                      onserverclick="btnReplaceCard_ServerClick"  /></td>
          </tr>
          
           <tr style=" display:none">
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
           <tr  style=" display:none">
              <td style="height: 25px; background-color: #F2F2F2;">
                  <input id="Checkbox3" runat="server" style="width: 16px" type="checkbox"  onclick="check3()"/>全部记录
                  &nbsp;<input id="Checkbox4" runat="server" style="width: 16px" type="checkbox"  onclick ="check4()" checked="CHECKED"/>按分店：<asp:DropDownList 
                      ID="Area_Code" runat="server" AutoPostBack="True" 
                      OnSelectedIndexChanged="Area_Code_SelectedIndexChanged" Width="100px">
                  </asp:DropDownList>
&nbsp;-
                  <asp:DropDownList ID="Site_Code" runat="server" Width="100px">
                  </asp:DropDownList>
&nbsp;<input id="Button8" class="btn008" name="A1"  style="width: 111px;  
                      height: 20px" type="button" value="分店统计清零"  OnClientClick="return confirm('确定要清除吗？');"  onserverclick="Button3_ServerClick"  runat="server" /></td>
          </tr>
          <tr style=" display:none">
              <td style="height: 20px">
                  &nbsp;</td>
          </tr>
      </tbody>
    </table>
  </div>
  <div class="appsection">
    <div class="section_operators" style="width:850px" align="center">
        &nbsp;&nbsp;
    </div>
  </div>
    </form>
</body>
</html>
