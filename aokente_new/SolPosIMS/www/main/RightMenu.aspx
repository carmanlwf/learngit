<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RightMenu.aspx.cs" Inherits="main_RightMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />

    <title>快捷菜单</title>
        <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
       <link rel="stylesheet" href="../css/table.css" />

    <script type="text/javascript">

function doOnLoad()
{
    setAutoHidden();
//    setPopupSection("callInfoSectionImg",form1.callInfoSectionStatus.value);
//    setPopupSection("querylistSectionImg",form1.querylistSectionStatus.value);
//    setPopupSection("hisPhoneListImg",form1.phoneList.value);
}

function setAutoHidden()
{
	var followImg = document.getElementById("autohiddenimg");
	var rightfollowImg = top.document.getElementById("rightfollowImg");
	if(rightfollowImg.onmousemove != null )
	{
		followImg.src = "../images/autohidden2.gif";
	}else
	{
		followImg.src = "../images/autohidden1.gif";
	}
}

function switchAutoHidden()
{
	var followImg = document.getElementById("autohiddenimg");
	var rightfollowImg = top.document.getElementById("rightfollowImg");
	if(rightfollowImg.onmousemove != null )
	{
		followImg.src = "../images/autohidden1.gif";
		rightfollowImg.onmousemove = null;
	}else
	{
		followImg.src = "../images/autohidden2.gif";
		rightfollowImg.onmousemove = rightfollowImg.onclick;
	}
}
function getCurrentCustomerId()
{
    var cust_id = curCustInfo.getCurrentCustomerId();
    return cust_id;
}

function refreshCallInfoList()
{
    hisCallInfoList.refreshCallInfoList(); 
}


function doReloadCustInfo(url)
{
    try
    {
        curCustInfo.WaitHelper.showWaitMessage();
    }catch(e){}
    curCustInfo.location.href = url;
    hisCustServiceList.location.href = hisCustServiceList.location.href;
    
}
function refleshCurrentCustomerInfo()
{
    try
    {
        curCustInfo.WaitHelper.showWaitMessage();
    }catch(e){}
    curCustInfo.location.href = curCustInfo.location.href;
}
    </script>

    <script type="text/javascript">

    function szrc(){
        document.getElementById('szrbb').style.display="none";
        document.getElementById('szrc').style.display="none";
        document.getElementById('szr').style.display="inline";
    }
    function szr(){
        document.getElementById('szrbb').style.display="none";
        document.getElementById('szr').style.display="none";
        document.getElementById('szrc').style.display="inline";
    }
    function szrbb(){
        document.getElementById('szrc').style.display="none";
        document.getElementById('szr').style.display="none";
        document.getElementById('szrbb').style.display="inline";
    }
    
    </script>
    
<script type="text/javascript">
    function one(){
        parent.document.getElementById("main").src="Consume/AddPointsByConsume.aspx";
    }
    function two(){
        parent.document.getElementById("main").src="Consume/AddPointsByProdcut.aspx";
    }
    
    function three(){
        parent.document.getElementById("main").src="Consume/ConsumeByTimes.aspx";
    }
    
    function four(){
        parent.document.getElementById("main").src="Member/MemberRechargeMoney.aspx";
    }
    function five(){
        parent.document.getElementById("main").src="Member/MemberRechargeTimes.aspx";
    }
    function six(){
        parent.document.getElementById("main").src="User/Member_Add.aspx";
    }
    function seven(){
        parent.document.getElementById("main").src="User/Member_List.aspx";
    }
    function eight(){
        parent.document.getElementById("main").src="Member/MemberChangeCard.aspx";
    }
    function nine(){
        parent.document.getElementById("main").src="Report/Rpt_TransRecord.aspx";
    }
    function ten(){
        parent.document.getElementById("main").src="Member/MemberRechargeMoney.aspx";
    }
    function eleven(){
        parent.document.getElementById("main").src="Member/MemberRechargeMoney.aspx";
    }
</script>

