<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hd.aspx.cs" Inherits="WebAPP.WebApp.hd" %>

<!DOCTYPE html>
<!-- saved from url=(0107)http://mp.weixin.qq.com/s?__biz=MzA4Nzc0MTExNw==&mid=206843263&idx=1&sn=ab0b75fedf7f9d0c84a4f64853f7ea75#rd -->
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <script type="text/javascript">
        var sampling = Math.random() < 0.001;
        var page_begintime = (+new Date());
        (sampling) && ((new Image()).src = "http://isdspeed.qq.com/cgi-bin/r.cgi?flag1=7839&flag2=7&flag3=8&15=1000&r=" + Math.random());

        var biz = "MzA4Nzc0MTExNw==";
        var sn = "ab0b75fedf7f9d0c84a4f64853f7ea75" || "";
        var mid = "206843263" || "";
        var idx = "1" || "";

        //辟谣需求
        var is_rumor = "" * 1;
        var norumor = "" * 1;
        if (!!is_rumor && !norumor) {
            if (!document.referrer || document.referrer.indexOf("mp.weixin.qq.com/mp/rumor") == -1) {
                location.href = "http://mp.weixin.qq.com/mp/rumor?action=info&__biz=" + biz + "&mid=" + mid + "&idx=" + idx + "&sn=" + sn + "#wechat_redirect";
            }
        }

        //原创需求，需要跳转到中间页
        /*
        var copyrightInfo = {
        display_source : ""*1,
        nocopyrightsource : ""*1
        };
        if (!!copyrightInfo.display_source&&!copyrightInfo.nocopyrightsource){
        if (!document.referrer || document.referrer.indexOf("mp.weixin.qq.com/mp/reprint") == -1){
        location.href = "http://mp.weixin.qq.com/mp/reprint?action=info&__biz=" + biz + "&mid=" + mid + "&idx=" + idx + "&sn=" + sn + "#wechat_redirect";
        }
        }*/
</script>
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
    <link rel="dns-prefetch" href="http://res.wx.qq.com/">
    <link rel="dns-prefetch" href="http://mmbiz.qpic.cn/">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1.0,maximum-scale=1.0,user-scalable=0">
    <link rel="shortcut icon" type="image/x-icon" href="http://res.wx.qq.com/mmbizwap/zh_CN/htmledition/images/icon/common/favicon22c41b.ico">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <script type="text/javascript">
        var uin = "";
        var key = "";
        var pass_ticket = "";

        String.prototype.html = function (encode) {
            var replace = ["&#39;", "'", "&quot;", '"', "&nbsp;", " ", "&gt;", ">", "&lt;", "<", "&amp;", "&", "&yen;", "¥"];
            //console.log(replace);
            if (encode) {
                replace.reverse();
            }
            for (var i = 0, str = this; i < replace.length; i += 2) {
                str = str.replace(new RegExp(replace[i], 'g'), replace[i + 1]);
            }

            return str;
        };
        pass_ticket = encodeURIComponent(pass_ticket.html(false).html(false).replace(/\s/g, "+"));
</script>
    <title>活动报名</title>
    <link rel="stylesheet" type="text/css" href="files/page_mp_article_improve265a3c.css">
    <style>
        
    </style>
    <!--[if lt IE 9]>
<link rel="stylesheet" type="text/css" href="http://res.wx.qq.com/mmbizwap/zh_CN/htmledition/style/page/appmsg/page_mp_article_improve_pc2637ae.css">
<![endif]-->
    <script type="text/javascript">
        document.domain = "qq.com";
</script>
    <script src="files/version4video26eb5e.js" type="text/javascript" async=""></script>
    <link rel="stylesheet" type="text/css" href="files/not_in_mm2637ae.css">
