<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardToExec.aspx.cs" StylesheetTheme="app"
    Inherits="Card_CardToExec" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员卡信息导出</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
           <link rel="stylesheet" href="../css/table.css" />

    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="js/CD.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/json.js"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>

    <script type="text/javascript">
 
function Checkboxonclick2()
{
 if(document.getElementById('Checkbox2').checked)
 {
  tableth1.style.display= ""; 
 tableth2.style.display= ""; 
 tableth3.style.display= ""; 
 document.getElementById('Checkbox3').checked=false;
 document.getElementById('Checkbox4').checked=false;
  document.getElementById("choolWhot").value="1";
 }
 else
 {
 tableth1.style.display= "none"; 
 tableth2.style.display= ""; 
 tableth3.style.display= ""; 
 document.getElementById('Checkbox3').checked=true;
 document.getElementById('Checkbox4').checked=false;
 document.getElementById("choolWhot").value="2";
 }
}



function Checkboxonclick3()
{
 if(document.getElementById('Checkbox3').checked)
 {
 tableth1.style.display= "none"; 
 tableth2.style.display= ""; 
 tableth3.style.display= ""; 
 document.getElementById('Checkbox2').checked=false;
 document.getElementById('Checkbox4').checked=false;
   document.getElementById("choolWhot").value="2";
 }
 else
 {
 tableth1.style.display= ""; 
 tableth2.style.display= "none"; 
 tableth3.style.display= "none"; 
 document.getElementById('Checkbox2').checked=false;
 document.getElementById('Checkbox4').checked=true;
    document.getElementById("choolWhot").value="3";
 }
}



