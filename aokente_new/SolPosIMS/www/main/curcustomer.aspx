<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="curcustomer.aspx.cs"
    Inherits="main_curcustomer" StylesheetTheme="app" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
    <title>��ݲ˵�</title>

    <script language="JavaScript" type="text/javascript" src="../js/app.edit.js"></script>


    <script type="text/javascript">

function doOnLoad()
{
    setAutoHidden();
}

function setAutoHidden()
{
	var followImg = document.getElementById("autohiddenimg");
	var rightfollowImg = top.document.getElementById("rightfollowImg");
	if(rightfollowImg.onmousemove != null )
	{
		followImg.src = "../images/autohidden2.gif";
	}else
	{
		followImg.src = "../images/autohidden1.gif";
	}
}

function switchAutoHidden()
{
	var followImg = document.getElementById("autohiddenimg");
	var rightfollowImg = top.document.getElementById("rightfollowImg");
	if(rightfollowImg.onmousemove != null )
	{
		followImg.src = "../images/autohidden1.gif";
		rightfollowImg.onmousemove = null;
	}else
	{
		followImg.src = "../images/autohidden2.gif";
		rightfollowImg.onmousemove = rightfollowImg.onclick;
	}
}
function getCurrentCustomerId()
{
    var cust_id = curCustInfo.getCurrentCustomerId();
    return cust_id;
}

function refreshCallInfoList()
{
    hisCallInfoList.refreshCallInfoList(); 
}


function doReloadCustInfo(url)
{
    try
    {
        curCustInfo.WaitHelper.showWaitMessage();
    }catch(e){}
    curCustInfo.location.href = url;
    hisCustServiceList.location.href = hisCustServiceList.location.href;
    
}
function refleshCurrentCustomerInfo()
{
    try
    {
        curCustInfo.WaitHelper.showWaitMessage();
    }catch(e){}
    curCustInfo.location.href = curCustInfo.location.href;
}
    </script>

    <script type="text/javascript">

    function szrc(){
        document.getElementById('szrbb').style.display="none";
        document.getElementById('szrc').style.display="none";
        document.getElementById('szr').style.display="inline";
    }
    function szr(){
        document.getElementById('szrbb').style.display="none";
        document.getElementById('szr').style.display="none";
        document.getElementById('szrc').style.display="inline";
    }
    function szrbb(){
        document.getElementById('szrc').style.display="none";
        document.getElementById('szr').style.display="none";
        document.getElementById('szrbb').style.display="inline";
    }
    
    </script>
</head>
<body onload="doOnLoad()" style="margin:0px;">
    <form runat="server" id="form1"><table border="0" cellpadding="0" 
        cellspacing="0" style="width: 100%; background-color: #3366FF">
            <tr>
                <td style="width: 100px; height: 20px; font-weight: bold; color: white;">

<img id="autohiddenimg" onclick="switchAutoHidden()" class="titlepopupimg" alt="�Զ�����" />���Ա���ٲ�ѯ</td>
            </tr>
        </table>
        <table
    cellpadding="1" cellspacing="0" style="width: 230px">
    <tr>
        <th style="height: 25px; border-bottom: #4ec6fa 1px solid; font-weight: bold;">
            ��Ա����</th>
        <td style="height: 25px; border-bottom: #4ec6fa 1px solid;">
            <input id="Card" runat="server" class="inputgreen" maxlength="16" name="Card"
                onfocus="setday(this)" style="width: 100px" type="text" vdisp="��ʼʱ��" vtype="date" />
            <input id="Button1" style="border-right: #4ec6fa 1px solid; border-top: #4ec6fa 1px solid;
                border-left: #4ec6fa 1px solid; width: 40px; color: #4ec6fa; border-bottom: #4ec6fa 1px solid;
                height: 20px; background-color: #ffffff" type="button" value="����" onserverclick="Button1_ServerClick" runat="server" /></td>
    </tr>
            <tr>
                <th colspan="2" 
                    style="height: 1px; background-color: #3366FF; text-align: left">
                </th>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� ����</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="RealName" runat="server" class="inputgreen" maxlength="20" name="RealName"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� ��</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="sex" runat="server" class="inputgreen" maxlength="20" name="sex"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� ����</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="CellPhone" runat="server" class="inputgreen" maxlength="20" name="CellPhone"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� ����</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="RankName" runat="server" class="inputgreen" maxlength="20" name="RankName"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    ״ ̬��</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="statusname" runat="server" class="inputgreen" maxlength="20" name="statusname"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� �</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="Balance" runat="server" class="inputgreen" maxlength="20" name="Balance"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� �֣�</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="Points" runat="server" class="inputgreen" maxlength="20" name="Points"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �����ܶ</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="Expenditure" runat="server" class="inputgreen" maxlength="20" name="Expenditure"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �����ŵ꣺</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="sitename" runat="server" class="inputgreen" maxlength="20" name="sitename"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    ע��ʱ�䣺</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="addeddate" runat="server" class="inputgreen" maxlength="20" name="Points"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    ��Ч���ڣ�</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    <input id="validDate" runat="server" class="inputgreen" maxlength="20" name="validDate"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �ϴ����ѣ�</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px"><input id="LastConsumeTime" runat="server" class="inputgreen" maxlength="20" name="LastConsumeTime"
                onfocus="setday(this)" style="width: 140px" type="text" vdisp="��ʼʱ��" vtype="date" /></td>
            </tr>
            <tr>
                <th colspan="2" style="font-weight: bold; width: 100px; color: white; height: 20px;
                    background-color: #3366FF; text-align: left">
                    �൱ǰ��¼��Ϣ</th>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� �ţ�</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    <asp:Label ID="Label1" runat="server" Text="δ֪"></asp:Label></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� ����</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    <asp:Label ID="Label2" runat="server" Text="δ֪"></asp:Label></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �� ����</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    <asp:Label ID="Label3" runat="server" Text="δ֪"></asp:Label></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    ��������</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    <asp:Label ID="Label4" runat="server" Text="δ֪"></asp:Label></td>
            </tr>
            <tr>
                <th style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    �汾�ţ�</th>
                <td style="color: gray; border-bottom: #4ec6fa 1px solid; height: 25px">
                    <asp:Label ID="Label5" runat="server" Text="δ֪"></asp:Label></td>
            </tr>
    <tr>
        <td align="right" colspan="4">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
    </tr>
</table>
    </form>
</body>
</html>
