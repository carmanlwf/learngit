<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="Member_MemberList"
    StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员基本信息</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/table.css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
	<script type="text/javascript" src="../js/app.xmlhttp.js"></script>

    <script src="../js/checkdate.js" type="text/javascript"></script>
    
<script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>

    <script src="../js/laydate.js" type="text/javascript"></script>

    <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

function doInforEdit(Userid)
{
    $("#isFrameOpt").wBox({
    requestType: "iframe",
    target:"MemberOperation.aspx?getcode="+Userid
    });
    $("#isFrameOpt").trigger("click");
    //openBrWindow('MemberOperation.aspx?getcode='+Userid,'EditMemberInfo','405','400')  ;
}

 
function doInforEditMem(Userid)
{
    openBrWindow('MemberOperation.aspx?statu=readonly&getcode=' + Userid ,'SeeClassInfoInfo','405','400')  ;
}

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
  
  
     function onAreaSelectChange()
	{		
		var selectArea=document.getElementById('Area_Code');
		var Area = selectArea.value;
		document.all.Site_Code.options.length = 0;
		BindNormalTableToListControl('Site_Code', "id","sitename","tb_site","id","areacode = '" + Area + "'","请选择");
		

	}
	
    </script>

    <script>
WaitHelper.showWaitMessage();
    </script>

</head>
<body style="width: 98%;" >
    <form runat="server" id="Form1">
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
        <ul class="sitemappath">
            <li><strong>车主基本信息</strong></li>
        </ul>
        <div class="appsection">
            <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 100%" id="TABLE1" runat="server">
                <tr>
                    <th style="height: 18px; width: 220px;">
                        车牌号</th>
                    <td style="height: 18px; width: 302px;">
                        <input type="text" class="inputblue" style="width: 100px" id="Card" runat="server"
                            name="Card" maxlength="30" /></td>
                    <th style="height: 18px; width: 136px;">
                        姓名</th>
                    <td style="height: 18px;">
                        <input type="text" class="inputblue" style="width: 100px" id="RealName" runat="server"
                            name="RealName" maxlength="10" /></td>
                    <th style="height: 18px; width: 208px;">
                        性别</th>
                    <td style="height: 18px; width: 307px;">
                        <select class="inputblue" style="width: 104px" id="Gender" runat="server" name="Gender">
                            <option value="" selected="selected">全部</option>
                            <option value="1">男</option>
                            <option value="0">女</option>
                        </select></td>
                </tr>
                <tr>
                    <th style="height: 18px; width: 220px;">
                        注册时间</th>
                    <td style="height: 18px;" colspan="5">
                        <input type="text" class="inputblue" style="width: 100px" id="addeddate1" runat="server"
                            onfocus="setday(this)" vdisp="起始时间" vtype="date" name="addeddate1" maxlength="20" readonly="readOnly"  onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})"/>～<input
                                type="text" class="inputblue" style="width: 100px" id="addeddate2" runat="server"
                                onfocus="setday(this)" vdisp="截止时间" vtype="date" name="addeddate2" maxlength="20" readonly="readOnly" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" /></td>
                </tr>
                <tr>
                    <td align="right" colspan="6" style="height: 18px">
                        &nbsp;<input type="button" name="btnCon" class="btn003" value="新增" onclick="doInfornew1()"
                            id="btnNew" runat="server" visible="false" />
                        <asp:Button ID="btnOut" runat="server" Text="导出" class="btn003" OnClick="btnOut_Click" Visible="false" />&nbsp;<input type="button" name="btnCon" class="btn003" value="查询" id="Button3" runat="server"
                            onserverclick="Button3_ServerClick" onclick="if(!checkdate('addeddate1','addeddate2'))  return false;" />
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div class="appsection" id="search_result" runat="server">
            <div class="apphead">
                <img src="../images/bullet02.gif" class="appfollowimg" alt="" /><strong>车主信息</strong></div>
            <asp:GridView Width="100%" PageSize="15" ID="GridView1" runat="server" SkinID="GridView_Blue"
                AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" 
                DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:TemplateField HeaderText="车牌号">
                        <ItemTemplate>
                            <%# Eval("Card")%>
                        </ItemTemplate>
                        <ItemStyle CssClass="tbody_th" />
                        <HeaderStyle Width="100px" />
                    </asp:TemplateField>
        
                          <asp:TemplateField HeaderText="姓名">
                <HeaderStyle Width="80px" />
                <ItemTemplate>
                    <a href="javascript:void(0)" onclick="doInforEditMem('<%# Eval("UserId")%>');"><%# Eval("RealName")%></a>
                </ItemTemplate>
                              <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
                    <asp:BoundField DataField="sex" HeaderText="性别">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BirthDate" HeaderText="生日" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CellPhone" HeaderText="手机号" >
                   
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Points" HeaderText="当前积分(＄)" >
                   
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Expenditure" HeaderText="累计消费(￥)" >
                   
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="addeddate" HeaderText="注册时间" >
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField ShowHeader="False">
                        <ControlStyle Width="55px" />
                        <ItemTemplate>
                            <a href="javascript:void(0)" onclick="doInforEdit('<%# Eval("UserId")%>')">
                                <span style="color:orange">[编辑]</span></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Panel ID="delPanel" runat="server" Width="100%">
            </asp:Panel>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" MaximumRowsParameterName="pageSize"
            OnSelecting="ObjectDataSource1_Selecting" SelectCountMethod="GetObjectsCount"
            SelectMethod="GetPagedObjects" SortParameterName="sortedBy" StartRowIndexParameterName="startIndex"
            TypeName="Ims.Member.BLL.MemberHelperBLL" OldValuesParameterFormatString="">
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
