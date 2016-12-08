<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="MainNav.aspx.cs" Inherits="main_MainNav" %>

<%--<%@ OutputCache VaryByParam="*" Duration="36000" %>
--%>
<%@ Import Namespace="Ims.Admin" %>
<%@ Import Namespace="Ims.Main" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>

    <link href="../css/app.css" rel="stylesheet" type="text/css" />
    <link href="../css/tabnav/tab.menu.css" rel="stylesheet" type="text/css" />
           <link rel="stylesheet" href="../css/table.css" />
    <style type="text/css">
body {
	margin:		2px;
	width:		180px;
	height:		auto;
	scrollbar-face-color:#ffffff;
	scrollbar-shadow-color:#84B3BC;
	scrollbar-highlight-color:#84B3BC;
	scrollbar-3dlight-color:#ffffff;
	scrollbar-darkshadow-color:#ffffff;
	scrollbar-track-color:#E5E5E5;
	scrollbar-arrow-color:#225765;
}

.dynamic-tab-pane-control .tab-page {
	height:		500px;
}

.dynamic-tab-pane-control h2 {
	text-align:	center;
	width:		auto;
}

.dynamic-tab-pane-control h2 a {
	display:	inline;
	width:		auto;
}

.dynamic-tab-pane-control a:hover {
	background: transparent;
}
.div-tab-page
{
	overflow:auto;
	width:180px;
	height:500px;
}
</style>

    <script type="text/javascript" src="../js/tabpane.js"></script>

    <script type="text/javascript">
        var webFXTreeImagesPath = "xtree/images/";
    </script>

    <script type="text/javascript" src="xtree/xtree.js"></script>

    <script type="text/javascript">
        webFXTreeConfig.rootIcon = webFXTreeImagesPath + 'menutree_folder.gif';
        webFXTreeConfig.openRootIcon = webFXTreeImagesPath + 'menutree_folder.gif';
        webFXTreeConfig.folderIcon = webFXTreeImagesPath + 'menutree_folder.gif';
        webFXTreeConfig.openFolderIcon = webFXTreeImagesPath + 'menutree_folder.gif';
        webFXTreeConfig.fileIcon = webFXTreeImagesPath + 'menutree_file.gif';

    </script>

    <style>
.webfx-tree-container {
	margin: 0px;
	padding: 0px;
	font: icon;
	font-size:15pt;
	white-space: nowrap;
}

.webfx-tree-item {
	padding: 0px;
	margin: 0px;
	font: icon;
	 font-size:large;
	  font-weight:bold;
	font-family:微软雅黑;
	white-space: nowrap;
}

.webfx-tree-item a, .webfx-tree-item a:active, .webfx-tree-item a:hover {
	margin-left: 2px;
	padding: 1px 2px 1px 2px;
	font-size:large;
  
}

.webfx-tree-item a {
	color: darkblue;
	text-decoration: none;
}

.webfx-tree-item a:hover {
	color: orangered;
	text-decoration: underline;
	  font-weight:bold;
}

.webfx-tree-item a:active {
	background: highlight;
	color: highlighttext;
	text-decoration: none;
}

.webfx-tree-item img {
	vertical-align: middle;
	border: 0px;
}

.webfx-tree-icon {
	width: 13px;
	height: 16px;
}
.webfx-tree-item a.selected {
	color: #3399ff;
	background: transparent;
}

.webfx-tree-item a.selected-inactive {
	color: #3399ff;
	background: transparent;
}

