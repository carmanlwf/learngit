<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewSites.aspx.cs" Inherits="Card_viewSites" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>路段基本信息</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />
<script src="../js/app.edit.js" type="text/javascript"></script>
<script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
<script type="text/javascript" src="js/ST.js" charset="gb2312"></script>
<script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
<script src="../js/checkdate.js" type="text/javascript"></script>
<script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>

      <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />

<script type="text/javascript">

    function Map() 
    {
        $("#isFrameMap").wBox({
            wBoxi: "1", //第一个
            requestType: "iframe",
            target: "select_map.html"
        });

        $("#isFrameMap").trigger("click");
    }

    function returnmap(lng, lat) {

        for (var i = 0; i < 3; i++) 
        {
            var name = window.frames[i];
            if (name.name == "wBoxIframe")
            {
                name.returnMap(lng, lat);
            }

        }
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
  
</script>
<script>
WaitHelper.showWaitMessage();
</script>
    <style type="text/css">
        .style2
        {
            height: 18px;
            }
        </style>
</head>
<body style="width:98%;">
<form runat="server" id="Form1">
<a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
<a id="isFrameMap" href="javascript:void(0)" style="display:none">isFrameMap</a>


<div class="appsection" id="search_result" runat="server" >
	<div class="apphead"><img src="../images/bullet02.gif" class="appfollowimg" alt=""/><strong>免费停车路段信息</strong></div> 
	<div style="width:400px; height:250px; overflow:auto">
	<asp:GridView Width="100%" PageSize="10" ID="GridView1" runat="server" 
        SkinID="GridView_AutoWidth_Blue" AllowPaging="false" AutoGenerateColumns="False" 
        AllowSorting="True" DataSourceID="ObjectDataSource1"  >
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# this.GridView1.PageIndex * this.GridView1.PageSize + this.GridView1.Rows.Count + 1%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
           <asp:BoundField DataField="siteid" HeaderText="路段编号" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            
            <asp:BoundField DataField="sitename" HeaderText="路段名称" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            
            <asp:BoundField DataField="areaname" HeaderText="所在区域" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    </div>
</div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    EnablePaging="True" MaximumRowsParameterName="pageSize" 
    OnSelecting="ObjectDataSource1_Selecting"  
    SelectMethod="getSites" SortParameterName="sortedBy" 
    StartRowIndexParameterName="startIndex" TypeName="Ims.Card.BLL.CardViewSitesBLL" 
    OldValuesParameterFormatString="">
        <SelectParameters>
            <asp:Parameter Name="carnum" Type="string" />
        </SelectParameters>
    </asp:ObjectDataSource>
</form>
<script>
WaitHelper.initWaitMessageForms("Form1");  
</script>
</body>
</html>