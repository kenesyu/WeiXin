<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WebAPP.WebApp.WXPay.Products" %>

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
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 tooltipss and media queries -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>

<body>
<!--main content start-->
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
                        <tr>
                            <td>商品名称：</td>
                            <td><asp:Label ID="lblProductName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>优惠价：</td>
                            <td><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>使用说明：</td>
                            <td><asp:Label ID="lblDetails" runat="server"></asp:Label></td>
                        </tr>
                        </tbody>
                    </table>
                </section>
            </div>
        </div>
        <!-- page end-->
    </section>
</section>
<!--main content end-->
<div>
    <%= WeiPay.PayConfig.AppId %> </br>
    <%= TimeStamp %></br>
    <%= NonceStr %></br>
    <%= Package %></br>
    <%= PaySign %>
</div>
<div class="ui-btn pay-btn" onclick="SavePay()">立即购买</div>

<script type="text/javascript">

    function SavePay() {
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
                       alert("微信支付成功!");
                   } else if (res.err_msg == "get_brand_wcpay_request:cancel") {
                       alert("用户取消支付!");
                   } else {
                       alert(res.err_msg);
                       alert("支付失败!");
                   }
                   // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回ok，但并不保证它绝对可靠。
                   //因此微信团队建议，当收到ok返回时，向商户后台询问是否收到交易成功的通知，若收到通知，前端展示交易成功的界面；若此时未收到通知，商户后台主动调用查询订单接口，查询订单的当前状态，并反馈给前端展示相应的界面。
               });
    }
   


</script>
</body>
</html>