</style>
    <script type="text/javascript">
	function createagentapptree()
	{
		var rootapp ,subapp;
	//////////////////业务系统菜单开始//////////////
	        <%if(ImsInfo.UserIsInRoles("admin,channel,agent,seller")!=""){ %>
		    rootapp = new WebFXTree('功能菜单');
		    rootapp.setBehavior('classic');
      
             
            
            <%if(ImsInfo.UserIsInRoles("admin,agent,seller")!=""){%>   
                subapp = new WebFXTreeItem("会员管理");
                rootapp.add(subapp);
                <%if(ImsInfo.UserIsInRoles("admin,agent,seller")!=""){%> 
//                    subapp.add(new WebFXTreeItem('会员等级',"javascript:nav('../Member/MemberLevel.aspx')"));
                    <%} %> 
                    subapp.add(new WebFXTreeItem('会员信息',"javascript:nav('../Member/MemberList.aspx')"));
                    subapp.add(new WebFXTreeItem('余额提醒',"javascript:nav('../Card/CardBalanceWarn.aspx')"));
                    subapp.add(new WebFXTreeItem('过期卡片',"javascript:nav('../Report/Rpt_Memberlost.aspx')"));

                   <%if(ImsInfo.UserIsInRoles("admin,agent,seller")!=""){%>   
                    subapp.add(new WebFXTreeItem('流失客户',"javascript:nav('../Report/Rpt_LostMember.aspx')"));
                    <%} %> 

                <%if(ImsInfo.UserIsInRoles("admin,channel")!=""){%>   
                subapp = new WebFXTreeItem("持卡管理");
                rootapp.add(subapp);
                
                    <%if(ImsInfo.UserIsInRoles("admin,agent,channel,seller")!=""){%>
                    subapp.add(new WebFXTreeItem('卡片信息',"javascript:nav('../Card/CardList.aspx')"));
                    subapp.add(new WebFXTreeItem('卡片挂失',"javascript:nav('../CardHold/CardLock.aspx')"));
                    subapp.add(new WebFXTreeItem('卡片解挂',"javascript:nav('../CardHold/CardUnLock.aspx')"));
                    subapp.add(new WebFXTreeItem('会员补卡',"javascript:nav('../CardHold/CardRenew.aspx')"));
                    subapp.add(new WebFXTreeItem('密码重置',"javascript:nav('../CardHold/CardPassReset.aspx')"));
                    subapp.add(new WebFXTreeItem('卡片延期',"javascript:nav('../CardHold/CardDelay.aspx')"));
                    subapp.add(new WebFXTreeItem('补卡记录',"javascript:nav('../Card/CardRecord.aspx')"));
                    <%} %> 

            <%} %> 
            <%if(ImsInfo.UserIsInRoles("admin,channel,seller")!=""){%>   
                subapp = new WebFXTreeItem("发卡管理");
                rootapp.add(subapp);
                    
                    //subapp.add(new WebFXTreeItem('会员卡信息',"javascript:nav('../Card/CardList.aspx')"));
                    subapp.add(new WebFXTreeItem('类型管理',"javascript:nav('../Card/CardTypeList.aspx')"));
                    subapp.add(new WebFXTreeItem('充值规则',"javascript:nav('../Card/CardChargeRuleList.aspx')"));
                    //subapp.add(new WebFXTreeItem('不记名发卡',"javascript:nav('../Card/CardBatchSend.aspx')"));
                    <%if(ImsInfo.UserIsInRoles("admin,seller")!=""){%> 
                    subapp.add(new WebFXTreeItem('未激活卡',"javascript:nav('../Card/CardBatchRegistration.aspx')"));

                      subapp.add(new WebFXTreeItem('新卡退款',"javascript:nav('../Card/EndCardSelect.aspx')"));

//                    subapp.add(new WebFXTreeItem('余额提醒',"javascript:nav('../Card/CardBalanceWarn.aspx')"));
                    //subapp.add(new WebFXTreeItem('类型转换记录',"javascript:nav('../Card/CardTurnTypeRecordList.aspx')"));
                    <%} %> 
                    <%if(ImsInfo.UserIsInRoles("admin1,seller")!=""){%> 
                        subapp.add(new WebFXTreeItem('操作员常用',"javascript:nav('../Notice/MenuList_Operator.aspx')"));
                        subapp.add(new WebFXTreeItem('打开发卡器',"javascript:nav('../utility/RF_Card_Config.aspx')"));
                     <%} %> 
                    
                         <%if(ImsInfo.UserIsInRoles("admin")!=""){%> 
                    subapp.add(new WebFXTreeItem('批量制卡',"javascript:nav('../Card/SentCard.aspx')"));
                    //subapp.add(new WebFXTreeItem('批量充值',"javascript:nav('../Card/BatchRecharge.aspx')"));
                    <%} %> 
                         subapp.add(new WebFXTreeItem('激活查询',"javascript:nav('../Card/CardActiveSelect.aspx')"));
                   <%} %> 
            <%} %>
            
            <%if(ImsInfo.UserIsInRoles("admin,agent,channel")!=""){%>   
                subapp = new WebFXTreeItem("查询统计");
                rootapp.add(subapp);
                
                    <%if(ImsInfo.UserIsInRoles("admin,agent,channel,seller")!=""){%>
                    //subapp.add(new WebFXTreeItem('test',"javascript:nav('../WebPrint/PreView.aspx')"));
                    subapp.add(new WebFXTreeItem('终端交易查询',"javascript:nav('../Report/Rpt_PosTransDetail.aspx')"));
                    //subapp.add(new WebFXTreeItem('消费撤单查询',"javascript:nav('../Report/Rpt_PosTransDetail.aspx?type=cd_xf')"));
                    //subapp.add(new WebFXTreeItem('终端消费积分',"javascript:nav('../Report/Rpt_PosTransDetail.aspx?type=jf')"));
                    //subapp.add(new WebFXTreeItem('积分撤单查询',"javascript:nav('../Report/Rpt_PosTransDetail.aspx?type=cd_jf')"));
                    //subapp.add(new WebFXTreeItem('终端充值查询',"javascript:nav('../Report/Rpt_PosTransDetail.aspx?type=cz')"));
                    //subapp.add(new WebFXTreeItem('终端充值撤单',"javascript:nav('../Report/Rpt_PosTransDetail.aspx?type=cd_cz')"));
                    <%} %> 

                    

                   <%if(ImsInfo.UserIsInRoles("admin,seller")!=""){%>   
                   subapp.add(new WebFXTreeItem('充值记录查询',"javascript:nav('../Sysem/Cardchargelist.aspx')"));
                   subapp.add(new WebFXTreeItem('退卡明细查询',"javascript:nav('../Sysem/ExitCard.aspx')"));
                   subapp.add(new WebFXTreeItem('每日充值统计',"javascript:nav('../Sysem/ToDayCZRecord.aspx')"));
                   subapp.add(new WebFXTreeItem('发卡综合统计',"javascript:nav('../Card/CardToExec.aspx')"));
                   subapp.add(new WebFXTreeItem('商户消费统计',"javascript:nav('../Report/Rpt_SiteCount.aspx')"));
                   subapp.add(new WebFXTreeItem('营业员充值统计',"javascript:nav('../Report/Rpt_PosUser.aspx')"));
                   subapp.add(new WebFXTreeItem('营业员结算记录',"javascript:nav('../Sysem/CardChargeStatics.aspx')"));
                    <%} %>
                   <%if(ImsInfo.UserIsInRoles("admin")!=""){%>   
                    subapp.add(new WebFXTreeItem('机号消费统计',"javascript:nav('../Report/Rpt_AllBranchData.aspx')"));
                    <%} %> 
                    //---------  

                    //---------

            <%} %> 
            <%if(ImsInfo.UserIsInRoles("admin,agent,channel")!=""){%>   
                subapp = new WebFXTreeItem("数据报表");
                rootapp.add(subapp);
                
                    <%if(ImsInfo.UserIsInRoles("admin,agent,channel,seller")!=""){%>
                    subapp.add(new WebFXTreeItem('报表清单',"javascript:nav('../ReportViewer/RptList.aspx')"));
             <%} %> 
              <%} %>  
		     <%if(ImsInfo.UserIsInRoles("admin,agent1")!=""){%>  
                subapp = new WebFXTreeItem("系统设置");
                rootapp.add(subapp);
                
                 <%if(ImsInfo.UserIsInRoles("admin")!=""){%>
                    subapp.add(new WebFXTreeItem('区域管理',"javascript:nav('../ST/AreaList.aspx')"));
                    <%} %> 
                    <%if(ImsInfo.UserIsInRoles("admin")!=""){%>
                    subapp.add(new WebFXTreeItem('分店管理',"javascript:nav('../ST/SiteList.aspx')"));
                    <%} %> 
                    <%if(ImsInfo.UserIsInRoles("admin")!=""){%>   
                    subapp.add(new WebFXTreeItem('用户管理',"javascript:nav('../Admin/UserListByAuthority.aspx?type=adminlist&code=1')"));
                    <%} %> 
                    <%if(ImsInfo.UserIsInRoles("admin,agent")!=""){%>   
                    subapp.add(new WebFXTreeItem('POS操作员',"javascript:nav('../ST/PosOperatorList.aspx')"));
                    <%} %> 
                     <%if(ImsInfo.UserIsInRoles("admin")!=""){%>   
                    subapp.add(new WebFXTreeItem('系统备份',"javascript:nav('../Sysem/ManagementData.aspx')"));
                    <%} %>
                    
                    //---------
                    <%if(ImsInfo.UserIsInRoles("admin")!=""){%>   
                    subapp.add(new WebFXTreeItem('数据维护',"javascript:nav('../Sysem/DataMaintenance.aspx')"));
                    <%} %>
                    //---------
                    <%if(ImsInfo.UserIsInRoles("admin")!=""){%>   
                    subapp.add(new WebFXTreeItem('操作日志',"javascript:nav('../Report/Rpt_OperationLog.aspx')"));
                    <%} %> 
            <%} %> 
		    document.write(rootapp);
		<%} %>
		/////////////////////业务系统菜单结束//////////////////////////
	}
	
	
    </script>

    <script type="text/javascript">
        function nav(url) {
            if (top.document.getElementById("queryNewInsurAgainCust") != null)
                top.document.getElementById("queryNewInsurAgainCust").style.display = "none";
            if (top.document.getElementById("ticketzb") != null)
                top.document.getElementById("ticketzb").style.display = "none";
            if (top.document.getElementById("queryNewInsurCust") != null)
                top.document.getElementById("queryNewInsurCust").style.display = "none";
            if (top.document.getElementById("newServices") != null)
                top.document.getElementById("newServices").style.display = "none";

            if (top.document.getElementById("aaQcOperation") != null)
                top.document.getElementById("aaQcOperation").style.display = "none";
            if (top.document.getElementById("obQcOperation") != null)
                top.document.getElementById("obQcOperation").style.display = "none";


            if (top.document.getElementById("manageServices") != null)
                top.document.getElementById("manageServices").style.display = "none";
            top.document.getElementById("main").style.display = "";
            doShowWaitMessage("main");
            window.setTimeout("top['main'].location.href = '" + url + "';", 0);
            //	    window.setTimeout("window.open('"+url+"','main')",0);
            //window.open(url,"main");
            if (top.document.getElementById("aaWebConsult") != null)
                top.document.getElementById("aaWebConsult").style.display = "none";

            if (top.document.getElementById("aaWebConsultQuery") != null)
                top.document.getElementById("aaWebConsultQuery").style.display = "none";
            if (top.document.getElementById("aaWebClaims") != null)
                top.document.getElementById("aaWebClaims").style.display = "none";
        }


        function doShowWaitMessage(iframeName) {
            var iframeWin = top[iframeName];
            if (iframeWin == null) return;
            try {
                iframeWin.WaitHelper.showWaitMessage();
            } catch (e) { }
        }

        function nav2(url, winName, width, height) {
            openBrWindow(url, winName, width, height);
        }
	
    </script>

