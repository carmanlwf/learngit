<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PosOperatorList.aspx.cs"
    Inherits="ST_PosOperatorList" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收费员列表</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>


    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>
    
<script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script> 
<script type="text/javascript" src="../js/laydate.js"></script>
    <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    
function doInforEdit(oid)
{
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"PosOperator.aspx?getcode="+oid
    });
    $("#isFrameOpt").trigger("click");
    //openBrWindow('PosOperator.aspx?getcode='+oid,'EditPosOperator','405','350')  ;
}
function doInfornew()
{
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"PosOperator.aspx"
    });
    $("#isFrameOpt").trigger("click");
    //openBrWindow('PosOperator.aspx','NewPosOperator','405','350')  ;
}

 function CheckAll(form)  {
 document.getElementById('chkChouse').checked=false;
  for (var i=0;i<form.elements.length;i++)    {
    var e = form.elements[i];
    if(e.name.indexOf('chkChouse')>-1)
    continue;
    if (e.name.indexOf('checkitall')==-1)       e.checked = form.checkitall.checked; 
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

    </script>

    <script type="text/javascript">
    WaitHelper.showWaitMessage();
    </script>

    <style type="text/css">
        .style5
        {
            height: 18px;
        }
        </style>

</head>
<body style="width:98%">
    <form runat="server" id="Form1">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
        <ul class="sitemappath">
            <li><strong>操作员信息</strong></li>
        </ul>
        <div class="appsection">
            <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%">
                <tr>
                    <th class="style5">
                        操作员编号</th>
                    <td class="style5">
                        &nbsp;<input type="text" class="inputblue" style="width: 100px" id="Operatorid" runat="server"
                            name="Operatorid" maxlength="20" /></td>
                    <th class="style5">
                        注册日期</th>
                    <td class="style5">
                        <input type="text" class="inputblue" style="width: 100px" id="adddate_begin" runat="server"
                            onfocus="setday(this)" vdisp="起始时间" vtype="date" name="adddate_begin" maxlength="20" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" />～<input
                                type="text" class="inputblue" style="width: 100px" id="Text2" runat="server"
                                onfocus="setday(this)" vdisp="截止时间" vtype="date" name="operate_date_end" maxlength="20" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" /></td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        &nbsp;&nbsp;&nbsp;
                        <input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew()"
                            id="btnNew" runat="server" />
                        <input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;if(!checkdate('adddate_begin','Text2'))  return false;"
                            id="Button3" runat="server" onserverclick="Button3_ServerClick" />
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="appsection" id="search_result" runat="server">
            <div class="apphead">
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>收费人员信息</strong></div>
            <asp:GridView Width="100%" PageSize="12" ID="GridView1" runat="server" SkinID="GridView_Blue"
                AllowPaging="True" AutoGenerateColumns="False" 
                DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("operatorid") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="sitename" HeaderText="路段名称" Visible= "false">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="operatorid" HeaderText="操作员帐号" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="name" HeaderText="操作员姓名" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cellphone" HeaderText="联系电话" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="status" HeaderText="签到状态" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="lastsigntime" HeaderText="上次签到" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="last_siteid" HeaderText="最后执勤路段编号" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="last_sitename" HeaderText="最后执勤路段名称" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="last_possnr" HeaderText="最后执勤所用终端" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="adddate" HeaderText="注册日期" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                      <asp:TemplateField HeaderText="编辑" AccessibleHeaderText="oid">
                        <ItemTemplate>
                           <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("operatorid")%>')"><font color="orange">[编辑信息]</font></a>
                        </ItemTemplate>
                        <ItemStyle CssClass="tbody_th" HorizontalAlign="Center" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
           <div class="table_data_title xytact">
			<ul>
					<li><input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)"
                runat="server" /><label for="checkitall">全选</label><em>|</em></li>
					<li><input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)"
                runat="server" /><label for="chkChouse">反选</label><em>|</em></li>
                    <li><asp:Button ID="btnDelete" runat="server"
                Text="批量删除"  OnClientClick="return confirm('确定要删除选定项吗？');" OnClick="btnDelete_Click" 
                            Width="62px" BackColor="Transparent" BorderStyle="None" Height="25px" /></li>
			</ul>
		</div>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ims.Site.BLL.PosOperatorHelperBLL" OldValuesParameterFormatString="">
            <SelectParameters>
                <asp:Parameter Name="o" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>

    <script type="text/javascript">
	WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
