<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Charge.aspx.cs" Inherits="Money_Charge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员充值</title>
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/app.edit.js"></script>
    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
    <script type="text/javascript" src="../js/app.date.js" charset="gb2312"></script>
    <script type="text/javascript" src ="../js/jquery-1.4.2.min.js"  charset="gb2312"></script>
    <script type="text/javascript">
        var aa = 1;
        var bb = 1;
        var ret;
        var address, address1, address2, address3;

        MWRFATL.CloseReader();

        function RfInit()//打开设备
        {
            MWRFATL.CloseReader();
            var pass = "明泰";
            bb = MWRFATL.OpenReader(pass);
            aa = MWRFATL.LastRet;
            if (aa == 0)
                return true;
            else
                return false;
        }

        function RfExit()//关闭设备
        {
            MWRFATL.CloseReader();
            aa = MWRFATL.LastRet;
            if (aa == 0) {
                //alert("关闭设备Sucess!");
            }
            //else
                //alert("关闭设备失败!");
        }


        function DevBeep()//蜂鸣器蜂鸣
        {
            bb = MWRFATL.RF_Beep(10); 	//传入参数：设备单次蜂鸣时间
            //aa = MWRFATL.LastRet;
            //if (aa == 0)
            //    alert("蜂鸣Sucess!");
            //else
            //    alert("蜂鸣Fail!");
        }
        function RfLoadkey() {
            //MWRFATL.RF_LoadKey("0", "0", "111111111111");
            var Sp = document.all('spass').value;
            MWRFATL.RF_LoadKey("0", "0", Sp);
            aa = MWRFATL.LastRet;
            if (aa == 0) {
                return true;
            }
            else
                return false;
        }
        function RfCard() {
            MWRFATL.MF_Reset(5);
            bb = MWRFATL.OpenCard(1);
            aa = MWRFATL.LastRet;
            if (aa == 0)
                return true;
            else
                return false;
        }

        function RfAuthentication() {
            MWRFATL.RF_Authentication(0, 0);
            aa = MWRFATL.LastRet;
            if (aa == 0)
                return true;
            else
                return false;
        }
        function RfRead() {
            var block = MWRFATL.MF_Read(1); //读取第0扇区第一块数据内容
            aa = MWRFATL.LastRet;
            if (aa == 0) {
                var mycard = (block.slice(0, 32));

                var cdata1 = mycard;
                var len = mycard.length;
                bb = MWRFATL.MF_a_hex(cdata1, len)
                aa = MWRFATL.LastRet;
                if (aa == 0) {
                    document.all('RF_Card').value = mycard;
                    DevBeep();
                    RfExit();
                    return true;
                    //alert(mycard);
                }
            }
            else {
                alert("读卡失败,请重试!");
            }
            return false;
        }
        function RF_ReadCard() {
            if (RfInit()) {
                if (RfLoadkey()) {
                    if (RfCard()) {
                        if (RfAuthentication()) {
                            return RfRead()
                        } else {
                        alert("密码验证失败!");
                        }
                    }
                    else {
                        alert("寻卡失败!");
                    }
                } else {
                alert("装载密码失败!");
            }
            return false;
           }
           else {
               alert("设备初始化失败,请确认资源是否可用且发卡器已准备就绪!");
            }
        }
        
        
    </script>
    <style type="text/css">
        .style1
        {
            height: 18px;
            width: 152px;
        }
        .style2
        {
            height: 18px;
            width: 97px;
        }
        .style3
        {
            height: 18px;
            }
        .style4
        {
            width: 106px;
            height: 60px;
        }
        .style5
        {
            height: 60px;
        }
        .style7
        {
            width: 106px;
        }
        .style10
        {
            height: 23px;
            }
        .style11
        {
            height: 23px;
            width: 97px;
        }
        .style12
        {
            height: 23px;
            width: 152px;
        }
        .style13
        {
            height: 18px;
            width: 106px;
        }
        .style14
        {
            height: 23px;
            width: 106px;
        }
        .style17
        {
            font-size: large;
            font-weight: bold;
            height: 25px;
            color: #33CC33;
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
            background-color: #EAF4F4;
        }
        .style18
        {
            font-size: medium;
            font-weight: bold;
            height: 25px;
            color: #339933;
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
            background-color: #EAF4F4;
        }
        .style19
        {
            font-size: large;
            font-weight: bold;
            height: 25px;
            color: #FF6600;
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
            background-color: #EAF4F4;
        }
        .style20
        {
            font-size: large;
            font-weight: bold;
            height: 25px;
            color: #FF9933;
            border-left-color: #808080;
            border-right-color: #C0C0C0;
            border-top-color: #808080;
            border-bottom-color: #C0C0C0;
            background-color: #EAF4F4;
        }
    </style>
    
    <script type="text/javascript" language="javascript">

        function GetChargeRule(ChargeAmount) {

            $.ajax({

                type: 'GET',

                url: 'rules.ashx',

                dataType: 'text',

                data: 'ctype=' + document.all('TypeName').value + '&amount=' + (getChecked() == 1 ? 0 : ChargeAmount),

                success: function(msg) {
                    var values = msg.split(",");
                    //alert(values[0]);
                    //alert(values[1]);
                    $("#rulename").val(values[0]);
                    $("#gift").val(values[1]);

                },
                error: function(data) {
                    alert('数据异常,请检查输入项是否合法!');
                    document.all('chargeAmount').value = "";
                }

            })

        }
        function GetCardSectorPass() {

            $.ajax({

                type: 'GET',

                url: '../utility/sectorPass.ashx',

                dataType: 'text',

                data: 'req=pass',

                success: function(msg) {
                    document.all('spass').value = msg.toString();


                },
                error: function(data) {
                    return "FFFFFFFFFFFF";
                }

            })

        }
