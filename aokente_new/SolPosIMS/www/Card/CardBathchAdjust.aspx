<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardBathchAdjust.aspx.cs" Inherits="Card_CardBathchAdjust" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>卡片类型批量转换</title>
   <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/json.js"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>
    <script type="text/javascript">
    function CloseWin(msg)
    {
        alert(msg);
        window.location.href = 'CardList.aspx'; //成功后跳转卡列表
    }
    </script>
    <script type="text/javascript">

        function ischool1() {
            if (document.getElementById('Checkbox5').checked) {
                isfront.style.display = "none";
                document.getElementById('Checkbox6').checked = false;
                count();
            }
            else {
                document.getElementById('Checkbox6').checked = true;
                isfront.style.display = "";
            }
        }

        function ischool2() {
            if (document.getElementById('Checkbox6').checked) {
                isfront.style.display = "";
                document.getElementById('Checkbox5').checked = false;
            }
            else {
                document.getElementById('Checkbox5').checked = true;
                isfront.style.display = "none";
                count();
            }
        }

        function count2() {
            var strlenth = 0;
            strlenth = document.getElementById("CardPre").value.replace(/[ ]/g, "").length + document.getElementById("StartNum").value.replace(/[ ]/g, "").length;
            document.all.Label1.innerText = "当前的卡号长度为" + strlenth + "个字符";

        }
        function count() {
            var strlenth = 0;
            if (document.getElementById('Checkbox6').checked) {
                strlenth = document.getElementById("CardPre").value.replace(/[ ]/g, "").length + document.getElementById("StartNum").value.replace(/[ ]/g, "").length;
            }
            else {
                document.getElementById("CardPre").value = "";
                strlenth = document.getElementById("StartNum").value.replace(/[ ]/g, "").length;
            }
            if (strlenth > 0) {
                document.all.Label1.innerText = "当前的卡号长度为" + strlenth + "个字符";
            }
            else {
                document.all.Label1.innerText = "当前的卡号长度为" + strlenth + "个字符";
            }

        }

        function isnull() {

            if (document.getElementById("StartNum").value == "") {
                alert("起始卡号不能为空!");
            }
            else {
                if (isNaN(document.getElementById("StartNum").value)) {
                    alert("起始卡号应该为数字!");
                }
                else {
                   
                        if (document.getElementById("CardPre").value.replace(/[ ]/g, "").length + document.getElementById("StartNum").value.replace(/[ ]/g, "").length < 6) {
                            alert("卡号总长度不能小于6位!");
                            btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
                        }
                        else {
                            return true;
                        }
                    }
                }
        }

        function isnull2() {
            if (document.getElementById('Checkbox6').checked) {
                if (document.getElementById("CardPre").value == "") {
                    alert("卡号前缀不能为空!");
                    btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull2())   return   false; ");
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }


        function OnLoadtime() {
            //   Isjihuo.style.display= "none"; 
             ischool1(); 
        }
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
        function doInfornew() {
            openBrWindow('ExcelCard.aspx', 'NewAreaInfo', '405', '340');
        }
        function AppearProgress() {

            //            $("#DivCover").css("display", "block");
            //            $("#Waiting").css("display", "block");
            document.getElementById("DivCover").style.display = "block";
            document.getElementById("Waiting").style.display = "block";
        }
    
    </script>
</head>
<body onload="OnLoadtime()" style=" width:98%">

 

    <form id="Form1" runat="server">
        <ul class="sitemappath">
        <li>发卡管理 > 批量激活卡</li></ul>
    <div class="table_data form_table clearfix">
			<table>
				<tbody>
                    <tr>
						<td class="xyfml">启用卡前缀</td>
						<td class="xyfmr">
                    <input id="Checkbox5" runat="server" type="checkbox" checked="CHECKED" onclick="ischool1()" />否
                    &nbsp;&nbsp;
                    <input id="Checkbox6" runat="server" type="checkbox" onclick="ischool2()" />是
                </td>
					</tr>
                    <tr  id="isfront">
						<td class="xyfml">卡号前缀</td>
						<td class="xyfmr">
                    <input id="CardPre" runat="server" class="xyin_s" maxlength="6" name="CardPre"
                        vdisp="卡号前缀" style="width: 136px" type="text" onpropertychange="count2()" 
                                onkeyup="value=value.replace(/[\W]/g,'')" /></td>
					</tr>
                    <tr>
						<td class="xyfml">起始卡号</td>
						<td class="xyfmr">
                    <input id="StartNum" runat="server" class="xyin_s" maxlength="10" name="StartNum"
                        vdisp="起始序号" vmode="not null" vtype="number" onpropertychange="count()" style="width: 136px"
                        type="text" />&nbsp;
                    <asp:Label ID="Label1" runat="server" Width="168px"></asp:Label>
                        </td>
					</tr>
                    <tr>
						<td class="xyfml">结束卡号</td>
						<td class="xyfmr">
                    <input id="EndNum" runat="server" class="xyin_s" maxlength="10" name="EndNum"
                        vdisp="起始序号" vmode="not null" vtype="number" onpropertychange="count()" style="width: 136px"
                        type="text" /></td>
					</tr>
                    <tr>
						<td class="xyfml">卡片类型</td>
						<td class="xyfmr">
                    <select id="TypeID" runat="server" class="inputblue" name="TypeID" 
                        style="width: 150px">
                    </select></td>
					</tr>
                    <tr id="siteID">
						<td class="xyfml">目标类型</td>
						<td class="xyfmr">
                    <select id="TypeID_Target" runat="server" class="inputblue" name="TypeID_Target" 
                        style="width: 150px">
                    </select></td>
					</tr>
                    <tr>
						<td class="xyfml">提 示</td>
						<td class="xyfmr">1、批量操作会占用服务器的资源,同时防止操作失误,建议每次转换的卡张数不超过1000张,最多为999张<br />
                                                        2、当卡号过长(10位以上),请启用卡号前缀进行辅助发卡<br />
                            </td>
					</tr>
                    <tr>
						<td class="xyfml">&nbsp;</td>
						<td class="xyfmr">
                &nbsp;<input id="cardsnr" type="hidden"  runat="server"/>
                            <input id="bt_Batch" runat="server" class="xybtn" name="btnCon" onserverclick="bt_Batch_ServerClick"
            type="button" value="批量转换" 
            
            onclick="javascript:if(isnull2()&&isnull()){AppearProgress();}" /></td>
					</tr>
				</tbody>
			</table>
		</div>
    <div align="center" class="section_operators">
        &nbsp;
        &nbsp;&nbsp; <input class="btn003" style=" height:18px; width:59px; display:none;" value="导入制卡"  onclick="doInfornew()" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
    <%--      遮罩层--%>
    <div id="DivCover" runat="server" style="display: none">
    </div>
    <div id="Waiting" runat="server" style="display: none;">
   <img src="../images/loadingbar.gif" width="100" height="7" alt="发送提示" /><br />
        <asp:Label ID="textid" runat="server" Text="正在执行，请稍后……"></asp:Label>  <br />
        <br />
        <a href="SentCard.aspx" target="_self">[返回面板]</a>
         </div>
    <%--      遮罩层结束--%>
    </form>



</body>
</html>
