<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="main_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MENU</title>
    <link rel="stylesheet" type="text/css" href="css/zzsc.css"/>
<script type="text/javascript" src="js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="firstpane" class="menu_list">
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller")!=""){ %>
    <p class="menu_head current" title="1.会员信息&#10;2.余额提醒&#10;3.过期卡片&#10;4.流失客户&#10;5.积分兑换">车主信息管理</p>
    <div style="display:block" class="menu_body" >
      <a href="../Member/MemberList.aspx" target="main">车主信息</a>
            <a href="../Card/CardTypeList.aspx" target="main">类型管理</a>
      <a href="../Card/CardBalanceWarn.aspx" target="main">余额提醒</a>
      <a href="../Report/Rpt_Memberlost.aspx" target="main">过期账户</a>
      <a href="../Report/Rpt_LostMember.aspx" target="main">流失客户</a>
       <%if (Ims.Main.ImsInfo.UserIsInRoles("admin1,seller1")!=""){ %>
      <a href="../Member/IntegralExchange.aspx" target="main">积分兑换</a>
      <a href="../Member/IntegralExchangeList.aspx" target="main">兑换记录</a>
       <%} %>
    </div>
    <%} %>
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,channel") != "") {%> 
    <p class="menu_head" title="1.卡片信息&#10;2.卡片挂失&#10;3.卡片解挂&#10;4.会员补卡&#10;5.密码重置&#10;6.卡片延期&#10;7.补卡记录">账户信息管理</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Card/CardList.aspx" target="main">帐户信息</a>
      <a href="../CardHold/CardLock.aspx" target="main">帐户挂失</a>
      <a href="../CardHold/CardUnLock.aspx" target="main">帐户解挂</a>
      <a href="../CardHold/CardPassReset.aspx" target="main">密码重置</a>
      <a href="../CardHold/CardDelay.aspx" target="main">账户延期</a>
      <a href="../CardHold/CardRenew.aspx" target="main">车牌变更</a>
      <a href="../Card/CardRecord.aspx" target="main">车牌变更记录</a>
    </div>
    <%} %>
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel")!=""){%> 
    <p class="menu_head" title="1.终端交易记录查询&#10;2.系统充值记录查询&#10;3.发卡综合统计">车位路段管理</p>
    <div style="display:none" class= "menu_body" >
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin")!=""){%> 
       <a href="../ST/AreaList.aspx" target="main">停车区域管理</a>
        <%} %>
      <a href="../ST/SiteList.aspx" target="main">街道路段管理</a>
      <a href="../ST/parkSiteinfo.aspx" target="main">车位信息管理</a>   
      <a href="../ST/RepeaterList.aspx" target="main">中继网关信息</a>
      <a href="../ST/MagicList.aspx" target="main">地磁微卡信息</a>
      <a href="../ST/parkSiteinfo.aspx" target="main">收费终端管理</a>
       <a href="../ST/PosOperatorList.aspx" target="main">终端收费员管理</a>
       <a href="../ST/PosposList.aspx" target="main">终端机管理</a>
    </div>
    <%} %>
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin1,seller1") != ""){%>
    <p class="menu_head" title="1.卡片类型管理&#10;2.类型转换记录&#10;3.充值赠送规则&#10;4.待激活会员卡&#10;5.新卡退卡退款&#10;6.批量发卡制卡&#10;7.卡片批量激活&#10;8.卡片批量激活&#10;9.发卡综合统计&#10;10.卡片激活记录">月卡月票管理</p>
    <div style="display:none" class= "menu_body" >

      <!---->
      <a href="../Card/CardChargeRuleList.aspx" target="main">充值赠送规则</a>
      <a href="../Card/CardBatchRegistration.aspx" target="main">待激活会员卡</a>
      <!--<a href="../Card/EndCardSelect.aspx" target="main">新卡退卡退款</a>-->
      <%if (Ims.Main.ImsInfo.UserIsInRoles("admin") != ""){%>
      <a href="../Card/SentCard.aspx" target="main">月票发放</a>
      <a href="../Card/CardBatchActive.aspx" target="main">卡片批量激活</a>
      <a href="../Card/CardBathchAdjust.aspx" target="main">批量类型转换</a>
      <a href="../Card/CardTurnTypeRecordList.aspx" target="main">类型转换记录</a>
      <%} %>
      <a href="../Card/CardToExec.aspx" target="main">发卡综合统计</a>
      <a href="../Card/CardActiveSelect.aspx" target="main">卡片激活记录</a>
    </div>
    <%} %>
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel")!=""){%> 
    <p class="menu_head" title="1.终端交易记录查询&#10;2.系统充值记录查询&#10;3.发卡综合统计">常用查询统计</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Report/Rpt_PosTransDetail.aspx" target="main">停车记录查询</a>
      <%if(Ims.Main.ImsInfo.UserIsInRoles("admin")!=""){%> 
      <!--<a href="../Sysem/Cardchargelist.aspx" target="main">充值记录查询</a>
      <a href="../Card/CardToExec.aspx" target="main">发卡综合统计</a>-->
      <%} %>
    </div>
    <%} %>
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin,manager")!=""){%> 
    <p class="menu_head" title="1.终端交易记录查询&#10;2.系统充值记录查询&#10;3.退卡明细查询&#10;4.每日充值统计&#10;5.发卡综合统计&#10;6.商户消费统计&#10;7.机号消费统计&#10;8.营业员充值统计&#10;9.营业员结算记录">综合查询统计</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Report/Rpt_PosTransDetail.aspx" target="main">停车记录查询</a>
      <!--<a href="../Sysem/Cardchargelist.aspx" target="main">充值记录查询</a>
      <a href="../Sysem/ExitCard.aspx" target="main">临时卡退卡明细</a>-->
      <!--<a href="../Sysem/ToDayCZRecord.aspx" target="main">每日充值统计</a>-->
      <!--<a href="../Card/CardToExec.aspx" target="main">发卡综合统计</a>-->
      <a href="../Report/Rpt_SiteCount.aspx" target="main">路段营收统计</a>
      <a href="../Report/Rpt_AllBranchData.aspx" target="main">机号营收统计</a>
      <!--<a href="../Report/Rpt_PosUser.aspx" target="main">营业员充值统计</a>-->
      <!--<a href="../Sysem/CardChargeStatics.aspx" target="main">营业员结算记录</a>-->
    </div>
    <%} %>
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin,manager")!=""){%> 
    <p class="menu_head" title="1.报表清单">收费明细管理</p>
    <div style="display:none" class= "menu_body" >
      <a href="../ReportViewer/RptList.aspx" target="main">进出场明细</a>
      <a href="../ReportViewer/RptList.aspx" target="main">收费明细</a>
      <a href="../ReportViewer/RptList.aspx" target="main">10分钟免收停车明细</a>
    </div>
    <%} %>
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin,manager")!=""){%> 
    <p class="menu_head" title="1.报表清单">数据清单报表</p>
    <div style="display:none" class= "menu_body" >
      <a href="../ReportViewer/RptList.aspx" target="main">报表清单</a>
    </div>
    <%} %>
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin")!=""){%> 
    <p class="menu_head" title="1.区域管理&#10;2.分店管理&#10;3.POS操作员&#10;4.系统备份&#10;5.数据维护&#10;6.操作日志">系统综合管理</p>
    <div style="display:none" class= "menu_body" >

      <a href="../Admin/UserListByAuthority.aspx?type=adminlist&code=1" target="main">系统用户管理</a>
     <a href="../Utility/TestDCCloundInterface.aspx" target="main">测试地磁网关</a>
      <a href="../Sysem/ManagementData.aspx" target="main">系统备份</a>
      <a href="../Sysem/DataMaintenance.aspx" target="main">数据记录维护</a>
      <a href="../Report/Rpt_OperationLog.aspx" target="main">系统操作日志</a>
    </div>
    <%} %>
</div>
<script type = "text/javascript">
$(document).ready(function(){
	$("#firstpane .menu_body:eq(0)").show();
	$("#firstpane p.menu_head").click(function(){
		$(this).addClass("current").next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
		$(this).siblings().removeClass("current");
	});
	$("#secondpane .menu_body:eq(0)").show();
	$("#secondpane p.menu_head").mouseover(function(){
		$(this).addClass("current").next("div.menu_body").slideDown(500).siblings("div.menu_body").slideUp("slow");
		$(this).siblings().removeClass("current");
	});
	
});
</script>
    </form>
</body>
</html>
