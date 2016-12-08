<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberLevel.aspx.cs" Inherits="Member_MemberLevel"
    StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员等级基本信息</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="js/MB.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript">

function doInforEdit(id)
{
    openBrWindow('MemberLevelOper.aspx?getcode='+id,'EditRankInfo','355','350')  ;
}

function doInfornew()
{
    openBrWindow('MemberLevelOper.aspx','NewRankInfo','355','350');
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

    <script>
WaitHelper.showWaitMessage();
    </script>

</head>
<body style="width:100%";">
    <form runat="server" id="Form1">
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <ul class="sitemappath">
            <li><strong>等级基本信息</strong></li></ul>
        <div class="appsection">
            <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width:100%"">
                <tr>
                    <th width="100">
                        等级编号</th>
                    <td style="width: 369px">
                        <input type="text" class="inputblue" style="width: 100px" id="id" runat="server"
                            name="RankId" vtype="number" maxlength="20" />
                    </td>
                    <th width="100">
                        等级名称</th>
                    <td style="width: 251px" colspan="3">
                        <input type="text" class="inputblue" style="width: 100px" id="Name" runat="server"
                            name="Name" maxlength="20" />&nbsp;</td>
                </tr>
                <tr>
                    <th>
                        添加时间</th>
                    <td style="width: 369px">
                        <input type="text" class="inputblue" style="width: 100px" id="addeddate1" runat="server"
                            onfocus="setday(this)" vdisp="起始时间" vtype="date" name="addeddate1" maxlength="20" />～<input
                                type="text" class="inputblue" style="width: 100px" id="addeddate2" runat="server"
                                onfocus="setday(this)" vdisp="截止时间" vtype="date" name="addeddate2" maxlength="20" /></td>
                    <th>
                    </th>
                    <td colspan="3" style="width: 251px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" colspan="6">
                        &nbsp;<input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew()"
                            id="btnNew" runat="server" />
                        <input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                            onserverclick="Button3_ServerClick" onclick="if(!doAllMessageBoxValidate(Form1)) return false;" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="appsection" id="search_result" runat="server">
            <div class="apphead">
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>等级信息</strong></div>
            <asp:GridView Width="100%" ID="GridView1" runat="server" SkinID="GridView_Blue"
                AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server"    Visible=<%# Eval("id").ToString()!="0"?true:false %> />
                            <img src="../images/default.gif"/ style="display:<%# Eval("id").ToString()=="0"?"":"none" %>">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="等级编号">
                        <ItemTemplate>
                            <%# Eval("id")%>
                        </ItemTemplate>
                        <ItemStyle CssClass="tbody_th" HorizontalAlign="Center" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="等级名称">
                        <ItemTemplate>
                            <a href="javascript:void(0)" onclick="doSeeInfo2('<%# Eval("id")%>');">
                                <%# Eval("Name")%>
                            </a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="等级名称">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="point" HeaderText="积分比例">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="scale" HeaderText="充值比例" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField ShowHeader="False" HeaderText="编辑">
                        <ControlStyle Width="55px" />
                        <ItemTemplate>
                            <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("id")%>')">
                                <img style="border: 0;" alt="编辑" src="../images/edit.gif" id="imedit" /></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView><span class="btngrey">
                <br />
                <asp:Panel ID="delPanel" runat="server" Height="1px" Width="192px">
                    &nbsp;<input type="checkbox" id="checkitall" name="checkitall" onclick="CheckAll(this.form)" /><label
                for="checkitall">全选</label>
            <input type="checkbox" id="chkChouse" name="chkChouse" onclick="FanCheckAll(this.form)" /><label
                for="chkChouse">反选</label>
            <span class="btngrey">
                <asp:Button ID="btnDelete" runat="server" Text="删除所选" class="icondel" OnClientClick="return confirm('确定要删除选定项吗？');"
                    OnClick="btnDelete_Click" CssClass="btn004" Width="70px" />
            </span>
                </asp:Panel>
            </span>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ims.Member.BLL.MemberRanksHelper" OldValuesParameterFormatString="">
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
