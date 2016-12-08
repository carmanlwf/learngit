<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptList.aspx.cs" Inherits="ReportViewer_RptList" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据报表</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
 <link rel="stylesheet" href="../css/table.css" />
    <script src="../js/app.edit.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <%--jquery引用--%>
    <link href="../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="../lib/ligerUI/skins/ligerui-icons.css" rel="stylesheet" type="text/css" />

    <script src="../lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../lib/ligerUI/js/core/base.js" type="text/javascript"></script>

    <script src="../lib/ligerUI/js/plugins/ligerDrag.js" type="text/javascript"></script>

    <script src="../lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>

    <script src="../lib/ligerUI/js/plugins/ligerResizable.js" type="text/javascript"></script>

    <%--引用结束--%>

    <script language="javascript" type="text/javascript">

        function CheckAll(form) {
            document.getElementById('chkChouse').checked = false;
            for (var i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.name.indexOf('chkChouse') > -1)
                    continue;
                if (e.name.indexOf('checkitall') == -1)
                    e.checked = form.checkitall.checked;
            }
        }

        function FanCheckAll(form) {
            document.getElementById('checkitall').checked = false;
            for (var i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.name.indexOf('chkChouse') == -1) {
                    if (e.name.indexOf('checkitall') == -1) {
                        if (e.checked)
                            e.checked = false;
                        else
                            e.checked = true;
                    }
                }
            }
        }
        //2013-4-28 *ZSD
        //新增
        function addadmin(id) {
            $.ligerDialog.open({ url: 'AreaOper.aspx', height: 251, width: 415, showMax: true, showToggle: true, showMin: true, slide: false,
                buttons: [
                { text: '确定', onclick: f_AddOK },
                { text: '取消', onclick: function(item, dialog) { dialog.close(); } }
             ], isResize: true
            });
        }
        //  编辑
        function doInforEdit(id) {
            $.ligerDialog.open({ url: 'AreaOper.aspx?getcode=' + id, height: 251, width: 415, showMax: true, showToggle: true, showMin: true, slide: false,
                buttons: [
                { text: '确定', onclick: f_EditOK },
                { text: '取消', onclick: function(item, dialog) { dialog.close(); } }
             ], isResize: true
            });
        }
        //查询
        function doSeeInfo2(areacode) {
            $.ligerDialog.open({ url: 'AreaOper.aspx?statu=readonly&getcode=' + areacode, height: 251, width: 415, showMax: true, showToggle: true, showMin: true, slide: false,
                buttons: [{ text: '关闭', onclick: function(item, dialog) { dialog.close(); } }
             ], isResize: true
            });
        }
        //获取子页面数据
        function f_EditOK(item, dialog) {
            var fn = dialog.frame.OnSubmitUpd || dialog.frame.window.OnSubmitUpd;
            var data = fn();
            if (data == true) {

                //        dialog.close();
            }
        }
        //获取子页面数据
        function f_AddOK(item, dialog) {
            var fn = dialog.frame.OnSubmitIns || dialog.frame.window.OnSubmitIns;
            var data = fn();
            if (data == true) {
                //        dialog.close();
            }
        }
    </script>

    <script>
        WaitHelper.showWaitMessage();
    </script>

    <style type="text/css">
        .style1
        {
            height: 8px;
            width: 244px;
        }
        .style2
        {
            height: 8px;
            width: 161px;
        }
        .style3
        {
            height: 8px;
            width: 149px;
        }
        .style4
        {
            width: 70px;
            height: 8px;
        }
        .style5
        {
            height: 8px;
        }
    </style>
</head>
<body style="width: 98%;">
    <form runat="server" id="Form1">
    <ul class="sitemappath">
        <li style="height: 20px">
            &nbsp;数据报表 > 报表清单</li>
    </ul>
    <div class="appsection">
        <table cellpadding="0" cellspacing="0" class="table_blue" 
            style="width: 100%; height: 23px;">
            <tr>
                <th class="style4">
                    报表编号
                </th>
                <td class="style3">
                    <input type="text" class="inputgreen02" style="width: 120px" id="Rptid" runat="server"
                        name="Rptid" maxlength="30" />
                </td>
                <th class="style4">
                    报表名称
                </th>
                <td class="style2">
                    <input type="text" class="inputgreen02" style="width: 123px" id="name" runat="server"
                        name="name" maxlength="30" />
                </td>
                <th class="style4">
                    <asp:Button ID="btnSelect" runat="server" Text="查询" CssClass="btn1" class="icondel"
            OnClick="btnSelect_Click" />
                </th>
                <td class="style1">
                    &nbsp;</td>
                <td class="style5">
                </td>
            </tr>
        </table>
    </div>
    <div align="right" class="section_operators" style="width: 100%; height: 20px;">
        &nbsp;</div>
    <div class="appsection" id="search_result" runat="server">
        <asp:GridView ID="gvArea" runat="server" AutoGenerateColumns="False" SkinID="GridView_Blue"
            Width="100%" AllowPaging="True" DataSourceID="ObjectDataSource1" 
            PageSize="15">
            <Columns>
                <asp:TemplateField HeaderText="报表编号">
                    <ItemTemplate>
                        <%# Eval("Rptid")%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" width="80px"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="报表名称">
                    <ItemTemplate>
                            <a href='<%# Eval("PageName")%>' target="_self" title="点击报表名称进入报表明细页后按条件筛选"  onMouseOver="this.style.textDecoration='underline';this.style.color='green'"  onMouseout="this.style.textDecoration='none';this.style.color='black'" ><%# Eval("name")%></a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"  Width="120px" />
                </asp:TemplateField>
                <asp:BoundField DataField="type" HeaderText="模板类别" 
                    ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="template" HeaderText="模板名称" 
                    ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="addeddate" HeaderText="添加时间" >
                    <HeaderStyle Width="100px" HorizontalAlign="Center" />

<ItemStyle Width="150px" HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
              <asp:TemplateField HeaderText="报表名称">
                    <ItemTemplate>
                            <a href='<%# Eval("PageName")%>' target="_self" title="点击进入"   onMouseOver="this.style.textDecoration='none';this.style.color='orange'" onMouseout="this.style.textDecoration='none';this.style.color='black'">[查看]</a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"  Width="120px"/>
                </asp:TemplateField>
                <asp:BoundField DataField="description" HeaderText="备注信息">
                    <HeaderStyle Width="500px" />
                </asp:BoundField>
                <asp:BoundField DataField="IsUseTemplate" HeaderText="是否启用" Visible="False" />
            </Columns>
        </asp:GridView>
        <asp:Panel ID="delPanel" runat="server" Width="100%">
            <span class="btngrey">&nbsp;</span>
        </asp:Panel>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
        OldValuesParameterFormatString="" OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
        TypeName="Ims.Pub.BLL.Rpt_ListHelperBLL">
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
