<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuList_Operator.aspx.cs" Inherits="Notice_MenuList_Operator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>操作员快捷菜单</title>
 <script src="js/jquery-latest.js"></script>
  		<script type="text/javascript">
  		    $(document).ready(function() {

  		        $("li").mouseover(function() {
  		            $(this).removeClass("inactive");
  		            $(this).addClass("active");
  		            $("li.active").animate({ width: "200px" }, 500);
  		            $("li.inactive").animate({ width: "100px" }, 500);
  		        });
  		        $("li").mouseout(function() {
  		            $(this).removeClass("active");
  		            $(this).addClass("inactive");
  		            $("li").animate({ width: "125px" }, 500);
  		        });

  		    });
		</script>
		<style type="text/css">
			ul li {
				list-style-type: none;
				width: 125px;
				height: 100px;
				margin-right: 10px;
				float: left;
				overflow: hidden;
			}
			a img {
				border: 0;
			}
		</style>
	</head>
	<body >
<br />
<br />
<br />
<br />
<br />
<div style="width:100%">
		<ul style=" margin-left:300px;">
			<li class="inactive"><a href=""><img src="images/products.jpg" alt=""/></a></li>
			<li class="inactive"><a href=""><img src="images/history.jpg" alt=""/></a></li>
			<li class="inactive"><a href=""><img src="images/news.jpg" alt=""/></a></li>
			<li class="inactive"><a href=""><img src="images/urideas.jpg" alt=""/></a></li>
		</ul>
</div>
</body>
</html>