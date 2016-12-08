<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthCard_Add.aspx.cs" Inherits="MonthCard_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="../css/table.css" />
       <script src="../jquery/jquery-1.9.1.min.js" type="text/javascript"></script>
   
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../js/app.edit.js"></script>
  
<link href="../jquery/wbox/wbox/wbox.css" rel="stylesheet" type="text/css" />
<script src="../jquery/wbox/wbox/mapapi.js" type="text/javascript"></script>
<script src="../jquery/wbox/wbox.js" type="text/javascript" charset="utf-8"></script>    

    <script type="text/javascript" src="../js/app.validate.js" charset="gb2312"></script>
  <link href="../css/xu.css" type="text/css" rel="stylesheet" />
    <link href="../css/demo.css" type="text/css" rel="stylesheet" />
    <script src="../js/laydate.js"></script>
    <link href="../css/laydate.css" rel="stylesheet" type="text/css" />
     <link href="../css/laydate(1).css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">

        var getid = document.getElementById("showTable");
        //调用
        function ShowTsite() {
            //width:335px;background-color:#C3D3F7;
            getid.style.cssText = "position:absolute;z-index:100;width:320px;background-color:#C3D3F7;display:block;border:0px;";
        }

        function hedeTsite(obj) {
            if (obj == "Confirm") {
                getid.style.cssText = "display:none;";
            }
            else {
                var getid = document.getElementById("Tsiet");
                getid.c
            }
        }

        function Check(msg) {
            if (msg != "")
                alert(msg);
        }

        function CloseWin(msg) {
            if (msg != "")
                alert(msg);
//            window.setTimeout('document.all("btnclose").click();parent.location.href="MonthCard.aspx";', 1 * 1000);
        }
    </script>
  <style type="text/css">

    *{margin:0;padding:0;list-style-type:none;outline:none;}
    a,img{border:0;}
    body{font:12px/normal "microsoft yahei";}
    .selectbox{width:400px;height:220px;}
    .selectbox div{float:left;}
   .select-bar
    {   
        padding:0 20px;
       overflow-x:hidden;
       overflow-y:hidden;
    }
    
    
    .selectbox .select-bar select{width:130px;height:150px;border:1px #A0A0A4 solid;padding:4px;font-size:14px;font-family:"microsoft yahei";}
    .btn-bar{}
    .btn-bar p{margin-top:5px;}
    .btn-bar p .btn{width:50px;height:30px;cursor:pointer;font-family:simsun;font-size:14px;}
    
</style>
<script type="text/javascript" >

    function doInforEdit(id) {
        $("#isFrameOpt").wBox({
            requestType: "iframe",
            target: "../Member/MemberSendCard.aspx?id=" + id
        });
        $("#isFrameOpt").trigger("click");
    }
    
$.ajaxSetup({
            async: false
        });
       
 function ajaxGetCar() {
    var val = document.getElementById("igCarNumber1").value;
    if (val != "") {
        $.ajax({
            type: "POST",
            url: "MonthCard_Add.aspx/GetCarNumber",
            contentType: "application/json; charset=utf-8",
            data: "{val:'" + val + "'}",
            dataType: "json",
            success: function(result) {
                if (result.d == "3") {
                    var r = window.confirm("用户还没注册，请先注册!");
                    if (r) {
                        doInforEdit(val);
                    }
                }
                else if(result.d == "2")
                {
                    alert("用户已经是会员！");
                }
                else if (result.d == "1") {
                    $("#table1").hide();
                    $("#next").hide();
                    $("#table2").show();
                    $("#btnUpdate").show();
                    $("#igCarNumber").val(val);
                }
            }
        });
        }
    }
    function oitems()
　　　　{　
　　　　　　var sel = document.getElementById("select2");
　　　　　  var selValue="";
　　　　　　for(var i=0; i < sel.length; i++)
　　　　　　{
　　　　　　　selValue += sel.options[i].value+",";
　　　　　　}
　　　　　　$("#SupportSites").val(selValue);
　　　　　　
　　　　}
　　　
　　　　
　　　　function ajaxPay(pay,text)
　　　　{
　　　　    var igCarNum,TypeName,Month,Support,Balance,time;
　　　　    igCarNum = $("#igCarNumber1").val();
　　　　    TypeName = $("#TypeID").val();
            Month = $("#numMonths").val();
            Support = $("#SupportSites").val();
            time = $("#igCreateTime").val();
            //
　　　　    $.ajax({
                type: "POST",
                url: "MonthCard_Add.aspx/btnUpdate_Click",
                contentType: "application/json; charset=utf-8",
                data: "{igCarNum:'" + igCarNum + "',TypeName:'"+TypeName+"',pay:'"+pay+"',Month:'"+Month+"',Support:'"+Support+"',Balance:'"+text+"',time:'"+time+"'}",
                dataType: "json",
                success: function(result){
                 alert(result.d);
                }
            })
　　　　
　　　　}
    var text;
    $(function() {
        $("#igCarNumber1").change( function(){
            var str = $("#igCarNumber1").val(); 
            str = str.replace(/\s+/g,"");
           $("#igCarNumber1").val(str);
        });
        $("#btnUpdate").click(function(){
             if($("#CashPay").attr("checked")){  
                        ajaxPay("1",text);
             }
            else if($("#BalancePay").attr("checked")){
                        ajaxPay("0",text);
             }
             else
             {
                alert("未支付！");
             }
                
            })
    
        $("#CashPay").click(function(){
            text =  $("#balance").val();
            if(text=="")
                {
                     $("#CashPay").attr("checked",false);
                      return alert("支付金额为空！");}
            else{
                 if($("#BalancePay").attr("checked")){
                     var r = window.confirm("是否现金支付"+text+"元!");
                        if (r) {
                            $("#BalancePay").attr("checked", false);
                        }
                 }
                 else if($("#CashPay").attr("checked"))
                 {
                   alert("是否现金支付"+text+"元!");
                 }
            }
        })
        
        $("#BalancePay").click(function(){
            text =  $("#balance").val();
            if(text=="")
                { 
                    $("#BalancePay").attr("checked",false);
                    return alert("支付金额为空！");
                }
            else{
                    if($("#CashPay").attr("checked"))
                    {
                        var r = window.confirm("是否余额支付"+text+"元!");
                            if (r) {
                                   $("#CashPay").attr("checked", false);
                            }
                    }
                    else if($("#BalancePay").attr("checked"))
                    {
                        alert("是否余额支付"+text+"元!");
                    }
             }
        })

        $("#Cardid").change(function() {
                    var text = $(this).find("option:selected").attr("money");
                    var tid = $(this).find("option:selected").val();
                    var numMonths = $(this).find("option:selected").attr("numMonths");
                    $("#Smoney").html(text);
                    $("#Add_Balance").html(text);
                    $("#TypeID").val(tid);
                    $("#numMonths").val(numMonths);
            
        });
        

        $('#add').click(function() {

            if (!$("#select1 option").is(":selected")) {
                alert("请选择需要移动的选项");
            }
            else {
                $('#select1 option:selected').appendTo('#select2');
            }
            oitems();
        });
        $('#remove').click(function() {
           
            if (!$("#select2 option").is(":selected")) {
                alert("请选择需要移动的选项");
            }
            else {
                $('#select2 option:selected').appendTo('#select1');
            }
             oitems();
        });

        $('#add_all').click(function() {

            $('#select1 option').appendTo('#select2');
            oitems();
        });

        $('#remove_all').click(function() {
            $('#select2 option').appendTo('#select1');
            oitems();
        });

        $('#select1').dblclick(function() {

            $("option:selected", this).appendTo('#select2');
            oitems();
        });

        $('#select2').dblclick(function() {
            $("option:selected", this).appendTo('#select1');
            oitems();
        });
    });
   
      function CloseWin(msg)
    {
        if(msg != "")
        alert(msg);

    }   
</script>

</head>
<body>

<script>
        WaitHelper.showWaitMessage();
    </script>

    <form id="form1" runat="server" >
    <a id="isFrameOpt" href="javascript:void(0)" style="display:none">isFrameOpt</a>
    <a id="btnclose" class="wBox_close" href="javascript:void(0);" style="display:none;">关闭</a>
    <div class="appsection" style=" float:left; margin-top:0px;">
                 <div move="ok" class="xubox_title" style="cursor: move;"><em>会员开卡</em></div>
     <table id="table1" cellpadding="1" cellspacing="1" class="table_default table_blue" style="width: 500px"> 
         <tr>
                <th style="height: 18px; width: 105px;">
                    <label style="color: Red; height: 18px;">
                        <span style="color: #1e3739;">车牌号码</span><label style="color: Red; height: 18px;">*</label></label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" style="width:150px" id="igCarNumber1"  runat="server" maxlength="20" />
                </td>
            </tr>
     </table>
   
        <table id="table2" cellpadding="1" cellspacing="1" class="table_default table_blue" style=" display:none; width: 500px">
            <tbody>
                <tr>
                <th style="height: 18px; width: 105px;">
                    <label style="color: Red; height: 18px;">
                        <span style="color: #1e3739;">车牌号码</span><label style="color: Red; height: 18px;">*</label></label>
                </th>
                <td style="height: 18px">
                    <input type="text" class="inputblue" style="width:150px" id="igCarNumber"  runat="server" maxlength="20" name="pid" />&nbsp;
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">选择卡类型<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
              <%--  <div id="divCradType"><select id="Cardid" style="width: 150px" class="inputblue"><option value="T-15117103534" money="51.00">1</option><option value="T-15117102031" money="51.00">季卡</option><option value="T-1511710211" money="53.00">月卡</option> </select>￥<label id="Smoney" style="color: Red; height: 18px;">53.00</label></div>--%>
                    <div id="divCradType" runat="server">
                         
                    </div>
                   
                </td>
            </tr>
             <tr>
                <th style="height: 18px; width: 105px;">支付金额<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <input type="text" style=" margin-left:20px;" id="balance"  runat="server"  />&nbsp;
                </td>
                
            </tr>
             <tr>
                <th style="height: 18px; width: 105px;">现金支付<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <input type="checkbox"  style=" margin-left:20px;" id="CashPay"  runat="server"  />&nbsp;
                </td>
                
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">余额支付<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                   <input type="checkbox"  style=" margin-left:20px;"  id="BalancePay"  runat="server"   />&nbsp;
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px;">开始日期<label style="color: Red; height: 18px;">*</label>
                </th>
                <td style="height: 18px">
                    <div class="inline layinput"  style="float:left;margin-left:20px; border:1px solid #B8E1F6; width:152px; height:25px;"><input placeholder="YYYY-MM-DD hh:mm:ss" runat="server" style=" font-size:11px; " id="igCreateTime" onclick="laydate({istime: true, format: &#39;YYYY-MM-DD hh:mm:ss&#39;})" /></div>
                </td>
            </tr>
            <tr>
                <th style="height: 18px; width: 105px; "><span style="float:left; height:20px; width:auto; margin-top:-50px; text-align:center;">添加停车路段 <label style="color: Red; height: 18px;  margin-top:10px;">*</label></span>
                </th>
                 <td>
                <div class="selectbox">
                    <div class="select-bar">
                        <select size="8" runat="server" id="select1">  
                        </select>
                    </div>

                    <div class="btn-bar">
                        <p><span id="add"><input type="button" class="btn" value=">" title="移动选择项到右侧"/></span></p>
                        <p><span id="add_all"><input type="button" class="btn" value=">>" title="全部移到右侧"/></span></p>
                        <p><span id="remove"><input type="button" class="btn" value="<" title="移动选择项到左侧"/></span></p>
                        <p><span id="remove_all"><input type="button" class="btn" value="<<" title="全部移到左侧"/></span></p>
                    </div>

                    <div class="select-bar">
                        <select size="8" runat="server" id="select2"></select>
                    </div>	
                  </div>
                </td>
            </tr>
            </tbody>
        </table>
        <input type="hidden" value="" id="igID"  runat="server" />
        <input type="hidden" value="<%#Typid %>" id="TypeID"  runat="server" />
        <input type="hidden" value="<%#numM %>" id="numMonths"  runat="server" />
        <input type="hidden" value="" id="SupportSites"  runat="server" />
        <input type="hidden" value='<%#SMoney %>' id="Add_Balance"  runat="server" />
    </div>
    <div class="appsection">
        <div class="section_operators" style="width: 400px" align="center">
        
          <input type="button" id="next" value="下一步" class="xybtn"  onclick="ajaxGetCar()"  />
          
           <input type="button" id="btnUpdate"   runat="server" value="提交" class="xybtn"  style="display:none;"  />
          <input type="button" name="btnCon" class="btn003" value="关闭" onclick="JavaScript:window.close();" style="display:none;" id="Button2" />
          
        </div>
    </div>
    
    </form>

<script>
        WaitHelper.initWaitMessageForms("Form1");  
    </script>

</body>
</html>
