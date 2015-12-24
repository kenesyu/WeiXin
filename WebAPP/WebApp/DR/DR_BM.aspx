<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DR_BM.aspx.cs" Inherits="WebAPP.WebApp.DR.DR_BM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>东软平板支撑比赛-报名页面</title>
    <link rel="stylesheet" href="/css/listStyle.css"/>
    <link rel="stylesheet" href="/css/myactive.css"/>
    <link rel="stylesheet" href="/css/select.css"/>
    <link href="/css/bootstrap-reset.css" rel="stylesheet">
    <link href="/css/style-responsive.css" rel="stylesheet" />
    <link href="/css/style.css" rel="stylesheet">
    <link href="/css/bootstrap.css" rel="stylesheet">
    <link href="/css/bootstrap-reset.css" rel="stylesheet">
    <link href="/css/style.css" rel="stylesheet">
    <link href="/css/style-responsive.css" rel="stylesheet" />
    <link rel="stylesheet" href="/css/form.css"/>
    <link rel="stylesheet" href="/css/myactive.css"/>
    <link rel="stylesheet" href="/css/select.css"/>
    <link rel="stylesheet" href="/css/datePicter.css"/>
    <!--<link rel="stylesheet" href="css/var.css"/>-->
    <!--个人头像的公共部分-->
    <link rel="stylesheet" href="/css/homepage.css"/>
    <link rel="stylesheet" href="/css/tantiao.css"/>
    <link rel="stylesheet" href="/css/font.css"/>
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/aply.js"></script>
    <script type="text/javascript" src="/js/active.js"></script>
</head>
<body>
<!--标题-->
<form runat="server" id="form1" onsubmit="return Submit()">
<div class="title">
    <h3>平板支撑比赛报名</h3>
</div>
<!--姓名-->
<div class="faqiList">
    <div class="faqiListName">姓名</div>
    <div class="chatFootI floatLeft input input--minoru faqiListDist font14" >
        <input type="text" id="txtopenid" runat="server" value="" style="display:none">
        <input type="text" class="input__field input__field--minoru"  id="txtName" runat="server" placeholder="请输入姓名">
    </div>
</div>
<!--电话-->
<div class="faqiList">
    <div class="faqiListName">电话</div>
    <div class="chatFootI floatLeft input input--minoru faqiListDist font14" >
        <input type="text" class="input__field input__field--minoru"  id="txtTel" runat="server" placeholder="请输入电话号码">
    </div>
</div>
<!--系别-->
<div class="faqiList">
    <div class="faqiListName">系别</div>
    <div class=" floatRight border1 cs300">
        <section>
            <select class="cs-select cs-skin-border" id="selX" runat="server">
<%--                <option value="" disabled selected>活动状态</option>
                <option value="email">体育系</option>
                <option value="twitter">美术系</option>
                <option value="linkedin">音乐系</option>
                <option value="linkedin">数学系</option>
                <option value="linkedin">化学系</option>--%>
            </select>
        </section>
    </div>
</div>
<!--报名button-->
    <asp:Button ID="btnSubmit" runat="server" Text="确认报名" 
    class="ui-btn pay-btn" onclick="btnSubmit_Click"/>
<!--弹出层-->
<%--<div class="tanBox">
    <div class="innerBox">
        <div class="title marginTop">
            <div>你已经成功报名</div>
        </div>
        <div class="title marginTop">
            <div>你的报名序号是：12345</div>
        </div>
        <div class="ui-btn pay-btn break ">关闭</div>
    </div>
</div>--%>
</form>
</body>
</html>
<script type="text/javascript" src="/js/classie.js"></script>
<script type="text/javascript" src="/js/selectFx.js"></script>
<script>
    (function () {
        [ ].slice.call(document.querySelectorAll('select.cs-select')).forEach(function (el) {
            new SelectFx(el);
        });
    })();

    function Submit(){
        if ($("#txtName").val() == "") {
            alert("请输入姓名");
            return false;
        }

        if ($("#txtTel").val() == "") {
            alert("请输入电话");
            return false;
        }


        if ($("#selX").val() == "") {
            alert("请选择所属院系");
            return false;
        }
        return true;
    }

</script>