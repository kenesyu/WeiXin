<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coach_list.aspx.cs" Inherits="WebAPP.WebApp.coach_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Mosaddek">
    <meta name="keyword" content="FlatLab, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=yes">
    <link rel="shortcut icon" href="../img/favicon.png">
    <title>找教练</title>
    <!-- Bootstrap core CSS -->
    <link href="../css/bootstrap.css" rel="stylesheet">
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
    <form id="form1" runat="server">
        <div>
            <section class="panel">
        <header class="panel-heading">&nbsp;
            教练列表
            <span class="tools pull-right">
            <div class="btn-group" id="btn1">
                <button data-toggle="dropdown" id="btnSport" searKey="" class="btn btn-primary dropdown-toggle btn-sm" type="button">所有项目<span class="caret"></span></button>
                <ul role="menu" class="dropdown-menu" id="selSport">
                    <asp:Repeater ID="repMenuSports" runat="server">
                        <HeaderTemplate>
                            <li><a key ="" onclick="Search(this,$('#btnSport'))">所有项目</a></li>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><a key='<%# Eval("SportID") %>' onclick='Search(this,$("#btnSport"))'><%# Eval("SportName") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="btn-group" id="btn2" >
                <button data-toggle="dropdown" id="btnRegion" searKey="" class="btn btn-primary dropdown-toggle btn-sm" type="button">全部区域<span class="caret"></span></button>
                <ul role="menu" class="dropdown-menu" id="selRegion">
                    <asp:Repeater ID="repMenuRegion" runat="server">
                        <HeaderTemplate>
                            <li><a key ="" onclick="Search(this,$('#btnRegion'))">全部区域</a></li>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><a key='<%# Eval("RegionID")%>' onclick="Search(this,$('#btnRegion'))"><%# Eval("RegionName")%></a></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </span>
        </header>
        <div class="panel-body" id="MessageDiv" style="overflow:auto; bottom:0; top:40px">
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
            <p>fdsfsdafsadfsadfsdafasdfasdf<p>
        </div>
    </section>
        </div>
    </form>
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script class="include" type="text/javascript" src="../js/jquery.dcjqaccordion.2.7.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../assets/jquery-knob/js/jquery.knob.js"></script>
    <script src="../js/respond.min.js"></script>
    <!--common script for all pages-->
    <script src="../js/common-scripts.js"></script>
    <script>
        //knob
        $(".knob").knob();
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            if (r != null) return unescape(r[2]); return null; //返回参数值
        }

        function Search(obj, objTo) {
            $(objTo).text($(obj).text());
            $(objTo).attr("searKey", $(obj).attr("key"));

            var r = $("#btnRegion").attr("searKey");
            var s = $("#btnSport").attr("searKey");

            //if (r == "全部区域") r = "";
            //if (s == "所有项目") s = "";

            //alert(encodeURI(r))
            var url = "list.aspx?r=" + r + "&s=" + s;
            //url = escape(url);
            //alert(url)
            location.href = url;
        }

        function SetSearch() {
            var r = getUrlParam('r');
            var s = getUrlParam('s');
            //alert("r:" + r + "s:" + s)
            if (r != "" && r != undefined) {
                $("#btnRegion").attr("searKey", r);
                $("#btnRegion").text($("#selRegion").find("a[key='" + r + "']").eq(0).text());
            }
            if (s != "" && s != undefined) {
                $("#btnSport").attr("searKey", s);
                $("#btnSport").text($("#selSport").find("a[key='" + s + "']").eq(0).text());
            }
            var right = 10 + 5 + $("#btn2").width();
            $("#btn1").css("right", right);
        }
        SetSearch();
        $("#MessageDiv").css("max-height", $(window).height() - 40);
        $("#MessageDiv").css("max-width", $(window).width());
    </script>
</body>
</html>
