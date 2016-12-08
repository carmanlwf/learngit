<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SentCard.aspx.cs" Inherits="Card_SentCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>批量制卡</title>
    <link rel="stylesheet" href="../css/table.css" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/json.js"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>

    <script type="text/javascript">
        function onAreaSelectChange() {
            var selectArea = document.getElementById('Area_Code');
            var Area = selectArea.value;
            document.all.Site_Code.options.length = 0;
            BindNormalTableToListControl('Site_Code', "id", "sitename", "tb_site", "id", "areacode = '" + Area + "'", "请选择");
        }

        function OnGroup() {
        /*
            var selectArea = document.getElementById('GroupID1');
            var Area = selectArea.value;
            document.all.Member1.options.length = 0;
            BindNormalTableToListControl('Member1', "id", "name", "v_pub_agentquerynew", "id", "groupid ='" + Area + "'", "请选择");
            */
        }


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

        function ischool3() {
            if (document.getElementById('Checkbox1').checked) {
                siteID.style.display = "none";
                //	     rankber.style.display= "none"; 
                document.getElementById('Checkbox2').checked = false;
            }
            else {
                document.getElementById('Checkbox2').checked = true;
                //	   siteID.style.display= ""; 
                //	    rankber.style.display= ""; 
            }
        }


        function ischool4() {
            if (document.getElementById('Checkbox2').checked) {
                siteID.style.display = "";
                //	     rankber.style.display= ""; 
                document.getElementById('Checkbox1').checked = false;
            }
            else {
                siteID.style.display = "none";
                //	       rankber.style.display= "none"; 
                document.getElementById('Checkbox1').checked = true;

            }
        }

        function ischool5() {
            if (document.getElementById('Checkbox3').checked) {
                possword1.style.display = "none";
                document.getElementById('Checkbox4').checked = false;
            }
            else {
                possword1.style.display = "";
                document.getElementById('Checkbox4').checked = true;

            }
        }

        function ischool6() {
            if (document.getElementById('Checkbox4').checked) {
                possword1.style.display = "";

                document.getElementById('Checkbox3').checked = false;
            }
            else {
                possword1.style.display = "none";

                document.getElementById('Checkbox3').checked = true;

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
                btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
            }
            else {
                if (isNaN(document.getElementById("StartNum").value)) {
                    alert("起始卡号应该为数字!");
                    btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
                }
                else {
                    if (document.getElementById("Num").value == "") {
                        alert("卡张数不能为空!");
                        btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
                    }
                    else {
                        if (isNaN(document.getElementById("Num").value)) {
                            alert("张数应该为整数!");
                            btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
                        }
                        else {
                            if (document.getElementById('Checkbox4').checked) {
                                if (document.getElementById("password").value == "") {
                                    alert("密码不能为空!");
                                    btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
                                }
                                else {
                                    return true;
                                }
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

        function isnull3() {
            if (document.getElementById("InitBalance").value == "") {
                alert("金额不能为空!");
                btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull3())   return   false; ");
            }
            else {
                if (isNaN(document.getElementById("InitBalance").value)) {
                    alert("金额应该为数字!");
                    btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull3())   return   false; ");
                }
                else {
                    return true;
                }
            }
        }

        function isnull4() {
            if (Number(document.getElementById("Num").value) > 1000) {
                alert("一次性发卡数不能超过1000!");
                btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull4())   return   false; ");
            }
            else {
                return true;
            }
        }


        function everyIsNumber()//判断密码是否为数字
        {
            if (document.getElementById('Checkbox3').checked) {
                var regNum = /^\d*$/; //判断为数字
                var cardid = document.getElementById("CardPre").value.replace(/[ ]/g, "") + document.getElementById("StartNum").value.replace(/[ ]/g, "");
                var splitcardid = cardid.split('');
                var t = "";

                for (var i = 0; i < splitcardid.length; i++) {
                    if (regNum.test(splitcardid[splitcardid.length - i - 1])) {
                        t = i;
                        continue;
                    }
                    else {
                        break;
                    }
                }


                if (t < 5) {
                    alert("选择以卡后面6位为密码时，请保证卡片后6位全为数字!");
                    btnInsertCustomer.Attributes.Add("onclick ", "if(!everyIsNumber())   return   false; ");
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }

        }

        function anerynumber() {
            if (document.getElementById('Checkbox4').checked) {
                if (document.getElementById("password").value == "") {
                    alert("密码不能为空!");
                    btnInsertCustomer.Attributes.Add("onclick ", "if(!anerynumber())   return   false; ");
                }
                else {

                    var regNum = /^\d*$/; //判断为数字
                    if (regNum.test(document.getElementById("password").value) == false) {
                        alert("密码应该全为数字!");
                        btnInsertCustomer.Attributes.Add("onclick ", "if(!anerynumber())   return   false; ");
                    }
                    else {
                        return true;
                    }
                }
            }
            else {
                return true;
            }
        }

        function OnLoadtime() {
            //   Isjihuo.style.display= "none"; 
            onAreaSelectChange(); ischool1(); ischool3(); ischool5(); 
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
        <li>发卡管理 > 批量制卡</li></ul>
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
						<td class="xyfml">起始序号</td>
						<td class="xyfmr">
                    <input id="StartNum" runat="server" class="xyin_s" maxlength="10" name="StartNum"
                        vdisp="起始序号" vmode="not null" vtype="number" onpropertychange="count()" style="width: 136px"
                        type="text" />&nbsp;
                    <asp:Label ID="Label1" runat="server" Width="168px"></asp:Label>
                        </td>
					</tr>
                    <tr>
						<td class="xyfml">发卡张数</td>
						<td class="xyfmr">
                    <input id="Num" runat="server" class="xyin_s" maxlength="4" name="Num" style="width: 50px"
                        vdisp="张数" vtype="number" voperate="rangeint" min="1" max="500" vmode="not null"
                        type="text" /></td>
					</tr>
                    <tr>
						<td class="xyfml">尾号筛选</td>
						<td class="xyfmr">
                    <input id="cbIn4" runat="server" type="checkbox" onclick="ischool1()" name="cbIn4" />尾号不带4
                    <input id="cbIn7" runat="server" type="checkbox" onclick="ischool1()" name="cbIn7" />尾号不带7</td>
					</tr>
                    <tr>
						<td class="xyfml">初始金额</td>
						<td class="xyfmr">
                    <input id="InitBalance" runat="server" class="xyin_s" maxlength="5" name="InitBalance"
                        vdisp="初始金额" vmode="not null" vtype="double" style="width: 50px" type="text"
                        value="0" /></td>
					</tr>
                    <tr>
						<td class="xyfml">有效期</td>
						<td class="xyfmr">
                    <input id="validDate" runat="server" class="xyin_s" maxlength="30" vtype="date"
                        onfocus="setday(this)" name="validDate" vdisp="有效日期" style="width: 104px" type="text"
                        readonly="readOnly" value="2020-12-31" /></td>
					</tr>
                    <tr>
						<td class="xyfml">卡片类型</td>
						<td class="xyfmr">
                    <select id="TypeID" runat="server" class="inputblue" name="TypeID" 
                        style="width: 150px">
                    </select></td>
					</tr>
                    <tr>
						<td class="xyfml">是否激活</td>
						<td class="xyfmr">
                    <input id="Checkbox1" runat="server" type="checkbox" checked="CHECKED" onclick="ischool3()" />否
                    &nbsp;&nbsp;
                    <input id="Checkbox2" runat="server" type="checkbox" onclick="ischool4()" />是
                </td>
					</tr>
                    <tr id="siteID">
						<td class="xyfml">所属分店</td>
						<td class="xyfmr">
                    <select id="Area_Code" runat="server" class="inputblue" name="Area_Code" onchange="onAreaSelectChange()"
                        style="width: 150px">
                    </select><select id="Site_Code" runat="server" class="inputblue" name="Site_Code"
                        style="width: 150px">
                    </select>
                </td>
					</tr>
                    <tr>
						<td class="xyfml">密码类型</td>
						<td class="xyfmr">
                    <input id="Checkbox3" type="checkbox" onclick="ischool5()" runat="server" checked="CHECKED" />卡号后面6位
                    <input id="Checkbox4" type="checkbox" onclick="ischool6()" runat="server" />统一密码</td>
					</tr>
                    <tr  id="possword1">
						<td class="xyfml">密 码</td>
						<td class="xyfmr">
                    <input id="password" runat="server" class="xyin_s" maxlength="6" name="password"
                        style="width: 104px" type="text" /></td>
					</tr>
                    <tr>
						<td class="xyfml">格 式</td>
						<td class="xyfmr">
                    <asp:RadioButtonList ID="RadFileFormat" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">生成文本</asp:ListItem>
                        <asp:ListItem Value="1">生成Excel</asp:ListItem>
                    </asp:RadioButtonList>
                        </td>
					</tr>
                    <tr>
						<td class="xyfml">&nbsp;</td>
						<td class="xyfmr">
                    <asp:Label ID="lbDown" runat="server" ForeColor="Green"></asp:Label>
                        </td>
					</tr>
                    <tr>
						<td class="xyfml">提 示</td>
						<td class="xyfmr">1、批量操作会占用服务器的资源,建议每次发卡张数不超过5000张,最多为9999张<br />
                                                        2、当卡号过长(10位以上),请启用卡号前缀进行辅助发卡<br />
                            3、发卡成功后,请下载生成的电子文档,用于存档备份</td>
					</tr>
                    <tr>
						<td class="xyfml">&nbsp;</td>
						<td class="xyfmr">
                &nbsp;<input id="cardsnr" type="hidden"  runat="server"/>
                            <input id="bt_Batch" runat="server" class="xybtn" name="btnCon" onserverclick="bt_Batch_ServerClick"
            type="button" value="批量生成" 
            
            onclick="javascript:if(isnull2()&&isnull()&&isnull3()&&isnull4()&&everyIsNumber()&&anerynumber()){AppearProgress();}" /></td>
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
        <a href="SentCard.aspx" target="_self">[返回列表]</a>
         </div>
    <%--      遮罩层结束--%>
    </form>



</body>
</html>
