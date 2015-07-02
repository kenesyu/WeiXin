<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubscribeRedPack.aspx.cs" Inherits="WebAPP.WebApp.SubscribeRedPack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en" xmlns="http://www.w3.org/1999/html">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <link rel="shortcut icon" href="img/favicon.png">

    <title>感谢关注</title>

    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-reset.css" rel="stylesheet">
    <!--external css-->
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 tooltipss and media queries -->
    <!--[if lt IE 9]>
      <script src="js/html5shiv.js"></script>
      <script src="js/respond.min.js"></script>
    <![endif]-->
  </head>

  <body>

  <section class="">
      <!--sidebar end-->
      <!--main content start-->
      <section>
          <section class="wrapper" style=" margin-top:0px; padding:0px">
              <!-- page start-->
              <div class="row">
                  <div class="col-lg-4">
                      <!--widget start-->
                      <aside class="profile-nav alt green-border">
                          <section class="panel">
                              <div class="user-heading alt green-bg">
                                  <a href="#">
                                      <img alt="" src="img/profile-avatar.jpg" runat="server" id="imgProfile">
                                  </a>
                                  <h1><asp:Label runat="server" ID="lblNickname"></asp:Label></h1>
                                  <p><asp:Label runat="server" ID="lblCity"></asp:Label>，<asp:Label runat="server" ID="lblSex"></asp:Label></p>
                              </div>

                              <ul class="nav nav-pills nav-stacked">
                                  <li><a href="javascript:;"><asp:Label ID="lblmessage" runat="server" Text = "感谢您的关注，本次活动已经结束，小伙伴们不要气馁，敬请期待近期其它活动内容。"></asp:Label></li>
                              </ul>

                          </section>
                      </aside>
                      <!--widget end-->
                      <!--widget start-->
                      <div class="panel" style="display:block">
                          <div class="panel-body">
                              <table cellpadding="0" cellspacing="0" width="95%">
                                <tr>
                                    <td colspan="4" align="center"><b>领取红包记录</b></td>
                                </tr>
                                <asp:Repeater runat="server" ID="repList">
                                <ItemTemplate>
                                <tr>
                                    <td><img src="<%# Eval("headimgurl") %>" width="50px" height="50px"></td>
                                    <td><%# st(Eval("nickname").ToString(),7) %></td>
                                    <td>￥<font color='red'><%# Convert.ToDouble(Eval("amount")) / 100 %></font></td>
                                    <td><%# Convert.ToDateTime(Eval("CreateTime")).ToString("hh:mm:ss") %></td>
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                              </table>
                          </div>
                      </div>
                      <!--widget end-->
                  </div>
              </div>
              <!-- page end-->
          </section>
      </section>
      <!--main content end-->
  </section>

    <!-- js placed at the end of the document so the pages load faster -->
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="../js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../assets/jquery-knob/js/jquery.knob.js"></script>
    <script src="../js/respond.min.js" ></script>

    <!--common script for all pages-->
    <script src="../js/common-scripts.js"></script>

  <script>

      //knob
      $(".knob").knob();

  </script>

  </body>
</html>