<script type="text/javascript">
    function one2(){
        top.leftnavframe.nav("../ST/AreaList.aspx");
    }
    function two2(){
        top.leftnavframe.nav("../ST/SiteList.aspx");
    }
    
    function three2(){
        top.leftnavframe.nav("../Sysem/ManagementData.aspx");
    }
    
    function four2(){
        top.leftnavframe.nav("../Admin/UserListByAuthority.aspx?type=adminlist&code=1");
    }
    function five2() {
        top.leftnavframe.nav("../Admin/UserListByAuthority.aspx?type=adminlist&code=1");
    }
    function six2(){
        top.leftnavframe.nav("../ST/PosOperatorList.aspx");
    }
    function seven2() {
        top.leftnavframe.nav("../Sysem/DataMaintenance.aspx");
    }
    function eight2() {
        top.leftnavframe.nav("../ST/SiteList.aspx");
    }
    function nine2() {
        top.leftnavframe.nav("../Report/Rpt_PosTransDetail.aspx");
    }
    function ten2() {
        top.leftnavframe.nav("../Report/Rpt_OperationLog.aspx");
    }
</script>

<script type="text/javascript">
    function one3(){
        parent.document.getElementById("main").src = "../Report/Rpt_PosTransDetail.aspx";
    }
    function two3(){
        parent.document.getElementById("main").src = "../Report/Rpt_ConsumePoint.aspx";
    }
    
    function three3(){
        parent.document.getElementById("main").src = "../Report/Rpt_LostMember";
    }
    
    function four3(){
        parent.document.getElementById("main").src="Report/Rpt_PosTransDetail_AgentAndManager.aspx";
    }
    function five3(){
        parent.document.getElementById("main").src="Product/POSOrdersList.aspx";
    }
    function six3(){
        parent.document.getElementById("main").src="Report/Rpt_PosTransDetail.aspx";
    }
    function seven3(){
        parent.document.getElementById("main").src="Report/Rpt_ChongZhi.aspx";
    }
    function eight3(){
        parent.document.getElementById("main").src="Report/Rpt_BranchData.aspx";
    }
    function nine3(){
        parent.document.getElementById("main").src="Member/MemberChangeCard.aspx";
    }
    function ten3(){
        parent.document.getElementById("main").src="Report/Rpt_TransRecord.asp";
    }
    function eleven3(){
        parent.document.getElementById("main").src="Report/Rpt_TransRecord.aspx";
    }
    function twelve3(){
        parent.document.getElementById("main").src="Report/Rpt_TransRecord.aspx";
    }
    function thirteen3(){
        parent.document.getElementById("main").src="Report/Rpt_OperationLog.aspx";
    }
    function fourteen3(){
        parent.document.getElementById("main").src="Report/Rpt_TransRecord.aspx";
    }
</script>



