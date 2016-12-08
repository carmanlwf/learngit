<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AreaOperation.aspx.cs" Inherits="ST_AreaOperation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>区域管理操作</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script language="javascript" type="text/javascript">
    function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);
        window.setTimeout('document.all("btnclose").click();parent.location.href="AreaList.aspx";',1*1000);
    }

    function btnTiJiao_click() {
        var areaname = document.getElementById("areaname").value;

        if (areaname.trim() == "") {
            alert("请输入区域名称！");
            return false;
        }

        var linkman  = document.getElementById("linkman").value;
        if (linkman == "") {
            alert("联系人不能为空！");
            return false;
        }

        var linkphone = document.getElementById("linkphone").value;
        if (linkphone == "") {
            alert("联系电话不能为空！");
        }


        __doPostBack('btnInsert', '');

        return true;
    }
    
    </script>
</head>
<body>

    <script>
WaitHelper.showWaitMessage();
    </script>

    <form id="form1" runat="server">
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
    <div class="appsection">
        <div class="apphead">
            <img src="../images/collapsed_no.gif" class="appfollowimg" onclick="switchAppSection()"
                alt="" /><strong>基本信息</strong></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 400px">
            <tr>
                <th style="height: 18px; width: 95px;">
                    <label style="color: Red; height: 18px;">
                        <span style="color: #1e3739;">区域编号</span><label style="color: Red; height: 18px;">*</label></label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" id="areacode" style="width: 240px" runat="server"
                        maxlength="20" vdisp="区域编号" vmode="not null" name="areacode" />&nbsp;
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 95px;">
                    区域名称<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" id="areaname" style="width: 240px" runat="server"
                        maxlength="15" vdisp="区域名称" vmode="not null" name="areaname" />
                </td>
            </tr>
            <tr>
                <th style="width: 95px; height: 18px">
                    联系人<label style="color: Red; height: 18px;">
                        *</label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" id="linkman" style="width: 240px" runat="server"
                        maxlength="10" vdisp="联系人" vmode="not null" name="linkman" />
                </td>
            </tr>
            <tr>
                <th style="width: 95px; height: 18px">
                    联系电话<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" id="linkphone" style="width: 240px" runat="server"
                        maxlength="15" vdisp="联系电话" vmode="not null" vtype="number" name="linkphone" />
                </td>
            </tr>
            <tr>
                <th style="width: 95px">
                    备注&nbsp;
                </th>
                <td colspan="1">
                    <textarea id="memo" runat="server" class="inputblue" maxlength="200" name="memo"
                        style="width: 240px; height: 50px" vdisp="备注" vtextarea="yes"></textarea>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div class="appsection">
        <div class="section_operators" style="width: 400px" align="center">
            <input id="chflag" runat="server" type="checkbox" style="display: none" />
            <input type="button" id="btnInsert" onclick="return btnTiJiao_click();"
                runat="server" value="提交" class="xybtn" onserverclick="btnInsert_Click" />
            <input type="button" id="btnUpdate" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
                runat="server" value="更新" class="xybtn" onserverclick="btnUpdate_Click" />
            <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" style="display:none;"
                id="Button2" />
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Ims.Site.Model.tb_area"
        InsertMethod="InsertObject" SelectMethod="GetObject" TypeName="Ims.Site.BLL.AreaHelperBLL"
        UpdateMethod="UpdateObject">
        <SelectParameters>
            <asp:Parameter Name="areacode" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>

    <script>
WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
