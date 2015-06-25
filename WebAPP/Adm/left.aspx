<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="WebAPP.Adm.left" %>

<!DOCTYPE htm PUBLIC "-//W3C//DTD Xhtm 1.0 Transitional//EN" "http://www.w3.org/TR/xhtm1/DTD/xhtm1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtm">
<head>
    <meta http-equiv="Content-Type" content="text/htm; charset=utf-8" />
    <title>无标题文档</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="js/jquery.js"></script>
    <script type="text/javascript">
        $(function () {
            //导航切换
            $(".menuson li").click(function () {
                $(".menuson li.active").removeClass("active")
                $(this).addClass("active");
            });

            $('.title').click(function () {
                var $ul = $(this).next('ul');
                $('dd').find('ul').slideUp();
                if ($ul.is(':visible')) {
                    $(this).next('ul').slideUp();
                } else {
                    $(this).next('ul').slideDown();
                }
            });
        })	
    </script>
    <style>
        .span 
        {
            margin:0;padding:0;display:block;
        }
    </style>
</head>
<body style="background: #f0f9fd;">
    <div class="lefttop">
        <span></span><a href="index.htm" target="rightFrame">首页</a></div>
    <dl class="leftmenu">
        <dd>
            <div class="title">
                <span>
                    <img src="images/leftico01.png" /></span>教练管理
            </div>
            <ul class="menuson">
                <li><cite></cite><a href="jl_list.aspx" target="rightFrame">教练列表</a><i></i></li>
                <li><cite></cite><a href="jl_add.aspx" target="rightFrame">添加教练</a><i></i></li>
            </ul>
        </dd>
        <dd><div class="title"><span><img src="images/leftico03.png" /></span>系统设置</div>
        <ul class="menuson">
<%--            <li><cite></cite><a href="xt_mima.htm" target="rightFrame">密码修改</a><i></i></li>
            <li><cite></cite><a href="#">权限设置</a><i></i></li>--%>
<!--            <li><cite></cite><a href="#">活动列表</a><i></i></li>-->
    <!--        <li><cite></cite><a href="#">其他</a><i></i></li>-->
        </ul>    
        </dd>  
    </dl>
</body>
</html>