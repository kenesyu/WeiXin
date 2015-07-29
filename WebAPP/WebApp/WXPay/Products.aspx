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
                        <tr>
                            <td>商品名称：</td>
                            <td align="left"><asp:Label ID="lblProductName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>优惠价：</td>
                            <td align="left"><asp:Label ID="lblPrice" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>使用说明：</td>
                            <td align="left">
                            <asp:Label ID="lblDetails" runat="server"></asp:Label>
                            <input type="text" runat="server" id="txtOpenID" style="display:none"/>
                            <input type="text" runat="server" id="txtid" style="display:none" />
                            </td>
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
<asp:Button Text="立即购买" runat="server" class="ui-btn pay-btn" ID="BtnSave" 
        onclick="BtnSave_Click" />
        </form>
</body>
</html>