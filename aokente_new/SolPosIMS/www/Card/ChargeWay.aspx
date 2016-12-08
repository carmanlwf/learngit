<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargeWay.aspx.cs" Inherits="Card_ChargeWay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>请选择充值方式</title>
<link type="text/css" rel="stylesheet" href="../css/app.css" />
	<link type="text/css" rel="stylesheet" href="../css/tabcolor/tab.css" />
	<link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../js/tabpane.js"></script>
	<script src="../js/app.edit.js" type="text/javascript"></script>
	<style type="text/css">

.tab-pane .tab-page {
	height:		650px;
	width:810px;
}

.tab-pane h2 {
	text-align:	center;
	width:		auto;
}

.tab-pane h2 a {
	display:	inline;
	width:		auto;
}

.tab-pane a:hover {
	background: transparent;
}
</style>
<script>
function GetParam(){
    var url = document.location.href;
    var name=""
    if (url.indexOf("=")>0)
    {
        name = url.substring(url.indexOf("=")+1,url.length)
    }
    return name;
}

</script>
</head>
<body>
	<form id="form1" runat="server">
		<input id="agentid" runat="server" value="" name="agentid" type="hidden"/>
		<div class="tab-pane tab-pane-red" id="tabPane1">
			<div class="tab-page" id="tabPage1">
				<h2 class="tab">
					现金支付</h2>
				<div>
					<iframe id="IfrIndividualquery" name="IfrStuSmsSend" runat="server" src="CardChongZhi.aspx" frameborder="0"
						scrolling="auto"></iframe>
				</div>
			</div>
			<div class="tab-page" id="tabPage2">
				<h2 class="tab">
					网银支付</h2>
				<div>
					<iframe id="IfrGroupQuery" name="IfrTeaSmsSend" src="zhifubao.aspx" frameborder="0"
						scrolling="auto"></iframe>
				</div>
			</div>
		</div>
		<script type="text/javascript">
var bizQueryPane = new WebFXTabPane( document.getElementById( "tabPane1" ) );
bizQueryPane.onSelectedChange = function(n)
{
    var currIframe = null;
    switch(n)
    {
        case 0:
            currIframe = IfrStuSmsSend;
            break;
        case 1:
            currIframe = IfrTeaSmsSend;
            break;
        case 2:
            currIframe = IfrOperatorQuery;
            break;
        case 3:
            currIframe = IfrClaimsQuery;
            break;
        case 4:
            currIframe = IfrTLUnitPrice;
            break;
        case 5:
            currIframe = IframeJBYRate;
            break;
    }
    currIframe.doOnFocus();
}
		</script>
	</form>
</body>
</html>