</head>
<%--<body onload="doOnLoad(),correctPNG()">--%>
<body onload="doOnLoad()">
    <form runat="server" id="form1">
        <div class="mainright">
            <div class="mainright-div1" style="height: 25px">
                <ul style="background-color: #CADCF0">
                    <li>
                    <th colspan="2" style="font-weight: bold; width: 120px; color: white; height: 25px;
                    background-color: #CADCF0; text-align: left; ">
                    <span style="margin-top:8px;width: 120px; font-weight:bold; color:gray;">∴账户信息查询</span></th></li>
                    <li id="mainright-div1-li3" class="mainright-div1-li3" style="display:none;"><a href="javascript:;" onclick="szrbb()"><img src="r_img/r_tj.jpg" alt="报表统计" style="display:none;"/></a></li>
                    <li id="Li1"><img id="autohiddenimg" onclick="switchAutoHidden()" class="titlepopupimg" alt="自动隐藏" /></li>
                </ul>
            </div>
            <div class="mainright-div2"><div id="szrc" style="left: 0px; top: 0px">
        <table cellpadding="1" cellspacing="0" style="width: 230px">
    <tr>
        <th style="height: 25px; border-bottom: #D5D9DD 1px solid; font-weight: bold;">
            车牌号</th>
        <td style="height: 25px; border-bottom: #D5D9DD 1px solid;">
            <input id="Card" runat="server" class="inputgreen" maxlength="16" name="Card"
                 style="width: 95px" type="text" vdisp="起始时间" vtype="date" />
            <input id="Button1" style="border-right: #D5D9DD 1px solid; border-top: #D5D9DD 1px solid;
                border-left: #D5D9DD 1px solid; width: 40px; color: #D5D9DD; border-bottom: #D5D9DD 1px solid;
                height: 20px; background-color: #ffffff" type="button" value="搜索" 
                onserverclick="Button1_ServerClick" runat="server" class="btn003" /></td>
    </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    姓 名：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="RealName" runat="server" class="inputgreen" maxlength="20" name="RealName"
                style="width: 140px" type="text" vdisp="姓 名" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    性 别：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="sex" runat="server" class="inputgreen" maxlength="20" name="sex"
                style="width: 140px" type="text" vdisp="性 别" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    手 机：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="CellPhone" runat="server" class="inputgreen" maxlength="20" name="CellPhone"
                 style="width: 140px" type="text" vdisp="手 机" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    类 型：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="RankName" runat="server" class="inputgreen" maxlength="20" name="RankName"
                 style="width: 140px" type="text" vdisp="等 级" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    状 态：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="statusname" runat="server" class="inputgreen" maxlength="20" name="statusname"
                 style="width: 140px" type="text" vdisp="状 态" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    余 额：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="Balance" runat="server" class="inputgreen" maxlength="20" name="Balance"
                style="width: 140px" type="text" vdisp="余 额" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    积 分：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="Points" runat="server" class="inputgreen" maxlength="20" name="Points"
                style="width: 140px" type="text" vdisp="积 分" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    消费总额：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="Expenditure" runat="server" class="inputgreen" maxlength="20" name="Expenditure"
                style="width: 140px" type="text" vdisp="消费总额" vtype="date" /></td>
            </tr>
            <tr style="display:none;">
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    发卡门店：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="sitename" runat="server" class="inputgreen" maxlength="20" name="sitename"
                 style="width: 140px" type="text" vdisp="发卡门店" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    注册时间：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="addeddate" runat="server" class="inputgreen" maxlength="20" name="Points"
                 style="width: 140px" type="text" vdisp="注册时间" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    有效日期：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    <input id="validDate" runat="server" class="inputgreen" maxlength="20" name="validDate"
                 style="width: 140px" type="text" vdisp="有效日期" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    上次消费：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px"><input id="LastConsumeTime" runat="server" class="inputgreen" maxlength="20" name="LastConsumeTime"
                 style="width: 140px" type="text" vdisp="上次消费" vtype="date" /></td>
            </tr>
            <tr>
                <th colspan="2" style="font-weight: bold; width: 100px; color: white; height: 20px;
                    background-color: #CADCF0; text-align: left">
                    <font color="gray">∴当前登录信息</font></th>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    帐 号：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px; text-align: left;">
                    <asp:Label ID="Label1" runat="server" Text="未知"></asp:Label></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    姓 名：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px; text-align: left;">
                    <asp:Label ID="Label2" runat="server" Text="未知"></asp:Label></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    本 机：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px; text-align: left;">
                    <asp:Label ID="Label3" runat="server" Text="未知"></asp:Label></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    服务器：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px; text-align: left;">
                    <asp:Label ID="Label4" runat="server" Text="未知"></asp:Label></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px">
                    版本号：</th>
                <td style="color: gray; border-bottom: #D5D9DD 1px solid; height: 25px; text-align: left;">
                    <asp:Label ID="Label5" runat="server" Text="未知"></asp:Label></td>
            </tr>
    <tr>
        <td align="right" colspan="4">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
    </tr>