function Checkboxonclick4()
{
 if(document.getElementById('Checkbox4').checked)
 {
 tableth1.style.display= ""; 
 tableth2.style.display= "none"; 
 tableth3.style.display= "none"; 
 document.getElementById('Checkbox2').checked=false;
 document.getElementById('Checkbox3').checked=false;
    document.getElementById("choolWhot").value="3";
 }
 else
 {
 tableth1.style.display= ""; 
 tableth2.style.display= ""; 
 tableth3.style.display= ""; 
 document.getElementById('Checkbox2').checked=true;
 document.getElementById('Checkbox3').checked=false;
  document.getElementById("choolWhot").value="1";
 }
}

    function onAreaSelectChange()
	{
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.Site_Code.options.length = 0;
		BindNormalTableToListControl('Site_Code', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
	}
 
 function ishchoolwhort()
 {
   if(document.getElementById("choolWhot").value=="")
   {
     document.getElementById('Checkbox2').checked=true;
     Checkboxonclick2();
   }
   else
   {
      if(document.getElementById("choolWhot").value=="1")
      {
            document.getElementById('Checkbox2').checked=true;
            Checkboxonclick2();
      }
      else
      {
          if(document.getElementById("choolWhot").value=="2")
          {
            document.getElementById('Checkbox3').checked=true;
                 Checkboxonclick3();
          }
          else
          {
            document.getElementById('Checkbox4').checked=true;
                 Checkboxonclick4();
          }
      }
   }
 }
    </script>

    <script type="text/javascript">
WaitHelper.showWaitMessage();
    </script>

</head>
<body style="width: 98%;" >
    <form runat="server" id="Form1">
    <ul class="sitemappath">
        <li><strong>会员卡基本信息</strong></li></ul>
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%">
            <tr>
                <th style="width: 90px; height: 18px">
                    导出信息选择
                </th>
                <td colspan="3" style="height: 18px">
                    <input id="Checkbox2" runat="server" type="checkbox" 
                        onclick="Checkboxonclick2()" checked="checked" />卡全部信息&nbsp;
                    <input id="Checkbox3" runat="server" type="checkbox" onclick="Checkboxonclick3()" />激活卡信息&nbsp;
                    <input id="Checkbox4" runat="server" type="checkbox" onclick="Checkboxonclick4()" />未激活信息&nbsp;
                    <input type="text" class="inputblue" style="width: 110px; display: none" id="choolWhot"
                        runat="server" name="choolWhot" maxlength="20" />
                </td>
                <th style="height: 18px">
                    &nbsp;</th>
                <td style="height: 18px">
                    &nbsp;</td>
            </tr>
            <tr id="tableth1">
                <th style="width: 90px; height: 18px">
                    发卡时间</th>
                <td style="width: 341px; height: 18px">
                    <input type="text" class="inputblue" style="width: 120px" id="addeddate1" runat="server"
                        onfocus="setday(this)" vdisp="起始时间" vtype="date" name="addeddate1" maxlength="20" />-<input
                            type="text" class="inputblue" style="width: 120px" id="addeddate2" runat="server"
                            onfocus="setday(this)" vdisp="截止时间" vtype="date" name="addeddate2" maxlength="20" /></td>
                <th style="height: 18px">
                    卡片类型</th>
                <td style="height: 18px">
                    <select id="TypeID" runat="server" class="inputblue" name="TypeID" 
                        style="width: 120px">
                    </select></td>               
                     <th style="height: 18px">
                         初始金额</th>
                <td style="height: 18px">
                <input id="initvalue" runat="server" class="inputblue" maxlength="30" 
                        name="initvalue" style="width: 120px"
                    type="text" /></td>
            </tr>
            <tr id="tableth2">
                <th style="width: 90px; height: 18px">
                    &nbsp;积分范围</th>
                <td style="width: 341px; height: 18px">
                <input id="S_Point" runat="server" class="inputblue" maxlength="30" name="S_Point" style="width: 120px"
                    type="text" />-<input id="E_Point" runat="server" class="inputblue" 
                        maxlength="30" name="E_Point" style="width: 120px"
                    type="text" /></td>
                <th style="height: 18px">
                    激活分店</th>
                <td style="height: 18px">
                    <asp:DropDownList ID="Area_Code" runat="server" Width="120px" 
                            AutoPostBack="True" onselectedindexchanged="Area_Code_SelectedIndexChanged">
                        </asp:DropDownList>
                     <asp:DropDownList ID="Site_Code" runat="server" Width="120px">
                        </asp:DropDownList>
                    </td>
               <th style="height: 18px">
                    &nbsp;</th>
                <td style="height: 18px">
                </td>
            </tr>
            <tr id="tableth3">
                <th style="height: 18px; width: 90px;">
                    激活时间
                </th>
                <td style="height: 18px; width: 341px;">
                    <input type="text" class="inputblue" style="width: 120px" id="activetime1" runat="server"
                        onfocus="setday(this)" vdisp="起始时间" vtype="date" name="activetime1" maxlength="20" />-<input
                            type="text" class="inputblue" style="width: 120px" id="activetime2" runat="server"
                            onfocus="setday(this)" vdisp="截止时间" vtype="date" name="activetime2" maxlength="20" /></td>
                <th style="height: 18px">
                    卡片状态
                </th>
                <td style="height: 18px">
                    <select class="inputblue" style="width: 120px" id="cardstatus1" runat="server" 
                        name="cardstatus1">
                    </select></td>
                <th style="height: 18px">
                    &nbsp;</th>
                <td style="height: 18px">
                </td>
            </tr>
            <tr>
                <td align="right" colspan="6" style="height: 18px">
                    &nbsp;&nbsp; &nbsp;&nbsp;
                    <input type="button" name="btnCon" class="btn003" value="数据预览" id="Button3" runat="server"
                        onserverclick="Button3_ServerClick" onclick="if(!doAllMessageBoxValidate(Form1)) return false;if(!checkdate('addeddate1','addeddate2'))  return false;if(!checkdate('activetime1','activetime2'))  return false;" />&nbsp;&nbsp;<input
                            type="button" name="btnCon" class="btn003" value="导 出" id="Button1" runat="server"
                            onserverclick="Button1_ServerClick" />
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection" id="search_result" runat="server">
        <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>预览卡信息结果</strong><asp:GridView
            Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue" AllowPaging="True"
            AutoGenerateColumns="False" AllowSorting="True">
            <Columns>
                <asp:TemplateField HeaderText="卡号">
                    <ItemTemplate>
                        <%# Eval("card")%>
                    </ItemTemplate>
                    <ItemStyle CssClass="tbody_th" />
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
                <asp:BoundField DataField="RealName" HeaderText="会员名称">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TypeName" HeaderText="卡片类型">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="balance" HeaderText="卡内余额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="initvalue" HeaderText="初始金额">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Points" HeaderText="卡上积分">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="sitename" HeaderText="所属门店">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="cardstatus" HeaderText="卡状态">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="activeaddate" HeaderText="卡激活时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="addeddate" HeaderText="发卡时间">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <div id="SumPan"  runat = "server" style="width: 100%" >
        <font color="green">[数据汇总]→</font> 全部发卡总数:<asp:Label ID="LabelCardSum" runat="server"
            ForeColor="#C00000">0</asp:Label>&nbsp; 全部已激活卡总数:<asp:Label ID="LabelCardActiveSum"
                runat="server" ForeColor="#C00000">0</asp:Label>
        &nbsp;&nbsp;全部未激活卡数:<asp:Label ID="LabelCardNoActiveSum" runat="server" ForeColor="#C00000">0</asp:Label>
        &nbsp; 当前卡内金额汇总：
        <asp:Label ID="LabelMemberSumBan" runat="server" ForeColor="Navy">0.00</asp:Label>&nbsp;
        全部未激活卡余额：
        <asp:Label ID="LabelCardNoActiveSumBan" runat="server" ForeColor="Navy">0.00</asp:Label>
        已激活初始金额总额：
        <asp:Label ID="LabelCardInitValue_Normal" runat="server" ForeColor="Navy">0.00</asp:Label>
        &nbsp;未激活初始金额总额：
        <asp:Label ID="LabelCardInitValue_NoActived" runat="server" ForeColor="Navy">0.00</asp:Label>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Card.BLL.v_CardToExecBLL" OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="o" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>

    <script>
WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
