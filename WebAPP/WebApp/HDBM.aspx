<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HDBM.aspx.cs" Inherits="WebAPP.WebApp.HDBM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="../img/favicon.png">
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=yes">
    <meta name="format-detection" content="telephone=yes">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <title>活动报名</title>
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.css" rel="stylesheet">
    <link href="../css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../assets/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet"
        type="text/css" media="screen" />
    <link rel="stylesheet" href="../css/owl.carousel.css" type="text/css">
    <link href="../css/owl.theme.css" rel="stylesheet">
    <link href="../css/owl.transitions.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 tooltipss and media queries -->
    <!--[if lt IE 9]>
      <script src="js/html5shiv.js"></script>
      <script src="js/respond.min.js"></script>
    <![endif]-->
    <style>
        #owl-demo .item img
        {
            display: block;
            width: 100%;
            height: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" onsubmit="if(!confirm('您的报名信息一但创建将无法修改，请确认！')){ return false }">
    <div>
        <div class="form-group">
            <label for="exampleInputEmail1">活动名称</label>
            <input type="text" class="form-control" style=" color:Black" id="txtHDName" disabled="disabled" runat="server" placeholder="">
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">姓名</label>
            <input type="text" class="form-control" id="txtName" runat="server" placeholder="请输入您的姓名">
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">性别</label>
            <select id="selSex" runat="server"  class="form-control">
                <option value="男">男</option>
                <option value="女">女</option>
            </select>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">联系电话</label>
            <input type="text" class="form-control" id="txtTel" runat="server" placeholder="添写真实有效的联系方式，我们会致电您以核实名额">
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">参与人数</label>
            <select id="selPersonCount" runat="server" class="form-control">
                <option value="1">1</option>
                <option value="2">2</option>
            </select>
            <input type="text" id="txtopenid" value="" runat="server" style="display:none">
            <input type="text" id="txtid" value="" runat="server" style="display:none">
            <input type="text" id="txthdid" value="" runat="server" style="display:none">
            <input type="text" id="txtNeedPay" value="" runat="server" style="display:none">
        </div>
        <asp:Button Text="确认报名" runat="server" class="btn btn-info" ID="btnSave" 
            onclick="btnSave_Click" />
    </div>
    </form>
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="../js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/jquery.sparkline.js" type="text/javascript"></script>
    <script src="../assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js"></script>
    <script src="../js/owl.carousel.js"></script>
    <script src="../js/jquery.customSelect.min.js"></script>
    <script src="../js/respond.min.js"></script>
    <script class="include" type="text/javascript" src="../js/jquery.dcjqaccordion.2.7.js"></script>
    <!--common script for all pages-->
    <script src="../js/common-scripts.js"></script>
    <!--script for this page-->
    <script src="../js/sparkline-chart.js"></script>
    <script src="../js/easy-pie-chart.js"></script>
    <script src="../js/count.js"></script>
    <script src="../ScriptsLib/CustomerServices.js"></script>
    <script src="../ScriptsLib/Core/IsTech_core.js"></script>
    <script src="../ScriptsLib/Core/IsTech_form.js"></script>
    <script>
</body>
</html>
