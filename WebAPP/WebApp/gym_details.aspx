<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gym_details.aspx.cs" Inherits="WebAPP.WebApp.gym_details" %>

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
    <title><%=GYMName %></title>

    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.css" rel="stylesheet">
    <link href="../css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../assets/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen"/>
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
    #owl-demo .item img{
    display: block;
    width: 100%;
    height: auto;
}
    </style>
  </head>

  <body>
      <form id="form1" runat="server">
 <div>
    <section>
    <div class="col-lg-6">
        <section class="panel">
            <header class="panel-heading">
                <%=GYMName %>
                <span class="tools pull-right">
                <a href="javascript:;" class="icon-chevron-down"></a>
<%--                <a href="javascript:;" class="icon-remove"></a>--%>
            </span>
            </header>
            <a id="agymname" style="display:none"><%=GYMName %></a>
            <div class="panel-body">
                <div id="demo">
                                        <div class="container">
                                        <div class="row">
                                            <div class="span12">
                                            <div id="owl-demo" class="owl-carousel">
                                                <asp:Repeater ID="repPicList" runat="server">
                                                    <ItemTemplate>
                                                        <div><img src="../img/coachpic/<%# Eval("Pic") %>"></div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            </div>
                                        </div>
                                        </div>
                                    </div>
            </div>
        </section>

                  </div>
    <div class="col-lg-6">
        <section class="panel">
            <header class="panel-heading">
                详细信息
                <span class="tools pull-right">
                <a href="javascript:;" class="icon-chevron-down"></a>
<%--                <a href="javascript:;" class="icon-remove"></a>--%>
            </span>
            </header>
            <div class="panel-body">
                <p>电话：<asp:Label ID="lblTel" runat="server" Text=""></asp:Label>&nbsp;&nbsp;<%--<a href="javascript:void(null)" onclick="CustomerService.ConnectCustomerService('<%=openid %>')">人工咨询</a>--%></p>
                <p>地址：<asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></p>
                <p>类型：<asp:Label ID="lblType" runat="server" Text=""></asp:Label></p>
                <p>区域：<asp:Label ID="lblRegion" runat="server" Text=""></asp:Label></p>
              <%--  <p>微信：<%=lblWeiXin%></p>
                <p>电话：<a href="tel:<%=lblTel %>"><%=lblTel%></a></p>--%>
                <p>
                 <button type="button" class="btn btn-success btn-xs" onclick="location.href='gym_subscribe.aspx?gymid=<%# Eval("GYMID") %>'" <%= IssSubscribe != "1" ? "style='display:none'" : "" %>>预定</button>&nbsp;<button type="button" class="btn btn-success btn-xs" onclick="location.href='gym_productlist.aspx?gymid=<%# Eval("GYMID") %>'" <%= IsShop != "1" ? "style='display:none'" : "" %>>办卡</button></p>
                <p><i class="icon-bullhorn"></i>&nbsp;<font color="red"><asp:Label ID="lblNewsLine" runat="server"></asp:Label></font></p>
                <p>详细信息：<asp:Label ID="lblDetails" runat="server"></asp:Label></p>
            </div>
        </section>

                  </div>
    </section>
    <ul class="inbox-nav inbox-divider">
        <li>
            <a href="#"><i class="icon-eye-open"></i>浏览次数：<%=ViewCount %></a>
        </li>
    </ul>
</div>
                                      
    <!-- js placed at the end of the document so the pages load faster -->
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="../js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/jquery.sparkline.js" type="text/javascript"></script>
    <script src="../assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js"></script>
    <script src="../js/owl.carousel.js" ></script>
    <script src="../js/jquery.customSelect.min.js" ></script>
    <script src="../js/respond.min.js" ></script>

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
      //owl carousel
      $(document).ready(function () {
          $("#owl-demo").owlCarousel({
              //autoPlay: 3000,
              stopOnHover: true,
              //navigation: true,
              paginationSpeed: 1000,
              goToFirstSpeed: 2000,
              singleItem: true,
              //autoHeight: true,
              transitionStyle: "fade"
          });
      });
      //custom select box
  </script>

      </form>

  </body>
</html>