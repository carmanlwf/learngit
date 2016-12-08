<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rpt_OperationLog.aspx.cs" Inherits="Report_Rpt_OperationLog" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>操作日志</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>
 <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

function doInforEdit(Userid)
{
    openBrWindow('MemberOperation.aspx?getcode='+Userid,'EditMemberInfo','850','230')  ;
}


function doInfornew()
{
    openBrWindow('MemberOperation.aspx','NewMemberInfo','850','230')  ;
}

</script>
<script>
WaitHelper.showWaitMessage();
</script>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<ul class="sitemappath"><li><strong>日志查询</strong></li></ul>
<div class="appsection">
	<table  cellpadding="1" cellspacing="1" class="table_default table_blue"style="width:100%;" >
	  <tr> 
		<th >
            事件编号</th>
		<td class="style1" >
		  <input type="text" class="inputblue" style="width:100px" id="logid"  runat="server" name="logid" maxlength="25" />		
		</td>
		<th >
            操作员号</th>
		<td class="style2" ><input type="text" class="inputblue" style="width:100px" id="operater"  runat="server" name="operater" maxlength="25" />&nbsp;</td>
		<th >
            &nbsp;</th>
		<td class="style3">
                &nbsp;&nbsp;</td>
	  </tr>
	  <tr>
	    <th >
            操作时间</th>
        <td>
             <div class="inline layinput"  style=" float:left; margin-left:20px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="operate_date_begin" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" style="  font-size:12px; width:153px;" /></div><span style=" float:left; color:Red; font-size:16px;">～</span>
                            <div class="inline layinput"  style="float:left;margin-left:1px; border:1px solid #B8E1F6; width:155px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss"  runat="server"  id="operate_date_end" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"  style="  font-size:12px; width:153px;"/></div>
        </td>
		  <th >
              事件类型</th>
		<td colspan="3">
                <select class="inputblue" style="width:100px; " id="type" runat="server" name="type">
                </select></td>
		</tr>
	    <tr>  
            <td align="right" colspan="6">
                &nbsp;&nbsp; 
	        <input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;if(!checkdate('operate_date_begin','operate_date_end'))  return false;" id="Button3" runat="server" onserverclick="Button3_ServerClick" />&nbsp;&nbsp;		
            </td>
	  </tr>
  </table>	
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>日志信息</strong></div>
    <asp:GridView Width="100%" PageSize="12" ID="GridView1" runat="server" 
        SkinID="GridView_Blue" AllowPaging="True" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="logid" HeaderText="事件编号"  >
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="type" HeaderText="事件类型" >
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="operater" HeaderText="操作员id" >
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="operate_date" HeaderText="操作时间" >
                <HeaderStyle Width="120px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="logmsg" HeaderText="事件明细" >
            </asp:BoundField>
        </Columns>
    </asp:GridView>	
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount" SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex" TypeName="Ims.Log.BLL.LogHelperBLL" OldValuesParameterFormatString="">
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