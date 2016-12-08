<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatMonthlyCardInfo.aspx.cs" Inherits="CardMonthly_CreatMonthlyCardInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    
    <script type='text/javascript' src="js/jquery.min.js"></script>
    <link href="../layer/skin/espresso/style.css" rel="stylesheet" type="text/css" />
<script src="../layer/layer.js" type="text/javascript"></script>
    <script type='text/javascript' src="js/jquery.selectlayer.js"></script>
    
    <script type="text/javascript">
    $(document).ready(function() {
        var QS_city = new Array()
        OpenCategoryLayer(
		"#district_cn",
		"#sel_district",
		"#district_cn",
		"#citycategory",
		QS_city,
	14);
    });
    </script>
    <script type="text/javascript">
    $(function(){
        $("#allSites").click(function(){
            if ($("#allSites").attr("checked"))
            {
                $("#district_cn").attr("disabled", true);
            }
            else
            {
                $("#district_cn").attr("disabled", false);
            }
            
        })
    })
    </script>

    <style type="text/css">
        /*等待状态样式开始*/#DivCover
        {
            background-color: #cccccc;
            filter: Alpha(Opacity=50, Style=0);
            opacity: 0.50;
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            _height: 768px;
            z-index: 999;
        }
        #Waiting
        {
            position: absolute;
            text-align: center;
            left: 50%;
            top: 50%;
            margin-left: -110px;
            margin-top: -50px;
            z-index: 1000;
            width: 200px;
            background-color: #FFFFFF;
            border-top: 1px dashed #52D3EA;
            border-right: 1px dashed #52D3EA;
            border-bottom: 1px dashed #52D3EA;
            border-left: 1px dashed #52D3EA;
            padding: 15px 10px 10px 10px;
        }
        #Waiting img
        {
            margin-bottom: 10px;
        }
        /*等待状态样式结束*/</style>

    <script type="text/javascript">
        function showdialogWin(msg) {
        
            
        layer.alert(msg);

//            layer.alert(msg, function() {
//                alert("dfhde")
//             });
          
            //


//            layer.alert(msg, {
//                btn: ['确定'] //按钮
//            }, function() {
//                layer.close(this);
//            });
            
            //layer.msg(msg);
           // layer.msg(msg, 2, 1, 0);
            //alert('sdfasdfasd----')
        }
    
    </script>
</head>
<body  style=" width:98%">
    <form id="Form1" runat="server">
        <ul class="sitemappath">
        <li>账户管理 > 开通月卡</li></ul>
    <div class="table_data form_table clearfix">
			<table>
				<tbody>
                    <tr>
						<td class="xyfml">车牌号码</td>
						<td>
                            <span style=" font-size:20pt; width:100px; height:25px; font-weight:bold; color:White; background-color:Blue; border-left:solid 1 gray;border-top:solid 1 gray;border-top:solid 1 gray;border-bottom:solid 1 gray;"><asp:Literal ID="ltcarnum" runat="server" Text="粤B88888"></asp:Literal></span>
                        </td>
					</tr>
                    <tr  id="isfront">
						<td class="xyfml">月卡类型</td>
						<td class="xyfmr">
                            <asp:RadioButtonList ID="rbCardType" runat="server" RepeatColumns="10" 
                                RepeatDirection="Horizontal" RepeatLayout="Flow" 
                                onselectedindexchanged="rbCardType_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:RadioButtonList>
                        </td>
					</tr>
                    <tr>
						<td class="xyfml">销售价格</td>
						<td class="xyfmr" >
                            <asp:Label ID="lbMonthlyCardPrice" runat="server" Font-Bold="True" style=" padding-left:10px;"
                                ForeColor="Red"></asp:Label>
                        </td>
					</tr>
                    <tr>
						<td class="xyfml">截至日期</td>
						<td class="xyfmr" >
                            <asp:Label ID="lbUptotime" runat="server" Font-Bold="True" style=" padding-left:10px;"
                                ForeColor="#009933"></asp:Label>
                        </td>
					</tr>
                    <tr>
						<td class="xyfml">停泊路段</td>
						<td class="xyfmr">
                            <div style="width:100%;margin-left:2px;">
	<input name="district_cn"  id="district_cn" type="text" runat = "server" value="请选择停泊路段..."  readonly="true" class="sltinput" />
	<input name="citycategory" id="citycategory" type="hidden" runat = "server" value="" />
	<input type="checkbox" id="allSites" runat="server" />所有路段
	<div style="display:none" id="sel_district">
		<div class="OpenFloatBoxBg"></div>
		<div class="OpenFloatBox">
			<div class="title">
				<h4>请选择停泊路段</h4>
				<div class="DialogClose" title="关闭"></div>
			</div>
			<div class="tip">请选择月卡有效期间所支持的停泊路段</div>
			<div class="content">
				<div class="txt">
                    <asp:Literal ID = "ltSiteList" runat="server"></asp:Literal>
					<div class="clear"></div>
				</div>
				<div class="txt">
					<div class="selecteditem"></div>
				</div>
				<div class="txt">
					<div align="center"><input type="button"  class="but80 Set" value="确定" /></div>
				</div>
			</div>
		</div>
	</div>
	
                                    </div></td>
					</tr>
                    <tr id="siteID">
						<td class="xyfml">姓 名</td>
						<td class="xyfmr">
                    <input id="RealName" runat="server" class="xyin_s" maxlength="10" name="RealName"
                         style="width: 180px"
                        type="text" /></td>
					</tr>
                    <tr id="siteID">
						<td class="xyfml">手 机</td>
						<td class="xyfmr">
                    <input id="CellPhone" runat="server" class="xyin_s" maxlength="11" name="CellPhone"
                        style="width: 180px"  type="text" /></td>
					</tr>
                    <tr>
						<td class="xyfml">提 示</td>
						<td class="xyfmr">1、办理开通月卡，将启用包月消费模式，已开通月卡用户将以当前开通的最新天数计算。<br />
                                                        2、月卡到期后，消费模式自动按照储值消费进行。<br />
                            </td>
					</tr>
                    <tr>
						<td class="xyfml"></td>
						<td class="xyfmr">
                &nbsp;<input id="cardsnr" type="hidden"  runat="server"/>
                            <input id="bt_Batch" runat="server" class="xybtn" name="btnCon" onserverclick="bt_Create_ServerClick" type="button" value="开通月卡" /></td>
					</tr>
				</tbody>
			</table>
		</div>
    </form>



</body>
</html>
