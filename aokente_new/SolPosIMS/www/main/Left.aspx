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
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,channel,maintenance, area_manager") != "")
      {%> 
    <p class="menu_head current" title="1.停车区域管理&#10;2.街道路段管理&#10;3.车位信息管理&#10;4.终端收费员管理&#10;5.手持终端管理">停车场管理</p>
    <div style="display:block" class= "menu_body" >
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,maintenance") != "")
      {%> 
       <a href="../ST/AreaList.aspx" target="main">经营区域管理</a>
        <%--<%} %>--%>
      <a href="../ST/SiteList.aspx" target="main">街道路段管理</a>
      <a href="../ST/Intemp_feetype.aspx" target="main">收费标准制定</a>
      <a href="../ST/In_Price_Set.aspx" target="main">路段收费设定</a> 
      <a href="../ST/parkSiteinfo.aspx" target="main">车位信息管理</a> 
      <a href="../ST/PosOperatorList.aspx" target="main">收费人员管理</a>
      <a href="../ST/PosposList.aspx" target="main">手持终端管理</a> 
      <%} %>
      <a href="../ST/OperatorSchedule.aspx" target="main">签到时间管理</a>      
       <!--<a href="../GPS_Info/traceinfo.aspx" target="main">执勤轨迹查询</a>-->
      <a href="../GPS_Info/operator_list.aspx" target="main">人员执勤信息</a>
       <!--<a href="../ST/PTracelist_Map.aspx" target="main">围栏报警信息</a>-->
      
    </div>
    <%} %>
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,agent,seller")!=""){ %>
    <p class="menu_head" title="1.车主信息&#10;2.类型管理&#10;3.余额提醒&#10;4.过期账户&#10;5.流失客户">车主信息管理</p>
    <div style="display:none" class="menu_body" >
      <a href="../Member/MemberList.aspx" target="main">车主信息</a>
      <a href="../Card/CardList.aspx" target="main">帐户信息</a>
      <a href="../Card/MonthCardList.aspx" target="main">会员信息</a>
      <a href="../CardMonthly/CardInput.aspx" target="main">用户开卡</a>
      <a href="../CardMonthly/CardInput.aspx" target="main">账户续费</a>
      <a href="../Card/CardTypeList.aspx" target="main">类型管理</a>
      <a href="../Card/CardBalanceWarn.aspx" target="main">余额提醒</a>
      <a href="../Report/Rpt_Memberlost.aspx" target="main">过期账户</a>
      <!--<a href="../Report/Rpt_LostMember.aspx" target="main">流失客户</a>-->
       <%if (Ims.Main.ImsInfo.UserIsInRoles("admin1,seller1")!=""){ %>
      <a href="../Member/IntegralExchange.aspx" target="main">积分兑换</a>
      <a href="../Member/IntegralExchangeList.aspx" target="main">兑换记录</a>
       <%} %>
    </div>
    <%} %>
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin1,channel") != "") {%> 
    <p class="menu_head" title="1.帐户信息&#10;2.帐户挂失&#10;3.帐户解挂&#10;4.密码重置&#10;5.账户延期&#10;6.车牌变更&#10;7.车牌变更记录">账户信息管理</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Card/CardList.aspx" target="main">帐户信息</a>
      <a href="../CardHold/CardLock.aspx" target="main">帐户锁定</a>
      <a href="../CardHold/CardUnLock.aspx" target="main">帐户解锁</a>
            <a href="../CardHold/CardDelay.aspx" target="main">账户延期</a>
      <a href="../CardHold/CardRenew.aspx" target="main">车牌变更</a>
      <a href="../Card/CardRecord.aspx" target="main">车牌变更记录</a>
      <!--<a href="../CardHold/CardPassReset.aspx" target="main">密码重置</a>

      <a href="../Card/CardChargeRuleList.aspx" target="main">充值赠送规则</a>-->
      
    </div>
    <%} %>
    
    

    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,seller1") != ""){%>
    <p class="menu_head" title="1.卡片类型管理&#10;2.类型转换记录&#10;3.充值赠送规则&#10;4.待激活会员卡&#10;5.新卡退卡退款&#10;6.批量发卡制卡&#10;7.卡片批量激活&#10;8.卡片批量激活&#10;9.发卡综合统计&#10;10.卡片激活记录">停车票据管理</p>
    <div style="display:none" class= "menu_body" >
    <a href="../Job/ticket_send.aspx" target="main">票据领取</a>
    <a href="../Job/ticket_sendlist.aspx" target="main">票据领取记录</a>
    <a href="../Job/ticket_statistics.aspx" target="main">票据消耗统计</a>
      <!--
      <a href="../Card/CardChargeRuleList.aspx" target="main">充值赠送规则</a>
      <!--<a href="../Card/CardBatchRegistration.aspx" target="main">待激活会员卡</a>
      <a href="../Card/EndCardSelect.aspx" target="main">新卡退卡退款</a>
      <%if (Ims.Main.ImsInfo.UserIsInRoles("admin") != ""){%>
      <a href="../Card/SentCard.aspx" target="main">月票发放</a>
      <a href="../Card/CardBatchActive.aspx" target="main">卡片批量激活</a>
      <a href="../Card/CardBathchAdjust.aspx" target="main">批量类型转换</a>
      <a href="../Card/CardTurnTypeRecordList.aspx" target="main">类型转换记录</a>
      <%} %>
      <a href="../Card/CardToExec.aspx" target="main">发卡综合统计</a>
      <a href="../Card/CardActiveSelect.aspx" target="main">卡片激活记录</a>-->
    </div>
    <%} %>
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin1,agent,channel")!=""){%> 
    <p class="menu_head" title="1.中继网关信息&#10;2.地磁设备信息&#10;3.地磁状态信息&#10;4.测试地磁网关">地磁信息查询</p>
    <div style="display:none" class= "menu_body" >
      <%if(Ims.Main.ImsInfo.UserIsInRoles("admin")!=""){%> 
      <!--<a href="../ST/RepeaterList.aspx" target="main">中继网关信息</a>
      <a href="../ST/MagicList.aspx" target="main">地磁设备信息</a>-->
      <a href="../ST/MagicStatusList.aspx" target="main">地磁状态信息</a>
      <a href="../Utility/TestDCCloundInterface.aspx" target="main">测试地磁网关</a>
      <%} %>
    </div>
    <%} %>
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,manager,member,small,area_manager,statistician") != "")
      {%> 
    <p class="menu_head" title="1.停车记录查询&#10;2.15钟免停记录查询&#10;3.在场车辆查询&#10;4.应收费车辆查询">停车收费查询</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Report/Rpt_PosTransDetail.aspx" target="main">停车记录查询</a>
      <a href="../Report/Rpt_FreeParkList.aspx" target="main">15钟免停记录查询</a>
      <a href="../Report/Rpt_CarInParkList.aspx" target="main">在场车辆查询</a>
      <a href="../Report/Rpt_CarOutParkList.aspx" target="main">应收费车辆查询</a>

      <!--<a href="../Sysem/Cardchargelist.aspx" target="main">充值记录查询</a>
      <a href="../Sysem/ExitCard.aspx" target="main">临时卡退卡明细</a>-->
      <!--<a href="../Sysem/ToDayCZRecord.aspx" target="main">每日充值统计</a>-->
      <!--<a href="../Card/CardToExec.aspx" target="main">发卡综合统计</a>
      <a href="../Report/Rpt_SiteCount.aspx" target="main">路段营收统计</a>
      <a href="../Report/Rpt_AllBranchData.aspx" target="main">机号营收统计</a>-->
      <!--<a href="../Report/Rpt_PosUser.aspx" target="main">营业员充值统计</a>-->
      <!--<a href="../Sysem/CardChargeStatics.aspx" target="main">营业员结算记录</a>-->
    </div>
    <%} %>
   
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,manager,small,statistician") != "")
      {%> 
    <p class="menu_head" title="1.停车记录查询&#10;2.10钟免停记录查询&#10;3.在场车辆查询&#10;4.应收费车辆查询">财务账单查询</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Pay/pay_paydetail.aspx" target="main">财务流水清单</a>
      <a href="../Pay/pay_owedetail.aspx" target="main">未追缴欠费单</a>
      <a href="../Pay/pay_memberrecord.aspx" target="main">会员开卡记录</a>
      <a href="../Pay/pay_afterwardslist.aspx" target="main">历史欠费记录</a>
      <a href="../Job/job_workturnlist.aspx" target="main">交接班记录</a>
      <a href="../RptChart/AchievementChartByPerson.aspx" target="main">收费业绩统计</a>
      <!--<a href="../RptChart/AchievementChartBySite.aspx" target="main">路段运营统计</a>-->
      <a href="../Sysem/Cardchargelist.aspx" target="main">充值记录查询[平台]</a>
      <a href="../Sysem/ToDayCZRecord.aspx" target="main">每日充值统计[平台]</a>
      <!--<a href="../Sysem/Cardchargelist.aspx" target="main">充值记录查询</a>
      <a href="../Sysem/ExitCard.aspx" target="main">临时卡退卡明细</a>-->
      <!--<a href="../Sysem/ToDayCZRecord.aspx" target="main">每日充值统计</a>-->
      <!--<a href="../Card/CardToExec.aspx" target="main">发卡综合统计</a>
      <a href="../Report/Rpt_SiteCount.aspx" target="main">路段营收统计</a>
      <a href="../Report/Rpt_AllBranchData.aspx" target="main">机号营收统计</a>-->
      <!--<a href="../Report/Rpt_PosUser.aspx" target="main">营业员充值统计</a>-->
      <!--<a href="../Sysem/CardChargeStatics.aspx" target="main">营业员结算记录</a>-->
    </div>
    <%} %>
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin1,admin") != "")
      {%> 
    <p class="menu_head" title="1.报表清单">数据清单报表</p>
    <div style="display:none" class= "menu_body" >
     <%if (Ims.Main.ImsInfo.UserIsInRoles("admin,manager,small,maintenance") != "")
       {%>
      <a href="../ReportViewer/RptList.aspx" target="main">报表清单</a>
     <a href="../ReportViewer/DataBackUp.aspx" target="main">数据备份</a>
      <%} if (Ims.Main.ImsInfo.UserIsInRoles("admin,manager,small,statistician") != "")
       { %>
      <%--<a href="../ReportViewer/AchievementChartByPerson.aspx" target="main">报表视图</a>
      <a href="../ReportViewer/AchievementChartByOne.aspx" target="main">个人报表视图</a>--%>
      <%} %>
    </div>
    <%} %>
    <%if(Ims.Main.ImsInfo.UserIsInRoles("admin")!=""){%> 
    <p class="menu_head" title="1.系统用户管理&#10;2.系统备份&#10;3.数据记录维护&#10;4.系统操作日志">系统综合管理</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Report/Con_banners.aspx"  target="main">发布小票通知</a>
      <a href="../Admin/UserListByAuthority.aspx?type=adminlist&code=1" target="main">系统用户管理</a>
      <!--<a href="../Sysem/ManagementData.aspx" target="main">系统备份</a>
      <a href="../Sysem/DataMaintenance.aspx" target="main">数据记录维护</a>-->
      <a href="../Report/Rpt_OperationLog.aspx" target="main">系统操作日志</a>
    </div>
    <%} %>
     <%if (Ims.Main.ImsInfo.UserIsInRoles("admin1,manager") != ""){%> 
    <p class="menu_head" title="1.帐户信息&#10;2.帐户挂失&#10;3.帐户解挂&#10;4.密码重置&#10;5.账户延期&#10;6.车牌变更&#10;7.车牌变更记录">路外停车管理</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Outdoor/tb_SalesDate.aspx" target="main">路外停车信息</a>
    </div>
    <%} %>
    <%if (Ims.Main.ImsInfo.UserIsInRoles("admin1,manager") != ""){%> 
    <p class="menu_head" title="1.帐户信息&#10;2.帐户挂失&#10;3.帐户解挂&#10;4.密码重置&#10;5.账户延期&#10;6.车牌变更&#10;7.车牌变更记录">交警后台链接管理</p>
    <div style="display:none" class= "menu_body" >
      <a href="../Outdoor/tb_Illegal.aspx" target="main">违章状态信息</a>
    </div>
    <%} %>
    
</div>
<script type = "text/javascript">
    $(document).ready(function() {
        $("#firstpane .menu_body:eq(0)").show();
        $("#firstpane p.menu_head").click(function() {
            $(this).addClass("current").next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
            $(this).siblings().removeClass("current");
            //$("#firstpane .menu_body a").css("background-color", "#ffffff")
        });
        $("#secondpane .menu_body:eq(0)").show();
        $("#secondpane p.menu_head").mouseover(function() {
            $(this).addClass("current").next("div.menu_body").slideDown(500).siblings("div.menu_body").slideUp("slow");
            $(this).siblings().removeClass("current");
        });

        $(".menu_body a").click(function() {
            $(".menu_body").children("a").css("background-color", "#ffffff");
            $(this).css("background-color", "#687FDA");
            //$(this).css({ "background-color": red });
            // $("#firstpane .menu_body a").not(this).css("background") = "#ffffff";
            //alert(this.innerHTML)
        })

//        
//        $("#GridView1 tr").mouseover(function() {
//            $(this).css("background-color", "#687FDA").not(this).css('background-color', 'none');

//        })
        

    });
</script>
    </form>
</body>
</html>
