<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"  CodeFile="CardSelectAccount.aspx.cs" Inherits="Card_CardSelectAccount" StylesheetTheme="app" EnableSessionState="ReadOnly" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>ת���˻�ѡ��</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/CD.js" charset ="gb2312"></script>
</head>
 <script type="text/javascript">
function CloseWin(parm_cd,parm_rm,parm_bl)
{

        var parent = GetParentWindow();
        //ת���û�����
        var cd = parent.document.getElementById("Card1");
        if(parm_cd.length>0)  cd.value= parm_cd;
        //ת���û�����
        var rm = parent.document.getElementById("RealName1");
        if(parm_rm.length>0) rm.value = parm_rm;
        //ת���û�����
        var bl = parent.document.getElementById("Balance1");
        if(parm_rm.length>0) bl.value = parm_bl;
        close();
   
}
</script>
<body style="width:500;">
   <script>
WaitHelper.showWaitMessage();
</script>
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>��Ա��������Ϣ</strong></li></ul>
			
<div class="appsection">
	<table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px" >
	  <tr> 
		<th style="width: 121px" >
            ��Ա����</th>
		<td style="width: 160px" >
            <input type="text" class="inputgreen" style="width:100px" id="Card"  runat="server" name="Card" maxlength="20" />&nbsp;
		</td>
		<th style="width: 121px" >
            ��Ա����</th>
		<td style="width: 120px" >
		  <input type="text" class="inputgreen" style="width:100px" id="RealName"  runat="server" name="RealName" />&nbsp;</td>
	  </tr>
        <tr>
            <th style="width: 121px">
            �ֻ�����</th>
            <td colspan="3">
                <input type="text" class="inputgreen" style="width:100px" id="CellPhone"  runat="server" name="RealName" vtype="mobiletel"/>
                <input type="button" name="btnCon" class="btn003" value="��ѯ" onclick="if(!doAllMessageBoxValidate(Form1)) return false;" id="Button3" runat="server" onserverclick="Button3_ServerClick" />
                <input type="button" name="bt_Confirm" class="btn003" value="ȷ��"  id="bt_Confirm" runat="server" onserverclick="bt_Confirm_ServerClick"  /></td>
        </tr>
  </table>	
</div>

<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>��Ա����Ϣ</strong></div>
    <asp:GridView Width="400px" ID="GridView1" runat="server" SkinID="GridView_AutoWidth_blue" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="Card">
        <Columns>
                    <asp:TemplateField HeaderText="�к�">
                        <ItemStyle Width="35px" CssClass="tbody_th" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <input type="radio" id="selectRadioButton1" name="selectRadioButton1" value="<%# Eval("Card ")%>" checked="CHECKED"
                                 />
                        </ItemTemplate>
                    </asp:TemplateField>
            <asp:BoundField DataField="Card" HeaderText="����" />
            <asp:BoundField DataField="RealName" HeaderText="����" />
            <asp:BoundField DataField="RankName" HeaderText="��Ա�ȼ�" >
            </asp:BoundField>
            <asp:BoundField DataField="balance" HeaderText="�˻����" >
            </asp:BoundField>
            <asp:BoundField DataField="AddedDate" HeaderText="����ʱ��" HtmlEncode="False" DataFormatString="{0:MM/dd/yyyy}" >
            </asp:BoundField>
        </Columns>
    </asp:GridView>	

</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.CardHelperBLL" OldValuesParameterFormatString="">
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
