<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserCardInfo.ascx.cs"
    Inherits="usercontrol_UserCardInfo" %>
<link rel="stylesheet" href="../css/table.css" />
<style type="text/css">
    .style2
    {
        height: 18px;
        width: 112px;
    }
    .style3
    {
        height: 18px;
        width: 150px;
    }
    .style4
    {
        width: 91px;
    }
    .style5
    {
        width: 92px;
    }
    .style6
    {
        width: 90px;
    }
    .style7
    {
        width: 2px;
    }
    .style8
    {
        width: 150px;
    }
</style>

<div class="appsection">
    <table cellpadding="1" cellspacing="1" style="width: 800px">
        <tr>
            <th class="style8">
                请输入车牌/手机号&nbsp;
            </th>
            <td class="style2">
                <table>
                    <tr>
                        <td>
                            <input type="text" class="xyin_s" id="card" runat="server"
                                name="card" vdisp="卡号" maxlength="16" />
                        </td>
                          <td style="width: 30px">
                        </td>
                        <td>
                            <input id="BtnSearch" type="button" value="查询" onclick="cardinfo()" class="btn2"
                                 />&nbsp;
                        </td>                      
                        <td>
                            <input type="text" class="inputblue " id="UserId" style="width: 1px; display: none"
                                runat="server" maxlength="20" name="UserId" readonly="readOnly" />
                            <input type="text" id="status" runat="server" style="width: 1px; display: none" name="status"
                                readonly="readonly" />
                            <input type="text" class="inputblue " id="Margcard" style="width: 1px; display: none"
                                runat="server" maxlength="20" name="Margcard" readonly="readOnly" />
                            <input type="text" class="inputgreen " id="SITEID" style="width: 2px; display: none"
                                runat="server" maxlength="20" name="SITEID" readonly="readOnly" />
                            <input type="text" class="inputgreen " id="balance" style="width: 2px; display: none"
                                runat="server" maxlength="20" name="balance" readonly="readOnly" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <th class="style3">
                &nbsp;
            </th>
            <td style="height: 18px; width: 742px;">
                姓名：<asp:Label ID="lbName" runat="server"> </asp:Label>客户类型：<asp:Label ID="lbRank"
                    runat="server"> </asp:Label><div style="display: none;">
                        <asp:Label ID="Labelsummbermoney" runat="server"></asp:Label></div>
                <%--余额：--%>
                <div style="display: none;">
                    <asp:Label ID="LabelPoints" runat="server"></asp:Label></div>
                积分：<asp:Label ID="lbPoint" runat="server"></asp:Label>账户余额：<asp:Label ID="lbBalance"
                    runat="server"></asp:Label>&nbsp; <a href="javascript:void(0)" onclick="document.all('member').click();"
                        style="text-decoration: none;">显示会员详细资料↓</a>
            </td>
        </tr>
    </table>
</div>
<div class="appsection" id="search_result" runat="server">
    <div class="appsection">
        <div class="apphead">
            <img id="member" src="../images/icon-login-seaver.gif" 
                onclick="switchAppSection()" alt="" /><strong>
                车主信息</strong></div>
        <table cellpadding="1" cellspacing="1" style="border: 1px dashed whitesmoke;
            margin-left: 90px; width: 600px;">
            <tr>
                <th style="height: 18px;" class="style5" colspan="4">
                    &nbsp;
                </th>
            </tr>
            <tr>
                <th class="style6">
                    车主姓名：
                </th>
                <td class="style12">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="RealName" runat="server"
                        name="RealName" vdisp="卡号" maxlength="5" readonly="readonly" />
                </td>
                <th class="style6">
                    手机号码：
                </th>
                <td class="style14">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="CellPhone" runat="server"
                        name="CellPhone" vdisp="" maxlength="11" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <th class="style6">
                    客户类型：
                </th>
                <td class="style16">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="RankName" runat="server"
                        name="RankName" vdisp="卡号" maxlength="10" readonly="readonly" />
                </td>
                <th class="style17">
                    会员生日：
                </th>
                <td class="style18">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="Birthday" runat="server"
                        name="Birthday" vdisp="卡号" maxlength="20" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <th class="style6">
                    车主性别：
                </th>
                <td class="style12">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="sex" runat="server"
                        name="sex" vdisp="卡号" maxlength="2" readonly="readonly" />
                </td>
                <th class="style4">
                    客户状态：
                </th>
                <td class="style14">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="StatuName" runat="server"
                        name="StatuName" vdisp="卡号" maxlength="5" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <th class="style6">
                    账户积分：
                </th>
                <td class="style12">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="Points" runat="server"
                        name="Points" vdisp="卡号" maxlength="10" readonly="readonly" />
                </td>
                <th class="style4">
                    联系地址：
                </th>
                <td class="style14">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="Address" runat="server"
                        name="Address" vdisp="卡号" maxlength="100" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <th class="style6">
                    开卡时间：
                </th>
                <td class="style12">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="ActiveTime" runat="server"
                        name="ActiveTime" vdisp="卡号" maxlength="20" readonly="readonly" />
                </td>
                <th class="style4">
                    开户地点：
                </th>
                <td class="style14">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="SiteName" runat="server"
                        name="SiteName" vdisp="卡号" maxlength="50" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <th class="style6">
                    证件类型：
                </th>
                <td class="style12">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="idtype" runat="server"
                        name="idtype" vdisp="卡号" maxlength="10" readonly="readonly" />
                </td>
                <th class="style4">
                    证件号码：
                </th>
                <td class="style14">
                    &nbsp;
                    <input type="text" class="inputgreen" 
                        style="border-style: none none dotted none; border-width: 1px; border-color: #C0C0C0; width: 150px; background-color: transparent;" 
                        id="idno" runat="server"
                        name="idno" vdisp="卡号" maxlength="18" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <th style="height: 18px; color: #C0C0C0;" class="style7" colspan="4">
                    &nbsp;
                </th>
            </tr>
        </table>
    </div>
</div>