</script>
<script type="text/javascript">
    function getChecked() {
        var vRbtid = document.getElementById("RadioButtonList1");
        //得到所有radio
        var vRbtidList = vRbtid.getElementsByTagName("INPUT");
        for (var i = 0; i < vRbtidList.length; i++) {
            if (vRbtidList[i].checked) {
                var text = vRbtid.cells[i].innerText;
                var value = vRbtidList[i].value;
                //alert("选中项的text值为" + text + ",value值为" + value);
                return value;
            }
        }
    }
    function CloseWin(msg) {
         alert(msg);
         close();

     }
     function openwin() {
         close();
         var balance = document.getElementById("Balance").value;
         balance = balance + "元<br><br>" + document.all('rulename').value;
         //         alert(balance);
         var ow =  window.open("Succ.htm?Balance=" + balance, "newwindow", "height=240, width=450, toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no,left=450,top=320") //写成一行
         //var ow = window.open("Succ.htm?Balance=" + balance, "newwindow", "height=240, width=450, toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no,left=450,top=320")
         //ow.document.open("text/html", "GB2312")
         ow.window.moveTo(parseInt((screen.availWidth - 450) / 2), parseInt((screen.availHeight - 240) / 2)) 
     } 

</script>
</head>
<body onload="GetCardSectorPass();" onunload="RfExit()">
<OBJECT id=MWRFATL style="WIDTH: 0px; HEIGHT: 0px" 
codeBase=http://192.168.1.195:8000/Money/MwRFReader.cab#version=2,0,0,1
data=data:application/x-oleobject;base64,VPpLUhUXNkSyudxeJIvBwwADAAAAAAAAAAAAAA== 
classid=CLSID:BDE9B6B3-4C1D-4C05-8A71-3696F3BF81F5></OBJECT>
<script>
WaitHelper.showWaitMessage();
</script>

    <form id="form1" runat="server">
    <div class="appsection">
    <div align="center" class="box_doubleborder_green" 
            style="width: 480px; text-align: left;">
        &nbsp;<b>∷个人信息</b></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_green" 
            style="width: 490px; height: 130px;">
            <tr>
                <th class="style13">
                    
                        会员姓名</th>
                <td class="style3">
                    <input id="RealName" runat="server" class="inputblue" maxlength="37" name="RealName"
                        style="width: 100px; " type="text" vdisp="会员姓名" readonly="readOnly" />&nbsp;</td>
                <th class="style2">
                   
                    会员卡号</th>
                <td class="style1">
                    <input id="card" runat="server" class="inputblue" maxlength="10" name="card"
                        style="width: 100px; " type="text" vdisp="卡内余额" readonly="readOnly"  />&nbsp;</td>
            </tr>
            <tr>
                <th class="style13">
                    会员编号
                </th>
                <td class="style3">
                    <input id="Userid" runat="server" class="inputblue" maxlength="25" name="Userid"
                        style="width: 100px; " type="text" vmode ="not null" vdisp="卡信息" readonly="readOnly" /></td>
                <th class="style2">
                    移动电话</th>
                <td class="style1">
                    <input id="CellPhone" runat="server" class="inputblue" maxlength="37" name="CellPhone"
                        style="width: 100px; " type="text" vdisp="移动电话" readonly="readOnly" /></td>
            </tr>
            <tr>
                <th class="style14">
                    卡内余额</th>
                <td class="style10">
                    <input id="Balance" runat="server" class="inputblue" maxlength="8" name="Balance"
                        style="width: 100px; " type="text" vdisp="卡内余额" readonly="readOnly" /></td>
                <th class="style11">
                    卡片类别</th>
                <td class="style12">
                    <input id="TypeName" runat="server" class="inputblue" maxlength="15" name="TypeName"
                        style="width: 100px; " type="text" vdisp="卡片类别" readonly="readOnly"/></td>
            </tr>
            <tr>
                <th class="style14">
                    地址</th>
                <td class="style10" colspan="3">
                    <input id="Address" runat="server" class="inputblue" maxlength="100" name="address"
                        style="width: 325px;  " type="text" 
                        vdisp="地址" readonly="readOnly" /></td>
            </tr>
            </table>
        <div align="center" class="div_outborder_blue" 
            style="width: 486px; text-align: left; margin-top:2px; margin-bottom:2px">
        &nbsp;<b>∷充值信息</b></div>
        <table cellpadding="1" cellspacing="1" class="table_default table_green" 
            style="width: 490px; height: 121px;">
            <tr>
                <th class="style13">
                    充值方式</th>
                <td class="style3">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="0">现金充值</asp:ListItem>
                        <asp:ListItem Value="1">退卡退款</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th class="style13">
                    充值金额</th>
                <td class="style3">
                    <span class="style17">￥</span><input id="chargeAmount" runat="server"  onblur="GetChargeRule(this.value)"
                        maxlength="8" name="chargeAmount" onkeyup="if((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46 || /\.\d\d$/.test(value))event.returnValue=false" onafterpaste="if((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46 || /\.\d\d$/.test(value))event.returnValue=false"
                        style="border-style: none none solid none; width: 90px; background-color: #EAF4F4; height: 27px; font-size: large; font-weight: bold; border-bottom-color: #33CC33; color: #006600;" type="text" 
                        vdisp="充值金额" vmode="not null" /><span class="style18">元</span></td>
            </tr>
            <tr>
                <th class="style7">
                    赠送金额</th>
                <td>
                    <span class="style19">￥</span><input id="gift" runat="server" 
                        maxlength="8" name="gift"
                        style="border-style: none none solid none; width: 90px; background-color: #EAF4F4; height: 27px; font-size: large; font-weight: bold; border-bottom-color: #FF9933; color: #FF6600;" type="text" 
                        vdisp="优惠内容"  readonly="readonly" /><span class="style20">元</span>&nbsp; 优惠内容：<input 
                        id="rulename" runat="server" 
                        maxlength="15" name="rulename"
                        
                        
                        
                        
                        style="border-style: none none solid none; width: 160px; background-color: #EAF4F4; height: 27px; font-size: medium; font-weight: normal; border-bottom-color: #0000FF; color: #0000FF;" type="text" 
                        vdisp="会员姓名"  readonly="readonly" /></td>
            </tr>
            <tr>
                <th class="style4">
                    提示&nbsp;</th>
                <td class="style5">
                    <span style="color: red">
                        <br />
                        &nbsp;
                        为卡片充值，根据金额和活动内容可享受一定的充值优惠，具体金额可根据活动细则了解，系统自动根据当前设置的充值比率进行充值。临时卡不享受任何的充值赠送优惠政策，退卡退款操作仅仅适用于临时卡客户<br /><input 
                        id="RF_Card" type="hidden"  runat="server"/>
                    </span><br />
                </td>
            </tr>
        </table>
    
    </div>
    <div align="center" class="div_outborder_blue" 
        style="width: 488px; text-align: right;">
  <input id="btnJieGua0" runat="server" class="btn01" name="btnJieGua0" onclick="if(!RF_ReadCard()) return false;"
            onserverclick="btnReadCard_Click" type="button" value="读 卡" />
       <%-- <input id="btnJieGua0" runat="server" class="btn00" name="btnJieGua0" 
            onserverclick="btnReadCard_Click" type="button" value="读 卡"/>--%>
        <input id="btnJieGua" runat="server" class="btn02" name="btnJieGua" onclick="if(!doAllMessageBoxValidate(form1)) return false;"
            onserverclick="btnCharge_Click" type="button" value="确 定" />
        <input id="BtnCancel" runat="server" class="btn00" name="BtnCancel" 
            onclick="JavaScript:window.close()" type="button" value="取 消" /> </div>
</form>
<script>
WaitHelper.initWaitMessageForms("form1");  
</script>
<p>
    <input id="spass" type="hidden"  value="FFFFFFFFFFFF"/>
</p>
</body>
</html>


