<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ResetStatus.aspx.cs" Inherits="main_ResetStatus" StylesheetTheme="app"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>��ϯ״̬�ָ�</title>
        <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
        <link href="../css/app.newedit.css" rel="stylesheet" type="text/css" />
        <link href="../css/app.intab.css" rel="stylesheet" type="text/css" />
         <script language="javascript" type="text/javascript">
            function Check()
            {
                if(document.getElementById("curagentid").value=="")
                {
                     alert("��������ϯ����/����ڹ���")
                    return false;
                }
                else
                {
                    if(confirm('ȷ�ϻָ���¼״̬��?'))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                }
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="resetStatus" style="left: 10px; position: absolute; top: 51px; width: 287px; height: 26px;">
    <table  cellpadding="1" cellspacing="1" class="table_default table_green">
        <tr>
            <th style="width: 58px; height: 25px">�û�/����ڹ���</th>
            <td style="width: 217px; height: 25px">
                <asp:TextBox ID="curagentid" runat="server"></asp:TextBox>
                <asp:Button ID="btnBackLogin" runat="server" CssClass="btn003" Text="�ָ�" OImsientClick="if(Check()) return true; else return false;" OImsick="btnBackLogin_Click" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