</head>
<body id="activity-detail" class="zh_CN mm_appmsg not_in_mm" ontouchstart="">
    <script type="text/javascript">
        var write_sceen_time = (+new Date());
        (sampling) && ((new Image()).src = "http://isdspeed.qq.com/cgi-bin/r.cgi?flag1=7839&flag2=7&flag3=8&16=1000&r=" + Math.random());
    </script>
    <div id="js_cmt_mine" class="discuss_container editing access" style="display: none;">
        <div class="discuss_container_inner">
            <h2 class="rich_media_title">
                报名页面test</h2>
            <div class="frm_textarea_box_wrp">
                <span class="frm_textarea_box">
                    <textarea id="js_cmt_input" class="frm_textarea" placeholder="评论将由公众帐号筛选后显示，对所有人可见。"></textarea>
                </span>
            </div>
            <div class="discuss_btn_wrp">
                <a id="js_cmt_submit" class="btn btn_primary btn_discuss btn_disabled" href="javascript:;">
                    提交</a></div>
            <div class="discuss_list_wrp" style="display: none">
                <div class="rich_tips with_line title_tips discuss_title_line">
                    <span class="tips">我的评论</span>
                </div>
                <ul class="discuss_list" id="js_cmt_mylist">
                </ul>
            </div>
            <div class="rich_tips tips_global loading_tips" id="js_mycmt_loading">
                <img src="files/icon_loading_white22c04a.gif" class="rich_icon icon_loading_white"
                    alt="">
                <span class="tips">加载中</span>
            </div>
            <div class="wx_poptips" id="js_cmt_toast" style="display: none;">
                <img alt="" class="icon_toast" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGoAAABqCAYAAABUIcSXAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA3NpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNS1jMDE0IDc5LjE1MTQ4MSwgMjAxMy8wMy8xMy0xMjowOToxNSAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDoyMTUxMzkxZS1jYWVhLTRmZTMtYTY2NS0xNTRkNDJiOGQyMWIiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6MTA3QzM2RTg3N0UwMTFFNEIzQURGMTQzNzQzMDAxQTUiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6MTA3QzM2RTc3N0UwMTFFNEIzQURGMTQzNzQzMDAxQTUiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIChNYWNpbnRvc2gpIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6NWMyOGVjZTMtNzllZS00ODlhLWIxZTYtYzNmM2RjNzg2YjI2IiBzdFJlZjpkb2N1bWVudElEPSJ4bXAuZGlkOjIxNTEzOTFlLWNhZWEtNGZlMy1hNjY1LTE1NGQ0MmI4ZDIxYiIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/Pmvxj1gAAAVrSURBVHja7J15rF1TFMbXk74q1ZKHGlMkJVIhIgg1FH+YEpEQJCKmGBpThRoSs5jVVNrSQUvEEENIhGiiNf9BiERICCFIRbUiDa2qvudbOetF3Tzv7XWGffa55/uS7593977n3vO7e5+199p7v56BgQGh0tcmvAUERREUQVEERREUQVEERREUQVEERREUQVEERREUQVEERREUQVEERVAUQVEERVAUQbVYk+HdvZVG8b5F0xj4RvhouB+eCy8KrdzDJc1RtAX8ILxvx98V1GyCSkN98Cx4z/95/Wn4fj6j6tUEeN4wkFSnw1MJqj5NhBfAuwaUHREUg4lqNMmePVsHll/HFhVfe1t3FwpJI8DXCCquDrCWNN4B6Tb4M3Z98aTPmTvh0YHl18PXw29yZiKejoPvcUD6E74yFBJbVDk6Bb7K8aP/Hb4c/tRzEYIqprPhSxzlf4Uvhb/0Xoig8qnHAJ3lqPMzfDH8XZ4LEpRf2sVdA5/sqPO9Qfop70UJyn+/boaPddT5yrq7VUUvTIVJI7q74MMddXR8NB1eXcYvhBpZm0s2w72/o86HFoKvLau/pYaXzjLMdUJ6y0LwtWV9CIIaXtvA8+G9HHV03u5q+K+yH47U0NoRngPv7KjzHDwTLj0bS1BDazfJJlcnOOostC6ysnCT+q80G/sIvFVgeW09D8FPVT0uoP7VfvAD8NjA8pqmuAN+OcYAjso0RbIZ8DGB5TVNcRO8JMaHY9SXSdfa3eeANJimWBLrA7JFiZwIXye+NMUV8CcxP2SRFjXefok7NRjSGZJlWUPvw2/wtNiQirSoXWyMsR28wR7AzzYM0oXw+Y7yK+CLJGeaoqjyrJSdZJD6Ov4+z5y6NJc0Az7NUecHydIUy+v60KNyQHoM3nKI1y7YCFiq0i7uBvgER52vDdKqWn9djhY1Dn4G3n6Ecqm2rF74dvgoR53S0hQxW9RJAZAGW5bSn58QJA27dQ7uIEedjywEX5NKVxCqsY6y+qA+LxFI4+yZ6oH0trWkNan80jygtIUsc5SflgAsDXgehfdx1KkkTRE76tN+Xue2jnTU0Ru1oIbvpt30bBtKhOp5yaaRkts0lic8V1i6dPcIRx2d/l8Y8XtNNEg7OOo8bl1kmmOKnDsO88CaYzejau0hWZqiL7C83oCH4SeTHvwV2BqqsHRVztSEYOmWF80NeXZT6Hd4KflResE9vCnBOlCyGfDNAstHTVPUDWoQ1t3iW+9WNizvlhfd4aerXd+ThqiMfNR6+9LvOOro5OY5JX2H4+F7HZD+kGzlamMgldWiirQsjcwWFbjmqZJteekJLK9pisvgL6RhKvuciZiwzrWWGapfrPy30kBVcSBIrw0aD3PU0XB6cehntq7rTMf7/2iQlktDVdXJLXlg6VjmiYBn6rWSTRCH6hvJ0hQrpcGq8oidsmHpTP8t8DGO9/vcWt9qabiqPgup1yKyQwvC2tSefZ73SSpNkUJ4PlLorlHZ+446nc8f3fIyywlJhwrTuwVSjBa1ccvSxN0hjjoK5xVrYZMd9V6XbFfgBukixTwGLg8sDam3dZR/wZ6L/dJlin1en8LS+bgpFbz3Ygvzu1J1HKxYNqxGpCmaCEo12rrBorD6LRp8UbpcdR5VWhTW35KlKd6QFqjuM2XzwlpnMxTvSkuUwuG/Xlg6NtPjbT6WFimF/VG6LEvXgn8QGDjMbBukVECFwhpoS+CQatfX2Q1q6H7wENHdrfCr0lKleEB9JyxNneus+VJpsVL9TwI6W65LovWIGl3KtVJaLv7LBwYTFEERFEVQFEERFEVQFEERFEVQFEERFEVQFEERFEVQFEERFFWq/hFgADUMN4RzT6/OAAAAAElFTkSuQmCC">
                <p class="toast_content">
                    已评论</p>
            </div>
        </div>
    </div>
    <div id="js_article" class="rich_media">
        <div id="js_top_ad_area" class="top_banner">
        </div>
        <div class="rich_media_inner">
            <div id="page-content">
                <div id="img-content" class="rich_media_area_primary">
                    <div class="rich_media_content" id="js_content">
                        <fieldset style="border: 0px none;">
                            <section style="border: 3px solid rgb(245,66,66); padding: 5px;"><section data-bcless="lighten" style="border: 1px solid rgb(245,66,66); padding: 15px; text-align: center; color: inherit;"><p style="color: inherit; font-size: 12px;"><img src="../img/logo.jpg" width="299" height="189" style="width: 299px !important; height: auto !important; visibility: visible !important;" data-ratio="0.6254180602006689" data-w="299" _width="299px" ></p></section></section>
                        </fieldset>
                            <br>
                        <section class="wxqq-borderTopColor wxqq-borderRightColor wxqq-borderBottomColor wxqq-borderLeftColor"
                            style="border: 1px solid rgb(30, 168, 30); box-shadow: rgb(226, 226, 226) 0em 1em 0.1em -0.6em;
                            line-height: 1.6em;"><section class="wxqq-bg" style="padding: 1em; color: rgb(255, 255, 255); text-align: center; font-size: 1.4em; font-weight: bold; line-height: 1.4em; box-shadow: rgb(221, 221, 221) 0em 0.2em 0.2em; background-color: rgb(30, 168, 30);"><span style="font-size: 1.4em;">射箭中心免费体验</span></section><section><section style="display: inline-block; width: 60%; padding: 0.2em; margin-left: 0.5em; font-size: 1em; color: inherit;"></section><p>    活动时间：2015年7月11日 9:30—11:00</p><p><span style="line-height: 1.6em;">    活动地点：</span><span style="line-height: 1.6em;">大连第一射箭中心</span><br></p></section><section style="display: inline-block;background-color: rgb(249, 110, 87); height: 2em; max-width: 100%;margin-top: 1.5em; line-height: 1em; box-sizing: border-box;"><section style="height: 2em; max-width: 100%; padding: 0.5em 1em; color: rgb(255, 255, 255); text-overflow: ellipsis; font-size: 1em;">报名方法</section></section><p><span style="line-height: 25.59375px;">      说明：本活动是大连运动健身网微信公众平台粉丝</span><span style="line-height: 25.59375px;">专享</span><span style="line-height: 25.59375px;">福利活动，名额30人，先到先得。您点击报名以后，我们微信公众平台的客服会尽快与您取得联系，确认您的报名信息。</span></p><p><span style="line-height: 25.59375px;"><br></span></p><p><a href="javascript:void(null)" onclick="CustomerService.ConnectCustomerService('<%=openid %>','射箭中心免费体验')">点此报名</a></p></section>
                        <br><section class="wxqq-borderTopColor wxqq-borderRightColor wxqq-borderBottomColor wxqq-borderLeftColor"
                            style="border: 1px solid rgb(30, 168, 30); box-shadow: rgb(226, 226, 226) 0em 1em 0.1em -0.6em;
                            line-height: 1.6em;"><section class="wxqq-bg" style="padding: 1em; color: rgb(255, 255, 255); text-align: center; font-weight: bold; line-height: 1.4em; box-shadow: rgb(221, 221, 221) 0em 0.2em 0.2em; background-color: rgb(30, 168, 30);"><span style="font-size: 27.440000534057617px;">免费学网球</span></section><section><p><span style="font-size: 14px; line-height: 22.390625px;"> </span></p><p><span style="font-size: 14px; line-height: 22.390625px;"><span style="font-size: 16px; line-height: 22.390625px;">     活动时间：2015年7月12日 13:30-15:30</span></span></p><p><span style="font-size: 16px; line-height: 22.390625px;">     活动地点：大连市体育中心网球馆</span></p></section><section style="display: inline-block;background-color: rgb(249, 110, 87); height: 2em; max-width: 100%;margin-top: 1.5em; line-height: 1em; box-sizing: border-box;"><section style="height: 2em; max-width: 100%; padding: 0.5em 1em; color: rgb(255, 255, 255); text-overflow: ellipsis; font-size: 1em;"><span style="font-size: 14px; line-height: 14px;">报名方法</span></section></section><p>      说明：本活动是大连运动健身网微信公众平台粉丝<span style="line-height: 25.59375px;">专享</span>福利活动，名额30人，先到先得。您点击报名以后，我们微信公众平台的客服会尽快与您取得联系，确认您的报名信息。</p><p><br></p><p>   <a href="javascript:void(null)" onclick="CustomerService.ConnectCustomerService('<%=openid %>','免费学网球')">点此报名</a></p></section>
                        <br><section class="wxqq-borderTopColor wxqq-borderRightColor wxqq-borderBottomColor wxqq-borderLeftColor"
                            style="border: 1px solid rgb(30, 168, 30); box-shadow: rgb(226, 226, 226) 0em 1em 0.1em -0.6em;
                            line-height: 1.6em;"><section class="wxqq-bg" style="padding: 1em; color: rgb(255, 255, 255); text-align: center; font-size: 1.4em; font-weight: bold; line-height: 1.4em; box-shadow: rgb(221, 221, 221) 0em 0.2em 0.2em; background-color: rgb(30, 168, 30);"><span style="font-size: 1.4em;">免费健身次卡</span></section><section><section style="display: inline-block; width: 60%; padding: 0.2em; margin-left: 0.5em; font-size: 1em; color: inherit;"></section><p>   活动时间：2015年7月11日至2015年7月18日</p><p><span style="line-height: 1.6em;">    活动地点：大连鼎龙健身俱乐部 和平广场店</span><br></p></section><section style="display: inline-block;background-color: rgb(249, 110, 87); height: 2em; max-width: 100%;margin-top: 1.5em; line-height: 1em; box-sizing: border-box;"><section style="height: 2em; max-width: 100%; padding: 0.5em 1em; color: rgb(255, 255, 255); text-overflow: ellipsis; font-size: 1em;"><span style="font-size: 14px; line-height: 14px;">报名方法</span></section></section><p>      说明：本活动是大连运动健身网微信公众平台粉丝<span style="line-height: 25.59375px;">专享</span>福利活动，名额100人，先到先得。您点击报名以后，我们微信公众平台的客服会尽快与您取得联系，确认您的报名信息。</p><p><br></p><p>   <a href="javascript:void(null)" onclick="CustomerService.ConnectCustomerService('<%=openid %>','免费健身次卡')">点此抢次卡</a></p></section>
                    </div>
                    <script type="text/javascript">
                        var first_sceen__time = (+new Date());
                    </script>
                    <link rel="stylesheet" type="text/css" href="files/page_mp_article_improve_combo26590f.css">
                    <div class="rich_media_tool" id="js_toobar">
                        <div id="js_read_area" class="media_tool_meta tips_global meta_primary" style="display: none;">
                            阅读 <span id="readNum"></span>
                        </div>
                        <span style="display: none;" class="media_tool_meta meta_primary tips_global meta_praise"
                            id="like"><i class="icon_praise_gray"></i><span class="praise_num" id="likeNum">
                            </span></span><a id="js_report_article" style="display: none;" class="media_tool_meta tips_global meta_extra"
                                href="javascript:void(0);">举报</a>
                    </div>
                </div>
                <div class="rich_media_area_extra">
                    <div class="mpda_bottom_container" id="js_bottom_ad_area">
                    </div>
                    <div id="js_iframetest" style="display: none;">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
