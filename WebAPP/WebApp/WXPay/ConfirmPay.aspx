﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmPay.aspx.cs" Inherits="WebAPP.WebApp.WXPay.ConfirmPay" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>在线支付</title>

    <!-- Bootstrap core CSS -->
    <link href="../../css/bootstrap.min.css" rel="stylesheet">
    <link href="../../css/bootstrap-reset.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../../css/style.css" rel="stylesheet">
    <link href="../../css/style-responsive.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../css/form.css"/>

    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/jquery.js" type="text/javascript"></script>
    <script language="javascript" src="http://res.mail.qq.com/mmr/static/lib/js/lazyloadv3.js" type="text/javascript"></script>
    <script src="../../js/jquery-1.8.3.min.js"></script>
    <script language="javascript" src="../../ScriptsLib/Core/IsTech_core.js" type="text/javascript"></script>
    <script language="javascript" src="../../ScriptsLib/Core/IsTech_form.js" type="text/javascript"></script>
    <script language="javascript" src="../../ScriptsLib/CustomerServices.js" type="text/javascript"></script>
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 tooltipss and media queries -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>

<body>
<!--main content start-->
<form runat="server" id="from1">
<section id="main-content">
    <section class="wrapper">
        <!-- page start-->
        <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                    <header class="panel-heading">
                        商品信息
                    </header>
                    <table class="table">

                        <tbody>

                    <table class="table">

                        <tbody>
                        <div class="container">
                            <div class="row col-lg-3 break-word font14">订单号：</div>
                            <div class="row col-lg-6 border-bottom break-word"><asp:Label ID="lblOrderNo" runat="server"></asp:Label></div>
                        </div>
                        <div class="container">
                            <div class="row col-lg-3 break-word font14">商品名称：</div>
                            <div class="row col-lg-6 border-bottom break-word"><asp:Label ID="lblProductName" runat="server"></asp:Label></div>
                        </div>
                        <div class="container">
                            <div class="row col-lg-3 break-word font14">支付金额：</div>
                            <div class="row col-lg-6 border-bottom-none break-word"><span style="color: red"><asp:Label ID="lblPrice" runat="server"></asp:Label>元</span></div>
                        </div>
                        <div class="container">
                            <div class="row col-lg-3 break-word font14">使用说明：</div>
                            <div class="row col-lg-6 border-bottom-none break-word"><asp:Label ID="lblDetails" runat="server"></asp:Label></div>
                        </div>
                        <div class="container">
                            <div class="row col-lg-3 break-word font14">姓名：</div>
                            <div class="row col-lg-6 border-bottom-none break-word"><asp:TextBox runat="server" ID="txtName"></asp:TextBox></div>
                        </div>
                        <div class="container">
                            <div class="row col-lg-3 break-word font14">电话：</div>
                            <div class="row col-lg-6 border-bottom-none break-word"><asp:TextBox runat="server" ID="txtTel"></asp:TextBox></div>
                        </div>
                        </tbody>
                    </table>
                </section>
            </div>
        </div>
        <!-- page end-->
    </section>
</section>
<!--main content end-->
<input type="button" class="ui-btn pay-btn" ID="BtnSave" value="确认支付" onclick="SavePay()" />
        </form>
</body>
</html>
<script type="text/javascript">

    function SavePay() {
        if ($("#txtName").val() == "" || $("#txtTel").val() == "") {
            alert("请添写姓名和联系电话!");
            return false;
        }    

        
        WeixinJSBridge.invoke('getBrandWCPayRequest', {
            "appId": "<%= WeiPay.PayConfig.AppId %>", //公众号名称，由商户传入
            "timeStamp": "<%= TimeStamp %>", //时间戳
            "nonceStr": "<%= NonceStr %>", //随机串
            "package": "<%= Package %>", //扩展包
            "signType": "MD5", //微信签名方式:1.sha1
            "paySign": "<%= PaySign %>" //微信签名
        },
               function (res) {
                   if (res.err_msg == "get_brand_wcpay_request:ok") {
                       SentCustomer();
                   } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                       alert("您取消了支付!");
                   } else {
                       alert(res.err_msg);
                       alert("支付失败!");
                   }
                   // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                   //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
               });
           }

           function SentCustomer() {
               IsTechForm.Post("/BussinessService/CustomerService.asmx/SentKey", { openid: '<%=o %>', code: '<%=s %>', productid: '<%=p %>', name: $("#txtName").val(), tel: $("#txtTel").val() }
                , function (response) {
                    if ($("string", response).text() == "true") {
                        //var result = $("string", response).text();
                        alert("支付成功，请注意查收交易凭证！");
                    }
                }, false);
           }
</script>