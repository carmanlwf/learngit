<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BatchRecharge.aspx.cs" Inherits="Card_BatchRecharge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>批量充值</title>
      <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/app.edit.js"></script>

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>

    <script type="text/javascript" src="../js/json.js"></script>

    <script type="text/javascript" src="../js/app.xmlhttp.js"></script>
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
        
          function isnull4() {
             var EndNum=document.getElementById("EndNum").value;
               var StartNum=document.getElementById("StartNum").value;
             if(EndNum-StartNum+1>1000){
                alert("一次性发卡数不能超过1000!");
                btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull4())   return   false; ");
            }
            else {
                return true;
            }
        }

        function AppearProgress() {


            document.getElementById("DivCover").style.display = "block";
            document.getElementById("Waiting").style.display = "block";
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
                    if (document.getElementById("EndNum").value == "") {
                        alert("结束卡号不能为空!");
                        btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
                    }
                    else {
                        if (isNaN(document.getElementById("EndNum").value)) {
                             alert("结束卡号应该为数字!");
                            btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
                        }
                        else {
                           
                            var EndNum=document.getElementById("EndNum").value;
                           var StartNum=document.getElementById("StartNum").value;
                           if(EndNum-StartNum+1<1){
                              alert("请输入正确的范围!");
                              btnInsertCustomer.Attributes.Add("onclick ", "if(!isnull())   return   false; ");
                            }
                           
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
        
    </script>
    
</head>
<body onload="ischool1()">
    <form id="Form1" runat="server">
    <div class="appsection">
        <table cellpadding="1" cellspacing="1" class="table_default table_blue">
            <tr>
                <th style="width: 125px; height: 18px">
                    <span style="color: #1e3739">是否添加卡号前</span><span style="color: #1e3739">缀</span>
                </th>
                <td colspan="3" style="height: 18px">
                    <span style="color: #1e3739"><span style="color: #1e3739"></span></span>
                    <input id="Checkbox5" runat="server" type="checkbox" checked="CHECKED" onclick="ischool1()" />否
                    &nbsp;&nbsp;
                    <input id="Checkbox6" runat="server" type="checkbox" onclick="ischool2()" />是
                </td>
            </tr>
            <tr id="isfront">
                <th style="height: 18px; width: 125px;">
                    <label style="color: red; height: 18px">
                        <span style="color: #1e3739">卡号前缀 </span>
                    </label>
                </th>
                <td colspan="3" style="height: 18px">
                    <input id="CardPre" runat="server" class="inputblue" maxlength="6" name="CardPre"
                        vdisp="卡号前缀" style="width: 136px" type="text" onpropertychange="count2()" onkeyup="value=value.replace(/[\W]/g,'')" />
                </td>
            </tr>
            <tr>
                <th style="width: 125px; height: 18px">
                    <span style="color: #1e3739">起始序号</span>
                </th>
                <td colspan="3" style="height: 18px">
                    <input id="StartNum" runat="server" class="inputblue" maxlength="10" name="StartNum"
                        vdisp="起始序号" vmode="not null" vtype="number" onpropertychange="count()" style="width: 136px"
                        type="text" />&nbsp;
                    <asp:Label ID="Label1" runat="server" Width="168px"></asp:Label>
                </td>
            </tr
             <tr>
                <th style="width: 125px; height: 18px">
                    <span style="color: #1e3739">结束序号</span>
                </th>
                <td colspan="3" style="height: 18px">
                    <input id="EndNum" runat="server" class="inputblue" maxlength="10" name="EndNum"
                        vdisp="结束序号" vmode="not null" vtype="number" onpropertychange="count()" style="width: 136px"
                        type="text" />&nbsp;
                    <asp:Label ID="Label2" runat="server" Width="168px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th style="width: 125px; height: 18px">
                    充值金额
                </th>
                <td colspan="3" style="height: 18px">
                    <input id="InitBalance" runat="server" class="inputblue" maxlength="5" name="InitBalance"
                        vdisp="充值金额" vmode="not null" vtype="double" style="width: 50px" type="text"
                        value="0" />元
                </td>
            </tr>
          
            <tr>
                <th style="width: 125px; height: 80px;">
                    提示&nbsp;
                </th>
                <td colspan="3" style="height: 80px">
                    <span style="color: red">批量充值就是所有卡都冲入实质相同的金额，没有任何赠送和利率！</span>
                </td>
            </tr>
          
        </table>
        <span style="color: #1e3739"></span>
    </div>
    <div align="left" class="section_operators">
        &nbsp; &nbsp;<input id="bt_Batch" runat="server" class="btn003" name="btnCon" onserverclick="bt_Batch_ServerClick"
            type="button" value="批量充值" onclick="javascript:if(isnull2()&&isnull()&&isnull3()&&isnull4()){AppearProgress();}" />
        &nbsp;&nbsp; </div>
    <%--      遮罩层--%>
    <div id="DivCover" runat="server" style="display: none">
    </div>
    <div id="Waiting" runat="server" style="display: none;">
   <img src="../images/loadingbar.gif" width="100" height="7" alt="发送提示" /><br />
        <asp:Label ID="textid" runat="server" Text="正在执行，请稍后……"></asp:Label>  <br />
        <br />
        <a href="BatchRecharge.aspx" target="_self">[返回列表]</a>
         </div>
    <%--      遮罩层结束--%>
    </form>



</body>
</html>
