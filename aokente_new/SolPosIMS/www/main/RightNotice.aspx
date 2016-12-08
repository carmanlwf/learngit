<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RightNotice.aspx.cs" Inherits="main_RightNotice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script src="../jquery/1.822/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
    
        $(function() {
            var maxLi = 10;
            setInterval(function() {
                //首先判断是否达到最大容量
                var $noticeList = $("#noticeList");
                if ($noticeList.children("li").length >= maxLi) {
                    $noticeList.children(":last").fadeOut(1000, function() {
                        $(this).remove();
                    })
                }
                //$.post //请求后台数据

                var $li = $("<li>").text("测试数据" + new Date().getTime()).css("display", "none");
                $noticeList.prepend($li);
                $li.fadeIn(1000);
            }, 2000);
        })
    </script>
</head>


<body>
    <form id="form1" runat="server">
    <ul id="noticeList">
    </ul>
    </form>
</body>
</html>
