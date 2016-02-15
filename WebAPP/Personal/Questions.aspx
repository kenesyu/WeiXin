<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Questions.aspx.cs" Inherits="WebAPP.Personal.Questions" %>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />
    <title>身体健康水平测试</title>
    <link rel="stylesheet" href="css/base.css"/>
    <link rel="stylesheet" href="css/style.css">
    <script src="js/jquery-1.8.0.js"></script>
    <script src="js/jquery.cookie.js"></script>
    <script src="js/js.js"></script>
</head>
<body>
<form runat="server" id="form1">
<header>
    身体健康水平测试
</header>

<section class="ceshi hz-hid"  id="sectionPart">
    <%=strHtml %>
<%--    <section class="t">一、最近两个月持续三十分以上的运动，平均每周几次？</section>
    <div class="time-0 hz-hid">
        <label class="checked">
            <input type="checkbox" checked/><span>A小于一次/周</span>
        </label>
        <label>
            <input type="checkbox"/><span>A小于一次/周</span>
        </label>
        <label>
            <input type="checkbox"/><span>A小于一次/周</span>
        </label>
    </div>
    <section class="t t-0">二、心率测试水平</section>
    <input type="text" name="xinlv" value="安静心率次/每分钟" onfocus="if(value=='安静心率次/每分钟') value=''" onblur="if(value=='') value='安静心率次/每分钟'"/>
    <section class="t t-1">二、身体基本数据</section>

    <div class="body-data hz-hid">
        <select name="" id="">
            <option value="">性 别</option>
        </select>
        <select name="" id="">
            <option value="">身 高</option>
        </select>
    </div>--%>
    <input type="text" style="display:none"  value="" runat="server" id="txtOpenid">
</section>

<section class="chu-2">
<%--    <a href="" class="fl">上一题</a>
    <a href="" class="fr">重参考结果</a>--%>
    <asp:LinkButton runat="server" ID="LinkPre" CssClass="fl" 
    onclick="LinkPre_Click"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="LinkNextOrSubmit" CssClass="fr" 
    onclick="LinkNextOrSubmit_Click" OnClientClick="return CheckInput()"></asp:LinkButton>
</section>

<script type="text/javascript">
    $(function () {
        var l = $('.time-0 label');
        l.click(function () {
            $(this).addClass('checked');
            $(this).find('input').attr('checked', 'checked');
            $(this).siblings('label').removeClass('checked');
            $(this).siblings('label').find('input').removeAttr('checked');
        })
    })

    function CheckInput() {
        <%=strScript %>
    }

    <%=BindScript %>

</script>
</form>
</body>
</html>