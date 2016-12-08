<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="FileManager.aspx.cs" Inherits="Utility_FileManager" StylesheetTheme="app" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>文件管理器</title>
<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/app.edit.js"></script>
<script type="text/javascript" src="../Utility/downloadfile.js"></script>
<script>
var parentControlId='<%=parentControlId%>';

function btnClose_onclick() {
    window.close();
}

function btnOk_onclick() {
    var parentWin = GetParentWindow();
    if(parentWin != null)
    {
        
        var parentControl = parentWin.document.getElementById(parentControlId);
        if(parentControl != null)
        {
            var fileView = document.getElementById("FileView");
            var values = GridViewHelper.getCheckedValues("selectRadioButton1",true,false);
            if(values.length >0)
            {
                parentControl.value = values[0];
            }
        }
    }
    window.close();
}

function openPath(thisPath)
{
    form1.currentPath.value = thisPath;
    form1.submit();
}
function doOnLoad()
{
    GridViewHelper.setSelectRadio("selectRadioButton1",'<%=currentFile%>');
}
</script>
</head>

<body style="width:720px" onload="doOnLoad()">
<ul class="sitemappath" style="width:700px"><li><strong>文件管理器</strong></li></ul>
<form runat="server" id="form1">
    <asp:GridView EnableViewState="false" ID="FileView" runat="server" Width="700px" SkinID="GridViewNoPaging_Red" >
    <Columns>
        <asp:TemplateField>
        <ItemTemplate><%#Eval("fileselect")%></ItemTemplate>
        <ItemStyle CssClass="tbody_th"  />
        <HeaderStyle Width="25px" />
        </asp:TemplateField>
        
        <asp:TemplateField>
         <ItemTemplate><%#Eval("pathurl")%>
        </ItemTemplate>
        <HeaderTemplate>文件名</HeaderTemplate>
        <HeaderStyle Width="380px"  />
        </asp:TemplateField>
       
        <asp:BoundField HeaderText="大小" DataField="size" >
            <HeaderStyle Width="89px" />
        </asp:BoundField>

        <asp:BoundField HeaderText="修改时间" DataField="modifieddate" >
            <HeaderStyle Width="193px" />
        </asp:BoundField>

         <asp:TemplateField>
        <ItemTemplate><%#Eval("downloadfile")%></ItemTemplate>
        <HeaderStyle Width="25px" />
        </asp:TemplateField>
       
    </Columns>    
    </asp:GridView>
<div class="section_operators" style="width:700px; text-align:left">
 <input type="hidden" id="currentPath" name="currentPath" value="<%=currentPath.Replace("\\","\\\\")%>" /><input type="hidden" id="rootPath" name="rootPath" value='<%=rootPath.Replace("\\", "\\\\")%>'/>
    <span>上传文件名：</span><asp:FileUpload ID="FileUpload1" runat="server" Width="451px" />
		<input type="button" id="btnUpload" class="btn002" value="上传" runat="server" onserverclick="btnUpload_ServerClick" />
	<input type="button" id="btnOk" class="btn002" value="确定" onclick="btnOk_onclick()" />
	<input type="button" id="btnClose" class="btn002" value="关闭" onclick="btnClose_onclick()" />
	</div>

</form>
</body>
</html>
