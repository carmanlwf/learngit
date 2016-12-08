<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardBatchRegister.aspx.cs" Inherits="Card_CardBatchRegister" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>批量卡注册</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script src="../js/app.edit.js"></script>

    <script type="text/javascript">
        function SplitCardNum() 
        { 
            var str = document.getElementById('cardbatch').value;
            var strArr = formatStr(str);
            var strs= new Array(); //定义一数组

            strs=strArr.split(","); //字符分割      
            var s = unique(strs)
            returnToArea(s);
        }
        function returnToArea(ss)
        {
//            alert(ss)
//            
//            re = /,/g;                     // 创建正则表达式模式。
//            ss = ss.replace(re, "\r\n");    // 将逗号替换为逗号换行，即从每个逗号后边另起一行。

//            alert(ss);
            document.getElementById('cardbatch').innerText = ss;
        }
        function formatStr(str)    
        {    
          str=str.replace(/\r\n/ig,",");    
          return str;    
        } 
        function unique(data)
        {   
            data = data || [];   
                var a = {};   
            for (var i=0; i<data.length; i++) {   
                var v = data[i];   
                if (typeof(a[v]) == 'undefined'){   
                    a[v] = 1;   
                }   
            };   
            data.length=0;   
            for (var i in a){   
                data[data.length] = i;   
            }   
            return data.join("\r\n");   
        }
    </script>

</head>
<body>

    <script>
WaitHelper.showWaitMessage();
    </script>

    <form id="form1" runat="server">
        <table cellspacing="0" style="width: 840px; margin-top: 3px; border-left-color: darkgray; border-bottom-color: darkgray; border-top-style: solid; border-top-color: darkgray; border-right-style: solid; border-left-style: solid; border-collapse: collapse; border-right-color: darkgray; border-bottom-style: solid;" border="1">
            <tr>
                <td style="vertical-align: top; width: 440px; height: 498px;">
                    <div class="apphead" style="width: 440px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>基本信息</strong></div>
                        <table width="100%" cellpadding="1" cellspacing="1" class="table_default table_blue">
                            <tr>
                                <th width="20%">
                                    开始时间</th>
                                <td>
                                    <input id="id" name="groupidquery" type="text" class="inputgreen ime_engish" style="width: 100px" runat="server" /></td>
                                <th width="20%">
                                    结束时间</th>
                                <td><input id="Text1" name="groupidquery" type="text" class="inputgreen ime_engish" style="width: 100px" runat="server" /></td>
                            </tr>
                            <tr>
                                <th width="20%">
                                    卡号</th>
                                <td>
                                    <input id="Text2" name="groupidquery" type="text" class="inputgreen ime_engish" style="width: 100px" runat="server" /></td>
                                <th width="20%">
                                    是否启用</th>
                                <td>
                                    <select id="flag" runat="server" class="inputgreen" name="flag" style="width: 60px">
                                        <option value="false">停用</option>
                                        <option selected="selected" value="true">启用</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <th width="20%">
                                    </th>
                                <td>
                                    &nbsp;</td>
                                <td  align="right" colspan="2"><input id="btnQuery" type="button" name="btnQuery" class="btn003" value="查询" runat="server" onserverclick="btnQuery_ServerClick" />&nbsp;</td>
                            </tr>
                        </table>
                                            <div class="apphead" style="width: 440px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>发卡信息</strong></div>
                    <asp:GridView ID="gvBatchCard" runat="server" AutoGenerateColumns="False"
                        SkinID="GridView_AutoWidth_Blue" AllowPaging="True" AllowSorting="True" DataKeyNames="id"
                        Width="440px">
                        <Columns>
                            <asp:TemplateField HeaderText="会员卡号">
                                <ItemTemplate>
                                    <%# Eval("card")%>
                                </ItemTemplate>
                                <ItemStyle CssClass="tbody_th" />
                                <HeaderStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="card" HeaderText="会员卡号" >
                                <HeaderStyle Width="114px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="physicalno" HeaderText="物理卡号" >
                                <HeaderStyle Width="209px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="addeddate" HeaderText="发卡时间" >
                                <HeaderStyle Width="180px" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="flag" HeaderText="是否有效" >
                                <HeaderStyle Width="112px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CheckBoxField>
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
                        OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
                        SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
                        TypeName="Ims.Site.BLL.SiteHelperBLL" DataObjectTypeName="">
                        <SelectParameters>
                            <asp:Parameter Name="o" Type="Object" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    &nbsp;
                </td>
                <td style="vertical-align: top; width: 175px; height: 498px;">
                    <div class="apphead" style="width: 175px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>已注册卡号</strong></div>
                    <select id="cardIn" name="cardIn" size="34" multiple="true" style="width: 175px"
                        runat="server" >
                    </select>
                </td>
                <td style="vertical-align: center; width: 30px; height: 498px;">
                </td>
                <td style="vertical-align: top; width: 175px; height: 498px;">
                    <div class="apphead" style="width: 175px">
                        <img src="../images/bullet02.gif" class="appnavimg" /><strong>待注册卡号</strong></div>
                    <textarea id="cardbatch" style="width: 175px; height: 475px"  onkeyup ="SplitCardNum()" name="cardbatch"></textarea></td>
            </tr>
        </table>
    </form>

    <script>
WaitHelper.initWaitMessageForms("form1");  
    </script>

</body>
</html>

