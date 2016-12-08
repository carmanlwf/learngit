<%@ Page Language="C#" AutoEventWireup="true" CodeFile="operator_list.aspx.cs" Inherits="GPS_Info_operator_list" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收费员状态列表</title>
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
                        操作员帐号</th>
                    <td class="style5">
                        <input type="text" class="inputblue" style="width: 100px" id="Operatorid" runat="server"
                            name="Operatorid" maxlength="20" /></td>
                    <th class="style5">
                        值班状态</th>
                    <td class="style5">
                        <select id="islogin" runat="server" class="inputblue" name="islogin" 
                            style="width: 130px">
                        </select></td>
                </tr>
                <tr>
                    <th class="style5">
                        操作员姓名</th>
                    <td class="style5">
                        <input type="text" class="inputblue" style="width: 100px" id="Operatorid0" runat="server"
                            name="Operatorid0" maxlength="20" /></td>
                    <th class="style5">
                        位置状态</th>
                    <td class="style5">
                        <select id="isOutBounds" runat="server" class="inputblue" name="isOutBounds" 
                            style="width: 130px">
                        </select></td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <input type="button" name="btnCon" class="btn003" value="查询" onclick="if(!doAllMessageBoxValidate(Form1)) return false;"
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
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                        <%#Eval("islogin").ToString() == "1" ? "<img alt='' src='operator.png'/>" : "<img alt='' src='operator_bw.png'/>"%>
                        </ItemTemplate>
                        <ItemStyle Width="60px" />
                         <ItemStyle CssClass="tbody_th" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="operatorid" HeaderText="操作员帐号" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="name" HeaderText="操作员姓名" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="当班状态">
                        <ItemTemplate>
                            <%#Eval("islogin").ToString() == "0" ? "<font color=red>下班</font>" : "<font color=green>值班</font>"%>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                         <ItemStyle CssClass="tbody_th" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="lastsigntime" HeaderText="上次签到" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="last_siteid" HeaderText="最后执勤路段编号" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="last_sitename" HeaderText="最后执勤路段名称" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="last_possnr" HeaderText="最后执勤所用终端号" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="位置状态" Visible="false">
                        <ItemTemplate>
                        <%#Eval("isOutBounds").ToString() == "1" ? "<font color=red>脱岗</font>" : "<font color=green>在岗</font>"%>
                        </ItemTemplate>
                         <ItemStyle CssClass="tbody_th" HorizontalAlign="Center" />
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="查看位置轨迹" AccessibleHeaderText="oid">
                        <ItemTemplate>
                           <a href="traceinfo.aspx?opid=<%#Eval("Operatorid") %>"><font color="orange">[今日执勤轨迹]</font></a>
                        </ItemTemplate>
                        <ItemStyle CssClass="tbody_th" HorizontalAlign="Center" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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

