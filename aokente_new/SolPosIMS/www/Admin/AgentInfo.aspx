<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="AgentInfo.aspx.cs" Inherits="Admin_AgentInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>用户信息管理</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script>

function postBackByObject()

{

    var o = window.event.srcElement;

    if (o.tagName == "INPUT" && o.type == "checkbox")

    {

       __doPostBack("","");

    } 

}
function SetDefaultValue(input)
{
    if(input.id=="agentid")
    {
        var agentid = document.getElementById("agentid");
        var icmid = document.getElementById("icmid");
        if(icmid.value==null||icmid.value.length==0)
        {
            icmid.value = agentid.value;
        }
        var obid = document.getElementById("obid");
        if(obid.value==null||obid.value.length==0)
        {
            obid.value = agentid.value;
        }
    }
    if(input.id=="pwd")
    {
        var pwd = document.getElementById("pwd");
        var icmpwd = document.getElementById("icmpwd");
        var obpwd = document.getElementById("obpwd");
        if(icmpwd.value==null||icmpwd.value.length==0)
        {
            icmpwd.value = pwd.value;
        }
        if(obpwd.value==null||obpwd.value.length==0)
        {
            obpwd.value = pwd.value;
        }
    }
}
    function Authority() 
    { 
        var curagentid = document.getElementById("curagentid");
        if(curagentid.value == null || curagentid.value == "" ) 
        {
            alert('未分配员工工号用户不能授权！');
            return;
        }

        var url="AgentAuthority.aspx?pub_agentid="+curagentid.value;
        //调转页面
        openBrWindow(url,'AgentAuthority','width=860,height=500');
        
    }
    function BackLogin()
    {
        if(confirm('确认恢复该用户登录状态吗'))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    </script>

</head>
<body>

    <script>
WaitHelper.showWaitMessage();
    </script>

    <form id="form1" runat="server">
        <div class="apphead" style="width: 600px">
            <strong>用户基本信息</strong></div>
        <asp:Panel ID="panelAgent" runat="server" Width="600px">
            <table width="600" cellpadding="1" cellspacing="1" class="table_default table_blue">
                <tr>
                    <th width="100">
                        员工编号</th>
                    <td width="160">
                        <input id="pm_employee_id" name="pm_employee_id" type="text" class="inputgreen readonly ime_engish"
                            style="width: 100px" runat="server" readonly="readOnly" /></td>
                    <th width="100">
                        组号</th>
                    <td>
                        <input id="groupinfo_id" name="groupinfo_id" type="text" class="inputgreen readonly ime_engish"
                            style="width: 100px" runat="server" readonly="readOnly" /></td>
                </tr>
                <tr>
                    <th>
                        姓名</th>
                    <td>
                        <input id="name" name="name" type="text" class="inputgreen readonly" style="width: 100px"
                            runat="server" readonly="readOnly" /></td>
                    <th>
                        性别</th>
                    <td>
                        <input id="sexname" name="sexname" type="text" class="inputgreen readonly" style="width: 100px"
                            runat="server" readonly="readOnly" /></td>
                </tr>
                <tr>
                    <th>
                        员工工号</th>
                    <td>
                        <input id="empid" name="empid" type="text" vdisp="员工工号" voperate="custom"
                            extendname="7位数字" maxlength="7" class="inputgreen ime_engish" style="width: 100px"
                            onfocusout="SetDefaultValue(this)" runat="server" /><span style="color: #ff0000">*</span></td>
                    <th>
                        员工登录密码</th>
                    <td>
                        <input id="pwd" name="pwd" type="text" class="inputgreen ime_engish" style="width: 100px"
                            runat="server" onfocusout="SetDefaultValue(this)" vdisp="员工登录密码" voperate="custom"
                            regexp="^[A-Za-z0-9]{4,8}$" extendname="4-8位字母数字组合" maxlength="8" /><span style="color: #ff0000">*</span></td>
                </tr>
                <tr>
                    <td>
                        <input id="superflag" type="checkbox" name="superflag" value="checkbox" runat="server" disabled="disabled" />
                        super</td>
                    <td>
                        <input id="validflag" type="checkbox" name="validflag" value="checkbox" runat="server"
                            checked="checked" />
                        有效
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <input id="curagentid" type="hidden" runat="server" name="curagentid" value="" />
        <div align="center" style="width: 600px">
            <input id="btnSave" type="button" name="btnCon" class="btn003" value="保存" runat="server"
                onserverclick="btnSave_ServerClick" onclick="if (!doAllMessageBoxValidate(form1)) return false;" />
            &nbsp;&nbsp;
            <input id="btnAuthority" type="button" name="btnAuthority" runat="server" class="btn003"
                value="授权" onclick="Authority()" />
            &nbsp;&nbsp;
            <input id="btnBackLogin" type="button" name="btnBackLogin" runat="server" class="btn003"
                value="恢复" onclick="if (!BackLogin()) return false;"  onserverclick="btnBackLogin_Click"/>
            &nbsp;&nbsp;
            <input id="btnReturn" type="button" name="btnReturn" class="btn003" value="关闭" onclick="JavaScript:window.close()" />
        </div>
    </form>

    <script>
WaitHelper.initWaitMessageForms("form1");  
    </script>

</body>
</html>