</table>
</div>
            
                
                <!---->
                <div id="szr" style=" margin-left:20px;">
                    <div style="margin-top:20px;">
                        <ul>
                            <li class="szr-l">
                                <p class="szr-lp1">
                                    <a href="javascript:;" onclick="one2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-1.jpg" alt="区域管理" /></a></p>
                                <p class="szr-lp2">
                                    区域管理</p>
                            </li>
                            <li class="szr-l">
                                <p class="szr-lp1">
                                    <a href="javascript:;" onclick="two2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-2.jpg" alt="分店管理" /></a></p>
                                <p class="szr-lp2">
                                    分店管理</p>
                            </li>
                            <li class="szr-r">
                                <p class="szr-rp1">
                                    <a href="javascript:;" onclick="three2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-3 (2).jpg" alt="数据备份" /></a></p>
                                <p class="szr-rp2">
                                    数据备份</p>
                            </li>
                        </ul>
                        <ul>
                            <li class="szr-l">
                                <p class="szr-lp1">
                                    <a href="javascript:;" onclick="four2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-4.jpg" alt="系统用户" /></a></p>
                                <p class="szr-lp2">
                                    系统用户</p>
                            </li>
                            <li class="szr-l">
                                <p class="szr-lp1">
                                    <a href="javascript:;" onclick="five2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-5.jpg" alt="分店店长" /></a></p>
                                <p class="szr-lp2">
                                    分店店长</p>
                            </li>
                            <li class="szr-r">
                                <p class="szr-rp1">
                                    <a href="javascript:;" onclick="six2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-6.jpg" alt="POS操作员" /></a></p>
                                <p class="szr-rp2">
                                    POS操作员</p>
                            </li>
                        </ul>
                        <ul>
                            <li class="szr-l">
                                <p class="szr-lp1">
                                    <a href="javascript:;" onclick="seven2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-7.jpg" alt="数据维护" /></a></p>
                                <p class="szr-lp2">
                                    数据维护</p>
                            </li>
                            <li class="szr-l">
                                <p class="szr-lp1">
                                    <a href="javascript:;" onclick="eight2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-8.jpg" alt="设备维护" /></a></p>
                                <p class="szr-lp2">
                                    设备维护</p>
                            </li>
                            <li class="szr-r">
                                <p class="szr-rp1">
                                    <a href="javascript:;" onclick="nine2()">
                                        <img class="tm" src="./r_m_img/num2/mainright-9.jpg" alt="交易记录" /></a></p>
                                <p class="szr-rp2">
                                    交易记录</p>
                            </li>
                        </ul>
                        <ul>
                            <li class="szr-l">
                                <p class="szr-lp1">
                                    <a onclick="ten2()" href="javascript:;">
                                        <img class="tm" src="./r_m_img/num2/mainright-10.jpg" alt="操作日志" /></a></p>
                                <p class="szr-lp2">
                                    操作日志</p>
                            </li>
                        </ul>
                    </div>
                </div>

                <!------->


<div id="szrbb" >
                                        <div style="margin-top:20px; display:none;">
                        <ul>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="one3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="消费统计" /></a></p>
                                <p class="szrbb-lp2">
                                    消费统计</p>
                            </li>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;"onclick="two3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt=" 积分统计" /></a></p>
                                <p class="szrbb-lp2">
                                    积分统计</p>
                            </li>
                            <li class="szrbb-r">
                                <p class="szrbb-rp1">
                                    <a href="javascript:;" onclick="three3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="流失客户" /></a></p>
                                <p class="szrbb-rp2">
                                    流失客户</p>
                            </li>
                        </ul>
                        <ul>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="four3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="兑换统计" /></a></p>
                                <p class="szrbb-lp2">
                                    兑换统计</p>
                            </li>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="five3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="充次统计" /></a></p>
                                <p class="szrbb-lp2">
                                    充次统计</p>
                            </li>
                             <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="six3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="流水统计" /></a></p>
                                <p class="szrbb-lp2">
                                    流水统计</p>
                            </li>
                        </ul>
                        <ul>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="seven3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="销售统计" /></a></p>
                                <p class="szrbb-lp2">
                                    销售统计</p>
                            </li>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="eight3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="营业统计" /></a></p>
                                <p class="szrbb-lp2">
                                    营业统计</p>
                            </li>
                            <li class="szrbb-r">
                                <p class="szrbb-rp1">
                                    <a href="javascript:;" onclick="nine3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="流失统计" /></a></p>
                                <p class="szrbb-rp2">
                                    流失统计</p>
                            </li>
                        </ul>
                        <ul>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="ten3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="明细统计" /></a></p>
                                <p class="szrbb-lp2">
                                    明细统计</p>
                            </li>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="eleven3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="会员统计" /></a></p>
                                <p class="szrbb-lp2">
                                    会员统计</p>
                            </li>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1" onclick="twelve3()">
                                    <a href="javascript:;">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="过期统计" /></a></p>
                                <p class="szrbb-lp2">
                                    过期统计</p>
                            </li>
                            
                        </ul>
                        <ul>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;"onclick="thirteen3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="排行统计" /></a></p>
                                <p class="szrbb-lp2">
                                    排行统计</p>
                            </li>
                            <li class="szrbb-l">
                                <p class="szrbb-lp1">
                                    <a href="javascript:;" onclick="fourteen3()">
                                        <img class="tm" src="./r_m_img/num3/mainright-10.jpg" alt="综合统计" /></a></p>
                                <p class="szrbb-lp2">
                                    综合统计</p>
                            </li>
                            
                        </ul>
                    </div>
                </div>
                
            </div>
        </div>

      <!--[if IE 6]>
<script type="text/javascript" src="js/png24.js" ></script>
<script type="text/javascript">
DD_belatedPNG.fix('.tm1');
</script>
<![endif]-->
    </form>
</body>
</html>

