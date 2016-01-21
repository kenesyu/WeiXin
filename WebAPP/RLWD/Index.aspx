<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebAPP.RLWD.Index" %>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />
    <title>瑞龙武道网络评选活动</title>
    <link rel="stylesheet" href="css/base.css"/>
    <link rel="stylesheet" href="css/style.css">
    <script src="js/jquery-1.8.0.js"></script>
    <script src="js/js.js"></script>
</head>
<body class="bg">
<form id="form1" runat="server">
<section class="search">
    <input type="text" id="searchKey" runat="server" placeholder="序号搜索"/>
</section>

<ul class="list hz-hid" id="masonry">
<asp:Repeater runat="server" id="repList">
    <ItemTemplate>
     <li class="article">
        <div class="box por">
              <div class="img hz-hid por">
                <img src="header/<%# Eval("id") %>.jpg" alt=""/>
                <i><%# Eval("rowNum") %></i>
                <div class="bottom"><%# Eval("CountNum") %> 票</div>
            </div>
            <div class="box-bottom">
                <span class="dib fl"><%# Eval("Name") %></span>
                <span class="num">
                    <span>No.</span><span class="f24"><%# Eval("id") %></span>
                </span>
                <a href="tp.aspx?id=<%# Eval("id") %>" style="display:none">投票</a>
            </div>
        </div>
    </li>
    </ItemTemplate>
</asp:Repeater>
</ul>


<script src="js/jaliswall.js"></script>
<script>
    $(function () {
        $('#masonry').jaliswall({ item: '.article' });
    });

 </script>
 </form>
</body>
</html>