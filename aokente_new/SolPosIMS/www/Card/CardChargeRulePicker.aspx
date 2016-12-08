<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardChargeRulePicker.aspx.cs" Inherits="Card_CardChargeRulePicker" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择充值规则</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/json.js"></script>
<script type="text/javascript" src="../js/app.xmlhttp.js"></script>
<script type="text/javascript">
//-------------  
 function onG_codeSelectChange()
	{
		var select_g_code=document.getElementById('g_code');
		var G_code = select_g_code.value;
		document.all.c_code.options.length = 0;
		BindNormalTableToListControl('c_code', "c_code","c_name","pub_class","c_code","g_code = '" + G_code + "'","请选择");
		var txt = select_g_code.options[select_g_code.selectedIndex].text;
           var slt=document.getElementById("c_code");   
           var objOption=document.createElement("OPTION");   
           objOption.value='';   
           objOption.text='全部';   
           slt.add(objOption);    
           slt.options[slt.options.length-1].selected='selected';
	}
 //-------------
 function CheckAll(form)  {
 document.getElementById('chkChouse').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if(e.name.indexOf('chkChouse')>-1)
    continue;
    if (e.name.indexOf('checkitall')==-1)   e.checked = form.checkitall.checked; 
   }
  }
  
   function FanCheckAll(form)  {
   document.getElementById('checkitall').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if (e.name.indexOf('chkChouse')==-1)
    {    
    if(e.name.indexOf('checkitall')==-1)
    {
    if(e.checked)
    e.checked = false;     
    else   
    e.checked = true;
    }    
    }
   }
  }

  //--------------------------------
  
function SelData()
{
var selMobile="";
var tempdate=document.getElementsByName('chkSel');
if(tempdate.length>0)
{
    for(var i=0 ; i<tempdate.length; i++)
    {
        if(tempdate[i].checked)
        {
        selMobile+=tempdate[i].value+";";
        }
    }
}        window.opener.document.getElementById("mobiles").value=selMobile;
}
  //---------------------------
  
</script>
<script>
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:300px;">
<form runat="server" id="Form1">
			
<div class="appsection" id="search_result" runat="server" >
    <asp:GridView Width="300px" ID="GridView1" runat="server" 
        SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="请选择该等级对应的充值优惠规则">
                <ItemTemplate>
                
                    <input id="chk" type="checkbox" onclick="SelData()" name="chkSel" value='<%# Eval("rulename") %>' />
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ruleid") %>' Visible="False"></asp:Label><%# Eval("rulename") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>	
     <asp:Panel ID="delPanel" runat="server" Width="300px" Height="25px">
           <input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form);SelData();" runat="server" /><label
                for="checkitall">全选</label>
                 <input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form);SelData();" runat="server" /><label
                for="chkChouse">反选</label>
           </asp:Panel>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    EnablePaging="True" MaximumRowsParameterName="pageSize" 
    OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" 
    SelectMethod="GetPagedObjects" SortParameterName="sortedBy" 
    StartRowIndexParameterName="startIndex" 
    TypeName="Ims.Card.BLL.CardRuleHelperBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>