</head>
<body style="margin:0px; font-size:large;">

    <table border="0" cellpadding="0" cellspacing="0" 
        style="width: 180px; margin-top: 0px; margin-left: 0px;">
        <tr>
            <td style="background-image: none; height: 30px; border-bottom-style: dotted; border-bottom-color: lightgray; border-bottom-width: thin;">
                    <script language="JavaScript">
                        today = new Date();
                        function initArray() {
                            this.length = initArray.arguments.length
                            for (var i = 0; i < this.length; i++)
                                this[i + 1] = initArray.arguments[i]
                        }
                        var d = new initArray(
     "星期日",
     "星期一",
     "星期二",
     "星期三",
     "星期四",
     "星期五",
     "星期六");
                        document.write(
	 "<img src=../images/calender.gif width=18 height=18 align=absmiddle hspace=3>",
     "<font style='font-size:11px;font-family:Verdana;color:#41A4D5'>",
                        //     today.getYear(),"年",
     today.getMonth() + 1, "月",
     today.getDate(), "日&nbsp;",
     d[today.getDay() + 1],
     "</font>"); 
        </script>
                </td>
        </tr>
        <tr>
            <td style="height: 5px; text-align: center">
            </td>
        </tr>
    </table>
   <span style=" font-weight:bold;">
 <script type="text/javascript">     createagentapptree()</script>

    <script type="text/javascript">
        //<![CDATA[

        setupAllTabs();

        //]]>
    </script>
</span>
</body>
</html>
